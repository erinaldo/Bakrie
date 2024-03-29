﻿Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports System.Math
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.Drawing.Printing
Imports BSP.LoginFrm
Public Class SummaryPengeluaranReportInterfaceFrm
    Public Shared StrFrmName As String = String.Empty
    Public Shared strAmonth As Integer
    Public Shared strAYear As Integer
    Public Shared strFrmDate As String = String.Empty
    Public Shared strToDate As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryPengeluaranReportInterfaceFrm))

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub SummaryPengeluaranReportInterfaceFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ds As DataSet
        Dim objSummaryPengeluaranPPT As New SummaryPengeluaranPPT
        Dim objSummaryPengeluaranBOL As New SummaryPengeluaranBOL
        Dim Lmonth As String
        Dim LYear As String
        Lmonth = GlobalPPT.IntLoginMonth
        LYear = GlobalPPT.intLoginYear

        ''temp start
        If Lmonth = 1 Then
            Lmonth = "January"
        ElseIf Lmonth = 2 Then
            Lmonth = "February"
        ElseIf Lmonth = 3 Then
            Lmonth = "March"
        ElseIf Lmonth = 4 Then
            Lmonth = "April"
        ElseIf Lmonth = 5 Then
            Lmonth = "May"
        ElseIf Lmonth = 6 Then
            Lmonth = "June"
        ElseIf Lmonth = 7 Then
            Lmonth = "July"
        ElseIf Lmonth = 8 Then
            Lmonth = "August"
        ElseIf Lmonth = 9 Then
            Lmonth = "September"
        ElseIf Lmonth = 10 Then
            Lmonth = "October"
        ElseIf Lmonth = 11 Then
            Lmonth = "November"
        ElseIf Lmonth = 12 Then
            Lmonth = "December"
        End If
        ''temp end 

        ds = objSummaryPengeluaranBOL.GetInterfaceYear(objSummaryPengeluaranPPT)

        If ds.Tables.Count > 0 Then

            If ds.Tables(0).Rows.Count > 0 Then

                cbYear.DataSource = ds.Tables(0)
                cbYear.DisplayMember = "AYear"
                cbYear.ValueMember = "AYear"
            End If

            cbYear.Text = LYear

            If ds.Tables(1).Rows.Count > 0 Then

                cbMonth.DataSource = ds.Tables(1)
                cbMonth.DisplayMember = "MONTH"
                cbMonth.ValueMember = "AMonth"

            End If

            cbMonth.Text = Lmonth
        End If

    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Reportget()
    End Sub
    Private Sub Reportget()

        Dim objSummaryPengeluaranPPT As New SummaryPengeluaranPPT
        Dim objSummaryPengeluaranBOL As New SummaryPengeluaranBOL
        Dim strsummaryname As String = String.Empty
        Dim ds As New DataSet
        Dim complete As String = String.Empty

        objSummaryPengeluaranPPT.AMonth = cbMonth.SelectedValue
        objSummaryPengeluaranPPT.AYear = cbYear.Text

        objSummaryPengeluaranPPT.Task = "Store month end closing"
        ''strtask = "Estate/Mill Delivery note approval"


        ds = objSummaryPengeluaranBOL.GetTaskComplete(objSummaryPengeluaranPPT)

        If ds.Tables(0).Rows.Count > 0 Then
            complete = ds.Tables(0).Rows(0).Item("Complete").ToString()
        End If


        If complete = "N" Then


            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryPengeluaranReportInterfaceFrm))
            If MsgBox(rm.GetString("msg01"), MsgBoxStyle.YesNo) <> Windows.Forms.DialogResult.No Then
                StrFrmName = "SummaryPen"
                objSummaryPengeluaranPPT.AMonth = cbMonth.SelectedValue
                objSummaryPengeluaranPPT.AYear = cbYear.Text
                ds = objSummaryPengeluaranBOL.GetFYearDate(objSummaryPengeluaranPPT)
                strFrmDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                strToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()
                strAmonth = cbMonth.SelectedValue
                strAYear = cbYear.Text
                SummaryPengeluaranReportView.ShowDialog()
            Else
                Exit Sub
                complete = String.Empty
                '' MessageBox.Show("Some of Estate/Mill Delivery note  not approved, do you still want to preview the report YES/NO", "BSP", MessageBoxButtons.OKCancel, _
            End If

        Else

            objSummaryPengeluaranPPT.AMonth = cbMonth.SelectedValue
            objSummaryPengeluaranPPT.AYear = cbYear.Text
            ds = objSummaryPengeluaranBOL.GetFYearDate(objSummaryPengeluaranPPT)
            strFrmDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
            strToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()
            StrFrmName = "SummaryPen"
            strAmonth = cbMonth.SelectedValue
            strAYear = cbYear.Text
            ''strmonname = cbMonth.SelectedValue
            SummaryPengeluaranReportView.stDate = strFrmDate
            SummaryPengeluaranReportView.endDate = strToDate
            SummaryPengeluaranReportView.ShowDialog()
            ''ReportODBCMethod.ShowDialog()

        End If
    End Sub
    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryPengeluaranReportInterfaceFrm))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            pnlSummarypengeluranrpt.CaptionText = rm.GetString("pnlSummarypengeluranrpt.CaptionText")
            lblsearchBy.Text = rm.GetString("lblsearchBy.Text")
            lblMonth.Text = rm.GetString("lblMonth.Text")
            lblYear.Text = rm.GetString("lblYear.Text")
            btnReport.Text = rm.GetString("btnReport.Text")
            btnClose.Text = rm.GetString("btnClose.Text")

        Catch

            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryPengeluaranReportInterfaceFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub SummaryPengeluaranReportInterfaceFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class