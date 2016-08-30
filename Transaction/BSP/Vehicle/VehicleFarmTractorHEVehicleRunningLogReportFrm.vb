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



Public Class VehicleFarmTractorHEVehicleRunningLogReportFrm

    Public Shared strActMthYearID As String = String.Empty
    Public Shared strmonth As String = String.Empty
    Public Shared strYear As String = String.Empty
    Public Shared strFiscalYearFromDate As String = String.Empty
    Public Shared strFiscalYearToDate As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleFarmTractorHEVehicleRunningLogReportFrm))


    Private Sub VehicleFarmTractorHEVehicleRunningLogReportFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        Dim ds As DataSet
        Dim objVehicleFarmTractorHEVehicleRunningLogReportPPT As New VehicleFarmTractorHEVehicleRunningLogReportPPT
        Dim objVehicleFarmTractorHEVehicleRunningLogReportBOL As New VehicleFarmTractorHEVehicleRunningLogReportBOL
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

        'ds = objVehicleFarmTractorHEVehicleRunningLogReportBOL.GetInterfaceYear(objVehicleFarmTractorHEVehicleRunningLogReportPPT)
        Dim objVehicleLedgerPPT As New VehicleLedgerPPT
        Dim objVehicleLedgerBOL As New VehicleLedgerBOL


        ds = objVehicleLedgerBOL.GetInterfaceYear(objVehicleLedgerPPT)

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

        'Dim dsVehicleMonthlyProcessing As New DataSet
        'Dim _VehicleMonthlyProcessingPPT As New Vehicle_PPT.VehicleMonthlyProcessingPPT

        Dim objVehicleFarmTractorHEVehicleRunningLogReportPPT As New VehicleFarmTractorHEVehicleRunningLogReportPPT
        Dim objVehicleFarmTractorHEVehicleRunningLogReportBOL As New VehicleFarmTractorHEVehicleRunningLogReportBOL
        Dim ds As New DataSet
        Dim complete As String = String.Empty

        ds = objVehicleFarmTractorHEVehicleRunningLogReportBOL.GetInterfaceYear(objVehicleFarmTractorHEVehicleRunningLogReportPPT)
        If ds.Tables(0).Rows.Count > 0 Then
            objVehicleFarmTractorHEVehicleRunningLogReportPPT.AMonth = cbMonth.SelectedValue
            objVehicleFarmTractorHEVehicleRunningLogReportPPT.AYear = cbYear.SelectedValue
        Else
            MessageBox.Show("There is no record found")
            Exit Sub
        End If

        
        objVehicleFarmTractorHEVehicleRunningLogReportPPT.Task = "Vehicle monthly processing"

        ds = objVehicleFarmTractorHEVehicleRunningLogReportBOL.GetTaskComplete(objVehicleFarmTractorHEVehicleRunningLogReportPPT)

        If Not ds Is Nothing And ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "N" Then
                If MsgBox(rm.GetString("msg01"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    ActiveMonthYearIDGet()

                    objVehicleFarmTractorHEVehicleRunningLogReportPPT.AMonth = cbMonth.SelectedValue
                    objVehicleFarmTractorHEVehicleRunningLogReportPPT.AYear = cbYear.Text
                    ds = objVehicleFarmTractorHEVehicleRunningLogReportBOL.GetFYearDate(objVehicleFarmTractorHEVehicleRunningLogReportPPT)
                    strFiscalYearFromDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                    strFiscalYearToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()


                    Dim childCR As New VehicleViewReportInTabRpt
                    'childCR.MdiParent = Me
                    childCR.strReportName = "VehicleFarmTractorHEVehicleRunningLogRpt"
                    childCR.Dock = DockStyle.Fill
                    strmonth = cbMonth.SelectedValue.ToString
                    strYear = cbYear.SelectedValue.ToString
                    childCR.Show()
                    'strActMthYearID = String.Empty
                Else
                    Exit Sub
                End If
            ElseIf ds.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "Y" Then

                ActiveMonthYearIDGet()

                objVehicleFarmTractorHEVehicleRunningLogReportPPT.AMonth = cbMonth.SelectedValue
                objVehicleFarmTractorHEVehicleRunningLogReportPPT.AYear = cbYear.Text
                ds = objVehicleFarmTractorHEVehicleRunningLogReportBOL.GetFYearDate(objVehicleFarmTractorHEVehicleRunningLogReportPPT)
                strFiscalYearFromDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                strFiscalYearToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()

                Dim childCR As New VehicleViewReportInTabRpt
                'childCR.MdiParent = Me
                childCR.strReportName = "VehicleFarmTractorHEVehicleRunningLogRpt"
                childCR.Dock = DockStyle.Fill
                strmonth = cbMonth.SelectedValue.ToString
                strYear = cbYear.SelectedValue.ToString
                childCR.Show()
                'strActMthYearID = String.Empty
            End If
        Else
            MsgBox("Record is not exist!", MsgBoxStyle.Information, "Information")
        End If






    End Sub
    Private Sub ActiveMonthYearIDGet()
        Dim objVehicleFarmTractorHEVehicleRunningLogReportPPT As New VehicleFarmTractorHEVehicleRunningLogReportPPT
        Dim objVehicleFarmTractorHEVehicleRunningLogReportBOL As New VehicleFarmTractorHEVehicleRunningLogReportBOL
        Dim ds As New DataSet

        objVehicleFarmTractorHEVehicleRunningLogReportPPT.AYear = cbYear.Text
        objVehicleFarmTractorHEVehicleRunningLogReportPPT.AMonth = cbMonth.SelectedValue.ToString

        ds = objVehicleFarmTractorHEVehicleRunningLogReportBOL.ActiveMonthYearIDGet(objVehicleFarmTractorHEVehicleRunningLogReportPPT)

        If ds.Tables(0).Rows.Count > 0 Then
            strActMthYearID = ds.Tables(0).Rows(0).Item("ActiveMonthYearID")
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleFarmTractorHEVehicleRunningLogReportFrm))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            pnlVehicleFarmTractorHEVehicleRunningLog.CaptionText = rm.GetString("pnlVehicleFarmTractorHEVehicleRunningLog.CaptionText")
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
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleFarmTractorHEVehicleRunningLogReportFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub VehicleFarmTractorHEVehicleRunningLogReportFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class