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
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.Drawing.Printing
Public Class AdviceofPKOLoadingRptFrm
    Dim xlApp As Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim sheet As Excel.Worksheet
    Dim cCell As Excel.Range
    Dim cRow As Excel.Range

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchPKOLoading()
    End Sub

    Private Sub AdviceofPKOLoadingRptFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblView.Visible = False
        If GlobalPPT.strLang <> "en" Then
            btnSearch.Text = "Mencari"
            btnClose.Text = "Tutup"
            ' btnviewReports.Text = "Lihat Laporan"
        End If
        SearchPKOLoading()
        dtpPKODate.Enabled = False
    End Sub

    Private Sub SearchPKOLoading()
        Dim ObjDispatchPPT As New DispatchPPT
        ObjDispatchPPT.BAPNo = txtBAPNo.Text
        dtpPKODate.Format = DateTimePickerFormat.Custom
        dtpPKODate.CustomFormat = "dd/MM/yyyy"

        If chkPKOdate.Checked = True Then
            ObjDispatchPPT.lDispatchDate = dtpPKODate.Value
        Else
            ObjDispatchPPT.lDispatchDate = ""
        End If

        Dim ds As New DataSet
        ds = DispatchBOL.GetPKOLoading(ObjDispatchPPT)
        If ds.Tables(0).Rows.Count > 0 Then
            dgvPKOLoading.DataSource = ds.Tables(0)
            dgvPKOLoading.AutoGenerateColumns = False
            lblView.Visible = False
        Else
            dgvPKOLoading.DataSource = ds.Tables(0)
            dgvPKOLoading.AutoGenerateColumns = False
            lblView.Visible = True
        End If
    End Sub

    Private Sub dgvPKOLoading_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPKOLoading.CellContentClick
        If e.ColumnIndex = 0 And dgvPKOLoading.Rows.Count > 0 Then
            Dim strMonthlyProdRptName As String = String.Empty
            Dim Logmonth As String = String.Empty
            Dim Datestr, DateMn, DateYr As Integer
            Dim Datestr1, DateMn1 As String
            Datestr = Date.Today.Day
            DateMn = Date.Today.Month
            DateYr = Date.Today.Year
            If Datestr < 10 Then
                Datestr1 = "0" + CStr(Datestr)
            Else
                Datestr1 = CStr(Datestr)
            End If
            If DateMn < 10 Then
                DateMn1 = "0" + CStr(DateMn)
            Else
                DateMn1 = CStr(DateMn)
            End If
            Logmonth = dgvPKOLoading.SelectedRows(0).Cells("dgclDispatchDate").Value
            ' Logmonth = "_" & Datestr1 & "" & DateMn1 & "" & DateYr & " "
            strMonthlyProdRptName = "ADVICE OF PKO LOADING REPORT - " & Logmonth & ""



            Dim ds As DataSet
            Dim ObjDispatchPPT As New DispatchPPT
            xlApp = New Excel.Application

            Dim ReportDirectory As String = String.Empty
            Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\TransportDeptPKO_Template.xls"

            If (File.Exists(TemPath)) Then
                xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\TransportDeptPKO_Template.xls")
            Else
                MsgBox("Advice of PKO loading report template missing.Please contact system administrator.")
                Cursor = Cursors.Arrow
                Exit Sub
            End If

            ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

            Dim sDirName As String
            sDirName = ReportDirectory + ":"
            Dim dDir As New DirectoryInfo(sDirName)

            If Not dDir.Exists Then
                MessageBox.Show("Report directory not found", "BSP")
                Cursor = Cursors.Arrow
                Exit Sub
            End If

            Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Production Reports")
            ' Determine whether the directory exists.
            If Not di.Exists Then
                di.Create()
            End If

            xlApp.Visible = True
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

            ObjDispatchPPT.DispatchID = dgvPKOLoading.SelectedRows(0).Cells("dgclDispatchID").Value.ToString()
            ds = DispatchBOL.CPOLoading_Reporting(ObjDispatchPPT)


            Dim intRowCount As Integer
            Dim lEstateName As String
            Dim lBAPNo As String
            Dim lDate As String
            Dim lShipPontoon As String

            'Dim con As New SqlConnection("Data Source=SQLSERVER;Initial Catalog=BSP; User =sa; Password =sql2008")
            'Dim strSelect = "select Store.STMaster.StockCode,Store.STMaster.PartNo,Store.STMaster.UnitPrice,General .UOM.UOM ,Store.StockDetail.BFQty as OpeningQTY ,Store.StockDetail.BFValue as OpeningValue ,Store.StockDetail.IDNQty as ReceivedQty,Store.StockDetail.IDNValue as ReceivedValue,Store.StockDetail.SIVQty as IssuedQTy ,Store.StockDetail.SIVValue as IssuedValue from Store.STMaster left outer join Store.StockDetail on Store.STMaster.StockID =Store.StockDetail.StockID  left outer join General.UOM on Store.STMaster.UOMID =General.UOM.UOMID  where Store.STMaster.EstateID=Store.StockDetail.EstateID  and Store.StockDetail.ActiveMonthYearID='01R17'"
            'con.Open()
            'Dim cmd As New SqlCommand(strSelect, con)
            'Dim dr As DataRow
            'dr = cmd.ExecuteReader()
            'Sno = 1 ShipPontoon
            intRowCount = 11
            lEstateName = ds.Tables(0).Rows(0).Item("EstateName").ToString
            lBAPNo = ds.Tables(0).Rows(0).Item("BAPNo").ToString
            lDate = Format(System.DateTime.Now, "dd/MM/yyyy")
            lShipPontoon = ds.Tables(0).Rows(0).Item("ShipPontoon").ToString
            sheet.Cells(4, 2) = "Estate/Mill :" & lEstateName & " "
            sheet.Cells(4, 4) = "Date :" & lDate & " "
            sheet.Cells(8, 2) = strMonthlyProdRptName
            sheet.Cells(10, 2) = "BAP No :" & lBAPNo & " "
            sheet.Cells(12, 2) = "NAME OF SHIP/PONTON :" & lShipPontoon & " "
            sheet.Cells(14, 2) = "Date of arrived at the estate"
            sheet.Cells(15, 2) = "Date of Commenced Loading"
            sheet.Cells(16, 2) = "Date of Completed loading"
            sheet.Cells(17, 2) = "Date of Departure"
            sheet.Cells(14, 3) = ds.Tables(0).Rows(0).Item("DOA").ToString
            sheet.Cells(15, 3) = ds.Tables(0).Rows(0).Item("DOL").ToString
            sheet.Cells(16, 3) = ds.Tables(0).Rows(0).Item("DCL").ToString
            sheet.Cells(17, 3) = ds.Tables(0).Rows(0).Item("DepartureDate").ToString
            sheet.Cells(14, 4) = ds.Tables(0).Rows(0).Item("DOATime").ToString
            sheet.Cells(15, 4) = ds.Tables(0).Rows(0).Item("DOLTime").ToString
            sheet.Cells(16, 4) = ds.Tables(0).Rows(0).Item("DCLTime").ToString
            sheet.Cells(17, 4) = ds.Tables(0).Rows(0).Item("DepartureTime").ToString

            strMonthlyProdRptName = strMonthlyProdRptName.Replace("/", "-")
            Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"



            sheet.Protect("RANNBSP@2010")
            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkPKOdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPKOdate.CheckedChanged
        If chkPKOdate.Checked = True Then
            dtpPKODate.Enabled = True
        Else
            dtpPKODate.Enabled = False
        End If
    End Sub

    Private Sub AdviceofPKOLoadingRptFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class