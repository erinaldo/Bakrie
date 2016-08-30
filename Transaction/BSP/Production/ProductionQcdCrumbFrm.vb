Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel
Public Class ProductionQcdCrumbFrm
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0
    Dim CurrentHeader As New ProductionQcdCrumbPPT
    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionQcdCrumbFrm))

    Private Sub ProductionQcdCrumbFrm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
    Private Sub DeleteViewGridRecord()
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If DeleteToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionQcdCrumbPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    Try
                        ProductionQcdCrumbBOL.DeleteLastQCRM(CurrentHeader)
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
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim objLQCMBPPT As New ProductionQcdCrumbPPT
        Try
            getObjectFromUI(objLQCMBPPT)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
        SaveAll(objLQCMBPPT)
        'DisplayInfoMessage("Msg02")
        MessageBox.Show("Saved Successfully", "Important Message")
        ResetAllSaveContrls()
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Sub getObjectFromUI(objLQCMBPPT)

        With objLQCMBPPT
            Try
                .ID = UpdateId
            Catch ex As Exception
                .ID = 0
            End Try

            Try
                .DocDate = dtpDate.Value
            Catch ex As Exception
                Throw New Exception("Invalid Date")
            End Try

            Try
                If txtCategory.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Category")
                Else
                    .QCRMCategory = txtCategory.Text.Trim()
                End If

            Catch ex As Exception
                Throw New Exception("Invalid Category")
            End Try

            Try
                If txtProduct.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Product Type")
                Else
                    .QCRMProduct = txtProduct.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Product Type")
            End Try

            Try
                If txtStorage.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Storage RM")
                Else
                    .QCRMStorage = txtStorage.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Storage RM")
            End Try

            Try
                If txtgrade.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Grade")
                Else
                    .QCRMGrade = txtgrade.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Grade")
            End Try

            Try
                If txtDoNumber.Text.Trim() Is "" Then
                    Throw New Exception("Invalid SI/Do No.")
                Else
                    .QCRMDoNum = txtDoNumber.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid SI/Do No.")
            End Try

            Try
                If txtLoadLoc.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Loading Location")
                Else
                    .QCRMLLoc = txtLoadLoc.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Loading Location")
            End Try

            Try
                If txtVehicleNumber.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Vehicle No.")
                Else
                    .QCRMVnum = txtVehicleNumber.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Vehicle No.")
            End Try

            'Try
            '    If txtNoPallet.Text.Trim() Is "" Then
            '        Throw New Exception("Invalid Pallet Code")
            '    Else
            '        .QCRMNoP = txtNoPallet.Text.Trim()
            '    End If
            'Catch ex As Exception
            '    Throw New Exception("Invalid Pallet Code")
            'End Try

            'Try
            '    If txtNoLot.Text.Trim() Is "" Then
            '        Throw New Exception("Invalid Lot Code")
            '    Else
            '        .QCRMNoL = txtNoLot.Text.Trim()
            '    End If
            'Catch ex As Exception
            '    Throw New Exception("Invalid Lot Code")
            'End Try

            'Try
            '    If txtDest.Text.Trim() Is "" Then
            '        Throw New Exception("Invalid Destination")
            '    Else
            '        .QCRMDes = txtDest.Text.Trim()
            '    End If
            'Catch ex As Exception
            '    Throw New Exception("Invalid Destination")
            'End Try

            Try
                .QCRMNoP = Decimal.Parse(txtNoPallet.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid No Code Pallet")
            End Try

            Try
                .QCRMNoL = Decimal.Parse(txtNoLot.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid No Code Lot")
            End Try

            Try
                .QCRMDes = Decimal.Parse(txtDest.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Destination")
            End Try

            Try
                .QCRMMwt = Decimal.Parse(txtMillWeight.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Mill Weight")
            End Try

            Try
                .QCRMP3 = Decimal.Parse(txtP30.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid P30")
            End Try

            Try
                .QCRMDC = Decimal.Parse(txtDirtContent.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Dirt Content")
            End Try

            Try
                .QCRMPO = Decimal.Parse(txtPO.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid PO")
            End Try

            Try
                .QCRMPri = Decimal.Parse(txtPri.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid PRI")
            End Try

            Try
                .QCRMV = Decimal.Parse(txtMooneyViscosity.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Mooney Viscosity")
            End Try

            Try
                .QCRMVM = Decimal.Parse(txtVolatileMater.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Volatile Mater")
            End Try

            Try
                .QCRMNC = Decimal.Parse(txtNitrogenContent.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Nitrogen Content")
            End Try

            Try
                .QCRMLC = Decimal.Parse(txtLc.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Lovibond Color")
            End Try

            Try
                .QCRMAC = Decimal.Parse(txtAshContent.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Ash Content")
            End Try
        End With
    End Sub
    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtCategory.Text = String.Empty
        txtProduct.Text = String.Empty
        txtStorage.Text = String.Empty
        txtgrade.Text = String.Empty
        txtDoNumber.Text = String.Empty
        txtLoadLoc.Text = String.Empty
        txtVehicleNumber.Text = String.Empty
        txtNoPallet.Text = String.Empty
        txtNoLot.Text = String.Empty
        txtDest.Text = String.Empty
        txtMillWeight.Text = String.Empty
        txtP30.Text = String.Empty
        txtDirtContent.Text = String.Empty
        txtPO.Text = String.Empty
        txtPri.Text = String.Empty
        txtMooneyViscosity.Text = String.Empty
        txtVolatileMater.Text = String.Empty
        txtNitrogenContent.Text = String.Empty
        txtLc.Text = String.Empty
        txtAshContent.Text = String.Empty
    End Sub

    Private Sub SaveAll(objLQCMBPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim objLQCRMDAL As New ProductionQcdCrumbDAL
        Dim ds As New DataSet
        ProductionQcdCrumbDAL.SaveQCRM(objLQCMBPPT)

    End Sub
    Private Sub btnCat_Click(sender As System.Object, e As System.EventArgs) Handles btnCat.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@form", "QCD Crumb Rubber")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[CategorySearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtCategory.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnProd_Click(sender As System.Object, e As System.EventArgs) Handles btnProd.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@form", "QCD Crumb Rubber")
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductCodeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtProduct.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnStor_Click(sender As System.Object, e As System.EventArgs) Handles btnStor.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[StorageTankSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtStorage.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnLoadLoc_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadLoc.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[LoadLocSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtLoadLoc.Text = frm.Result(0)
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
        Dim objBOL As New ProductionQcdCrumbBOL
        Dim dt As New ObservableCollection(Of ProductionQcdCrumbPPT)
        Dim SearchObjPPT As ProductionQcdCrumbPPT = New ProductionQcdCrumbPPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchSource.Text.Trim().Length > 0 Then
            SearchObjPPT.QCRMStorage = txtSearchSource.Text.Trim
        End If
        If txtSearchType.Text.Trim().Length > 0 Then
            SearchObjPPT.QCRMProduct = txtSearchType.Text.Trim
        End If
        Try
            dt = New ObservableCollection(Of ProductionQcdCrumbPPT)(objBOL.GetSearchResults(SearchObjPPT))
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
                    Dim currentSearchData As ObservableCollection(Of ProductionQcdCrumbPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    UpdateId = CurrentHeader.ID
                    dtpDate.Text = CurrentHeader.DocDate
                    txtCategory.Text = CurrentHeader.QCRMCategory
                    txtProduct.Text = CurrentHeader.QCRMProduct
                    txtStorage.Text = CurrentHeader.QCRMStorage
                    txtgrade.Text = CurrentHeader.QCRMGrade
                    txtDoNumber.Text = CurrentHeader.QCRMDoNum
                    txtLoadLoc.Text = CurrentHeader.QCRMLLoc
                    txtVehicleNumber.Text = CurrentHeader.QCRMVnum
                    txtNoPallet.Text = CurrentHeader.QCRMNoP
                    txtNoLot.Text = CurrentHeader.QCRMNoL
                    txtDest.Text = CurrentHeader.QCRMDes
                    txtMillWeight.Text = CurrentHeader.QCRMMwt
                    txtP30.Text = CurrentHeader.QCRMP3
                    txtDirtContent.Text = CurrentHeader.QCRMDC
                    txtPO.Text = CurrentHeader.QCRMPO
                    txtPri.Text = CurrentHeader.QCRMPri
                    txtMooneyViscosity.Text = CurrentHeader.QCRMV
                    txtVolatileMater.Text = CurrentHeader.QCRMVM
                    txtNitrogenContent.Text = CurrentHeader.QCRMNC
                    txtLc.Text = CurrentHeader.QCRMLC
                    txtAshContent.Text = CurrentHeader.QCRMAC
                    TabContainerMain.SelectedTab = TabSave

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

    Private Sub txtP30_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtP30.TextChanged
        pricalc()
    End Sub

    Private Sub txtPO_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPO.TextChanged
        pricalc()
    End Sub

    Private Sub pricalc()
        If txtP30.Text <> "" And txtPO.Text <> "" Then
            Dim p30 As Decimal
            Dim po As Decimal
            Dim pri As Decimal
            p30 = Decimal.Parse(txtP30.Text.Trim())
            po = Decimal.Parse(txtPO.Text.Trim())
            pri = (p30 / po) * 100
            txtPri.Text = pri
        Else
            txtPri.Text = String.Empty
        End If
    End Sub

    Private Sub btngrad_Click(sender As System.Object, e As System.EventArgs) Handles btngrad.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[GradeSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtgrade.Text = frm.Result(0)
        End If
    End Sub
End Class