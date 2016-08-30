Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel
Public Class ProductionOffgradeFrm
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0

    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionOffgradeFrm))
    Dim CurrentHeader As New OffgradePPT

    Private Sub ProductionOffgradeFrm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

        SetUICulture(GlobalPPT.strLang)
        TabContainerMain.SelectedTab = TabSearch
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Add()
        ResetAllSaveContrls()
    End Sub
    Sub Add()
        Me.TabContainerMain.SelectedTab = TabSave
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteSelectedItem()

        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
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

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim objOGPPT As New OffgradePPT

        Try
            getObjectFromUI(objOGPPT)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
        Try
            SaveAll(objOGPPT)
            MessageBox.Show("Saved Successfully", "Important Message")
            ResetAllSaveContrls()
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Important Message")
        End Try

        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub
    Sub getObjectFromUI(objOGPPT)

        With objOGPPT
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
                If txtContract.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Contract No.")
                Else
                    .OGContract = txtContract.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Contract No.")
            End Try

            Try
                If txtCustomer.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Customer")
                Else
                    .OGCust = txtCustomer.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Customer")
            End Try

            Try
                If txtDeliveryOrderNo.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Delivery Order No.")
                Else
                    .OGDo = txtDeliveryOrderNo.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Delivery Order")
            End Try

            Try
                If txtIdTruck.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Truck Id")
                Else
                    .OGTruckId = txtIdTruck.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Truck Id")
            End Try

            Try
                If txtstorage.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Storage RM")
                Else
                    .OGStorage = txtstorage.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Storage RM")
            End Try

            Try
                If txtprod.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Product Type")
                Else
                    .OGProduct = txtprod.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Product Type")
            End Try

            Try
                .OGWet = Decimal.Parse(txtWet.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Wet")
            End Try

            Try
                .OGDry = Decimal.Parse(txtDry.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Dry")
            End Try

            Try
                .OGDrc = Decimal.Parse(txtDrc.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid DRC")
            End Try

        End With


    End Sub
    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtContract.Text = String.Empty
        txtCustomer.Text = String.Empty
        txtDeliveryOrderNo.Text = String.Empty
        txtIdTruck.Text = String.Empty
        txtstorage.Text = String.Empty
        txtprod.Text = String.Empty
        txtWet.Text = String.Empty
        txtDry.Text = String.Empty
        txtDrc.Text = String.Empty
    End Sub

    Private Sub SaveAll(objOGPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim objOGDAL As New OffgradeDAL
        Dim ds As New DataSet
        OffgradeDAL.SaveOG(objOGPPT)

    End Sub

    Private Sub btnStorage_Click(sender As System.Object, e As System.EventArgs) Handles btnStorage.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Form", "Sales Offgrade")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StorageTankSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtstorage.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnprod_Click(sender As System.Object, e As System.EventArgs) Handles btnprod.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Form", "Sales Offgrade")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductCodeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtprod.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        ResetAllSaveContrls()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkDocDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDocDate.CheckedChanged
        dtpSearchDocDate.Enabled = chkDocDate.Checked
    End Sub

    Private Sub btnViewSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnViewSearch.Click
        GridViewBind()
    End Sub

    Private Sub GridViewBind()
        ResetAllSaveContrls()
        Dim objBOL As New OffgradeBOL
        Dim dt As New ObservableCollection(Of OffgradePPT)
        Dim SearchObjPPT As OffgradePPT = New OffgradePPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchSource.Text.Trim().Length > 0 Then
            SearchObjPPT.OGStorage = txtSearchSource.Text.Trim
        End If
        If txtSearchType.Text.Trim().Length > 0 Then
            SearchObjPPT.OGProduct = txtSearchType.Text.Trim
        End If
        Try
            dt = New ObservableCollection(Of OffgradePPT)(objBOL.GetSearchResults(SearchObjPPT))
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
                    Dim currentSearchData As ObservableCollection(Of OffgradePPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    UpdateId = CurrentHeader.ID
                    dtpDate.Text = CurrentHeader.DocDate
                    txtContract.Text = CurrentHeader.OGContract
                    txtCustomer.Text = CurrentHeader.OGCust
                    txtDeliveryOrderNo.Text = CurrentHeader.OGDo
                    txtIdTruck.Text = CurrentHeader.OGTruckId
                    txtstorage.Text = CurrentHeader.OGStorage
                    txtprod.Text = CurrentHeader.OGProduct
                    txtWet.Text = CurrentHeader.OGWet
                    txtDry.Text = CurrentHeader.OGDry
                    txtDrc.Text = CurrentHeader.OGDrc
                    TabContainerMain.SelectedTab = TabSave

                End If
            End If
        End If


    End Sub

    Private Sub dgvView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvView.CellDoubleClick
        EditViewGridRecord()
    End Sub

    Private Sub DeleteSelectedItem()
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If DeleteToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    Dim currentSearchData As ObservableCollection(Of OffgradePPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    Try
                        OffgradeBOL.DeleteLastOG(CurrentHeader)
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
End Class