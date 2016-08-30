Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel
Public Class ProductionWIPFrm

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0
    Dim CurrentHeader As New WipPPT
    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionWIPFrm))

    Private Sub ProductionWIPFrm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        SetUICulture(GlobalPPT.strLang)
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

    ''' <summary>
    ''' Display message from resource file
    ''' </summary>
    ''' <param name="lsResourceKey"></param>
    ''' <remarks></remarks>
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnSource_Click(sender As System.Object, e As System.EventArgs) Handles btnSource.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Form", "WIP")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StorageTankSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtstorage.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnProduct_Click(sender As System.Object, e As System.EventArgs) Handles btnProduct.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Form", "WIP")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductCodeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtproduct.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnClasification_Click(sender As System.Object, e As System.EventArgs) Handles btnClasification.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ClassificationSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtclassification.Text = frm.Result(0)
        End If
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

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim objLWipPPT As New WipPPT
        Try
            getObjectFromUI(objLWipPPT)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
        SaveAll(objLWipPPT)
        'DisplayInfoMessage("Msg02")
        MessageBox.Show("Saved Successfully", "Important Message")
        ResetAllSaveContrls()
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Sub getObjectFromUI(objLWipPPT)

        With objLWipPPT
            Try
                .ID = UpdateId
            Catch ex As Exception
                .ID = 0
            End Try

            Try
                .DocDate = dtpDate.Value.Date + TimeOfDay.ToString(" hh:mm:ss tt")
            Catch ex As Exception
                Throw New Exception("Invalid Date")
            End Try

            Try
                If txtStation.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Station")
                Else
                    .WIPStation = txtStation.Text.Trim()
                End If

            Catch ex As Exception
                Throw New Exception("Invalid Station")
            End Try

            Try
                If txtstorage.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Storage")
                Else
                    .WIPStorage = txtstorage.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Storage")
            End Try

            Try
                If txtclassification.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Classification")
                Else
                    .WIPClass = txtclassification.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Classification")
            End Try

            Try
                If txtproduct.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Product Type")
                Else
                    .WIPProduct = txtproduct.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Product Type")
            End Try

            Try
                .WIPCenexDry = Decimal.Parse(txtQtyCenexDry.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Qty Cenex Dry")
            End Try

            Try
                .WIPCenexWet = txtQtyCenexWet.Text.Trim()
            Catch ex As Exception
                Throw New Exception("Invalid Qty Cenex Wet")
            End Try

            Try
                .WIPQtyDry = Decimal.Parse(txtQtyDry.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Qty Dry")
            End Try

            Try
                .WIPDrc = Decimal.Parse(txtDrc.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Drc(latex only)")
            End Try

        End With
    End Sub

    Private Sub SaveAll(objLWipPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim objLWipDAL As New WipDAL
        Dim ds As New DataSet
        WipDAL.SaveWIP(objLWipPPT)

    End Sub

    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtStation.Text = String.Empty
        txtstorage.Text = String.Empty
        txtclassification.Text = String.Empty
        txtproduct.Text = String.Empty
        txtQtyCenexDry.Text = String.Empty
        txtQtyCenexWet.Text = String.Empty
        txtQtyDry.Text = String.Empty
        txtDrc.Text = String.Empty
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Add()
        ResetAllSaveContrls()
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
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

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteViewGridRecord()
    End Sub

    Private Sub chkDocDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDocDate.CheckedChanged
        dtpSearchDocDate.Enabled = chkDocDate.Checked
    End Sub

    Private Sub btnViewSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnViewSearch.Click
        GridViewBind()
    End Sub
    Private Sub GridViewBind()
        ResetAllSaveContrls()
        Dim objBOL As New WipBOL
        Dim dt As New ObservableCollection(Of WipPPT)
        Dim SearchObjPPT As WipPPT = New WipPPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchStorage.Text.Trim().Length > 0 Then
            SearchObjPPT.WIPStorage = txtSearchStorage.Text.Trim
        End If
        If txtSearchProduct.Text.Trim().Length > 0 Then
            SearchObjPPT.WIPProduct = txtSearchProduct.Text.Trim
        End If
        Try
            dt = New ObservableCollection(Of WipPPT)(objBOL.GetSearchResults(SearchObjPPT))
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

    Private Sub dgvView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvView.CellDoubleClick
        EditViewGridRecord()
    End Sub

    Private Sub EditViewGridRecord()
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    EditSelectedItem()
                End If
            End If
        End If

    End Sub

    Sub EditSelectedItem()
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 And dgvView.SelectedRows.Count > 0 Then
                    Dim currentSearchData As ObservableCollection(Of WipPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    UpdateId = CurrentHeader.ID
                    dtpDate.Text = CurrentHeader.DocDate
                    txtStation.Text = CurrentHeader.WIPStation
                    txtstorage.Text = CurrentHeader.WIPStorage
                    txtclassification.Text = CurrentHeader.WIPClass
                    txtproduct.Text = CurrentHeader.WIPProduct
                    txtQtyCenexDry.Text = CurrentHeader.WIPCenexDry
                    txtQtyCenexWet.Text = CurrentHeader.WIPCenexWet
                    txtQtyDry.Text = CurrentHeader.WIPQtyDry
                    txtDrc.Text = CurrentHeader.WIPDrc
                    TabContainerMain.SelectedTab = TabSave

                End If
            End If
        End If
    End Sub

    Private Sub DeleteViewGridRecord()
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If DeleteToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    Dim currentSearchData As ObservableCollection(Of WipPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    Try
                        WipBOL.DeleteLastWIP(CurrentHeader)
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

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        ResetAllSaveContrls()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class