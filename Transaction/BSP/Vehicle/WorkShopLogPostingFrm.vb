Imports Vehicle_BOL
Imports Vehicle_PPT
'Imports Vehicle_DAL
Imports Common_PPT
Public Class WorkShopLogPostingFrm

    Dim _WorkshopLogPostingEntity As WorkshopLogPostingPPT
    Dim _WorkshopLogPostingManager As WorkshopLogPostingBOL
    Dim dsWorkshopLogPosting As DataSet

#Region "Events"
    Private Sub WorkshopLogPosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Threading.Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture
        Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("en-US")

        SetUICulture(GlobalPPT.strLang)
        LoadNonPostedWorkshopLog()
        dgvPostingNonPostedWorkshopLog.Columns("LogDate").DefaultCellStyle.Format = "dd/MM/yyyy"
    End Sub

    Private Sub btnPostAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproveAll.Click
        PostAllOrPostById("Multiple", 0, String.Empty, DateTime.Now)
        LoadNonPostedWorkshopLog()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WorkShopLogPostingFrm))

        If MsgBox(rm.GetString("ClosePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Hide()
        End If
    End Sub

    Private Sub dgvPostingNonPostedWorkshopLog_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPostingNonPostedWorkshopLog.CellContentClick
        If dgvPostingNonPostedWorkshopLog.CurrentRow IsNot Nothing Then
            If dgvPostingNonPostedWorkshopLog.CurrentRow.Index >= 0 Then
                ' find out which column was clicked
                Select Case dgvPostingNonPostedWorkshopLog.Columns(e.ColumnIndex).Name
                    Case "Details"
                        Dim _WorkshopLog As New WorkShopLogFrm
                        Dim liID As String = dgvPostingNonPostedWorkshopLog.Rows(e.RowIndex).Cells("Id").Value
                        _WorkshopLog.SetUICulture(GlobalPPT.strLang)
                        _WorkshopLog.MdiParent = MdiParent
                        _WorkshopLog.Dock = DockStyle.Fill

                        _WorkshopLog.gbWorkshopLog.Enabled = False
                        _WorkshopLog.btnPrint.Enabled = False
                        _WorkshopLog.btnReset.Enabled = False
                        _WorkshopLog.tbcWorkshop.SelectTab(0)
                        _WorkshopLog.ShowWorkshopDetailsByID(Convert.ToInt32(liID))
                        _WorkshopLog.tbcWorkshop.TabPages.Remove(_WorkshopLog.tpViewVRL)
                        _WorkshopLog.gbListOfWorkshopLog.Visible = False
                        _WorkshopLog.btnClose.Enabled = True
                        _WorkshopLog.gbAddReset.Enabled = True

                        _WorkshopLog.Show()
                        _WorkshopLog.btnReset.Enabled = False
                        _WorkshopLog.btnSaveOrUpdate.Enabled = False

                    Case "Post"
                        'PostAllOrPostById("Single", CDate(dgvPostingNonPostedWorkshopLog.Rows(dgvPostingNonPostedWorkshopLog.CurrentRow.Index).Cells("LogDate").Value), dgvPostingNonPostedWorkshopLog.Rows(dgvPostingNonPostedWorkshopLog.CurrentRow.Index).Cells("VHWSCode").Value)

                        'Dim lsWorkVHID As String = dgvPostingNonPostedWorkshopLog.Rows(dgvPostingNonPostedWorkshopLog.CurrentRow.Index).Cells("WorkVHID").Value
                        ' Dim lsLogDate As Date = dgvPostingNonPostedWorkshopLog.Rows(dgvPostingNonPostedWorkshopLog.CurrentRow.Index).Cells("LogDate").Value

                        'SaveOrUpdateVHRunningDetailExternal(lsVHWSCode, lsLogDate)
                        PostAllOrPostById("Single", Convert.ToInt32(dgvPostingNonPostedWorkshopLog.Rows(e.RowIndex).Cells("Id").Value), Convert.ToString(dgvPostingNonPostedWorkshopLog.Rows(e.RowIndex).Cells("WorkshopNo").Value), Convert.ToDateTime(dgvPostingNonPostedWorkshopLog.Rows(e.RowIndex).Cells("LogDate").Value))
                        LoadNonPostedWorkshopLog()
                End Select

            End If
        End If

    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvPostingNonPostedWorkshopLog.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

#End Region

#Region "Functions"

    Private Sub PostAllOrPostById(ByVal lsPostBy As String, ByVal liId As Integer, ByVal lsWorkVHID As String, ByVal ldLogDT As DateTime)

        _WorkshopLogPostingEntity = New WorkshopLogPostingPPT
        _WorkshopLogPostingManager = New WorkshopLogPostingBOL

        '_WorkshopLogPostingEntity.psEstateID = GlobalVar.psEstateID
        ' _WorkshopLogPostingEntity.psActiveMonthYearID = GlobalVar.psActiveMonthYearID
        _WorkshopLogPostingEntity.psPostingType = lsPostBy
        '_WorkshopLogPostingEntity.psCreatedModifiedBy = GlobalVar.psModifiedBy

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WorkShopLogPostingFrm))

        Select Case lsPostBy
            Case "Single"
                _WorkshopLogPostingEntity.piId = liId
                If MsgBox(rm.GetString("PromptApproval"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    _WorkshopLogPostingManager.PostByIdOrPostAllWorkshopLog(_WorkshopLogPostingEntity)
                    '_WorkshopLogPostingManager.SaveWorkshopLogVehicleProcessing(_WorkshopLogPostingEntity)
                    MsgBox(rm.GetString("MsgApproved"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Message")
                End If

            Case "Multiple"
                If MsgBox(rm.GetString("PromptAllApproval"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    Dim lirow As Integer
                    For lirow = 0 To dgvPostingNonPostedWorkshopLog.Rows.Count - 1

                        _WorkshopLogPostingEntity.piId = dgvPostingNonPostedWorkshopLog.Rows(lirow).Cells("Id").Value()

                        _WorkshopLogPostingManager.PostByIdOrPostAllWorkshopLog(_WorkshopLogPostingEntity)
                        '_WorkshopLogPostingManager.SaveWorkshopLogVehicleProcessing(_WorkshopLogPostingEntity)
                    Next
                    MsgBox(rm.GetString("MsgApproved"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Message")
                End If

        End Select

        'To Insert/Update the VHRunningDetail Table
        'To Insert the LedgerAllModule, JournalDetail and  VHChargeDetail Tables

        '   _WorkshopLogPostingEntity.psCreatedModifiedBy = GlobalVar.psCreatedBy

        'Select Case lsPostBy
        '    Case "Single"
        '        If lsWorkVHID <> String.Empty Then

        '            _WorkshopLogPostingEntity.pdLogDateDT = ldLogDT
        '            _WorkshopLogPostingEntity.psWorkVHID = lsWorkVHID

        '            _WorkshopLogPostingManager.SaveVehicleRunningDetail(_WorkshopLogPostingEntity)

        '        End If
        '    Case "Multiple"
        '        Dim row As Integer
        '        For row = 0 To dgvPostingNonPostedWorkshopLog.Rows.Count - 1

        '            _WorkshopLogPostingEntity.pdLogDateDT = dgvPostingNonPostedWorkshopLog.Rows(row).Cells("LogDate").Value()
        '            _WorkshopLogPostingEntity.psWorkVHID = dgvPostingNonPostedWorkshopLog.Rows(row).Cells("WorkshopNo").Value()

        '            _WorkshopLogPostingManager.SaveVehicleRunningDetail(_WorkshopLogPostingEntity)

        '        Next
        'End Select

    End Sub

    Private Sub LoadNonPostedWorkshopLog()
        _WorkshopLogPostingEntity = New WorkshopLogPostingPPT
        _WorkshopLogPostingManager = New WorkshopLogPostingBOL

        '_WorkshopLogPostingEntity.psEstateID = GlobalVar.psEstateID
        '_WorkshopLogPostingEntity.psActiveMonthYearID = GlobalVar.psActiveMonthYearID

        dsWorkshopLogPosting = _WorkshopLogPostingManager.NonPostedWorkshopLogGet(_WorkshopLogPostingEntity)
        With dgvPostingNonPostedWorkshopLog
            .AutoGenerateColumns = False
            .DataSource = dsWorkshopLogPosting.Tables(0)
            .ClearSelection()
        End With

        If dsWorkshopLogPosting Is Nothing Or dsWorkshopLogPosting.Tables(0).Rows.Count <= 0 Then

            btnApproveAll.Enabled = False
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WorkShopLogPostingFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'Button
            btnApproveAll.Text = rm.GetString("btnApproveAll.Text")
            btnClose.Text = rm.GetString("btnClose.Text")

            'label
            lblApproveMessage.Text = rm.GetString("lblApproveMessage.Text")

            'GridView
            dgvPostingNonPostedWorkshopLog.Columns("LogDate").HeaderText = rm.GetString("dgvPostingNonPostedWorkshopLog.Columns(LogDate).HeaderText")
            dgvPostingNonPostedWorkshopLog.Columns("WorkshopNo").HeaderText = rm.GetString("dgvPostingNonPostedWorkshopLog.Columns(WorkshopNo).HeaderText")
            dgvPostingNonPostedWorkshopLog.Columns("VHID").HeaderText = rm.GetString("dgvPostingNonPostedWorkshopLog.Columns(VHID).HeaderText")
            dgvPostingNonPostedWorkshopLog.Columns("TotalHrs").HeaderText = rm.GetString("dgvPostingNonPostedWorkshopLog.Columns(TotalHrs).HeaderText")
            dgvPostingNonPostedWorkshopLog.Columns("Details").HeaderText = rm.GetString("dgvPostingNonPostedWorkshopLog.Columns(Details).HeaderText")
            dgvPostingNonPostedWorkshopLog.Columns("Post").HeaderText = rm.GetString("dgvPostingNonPostedWorkshopLog.Columns(Post).HeaderText")
            Post.Text = rm.GetString("Approve")

            'dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item("Approvel").Value= ""
            '  For Each DataGridViewRow In dgvPostingNonPostedVehicleDistribution.Rows
            'DataGridViewRow.Cells("Approvel").Value.ToString()
            'Next
            'dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item("Approvel").Value = rm.GetString("dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item(Approvel).Value")
            cmsWorkshopLogPosting.Items.Item(0).Text = rm.GetString("cmsWorkshopLogPosting.Items.Item(0).Text")
            cmsWorkshopLogPosting.Items.Item(1).Text = rm.GetString("cmsWorkshopLogPosting.Items.Item(1).Text")
            cmsWorkshopLogPosting.Items.Item(2).Text = rm.GetString("cmsWorkshopLogPosting.Items.Item(2).Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class