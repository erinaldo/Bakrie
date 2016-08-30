Imports Vehicle_PPT
Imports Vehicle_BOL
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

Public Class DistribusiBiayaBengkelReportFrm

    Public Shared strActMthYearID As String = String.Empty
    Public Shared strmonth As String = String.Empty
    Public Shared strYear As String = String.Empty
    Public Shared strFiscalYearFromDate As String = String.Empty
    Public Shared strFiscalYearToDate As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DistribusiBiayaBengkelReportFrm))



    Private Sub DistribusiBiayaBengkelReportFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        Dim ds As DataSet
        Dim objDistribusiBiayaBengkelReportPPT As New DistribusiBiayaBengkelReportPPT
        Dim objDistribusiBiayaBengkelReportBOL As New DistribusiBiayaBengkelReportBOL
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

        ds = objDistribusiBiayaBengkelReportBOL.GetInterfaceYear(objDistribusiBiayaBengkelReportPPT)

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


        Dim DistribusiBiayaBengkelReportFrm As New DistribusiBiayaBengkelReportFrm
        Dim objDistribusiBiayaBengkelReportPPT As New DistribusiBiayaBengkelReportPPT
        Dim objDistribusiBiayaBengkelReportBOL As New DistribusiBiayaBengkelReportBOL

        Dim ds As New DataSet
        Dim complete As String = String.Empty

        ' strActMthYearID = cbMonth.SelectedValue.ToString

        ds = objDistribusiBiayaBengkelReportBOL.GetInterfaceYear(objDistribusiBiayaBengkelReportPPT)
        If ds.Tables(0).Rows.Count > 0 Then
            objDistribusiBiayaBengkelReportPPT.AYear = cbYear.Text
            objDistribusiBiayaBengkelReportPPT.AMonth = cbMonth.SelectedValue.ToString
        Else
            MessageBox.Show("There is no record found", "BSP", MessageBoxButtons.OK)
            Exit Sub
        End If
 
        

        'Dim ds1 As New DataSet
        'ds1 = objDistribusiBiayaBengkelReportBOL.GetInterfaceYear(objDistribusiBiayaBengkelReportPPT)
        'If ds1.Tables.Count > 0 Then
        '    If ds1.Tables(0).Rows.Count > 0 Then
        '        cbYear.DataSource = ds1.Tables(0)
        '        cbYear.DisplayMember = "AYear"
        '        cbYear.ValueMember = "AYear"
        '    End If
        '    If ds1.Tables(1).Rows.Count > 0 Then

        '        cbMonth.DataSource = ds1.Tables(1)
        '        cbMonth.DisplayMember = "MONTH"
        '        cbMonth.ValueMember = "ActiveMonthYearID"
        '        'strActMthYearID = "ActiveMonthYearID"

        '    End If


        'End If
        'objDistribusiBiayaBengkelReportPPT.AMonth = cbMonth.SelectedValue
        'objDistribusiBiayaBengkelReportPPT.AYear = cbYear.Text
        objDistribusiBiayaBengkelReportPPT.Task = "Vehicle monthly processing"
        'strActMthYearID = cbMonth.SelectedValue.ToString

        ds = objDistribusiBiayaBengkelReportBOL.GetTaskComplete(objDistribusiBiayaBengkelReportPPT)

        If Not ds Is Nothing And ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "N" Then
                If MsgBox(rm.GetString("msg01"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then


                    ActiveMonthYearIDGet()

                    objDistribusiBiayaBengkelReportPPT.AMonth = cbMonth.SelectedValue
                    objDistribusiBiayaBengkelReportPPT.AYear = cbYear.Text
                    ds = objDistribusiBiayaBengkelReportBOL.GetFYearDate(objDistribusiBiayaBengkelReportPPT)
                    strFiscalYearFromDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                    strFiscalYearToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()

                    Dim childCR As New VehicleViewReport
                    childCR.strReportName = "DistribusiBiayaBengkelsReport"
                    childCR.Dock = DockStyle.Fill
                    strmonth = cbMonth.SelectedValue.ToString
                    strYear = cbYear.SelectedValue.ToString

                    childCR.Show()
                    strActMthYearID = String.Empty
                    strmonth = String.Empty
                    strYear = String.Empty
                    childCR.AutoScroll = True
                Else
                    Exit Sub
                End If
            ElseIf ds.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "Y" Then

                ActiveMonthYearIDGet()

                objDistribusiBiayaBengkelReportPPT.AMonth = cbMonth.SelectedValue
                objDistribusiBiayaBengkelReportPPT.AYear = cbYear.Text
                ds = objDistribusiBiayaBengkelReportBOL.GetFYearDate(objDistribusiBiayaBengkelReportPPT)
                strFiscalYearFromDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                strFiscalYearToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()

                Dim childCR As New VehicleViewReport
                childCR.strReportName = "DistribusiBiayaBengkelsReport"
                childCR.Dock = DockStyle.Fill
                strmonth = cbMonth.SelectedValue.ToString
                strYear = cbYear.SelectedValue.ToString
                childCR.Show()
                strActMthYearID = String.Empty
                strmonth = String.Empty
                strYear = String.Empty
                childCR.AutoScroll = True
            End If
        End If








        'Dim childCR As New VehicleViewReport
        'childCR.strReportName = "DistribusiBiayaBengkelsReport"
        'childCR.Dock = DockStyle.Fill
        'childCR.Show()
        'strActMthYearID = String.Empty
        'childCR.AutoScroll = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub ActiveMonthYearIDGet()
        Dim objDistribusiBiayaBengkelReportPPT As New DistribusiBiayaBengkelReportPPT
        Dim objDistribusiBiayaBengkelReportBOL As New DistribusiBiayaBengkelReportBOL
        Dim ds As New DataSet

        objDistribusiBiayaBengkelReportPPT.AYear = cbYear.Text
        objDistribusiBiayaBengkelReportPPT.AMonth = cbMonth.SelectedValue.ToString()

        ds = objDistribusiBiayaBengkelReportBOL.ActiveMonthYearIDGet(objDistribusiBiayaBengkelReportPPT)

        If ds.Tables(0).Rows.Count > 0 Then
            strActMthYearID = ds.Tables(0).Rows(0).Item("ActiveMonthYearID")
        End If

    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DistribusiBiayaBengkelReportFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DistribusiBiayaBengkelReportFrm))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            pnlDistribusiBiayaBengkelrpt.CaptionText = rm.GetString("pnlDistribusiBiayaBengkelrpt.CaptionText")
            lblsearchBy.Text = rm.GetString("lblsearchBy.Text")
            lblMonth.Text = rm.GetString("lblMonth.Text")
            lblYear.Text = rm.GetString("lblYear.Text")
            btnReport.Text = rm.GetString("btnReport.Text")
            btnClose.Text = rm.GetString("btnClose.Text")

        Catch

            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DistribusiBiayaBengkelReportFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class


