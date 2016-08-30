Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel

Public Class ProductionRawMaterialStorageFrm
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0

    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionRawMaterialStorageFrm))
    Dim CurrentHeader As New ProductionRMSPPT

    Private Sub ProductionRawMaterialStorageFrm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        SetUICulture(GlobalPPT.strLang)
        FillTotalWetDry()
        TabContainerMain.SelectedTab = TabSearch

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

    Sub FillTotalWetDry()
        Dim objRMSBOL As New ProductionRMSBOL
        Dim dt1 As New DataTable()
        dt1 = objRMSBOL.FillTotalWetDry()
        txtTotalTodateDry.Text = dt1.Rows(0)("Dry").ToString()
        txtTotalTodateWet.Text = dt1.Rows(0)("Wet").ToString()
    End Sub


    ''' <summary>
    ''' Display message from resource file
    ''' </summary>
    ''' <param name="lsResourceKey"></param>
    ''' <remarks></remarks>
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub


    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        Dim objRMSPPT As New ProductionRMSPPT

        Try
            getObjectFromUI(objRMSPPT)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
        Try
            SaveAll(objRMSPPT)
            MessageBox.Show("Saved Successfully", "Important Message")
            ResetAllSaveContrls()
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Important Message")
        End Try

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Dim objRMSPPT As New ProductionRMSPPT

        Try
            getObjectFromUI(objRMSPPT)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        ResetAllSaveContrls()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtLoc.Text = String.Empty
        txtproduct.Text = String.Empty
        txtstorage.Text = String.Empty
        txtTotalTodayDry.Text = String.Empty
        txtTotalTodayWet.Text = String.Empty
        txtTotalTodateDry.Text = String.Empty
        txtTotalTodateWet.Text = String.Empty
        FillTotalWetDry()
    End Sub

    Sub getObjectFromUI(objRMSPPT)

        With objRMSPPT
            Try
                .ID = UpdateId
            Catch ex As Exception
                .ID = 0
            End Try

            Try
                '.DocDate = Format(dtpDate.Value, "MM/dd/yyyy") + TimeOfDay.ToString(" hh:mm:ss tt")
                '.DocDate = dtpDate.Value.ToString("MM/dd/yyyy") + TimeOfDay.ToString(" hh:mm:ss tt")
                .DocDate = dtpDate.Value.Date + TimeOfDay.ToString(" hh:mm:ss tt")
                '.DocDate = dtpDate.Value
            Catch ex As Exception
                Throw New Exception("Invalid Date")
            End Try

            Try
                If txtLoc.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Location")
                Else
                    .RMSLoc = txtLoc.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Location")
            End Try

            Try
                If txtproduct.Text.Trim() Is "" Then
                    Throw New Exception("Invalid RM Type")
                Else
                    .RMSProduct = txtproduct.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid RM Type")
            End Try

            Try

                If txtstorage.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Source RM")
                Else
                    .RMSStorage = txtstorage.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Source RM")
            End Try

            Try
                .RMSTodayWet = Decimal.Parse(txtTotalTodayWet.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Total Today Wet")
            End Try

            Try
                .RMSTodayDry = Decimal.Parse(txtTotalTodayDry.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Total Today Dry")
            End Try

            Try
                .RMSTodateWet = Decimal.Parse(txtTotalTodateWet.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Total Todate Wet")
            End Try

            Try
                .RMSTodateDry = Decimal.Parse(txtTotalTodateDry.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Total Todate Dry")
            End Try

        End With


    End Sub


    Private Sub SaveAll(objRMSPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim objRMSDAL As New ProductionRMSDAL
        Dim ds As New DataSet
        ProductionRMSDAL.SaveRMS(objRMSPPT)

    End Sub

    Private Sub btnprod_Click(sender As System.Object, e As System.EventArgs) Handles btnprod.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Form", "RawMaterial Storage")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductCodeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtproduct.Text = frm.Result(0)
        End If
    End Sub

    Private Sub chkDocDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDocDate.CheckedChanged
        dtpSearchDocDate.Enabled = chkDocDate.Checked
    End Sub

    Private Sub btnViewSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnViewSearch.Click
        GridViewBind()
    End Sub

    Private Sub GridViewBind()
        ResetAllSaveContrls()
        Dim objBOL As New ProductionRMSBOL
        Dim dt As New ObservableCollection(Of ProductionRMSPPT)
        Dim SearchObjPPT As ProductionRMSPPT = New ProductionRMSPPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchSource.Text.Trim().Length > 0 Then
            SearchObjPPT.RMSStorage = txtSearchSource.Text.Trim
        End If
        If txtSearchType.Text.Trim().Length > 0 Then
            SearchObjPPT.RMSProduct = txtSearchType.Text.Trim
        End If
        Try
            dt = New ObservableCollection(Of ProductionRMSPPT)(objBOL.GetSearchResults(SearchObjPPT))
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
    'Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
    '    If grdname.Rows.Count <> 0 Then

    '        Dim objDataGridViewRow As New DataGridViewRow

    '        For iCount As Integer = 1 To grdname.Rows.Count
    '            grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
    '        Next

    '        If grdname.Rows.Count = 1 Then
    '            grdname.Rows.RemoveAt(0)
    '        End If
    '    End If

    'End Sub

    Private Sub dgvView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvView.CellDoubleClick
        EditViewGridRecord()
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

    Sub EditSelectedItem()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 And dgvView.SelectedRows.Count > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionRMSPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    UpdateId = CurrentHeader.ID
                    dtpDate.Text = CurrentHeader.DocDate
                    txtLoc.Text = CurrentHeader.RMSLoc
                    txtstorage.Text = CurrentHeader.RMSStorage
                    txtproduct.Text = CurrentHeader.RMSProduct
                    txtTotalTodayDry.Text = CurrentHeader.RMSTodayDry
                    txtTotalTodayWet.Text = CurrentHeader.RMSTodayWet
                    txtstorage.Text = CurrentHeader.RMSStorage
                    TabContainerMain.SelectedTab = TabSave

                End If
            End If
        End If


    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Add()
        ResetAllSaveContrls()
        'FillTotalWetDry()
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub Add()
        btnAddFlag = True
        Me.TabContainerMain.SelectedTab = TabSave
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub

    Private Sub btnSearchSource_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchSource.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Form", "RawMaterial Storage")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StorageTankSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtstorage.Text = frm.Result(0)
        End If
    End Sub

    Private Sub TabContainerMain_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabContainerMain.SelectedIndexChanged
        If TabContainerMain.SelectedTab Is TabSave Then
            'ResetAllSaveContrls()
            FillTotalWetDry()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteViewGridRecord()
    End Sub

    Private Sub DeleteViewGridRecord()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If DeleteToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionRMSPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    Try
                        ProductionRMSBOL.DeleteLastRMS(CurrentHeader)
                        'DisplayInfoMessage("Msg04")
                        MessageBox.Show("Deleted Successfully", "Important Message")
                        GridViewBind()
                    Catch ex As Exception
                        MessageBox.Show("Error: " + ex.Message, "Important Message")
                    End Try
                End If
            End If
        End If
    End Sub


    Private Sub btnSearchLocation_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchLocation.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[RMLocationGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtLoc.Text = frm.Result(0)
        End If

    End Sub
End Class