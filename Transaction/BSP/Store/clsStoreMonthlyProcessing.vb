Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Math

Public Class clsStoreMonthlyProcessing

    Public Sub DOStoreMonthlyProcessing()
        Dim PCircle As New SpinningProgressFrm
        Try
            PCircle.TopMost = True
            PCircle.Show()
            PCircle.SpinningProgressBar.Refresh()

            Dim objStoreMonthlyProcessingPPT As New StoreMonthlyProcessingPPT
            Dim dsStoreMonthlyProcessing As New DataSet

            'Progress Bar Start
            Dim fMsg As New ProgressingFrm            'create a new object for the message form
            fMsg.TopMost = True                'this is to make sure that the message form is displayed at the top of your windows and the users cannot do anything to it except waiting
            'fMsg.RightToLeftLayout.
            fMsg.Show()                'use Show() instead of ShowDialog()

            fMsg.pbWait.Minimum = 0
            fMsg.pbWait.Maximum = 100
            fMsg.pbWait.Value = 0
            fMsg.lblTitle.Refresh()
            fMsg.lblTitle.Text = "Progress"
            fMsg.lblTitle.Refresh()
            '

            'fMsg.pbWait.Value += 10
            'System.Threading.Thread.Sleep(2000)


            fMsg.lblMessage.Refresh()
            fMsg.lblMessage.Text = "Monthly Processing Progress..."
            fMsg.lblMessage.Refresh()


            dsStoreMonthlyProcessing = StoreMonthlyProcessingBOL.DoStoreMonthlyProcessing(objStoreMonthlyProcessingPPT)
            If dsStoreMonthlyProcessing Is Nothing Then
                fMsg.Close()
                MessageBox.Show("Operation Failed")
                Exit Sub
            Else
                fMsg.pbWait.Value += 90
                System.Threading.Thread.Sleep(2000)
                fMsg.Close() 'close the message form because the processing is done



                MessageBox.Show("Store Monthly Processing Completed.")
                'MessageBox.Show(Date.Today().Now())
            End If

        Catch ex As Exception

        Finally
            PCircle.Close()
        End Try



    End Sub

End Class
