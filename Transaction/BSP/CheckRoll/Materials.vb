Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports CheckRoll_DAL

Public Class Materials
    Public ldailydistributionId As String = String.Empty
    Public LEmpName As String = String.Empty
    Public LEmpId As String = String.Empty
    Public LempCode As String = String.Empty
    Public lcoaid As String = String.Empty
    Public lcoaCode As String = String.Empty
    Public lcoadescp As String = String.Empty

    Public lstringctrl As String = String.Empty
    Public LSource As String = String.Empty
    Public LFormula As String = String.Empty
    Public ltanggal As String = String.Empty
    Public Lactivity As String = String.Empty
    Public LteamId As String = String.Empty
    Public LTeamName As String = String.Empty
    Public StrUsername As String = String.Empty
    Public StrEstateCode As String = String.Empty
    Public StrEstateID As String = String.Empty
    Public StrEstateName As String = String.Empty
    Public StrActMthYearID As String = String.Empty
    Public Rdate As String = String.Empty
    Public DT_Material As DataTable = New DataTable
    Public Sdate As String = String.Empty
    Private MaterialeAdapter As Material_Dal

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If txtChange.Text = "Update" Or txtChange.Text = "Delete " Then
            Dim jwb As String
            jwb = MsgBox("Your data has not been saved yet, do you want to close this screen?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
            If jwb = 6 Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If

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
                lblStockId.Text = Stock_Lookup._StockId
                lblStockDescp.Text = Stock_Lookup._StockDescp
                lblPartNo.Text = Stock_Lookup._PartNo
                lblUom1.Text = Stock_Lookup._UOM
                lblUom2.Text = Stock_Lookup._UOM
                lblUom3.Text = Stock_Lookup._UOM
                txtIssueQty.Focus()
            End If
        End If


    End Sub

    Private Sub Materials_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If txtChange.Text = "Update" Or txtChange.Text = "Delete " Then
            Dim jwb As String
            jwb = MsgBox("Your data has not been saved yet, do you want to save data?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
            If jwb = 6 Then
                '=============================
                If txtChange.Text = "" Then
                    MsgBox("Nothing Change", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) ',"Warning")
                ElseIf txtChange.Text <> "Update" And txtChange.Text <> "Delete" Then
                    If dgvMaterial.Rows.Count < 1 Then
                        MsgBox("Please Complete Your Data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) ',"Warning"
                    ElseIf dgvMaterial.Rows.Count > 0 Then
                        Dim jawb As String
                        jawb = MsgBox("Are You Really Want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
                        If jawb = 6 Then
                            Try
                                MaterialeAdapter.Update(DT_Material)
                                ResetAll()
                                DT_Material.Clear()
                                MsgBox("Your data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                                txtChange.Text = ""
                                Me.Close()
                            Catch ex As Exception
                                MsgBox(ex.ToString)
                                MsgBox("Your data has not been saved, please check your missing data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Information")
                            End Try
                        End If
                    End If

                ElseIf txtChange.Text = "Update" Or txtChange.Text = "Delete" Then
                    Dim jawb As String
                    jawb = MsgBox("Are You Really Want to Save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
                    If jawb = 6 Then
                        Try
                            MaterialeAdapter.Update(DT_Material)
                            ResetAll()
                            DT_Material.Clear()
                            MsgBox("Your data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                            txtChange.Text = ""
                            Me.Close()
                        Catch ex As Exception
                            MsgBox("Your data has not been saved, please check your missing data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Information")
                        End Try
                    End If
                End If

                '======================
            End If

        End If
    End Sub

    Private Sub Materials_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Material_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Rabu, 30 Sep 2009, 16:23
        ' Masalah di ADO.NET, kalo windows control panel di set format date nya ke dd/MM/yyyy
        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()

        MaterialeAdapter = New Material_Dal
        ResetAll()
        StrUsername = GlobalPPT.strUserName.ToString
        StrEstateCode = GlobalPPT.strEstateCode.ToString
        StrEstateID = GlobalPPT.strEstateID.ToString
        StrEstateName = GlobalPPT.strEstateName.ToString
        StrActMthYearID = GlobalPPT.strActMthYearID.ToString

        lblDailyDistributionID.Text = Me.ldailydistributionId
        lblEmpName.Text = Me.LEmpName
        lblEmpId.Text = Me.LEmpId
        txtNIK.Text = Me.LempCode
        lblActivity.Text = Me.lcoadescp
        txtActivity.Text = Me.lcoaCode
        lblActId.Text = Me.lcoaid
        dtpDate.Value = Me.ltanggal


        If txtActivity.Text = "" Then
            MsgBox("Please select activity from activity distribution screen", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
            Return
        End If

        DT_Material.Clear()
        DT_Material = CheckRoll_BOL.MaterialBOL.DailyMaterialView(lblDailyDistributionID.Text, lblActId.Text)
        dgvMaterial.DataSource = DT_Material

        arrangeview()
        txtSIV.Focus()
        dgvMaterial.DefaultCellStyle.BackColor = Color.White
    End Sub

    Private Sub arrangeview()
        dgvMaterial.Columns.Item("COA ID").Visible = False
        'dgvMaterial.Columns.Item("Part No").Visible = False
        dgvMaterial.Columns.Item("Material Usage ID").Visible = False
        dgvMaterial.Columns.Item("Estate ID").Visible = False
        dgvMaterial.Columns.Item("Estate Code").Visible = False
        dgvMaterial.Columns.Item("Active Month Year ID").Visible = False
        dgvMaterial.Columns.Item("Daily Distribution ID").Visible = False
        dgvMaterial.Columns.Item("St Issue ID").Visible = False
        dgvMaterial.Columns.Item("Stock Id").Visible = False
        dgvMaterial.Columns.Item("CreatedBy").Visible = False
        dgvMaterial.Columns.Item("ModifiedBy").Visible = False

    End Sub

    Private Sub txtActivity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtActivity.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtActivity.Focus()
        End If
    End Sub

    Private Sub txtSIV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSIV.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtSIV.Text <> Nothing Then
                txtStockCode.Focus()
            End If
        End If
    End Sub

    Private Sub txtStockCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStockCode.KeyDown
        If e.KeyCode = Keys.Enter Then

            If txtStockCode.Text = "" Then
                txtStockCode.Focus()

            ElseIf txtStockCode.Text <> "" Then
                ' Modified by Dadang Adi Hendradi
                ' Senin, 23 Nov 2009, 01:10
                ' Adding StockDescp in parameters and where clause

                Dim DTSTMasterExist As DataTable
                DTSTMasterExist = CheckRoll_BOL.LookUpBOL.STMasterIsExist("", _
                                                                          txtStockCode.Text, _
                                                                          "")

                If DTSTMasterExist.Rows.Count = 0 Then
                    MsgBox("Stock Code is not valid", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                    Return

                ElseIf DTSTMasterExist.Rows.Count > 0 Then
                    txtStockCode.Text = DTSTMasterExist.Rows(0).Item("StockCode").ToString()
                    lblPartNo.Text = DTSTMasterExist.Rows(0).Item("Part No").ToString()
                    lblStockId.Text = DTSTMasterExist.Rows(0).Item("StockID").ToString()
                    lblStockDescp.Text = DTSTMasterExist.Rows(0).Item("StockDesc").ToString()
                    lblUom1.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
                    lblUom2.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
                    lblUom3.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
                End If
            End If

        ElseIf e.KeyCode = Keys.Escape Then
        End If

    End Sub

    Private Sub txtIssueQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIssueQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(txtIssueQty.Text) = False Then
                MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtIssueQty.Text = ""
                txtIssueQty.Focus()
            ElseIf IsNumeric(txtIssueQty.Text) = True Then
                txtusageQty.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            txtusageQty.Focus()
        End If
    End Sub

    Private Sub txtusageQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtusageQty.KeyDown

        If e.KeyCode = Keys.Enter Then
            If IsNumeric(txtusageQty.Text) = False Then
                MsgBox("Please key in numeric data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                txtusageQty.Text = ""
                txtBalanceQty.Text = ""
                txtusageQty.Focus()
            ElseIf IsNumeric(txtusageQty.Text) = True Then
                If Val(txtIssueQty.Text) > (txtusageQty.Text) Or Val(txtIssueQty.Text) = (txtusageQty.Text) Then
                    txtBalanceQty.Text = Val(txtIssueQty.Text) - (txtusageQty.Text)
                    btnAdd.Focus()
                ElseIf Val(txtIssueQty.Text) < (txtusageQty.Text) Then
                    MsgBox("Usage Qty the value is bigger dan Issue Qty", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Warning")
                    txtusageQty.Text = ""
                    txtBalanceQty.Text = ""
                    txtusageQty.Focus()
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            btnAdd.Focus()
        End If




    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtSIV.Text = Nothing Then
            MsgBox("Please Keyin Siv No", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            txtSIV.Focus()
            Return
        End If

        If txtStockCode.Text = Nothing Then
            MsgBox("Please keyin Stock Code ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            txtStockCode.Focus()
            Return

        ElseIf txtStockCode.Text <> Nothing Then
            ' Modified by Dadang Adi Hendradi
            ' Senin, 23 Nov 2009, 01:09
            ' Adding StockDescp in parameters and where clause

            Dim DTSTMasterExist As DataTable
            DTSTMasterExist = CheckRoll_BOL.LookUpBOL.STMasterIsExist("", _
                                                                      txtStockCode.Text, _
                                                                      "")

            If DTSTMasterExist.Rows.Count = 0 Then
                MsgBox("Stock Code is not valid", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
                Return
            ElseIf DTSTMasterExist.Rows.Count > 0 Then
                txtStockCode.Text = DTSTMasterExist.Rows(0).Item("StockCode").ToString()
                lblPartNo.Text = DTSTMasterExist.Rows(0).Item("PartNo").ToString()
                lblStockId.Text = DTSTMasterExist.Rows(0).Item("StockID").ToString()
                lblStockDescp.Text = DTSTMasterExist.Rows(0).Item("StockDesc").ToString()
                lblUom1.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString()
            End If
        End If


        If IsNumeric(txtIssueQty.Text) = False Or Val(txtIssueQty.Text) = 0 Then
            MsgBox("Please keyin Issued Qty ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            txtIssueQty.Focus()
            Return
        End If

        If IsNumeric(txtusageQty.Text) = False Or Val(txtusageQty.Text) = 0 Then
            MsgBox("Please keyin usage Qty ", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            txtusageQty.Focus()
            Return
        End If

        If Val(txtIssueQty.Text) < Val(txtusageQty.Text) Then
            MsgBox("Usage Qty should be greater than Issued Qty", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
            txtusageQty.Focus()
            Return
        End If

        If Val(txtIssueQty.Text) >= Val(txtusageQty.Text) Then
            txtBalanceQty.Text = Val(txtIssueQty.Text) - (txtusageQty.Text)
            Dim newdatarow As System.Data.DataRow
            DT_Material = dgvMaterial.DataSource
            newdatarow = DT_Material.NewRow
            newdatarow.Item("COA Id") = lblActId.Text
            newdatarow.Item("Activity") = lblActivity.Text
            newdatarow.Item("Activity Descp") = txtActivity.Text
            newdatarow.Item("Estate Id") = StrEstateID
            newdatarow.Item("Estate Code") = StrEstateCode
            newdatarow.Item("Active Month Year Id") = StrActMthYearID
            newdatarow.Item("Daily Distribution Id") = lblDailyDistributionID.Text
            newdatarow.Item("Siv No") = txtSIV.Text
            newdatarow.Item("Stock Id") = lblStockId.Text
            newdatarow.Item("Stock Code") = txtStockCode.Text
            newdatarow.Item("Part No") = lblPartNo.Text
            newdatarow.Item("Stock Descp") = lblStockDescp.Text
            newdatarow.Item("Issued qty") = FormatNumber(Val(txtIssueQty.Text), 3)
            newdatarow.Item("Usage qty") = FormatNumber(Val(txtusageQty.Text), 3)
            newdatarow.Item("Bal.Qty") = FormatNumber(Val(txtBalanceQty.Text), 3)
            newdatarow.Item("CreatedBy") = GlobalPPT.strUserName
            newdatarow.Item("ModifiedBy") = GlobalPPT.strUserName
            DT_Material.Rows.Add(newdatarow)
            Reset()
            txtActivity.Focus()
            txtChange.Text = "YES"
        End If


    End Sub

    Private Sub Reset()
        txtSIV.Text = ""
        txtStockCode.Text = ""
        lblStockDescp.Text = ""
        lblStockId.Text = ""
        txtIssueQty.Text = ""
        txtusageQty.Text = ""
        txtBalanceQty.Text = ""
        lblPartNo.Text = ""
    End Sub

    Private Sub ResetAll()
        lblGangMasterID.Text = ""
        lblEmpId.Text = ""
        txtSIV.Text = ""
        txtStockCode.Text = ""
        lblPartNo.Text = ""
        lblStockDescp.Text = ""
        lblStockId.Text = ""
        txtIssueQty.Text = ""
        txtusageQty.Text = ""
        txtBalanceQty.Text = ""
        txtNIK.Text = ""
        lblGangMasterID.Text = ""
        dgvMaterial.DataSource = Nothing

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
        btnUpdate.Visible = False
        btnRpt.Enabled = False
        btnAdd.Visible = True
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        If txtChange.Text = "" Then
            MsgBox("Nothing Change", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) ',"Warning")
        ElseIf txtChange.Text <> "Update" And txtChange.Text <> "Delete" Then
            If dgvMaterial.Rows.Count < 1 Then
                MsgBox("Please Complete Your Data", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) ',"Warning"
            ElseIf dgvMaterial.Rows.Count > 0 Then
                Dim jwb As String
                jwb = MsgBox("Do you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
                If jwb = 6 Then
                    Try
                        MaterialeAdapter.Update(DT_Material)
                        ResetAll()
                        DT_Material.Clear()

                        ' Jum'at, 1 Jan 2010, 13:48
                        CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
                        ' END Jum'at, 1 Jan 2010, 13:48

                        MsgBox("Your data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                        txtChange.Text = ""
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        MsgBox("Your data has not been saved, please check your missing data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Information")
                    End Try
                End If
            End If

        ElseIf txtChange.Text = "Update" Or txtChange.Text = "Delete" Then
            Dim jwb As String
            jwb = MsgBox("Do you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation")
            If jwb = 6 Then
                Try
                    MaterialeAdapter.Update(DT_Material)
                    ResetAll()
                    DT_Material.Clear()

                    ' Jum'at, 1 Jan 2010, 13:48
                    CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
                    ' END Jum'at, 1 Jan 2010, 13:48

                    MsgBox("Your data has been saved", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
                    txtChange.Text = ""
                    Me.Close()
                Catch ex As Exception
                    MsgBox("Your data has not been saved, please check your missing data", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Error Information")
                End Try
            End If
        End If


    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtStockCode.Text = "" Then
            MsgBox("Please key in Stock Code", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Warning")
        ElseIf txtStockCode.Text <> "" Then
            txtBalanceQty.Text = Val(txtIssueQty.Text) - (txtusageQty.Text)
            DT_Material = dgvMaterial.DataSource
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("COA Id") = lblActId.Text
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Activity") = lblActivity.Text
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Activity Descp") = txtActivity.Text
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Estate Id") = StrEstateID
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Estate Code") = StrEstateCode
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Active Month Year Id") = StrActMthYearID
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Daily Distribution Id") = lblDailyDistributionID.Text
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Siv No") = txtSIV.Text
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Stock Id") = lblStockId.Text
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Stock Code") = txtStockCode.Text
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Part No") = lblPartNo.Text
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Stock Descp") = lblStockDescp.Text
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Issued qty") = FormatNumber(txtIssueQty.Text, 3)
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Usage qty") = FormatNumber(txtusageQty.Text, 3)
            DT_Material.Rows(dgvMaterial.CurrentCell.RowIndex).Item("Bal.Qty") = FormatNumber(txtBalanceQty.Text, 3)
            txtChange.Text = "Update"
            btnUpdate.Visible = False
            btnAdd.Visible = True
            Reset()
            MsgBox("Data successfully updated", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If dgvMaterial.Rows.Count > 0 Then
            Reset()
            btnUpdate.Visible = True
            btnAdd.Visible = False
            If (dgvMaterial.SelectedRows(0).Cells("Siv No").Value.ToString) <> Nothing Then
                txtSIV.Text = (dgvMaterial.SelectedRows(0).Cells("Siv No").Value.ToString)
            End If

            If (dgvMaterial.SelectedRows(0).Cells("Issued Qty").Value.ToString) <> Nothing Then
                txtIssueQty.Text = (dgvMaterial.SelectedRows(0).Cells("Issued Qty").Value.ToString)
            End If

            lblActivity.Text = dgvMaterial.SelectedRows(0).Cells("COA Code").Value()
            txtActivity.Text = dgvMaterial.SelectedRows(0).Cells("COA Descp").Value()
            lblActId.Text = dgvMaterial.SelectedRows(0).Cells("COA ID").Value()
            lblDailyDistributionID.Text = dgvMaterial.SelectedRows(0).Cells("Daily Distribution ID").Value()
            txtStockCode.Text = dgvMaterial.SelectedRows(0).Cells("Stock Code").Value()
            lblPartNo.Text = dgvMaterial.SelectedRows(0).Cells("Part No").Value()
            lblStockDescp.Text = dgvMaterial.SelectedRows(0).Cells("Stock Descp").Value()
            lblStockId.Text = dgvMaterial.SelectedRows(0).Cells("Stock Id").Value()
            txtusageQty.Text = dgvMaterial.SelectedRows(0).Cells("Usage Qty").Value()
            txtBalanceQty.Text = dgvMaterial.SelectedRows(0).Cells("Bal.Qty").Value()
            lblMaterialUsageID.Text = dgvMaterial.SelectedRows(0).Cells("Material Usage ID").Value()

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
        If dgvMaterial.Rows.Count > 0 Then
            Reset()
            btnUpdate.Visible = True
            btnAdd.Visible = False
            btnRpt.Enabled = True
            If (dgvMaterial.SelectedRows(0).Cells("Siv No").Value.ToString) <> Nothing Then
                txtSIV.Text = (dgvMaterial.SelectedRows(0).Cells("Siv No").Value.ToString)
            End If

            If (dgvMaterial.SelectedRows(0).Cells("Issued Qty").Value.ToString) <> Nothing Then
                txtIssueQty.Text = (dgvMaterial.SelectedRows(0).Cells("Issued Qty").Value.ToString)
            End If

            lblActivity.Text = dgvMaterial.SelectedRows(0).Cells("Activity").Value()
            txtActivity.Text = dgvMaterial.SelectedRows(0).Cells("Activity Descp").Value()
            lblActId.Text = dgvMaterial.SelectedRows(0).Cells("COA ID").Value()
            If dgvMaterial.SelectedRows(0).Cells("Siv No").Value().ToString <> Nothing Then
                txtIssueQty.Text = dgvMaterial.SelectedRows(0).Cells("Siv No").Value()
            End If
            If Val(dgvMaterial.SelectedRows(0).Cells("Issued Qty").Value().ToString) > 0 Then
                txtIssueQty.Text = dgvMaterial.SelectedRows(0).Cells("Issued Qty").Value()
            End If

            If dgvMaterial.SelectedRows(0).Cells("Daily Distribution ID").Value().ToString <> "" Then
                lblDailyDistributionID.Text = dgvMaterial.SelectedRows(0).Cells("Daily Distribution ID").Value()
            End If

            If dgvMaterial.SelectedRows(0).Cells("Stock Code").Value().ToString <> "" Then

                ' Modified by Dadang Adi Hendradi
                ' Senin, 23 Nov 2009, 01:15
                ' Adding StockDescp in parameters and where clause

                txtStockCode.Text = dgvMaterial.SelectedRows(0).Cells("Stock Code").Value()
                Dim DTSTMasterExist As DataTable
                DTSTMasterExist = CheckRoll_BOL.LookUpBOL.STMasterIsExist("", _
                                                                          txtStockCode.Text, _
                                                                          "")

                If DTSTMasterExist.Rows.Count > 0 Then
                    lblUom1.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString
                    lblUom2.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString
                    lblUom3.Text = DTSTMasterExist.Rows(0).Item("UOM").ToString
                End If

            End If

            If dgvMaterial.SelectedRows(0).Cells("Stock Descp").Value().ToString <> "" Then
                lblStockDescp.Text = dgvMaterial.SelectedRows(0).Cells("Stock Descp").Value()
            End If

            If dgvMaterial.SelectedRows(0).Cells("Part No").Value().ToString <> "" Then
                lblPartNo.Text = dgvMaterial.SelectedRows(0).Cells("Part No").Value()
            End If

            If dgvMaterial.SelectedRows(0).Cells("Stock Id").Value().ToString <> "" Then
                lblStockId.Text = dgvMaterial.SelectedRows(0).Cells("Stock Id").Value()
            End If

            If Val(dgvMaterial.SelectedRows(0).Cells("Usage Qty").Value().ToString) > 0 Then
                txtusageQty.Text = dgvMaterial.SelectedRows(0).Cells("Usage Qty").Value()
            End If

            If Val(dgvMaterial.SelectedRows(0).Cells("Bal.Qty").Value().ToString) > 0 Then
                txtBalanceQty.Text = dgvMaterial.SelectedRows(0).Cells("Bal.Qty").Value()
            End If

            If dgvMaterial.SelectedRows(0).Cells("Material Usage ID").Value().ToString <> "" Then
                lblMaterialUsageID.Text = dgvMaterial.SelectedRows(0).Cells("Material Usage ID").Value()
            End If

            txtBalanceQty.Text = Val(txtIssueQty.Text) - Val(txtusageQty.Text)

        ElseIf dgvMaterial.Rows.Count = 0 Then
            btnUpdate.Visible = False
            btnAdd.Visible = True
            btnRpt.Enabled = False
        End If

    End Sub
    Private Sub Button2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRpt.Click
        LFormula = "{Stmaster.StockCode} =" + "'" + txtStockCode.Text + "'"
        LSource = CurDir() + "\Checkroll_Report\MaterialUsageReport.Rpt"
        ViewReport._Formula = LFormula
        ViewReport._Source = LSource
        ViewReport.ShowDialog()
        'MsgBox("Under Construction")

    End Sub
   
    Private Sub dgvMaterial_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMaterial.CellContentClick

    End Sub
End Class