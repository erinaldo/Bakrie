Imports Common_BOL
Imports Common_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel
Imports System.Linq
Public Class ProductionTransferFrm
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0

    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionTransferFrm))

    Dim CurrentHeader As New ProductionTransferPPT

    Private Sub ProductionTransferFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If

        SetUICulture(GlobalPPT.strLang)
        TabContainerMain.SelectedTab = tabSearchView
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

    Private Sub btnProductFrom_Click(sender As System.Object, e As System.EventArgs) Handles btnProductFrom.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@form", "Transfer")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductCodeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtProductFrom.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnStorageFrom_Click(sender As System.Object, e As System.EventArgs) Handles btnStorageFrom.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StorageTankSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtStorageFrom.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnProductTo_Click(sender As System.Object, e As System.EventArgs) Handles btnProductTo.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@form", "Transfer")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductCodeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtProductTo.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnStorageTo_Click(sender As System.Object, e As System.EventArgs) Handles btnStorageTo.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StorageTankSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtStorageTo.Text = frm.Result(0)
        End If
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

    Sub getObjectFromUI(objTransferPPT)

        With objTransferPPT

            Try
                .DocDate = dtpDate.Value.Date + TimeOfDay.ToString(" hh:mm:ss tt")
            Catch ex As Exception
                Throw New Exception("Invalid Date")
            End Try

            Try
                If txtProductFrom.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Product Type From")
                Else
                    .ProductFrom = txtProductFrom.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Product Type From")
            End Try

            Try
                If txtStorageFrom.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Storage RM From")
                Else
                    .StorageFrom = txtStorageFrom.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Storage RM From")
            End Try

            Try
                If txtProductTo.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Product Type To")
                Else
                    .ProductTo = txtProductTo.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Product Type To")
            End Try

            Try
                If txtStorageTo.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Storage RM To")
                Else
                    .StorageTo = txtStorageTo.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Storage RM To")
            End Try

            Try
                .QtyFromWet = Decimal.Parse(txtQtyFW.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Quantity From Wet")
            End Try

            Try
                .QtyFromDry = Decimal.Parse(txtQtyFD.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Quantity From Dry")
            End Try

            Try
                .QtyToWet = Decimal.Parse(txtQtyTW.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Quantity To Wet")
            End Try

            Try
                .QtyToDry = Decimal.Parse(txtQtyTD.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Quantity To Dry")
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

        End With

    End Sub

    Private Sub SaveAll(objTransferPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim ds As New DataSet
        Try
            ProductionTransferBOL.Save(objTransferPPT)
            'DisplayInfoMessage("Msg04")
            MessageBox.Show("Saved Successfully", "Important Message")
            ResetAllSaveContrls()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Add()
    End Sub

    Private Sub Add()
        btnAddFlag = True
        CurrentHeader = New ProductionTransferPPT()
        ResetAllSaveContrls()
        Me.TabContainerMain.SelectedTab = tabSave
    End Sub

    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtProductFrom.Text = String.Empty
        txtStorageFrom.Text = String.Empty
        txtProductTo.Text = String.Empty
        txtStorageTo.Text = String.Empty
        txtRemarks.Text = String.Empty
        txtQtyFD.Text = String.Empty
        txtQtyFW.Text = String.Empty
        txtQtyTD.Text = String.Empty
        txtQtyTW.Text = String.Empty
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub

    Sub EditSelectedItem()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 And dgvView.SelectedRows.Count > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionTransferPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    'txtDocID.Text = CurrentHeader.Id
                    dtpDate.Text = CurrentHeader.DocDate
                    txtProductFrom.Text = CurrentHeader.ProductFrom
                    txtStorageFrom.Text = CurrentHeader.StorageFrom
                    txtProductTo.Text = CurrentHeader.ProductTo
                    txtStorageTo.Text = CurrentHeader.StorageTo
                    txtRemarks.Text = CurrentHeader.Remarks
                    txtQtyFD.Text = CurrentHeader.QtyFromDry
                    txtQtyFW.Text = CurrentHeader.QtyFromWet
                    txtQtyTD.Text = CurrentHeader.QtyToDry
                    txtQtyTW.Text = CurrentHeader.QtyToWet
                    TabContainerMain.SelectedTab = tabSave

                End If
            End If
        End If
    End Sub

    Private Sub btnResetAll_Click(sender As System.Object, e As System.EventArgs) Handles btnResetAll.Click
        ResetAllSaveContrls()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub DeleteSelectedItem()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If DeleteToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionTransferPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    UpdateId = CurrentHeader.Id
                    Try
                        ProductionTransferBOL.DeleteLastTransfer(CurrentHeader)
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

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteSelectedItem()

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub GridViewBind()
        ResetAllSaveContrls()
        Dim objBOL As New ProductionTransferBOL
        Dim dt As New ObservableCollection(Of ProductionTransferPPT)

        Dim SearchObjPPT As ProductionTransferPPT = New ProductionTransferPPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchProdTo.Text.Trim().Length > 0 Then
            SearchObjPPT.ProductTo = txtSearchProdTo.Text.Trim
        End If
        If txtSearchStorTo.Text.Trim().Length > 0 Then
            SearchObjPPT.StorageTo = txtSearchStorTo.Text.Trim
        End If

        Try
            dt = New ObservableCollection(Of ProductionTransferPPT)(objBOL.GetSearchResults(SearchObjPPT))
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

End Class