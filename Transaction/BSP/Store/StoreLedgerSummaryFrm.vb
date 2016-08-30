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

Public Class StoreLedgerSummaryFrm

    Public Shared strActMthYearID As String = String.Empty
    Public Shared Intmonth As Integer
    Public Shared IntYear As Integer
    Public Shared strFiscalYearFromDate As String = String.Empty
    Public Shared strFiscalYearToDate As String = String.Empty

    Public Shared strTask As String = String.Empty

    Public psMenuID As String = String.Empty
    Shadows mdiparent As New MDIParent
    Public Shared modid As New Integer


    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StoreLedgerSummaryFrm))


    Private Sub StoreLedgerSummaryFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)

        psMenuID = mdiparent.strMenuID

        Dim ds As DataSet
        Dim objVehicleLedgerPPT As New VehicleLedgerPPT
        Dim objVehicleLedgerBOL As New VehicleLedgerBOL
        Dim Lmonth As String
        Dim LYear As String

        'If psMenuID = "M286" Then

        modid = 2
        objVehicleLedgerPPT.ModID = "2"

        If GlobalPPT.strLang = "en" Then
            pnlVehicleLedger.CaptionText = "Store Ledger Summary Report"
        ElseIf GlobalPPT.strLang = "ms" Then
            pnlVehicleLedger.CaptionText = "Laporan Ringkasan Ledger Store"
        End If

        'ElseIf psMenuID = "M107" Then
        '    modid = 6
        '    objVehicleLedgerPPT.ModID = "6"



        '    If GlobalPPT.strLang = "en" Then
        '        pnlVehicleLedger.CaptionText = "Accounts Ledger Report"
        '    ElseIf GlobalPPT.strLang = "ms" Then
        '        pnlVehicleLedger.CaptionText = "Account Ledger Laporan"
        '    End If
        'ElseIf psMenuID = "M78" Then
        '    modid = 3

        '    objVehicleLedgerPPT.ModID = "3"



        '    If GlobalPPT.strLang = "en" Then
        '        pnlVehicleLedger.CaptionText = "Vehicle Ledger Report"
        '    ElseIf GlobalPPT.strLang = "ms" Then
        '        pnlVehicleLedger.CaptionText = "Kendaraan Ledger Laporan"
        '    End If
        'End If

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

    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleLedgerFrm))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            lblsearchBy.Text = rm.GetString("lblsearchBy.Text")
            lblMonth.Text = rm.GetString("lblMonth.Text")
            lblYear.Text = rm.GetString("lblYear.Text")
            btnReport.Text = rm.GetString("btnReport.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            '  pnlVehicleLedger.CaptionText = rm.GetString("pnlVehicleLedger.CaptionText")

        Catch

            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleLedgerFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")

    End Sub

    Private Sub StoreLedgerSummaryFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

    Private Sub ActiveMonthYearIDGet()

        Dim objVehicleLedgerPPT As New VehicleLedgerPPT
        Dim objVehicleLedgerBOL As New VehicleLedgerBOL

        Dim ds As New DataSet

        If cbMonth.Text <> "" Then
            objVehicleLedgerPPT.AYear = cbYear.Text
        Else
            Exit Sub
        End If

        If cbMonth.Text <> "" Then
            objVehicleLedgerPPT.AMonth = cbMonth.SelectedValue.ToString
        Else
            Exit Sub
        End If

        ds = objVehicleLedgerBOL.ActiveMonthYearIDGet(objVehicleLedgerPPT)

        If ds.Tables(0).Rows.Count > 0 Then
            strActMthYearID = ds.Tables(0).Rows(0).Item("ActiveMonthYearID")
        End If

    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim objVehicleLedgerPPT As New VehicleLedgerPPT
        Dim objVehicleLedgerBOL As New VehicleLedgerBOL

        Dim ds As New DataSet

        ActiveMonthYearIDGet()

        If cbMonth.Text <> "" Then
            objVehicleLedgerPPT.AMonth = cbMonth.SelectedValue
        Else
            MessageBox.Show("There is no record(s) to display.", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If cbYear.Text <> "" Then
            objVehicleLedgerPPT.AYear = cbYear.SelectedValue
        Else
            MessageBox.Show("There is no record(s) to display.", "BSP", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Exit Sub
        End If

        objVehicleLedgerPPT.ModID = modid
        objVehicleLedgerPPT.strActMthYearID = strActMthYearID

        ds = objVehicleLedgerBOL.GetTaskComplete(objVehicleLedgerPPT)

        If GlobalPPT.strLang = "en" Then

            If ds.Tables(0).Rows(0).Item("Complete").ToString = "N" Then
                If Not (MessageBox.Show("Store month end closing NOT done? Still Want to see the Report, If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

                    Exit Sub
                End If
            End If
          
        Else

            If ds.Tables(0).Rows(0).Item("Complete").ToString = "N" Then
                If Not (MessageBox.Show("akhir bulan penutupan toko TIDAK dilakukan? Masih Ingin melihat Laporan, Jika ya silahkan klik 'OK' atau klik 'Batal'", "konfirmasi", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

                    Exit Sub
                End If
            End If
       
        End If

        'objVehicleLedgerPPT.AMonth = cbMonth.SelectedValue
        'objVehicleLedgerPPT.AYear = cbYear.Text
        'ds = objVehicleLedgerBOL.GetFYearDate(objVehicleLedgerPPT)
        'strFiscalYearFromDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
        'strFiscalYearToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()

        Intmonth = cbMonth.SelectedValue
        IntYear = cbYear.SelectedValue

        Cursor = Cursors.WaitCursor
        StoreLedgerSummaryReportView.ShowDialog()
        Cursor = Cursors.Arrow

    End Sub

End Class