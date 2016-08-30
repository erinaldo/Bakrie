Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports CheckRoll_BOL
Imports CheckRoll_DAL
Imports CheckRoll_PPT
Imports Common_PPT
Imports System.IO
Imports Core.Framework.Windows.Helper
Imports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel

Namespace CheckRoll.Import

    Public Class ImportAllowance

        Private tempOfsource As DataSet

        Private Sub BtnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles BtnBrowse.Click
            Try
                Dim file As New OpenFileDialog
                file.Filter = "Excel Worksheets 2007 |*.xls"
                If file.ShowDialog() <> DialogResult.Cancel Then
                    LblSource.Text = file.FileName
                    ImportAllowancePPT.fileName = file.FileName
                    Dim objBOL As New ImportAllowanceBOL
                    dgvAllowance.DataSource = objBOL.GetExcel().Tables(0)
                    tempOfsource = objBOL.GetExcel()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Sub

        Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click

            Dim listProcess As Integer
            Dim listTemp As New List(Of String)
            Dim listSuccess As Integer = 0
            Dim jumlah = dgvAllowance.Rows.Count
            ProgressBar.Visible = True
            ProgressBar.Value = 0
            ProgressBar.Maximum = jumlah
            BtnBrowse.Enabled = False
            BtnSave.Enabled = False
            btnClose.Enabled = False            
            Try

            Dim objBOL As New ImportAllowanceBOL
                ThreadPool.QueueUserWorkItem(
                    Sub(state As Object)

                        Dim stateObject As Object()
                        stateObject = state
                        Dim objcBol As ImportAllowanceBOL = stateObject(0)
                        Dim tempOfExcel As DataSet = stateObject(1)

                        For Each dg In tempOfExcel.Tables(0).Rows
                            Dim ppt As New ImportAllowancePPT
                            listProcess = listProcess + 1
                            With ppt
                                If Not IsDBNull(dg("Emp ID")) Then
                                    .empID = dg("Emp ID").ToString()
                                End If
                                If Not IsDBNull(dg("Estate ID")) Then
                                    .estateID = dg("Estate ID").ToString()
                                End If
                                .estateCode = GlobalPPT.strEstateCode
                                If Not IsDBNull(dg("AllowDeductionCode")) Then
                                    .allowDedID = dg("AllowDeductionCode").ToString()
                                End If
                                If Not IsDBNull(dg("Amount")) Then
                                    .amount = dg("Amount").ToString()
                                End If
                                If Not IsDBNull(dg("Type")) Then
                                    .type = dg("Type").ToString()
                                End If
                                If Not IsDBNull(dg("DateFrom")) Then
                                    .startDate = dg("DateFrom")
                                End If

                                If Not IsDBNull(dg("DateTo")) Then
                                    .endDate = dg("DateTo")
                                End If
                            End With

                            LblProcess.BeginInvoke(Sub()
                                                       LblProcess.Text = "Process " & listProcess & " of " & jumlah & " : Saving " & ppt.empID
                                                       ProgressBar.Value += 1
                                                   End Sub)

                            If Not objcBol.Save(ppt) Then
                                Dim errorstring = ppt.SaveError
                                dg("System Error Message") = errorstring
                                listTemp.Add(dg("System Error Message") & "|" & dg("Emp ID") & "|" & dg("AllowDeductionCode"))
                                'objBOL.UpdateExcel(errorstring, ppt.empID, ppt.allowDedID)
                            Else
                                '  dg("System Error Message") = ""
                                listSuccess = listSuccess + 1
                                'objBOL.UpdateExcel("", ppt.empID, ppt.allowDedID)
                            End If
                        Next

                        objcBol.UpdateExcels(listTemp)

                        ProgressBar.BeginInvoke(Sub()
                                                    LblProcess.Text = "Finish ! Success : " & listSuccess & " Error : " & listTemp.Count
                                                    ProgressBar.Visible = False
                                                    BtnBrowse.Enabled = True
                                                    BtnSave.Enabled = True
                                                    btnClose.Enabled = True
                                                    dgvAllowance.DataSource = tempOfExcel.Tables(0)
                                                End Sub)
                        MsgBox("Done! Check column System Error Message for any Error(s)", MsgBoxStyle.Information, "Information")

                    End Sub, New Object() {objBOL, tempOfsource})
            Catch ex As Exception
                MsgBox("Following Erorr has occured : ", ex.Message)
            End Try

        End Sub

        Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
            Close()
        End Sub

        Private Sub ImportAllowance_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            dgvAllowance.DataSource = Nothing
            LblSource.Text = "..."
        End Sub
    End Class
End Namespace