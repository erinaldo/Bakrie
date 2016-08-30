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

Public Class PPH21Monthly


    Dim FromDate As Date
    Dim ToDate As Date
    Dim lDivTypecheck As Boolean
    Dim lRepeatDate As Date
    Dim lRepeatStockCode As String
    Dim lRepeatDateCals As Decimal

    Private Sub MaterialUsageRptFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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


        Dim Months As New ArrayList

        'add month structure entries to the arraylist
        With Months
            .Add("JANUARY")
            .Add("FEBRUARY")
            .Add("MARCH")
            .Add("APRIL")
            .Add("MAY")
            .Add("JUNE")
            .Add("JULY")
            .Add("AUGUST")
            .Add("SEPTEMBER")
            .Add("OCTOBER")
            .Add("NOVEMBER")
            .Add("DECEMBER")
        End With

        cbMonth.DataSource = Months

        cbYear.SelectedValue = Date.Now.Year

        Select Case Date.Now.Month
            Case 1
                cbMonth.SelectedIndex = 0
            Case 2
                cbMonth.SelectedIndex = 1
            Case 3
                cbMonth.SelectedIndex = 2
            Case 4
                cbMonth.SelectedIndex = 3
            Case 5
                cbMonth.SelectedIndex = 4
            Case 6
                cbMonth.SelectedIndex = 5
            Case 7
                cbMonth.SelectedIndex = 6
            Case 8
                cbMonth.SelectedIndex = 7
            Case 9
                cbMonth.SelectedIndex = 8
            Case 10
                cbMonth.SelectedIndex = 9
            Case 11
                cbMonth.SelectedIndex = 10
            Case 12
                cbMonth.SelectedIndex = 11
        End Select

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ' If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        Me.Close()
        '  End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
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
            cmd.CommandText = "Checkroll.MonthlyTaxReport"
            cmd.CommandTimeout = 1800
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Amonth", Me.cbMonth.SelectedIndex + 1)
            cmd.Parameters.AddWithValue("@AYear", Me.cbYear.Text)
            cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
          
            Dim tblAdt As New SqlDataAdapter
            Dim ds As New DataSet
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "MonthlyTaxReport")

            Dim ReportDirectory As String = String.Empty
            xlApp = New Excel.Application

            Dim TemPath As String = Application.StartupPath & "\Reports\CheckRoll\Excel\MonthlyTaxReport.xls"
            If (File.Exists(TemPath)) Then
                xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\CheckRoll\Excel\MonthlyTaxReport.xls")
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

            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL

            lTextmonth = objCommonBOl.PMonthName((cbMonth.SelectedIndex) + 1, cbYear.Text, GlobalPPT.strLang)

            lTextmonth = " Material Tax Report for " & lTextmonth

            Dim StrPath As String = ""

            StrPath = "" & sDirName & "\BSP CheckRoll Reports\" & lTextmonth & ".xls"

            Dim lEstate As String
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            lEstate = strArray(1)

             If ds.Tables(0).Rows.Count < 1 Then
                MsgBox("No Records matching the given condition")
                Exit Sub
            End If

            Dim sheet As Excel.Worksheet
            sheet = xlWorkBook.Sheets("Sheet1")
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
            sheet.Cells.Clear()
            Dim row As DataRow
            Dim i As Integer = 1

            sheet.Cells(i, 1) = "Masa Pajak"
            sheet.Cells(i, 2) = "Tahun Pajak"
            sheet.Cells(i, 3) = "Pembetulan"
            sheet.Cells(i, 4) = "NPWP"
            sheet.Cells(i, 5) = "Nama"
            sheet.Cells(i, 6) = "Kode Pajak"
            sheet.Cells(i, 7) = "Jumlah Bruto"
            sheet.Cells(i, 8) = "Jumlah Pajak"
            sheet.Cells(i, 9) = "Kode Negara"
            i = 2

            For Each row In ds.Tables(0).Rows
                sheet.Cells(i, 1) = (cbMonth.SelectedIndex) + 1 'Masa Pajak
                sheet.Cells(i, 2) = cbYear.Text 'Masa Pajak
                sheet.Cells(i, 3) = 0 'Pembetulan
                If row("NPWP").ToString = "" Or row("NPWP").ToString = "NO" Or IsDBNull(row("NPWP")) Then
                    sheet.Cells(i, 4) = "'000000000000000"
                Else
                    sheet.Cells(i, 4) = row("NPWP").ToString
                End If
                'sheet.Cells(i, 4) = row("NPWP").ToString
                sheet.Cells(i, 5) = row("EmpCOde").ToString + " " + row("EmpName").ToString 'Nama
                sheet.Cells(i, 6) = "21-100-" + (i - 1).ToString 'KodePajak
                sheet.Cells(i, 7) = row("Bruto").ToString 'JumlahBruto
                sheet.Cells(i, 8) = row("Pajak").ToString 'JumlahPajak
                sheet.Cells(i, 9) = "INDONESIA" 'KodeNegara
                i = i + 1
            Next
         

            xlApp.Visible = True

            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If

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