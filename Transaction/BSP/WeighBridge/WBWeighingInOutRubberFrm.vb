Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports WeighBridge_PPT
Imports WeighBridge_DAL
Imports WeighBridge_BOL
Imports System.Collections.ObjectModel
Imports System.Linq


Public Class WBWeighingInOutRubberFrm

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty

    'Used to get whtr this is adding mode or editing mode
    Public btnAddFlag As Boolean = True
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBWeighingInOutRubberFrm))

    Dim CurrentHeader As New WBWeighingInOutRubberPPT

    Private Sub WBWeighingInOutRubberFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        Add()

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

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




    Private Function checkValues() As Boolean

        If (txtVehicleID.Text = String.Empty) Then
            DisplayInfoMessage("Msg01")
            txtVehicleID.Focus()
            Return False
        End If
        Return True

    End Function

    ''' <summary>
    ''' Display message from resource file
    ''' </summary>
    ''' <param name="lsResourceKey"></param>
    ''' <remarks></remarks>
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LocalPuchaseOrderFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSaveAll.Click

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

    Sub getObjectFromUI(objWIORubberPPT)

        With objWIORubberPPT
            Try
                .ID = Decimal.Parse(txtDocID.Text.Trim())
            Catch ex As Exception
                .ID = 0
            End Try

            Try
                .DocDate = dtpDate.Value.Date + TimeOfDay.ToString(" hh:mm:ss tt")
            Catch ex As Exception
                Throw New Exception("Invalid Date")
            End Try

            Try
                If txtTicketNum.Text.Trim() Is "" Then
                    Throw New Exception("Invalid WB Ticket No.")
                Else
                    .WBTicketNo = txtTicketNum.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid WB Ticket No.")
            End Try

            Try
                If txtVehicleID.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Vehicle ID")
                Else
                    .VehicleID = txtVehicleID.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Vehicle ID")
            End Try

            Try
                If txtDiv.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Div")
                Else
                    .DivID = txtDiv.Text.Trim()
                End If
            Catch ex As Exception
                Throw New Exception("Invalid Div")
            End Try

            Try
                If txtEstateID.Text.Trim() Is "" Then
                    Throw New Exception("Invalid Estate")
                Else
                    .EstateID = txtEstateID.Text.Trim()
                End If
                .EstateID = txtEstateID.Text.Trim()
            Catch ex As Exception
                Throw New Exception("Invalid Estate")
            End Try

            Try
                .Wet = Decimal.Parse(txtWet.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Wet")
            End Try

            Try
                .Dry = Decimal.Parse(txtDry.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid Dry")
            End Try

            Try
                .DRCPct = Decimal.Parse(txtDrc.Text.Trim())
            Catch ex As Exception
                Throw New Exception("Invalid DRC")
            End Try

        End With


    End Sub


    Private Sub SaveAll(objWIORubberPPT)
        Try
            WBWeighingInOutRubberBOL.Save(objWIORubberPPT)
            'DisplayInfoMessage("Msg02")
            MessageBox.Show("Saved Successfully", "Important Message")
            ResetAllSaveContrls()
        Catch ex As Exception
            'DisplayInfoMessage("Error: " + ex.Message)
            MessageBox.Show("Error: " + ex.Message, "Important Message")
        End Try
    End Sub


    Private Sub GridViewBind()
        ResetAllSaveContrls()
        Dim objBOL As New WBWeighingInOutRubberBOL
        Dim dt As New ObservableCollection(Of WBWeighingInOutRubberPPT)

        Dim SearchObjPPT As WBWeighingInOutRubberPPT = New WBWeighingInOutRubberPPT

            If txtSearchVehicleID.Text.Trim().Length > 0 Then
            SearchObjPPT.VehicleID = txtSearchVehicleID.Text.Trim
            End If
            If chkDocDate.Checked Then
            SearchObjPPT.DocDate = dtpSearchDocDate.Value
            End If
            If txtSearchWBTcktNum.Text.Trim().Length > 0 Then
            SearchObjPPT.WBTicketNo = txtSearchWBTcktNum.Text.Trim
            End If

            Try
            dt = New ObservableCollection(Of WBWeighingInOutRubberPPT)(objBOL.GetSearchResults(SearchObjPPT))
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
    'If grdname.Rows.Count <> 0 Then

    '    Dim objDataGridViewRow As New DataGridViewRow

    '    For iCount As Integer = 1 To grdname.Rows.Count
    '        grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
    '    Next

    '    If grdname.Rows.Count = 1 Then
    '        grdname.Rows.RemoveAt(0)
    '    End If
    'End If

    'End Sub
    Private Sub btnViewSearch_Click(sender As Object, e As EventArgs) Handles btnViewSearch.Click
        GridViewBind()
    End Sub

    Private Sub chkDocDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkDocDate.CheckedChanged
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

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Add()
    End Sub

    Private Sub Add()
        btnAddFlag = True
        CurrentHeader = New WBWeighingInOutRubberPPT()
        ResetAllSaveContrls()
        Me.TabContainerMain.SelectedTab = tabSave
    End Sub

    Sub ResetAllSaveContrls()
        CurrentHeader = New WBWeighingInOutRubberPPT
        dtpDate.ResetText()
        txtDocID.Text = String.Empty
        txtDiv.Text = String.Empty
        txtDrc.Text = String.Empty
        txtDry.Text = String.Empty
        txtEstateID.Text = String.Empty
        txtVehicleID.Text = String.Empty
        txtWet.Text = String.Empty
        txtTicketNum.Text = String.Empty
    End Sub


    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub

    Sub EditSelectedItem()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 And dgvView.SelectedRows.Count > 0 Then
                    Dim currentSearchData As ObservableCollection(Of WBWeighingInOutRubberPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    dtpDate.Text = CurrentHeader.DocDate
                    txtDocID.Text = CurrentHeader.ID
                    txtDiv.Text = CurrentHeader.DivID
                    txtDrc.Text = CurrentHeader.DRCPct
                    txtDry.Text = CurrentHeader.Dry
                    txtEstateID.Text = CurrentHeader.EstateID
                    txtVehicleID.Text = CurrentHeader.VehicleID
                    txtWet.Text = CurrentHeader.Wet
                    txtTicketNum.Text = CurrentHeader.WBTicketNo
                    TabContainerMain.SelectedTab = tabSave

                End If
            End If
        End If


    End Sub

    Private Sub btnSearchTruck_Click(sender As Object, e As EventArgs) Handles btnSearchTruck.Click
        Dim params(4) As SqlParameter
        params(0) = New SqlParameter("@Category", DBNull.Value)
        params(1) = New SqlParameter("@VHModel", DBNull.Value)
        params(2) = New SqlParameter("@VHWSCode", DBNull.Value)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@Year", GlobalPPT.intLoginYear)

        Dim frm As CommonLookUp = New CommonLookUp("[WeighBridge].[VehicleCodeSearchGET]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtVehicleID.Text = frm.Result(0)
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ResetAllSaveContrls()
    End Sub

    
    Private Sub btnSearchTicketNum_Click(sender As Object, e As EventArgs) Handles btnSearchTicketNum.Click
        Dim params(1) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Dim frm As CommonLookUp = New CommonLookUp("[WeighBridge].[WBTicketNoGET]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtTicketNum.Text = frm.Result(0)
        End If
    End Sub

    Private Sub DeleteSelectedItem()
        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If DeleteToolStripMenuItem.Enabled = True Then
                If dgvView.RowCount > 0 Then
                    Dim currentSearchData As ObservableCollection(Of WBWeighingInOutRubberPPT) = (dgvView.DataSource)
                    CurrentHeader = currentSearchData(dgvView.SelectedRows(0).Index)
                    Try
                        WBWeighingInOutRubberBOL.DeleteLastWIORubber(CurrentHeader)
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

    Private Sub btnSearchEstate_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchEstate.Click
        Dim params(0) As SqlParameter
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim frm As CommonLookUp = New CommonLookUp("[WeighBridge].[WBEstateGET]", params)
        Dim dgResult As DialogResult = frm.ShowDialog
        If (dgResult = Windows.Forms.DialogResult.OK) Then
            txtEstateID.Text = frm.Result(0)
        End If
    End Sub
End Class