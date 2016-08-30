Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Math
Imports System.IO

Public Class StoreMonthEndClosing


    Private Sub StoreMonthEndClosing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'First check the taskcheck=y if yes , next check task monitor table
        'If TaskConfigTaskCheck() = "Y" Then
        LoadGridTaskStatus()
        ' Else
        'MessageBox.Show("Cant proceed Month End Closing ... Please Check Task Config")

        'End If
       
    End Sub

    Private Function TaskConfigTaskCheck() As String

        Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
        Dim lsTaskCheck As String = "N"
        Dim dsTaskCheck As New DataSet
        dsTaskCheck = StoreMonthEndClosingBOL.TaskConfigTaskCheckGet(objStoreMonthEndClosingPPT)
        If dsTaskCheck.Tables(0).Rows.Count <> 0 Then
            lsTaskCheck = dsTaskCheck.Tables(0).Rows(0).Item("CValue")
        End If
        Return lsTaskCheck

    End Function

    Private Sub LoadGridTaskStatus()

        Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
        Dim dsLoadGridTaskStatus As New DataSet
        dsLoadGridTaskStatus = StoreMonthEndClosingBOL.TaskMonitorGet(objStoreMonthEndClosingPPT)
        If dsLoadGridTaskStatus.Tables(0).Rows.Count > 0 Then
            gvTaskStatus.AutoGenerateColumns = False
            gvTaskStatus.DataSource = dsLoadGridTaskStatus.Tables(0)
        Else
            gvTaskStatus.DataSource = dsLoadGridTaskStatus.Tables(0)
        End If

    End Sub

    Private Sub btnProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProc.Click
        'Dim MnthProc As New clsStoreMonthlyProcessing()
        'If MsgBox("You are about to perform monthly processing. Do you want to proceed. If Yes, click ""OK"", otherwise click ""Cancel""", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        'Me.Cursor = Cursors.WaitCursor
        'MnthProc.DOStoreMonthlyProcessing()
        'Me.Cursor = Cursors.Arrow

        Cursor = Cursors.WaitCursor
        Dim lsComplete As String = String.Empty

        If MsgBox("You are about to perform month end closing. Do you want to proceed. If Yes, click ""OK"", otherwise click ""Cancel""", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

            For Each objDataGridViewRow In gvTaskStatus.Rows
                If objDataGridViewRow.Cells("Complete").Value.ToString() = "N" Then
                    If objDataGridViewRow.Cells("Task").Value.ToString() <> "Store month end closing" Then
                        lsComplete = "N"
                        Exit For
                    End If
                End If
            Next

            If lsComplete = "N" Then

                MessageBox.Show("Could not proceed with month end closing. Some of the tasks not completed!")

            Else
                '-------------------------------------------------------------------------
                'Dim strBackupPath As String = String.Empty
                'strBackupPath = "SQLSERVER"
                'strBackupPath = "\\" + strBackupPath + "\" + "C\RANNBSPDB"
                'If Not Directory.Exists(strBackupPath) Then
                '    Directory.CreateDirectory(strBackupPath)
                'End If
                'Dim di As DirectoryInfo = Directory.CreateDirectory(strBackupPath)
                '-------------------------------------------------------------------------
                '


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
                fMsg.lblTitle.Text = "Progress"
                'MessageBox.Show(fMsg.lblTitle.Text)
                fMsg.lblTitle.Refresh()
                fMsg.lblMessage.Refresh()
                '

                'Commented by sangar D on 28-Aug-2012 - Advised by ran team to imporove the application performance
                'fMsg.lblMessage.Refresh()
                'fMsg.lblMessage.Text = "Database Backup before Month end closing Progress..."
                'fMsg.lblMessage.Refresh()
                'fMsg.pbWait.Value += 10
                'System.Threading.Thread.Sleep(2000)
                'Take a backup of BSP db before month end closing Start
                'GlobalBOL.AutoBSPBackup("Before", 2)
                'Take a backup of BSP db before month end closing End


                fMsg.pbWait.Value += 25
                System.Threading.Thread.Sleep(2000)


                fMsg.lblMessage.Refresh()
                fMsg.lblMessage.Text = "Monthly Process Progress..."
                fMsg.lblMessage.Refresh()


                Dim objStoreMonthEndClosingPPT As New StoreMonthEndClosingPPT
                Dim objProcessingPPT As New StoreMonthlyProcessingPPT
                Dim dsStoreMonthEndClosing As New DataSet
                Dim DSprocessing As New DataSet

                DSprocessing = StoreMonthlyProcessingBOL.DoStoreMonthlyProcessing(objProcessingPPT)

                fMsg.pbWait.Value += 25
                System.Threading.Thread.Sleep(2000)


                fMsg.lblMessage.Refresh()
                fMsg.lblMessage.Text = "Month End Closing Progress..."
                fMsg.lblMessage.Refresh()


                If DSprocessing Is Nothing Then
                    fMsg.Close()
                    MessageBox.Show("Processing  Failed")
                    Exit Sub
                End If

                dsStoreMonthEndClosing = StoreMonthEndClosingBOL.DoStoreMonthEndClosing(objStoreMonthEndClosingPPT)

                fMsg.pbWait.Value += 25
                System.Threading.Thread.Sleep(2000)



                If dsStoreMonthEndClosing Is Nothing Then

                    fMsg.Close()
                    MessageBox.Show("Operation Failed")
                    Exit Sub
                Else

                    ' Palani
                    Dim strnewActiveMonthYearID As String = ""
                    strnewActiveMonthYearID = dsStoreMonthEndClosing.Tables(0).Rows(0).Item(0).ToString()

                    If strnewActiveMonthYearID.Trim() <> "" Then
                        Dim dsTemp As New DataSet
                        dsTemp = StoreMonthEndClosingBOL.StoreMonthEndClosing_UpdateStockMaster(objStoreMonthEndClosingPPT, strnewActiveMonthYearID)
                    End If

                    'Commented on 14-June-2011 - Only to backup db before month-end closing
                    'fMsg.lblMessage.Text = "Database Backup After Month end closing Progress..."
                    'fMsg.lblMessage.Refresh()



                    'Take a backup of BSP db before month end closing Start
                    'Commented on 14-June-2011 - Only to backup db before month-end closing
                    'GlobalBOL.AutoBSPBackup("After", 2)
                    'Take a backup of BSP db before month end closing End

                    'MessageBox.Show(Date.Today().Now())

                    fMsg.pbWait.Value += 25
                    System.Threading.Thread.Sleep(2000)

                    'obj.Sleep(5000)

                    fMsg.Close()                'close the message form because the processing is done

                    'Me.Show()

                    MessageBox.Show("Month End Closing Completed.")

                    MdiParent.Close()
                    LoginFrm.Show()

                End If

                MdiParent.Close()
                LoginFrm.Show()

            End If
        Else
            Cursor = Cursors.Arrow
            Exit Sub
        End If
        Cursor = Cursors.Arrow
        'Else
        '    Exit Sub
        'End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub


    Private Sub PnlSearch_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles PnlSearch.Paint

    End Sub
End Class