Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT


Public Class ProductionMonthEndClosing


    Private Sub ProductionMonthEndClosing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        LoadGridTaskStatus()
    End Sub
    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionMonthEndClosing))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            'gpProductionMonthEndClosing.Text = rm.GetString("ProductionMonthEndClosing")
            'PnlSearch.CaptionText = rm.GetString("PnlSearch")
            'gvTaskStatus.Columns("TASK").HeaderText = rm.GetString("TASK")
            'gvTaskStatus.Columns("Complete").HeaderText = rm.GetString("Complete")
            btnClose.Text = rm.GetString("Close")
            btnProcessing.Text = rm.GetString("Processing")
  
        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionMonthEndClosing))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
    Private Sub LoadGridTaskStatus()
        Dim dsLoadGridTaskStatus As New DataSet
        dsLoadGridTaskStatus = ProductionMonthEndClosingBOL.TaskMonitorGet()
        If dsLoadGridTaskStatus.Tables(0).Rows.Count > 0 Then
            gvTaskStatus.AutoGenerateColumns = False
            gvTaskStatus.DataSource = dsLoadGridTaskStatus.Tables(0)
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionMonthEndClosing))
        If MsgBox(rm.GetString("Msg1"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            Me.Close()
        End If
        ''If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        ''    Me.Close()
        ''End If
    End Sub
    Private Function StatusCheck() As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In gvTaskStatus.Rows
                Dim lStatus As String = "N"
                If lStatus = objDataGridViewRow.Cells("Complete").Value.ToString() And objDataGridViewRow.Cells("Task").Value.ToString() <> "Mill Month end closing" Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub btnProcessing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessing.Click
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProductionMonthEndClosing))

        If StatusCheck() = True Then
            DisplayInfoMessage("Msg2")
            ''MsgBox(" Could not proceed with month end closing. Some of the tasks not completed!")
            Exit Sub
        End If
        If MsgBox(rm.GetString("Msg3"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
            ''If (MessageBox.Show("You are about to perform month end closing. Do you want to proceed. If Yes, click 'OK' otherwise click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            Me.Cursor = Cursors.WaitCursor
            Try
                'Progress Bar Start
                Dim fMsg As New ProgressingFrm            'create a new object for the message form
                fMsg.TopMost = True                'this is to make sure that the message form is displayed at the top of your windows and the users cannot do anything to it except waiting
                'fMsg.RightToLeftLayout.
                fMsg.Show()                'use Show() instead of ShowDialog()

                fMsg.pbWait.Minimum = 0
                fMsg.pbWait.Maximum = 100
                fMsg.pbWait.Value = 0
                fMsg.lblMessage.Refresh()
                fMsg.lblTitle.Refresh()
                fMsg.lblTitle.Text = rm.GetString("Msg4")
                'fMsg.lblTitle.Text = "Progress"
                'MessageBox.Show(fMsg.lblTitle.Text)
                fMsg.lblTitle.Refresh()
                fMsg.lblMessage.Refresh()
                '

                'Commented by sangar D on 28-Aug-2012 - Advised by ran team to imporove the application performance
                'fMsg.lblMessage.Refresh()
                'fMsg.lblMessage.Text = rm.GetString("Msg5")
                ' '' fMsg.lblMessage.Text = "Database Backup before Month end closing Progress..."
                'fMsg.lblMessage.Refresh()
                'fMsg.pbWait.Value += 25
                'System.Threading.Thread.Sleep(2000)
                'GlobalBOL.AutoBSPBackup("Before", 4)

                fMsg.pbWait.Value += 50
                System.Threading.Thread.Sleep(2000)


                fMsg.lblMessage.Refresh()
                fMsg.lblMessage.Text = rm.GetString("Msg6")
                ''fMsg.lblMessage.Text = "Month End Closing Progress..."
                fMsg.lblMessage.Refresh()

                Dim ds As New DataSet
                ds = ProductionMonthEndClosingBOL.ProductionTaskMonitorINSERT()
                If ds Is Nothing Then
                    fMsg.Close()
                    DisplayInfoMessage("Msg7")
                    ''MsgBox("Month End Closing Failed")
                Else
                    'Commented on 14-June-2011 - Only to backup db before month-end closing
                    'GlobalBOL.AutoBSPBackup("After", 4)
                    'fMsg.lblMessage.Text = rm.GetString("Msg8")
                    ''fMsg.lblMessage.Text = "Database Backup After Month end closing Progress..."
                    fMsg.lblMessage.Refresh()


                    fMsg.pbWait.Value += 50
                    System.Threading.Thread.Sleep(2000)

                    fMsg.Close()
                    DisplayInfoMessage("Msg9")
                    ''MsgBox("Month End Closing Completed")
                    MdiParent.Close()
                    Dim LoginFrmTest As New LoginFrm
                    LoginFrmTest.Show()
                    '  LoginFrm.ShowDialog()
                End If
            Catch ex As Exception
                DisplayInfoMessage("Msg10")
                ''MsgBox("Processing Failed")
            End Try
            Me.Cursor = Cursors.Default
        End If

    End Sub

End Class