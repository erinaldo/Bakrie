Imports Vehicle_BOL
Imports Vehicle_PPT
'Imports Vehicle_DAL
Imports Common_PPT
Public Class VehicleRunningLogPostingFrm

#Region "ClassDeclarations"
    Dim _VehicleRunningLogPostingEntity As VehicleRunningLogPostingPPT
    Dim _VehicleRunningLogPostingManager As VehicleRunningLogPostingBOL
    Dim dsVHRLogPosting As DataSet
    'VehicleRunningLogPosting
    'Dim dsNonPostedVehicleLog As DataSet
#End Region

#Region "Events"

    Private Sub VehicleRunningLogPosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Threading.Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture
        Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("en-US")

        SetUICulture(GlobalPPT.strLang)
        LoadNonPostedVehicleRunningLog(String.Empty)
        dgvPostingNonPostedVehicleRunningLog.Columns("LogDate").DefaultCellStyle.Format = "dd/MM/yyyy"
        ' dgvPostingNonPostedVehicleRunningLog.CurrentRow.Selected = False

    End Sub

    

    Private Sub btnPostAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproveAll.Click

        'Which posts all the records
        PostAllOrPostById("Multiple", CDate("01/01/1753"), String.Empty)

        ''Dim dsVHRLogPosting As VehicleRunningLogPostingCollection = dgvPostingNonPostedVehicleRunningLog.DataSource

        Dim dt As DataTable = dgvPostingNonPostedVehicleRunningLog.DataSource
        ''Dim dt As DataTable = New DataTable
        'dt.Columns.Add(New DataColumn("VHWSCode"))
        'dt.Columns.Add(New DataColumn("LogDate"))

        'For count As Integer = 0 To dsVHRLogPosting.Tables(0).Rows.Count - 1
        '    Dim dr As DataRow = dt.NewRow
        '    dr("VHWSCode") = dsVHRLogPosting.Tables(0).Rows(0).Item(count).psVHWSCode
        '    dr("LogDate") = dsVHRLogPosting.Tables(0).Rows(0).Item(count).pdLogDateDT
        '    dt.Rows.Add(dr)
        'Next

        'VHWSCode comes more than onece in the Grid.
        'To insert RunningLog record that are posted
        'So create distinct of VHWSCode and LogDate
        Dim dv As DataView = New DataView(dt)

        Dim VHRunningDetailExternal As DataTable = dv.ToTable("Accounts", True, "VHWSCode", "LogDate")

        For Each row As DataRow In VHRunningDetailExternal.Rows
            SaveOrUpdateVHRunningDetailExternal(row("VHWSCode").ToString(), row("LogDate").ToString)
        Next

        ''For calculating Accounts.JournalDetail and Vehicle.VHRunningDetailExternal
        'For count As Integer = 0 To dsVHRLogPosting.Tables(0).Rows.Count - 1
        '    VehicleProcessingWriteUp(dsVHRLogPosting.Tables(0).Rows(0).Item(count).piId)
        'Next

        'To clear the Grid
        LoadNonPostedVehicleRunningLog("PostAll")

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningLogPostingFrm))
        If MsgBox(rm.GetString("ClosePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Hide()
        End If
    End Sub

    Private Sub dgvPostingNonPostedVehicleRunningLog_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvPostingNonPostedVehicleRunningLog.MouseClick

        dgvPostingNonPostedVehicleRunningLog.CurrentRow.Selected = False

        Dim htIsHeader As DataGridView.HitTestInfo = Me.dgvPostingNonPostedVehicleRunningLog.HitTest(e.X, e.Y)
        If htIsHeader.Type <> DataGridViewHitTestType.Cell Then
            Return
        End If

        If dgvPostingNonPostedVehicleRunningLog.RowCount > 0 Then
            If dgvPostingNonPostedVehicleRunningLog.CurrentRow.Index >= 0 Then
                Select Case dgvPostingNonPostedVehicleRunningLog.Columns(dgvPostingNonPostedVehicleRunningLog.CurrentCell.ColumnIndex).Name

                    Case "Details"
                        'Dim objVehicleRunningLog As New VehicleRunningLogFrm

                        'Dim liID As String = dgvPostingNonPostedVehicleRunningLog.Rows(dgvPostingNonPostedVehicleRunningLog.CurrentRow.Index).Cells("ID").Value()

                        'For Each ChildForm As Form In MdiParent.MdiChildren
                        '    ChildForm.Close()
                        'Next

                        'Dim childVehicle As New VehicleRunningLogFrm()
                        'childVehicle.MdiParent = MdiParent
                        'childVehicle.Dock = DockStyle.Fill

                        'objVehicleRunningLog.Enabled = False
                        'objVehicleRunningLog.tbVehicleRunningLog.SelectedIndex = 0
                        'objVehicleRunningLog.gbListOfVehicleLog.Visible = False

                        'objVehicleRunningLog.ResetControls("EnableControls")
                        'objVehicleRunningLog.ResetControls("Default")
                        'objVehicleRunningLog.ResetControls("Mandatary")
                        'objVehicleRunningLog.ResetControls("VehicleRunningData")
                        'objVehicleRunningLog.ResetControls("BunchesData")
                        'objVehicleRunningLog.ResetControls("ClearGrid")

                        ''Since we are calling the function EditListOfVehicle it changes the text
                        'objVehicleRunningLog.btnSaveOrUpdate.Text = "Save"

                        'objVehicleRunningLog.EditListOfVehicle(Convert.ToInt32(liID))

                        'childVehicle.Show()


                        Dim objVehicleRunningLog As New VehicleRunningLogFrm
                        'Dim objVehicleRunningBatchControl As VehicleControl = New VehicleControl
                        'objVehicleRunningBatchControl.AddControlToChildControlPanel(objVehicleRunningLog)
                        'Me.Parent.Controls(0).Controls.Clear()
                        'Me.Parent.Controls(0).Controls.Add(objVehicleRunningLog)

                        'Dim liID As String = dgvPostingNonPostedVehicleRunningLog.Rows(dgvPostingNonPostedVehicleRunningLog.CurrentRow.Index).Cells("ID").Value()
                        Dim lsVehicleCode As String = dgvPostingNonPostedVehicleRunningLog.Rows(dgvPostingNonPostedVehicleRunningLog.CurrentRow.Index).Cells("VHWSCode").Value()
                        Dim ldtLogDate As DateTime = dgvPostingNonPostedVehicleRunningLog.Rows(dgvPostingNonPostedVehicleRunningLog.CurrentRow.Index).Cells("LogDate").Value()

                        'For Each ChildForm As Form In MdiParent.MdiChildren
                        '    ChildForm.Close()
                        'Next

                        'Dim childVehicle As New VehicleRunningLogFrm()
                        objVehicleRunningLog.MdiParent = MdiParent
                        objVehicleRunningLog.Dock = DockStyle.Fill

                        'objVehicleRunningLog.Enabled = False
                        'objVehicleRunningLog.tbVehicleRunningLog.SelectTab(0)
                        objVehicleRunningLog.tbVehicleRunningLog.TabPages.Remove(objVehicleRunningLog.tpViewVRL)
                        'objVehicleRunningLog.gbListOfVehicleLog.Visible = False

                        objVehicleRunningLog.ResetControls("EnableControls")
                        objVehicleRunningLog.ResetControls("Default")
                        objVehicleRunningLog.ResetControls("Mandatary")
                        objVehicleRunningLog.ResetControls("VehicleRunningData")
                        objVehicleRunningLog.ResetControls("BunchesData")
                        objVehicleRunningLog.ResetControls("ClearGrid")

                        'Since we are calling the function EditListOfVehicle it changes the text
                        objVehicleRunningLog.btnSaveOrUpdate.Text = "Save"

                        'objVehicleRunningLog.EditListOfVehicle(Convert.ToInt32(liID))
                        objVehicleRunningLog.ShowRunningDetailsByVehicleCodeAndDate(lsVehicleCode, ldtLogDate)

                        'objVehicleRunningLog.btnClose.Enabled = True

                        'objVehicleRunningLog.grpDefault.Enabled = False
                        'objVehicleRunningLog.gbVehicleRunningData.Enabled = False
                        'objVehicleRunningLog.gbBunchesData.Enabled = False

                        objVehicleRunningLog.pnlEntryArea.Enabled = False

                        objVehicleRunningLog.btnPrintFFBDO.Enabled = False

                        objVehicleRunningLog.btnReset.Enabled = False
                        objVehicleRunningLog.txtRemarks.Enabled = False
                        objVehicleRunningLog.lblRemarks.Enabled = False
                        ' objVehicleRunningLog.Label22.Enabled = False

                        objVehicleRunningLog.Show()

                        objVehicleRunningLog.btnReset.Enabled = False
                        objVehicleRunningLog.btnSaveOrUpdate.Enabled = False

                    Case "Post"

                        PostAllOrPostById("Single", CDate(dgvPostingNonPostedVehicleRunningLog.Rows(dgvPostingNonPostedVehicleRunningLog.CurrentRow.Index).Cells("LogDate").Value), dgvPostingNonPostedVehicleRunningLog.Rows(dgvPostingNonPostedVehicleRunningLog.CurrentRow.Index).Cells("VHWSCode").Value)

                        Dim lsVHWSCode As String = dgvPostingNonPostedVehicleRunningLog.Rows(dgvPostingNonPostedVehicleRunningLog.CurrentRow.Index).Cells("VHWSCode").Value
                        Dim lsLogDate As Date = dgvPostingNonPostedVehicleRunningLog.Rows(dgvPostingNonPostedVehicleRunningLog.CurrentRow.Index).Cells("LogDate").Value

                        SaveOrUpdateVHRunningDetailExternal(lsVHWSCode, lsLogDate)
                        'VehicleProcessingWriteUp(Convert.ToInt32(dgvPostingNonPostedVehicleRunningLog.Rows(dgvPostingNonPostedVehicleRunningLog.CurrentRow.Index).Cells("Id").Value))
                        LoadNonPostedVehicleRunningLog("Posted")

                End Select
            End If
        End If

    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvPostingNonPostedVehicleRunningLog.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

#End Region

#Region "Function"

    Private Sub PostAllOrPostById(ByVal lsPostBy As String, ByVal LogDate As DateTime, ByVal VHWSCode As String)

        _VehicleRunningLogPostingEntity = New VehicleRunningLogPostingPPT
        _VehicleRunningLogPostingManager = New VehicleRunningLogPostingBOL

        '  _VehicleRunningLogPostingEntity.psEstateID = GlobalVar.psEstateID
        ' _VehicleRunningLogPostingEntity.psActiveMonthYearID = GlobalVar.psActiveMonthYearID
        _VehicleRunningLogPostingEntity.psPostingType = lsPostBy
        _VehicleRunningLogPostingEntity.pdLogDateDT = LogDate
        _VehicleRunningLogPostingEntity.psVHWSCode = VHWSCode

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningLogPostingFrm))

        Select Case lsPostBy
            Case "Single"
                '_VehicleRunningLogPostingEntity.piId = liId
                If MsgBox(rm.GetString("PromptApproval"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    If _VehicleRunningLogPostingManager.PostByIdOrPostAll(_VehicleRunningLogPostingEntity) = 6 Then
                        MsgBox(rm.GetString("MsgApproved"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Message")
                    End If
                End If
            Case "Multiple"
                If MsgBox(rm.GetString("PromptAllApproval"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    If _VehicleRunningLogPostingManager.PostByIdOrPostAll(_VehicleRunningLogPostingEntity) = 7 Then
                        MsgBox(rm.GetString("MsgApproved"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Message")
                    End If
                End If
        End Select

        'This SP also insert or update in Loging table



    End Sub

    Private Sub SaveOrUpdateVHRunningDetailExternal(ByVal lsVHWSCode As String, ByVal ldLogDate As Date)

        _VehicleRunningLogPostingEntity = New VehicleRunningLogPostingPPT
        _VehicleRunningLogPostingManager = New VehicleRunningLogPostingBOL

        _VehicleRunningLogPostingEntity.psVHWSCode = lsVHWSCode
        _VehicleRunningLogPostingEntity.pdLogDateDT = ldLogDate
        '_VehicleRunningLogPostingEntity.psEstateID = GlobalVar.psEstateID()
        '_VehicleRunningLogPostingEntity.psActiveMonthYearID = GlobalVar.psActiveMonthYearID
        '_VehicleRunningLogPostingEntity.CreatedBy = GlobalVar.psCreatedBy




        '''''_VehicleRunningLogPostingManager.SaveOrUpdateVHRunningDetailExternal(_VehicleRunningLogPostingEntity)

    End Sub

    Private Sub LoadNonPostedVehicleRunningLog(ByVal lsSender As String)
        _VehicleRunningLogPostingEntity = New VehicleRunningLogPostingPPT
        _VehicleRunningLogPostingManager = New VehicleRunningLogPostingBOL

        _VehicleRunningLogPostingEntity.psEstateID = GlobalPPT.strEstateID
        _VehicleRunningLogPostingEntity.psActiveMonthYearID = GlobalPPT.strActMthYearID

        dsVHRLogPosting = _VehicleRunningLogPostingManager.NonPostedVehicleRunningLogGet(_VehicleRunningLogPostingEntity)

        With dgvPostingNonPostedVehicleRunningLog
            .AutoGenerateColumns = False
            .DataSource = dsVHRLogPosting.Tables(0)
        End With

        'dgvPostingNonPostedVehicleRunningLog.CurrentRow.Selected = False

        If dsVHRLogPosting Is Nothing Or dsVHRLogPosting.Tables(0).Rows.Count <= 0 Then
            btnApproveAll.Enabled = False
        End If

        'If dsVHRLogPosting Is Nothing And lsSender = String.Empty Then
        '    MsgBox("'All of vehicle running log records were posted. None remaining to be posted.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
        'End If

    End Sub

    Private Sub VehicleProcessingWriteUp(ByVal ldId As Integer)
        _VehicleRunningLogPostingEntity = New VehicleRunningLogPostingPPT
        _VehicleRunningLogPostingManager = New VehicleRunningLogPostingBOL

        _VehicleRunningLogPostingEntity.piId = ldId
        '_VehicleRunningLogPostingEntity.CreatedBy = GlobalVar.psCreatedBy
        _VehicleRunningLogPostingManager.VehicleProcessingWriteUp(_VehicleRunningLogPostingEntity)

    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningLogPostingFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'Button
            btnApproveAll.Text = rm.GetString("btnApproveAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")

            'label
            lblApproveMessage.Text = rm.GetString("lblApproveMessage.Text")
            lblApprovalMsg1.Text = rm.GetString("lblApproveMessage1")

            'GridView
            dgvPostingNonPostedVehicleRunningLog.Columns("LogDate").HeaderText = rm.GetString("dgvPostingNonPostedVehicleRunningLog.Columns(LogDate).HeaderText")
            dgvPostingNonPostedVehicleRunningLog.Columns("VHWSCode").HeaderText = rm.GetString("dgvPostingNonPostedVehicleRunningLog.Columns(VHWSCode).HeaderText")
            dgvPostingNonPostedVehicleRunningLog.Columns("TotalHrsOrKm").HeaderText = rm.GetString("dgvPostingNonPostedVehicleRunningLog.Columns(TotalHrsOrKm).HeaderText")
            dgvPostingNonPostedVehicleRunningLog.Columns("Details").HeaderText = rm.GetString("dgvPostidgvPostingNonPostedVehicleRunningLog.Columns(Details).HeaderText")
            dgvPostingNonPostedVehicleRunningLog.Columns("Post").HeaderText = rm.GetString("dgvPostingNonPostedVehicleRunningLog.Columns(Post).HeaderText")
            Post.Text = rm.GetString("Approve")
            'dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item("Approvel").Value= ""
            '  For Each DataGridViewRow In dgvPostingNonPostedVehicleDistribution.Rows
            'DataGridViewRow.Cells("Approvel").Value.ToString()
            'Next
            'dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item("Approvel").Value = rm.GetString("dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item(Approvel).Value")
            cmsVehicleRunningLogPosting.Items.Item(0).Text = rm.GetString("cmsVehicleRunningLogPosting.Items.Item(0).Text")
            cmsVehicleRunningLogPosting.Items.Item(1).Text = rm.GetString("cmsVehicleRunningLogPosting.Items.Item(1).Text")
            cmsVehicleRunningLogPosting.Items.Item(2).Text = rm.GetString("cmsVehicleRunningLogPosting.Items.Item(2).Text")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class