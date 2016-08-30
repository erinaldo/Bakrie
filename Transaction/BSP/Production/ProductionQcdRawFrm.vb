Imports Common_BOL
Imports Common_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel
Imports System.Linq
Public Class ProductionQcdRawFrm
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0

    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionQcdRawFrm))

    Dim CurrentHeader As New ProductionQcdRawPPT

    Private Sub ProductionQcdRawFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Sub getObjectFromUI(objQcdRawPPT)

        With objQcdRawPPT

            Try
                .DocDate = dtpDate.Value.Date + TimeOfDay.ToString(" hh:mm:ss tt")
            Catch ex As Exception
                Throw New Exception("Invalid Date")
            End Try

            Try
                If txtTicket.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Ticket No.")
                Else
                    .TicketNo = txtTicket.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Ticket No.")
            End Try

            Try
                If txtEstate.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Estate")
                Else
                    .Estate = txtEstate.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Estate")
            End Try

            Try
                If txtCarNo.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Car No.")
                Else
                    .CarNo = txtCarNo.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Car No.")
            End Try

            Try
                If txtDivision.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Division")
                Else
                    .Division = txtDivision.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Division")
            End Try

            Try
                If txtRawMaterial.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Raw Material Type")
                Else
                    .RawMaterial = txtRawMaterial.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Raw Material Type")
            End Try

            Try
                .QtyEstate = Decimal.Parse(txtQtyEstate.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Quantity (Estate)")
            End Try

            Try
                .QtyFactory = Decimal.Parse(txtQtyFactory.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Quantity (Factory)")
            End Try

            Try
                .Drc1 = Decimal.Parse(txtDrc1.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid DRC % (INDV RT1)")
            End Try

            Try
                .Drc2 = Decimal.Parse(txtDrc2.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid DRC % (INDV RT2)")
            End Try

            Try
                .Drc3 = Decimal.Parse(txtDrc3.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid DRC % (INDV RT3)")
            End Try

            Try
                .DrcCar = Decimal.Parse(txtDrcNgrr.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid DRC % (CAR)")
            End Try

            Try
                .Nh31 = Decimal.Parse(txtNh31.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid NH3 % (INDV RT1)")
            End Try

            Try
                .Nh32 = Decimal.Parse(txtNh32.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid NH3 % (INDV RT2)")
            End Try

            Try
                .Nh33 = Decimal.Parse(txtNh33.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid NH3 % (INDV RT3)")
            End Try

            Try
                .Nh3Car = Decimal.Parse(txtNh3Ngrr.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid NH3 % (CAR)")
            End Try

            Try
                .Nh3Estate = Decimal.Parse(txtNh3Estate.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid NH3 % (Mix RT Estate)")
            End Try

            Try
                .DrcEstate = Decimal.Parse(txtDrcEstate.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid DRC % (Mix RT Estate)")
            End Try

            Try
                .VfaNo = Decimal.Parse(txtVfaNo.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid VFA No")
            End Try

            Try
                .Dirt = Decimal.Parse(txtDirt.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Dirt Content")
            End Try

            Try
                .Ash = Decimal.Parse(txtAsh.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Ash Content")
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

    Private Sub SaveAll(objQcdRawPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim ds As New DataSet
        Try
            ProductionQcdRawBOL.Save(objQcdRawPPT)
            'DisplayInfoMessage("Msg04")
            MessageBox.Show("Saved Successfully", "Important Message")
            ResetAllSaveContrls()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Add()
        btnAddFlag = True
        CurrentHeader = New ProductionQcdRawPPT()
        ResetAllSaveContrls()
        Me.TabContainerMain.SelectedTab = tabSave
    End Sub

    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtTicket.Text = String.Empty
        txtEstate.Text = String.Empty
        txtCarNo.Text = String.Empty
        txtDivision.Text = String.Empty
        txtRawMaterial.Text = String.Empty
        txtAsh.Text = String.Empty
        txtDirt.Text = String.Empty
        txtDrc1.Text = String.Empty
        txtDrc2.Text = String.Empty
        txtDrc3.Text = String.Empty
        txtNh3Estate.Text = String.Empty
        txtDrcNgrr.Text = String.Empty
        txtNh31.Text = String.Empty
        txtNh32.Text = String.Empty
        txtNh33.Text = String.Empty
        txtNh3Ngrr.Text = String.Empty
        txtQtyEstate.Text = String.Empty
        txtQtyFactory.Text = String.Empty
        txtRemarks.Text = String.Empty
        txtVfaNo.Text = String.Empty
        txtDrcEstate.Text = String.Empty
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
                    Dim currentSearchData As ObservableCollection(Of ProductionQcdRawPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    'txtDocID.Text = CurrentHeader.Id

                    dtpDate.Text = CurrentHeader.DocDate
                    txtTicket.Text = CurrentHeader.TicketNo
                    txtEstate.Text = CurrentHeader.Estate
                    txtCarNo.Text = CurrentHeader.CarNo
                    txtDivision.Text = CurrentHeader.Division
                    txtRawMaterial.Text = CurrentHeader.RawMaterial
                    txtAsh.Text = CurrentHeader.Ash
                    txtDirt.Text = CurrentHeader.Dirt
                    txtDrc1.Text = CurrentHeader.Drc1
                    txtDrc2.Text = CurrentHeader.Drc2
                    txtDrc3.Text = CurrentHeader.Drc3
                    txtNh3Estate.Text = CurrentHeader.Nh3Estate
                    txtDrcEstate.Text = CurrentHeader.DrcEstate
                    txtDrcNgrr.Text = CurrentHeader.DrcCar
                    txtNh31.Text = CurrentHeader.Nh31
                    txtNh32.Text = CurrentHeader.Nh32
                    txtNh33.Text = CurrentHeader.Nh33
                    txtNh3Ngrr.Text = CurrentHeader.Nh3Car
                    txtQtyEstate.Text = CurrentHeader.QtyEstate
                    txtQtyFactory.Text = CurrentHeader.QtyFactory
                    txtRemarks.Text = CurrentHeader.Remarks
                    txtVfaNo.Text = CurrentHeader.VfaNo
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
                    Dim currentSearchData As ObservableCollection(Of ProductionQcdRawPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    UpdateId = CurrentHeader.Id
                    Try
                        ProductionQcdRawBOL.DeleteLastQcdRaw(CurrentHeader)
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
        Dim objBOL As New ProductionQcdRawBOL
        Dim dt As New ObservableCollection(Of ProductionQcdRawPPT)

        Dim SearchObjPPT As ProductionQcdRawPPT = New ProductionQcdRawPPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchTicket.Text.Trim().Length > 0 Then
            SearchObjPPT.TicketNo = txtSearchTicket.Text.Trim
        End If
        If txtSearchEstate.Text.Trim().Length > 0 Then
            SearchObjPPT.Estate = txtSearchEstate.Text.Trim
        End If

        Try
            dt = New ObservableCollection(Of ProductionQcdRawPPT)(objBOL.GetSearchResults(SearchObjPPT))
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

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnTicket_Click(sender As System.Object, e As System.EventArgs) Handles btnTicket.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[ProductTicketSearchGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtTicket.Text = frm.Result(0)
            'txtEstate.Text = frm.Result(1)
        End If
    End Sub

    Private Sub btnestate_Click(sender As System.Object, e As System.EventArgs) Handles btnestate.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[WeighBridge].[WBEstateGET]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtEstate.Text = frm.Result(0)
        End If
    End Sub

    Private Sub btnraw_Click(sender As System.Object, e As System.EventArgs) Handles btnraw.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[Production].[RAWGet]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtRawMaterial.Text = frm.Result(0)
        End If
    End Sub
End Class