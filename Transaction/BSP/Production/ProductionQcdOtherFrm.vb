Imports Common_BOL
Imports Common_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Production_PPT
Imports Production_DAL
Imports Production_BOL
Imports System.Collections.ObjectModel
Imports System.Linq
Public Class ProductionQcdOtherFrm
    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim UpdateId As Decimal = 0

    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionQcdOtherFrm))

    Dim CurrentHeader As New ProductionQcdOtherPPT

    Private Sub ProductionQcdOtherFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnSaveAll_Click_1(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
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

    Sub getObjectFromUI(objQcdOtherPPT)

        With objQcdOtherPPT

            Try
                .DocDate = dtpDate.Value.Date + TimeOfDay.ToString(" hh:mm:ss tt")
            Catch ex As Exception
                Throw New Exception("Invalid Doc Date")
            End Try

            Try
                .CRubber3CV = Decimal.Parse(txtCRubber3CV.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Crumb Rubber SIR 3CV/L DRC")
            End Try

            Try
                .CRubber10VK = Decimal.Parse(txtCRubber10VK.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Crumb Rubber SIR 10/10VK/20/20VK")
            End Try

            Try
                If txtStorage.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Storage RM")
                Else
                    .Storage = txtStorage.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Storage RM")
            End Try

            Try
                .CRubberDRC = Decimal.Parse(txtCRubberDRC.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Crumb Rubber DRC")
            End Try

            Try
                .CenexDRC = Decimal.Parse(txtCenexDRC.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Cenex DRC")
            End Try

            Try
                .Dirt = Decimal.Parse(txtDirt.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Dirt Content")
            End Try

            Try
                .CenexNh3 = Decimal.Parse(txtCenexNh3.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Cenex NH3")
            End Try

            Try
                .Ash = Decimal.Parse(txtAsh.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Ash Content")
            End Try

            Try
                .MG = Decimal.Parse(txtMG.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid MG")
            End Try

            Try
                .BsrDRC = Decimal.Parse(txtBsrDRC.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid BSR DRC")
            End Try

            Try
                .RssDRC = Decimal.Parse(txtRssDRC.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid RSS DRC")
            End Try

            Try
                .BcDRC = Decimal.Parse(txtBcDRC.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Brown Creep DRC")
            End Try

        End With

    End Sub

    Private Sub SaveAll(objQcdOtherPPT)
        Dim rowaffected As Integer = 0
        Dim intResult As Integer = 0
        Dim ds As New DataSet
        Try
            ProductionQcdOtherBOL.Save(objQcdOtherPPT)
            'DisplayInfoMessage("Msg04")
            MessageBox.Show("Saved Successfully", "Important Message")
            ResetAllSaveContrls()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Add()
        btnAddFlag = True
        CurrentHeader = New ProductionQcdOtherPPT()
        ResetAllSaveContrls()
        Me.TabContainerMain.SelectedTab = tabSave
    End Sub

    Sub ResetAllSaveContrls()
        dtpDate.ResetText()
        txtAsh.Text = String.Empty
        txtBcDRC.Text = String.Empty
        txtBsrDRC.Text = String.Empty
        txtCenexDRC.Text = String.Empty
        txtCenexNh3.Text = String.Empty
        txtCRubber10VK.Text = String.Empty
        txtCRubber3CV.Text = String.Empty
        txtCRubberDRC.Text = String.Empty
        txtDirt.Text = String.Empty
        txtMG.Text = String.Empty
        txtRssDRC.Text = String.Empty
        txtStorage.Text = String.Empty
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
                    Dim currentSearchData As ObservableCollection(Of ProductionQcdOtherPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    'txtDocID.Text = CurrentHeader.Id

                    dtpDate.Text = CurrentHeader.DocDate
                    txtCRubber3CV.Text = CurrentHeader.CRubber3CV
                    txtCRubber10VK.Text = CurrentHeader.CRubber10VK
                    txtStorage.Text = CurrentHeader.Storage
                    txtCRubberDRC.Text = CurrentHeader.CRubberDRC
                    txtCenexDRC.Text = CurrentHeader.CenexDRC
                    txtDirt.Text = CurrentHeader.Dirt
                    txtCenexNh3.Text = CurrentHeader.CenexNh3
                    txtAsh.Text = CurrentHeader.Ash
                    txtMG.Text = CurrentHeader.MG
                    txtBsrDRC.Text = CurrentHeader.BsrDRC
                    txtRssDRC.Text = CurrentHeader.RssDRC
                    txtBcDRC.Text = CurrentHeader.BcDRC
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
                    Dim currentSearchData As ObservableCollection(Of ProductionQcdOtherPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    UpdateId = CurrentHeader.Id
                    Try
                        ProductionQcdOtherBOL.DeleteLastQcdOther(CurrentHeader)
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
        Dim objBOL As New ProductionQcdOtherBOL
        Dim dt As New ObservableCollection(Of ProductionQcdOtherPPT)

        Dim SearchObjPPT As ProductionQcdOtherPPT = New ProductionQcdOtherPPT

        If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
        End If
        If txtSearchStorage.Text.Trim().Length > 0 Then
            SearchObjPPT.Storage = txtSearchStorage.Text.Trim
        End If

        Try
            dt = New ObservableCollection(Of ProductionQcdOtherPPT)(objBOL.GetSearchResults(SearchObjPPT))
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
End Class