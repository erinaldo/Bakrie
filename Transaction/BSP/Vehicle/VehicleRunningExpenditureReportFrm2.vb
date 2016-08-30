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
Imports Store_PPT
Imports Store_BOL

Public Class VehicleRunningExpenditureReportFrm2

    Public Shared strActMthYearID As String = String.Empty
    Public Shared strmonth As String = String.Empty
    Public Shared strYear As String = String.Empty
    Public Shared strFiscalYearFromDate As String = String.Empty
    Public Shared strFiscalYearToDate As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningExpenditureReportFrm2))

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub VehicleRunningExpenditureReportFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        Dim ds As DataSet

        Dim objVehicleRunningExpenditureReportPPT As New VehicleRunningExpenditureReportPPT
        Dim objVehicleRunningExpenditureReportBOL As New VehicleRunningExpenditureReportBOL
        Dim o As New VehicleRunningExpenditureReport
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

        ds = objVehicleRunningExpenditureReportBOL.GetInterfaceYear(objVehicleRunningExpenditureReportPPT)

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

        BindVHDetailCostCode
    End Sub

    Private Sub BindVHDetailCostCode()
        Dim objVHDetailsCostCodePPT As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        objVHDetailsCostCodePPT.VHDetailCostCode = ""
        objVHDetailsCostCodePPT.VHDetailCostDesc = ""
        objVHDetailsCostCodePPT.Type = "V"
        ds = StoreIssueVoucherBOL.GetVHDetailsCostCode(objVHDetailsCostCodePPT, "NO")
        Me.lstDetailCostCode.DataSource = ds.Tables(0)
        Me.lstDetailCostCode.DisplayMember = "VHDescp"
        Me.lstDetailCostCode.ValueMember = "VHDetailCostCode"
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim objVehicleRunningExpenditureReportPPT As New VehicleRunningExpenditureReportPPT
        Dim objVehicleRunningExpenditureReportBOL As New VehicleRunningExpenditureReportBOL
        Dim ds As New DataSet

        Dim dsVehicleMonthlyProcessing As New DataSet
        Dim _VehicleMonthlyProcessingPPT As New Vehicle_PPT.VehicleMonthlyProcessingPPT

        ds = objVehicleRunningExpenditureReportBOL.GetInterfaceYear(objVehicleRunningExpenditureReportPPT)

        If ds.Tables(0).Rows.Count > 0 Then
            objVehicleRunningExpenditureReportPPT.AMonth = cbMonth.SelectedValue
            objVehicleRunningExpenditureReportPPT.AYear = cbYear.Text
        Else
            MessageBox.Show("There is no record found")
            Exit Sub
        End If


        objVehicleRunningExpenditureReportPPT.Task = "Vehicle monthly processing"
        'dsVehicleMonthlyProcessing = Vehicle_BOL.VehicleMonthlyProcessingBOL.TaskMonitorStatusGet(_VehicleMonthlyProcessingPPT)
        dsVehicleMonthlyProcessing = objVehicleRunningExpenditureReportBOL.GetTaskComplete(objVehicleRunningExpenditureReportPPT)


        If Not dsVehicleMonthlyProcessing Is Nothing And dsVehicleMonthlyProcessing.Tables(0).Rows.Count > 0 Then
            If dsVehicleMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "N" Then
                If MsgBox(rm.GetString("msg01"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

                    ActiveMonthYearIDGet()



                    objVehicleRunningExpenditureReportPPT.AMonth = cbMonth.SelectedValue
                    objVehicleRunningExpenditureReportPPT.AYear = cbYear.Text
                    ds = objVehicleRunningExpenditureReportBOL.GetFYearDate(objVehicleRunningExpenditureReportPPT)
                    strFiscalYearFromDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                    strFiscalYearToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()


                    Dim childCR As New VehicleViewReport
                    'childCR.MdiParent = Me
                    childCR.strReportName = "VehicleRunningExpenditureReportByCostCode"
                    childCR.Dock = DockStyle.Fill
                    strmonth = cbMonth.SelectedValue.ToString
                    strYear = cbYear.SelectedValue.ToString
                    childCR.Show()

                    strActMthYearID = String.Empty
                    strmonth = String.Empty
                    strYear = String.Empty
                    strFiscalYearFromDate = String.Empty
                    strFiscalYearToDate = String.Empty

                Else
                    Exit Sub
                End If
            ElseIf dsVehicleMonthlyProcessing.Tables(0).Rows(0).Item("Complete").ToString.ToUpper = "Y" Then

                ActiveMonthYearIDGet()


                objVehicleRunningExpenditureReportPPT.AMonth = cbMonth.SelectedValue
                objVehicleRunningExpenditureReportPPT.AYear = cbYear.Text
                ds = objVehicleRunningExpenditureReportBOL.GetFYearDate(objVehicleRunningExpenditureReportPPT)
                strFiscalYearFromDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                strFiscalYearToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()



                Dim childCR As New VehicleViewReport
                'childCR.MdiParent = Me
                childCR.strReportName = "VehicleRunningExpenditureReportByCostCode"
                childCR.Dock = DockStyle.Fill
                strmonth = cbMonth.SelectedValue.ToString
                strYear = cbYear.SelectedValue.ToString
                childCR.Show()
                strActMthYearID = String.Empty
                strmonth = String.Empty
                strYear = String.Empty
                strFiscalYearFromDate = String.Empty
                strFiscalYearToDate = String.Empty

            End If
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
    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningExpenditureReportFrm))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            pnlVehicleRunningExpenditureReport.CaptionText = rm.GetString("pnlVehicleRunningExpenditureReport.CaptionText")
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
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleRunningExpenditureReportFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub VehicleRunningExpenditureReportFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class