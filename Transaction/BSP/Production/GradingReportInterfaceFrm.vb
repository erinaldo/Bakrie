Imports Production_PPT
Imports Production_BOL
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
Imports System.Runtime.InteropServices.Marshal
Imports System.Drawing.Printing
Imports BSP.LoginFrm

Public Class GradingReportInterfaceFrm
    Public Shared StrFrmName As String = String.Empty
    Public Shared strweiID As String = String.Empty
    Public Shared strAMYID As String = String.Empty
    Public Shared strGradingdate As Date
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GradingReportInterfaceFrm))

    Private Sub GradingReportInterfaceFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub GradingReportInterfaceFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dtpDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpDate.MaxDate = GlobalPPT.FiscalYearToDate
        Dim TempDate As Date = dtpDate.Value
        Dim NowDate As Date = Now()
        If Now() >= GlobalPPT.FiscalYearFromDate And dtpDate.Value <= GlobalPPT.FiscalYearFromDate Then
            dtpDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        End If

        If GlobalPPT.strLang <> "en" Then
            btnSearch.Text = "Mencari"
            btnClose.Text = "Tutup"
            ' btnviewReports.Text = "Lihat Laporan"
        End If
        '  SetUICulture(GlobalPPT.strLang)
        Dim ds As DataSet
        Dim objGradingReportPPT As New GradingReportPPT
        Dim Lmonth As String
        Dim LYear As String
        dtpDate.CustomFormat = "dd/MM/yyyy"
        Lmonth = GlobalPPT.IntLoginMonth
        LYear = GlobalPPT.intLoginYear

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

        ds = GradingReportBOL.GetInterfaceYear(objGradingReportPPT)

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
            Gridbind()
        End If
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Gridbind()

    End Sub
    Private Sub dgvGradingrpt_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGradingrpt.CellContentClick

        Dim objGradingReportPPT As New GradingReportPPT

        If e.ColumnIndex = 5 Then
            'Dim ReportDate As Date
            'Dim RptDate() As String
            'Dim Gradingdate As String
            'Gradingdate = dgvGradingrpt.SelectedRows(0).Cells("GradingDate").Value
            'RptDate = Gradingdate.Split("/")
            'ReportDate = RptDate(1) + "/" + RptDate(0) + "/" + RptDate(2)
            'ReportDate = Convert.ToDateTime(Gradingdate).ToString("dd/MM/yyyy")
            'strGradingdate = ReportDate
            strweiID = dgvGradingrpt.SelectedRows(0).Cells("WeighingID").Value
            strAMYID = dgvGradingrpt.SelectedRows(0).Cells("ActiveMonthYearID").Value
            'StrFrmName = "Gradingrpt"
            'ProductionReportODBCMethod.ShowDialog()

            Dim reportData As New ReportData
            reportData.ReportSource = "Reports\Production\" & "GradingReportNew.rpt"
            Dim par1 As New ReportData.ReportParameter
            par1.Name = "EstateID"
            par1.Value = GlobalPPT.strEstateID
            Dim par2 As New ReportData.ReportParameter
            par2.Name = "WeighingID"
            par2.Value = strweiID

            reportData.Parameters = New List(Of ReportData.ReportParameter)
            reportData.Parameters.Add(par1)
            reportData.Parameters.Add(par2)

            Dim reportViewer As New CRViewer(reportData)
            reportViewer.ShowDialog()

        End If

    End Sub
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

    Private Sub Gridbind()

        Dim objGradingReportPPT As New GradingReportPPT
        Dim dt As DataTable
        dtpDate.CustomFormat = "dd/MM/yyyy"

        If Not (cbMonth.Text = "" Or cbYear.Text = "") Then
            With objGradingReportPPT
                .AMonth = cbMonth.SelectedValue
                .AYear = cbYear.Text
                If txtWBTicketno.Text.Trim = String.Empty Then
                    .WBTicketNo = String.Empty
                Else
                    .WBTicketNo = txtWBTicketno.Text.Trim
                End If
                If Chkdate.Checked = True Then
                    .BGradingDate = True
                Else
                    .BGradingDate = False
                End If
                .GradingDate = dtpDate.Value
            End With

            dt = GradingReportBOL.GetWBTicketNo(objGradingReportPPT)
            If dt.Rows.Count > 0 Then
                dgvGradingrpt.AutoGenerateColumns = False
                dgvGradingrpt.DataSource = dt
            Else
                dgvGradingrpt.AutoGenerateColumns = False
                dgvGradingrpt.DataSource = dt
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("There is no Record Found")
            End If
        End If
       

      

    End Sub
    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GradingReportInterfaceFrm))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            pnlGradingreport.CaptionText = rm.GetString("pnlGradingreport.CaptionText")
            lblsearchBy.Text = rm.GetString("lblsearchBy.Text")
            lblMonth.Text = rm.GetString("lblMonth.Text")
            lblYear.Text = rm.GetString("lblYear.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            Chkdate.Text = rm.GetString("Chkdate.Text")
            lblWBTicketNo.Text = rm.GetString("lblWBTicketNo.Text")

        Catch

            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GradingReportInterfaceFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
 
End Class