Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel
Public Class ProductionQcdCenexFrm
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0
    Dim CurrentHeader As New ProductionQcdCenexPPT
    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionQcdCenexFrm))

    Private Sub ProductionQcdCenexFrm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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

    Private Sub btnCat_Click(sender As System.Object, e As System.EventArgs) Handles btnCat.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[CategorySearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtCat.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnTrain_Click(sender As System.Object, e As System.EventArgs) Handles btnTrain.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[TrainSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txttrain.Text = frm.Result(0)
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

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim objLQCNXPPT As New ProductionQcdCenexPPT
        Try
            getObjectFromUI(objLQCNXPPT)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try
        SaveAll(objLQCNXPPT)
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
                If txtCat.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Category")
                Else
                    .QCNXCategory = txtCat.Text.Trim()
                End If

            Catch ex As Exception
                Throw New Exception("Invalid Category")
            End Try

            Try
                If txttrain.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Truck/Train No.")
                Else
                    .QCNXTrain = txttrain.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Truck/Train No.")
            End Try

            Try
                If txtLoadLoc.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Loading Location")
                Else
                    .QCNXLLoc = txtLoadLoc.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Loading Location")
            End Try

            Try
                If txtDestination.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Destination")
                Else
                    .QCNXDes = txtDestination.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Destination")
            End Try

            Try
                .QCNXSe = Decimal.Parse(txtSEDO.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid SI/DO Number")
            End Try

            Try
                .QCNXQty = Decimal.Parse(txtQuantity.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Quantity")
            End Try

            Try
                .QCNXDrc = Decimal.Parse(txtDrcPer.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid DRC %")
            End Try

            Try
                .QCNXTsc = Decimal.Parse(txtTSC.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid TSC %")
            End Try

            Try
                .QCNXNrc = Decimal.Parse(txtNrc.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid NRC %")
            End Try

            Try
                .QCNXNh3 = Decimal.Parse(txtNH3.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid NH3 %")
            End Try

            Try
                .QCNXVfa = Decimal.Parse(txtVFA.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid VFA No.")
            End Try

            Try
                .QCNXMst = Decimal.Parse(txtMST.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid MST Sec")
            End Try

            Try
                .QCNXKoh = Decimal.Parse(txtKOH.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid KOH No.")
            End Try

            Try
                .QCNXMg = Decimal.Parse(txtmgppm.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Mg PPM")
            End Try

        End With
    End Sub

    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtCat.Text = String.Empty
        txttrain.Text = String.Empty
        txtLoadLoc.Text = String.Empty
        txtDestination.Text = String.Empty
        txtSEDO.Text = String.Empty
        txtQuantity.Text = String.Empty
        txtDrcPer.Text = String.Empty
        txtTSC.Text = String.Empty
        txtNrc.Text = String.Empty
        txtNH3.Text = String.Empty
        txtVFA.Text = String.Empty
        txtMST.Text = String.Empty
        txtKOH.Text = String.Empty
        txtmgppm.Text = String.Empty
    End Sub

    Private Sub SaveAll(objLQCNXPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim objLQCNXDAL As New ProductionQcdCenexDAL
        Dim ds As New DataSet
        ProductionQcdCenexDAL.SaveQCNX(objLQCNXPPT)

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
                    Dim currentSearchData As ObservableCollection(Of ProductionQcdCenexPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    UpdateId = CurrentHeader.ID
                    dtpDate.Text = CurrentHeader.DocDate
                    txtCat.Text = CurrentHeader.QCNXCategory
                    txttrain.Text = CurrentHeader.QCNXTrain
                    txtLoadLoc.Text = CurrentHeader.QCNXLLoc
                    txtDestination.Text = CurrentHeader.QCNXDes
                    txtSEDO.Text = CurrentHeader.QCNXSe
                    txtQuantity.Text = CurrentHeader.QCNXQty
                    txtDrcPer.Text = CurrentHeader.QCNXDrc
                    txtTSC.Text = CurrentHeader.QCNXTsc
                    txtNrc.Text = CurrentHeader.QCNXNrc
                    txtNH3.Text = CurrentHeader.QCNXNh3
                    txtVFA.Text = CurrentHeader.QCNXVfa
                    txtMST.Text = CurrentHeader.QCNXMst
                    txtKOH.Text = CurrentHeader.QCNXKoh
                    txtmgppm.Text = CurrentHeader.QCNXMg
                    TabContainerMain.SelectedTab = TabSave

                End If
            End If
        End If


    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteViewGridRecord()
    End Sub

    Private Sub DeleteViewGridRecord()
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If DeleteToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    Dim currentSearchData As ObservableCollection(Of ProductionQcdCenexPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    Try
                        ProductionQcdCenexBOL.DeleteLastQCNX(CurrentHeader)
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
    Private Sub btnViewSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnViewSearch.Click
        GridViewBind()
    End Sub

    Private Sub GridViewBind()
        ResetAllSaveContrls()
        Dim objBOL As New ProductionQcdCenexBOL
        Dim dt As New ObservableCollection(Of ProductionQcdCenexPPT)
        Dim SearchObjPPT As ProductionQcdCenexPPT = New ProductionQcdCenexPPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchTrain.Text.Trim().Length > 0 Then
            SearchObjPPT.QCNXTrain = txtSearchTrain.Text.Trim
        End If
        If txtSearchCat.Text.Trim().Length > 0 Then
            SearchObjPPT.QCNXCategory = txtSearchCat.Text.Trim
        End If
        Try
            dt = New ObservableCollection(Of ProductionQcdCenexPPT)(objBOL.GetSearchResults(SearchObjPPT))
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

    Private Sub chkDocDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDocDate.CheckedChanged
        dtpSearchDocDate.Enabled = chkDocDate.Checked
    End Sub

    Private Sub dgvView_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvView.CellDoubleClick
        EditViewGridRecord()
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        ResetAllSaveContrls()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class