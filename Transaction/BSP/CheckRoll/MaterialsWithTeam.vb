'
'>>>>>>>>>>>>>>>>>>>>>>>>>>>>
'
'
' By              : Dadang Adi H
' Modified date   : Selasa, 27 Oct 2009, 14:10
'
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports CheckRoll_DAL


Public Class MaterialsWithTeam
    Public lstringctrl As String = String.Empty
    Public LSource As String = String.Empty
    Public LFormula As String = String.Empty
    Public ltanggal As String = String.Empty

    Public DailyDistributionID As String = String.Empty

    Public Lactivity As String = String.Empty
    Public LteamId As String = String.Empty
    Public LTeamName As String = String.Empty
    Public LEmpName As String = String.Empty
    Public LEmpId As String = String.Empty
    Public lcoaCode As String = String.Empty
    Public lcoadescp As String = String.Empty
    Public lcoaid As String = String.Empty
    Public StrUsername As String = String.Empty
    Public StrEstateCode As String = String.Empty
    Public StrEstateID As String = String.Empty
    Public StrEstateName As String = String.Empty
    Public StrActMthYearID As String = String.Empty
    Public Rdate As String = String.Empty

    Public DT_Material As DataTable = New DataTable
    Public Sdate As String = String.Empty
    Private MaterialeAdapter As Material_Dal

    Private MaterialTableAdapter As New MaterialWithTeamDAL()

    ' Selasa, 27 Oct 2009, 14:20
    ' Boolean flag used to determine when a character other than a number is entered.
    Private nonNumberEntered As Boolean = False

    ' Selasa, 1 Des 2009, 17:28
    Public GangName As String = String.Empty
    Public GangMasterID As String = String.Empty
    Public MaterialsDate As Date = Now
    ' END Selasa, 1 Des 2009, 17:28

    Public MandoEmprName As String = String.Empty
    Public KraniEmpName As String = String.Empty

    Private Function IsMaterialUsageIsModified() As Boolean
        Dim ModifiedRow As DataRow() = DT_Material.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent)
        Dim AddedRow As DataRow() = DT_Material.Select(Nothing, Nothing, DataViewRowState.Added)
        Dim DeletedRow As DataRow() = DT_Material.Select(Nothing, Nothing, DataViewRowState.Deleted)

        Dim Modified As Boolean = False

        If ModifiedRow.Length > 0 Or AddedRow.Length > 0 Or DeletedRow.Length > 0 Then
            'array dataRow ModifiedRow ini akan berisi array bila ada dataRow yg dimodifikasi/berubah
            'didalam DT_DailyAttendance
            Modified = True
        End If

        Return Modified
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'If txtChange.Text = "Update" Or txtChange.Text = "Delete " Then
        '    Dim jwb As String
        '    jwb = MsgBox("Your data has not been saved yet, do you want to close this screen?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
        '    If jwb = 6 Then
        '        Me.Close()
        '    End If
        'Else
        '    Me.Close()
        'End If

        Me.Close()
    End Sub

    Private Sub mtnhCalDateSearch_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs)
        Dim _Date As String
        _Date = e.Start.ToShortDateString()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SIVLookup.Show()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStock.Click
        If lblEmpId.Text = "" And lblGangMasterID.Text = "" Then
            MsgBox("Please select team or NIK", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) ',"Warning")

        ElseIf lblEmpId.Text <> "" Or lblGangMasterID.Text <> "" Then

            Stock_Lookup.ShowDialog()
            If Stock_Lookup.DialogResult = Windows.Forms.DialogResult.OK Then
                txtStockCode.Text = Stock_Lookup._StockCode
                lblStockID.Text = Stock_Lookup._StockId
                lblStockDescp.ForeColor = Color.Blue
                lblStockDescp.Text = Stock_Lookup._StockDescp
                lblUom1.Text = Stock_Lookup._UOM
                lblUom2.Text = Stock_Lookup._UOM
                lblUom3.Text = Stock_Lookup._UOM
                txtIssueQty.Focus()
            End If
        End If


    End Sub

    Private Sub Materials_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If IsMaterialUsageIsModified() = True Then
            If MessageBox.Show("The data has changed," + vbCrLf + _
                                "Do you want to save this data..", "Warning", _
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
              Windows.Forms.DialogResult.Yes Then
                'save data
                SaveMaterial()
            End If

        End If
    End Sub

    Private Sub MaterialsWithTeam_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Material_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Rabu, 30 Sep 2009, 16:23
        ' Masalah di ADO.NET, kalo windows control panel di set format date nya ke dd/MM/yyyy
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()


        'MaterialeAdapter = New Material_Dal
        ResetAll()
        StrUsername = GlobalPPT.strUserName.ToString
        StrEstateCode = GlobalPPT.strEstateCode.ToString
        StrEstateID = GlobalPPT.strEstateID.ToString
        StrEstateName = GlobalPPT.strEstateName.ToString
        StrActMthYearID = GlobalPPT.strActMthYearID.ToString
        lblEmpId.Text = Me.GangMasterID
        txtGangName.Text = Me.GangName
        ScreenCtrl.Text = Me.lstringctrl

        lblCOADescp.Text = Me.lcoadescp
        txtCOACode.Text = Me.lcoaCode
        lblCOAID.Text = Me.lcoaid

        dtpDate.Value = Me.MaterialsDate ' Selasa, 1 Des 2009, 17:30
        lblMandorEmpName.Text = MandoEmprName
        lblKraniEmpName.Text = KraniEmpName
        'lblDailyDistributionID.Text = Me.ldailydistributionId

        If txtCOACode.Text = "" Then
            MsgBox("Please select activity from activity distribution screen", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
            Return
        End If

        ' Selasa, 27 Oct 2009, 15:27
        DT_Material = MaterialWithTeamDAL.CRActivityMaterialUsageWithTeamView(Me.DailyDistributionID)
        dgvMaterial.DataSource = DT_Material
        HideGridColumn()


        'If Val(ScreenCtrl.Text) = 1 Then
        '    lblTeam.Text = "Team"
        'ElseIf Val(ScreenCtrl.Text) = 0 Then
        '    lblTeam.Text = "NIK"

        'End If
        dgvMaterial.DefaultCellStyle.BackColor = Color.White
    End Sub

    Private Sub HideGridColumn()
        dgvMaterial.Columns("EstateID").Visible = False
        dgvMaterial.Columns("EstateCode").Visible = False
        dgvMaterial.Columns("ActiveMonthYearID").Visible = False
        dgvMaterial.Columns("DailyDistributionID").Visible = False
        dgvMaterial.Columns("STIssueID").Visible = False
        dgvMaterial.Columns("StockID").Visible = False
        dgvMaterial.Columns("MaterialUsageID").Visible = False

        dgvMaterial.Columns("CreatedBy").Visible = False
        dgvMaterial.Columns("CreatedOn").Visible = False
        dgvMaterial.Columns("ModifiedBy").Visible = False
        dgvMaterial.Columns("ModifiedOn").Visible = False
    End Sub


    Private Sub txtSIV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSIVNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStockCode.Focus()
        End If
    End Sub

    Private Sub txtStockCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtIssueQty.Focus()

        End If


        'If e.KeyCode = Keys.Enter Then

        '    e.SuppressKeyPress = True ' Selasa, 1 Des 2009, 00:35

        '    If txtStockCode.Text.Trim = "" Then
        '        btnStock.Focus()

        '    ElseIf txtStockCode.Text.Trim <> "" Then

        '        ' Modified by Dadang Adi Hendradi
        '        ' Senin, 23 Nov 2009, 01:15
        '        ' Adding StockDescp in parameters and where clause

        '        Dim DTSTMasterExist As DataTable
        '        DTSTMasterExist = CheckRoll_BOL.LookUpBOL.STMasterIsExist("", _
        '                                                                  txtStockCode.Text, _
        '                                                                  "")

        '        If DTSTMasterExist.Rows.Count = 0 Then
        '            lblStockID.Text = String.Empty
        '            lblStockDescp.ForeColor = Color.Red
        '            lblStockDescp.Text = "Stock code not valid!"
        '            txtStockCode.Focus()
        '            'MessageBox.Show("Stcok Code is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '        ElseIf DTSTMasterExist.Rows.Count > 0 Then
        '            txtStockCode.Text = DTSTMasterExist.Rows(0).Item("StockCode").ToString()
        '            lblStockID.Text = DTSTMasterExist.Rows(0).Item("StockID").ToString()
        '            lblStockDescp.ForeColor = Color.Blue
        '            lblStockDescp.Text = DTSTMasterExist.Rows(0).Item("StockDesc").ToString()

        '            lblUom1.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
        '            lblUom2.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
        '            lblUom3.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
        '        End If
        '    End If
        'ElseIf e.KeyCode = Keys.Escape Then
        'End If

    End Sub

    Private Sub txtIssueQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIssueQty.KeyDown
        ' Selasa, 27 Oct 2009, 16:22
        ' by Dadang Adi
        ' Initialize the flag to false.

        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Decimal AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                    e.SuppressKeyPress = True ' Selasa, 1 Des 2009, 00:35
                End If
            End If
        End If

        'ElseIf e.KeyCode = Keys.Escape Then
        '    txtUsageQty.Focus()
        'End If
    End Sub

    Private Sub txtIssueQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIssueQty.KeyPress
        ' Selasa, 27 Oct 2009, 14:23
        ' by Dadang Adi H
        ' Check for the flag being set in the KeyDown event.
        If nonNumberEntered = True Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else

            If e.KeyChar = vbCr Then
                txtUsageQty.Focus()
            End If
        End If

    End Sub

    Private Sub txtIssueQty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIssueQty.Leave
        ' Selasa, 27 Oct 2009, 14:24
        If txtIssueQty.Text = "" Or txtIssueQty.Text = "." Then
            txtIssueQty.Text = "0"
        End If

    End Sub

    Private Sub txtusageQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsageQty.KeyDown
        ' Selasa, 27 Oct 2009, 16:28
        ' by Dadang Adi
        ' Initialize the flag to false.
        nonNumberEntered = False

        ' Determine whether the keystroke is a number from the top of the keyboard.
        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            ' Determine whether the keystroke is a number from the keypad.
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                ' Determine whether the keystroke is a backspace.
                If e.KeyCode <> Keys.Back AndAlso e.KeyCode <> Keys.OemPeriod AndAlso e.KeyCode <> Keys.Decimal AndAlso e.KeyCode <> Keys.Enter Then
                    ' A non-numerical keystroke was pressed. 
                    ' Set the flag to true and evaluate in KeyPress event.
                    nonNumberEntered = True
                End If
            End If
        End If

        'ElseIf e.KeyCode = Keys.Escape Then
        '    btnAdd.Focus()
        'End If

    End Sub

    Private Sub txtUsageQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsageQty.KeyPress
        ' Selasa, 27 Oct 2009, 14:28
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

    Private Sub txtUsageQty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsageQty.Leave
        ' Selasa, 27 Oct 2009, 14:29
        If txtUsageQty.Text = "" Or txtUsageQty.Text = "." Then
            txtUsageQty.Text = "0"
        End If

        If txtIssueQty.Text = "" Or txtIssueQty.Text = "." Then
            txtIssueQty.Text = "0"
        End If

        Dim dIssueQty As Decimal = 0
        Dim dUsageQty As Decimal = 0
        Dim dBalanceQty As Decimal = 0

        dIssueQty = Convert.ToDecimal(txtIssueQty.Text)
        dUsageQty = Convert.ToDecimal(txtUsageQty.Text)

        If dUsageQty <= dIssueQty Then
            dBalanceQty = dIssueQty - dUsageQty
            txtBalanceQty.Text = dBalanceQty.ToString()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If btnAdd.Text = "&Add" Then

            If CheckInput() Then
                DoAdd()
                Reset()
            End If


        ElseIf btnAdd.Text = "&Update" Then

            If CheckInput() Then

                If DoUpdate() Then
                    Reset()
                    btnAdd.Text = "&Add"
                    btnReset.Enabled = False
                    btnSaveAll.Enabled = True
                    btnClose.Enabled = True
                    dgvMaterial.Enabled = True ' Senin, 30 Nov 2009, 23:26
                End If

            End If
        End If

    End Sub


    Private Function CheckInput() As Boolean
        ' Selasa, 27 Oct 2009, 14:48
        If txtCOACode.Text = String.Empty Then
            MessageBox.Show("Activity not valid..", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCOACode.Focus()
            Return False
        End If

        If txtStockCode.Text.Trim = String.Empty Then
            MessageBox.Show("Stock Code is required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStockCode.Focus()
            Return False
        End If

        ' Senin, 30 Nov 2009, 23:39
        Dim DTSTMasterExist As DataTable
        DTSTMasterExist = CheckRoll_BOL.LookUpBOL.STMasterIsExist("", _
                                                                  txtStockCode.Text.Trim, _
                                                                  "")

        If DTSTMasterExist.Rows.Count = 0 Then
            lblStockID.Text = String.Empty
            lblStockDescp.ForeColor = Color.Red
            lblStockDescp.Text = "Stock code not valid!"
            MessageBox.Show("Stcok Code is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStockCode.Focus()
            Return False


        ElseIf DTSTMasterExist.Rows.Count > 0 Then
            txtStockCode.Text = DTSTMasterExist.Rows(0).Item("StockCode").ToString()
            lblStockID.Text = DTSTMasterExist.Rows(0).Item("StockID").ToString()
            lblStockDescp.ForeColor = Color.Blue
            lblStockDescp.Text = DTSTMasterExist.Rows(0).Item("StockDesc").ToString()

            lblUom1.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
            lblUom2.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
            lblUom3.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
        End If
        ' END Senin, 30 Nov 2009, 23:39

        'If String.IsNullOrEmpty(lblStockID.Text) Then
        '    MessageBox.Show("Stock Code not valid..", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtStockCode.Focus()
        '    Return False
        'End If

        If txtIssueQty.Text = "0" Then
            MessageBox.Show("Issue Qty cannot be zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtIssueQty.Focus()
            Return False
        End If

        If txtUsageQty.Text = "0" Then
            MessageBox.Show("Usage Qty cannot be zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsageQty.Focus()
            Return False
        End If

        Dim dIssueQty As Decimal = 0
        Dim dUsageQty As Decimal = 0

        Try
            dIssueQty = Convert.ToDecimal(txtIssueQty.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try

        Try
            dUsageQty = Convert.ToDecimal(txtUsageQty.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try

        If dUsageQty > dIssueQty Then
            MessageBox.Show("Usage Qty cannot more than Issue Qty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsageQty.Focus()
            Return False

        End If

        Return True
    End Function

    Private Function DoAdd() As Boolean


        Dim newRow As DataRow

        newRow = DT_Material.NewRow
        newRow.Item("MaterialUsageID") = String.Empty
        newRow.Item("SIVNo") = txtSIVNo.Text
        newRow.Item("StockCode") = txtStockCode.Text
        newRow.Item("StockDesc") = lblStockDescp.Text

        newRow.Item("EstateID") = GlobalPPT.strEstateID
        newRow.Item("EstateCode") = GlobalPPT.strEstateCode
        newRow.Item("ActiveMonthYearID") = GlobalPPT.strActMthYearID
        newRow.Item("DailyDistributionID") = Me.DailyDistributionID
        newRow.Item("STIssueID") = System.DBNull.Value
        newRow.Item("StockID") = lblStockID.Text

        newRow.Item("IssuedQty") = txtIssueQty.Text
        newRow.Item("UsageQty") = txtUsageQty.Text

        newRow.Item("UOM") = lblUom1.Text

        newRow.Item("CreatedBy") = GlobalPPT.strUserName
        newRow.Item("CreatedOn") = Now
        newRow.Item("ModifiedBy") = GlobalPPT.strUserName
        newRow.Item("ModifiedOn") = Now

        DT_Material.Rows.Add(newRow)
        dgvMaterial.DataSource = DT_Material
        Return True

    End Function

    Private Function DoUpdate() As Boolean
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvMaterial.DataSource, dgvMaterial.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        ' Use Currency Manager and DataView to retrieve the Current Row
        Dim dr As DataRow
        dr = dv.Item(cm.Position).Row

        Try

            dr.Item("SIVNo") = txtSIVNo.Text
            dr.Item("StockCode") = txtStockCode.Text
            dr.Item("StockDesc") = lblStockDescp.Text
            dr.Item("StockID") = lblStockID.Text
            dr.Item("IssuedQty") = txtIssueQty.Text
            dr.Item("UsageQty") = txtUsageQty.Text

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try

        Return True
    End Function

    Private Sub Reset()
        'txtActivity.Text = ""
        'lblActivity.Text = ""
        'lblActId.Text = ""
        txtSIVNo.Text = ""
        txtStockCode.Text = ""
        lblStockDescp.Text = ""
        lblStockID.Text = ""
        txtIssueQty.Text = ""
        txtUsageQty.Text = ""
        txtBalanceQty.Text = ""

        lblUom1.Text = String.Empty
        lblUom2.Text = String.Empty
        lblUom3.Text = String.Empty
    End Sub

    Private Sub ResetAll()
        lblMandorEmpName.Text = String.Empty
        lblKraniEmpName.Text = String.Empty

        lblDailyDistributionID.Text = String.Empty
        lblEmpId.Text = String.Empty

        txtCOACode.Text = String.Empty
        lblCOADescp.Text = String.Empty

        lblCOAID.Text = String.Empty
        txtSIVNo.Text = String.Empty
        txtStockCode.Text = String.Empty
        lblStockDescp.Text = String.Empty
        lblStockID.Text = String.Empty
        txtIssueQty.Text = String.Empty
        txtUsageQty.Text = String.Empty
        txtBalanceQty.Text = String.Empty
        txtGangName.Text = String.Empty
        lblGangMasterID.Text = String.Empty

        lblUom1.Text = String.Empty
        lblUom2.Text = String.Empty
        lblUom3.Text = String.Empty

        DT_Material.Clear()
        'dgvMaterial.DataSource = Nothing

    End Sub


    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
        btnAdd.Text = "&Add"
        'btnReset.Enabled = False
        btnSaveAll.Enabled = True
        btnClose.Enabled = True
        dgvMaterial.Enabled = True ' Senin, 30 Nov 2009, 23:26

        'btnUpdate.Visible = False
        'btnRpt.Enabled = False
        'btnAdd.Visible = True
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        SaveMaterial()
    End Sub

    Private Sub SaveMaterial()
        ' Ahad, 15 Nov 2009, 21:35
        Dim rowAffected As Integer

        Try
            rowAffected = MaterialTableAdapter.Update(DT_Material)
            If rowAffected > 0 Then

                ' Jum'at, 1 Jan 2010, 13:47
                CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
                ' END Jum'at, 1 Jan 2010, 13:47

                MessageBox.Show("Material Data Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If dgvMaterial.Rows.Count > 0 Then
            Reset()
            btnUpdate.Visible = True
            btnAdd.Visible = False
            DoEdit()

        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        Dim jwb As String
        jwb = MsgBox("Are you sure want to delete this Data", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
        If jwb = 6 Then
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Delete()
            MsgBox("Your data has been deleted, please Save All to confirm", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information")
            txtChange.Text = "Delete"
        End If

    End Sub

    Private Sub dgvMaterial_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMaterial.DoubleClick

        If DT_Material.Rows.Count = 0 Then
            Return
        End If

        btnAdd.Text = "&Update"
        btnReset.Enabled = True
        btnSaveAll.Enabled = False
        btnClose.Enabled = False
        dgvMaterial.Enabled = False ' Senin, 30 Nov 2009, 23:26
        DoEdit()
    End Sub

    Private Sub DoEdit()
        ' Get the Currency Manager by using the BindingContext of the DataGrid
        Dim cm As CurrencyManager = CType(Me.BindingContext(dgvMaterial.DataSource, dgvMaterial.DataMember), CurrencyManager)
        Dim dv As DataView = CType(cm.List, DataView)

        ' Use Currency Manager and DataView to retrieve the Current Row
        Dim dr As DataRow
        dr = dv.Item(cm.Position).Row

        Try

            txtSIVNo.Text = dr.Item("SivNo")
            txtStockCode.Text = dr.Item("StockCode")
            lblStockDescp.Text = dr.Item("StockDesc")
            lblStockID.Text = dr.Item("StockID")

            txtIssueQty.Text = dr.Item("IssuedQty")
            txtUsageQty.Text = dr.Item("UsageQty")

            ' Ahad, 15 Nov 2009, 21:21
            If Not dr.IsNull("UOM") Then

                lblUom1.Text = dr.Item("UOM")
                lblUom2.Text = dr.Item("UOM")
                lblUom3.Text = dr.Item("UOM")
            End If
            txtBalanceQty.Text = Val(txtIssueQty.Text) - Val(txtUsageQty.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Material")
        End Try

    End Sub

    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRpt.Click
        LFormula = "{Stmaster.StockCode} =" + "'" + txtStockCode.Text + "'"
        LSource = CurDir() + "\Checkroll_Report\MaterialUsageReport.Rpt"
        ViewReport._Formula = LFormula
        ViewReport._Source = LSource
        ViewReport.ShowDialog()
        'MsgBox("Under Construction")

    End Sub

    Private Sub txtStockCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockCode.Leave
        If txtStockCode.Text.Trim = "" Then
            lblStockDescp.Text = String.Empty
            txtIssueQty.Focus()

        ElseIf txtStockCode.Text.Trim <> "" Then

            ' Modified by Dadang Adi Hendradi
            ' Senin, 23 Nov 2009, 01:15
            ' Adding StockDescp in parameters and where clause

            Dim DTSTMasterExist As DataTable
            DTSTMasterExist = CheckRoll_BOL.LookUpBOL.STMasterIsExist("", _
                                                                      txtStockCode.Text.Trim, _
                                                                      "")

            If DTSTMasterExist.Rows.Count = 0 Then
                lblStockID.Text = String.Empty
                lblStockDescp.ForeColor = Color.Red
                lblStockDescp.Text = "Stock code not valid!"
                txtStockCode.Focus()
                'MessageBox.Show("Stcok Code is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            ElseIf DTSTMasterExist.Rows.Count > 0 Then
                txtStockCode.Text = DTSTMasterExist.Rows(0).Item("StockCode").ToString()
                lblStockID.Text = DTSTMasterExist.Rows(0).Item("StockID").ToString()
                lblStockDescp.ForeColor = Color.Blue
                lblStockDescp.Text = DTSTMasterExist.Rows(0).Item("StockDesc").ToString()

                lblUom1.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
                lblUom2.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
                lblUom3.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
            End If
        End If

    End Sub

   
End Class