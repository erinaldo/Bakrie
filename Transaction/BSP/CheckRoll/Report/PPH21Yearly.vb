Imports CheckRoll_BOL
Imports Common_PPT
Imports Common_BOL
Imports Common_DAL
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal

Public Class PPH21Yearly


    Dim FromDate As Date
    Dim ToDate As Date
    Dim lDivTypecheck As Boolean
    Dim lRepeatDate As Date
    Dim lRepeatStockCode As String
    Dim lRepeatDateCals As Decimal

    Private Sub MaterialUsageRptFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtTanggalDTP.Text = Today
        GetInterface()

    End Sub

    Private Sub GetInterface()

        Dim ds As New DataSet

        Dim objMaterialUsageReportDAL As New MaterialUsageReport_BOL
        ds = objMaterialUsageReportDAL.GetInterfaceYear()
        If ds.Tables(0).Rows.Count > 0 Then
            cbYear.DataSource = ds.Tables(0)
            cbYear.DisplayMember = "AYear"
            cbYear.ValueMember = "AYear"
        End If
        Me.cbYear.Text = Year(Today)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ' If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        Me.Close()
        '  End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If Me.txtNama.Text = "" Then
            MsgBox("Please enter Nama", vbInformation)
            Exit Sub
        End If
        If Me.txtNPWP.Text = "" Then
            MsgBox("Please enter NPWP", vbInformation)
            Exit Sub
        End If
        If Me.txtTanggalDTP.Text = "" Then
            MsgBox("Please enter Tanggal Potongan", vbInformation)
            exit sub
        End If
        Dim fMsg As New ProgressingFrm
        Try
            fMsg.TopMost = True
            fMsg.Show()

            fMsg.lblTitle.Refresh()
            fMsg.lblTitle.Text = "Processing Tax Summary"
            fMsg.lblTitle.Refresh()

            Cursor = Cursors.WaitCursor

            'to fix an Excel bug need to change the culture info
            Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim strServerUserName As String = String.Empty
            Dim strServerPassword As String = String.Empty
            Dim strDSN As String = String.Empty
            Dim StrInitialCatlog As String = String.Empty
            Dim MaterialusageFlag As Boolean = True

            strDSN = GlobalPPT.SelectedDB.DSN
            strServerUserName = GlobalPPT.SelectedDB.User
            strServerPassword = GlobalPPT.SelectedDB.Password
            StrInitialCatlog = GlobalPPT.SelectedDB.DBName

            Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim cmd1 As New SqlCommand
            Dim da As New SqlDataAdapter
            con = New SqlConnection(constr)

            con.Open()

            cmd.Connection = con
            cmd.CommandText = "Checkroll.YearlyTaxReport"
            cmd.CommandTimeout = 1800
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AYear", Me.cbYear.Text)
            cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)

            Dim tblAdt As New SqlDataAdapter
            Dim ds As New DataSet
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "YearlyTaxReport")

            Dim ReportDirectory As String = String.Empty
            xlApp = New Excel.Application

            Dim TemPath As String = Application.StartupPath & "\Reports\CheckRoll\Excel\YearlyTaxReport.xls"
            If (File.Exists(TemPath)) Then
                xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\CheckRoll\Excel\YearlyTaxReport.xls")
            Else
                MsgBox("Tax report template missing.Please contact system administrator.")
                Exit Sub
            End If

            ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

            Dim sDirName As String
            sDirName = ReportDirectory + ":"
            Dim dDir As New DirectoryInfo(sDirName)

            If Not dDir.Exists Then
                MessageBox.Show("Report directory not found", "BSP")
                Exit Sub
            End If

            Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP CheckRoll Reports")
            ' Determine whether the directory exists.
            If Not di.Exists Then
                di.Create()
            End If


            If ds.Tables(0).Rows.Count < 1 Then
                MsgBox("No Records matching the given condition")
                Exit Sub
            End If
            xlApp.ScreenUpdating = False
            Dim sheet As Excel.Worksheet
            sheet = xlWorkBook.Sheets("Sheet1")
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
            sheet.Cells.Clear()
            Dim row As DataRow
            Dim i As Integer = 1
            'Populate Headers First

            sheet.Cells(i, 1) = "Masa Pajak"
            sheet.Cells(i, 2) = "Tahun Pajak"
            sheet.Cells(i, 3) = "Pembetulan"
            sheet.Cells(i, 4) = "Nomor Bukti Potong"
            sheet.Cells(i, 5) = "Masa Perolehan Awal"
            sheet.Cells(i, 6) = "Masa Perolehan Akhir"
            sheet.Cells(i, 7) = "NPWP"
            sheet.Cells(i, 8) = "NIK"
            sheet.Cells(i, 9) = "Nama"
            sheet.Cells(i, 10) = "Alamat"
            sheet.Cells(i, 11) = "Jenis Kelamin"
            sheet.Cells(i, 12) = "Status PTKP"
            sheet.Cells(i, 13) = "Jumlah Tanggungan"
            sheet.Cells(i, 14) = "Nama Jabatan"
            sheet.Cells(i, 15) = "WP Luar Negeri"
            sheet.Cells(i, 16) = "Kode Negara"
            sheet.Cells(i, 17) = "Kode Pajak"
            sheet.Cells(i, 18) = "Jumlah1"
            sheet.Cells(i, 19) = "Jumlah2"
            sheet.Cells(i, 20) = "Jumlah3"
            sheet.Cells(i, 21) = "Jumlah4"
            sheet.Cells(i, 22) = "Jumlah5"
            sheet.Cells(i, 23) = "Jumlah6"
            sheet.Cells(i, 24) = "Jumlah7"
            sheet.Cells(i, 25) = "Jumlah8"
            sheet.Cells(i, 26) = "Jumlah9"
            sheet.Cells(i, 27) = "Jumlah10"
            sheet.Cells(i, 28) = "Jumlah11"
            sheet.Cells(i, 29) = "Jumlah12"
            sheet.Cells(i, 30) = "Jumlah13"
            sheet.Cells(i, 31) = "Jumlah14"
            sheet.Cells(i, 32) = "Jumlah15" 'Jumlah(15)
            sheet.Cells(i, 33) = "Jumlah16" 'Jumlah(16)
            sheet.Cells(i, 34) = "Jumlah17" 'Jumlah(17)
            sheet.Cells(i, 35) = "Jumlah18" 'Jumlah(18)
            sheet.Cells(i, 36) = "Jumlah19" 'Jumlah(19)
            sheet.Cells(i, 37) = "Jumlah20" 'Jumlah(20)
            sheet.Cells(i, 38) = "Status"
            sheet.Cells(i, 39) = "NPWP Pemotong"
            sheet.Cells(i, 40) = "Nama Pemotong"
            sheet.Cells(i, 41) = "Tanggal Bukti Potong"
            i = 2

            For Each row In ds.Tables(0).Rows
                sheet.Cells(i, 1) = 12 '    Masa(Pajak)
                sheet.Cells(i, 2) = cbYear.Text 'Tahun(Pajak)
                sheet.Cells(i, 3) = 0 'Pembetulan()
                sheet.Cells(i, 4) = "" 'Nomor Bukti Potong
                sheet.Cells(i, 5) = "" 'Masa Perolehan Awal
                sheet.Cells(i, 6) = "" 'Masa Perolehan Akhir
                sheet.Cells(i, 7) = row("NPWP").ToString 'NPWP()
                sheet.Cells(i, 8) = row("EmpCode").ToString 'NIK()
                sheet.Cells(i, 9) = row("EmpName") 'Nama()
                sheet.Cells(i, 10) = row("HomeAdd1") 'Alamat()
                sheet.Cells(i, 11) = row("Gender") 'Jenis(Kelamin)
                sheet.Cells(i, 12) = row("MaritalStatus") 'Status(PTKP)
                sheet.Cells(i, 13) = row("NoofChildrenForTax") 'Jumlah(Tanggungan)
                sheet.Cells(i, 14) = row("OEEmplocation") 'Nama(Jabatan)
                sheet.Cells(i, 15) = "" 'WP Luar Negeri
                sheet.Cells(i, 16) = "" 'Kode(Negara)
                sheet.Cells(i, 17) = "" 'Kode(Pajak)
                sheet.Cells(i, 18) = row("Jumlah1").ToString 'Jumlah(1)
                sheet.Cells(i, 19) = row("Jumlah2").ToString 'Jumlah(2)
                sheet.Cells(i, 20) = row("Jumlah3").ToString 'Jumlah(3)
                sheet.Cells(i, 21) = row("Jumlah4").ToString 'Jumlah(4)
                sheet.Cells(i, 22) = row("Jumlah5").ToString 'Jumlah(5)
                sheet.Cells(i, 23) = row("Jumlah6").ToString 'Jumlah(6)
                sheet.Cells(i, 24) = row("Jumlah7").ToString 'Jumlah(7)
                sheet.Cells(i, 25) = row("Jumlah8").ToString 'Jumlah(8)
                sheet.Cells(i, 26) = row("Jumlah9").ToString 'Jumlah(9)
                sheet.Cells(i, 27) = row("Jumlah10").ToString 'Jumlah(10)
                sheet.Cells(i, 28) = row("Jumlah11").ToString 'Jumlah(11)
                sheet.Cells(i, 29) = row("Jumlah12").ToString 'Jumlah(12)
                sheet.Cells(i, 30) = "" 'Jumlah(13)
                sheet.Cells(i, 31) = "" 'Jumlah(14)
                sheet.Cells(i, 32) = "" 'Jumlah(15)
                sheet.Cells(i, 33) = "" 'Jumlah(16)
                sheet.Cells(i, 34) = "" 'Jumlah(17)
                sheet.Cells(i, 35) = "" 'Jumlah(18)
                sheet.Cells(i, 36) = "" 'Jumlah(19)
                sheet.Cells(i, 37) = "" 'Jumlah(20)
                sheet.Cells(i, 38) = row("Status") 'Status(Pindah)
                sheet.Cells(i, 39) = Me.txtNama.Text
                sheet.Cells(i, 40) = Me.txtNPWP.Text
                sheet.Cells(i, 41) = Me.txtTanggalDTP.Text
                i = i + 1
            Next

            xlApp.ScreenUpdating = True
            xlApp.Visible = True

            ' put CultureInfo back to original
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
            fMsg.Close()
        End Try
    End Sub



End Class