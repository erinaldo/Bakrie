'
' Programmer: Dadang Adi Hendradi
'
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading

Imports CheckRoll_PPT
Imports CheckRoll_DAL
Imports CheckRoll_BOL

Imports Common_PPT ' Thursday, 10 Sep 2009, 03:06


Public Class Censuss

    Private EstateID As String = System.DBNull.Value.ToString()
    Private EstateCode As String = System.DBNull.Value.ToString()
    Private ActiveMonthYear As String = System.DBNull.Value.ToString()
    Private MenuForm As MDIParent ' MDIParent form
    Private USER_NAME As String = System.DBNull.Value.ToString()

    Private CensusTableAdapter As Census_DAL
    Private DT_Census As DataTable = Nothing
    Private rowIndexGrid As Integer = -1

    ' Selasa, 27 Oct 2009, 19:30
    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False

    Private Sub SetUICulture(ByVal culture As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Censuss))
        Try
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblDate.Text = rm.GetString("lblDate.Text")
            lblDiv.Text = rm.GetString("lblDiv.Text")
            lblYOP.Text = rm.GetString("lblYOP.Text")
            lblSuBlock.Text = rm.GetString("lblSuBlock.Text")
            lblAreaPlanted.Text = rm.GetString("lblAreaPlanted.Text")
            lblPlantDensityRequired.Text = rm.GetString("lblPlantDensityRequired.Text")
            lblPlantDensityActual.Text = rm.GetString("lblPlantDensityActual.Text")

            lblTLJalanPoros.Text = rm.GetString("lblTLJalanPoros.Text")
            lblTLMainRoad.Text = rm.GetString("lblTLMainRoad.Text")
            lblTLCollectionRoad.Text = rm.GetString("lblTLCollectionRoad.Text")
            lblNoOfBunches.Text = rm.GetString("lblNoOfBunches.Text")
            lblTotalFFB.Text = rm.GetString("lblTotalFFB.Text")

            tcCensus.TabPages(0).Text = rm.GetString("tcCensus.TabPages(0).Text")
            tcCensus.TabPages(1).Text = rm.GetString("tcCensus.TabPages(1).Text")

            lblViewStartDate.Text = rm.GetString("lblViewStartDate.Text")
            lblViewEndtDate.Text = rm.GetString("lblViewEndtDate.Text")
            pnlCategorySearch.CaptionText = rm.GetString("pnlCategorySearch.CaptionText")

            btnAdd.Text = rm.GetString("btnAdd.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnSaveAll.Text = rm.GetString("btnSaveAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnViewReport.Text = rm.GetString("btnViewReport.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ''
    End Sub

    Private Sub Censuss_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles Me.Invalidated

    End Sub

    Private Sub Censuss_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'msktxtDate.Text = Date.Now.ToString("dd/MM/yyyy")
        dtpCensusDateStartSearch.Value = Date.Now

        CensusTableAdapter = New Census_DAL()

        'DT_Census = CensusTableAdapter.CensusSelectByDate(dtpCensusDate.Value, Nothing)
        DT_Census = Census_BOL.CRCensusByDateSelect(dtpCensusDate.Value, New Date(1980, 1, 1))

        dgvCensus.DataSource = DT_Census
        HiddenGridColumnCensus()

        ClearInput()
        tcCensus.SelectedTab = tabView
        selectCensusByDate()

        'Kamis, 10 Sep 2009, 00:19
        SetUICulture(GlobalPPT.strLang)
        ' Rabu, 30 Sep 2009, 16:23
        ' Masalah di ADO.NET, kalo windows control panel di set format date nya ke dd/MM/yyyy
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()
        dtpCensusDateStartSearch.Focus()


    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubBlockLookupButton.Click
        Dim w As Windows.Forms.DialogResult
        Dim SubBlockLoop_Form As New SubBlockLookups(txtSubBlock.Text)

        SubBlockLoop_Form.SubBlockName = txtSubBlock.Text

        w = SubBlockLoop_Form.ShowDialog()
        If (w = Windows.Forms.DialogResult.OK) Then
            Me.txtSubBlock.Text = SubBlockLoop_Form.SubBlockName
            Me.txtDIV.Text = SubBlockLoop_Form.DIV
            Me.txtYOP.Text = SubBlockLoop_Form.YOP

            lblSubBlockID.Text = SubBlockLoop_Form.SubBlockID
            lblDivID.Text = SubBlockLoop_Form.DivID
            lblYOPID.Text = SubBlockLoop_Form.YOPID

            txtAreaPlanted.Focus()
        End If

    End Sub

    Private Sub txtSubBlock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubBlock.KeyDown
        ' Kamis, 3 Sep 2009, 11:31
        If e.KeyCode = Keys.Enter Then
            If Not txtSubBlock.Text = String.Empty Then


                Dim dt As New DataTable
                dt = Census_DAL.CRSubBlockSelect(txtSubBlock.Text.Trim)
                'txtSubBlock.Focus()
                If dt.Rows.Count >= 1 Then
                    Me.txtSubBlock.Text = dt.Rows(0).Item("BlockName").ToString()
                    Me.txtDIV.Text = dt.Rows(0).Item("DivName").ToString()
                    Me.txtYOP.Text = dt.Rows(0).Item("YOP").ToString()
                    lblSubBlockID.Text = dt.Rows(0).Item("BlockID").ToString()
                    lblDivID.Text = dt.Rows(0).Item("DivID").ToString()
                    lblYOPID.Text = dt.Rows(0).Item("YOPID").ToString()
                    txtAreaPlanted.Focus()

                Else

                    'Me.txtSubBlock.Text = SubBlockLoop_Form.SubBlockName
                    Me.txtDIV.Text = String.Empty
                    Me.txtYOP.Text = String.Empty
                    lblSubBlockID.Text = String.Empty
                    lblDivID.Text = String.Empty
                    lblYOPID.Text = String.Empty
                    MsgBox("Field No Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    txtSubBlock.Text = String.Empty

                End If
            Else
                Me.txtDIV.Text = String.Empty
                Me.txtYOP.Text = String.Empty
                lblSubBlockID.Text = String.Empty
                lblDivID.Text = String.Empty
                lblYOPID.Text = String.Empty
            End If
            ''Sabtu, 5 Sep 2009, 15:08
            '' Dim DT_SubBlock As DataTable = Census_DAL.getSubBlock(txtSubBlock.Text)

            'Dim w As Windows.Forms.DialogResult
            'Dim SubBlockLoop_Form As New SubBlockLookups(txtSubBlock.Text)

            'w = SubBlockLoop_Form.ShowDialog()
            'If (w = Windows.Forms.DialogResult.OK) Then
            '    Me.txtSubBlock.Text = SubBlockLoop_Form.SubBlockName
            '    Me.txtDIV.Text = SubBlockLoop_Form.DIV
            '    Me.txtYOP.Text = SubBlockLoop_Form.YOP

            '    lblSubBlockID.Text = SubBlockLoop_Form.SubBlockID
            '    lblDivID.Text = SubBlockLoop_Form.DivID
            '    lblYOPID.Text = SubBlockLoop_Form.YOPID

            '    txtAreaPlanted.Focus()
            'End If

            'SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub txtSubBlock_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubBlock.Leave
        'Dim objCensusPPT As New Census_PPT
        'objCensusPPT.BlockName = txtSubBlock.Text
        If Not txtSubBlock.Text = String.Empty Then
       
            Dim dt As New DataTable
            dt = Census_DAL.CRSubBlockSelect(txtSubBlock.Text.Trim)
            'txtSubBlock.Focus()
            If dt.Rows.Count >= 1 Then
                Me.txtSubBlock.Text = dt.Rows(0).Item("BlockName").ToString()
                Me.txtDIV.Text = dt.Rows(0).Item("DivName").ToString()
                Me.txtYOP.Text = dt.Rows(0).Item("YOP").ToString()
                lblSubBlockID.Text = dt.Rows(0).Item("BlockID").ToString()
                lblDivID.Text = dt.Rows(0).Item("DivID").ToString()
                lblYOPID.Text = dt.Rows(0).Item("YOPID").ToString()
                txtAreaPlanted.Focus()

            Else

                'Me.txtSubBlock.Text = SubBlockLoop_Form.SubBlockName
                Me.txtDIV.Text = String.Empty
                Me.txtYOP.Text = String.Empty
                lblSubBlockID.Text = String.Empty
                lblDivID.Text = String.Empty
                lblYOPID.Text = String.Empty
                MsgBox("Field No Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                txtSubBlock.Text = String.Empty
            End If
            'GlobalPPT.strEstateCode.ToString()

            'Dim DTAllDedSetup As DataTable
            'DTAllDedSetup = AllowanceDeduction_Dal.CRAllowanceDeductionSetupIsExist(txtCoaCode.Text.Trim)

            'If DTAllDedSetup.Rows.Count >= 1 Then
            '    txtCoaCode.Text = DTAllDedSetup.Rows(0).Item("AllowDedCode").ToString()
            '    lblCoaDesc.Text = DTAllDedSetup.Rows(0).Item("Remarks").ToString()
            '    lblType.Text = DTAllDedSetup.Rows(0).Item("Type").ToString()
            '    lblAllDedID.Text = DTAllDedSetup.Rows(0).Item("AllowDedID").ToString()
            '    txtAmount.Focus()

            'ElseIf DTAllDedSetup.Rows.Count = 0 Then

            '    MsgBox(" Allowance & Deduction Code Not Valid", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
            '    lblCoaDesc.Text = String.Empty
            'End If
        Else
            Me.txtDIV.Text = String.Empty
            Me.txtYOP.Text = String.Empty
            lblSubBlockID.Text = String.Empty
            lblDivID.Text = String.Empty
            lblYOPID.Text = String.Empty
        End If
    End Sub

    Private Sub txtAreaPlanted_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ' Kamis, 3 Sep 2009, 11:31
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub txtPlantDensityRequired_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ' Kamis, 3 Sep 2009, 11:31
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub txtTLJalanPoros_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTLJalanPoros.KeyDown
        ' Selasa, 27 Oct 2009, 19:34
        ' by Dadang Adi
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtTLMainRoad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTLMainRoad.KeyDown
        ' Selasa, 27 Oct 2009, 19:34
        ' by Dadang Adi
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtTLCollectionRoad_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTLCollectionRoad.KeyDown
        ' Selasa, 27 Oct 2009, 19:34
        ' by Dadang Adi
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtTLCollectionRoad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTLCollectionRoad.KeyPress
        ' Selasa, 27 Oct 2009, 19:46
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtNoOfBunches.Focus()
            End If
        End If
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        SaveCensus()
        DT_Census.Clear()
        selectCensusByDate()
    End Sub

    Private Sub SaveCensus()
        Try
            'CensusTableAdapter.Update(DT_Census)
            Dim rowAffected As Integer
            rowAffected = Census_BOL.UpdateCensus(CensusTableAdapter, DT_Census)

            MsgBox("Your data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            btnSaveAll.Enabled = False
            ClearInput()
            txtChange.Text = ""
        Catch ex As Exception
            MsgBox("Your data has not been saved, please check your missing data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Information")
        End Try
    End Sub

    Private Sub AddToGrid()
        ' Ahad, 6 Sep 2009, 00:26

        Dim objCensusPPT As New Census_PPT

        objCensusPPT.CensusDate = dtpCensusDate.Value
        objCensusPPT.DivName = txtDIV.Text
        objCensusPPT.YOP = txtYOP.Text
        objCensusPPT.BlockName = txtSubBlock.Text
        objCensusPPT.AreaPlanted = txtAreaPlanted.Text
        objCensusPPT.PlantdensityRequired = txtPlantDensityRequired.Text
        objCensusPPT.PlantDensityActual = txtPlantDensityActual.Text
        objCensusPPT.PorosinArea = txtTLJalanPoros.Text
        objCensusPPT.MainRoadInArea = txtTLMainRoad.Text
        objCensusPPT.CollectionRoadInArea = txtTLCollectionRoad.Text
        objCensusPPT.NoOfBunches = txtNoOfBunches.Text
        objCensusPPT.TotalFFB = txtTotalFFB.Text
        objCensusPPT.BlockID = lblSubBlockID.Text
        objCensusPPT.DivID = lblDivID.Text
        objCensusPPT.YOPID = lblYOPID.Text
        objCensusPPT.CensusID = String.Empty
        objCensusPPT.EstateID = GlobalPPT.strEstateID
        objCensusPPT.EstateCode = GlobalPPT.strEstateCode
        objCensusPPT.ActiveMonthYearID = GlobalPPT.strActMthYearID
        objCensusPPT.CreatedBy = GlobalPPT.strUserName
        objCensusPPT.CreatedOn = Now
        objCensusPPT.ModifiedBy = GlobalPPT.strUserName
        objCensusPPT.ModifiedOn = Now

        CensusTableAdapter.AddToGrid(DT_Census, objCensusPPT)

        'DT_Census = dgvCensus.DataSource
        'Dim newDataRow As System.Data.DataRow = DT_Census.NewRow()

        'newDataRow.Item("CensusDate") = dtpCensusDate.Value
        'newDataRow.Item("DivName") = txtDIV.Text
        'newDataRow.Item("YOP") = txtYOP.Text
        'newDataRow.Item("BlockName") = txtSubBlock.Text
        'newDataRow.Item("AreaPlanted") = txtAreaPlanted.Text
        'newDataRow.Item("PlantDensityRequired") = txtPlantDensityRequired.Text
        'newDataRow.Item("PlantDensityActual") = txtPlantDensityActual.Text
        'newDataRow.Item("PorosInArea") = txtTLJalanPoros.Text
        'newDataRow.Item("MainRoadInArea") = txtTLMainRoad.Text
        'newDataRow.Item("CollectionRoadInArea") = txtTLCollectionRoad.Text
        'newDataRow.Item("NoOfBunches") = txtNoOfBunches.Text
        'newDataRow.Item("TotalFFB") = txtTotalFFB.Text
        'newDataRow.Item("BlockID") = lblSubBlockID.Text
        'newDataRow.Item("DivID") = lblDivID.Text
        'newDataRow.Item("YOPID") = lblYOPID.Text
        'newDataRow.Item("CensusID") = String.Empty
        'newDataRow.Item("EstateID") = GlobalPPT.strEstateID
        'newDataRow.Item("EstateCode") = GlobalPPT.strEstateCode
        'newDataRow.Item("ActiveMonthYearID") = GlobalPPT.strActMthYearID
        'newDataRow.Item("CreatedBy") = GlobalPPT.strUserName
        'newDataRow.Item("CreatedOn") = Date.Now
        'newDataRow.Item("ModifiedBy") = GlobalPPT.strUserName
        'newDataRow.Item("ModifiedOn") = Date.Now
        'DT_Census.Rows.Add(newDataRow)


        MessageBox.Show("Data successfully Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtChange.Text = "ADD"
        ClearInput()
    End Sub

    Private Sub selectCensusByDate()
        ' Jum'at, Sep 04 2009, 21:09
        Dim DT_CensusView As DataTable

        'DT_CensusView = CensusTableAdapter.CensusSelectByDate(Nothing, Nothing)
        DT_CensusView = Census_BOL.CRCensusByDateSelect("01/01/1900", "01/01/1900")
        DgvCensussView.DataSource = DT_CensusView
        HiddenGridColumnCensusView()
    End Sub

    Private Sub HiddenGridColumnCensusView()
        ' Kamis, 8 Oct 2009, 01:00
        DgvCensussView.Columns("CensusID").Visible = False
        DgvCensussView.Columns("EstateID").Visible = False
        DgvCensussView.Columns("EstateCode").Visible = False
        DgvCensussView.Columns("ActiveMonthYearID").Visible = False
        DgvCensussView.Columns("DivID").Visible = False
        DgvCensussView.Columns("YOPID").Visible = False
        DgvCensussView.Columns("BlockID").Visible = False
        DgvCensussView.Columns("CensusViewColumnConcurrencyId").Visible = False
        DgvCensussView.Columns("CreatedBy").Visible = False
        DgvCensussView.Columns("CreatedOn").Visible = False
        DgvCensussView.Columns("ModifiedBy").Visible = False
        DgvCensussView.Columns("ModifiedOn").Visible = False
    End Sub

    Private Sub HiddenGridColumnCensus()
        ' Kamis, 8 Oct 2009, 01:00
        dgvCensus.Columns("CensusID").Visible = False
        dgvCensus.Columns("EstateID").Visible = False
        dgvCensus.Columns("EstateCode").Visible = False
        dgvCensus.Columns("ActiveMonthYearID").Visible = False
        dgvCensus.Columns("DivID").Visible = False
        dgvCensus.Columns("YOPID").Visible = False
        dgvCensus.Columns("BlockID").Visible = False
        dgvCensus.Columns("CensusColumnConcurrencyId").Visible = False
        dgvCensus.Columns("CreatedBy").Visible = False
        dgvCensus.Columns("CreatedOn").Visible = False
        dgvCensus.Columns("ModifiedBy").Visible = False
        dgvCensus.Columns("ModifiedOn").Visible = False
    End Sub

    Private Sub ClearInput()
        ' Sabtu, Sep 05 2009, 02:41
        txtDIV.Text = ""
        txtYOP.Text = ""
        txtSubBlock.Text = ""
        txtAreaPlanted.Text = 0
        txtPlantDensityRequired.Text = 0
        txtPlantDensityActual.Text = 0
        txtTLJalanPoros.Text = 0
        txtTLMainRoad.Text = 0
        txtTLCollectionRoad.Text = 0
        txtNoOfBunches.Text = 0
        txtTotalFFB.Text = 0

        lblDivID.Text = ""
        lblYOPID.Text = ""
        lblSubBlockID.Text = ""
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ' Sabtu, 5 Sep 2009, 03:19 dinihari
        Dim DT_CensusView As DataTable
        If chkDate.Checked = True Then
            DT_CensusView = CensusTableAdapter.CensusSelectByDate(dtpCensusDateStartSearch.Value, dtpCensusDateEndSearch.Value)
        Else
            DT_CensusView = CensusTableAdapter.CensusSelectByDate("01/01/1900", "01/01/1900")
        End If
       
        DgvCensussView.DataSource = DT_CensusView

        If DT_CensusView.Rows.Count = 0 Then
            MessageBox.Show("No record found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ' Sabtu, 5 Sep 2009, 03:59 dinihari
        ClearInput()

        btnAdd.Text = "&Add"

        dgvCensus.Enabled = True
        btnSaveAll.Enabled = True
        btnClose.Enabled = True
    End Sub

    Private Sub EditCensus()
        btnAdd.Text = "&Update"


        dtpCensusDate.Value = dgvCensus.CurrentCell.OwningRow.Cells("CensusDate").Value
        txtSubBlock.Text = dgvCensus.CurrentCell.OwningRow.Cells("BlockName").Value
        txtDIV.Text = dgvCensus.CurrentCell.OwningRow.Cells("DivName").Value
        txtYOP.Text = dgvCensus.CurrentCell.OwningRow.Cells("YOP").Value

        lblSubBlockID.Text = dgvCensus.CurrentCell.OwningRow.Cells("BlockID").Value
        lblDivID.Text = dgvCensus.CurrentCell.OwningRow.Cells("DivID").Value
        lblYOPID.Text = dgvCensus.CurrentCell.OwningRow.Cells("YOPID").Value

        If dgvCensus.CurrentCell.OwningRow.Cells("AreaPlanted").Value IsNot System.DBNull.Value Then
            txtAreaPlanted.Text = CType(dgvCensus.CurrentCell.OwningRow.Cells("AreaPlanted").Value, Double).ToString()
        Else
            txtAreaPlanted.Text = ""
        End If

        If dgvCensus.CurrentCell.OwningRow.Cells("PlantDensityRequired").Value IsNot System.DBNull.Value Then
            txtPlantDensityRequired.Text = CType(dgvCensus.CurrentCell.OwningRow.Cells("PlantDensityRequired").Value, Double).ToString()
        Else
            txtPlantDensityRequired.Text = ""
        End If

        If dgvCensus.CurrentCell.OwningRow.Cells("PlantDensityActual").Value IsNot System.DBNull.Value Then
            txtPlantDensityActual.Text = CType(dgvCensus.CurrentCell.OwningRow.Cells("PlantDensityActual").Value, Double).ToString()
        Else
            txtPlantDensityActual.Text = ""
        End If

        If dgvCensus.CurrentCell.OwningRow.Cells("PorosInArea").Value IsNot System.DBNull.Value Then
            txtTLJalanPoros.Text = CType(dgvCensus.CurrentCell.OwningRow.Cells("PorosInArea").Value, Double).ToString()
        Else
            txtTLJalanPoros.Text = ""
        End If

        If dgvCensus.CurrentCell.OwningRow.Cells("MainRoadInArea").Value IsNot System.DBNull.Value Then
            txtTLMainRoad.Text = CType(dgvCensus.CurrentCell.OwningRow.Cells("MainRoadInArea").Value, Double).ToString()
        Else
            txtTLMainRoad.Text = ""
        End If

        If dgvCensus.CurrentCell.OwningRow.Cells("CollectionRoadInArea").Value IsNot System.DBNull.Value Then
            txtTLCollectionRoad.Text = CType(dgvCensus.CurrentCell.OwningRow.Cells("CollectionRoadInArea").Value, Double).ToString()
        Else
            txtTLCollectionRoad.Text = ""
        End If

        If dgvCensus.CurrentCell.OwningRow.Cells("NoOfBunches").Value IsNot System.DBNull.Value Then
            txtNoOfBunches.Text = CType(dgvCensus.CurrentCell.OwningRow.Cells("NoOfBunches").Value, Double).ToString()
        Else
            txtNoOfBunches.Text = ""
        End If

        If dgvCensus.CurrentCell.OwningRow.Cells("TotalFFB").Value IsNot System.DBNull.Value Then
            txtTotalFFB.Text = CType(dgvCensus.CurrentCell.OwningRow.Cells("TotalFFB").Value, Double).ToString()
        Else
            txtTotalFFB.Text = ""
        End If

    End Sub

    Private Sub DeleteCensusFromdgvCensusMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCensusFromdgvCensusMenu.Click
        ' Ahad, 6 Sep 2009, 00:42
        If dgvCensus.Rows.Count = 0 Then
            Return
        End If

        If dgvCensus.CurrentCell Is Nothing Then
            Return
        End If

        rowIndexGrid = dgvCensus.CurrentCell.RowIndex

        If MessageBox.Show("Your are about to delete the selected record" + vbCrLf + _
                           "Are you sure want to delete this record: " + vbCrLf + _
                           "Field No: " + dgvCensus.Rows(rowIndexGrid).Cells("BlockName").Value.ToString() + vbCrLf + _
                           "DIV      : " + dgvCensus.Rows(rowIndexGrid).Cells("DivName").Value.ToString() + vbCrLf + _
                           "YOP      : " + dgvCensus.Rows(rowIndexGrid).Cells("YOP").Value.ToString(), _
                    "Census Delete", MessageBoxButtons.OKCancel, _
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        DeleteCensus()
    End Sub

    Private Sub DeleteCensus()
        ' Ahad, 6 Sep 2009, 00:44

        If dgvCensus.Rows(dgvCensus.CurrentCell.RowIndex).Cells("CensusID").Value Is System.DBNull.Value Then
            dgvCensus.Rows.RemoveAt(dgvCensus.CurrentCell.RowIndex)
            MessageBox.Show("Data successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtChange.Text = "Delete"
            btnSaveAll.Enabled = True
        Else
            DT_Census.Rows(rowIndexGrid).Delete()
            MessageBox.Show("Data successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtChange.Text = "Delete"
            btnSaveAll.Enabled = True
        End If

        
    End Sub

    Private Function IsSubBlockAlreadyInGread() As Integer
        Dim rowIndex As Integer = -1
        Dim BlockNameInGrid As String = String.Empty
        Dim BlockNameInput As String = String.Empty
        ' Ahad, 15 Nov 2009, 20:27
        Dim YOPInGrid As String = String.Empty
        Dim DivisionInGrid As String = String.Empty

        If txtSubBlock.Text = String.Empty Then
            Return rowIndex
        End If

        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvCensus.DataSource, dgvCensus.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)
        'Dim dr As DataRow = dv.Item(cm.Position).Row

        For i As Int32 = 0 To DT_Census.Rows.Count - 1
            Dim row As DataRow = DT_Census.Rows(i)
            Dim dCensusInGrid As Date

            If row.RowState <> DataRowState.Deleted Then
                BlockNameInGrid = row.Item("BlockName")
                DivisionInGrid = row.Item("DivName")
                YOPInGrid = row.Item("YOP")

                dCensusInGrid = row.Item("CensusDate")

                If BlockNameInGrid = txtSubBlock.Text AndAlso DivisionInGrid = txtDIV.Text AndAlso YOPInGrid = txtYOP.Text _
                    AndAlso dCensusInGrid.Date = dtpCensusDate.Value.Date Then
                    rowIndex = i
                    Exit For
                End If
            End If
        Next

        Return rowIndex
    End Function

    Private Function IsSubBlockAlreadyInGreadWithOutCurrentEdit() As Integer
        ' Senin, 16 Nov 2009, 01:00

        Dim rowIndex As Integer = -1
        Dim BlockNameInGrid As String = String.Empty
        Dim BlockNameInput As String = String.Empty
        Dim YOPInGrid As String = String.Empty
        Dim DivisionInGrid As String = String.Empty

        If txtSubBlock.Text = "" Then
            Return rowIndex
        End If

        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvCensus.DataSource, dgvCensus.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        For i As Int32 = 0 To DT_Census.Rows.Count - 1
            Dim row As DataRow = DT_Census.Rows(i)
            Dim dCensusInGrid As Date

            If i <> dgvCensus.CurrentCell.RowIndex Then

                If row.RowState <> DataRowState.Deleted Then
                    BlockNameInGrid = row.Item("BlockName")
                    DivisionInGrid = row.Item("DivName")
                    YOPInGrid = row.Item("YOP")

                    dCensusInGrid = row.Item("CensusDate")

                    If BlockNameInGrid = txtSubBlock.Text AndAlso DivisionInGrid = txtDIV.Text AndAlso YOPInGrid = txtYOP.Text _
                        AndAlso dCensusInGrid.Date = dtpCensusDate.Value.Date Then
                        rowIndex = i
                        Exit For
                    End If
                End If

            End If
        Next

        Return rowIndex
    End Function

    Private Function CheckInput() As Boolean
        ' Monday, 16 Nov 2009, 00:47
        'Sabtu, 05 Sep 2009, 15:24
        Dim CheckOK As Boolean = True

        If lblSubBlockID.Text.Trim = "" Or lblDivID.Text.Trim = "" Or lblYOPID.Text.Trim = "" Then
            MessageBox.Show("You must select SubBlock", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CheckOK = False
        End If

        ' Senin, 05 Oct 2009, 20:09
        If IsNumeric(txtAreaPlanted.Text.Trim) = False Then
            MessageBox.Show("Please key in numeric value for Area Planted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CheckOK = False
        End If

        If IsNumeric(txtPlantDensityRequired.Text.Trim) = False Then
            MessageBox.Show("Please key in numeric value for Plant density required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CheckOK = False
        End If

        If IsNumeric(txtPlantDensityActual.Text.Trim) = False Then
            MessageBox.Show("Please key in numeric value for Plant Density Actual", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CheckOK = False
        End If

        If IsNumeric(txtTLJalanPoros.Text.Trim) = False Then
            MessageBox.Show("Please key in numeric value for Jalan Poros in Area", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CheckOK = False
        End If

        If IsNumeric(txtTLMainRoad.Text.Trim) = False Then
            MessageBox.Show("Please key in numeric value for Main Road in this area", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CheckOK = False
        End If

        If IsNumeric(txtTLCollectionRoad.Text.Trim) = False Then
            MessageBox.Show("Please key in numeric value for Collection in this area", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CheckOK = False
        End If

        If IsNumeric(txtNoOfBunches.Text.Trim) = False Then
            MessageBox.Show("Please key in numeric value for No of bunches", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CheckOK = False
        End If

        If IsNumeric(txtTotalFFB.Text.Trim) = False Then
            MessageBox.Show("Please key in numeric value for TotalFFB", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CheckOK = False
        End If

        Return CheckOK
    End Function

    Private Sub btnAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ' Ahad, 6 Sep 2009, 01:02
        ' Kamis, 3 Sep 2009, 12:06
        If CheckInput() = False Then
            Return
        End If

        If btnAdd.Text = "&Add" Then

            If IsSubBlockAlreadyInGread() <> -1 Then
                MessageBox.Show( _
                    "Field No Already in grid" + vbCrLf + _
                    "example: You can not add the similar Field No", _
                    "Information", _
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            AddToGrid()
            btnSaveAll.Enabled = True

        ElseIf btnAdd.Text = "&Update" Then

            If IsSubBlockAlreadyInGreadWithOutCurrentEdit() <> -1 Then
                MessageBox.Show("Field No Already in grid" + vbCrLf + _
                    "example: You can not add the similar Field No", _
                    "Information", _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            UpdateToGrid()

            btnAdd.Text = "&Add"
            btnClose.Text = "&Close"
            txtChange.Text = "Update"

            btnSaveAll.Enabled = True
            btnClose.Enabled = True
            dgvCensus.Enabled = True
        End If


    End Sub

    Private Sub UpdateToGrid()
        'Ahad, 6 Sep 2009, 15:54
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("CensusDate") = dtpCensusDate.Value
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("DivName") = txtDIV.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("YOP") = txtYOP.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("BlockName") = txtSubBlock.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("AreaPlanted") = txtAreaPlanted.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("PlantDensityRequired") = txtPlantDensityRequired.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("PlantDensityActual") = txtPlantDensityActual.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("PorosInArea") = txtTLJalanPoros.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("MainRoadInArea") = txtTLMainRoad.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("CollectionRoadInArea") = txtTLCollectionRoad.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("NoOfBunches") = txtNoOfBunches.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("TotalFFB") = txtTotalFFB.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("BlockID") = lblSubBlockID.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("DivID") = lblDivID.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("YOPID") = lblYOPID.Text
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("ActiveMonthYearID") = GlobalPPT.strActMthYearID
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("ModifiedBy") = GlobalPPT.strUserName
        DT_Census.Rows(dgvCensus.CurrentCell.RowIndex).Item("ModifiedOn") = Date.Now

        ClearInput()
        MessageBox.Show("Data successfully updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub EditCensusFromdgvCensusMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCensusFromdgvCensusMenu.Click
        ' Ahad, 06 Sep 2009, 17:07
        If dgvCensus.Rows.Count = 0 Then
            Return
        End If

        If dgvCensus.CurrentCell Is Nothing Then
            Return
        End If

        EditCensus()
    End Sub

    Private Sub Censuss_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Senin, 5 Oct 2009, 20:39
        If txtChange.Text <> "" Then
            Dim jwb As String
            jwb = MsgBox("Your data has not been saved yet, do you want to save data?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
            If jwb = 6 Then
                SaveCensus()
            End If
        End If

    End Sub

    Private Sub DgvCensussView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCensussView.CellDoubleClick
        ' Sabtu, 5 Sep 2009, 03:19 dinihari

        If DgvCensussView.Rows.Count = 0 Then
            Return
        End If

        If DgvCensussView.CurrentCell Is Nothing Then
            Return
        End If

        Dim dselect As Date = DgvCensussView.CurrentCell.OwningRow.Cells("CensusDateView").Value

        DT_Census = CensusTableAdapter.CensusSelectByDate(dselect, Nothing)
        dgvCensus.DataSource = DT_Census
        tcCensus.SelectedTab = tabMaterial

    End Sub

    Private Sub txtAreaPlanted_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAreaPlanted.KeyDown
        ' Selasa, 20 Oct 2009, 16:15
        ' by Dadang Adi
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

        'If e.KeyCode = Keys.Enter Then
        '    If IsNumeric(txtAreaPlanted.Text) = False Then
        '        MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
        '        txtAreaPlanted.Text = ""
        '        txtAreaPlanted.Focus()
        '        Return
        '    ElseIf IsNumeric(txtAreaPlanted.Text) = True Then
        '        txtPlantDensityRequired.Focus()
        '    End If
        'ElseIf e.KeyCode = Keys.Escape Then
        '    txtPlantDensityRequired.Focus()
        'End If

    End Sub

    Private Sub txtAreaPlanted_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAreaPlanted.KeyPress
        ' Selasa, 27 Oct 2009, 19:32
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtPlantDensityRequired.Focus()
            End If
        End If

    End Sub

    Private Sub txtAreaPlanted_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAreaPlanted.Leave
        ' Selasa, 27 Oct 2009, 19:33
        If txtAreaPlanted.Text = "" Or txtAreaPlanted.Text = "." Then
            txtAreaPlanted.Text = "0"
        End If
    End Sub

    Private Sub txtPlantDensityActual_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlantDensityActual.KeyDown
        ' Selasa, 27 Oct 2009, 19:34
        ' by Dadang Adi
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtPlantDensityActual_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlantDensityActual.KeyPress
        ' Selasa, 27 Oct 2009, 19:41
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtTLJalanPoros.Focus()
            End If
        End If
    End Sub

    Private Sub txtPlantDensityActual_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlantDensityActual.Leave
        ' Selasa, 27 Oct 2009, 19:37
        If txtPlantDensityActual.Text = "" Or txtPlantDensityActual.Text = "." Then
            txtPlantDensityActual.Text = "0"
        End If
    End Sub

    Private Sub txtTotalFFB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotalFFB.KeyDown
        ' Selasa, 27 Oct 2009, 19:34
        ' by Dadang Adi
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If
    End Sub

    Private Sub txtPlantDensityRequired_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlantDensityRequired.KeyDown
        ' Selasa, 27 Oct 2009, 19:34
        ' by Dadang Adi
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

    End Sub

    Private Sub txtPlantDensityRequired_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlantDensityRequired.KeyPress
        ' Selasa, 27 Oct 2009, 19:35
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtPlantDensityActual.Focus()
            End If
        End If

    End Sub

    Private Sub txtPlantDensityRequired_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlantDensityRequired.Leave
        ' Selasa, 27 Oct 2009, 19:37
        If txtAreaPlanted.Text = "" Or txtAreaPlanted.Text = "." Then
            txtAreaPlanted.Text = "0"
        End If
    End Sub


    Private Sub txtNoOfBunches_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNoOfBunches.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(txtNoOfBunches.Text) = False Then
                MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtNoOfBunches.Text = ""
                txtNoOfBunches.Focus()
                Return
            ElseIf IsNumeric(txtNoOfBunches.Text) = True Then
                txtTotalFFB.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            txtTotalFFB.Focus()
        End If
    End Sub


    Private Sub dgvCensus_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCensus.CellDoubleClick
        ' Sabtu, 5 Sep 2009, 04:00 dinihari
        If dgvCensus.Rows.Count = 0 Then
            Return
        End If

        If dgvCensus.CurrentCell Is Nothing Then
            Return
        End If

        rowIndexGrid = dgvCensus.CurrentCell.RowIndex
        EditCensus()

        dgvCensus.Enabled = False
        btnSaveAll.Enabled = False
        btnClose.Enabled = False
    End Sub

    Private Sub txtTLJalanPoros_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTLJalanPoros.KeyPress
        ' Selasa, 27 Oct 2009, 19:46
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtTLMainRoad.Focus()
            End If
        End If
    End Sub

    Private Sub txtTLJalanPoros_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTLJalanPoros.Leave
        ' Selasa, 27 Oct 2009, 19:48
        If txtTLJalanPoros.Text = "" Or txtTLJalanPoros.Text = "." Then
            txtTLJalanPoros.Text = "0"
        End If
    End Sub

    Private Sub txtTLMainRoad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTLMainRoad.KeyPress
        ' Selasa, 27 Oct 2009, 19:46
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtTLCollectionRoad.Focus()
            End If
        End If
    End Sub

    Private Sub txtTLMainRoad_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTLMainRoad.Leave
        ' Selasa, 27 Oct 2009, 19:48
        If txtTLMainRoad.Text = "" Or txtTLMainRoad.Text = "." Then
            txtTLMainRoad.Text = "0"
        End If
    End Sub


    Private Sub txtNoOfBunches_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfBunches.KeyPress
        ' Selasa, 27 Oct 2009, 19:46
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtTotalFFB.Focus()
            End If
        End If
    End Sub

    Private Sub txtTLCollectionRoad_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTLCollectionRoad.Leave
        ' Selasa, 27 Oct 2009, 19:48
        If txtTLCollectionRoad.Text = "" Or txtTLCollectionRoad.Text = "." Then
            txtTLCollectionRoad.Text = "0"
        End If

    End Sub

    Private Sub txtNoOfBunches_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoOfBunches.Leave
        ' Selasa, 27 Oct 2009, 20:43
        If txtNoOfBunches.Text = "" Or txtNoOfBunches.Text = "." Then
            txtNoOfBunches.Text = "0"
        End If
    End Sub

    Private Sub txtTotalFFB_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalFFB.KeyPress
        ' Selasa, 27 Oct 2009, 19:46
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                btnAdd.Focus()
            End If
        End If
    End Sub

    Private Sub txtTotalFFB_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalFFB.Leave
        ' Selasa, 27 Oct 2009, 20:43
        If txtTotalFFB.Text = "" Or txtTotalFFB.Text = "." Then
            txtTotalFFB.Text = "0"
        End If
    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        ' By Dadang Adi H
        ' Selasa, 23 Feb 2010, 13:30
        Cursor = Cursors.WaitCursor

        Dim report As New ViewReport()
        Dim ReportName As String
        Dim StartDate As String
        Dim EndDate As String

        StartDate = dtpCensusDateStartSearch.Value.ToString("yyyy/MM/dd")
        EndDate = dtpCensusDateEndSearch.Value.ToString("yyyy/MM/dd")

        ReportName = "CRCensusReport"
        report._Source = ReportName
        report._Formula = _
                "{CRCensusReport;1.EstateID} = '" + GlobalPPT.strEstateID + "' AND " + _
                "{CRCensusReport;1.CensusDate} >= #" + StartDate + "# AND " + _
                "{CRCensusReport;1.CensusDate} <= #" + EndDate + "#"

        report.ShowDialog()

        Cursor = Cursors.Default

    End Sub

    Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
        If chkDate.Checked = True Then
            dtpCensusDateStartSearch.Enabled = True
            dtpCensusDateEndSearch.Enabled = True
        Else
            dtpCensusDateStartSearch.Enabled = False
            dtpCensusDateEndSearch.Enabled = False
        End If

    End Sub

    Private Sub tcCensus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcCensus.SelectedIndexChanged
        If tcCensus.SelectedIndex = 1 Then
            chkDate.Checked = False
            dtpCensusDateStartSearch.Value = Now
            dtpCensusDateEndSearch.Value = Now
            selectCensusByDate()
        ElseIf tcCensus.SelectedIndex = 0 Then
            dtpCensusDate.Focus()
        End If
      

    End Sub

    Private Sub Censuss_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class