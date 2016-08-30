Imports Vehicle_BOL
Imports Vehicle_PPT
'Imports Vehicle_DAL
Imports Common_PPT

Public Class VehicleDistributionPostingFrm
    'Public Sub New()
    '    InitializeComponent()
    'End Sub

    Dim _VehicleDistributionPostingPPT As VehicleDistributionPostingPPT
    Dim _VehicleDistributionPostingBOL As VehicleDistributionPostingBOL
    Dim dsVDLogPosting As DataSet

    Dim _VehicleRunningLogPostingEntity As VehicleRunningLogPostingPPT
    Dim _VehicleRunningLogPostingManager As VehicleRunningLogPostingBOL
    'Dim dsVDLogPosting As DataSet
    'Dim dsNonPostedVehicleLog As DataSet

#Region "Events"

    Private Sub VehicleDistributionPosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        LoadNonPostedVehicleDistribution()
        dgvPostingNonPostedVehicleDistribution.Columns("LogDate").DefaultCellStyle.Format = "dd/MM/yyyy"
    End Sub

    Private Sub btnPostAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproveAll.Click
        PostAllOrPostById("Multiple", 0, String.Empty, DateTime.Now, 0, 0)
        LoadNonPostedVehicleDistribution()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionPostingFrm))
        If MsgBox(rm.GetString("ClosePrompt"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Hide()
        End If
    End Sub

    Private Sub dgvPostingNonPostedVehicleDistribution_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPostingNonPostedVehicleDistribution.CellContentClick
        ' find out which column was clicked
        Select Case dgvPostingNonPostedVehicleDistribution.Columns(e.ColumnIndex).Name
            Case "Details"
                Dim lsVHCode As String
                Dim liId As String
                Dim ldtLogDate As Date
                lsVHCode = dgvPostingNonPostedVehicleDistribution.Rows(dgvPostingNonPostedVehicleDistribution.CurrentRow.Index).Cells("VHID").Value
                ldtLogDate = Convert.ToDateTime(dgvPostingNonPostedVehicleDistribution.Rows(dgvPostingNonPostedVehicleDistribution.CurrentRow.Index).Cells("LogDate").Value)
                liId = dgvPostingNonPostedVehicleDistribution.Rows(dgvPostingNonPostedVehicleDistribution.CurrentRow.Index).Cells("Id").Value

                Dim _VehicleDistribution As New VehicleDistributionFrm
                Dim _VehicleDistributionBOL As New VehicleDistributionBOL
                Dim _VehicleDistributionPPT As New VehicleDistributionPPT

                _VehicleDistributionPPT.piId = liId

                Dim dsVDFrm As New DataSet

                dsVDFrm = _VehicleDistributionBOL.GetVehicleDistributionDetails(_VehicleDistributionPPT)
                'Me.Parent.Controls(0).Controls.Clear()
                ' Me.Parent.Controls(0).Controls.Add(VehicleDistributionFrm)



                'For Each ChildForm As Form In MdiParent.MdiChildren
                '    ChildForm.Close()
                'Next


                'Dim childVehicle As New VehicleDistributionFrm()
                _VehicleDistribution.MdiParent = MdiParent
                _VehicleDistribution.Dock = DockStyle.Fill
                _VehicleDistribution.Show()

                '_VehicleDistribution.Enabled = False
                _VehicleDistribution.pnlEntry.Enabled = False

                _VehicleDistribution.btnSaveAll.Enabled = False
                _VehicleDistribution.btnResetAll.Enabled = False
                _VehicleDistribution.btnClose.Visible = True

                _VehicleDistribution.tbcVehicleDistribution.TabPages.Remove(_VehicleDistribution.tbpgViewVRB)

                _VehicleDistribution.BindVehicleDistributionByVehicleCode(lsVHCode, ldtLogDate)

                _VehicleDistribution.AssignDistributionValuesForVehicleCode(lsVHCode, ldtLogDate)

                'dsVehicleCode = New DataSet()

                '_VehicleDistributionPPT.psVHID = lsVHCode
                ''ObjVehicleDistributionPPT.psEstateID = GlobalPPT.strEstateID
                ''ObjVehicleDistributionPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID
                '_VehicleDistributionPPT.pdDistributionDT = ldtLogDate

                'Dim ObjVehicleDistributionCollection As DataSet
                'ObjVehicleDistributionCollection = _VehicleDistributionBOL.GetVehicleDistribution(_VehicleDistributionPPT)

                'Dim ObjVehicleDistributionCollection0 As New DataTable
                'ObjVehicleDistributionCollection0 = ObjVehicleDistributionCollection.Tables(0)

                'If ObjVehicleDistributionCollection0.Rows.Count > 0 Then
                '    _VehicleDistribution.txtUOM.Text = Convert.ToString(ObjVehicleDistributionCollection0.Rows(0)("UOM"))


                '    _VehicleDistribution.ConvertKmsToHrsText(_VehicleDistribution.txtUOM.Text)
                '    _VehicleDistribution.txtVehicleCode.Text = lsVHCode
                '    _VehicleDistribution.txtVehicleName.Text = Convert.ToString(ObjVehicleDistributionCollection0.Rows(0)("Category"))
                '    _VehicleDistribution.txtVehicleModel.Text = Convert.ToString(ObjVehicleDistributionCollection0.Rows(0)("VHModel"))
                '    _VehicleDistribution.txtVehicleRegNo.Text = Convert.ToString(ObjVehicleDistributionCollection0.Rows(0)("RegNo"))
                'End If

                'If dsVDFrm.Tables(0).Rows.Count > 0 Then
                '    '_VehicleDistribution.txtVehicleCode.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("VHWSCode"))
                '    _VehicleDistribution.txtAccountCode.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("COACode"))
                '    _VehicleDistribution.lblAccountDescription.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("COADescp"))
                '    _VehicleDistribution.lblOldAccountValue.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("OldCOACode"))

                '    Select Case (_VehicleDistribution.txtUOM.Text.Trim)
                '        Case "Hrs"
                '            Dim ldTimeDt As DateTime = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("KmHours")).Replace(".", ":") 'DateTime.ParseExact(Me.dsVehicleLogDetails.Tables(0).Rows(0)(0).ToString().Substring(0, 5), "HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo).ToString("HH:mm")
                '            _VehicleDistribution.txtKm.Text = ldTimeDt.ToString("HH:mm") 'ldTimeDt.Hour.ToString("00") + "." + ldTimeDt.Minute.ToString("00")
                '            ldTimeDt = Convert.ToString(dgvPostingNonPostedVehicleDistribution.Rows(dgvPostingNonPostedVehicleDistribution.CurrentRow.Index).Cells("TotalRunningKmHrs").Value).Replace(".", ":")
                '            _VehicleDistribution.txtTotalRunningKm.Text = ldTimeDt.ToString("HH:mm")
                '            ldTimeDt = Convert.ToString(dgvPostingNonPostedVehicleDistribution.Rows(dgvPostingNonPostedVehicleDistribution.CurrentRow.Index).Cells("TotalDistributedKmHrs").Value).Replace(".", ":")
                '            _VehicleDistribution.txtTotalKmDistributed.Text = ldTimeDt.ToString("HH:mm")

                '            'Dim ldTotalHrsDistributedDT As TimeSpan = GetInTimeValue(ldCurrentTotalKmDistributed) - GetInTimeValue(txtKm.Text.Trim.Replace(":", ".")) 'GetInTimeValue(ddlHrs.SelectedItem + "." + ddlMin.SelectedItem)
                '            'Me.txtTotalKmDistributed.Text = ldTotalHrsDistributedDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldTotalHrsDistributedDT.ToString.Substring(0, 5)) '.Replace(":", ".")) 'Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim) - Convert.ToDecimal(Me.txtKm.Text.Trim)
                '            'ldCurrentTotalKmDistributed = Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim.Replace(":", ".")) 'Convert.ToDecimal(Me.txtTotalKmDistributed.Text.Trim) - Convert.ToDecimal(Me.txtKm.Text.Trim)

                '            'Dim ldBalanceToDistributeDT As TimeSpan = GetInTimeValue(txtTotalRunningKm.Text.Trim.Replace(":", ".")) - GetInTimeValue(ldCurrentTotalKmDistributed) 'GetInTimeValue(ddlHrs.SelectedItem + "." + ddlMin.SelectedItem)
                '            'Me.txtBalanceToDistribute.Text = ldBalanceToDistributeDT.ToString.Substring(0, 5) 'Convert.ToDecimal(ldBalanceToDistributeDT.ToString.Substring(0, 5)) '.Replace(":", ".")) 'Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Trim) + Convert.ToDecimal(Me.txtKm.Text.Trim)

                '            'ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Replace(":", ".")) 'Convert.ToDecimal(Me.txtBalanceToDistribute.Text.Trim) + Convert.ToDecimal(Me.txtKm.Text.Trim)

                '        Case "Kms"
                '            _VehicleDistribution.txtKm.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("KmHours")) 'Me.dsVehicleLogDetails.Tables(0).Rows(0)(0).ToString
                '            _VehicleDistribution.txtTotalRunningKm.Text = Convert.ToString(dgvPostingNonPostedVehicleDistribution.Rows(dgvPostingNonPostedVehicleDistribution.CurrentRow.Index).Cells("TotalRunningKmHrs").Value)
                '            _VehicleDistribution.txtTotalKmDistributed.Text = Convert.ToString(dgvPostingNonPostedVehicleDistribution.Rows(dgvPostingNonPostedVehicleDistribution.CurrentRow.Index).Cells("TotalDistributedKmHrs").Value)
                '            'Me.txtTotalKmDistributed.Text = ldCurrentTotalKmDistributed - Convert.ToDecimal(Me.txtKm.Text.Trim)
                '            'ldCurrentTotalKmDistributed = Convert.ToDecimal(Me.txtTotalKmDistributed.Text)
                '            'Me.txtBalanceToDistribute.Text = Convert.ToDecimal(txtTotalRunningKm.Text.Trim) - ldCurrentTotalKmDistributed
                '            'ldCurrentBalanceToDistribute = Convert.ToDecimal(Me.txtBalanceToDistribute.Text)

                '    End Select

                '    _VehicleDistribution.txtPrestasiTonnageBuncheskm.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("PrestasiTonBunchesKm"))

                '    _VehicleDistribution.txtDIV.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("Div"))
                '    _VehicleDistribution.txtYOP.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("YOP"))
                '    _VehicleDistribution.txtBlock.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("BlockName"))
                '    _VehicleDistribution.lblSubBlockStatus.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("BlockStatus"))
                '    _VehicleDistribution.txtT0.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("TValue0"))
                '    _VehicleDistribution.txtT1.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("TValue1"))
                '    _VehicleDistribution.txtT2.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("TValue2"))
                '    _VehicleDistribution.txtT3.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("TValue3"))
                '    _VehicleDistribution.txtT4.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("TValue4"))
                '    _VehicleDistribution.lblT0Desc.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("TDesc0"))
                '    _VehicleDistribution.lblT1Desc.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("TDesc1"))
                '    _VehicleDistribution.lblT2Desc.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("TDesc2"))
                '    _VehicleDistribution.lblT3Desc.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("TDesc3"))
                '    _VehicleDistribution.lblT4Desc.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("TDesc4"))
                '    _VehicleDistribution.txtRemarks.Text = Convert.ToString(dsVDFrm.Tables(0).Rows(0)("Remarks"))
                'End If

                '_VehicleDistribution.ShowVehicleDistributionDetailsByID(Convert.ToInt32(dgvPostingNonPostedVehicleDistribution.Rows(e.RowIndex).Cells("Id").Value))

            Case "Approval"

                PostAllOrPostById("Single", Convert.ToInt32(dgvPostingNonPostedVehicleDistribution.Rows(e.RowIndex).Cells("Id").Value), Convert.ToString(dgvPostingNonPostedVehicleDistribution.Rows(e.RowIndex).Cells("VHID").Value), Convert.ToDateTime(dgvPostingNonPostedVehicleDistribution.Rows(e.RowIndex).Cells("LogDate").Value), Convert.ToDecimal(dgvPostingNonPostedVehicleDistribution.Rows(e.RowIndex).Cells("TotalRunningKmHrs").Value), Convert.ToDecimal(dgvPostingNonPostedVehicleDistribution.Rows(e.RowIndex).Cells("TotalDistributedKmHrs").Value))

        End Select

        LoadNonPostedVehicleDistribution()

    End Sub

    Private Sub ClearSelection(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvPostingNonPostedVehicleDistribution.DataBindingComplete
        DirectCast(sender, DataGridView).ClearSelection()
    End Sub

#End Region

#Region "Functions"

    Private Sub PostAllOrPostById(ByVal lsPostBy As String, ByVal liId As Integer, ByVal lsVehicle As String, ByVal ldDistributionDT As DateTime, ByVal ldTotalRunningKmsHrs As Decimal, ByVal ldTotalKmsHrsDistributed As Decimal)

        _VehicleDistributionPostingPPT = New VehicleDistributionPostingPPT
        _VehicleDistributionPostingBOL = New VehicleDistributionPostingBOL

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionPostingFrm))

        Select Case lsPostBy
            Case "Single"
                If ldTotalRunningKmsHrs = ldTotalKmsHrsDistributed Then
                    '_VehicleDistributionPostingEntity.piId = liId
                    _VehicleDistributionPostingPPT.psVHID = lsVehicle
                    _VehicleDistributionPostingPPT.pdDistributionDT = ldDistributionDT
                    If MsgBox(rm.GetString("PromptApproval"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                        'VehicleRunningLog Posting
                        If Not PostAllOrPostById("Single", ldDistributionDT, lsVehicle) Then
                            MsgBox(rm.GetString("MsgApprovalDeniedForVHRLog"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                            Return
                        End If
                        _VehicleDistributionPostingBOL.PostByIdOrPostAllVehicleDistribution(_VehicleDistributionPostingPPT) '
                        MsgBox(rm.GetString("MsgApproved"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                    End If
                Else
                    MsgBox(rm.GetString("MsgApprovalDenied"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                    Return
                End If
            Case "Multiple"
                If MsgBox(rm.GetString("PromptAllApproval"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    Dim operationFlag, operationFlagGrid As New Integer
                    'operationFlagGrid = dgvPostingNonPostedVehicleDistribution.Rows.Count
                    Dim lirow As Integer
                    For lirow = 0 To dgvPostingNonPostedVehicleDistribution.Rows.Count - 1
                        ldTotalRunningKmsHrs = Convert.ToDecimal(dgvPostingNonPostedVehicleDistribution.Rows(lirow).Cells("TotalRunningKmHrs").Value)
                        ldTotalKmsHrsDistributed = Convert.ToDecimal(dgvPostingNonPostedVehicleDistribution.Rows(lirow).Cells("TotalDistributedKmHrs").Value)

                        If ldTotalRunningKmsHrs = ldTotalKmsHrsDistributed Then
                            '_VehicleDistributionPostingEntity.piId = dgvPostingNonPostedVehicleDistribution.Rows(lirow).Cells("Id").Value()
                            _VehicleDistributionPostingPPT.psVHID = dgvPostingNonPostedVehicleDistribution.Rows(lirow).Cells("VHID").Value()
                            _VehicleDistributionPostingPPT.pdDistributionDT = Convert.ToDateTime(dgvPostingNonPostedVehicleDistribution.Rows(lirow).Cells("LogDate").Value())
                            'VehicleRunningLog Posting
                            If Not PostAllOrPostById("Single", CDate(dgvPostingNonPostedVehicleDistribution.Rows(lirow).Cells("LogDate").Value()), dgvPostingNonPostedVehicleDistribution.Rows(lirow).Cells("VHID").Value()) Then
                                MsgBox(rm.GetString("MsgApprovalDeniedForVHRLog"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                                Return
                            End If
                            _VehicleDistributionPostingBOL.PostByIdOrPostAllVehicleDistribution(_VehicleDistributionPostingPPT)
                            operationFlag = operationFlag + 1
                        Else
                            operationFlagGrid = operationFlagGrid + 1
                        End If
                    Next

                    If operationFlag = 0 And operationFlagGrid > 0 Then
                        MsgBox(rm.GetString("MsgApprovalDenied"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                    ElseIf operationFlag > 0 And operationFlagGrid = 0 Then
                        MsgBox(rm.GetString("MsgApproved"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                    ElseIf operationFlag > 0 And operationFlagGrid > 0 Then
                        MsgBox(rm.GetString("SomeMsgApprovalDenied"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                    End If

                End If
        End Select

    End Sub

    Private Function PostAllOrPostById(ByVal lsPostBy As String, ByVal LogDate As DateTime, ByVal VHWSCode As String) As Boolean

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
                If _VehicleRunningLogPostingManager.PostByIdOrPostAll(_VehicleRunningLogPostingEntity) = 6 Then
                    Return True
                End If
            Case "Multiple"
                If _VehicleRunningLogPostingManager.PostByIdOrPostAll(_VehicleRunningLogPostingEntity) = 7 Then
                    Return True
                End If
        End Select
        Return False

    End Function

    Private Sub LoadNonPostedVehicleDistribution()
        '_VehicleDistributionPostingPPT = New VehicleDistributionPostingPPT
        _VehicleDistributionPostingBOL = New VehicleDistributionPostingBOL

        
        dsVDLogPosting = _VehicleDistributionPostingBOL.NonPostedVehicleDistributionGet()

        With dgvPostingNonPostedVehicleDistribution
            .AutoGenerateColumns = False
            .DataSource = dsVDLogPosting.Tables(0)
            .ClearSelection()
        End With

        If dsVDLogPosting Is Nothing Or dsVDLogPosting.Tables(0).Rows.Count <= 0 Then
            'MsgBox("All of vehicle distribution log records were posted. None remaining to be posted.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Information")
            btnApproveAll.Enabled = False
        End If

    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionPostingFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'Button
            btnApproveAll.Text = rm.GetString("btnApproveAll")
            btnClose.Text = rm.GetString("btnClose")

            'label
            lblApproveMessage.Text = rm.GetString("lblApproveMessage")

            'GridView
            dgvPostingNonPostedVehicleDistribution.Columns("LogDate").HeaderText = rm.GetString("LogDate")
            dgvPostingNonPostedVehicleDistribution.Columns("VHID").HeaderText = rm.GetString("VHID")
            dgvPostingNonPostedVehicleDistribution.Columns("TotalRunningKmHrs").HeaderText = rm.GetString("TotalRunningKmHrs")
            dgvPostingNonPostedVehicleDistribution.Columns("TotalDistributedKmHrs").HeaderText = rm.GetString("TotalDistributedKmHrs")
            dgvPostingNonPostedVehicleDistribution.Columns("Details").HeaderText = rm.GetString("Details")
            dgvPostingNonPostedVehicleDistribution.Columns("Approval").HeaderText = rm.GetString("Approval")
            'dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item("Approvel").Value= ""
            '  For Each DataGridViewRow In dgvPostingNonPostedVehicleDistribution.Rows
            'DataGridViewRow.Cells("Approvel").Value.ToString()
            'Next
            'dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item("Approvel").Value = rm.GetString("dgvPostingNonPostedVehicleDistribution.Rows(0).Cells.Item(Approvel).Value")
            cmsVehicleDistributionPosting.Items.Item(0).Text = rm.GetString("cmsVehicleDistributionPosting.Items.Item(0).Text")
            cmsVehicleDistributionPosting.Items.Item(1).Text = rm.GetString("cmsVehicleDistributionPosting.Items.Item(1).Text")
            cmsVehicleDistributionPosting.Items.Item(2).Text = rm.GetString("cmsVehicleDistributionPosting.Items.Item(2).Text")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class