Imports Common_BOL
Imports Common_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel
Imports System.Linq
Public Class ProductionFinishGoodsFrm
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0

    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionFinishGoodsFrm))

    Dim CurrentHeader As New ProductionFinishGoodsPPT

    Private Sub ProductionFinishGoodsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

        SetUICulture(GlobalPPT.strLang)
        TabContainerMain.SelectedTab = tabSearchView

        'QtyTodayWetDryFill()
        'QtyTodayWetFill()
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'sample
            'tabLPOContainer.TabPages("tabLPO").Text = rm.GetString("tabLPOContainer.TabPages(tabLPO).Text ")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        Try
            getObjectFromUI(CurrentHeader)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

        SaveAll(CurrentHeader)

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Sub getObjectFromUI(objFinishGoodsPPT)

        With objFinishGoodsPPT

            Try
                .DocDate = dtpDate.Value.Date + TimeOfDay.ToString(" hh:mm:ss tt")
            Catch ex As Exception
                Throw New Exception("Invalid Date")
            End Try

            Try
                If txtStation.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Station")
                Else
                    .Station = txtStation.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Station")
            End Try

            Try
                If txtstorage.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Storage RM")
                Else
                    .Storage = txtstorage.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Storage RM")
            End Try

            Try
                If txtproduct.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Product Type")
                Else
                    .Product = txtproduct.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Product Type")
            End Try

            Try
                If txtLocation.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Location")
                Else
                    .Location = txtLocation.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Location")
            End Try

            Try
                If txtRemarks.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Remarks")
                Else
                    .Remarks = txtRemarks.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Remarks")
            End Try

            Try
                .QtyDry = Decimal.Parse(txtQtyDry.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Qty Dry")
            End Try

            Try
                .QtyWet = Decimal.Parse(txtQtyWet.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Qty Wet")
            End Try

            Try
                .DRC = Decimal.Parse(txtDrc.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid DRC")
            End Try

        End With

    End Sub

    Private Sub SaveAll(objFinishGoodsPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim ds As New DataSet
        Try
            ProductionFinishGoodsBOL.Save(objFinishGoodsPPT)
            'DisplayInfoMessage("Msg04")
            MessageBox.Show("Saved Successfully", "Important Message")
            ResetAllSaveContrls()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Add()
        btnAddFlag = True
        CurrentHeader = New ProductionFinishGoodsPPT()
        ResetAllSaveContrls()
        Me.TabContainerMain.SelectedTab = tabSave
    End Sub

    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtproduct.Text = String.Empty
        txtstorage.Text = String.Empty
        txtStation.Text = String.Empty
        txtLocation.Text = String.Empty
        txtRemarks.Text = String.Empty
        txtQtyDry.Text = String.Empty
        txtQtyWet.Text = String.Empty
        txtQtyDry.Text = String.Empty
        txtDrc.Text = String.Empty
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Add()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub

    Sub EditSelectedItem()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 And dgvView.SelectedRows.Count > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionFinishGoodsPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    'txtDocID.Text = CurrentHeader.Id
                    dtpDate.Text = CurrentHeader.DocDate
                    txtproduct.Text = CurrentHeader.Product
                    txtstorage.Text = CurrentHeader.Storage
                    txtStation.Text = CurrentHeader.Station
                    txtLocation.Text = CurrentHeader.Location
                    txtRemarks.Text = CurrentHeader.Remarks
                    txtQtyDry.Text = CurrentHeader.QtyDry
                    txtQtyWet.Text = CurrentHeader.QtyWet
                    txtDrc.Text = CurrentHeader.DRC
                    TabContainerMain.SelectedTab = tabSave
                End If
            End If
        End If
    End Sub

    Private Sub btnResetAll_Click(sender As System.Object, e As System.EventArgs) Handles btnResetAll.Click
        ResetAllSaveContrls()
    End Sub

    Private Sub DeleteSelectedItem()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If DeleteToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionFinishGoodsPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    UpdateId = CurrentHeader.Id
                    Try
                        ProductionFinishGoodsBOL.DeleteLastFinishGoods(CurrentHeader)
                        'DisplayInfoMessage("Msg04")
                        MessageBox.Show("Deleted Successfully", "Important Message")
                        GridViewBind()
                    Catch ex As Exception
                        'DisplayInfoMessage("Error: " + ex.Message)
                        MessageBox.Show("Error: " + ex.Message, "Important Message")
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteSelectedItem()

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub GridViewBind()
        ResetAllSaveContrls()
        Dim objBOL As New ProductionFinishGoodsBOL
        Dim dt As New ObservableCollection(Of ProductionFinishGoodsPPT)

        Dim SearchObjPPT As ProductionFinishGoodsPPT = New ProductionFinishGoodsPPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchProd.Text.Trim().Length > 0 Then
            SearchObjPPT.Product = txtSearchProd.Text.Trim
        End If
        If txtSearchStor.Text.Trim().Length > 0 Then
            SearchObjPPT.Storage = txtSearchStor.Text.Trim
        End If

        Try
            dt = New ObservableCollection(Of ProductionFinishGoodsPPT)(objBOL.GetSearchResults(SearchObjPPT))
        Catch ex As Exception
            MsgBox("Search Failed.")
        End Try

        If Not dt Is Nothing Then
            If dt.Count <> 0 Then
                dgvView.AutoGenerateColumns = False
                Me.dgvView.DataSource = dt
                lblView.Visible = False
            Else
                dgvView.DataSource = Nothing  '''''clear the records from grid view
                lblView.Visible = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnViewSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnViewSearch.Click
        GridViewBind()
    End Sub

    Private Sub chkDocDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDocDate.CheckedChanged
        dtpSearchDocDate.Enabled = chkDocDate.Checked
    End Sub

    Private Sub dgvView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellDoubleClick
        EditViewGridRecord()
        'QtyTodayWetDryFill()
    End Sub

    Private Sub EditViewGridRecord()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    EditSelectedItem()
                End If
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnStation_Click(sender As System.Object, e As System.EventArgs) Handles btnStation.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StationSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtStation.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnprod_Click(sender As System.Object, e As System.EventArgs) Handles btnprod.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Form", "Finished Goods")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductCodeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtproduct.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnSearchSource_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchSource.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Form", "Finished Goods")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StorageTankSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtstorage.Text = frm.Result(0)
        End If
    End Sub

    'To select last sum of qty cenex dry from db
    'Sub QtyTodayWetDryFill()
    '    Dim objdb As New SQLHelp
    '    Dim params(1) As SqlParameter
    '    Dim dt As New DataTable
    '    params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    '    dt = objdb.ExecQuery("[Production].[ProductionFinishGoodsQtyTWetDry]", params).Tables(0)
    '    txtQtyTodayWet.Text = dt.Rows(0)(0).ToString()
    '    txtQtyTodayDry.Text = dt.Rows(0)(1).ToString()
    '    'If dt.Rows.Count > 0 Then
    '    '    txtQtyTodayWet.Text = dt.Rows(0)(0).ToString()
    '    '    txtQtyTodayDry.Text = dt.Rows(0)(1).ToString()
    '    'Else
    '    '    txtQtyTodayWet.Text = "0.00"
    '    '    txtQtyTodayDry.Text = "0.00"
    '    'End If
    'End Sub

    'To select last sum of qty cenex wet from db
    'Sub QtyTodayWetFill()
    '    Dim objdb As New SQLHelp
    '    Dim params(1) As SqlParameter
    '    Dim dt As New DataTable
    '    params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    '    dt = objdb.ExecQuery("[Production].[ProductionFinishGoodsQtyTodayWet]", params).Tables(0)
    '    If dt.Rows.Count > 0 Then
    '        txtQtyTodayWet.Text = dt.Rows(0)(0).ToString()
    '    Else
    '        txtQtyTodayWet.Text = "0.00"
    '    End If
    'End Sub

    Private Sub txtQtyDry_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQtyDry.TextChanged
        drccalc()
    End Sub

    Private Sub txtQtyWet_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQtyWet.TextChanged
        drccalc()
    End Sub
    Private Sub drccalc()
        If txtQtyDry.Text <> "" And txtQtyWet.Text <> "" Then
            Dim qdry As Decimal
            Dim qwet As Decimal
            Dim drc As Decimal
            qdry = Decimal.Parse(txtQtyDry.Text.Trim())
            qwet = Decimal.Parse(txtQtyWet.Text.Trim())
            drc = (qdry / qwet) * 100
            txtDrc.Text = drc
        Else
            txtDrc.Text = String.Empty
        End If

    End Sub
End Class