Imports Store_PPT
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

Public Class LaporanStockReportInterface
    Public Shared StrFrmName As String = String.Empty
    Public Shared strAmonth As String = String.Empty
    Public Shared strAYear As String = String.Empty
    Public Shared strmonname As String = String.Empty
    Public Shared strFrmDate As String = String.Empty
    Public Shared strToDate As String = String.Empty
    Public Shared strIsZero As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LaporanStockReportInterface))
    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Reportget()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub LaporanStockReportInterface_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        Dim ds As DataSet
        Dim objLaporanstockPPT As New LaporanstockPPT
        Dim objLaporanstockBOL As New LaporanstockBOL
        Dim Lmonth As String
        Dim LYear As String
        Chkzeroqtystock.Checked = False
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

        ds = objLaporanstockBOL.GetInterfaceYear(objLaporanstockPPT)

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
    Private Sub Reportget()


        Dim objLaporanstockPPT As New LaporanstockPPT
        Dim objLaporanstockBOL As New LaporanstockBOL
        Dim strsummaryname As String = String.Empty
        Dim ds As New DataSet
        Dim complete As String = String.Empty

        objLaporanstockPPT.AMonth = cbMonth.SelectedValue
        objLaporanstockPPT.AYear = cbYear.Text

        objLaporanstockPPT.Task = "Store monthly processing"
        ''strtask = "Estate/Mill Delivery note approval"


        ds = objLaporanstockBOL.GetTaskComplete(objLaporanstockPPT)

        If ds.Tables(0).Rows.Count > 0 Then
            complete = ds.Tables(0).Rows(0).Item("Complete").ToString()
        End If


        If complete = "N" Then

            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LaporanStockReportInterface))
            If MsgBox(rm.GetString("msg01"), MsgBoxStyle.YesNo) <> Windows.Forms.DialogResult.No Then
                StrFrmName = "Laporanstock"
                objLaporanstockPPT.AMonth = cbMonth.SelectedValue
                objLaporanstockPPT.AYear = cbYear.Text
                ds = objLaporanstockBOL.GetFYearDate(objLaporanstockPPT)
                strFrmDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                strToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()
                strAmonth = cbMonth.SelectedValue
                strAYear = cbYear.Text
                strmonname = cbMonth.SelectedValue
                If Chkzeroqtystock.Checked = True Then
                    strIsZero = "Y"
                Else
                    strIsZero = "N"
                End If
                StoreLaporanStockReportView.ShowDialog()
            Else
                Exit Sub
                complete = String.Empty
                '' MessageBox.Show("Some of Estate/Mill Delivery note  not approved, do you still want to preview the report YES/NO", "BSP", MessageBoxButtons.OKCancel, _
            End If

        Else

            objLaporanstockPPT.AMonth = cbMonth.SelectedValue
            objLaporanstockPPT.AYear = cbYear.Text
            ds = objLaporanstockBOL.GetFYearDate(objLaporanstockPPT)
            strFrmDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
            strToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()
            StoreLaporanStockReportView.stDate = strFrmDate
            StoreLaporanStockReportView.endDate = strToDate
            StrFrmName = "Laporanstock"
            strAmonth = cbMonth.SelectedValue
            strAYear = cbYear.Text
            If Chkzeroqtystock.Checked = True Then
                strIsZero = "Y"
            Else
                strIsZero = "N"
            End If
            StoreLaporanStockReportView.ShowDialog()
            ''ReportODBCMethod.ShowDialog()

        End If
    End Sub

         Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LaporanStockReportInterface))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            pnlLaporanstockRpt.CaptionText = rm.GetString("pnlLaporanstockRpt.CaptionText")
            lblsearchBy.Text = rm.GetString("lblsearchBy.Text")
            lblMonth.Text = rm.GetString("lblMonth.Text")
            lblYear.Text = rm.GetString("lblYear.Text")
            btnReport.Text = rm.GetString("btnReport.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            Chkzeroqtystock.Text = rm.GetString("Chkzeroqtystock.Text")

        Catch

            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LaporanStockReportInterface))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub LaporanStockReportInterface_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class