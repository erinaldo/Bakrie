Imports Production_BOL
Imports Production_PPT
Imports System.Collections
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports Common_BOL
Imports Common_PPT
Imports System.IO

Public Class DailyProductionReportKCPFrm

    Private Sub DailyProductionReportKCPFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub DailyProductionReportKCPFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ToDate As Date = Date.Today
        dtpDailyProdKCPDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        If GlobalPPT.strLang <> "en" Then
            '  btnSearch.Text = "Mencari"
            btnClose.Text = "Tutup"
            btnSearch.Text = "Lihat Laporan"
        End If

    End Sub
    'Private Sub BindDategrid()
    '    Dim dsDate As New DataSet
    '    Dim objDailyProductionPPT As New DailyProductionKCPPPT
    '    objDailyProductionPPT.ProductionDate = dtpDailyProdKCPDate.Value
    '    Dim LoadorSearch As String
    '    If chKCPDate.Checked = False Then
    '        LoadorSearch = "Load"
    '    Else
    '        LoadorSearch = "Search"
    '    End If


    '    dsDate = DailyProductionKCPBOL.DailyProductionKCPDateSelect(objDailyProductionPPT, LoadorSearch)

    '    If dsDate.Tables(0).Rows.Count <> 0 Then
    '        dgvKCP.AutoGenerateColumns = False
    '        dgvKCP.DataSource = dsDate.Tables(0)

    '    End If
    'End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        Me.Close()
        ' End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet

        'Try

        Dim strMonthlyProdRptName As String = String.Empty
        Dim ReportDirectory As String = String.Empty

        Dim ObjDailyProductionKCPPPT As New DailyProductionKCPPPT


        ObjDailyProductionKCPPPT.ProductionDate = dtpDailyProdKCPDate.Value


        xlApp = New Excel.Application
        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\DailyProductionReportKCP_Template.xls"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\DailyProductionReportKCP_Template.xls")
        Else
            MsgBox("Daily production report KCP template missing.Please contact system administrator.")
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



        sheet = xlWorkBook.Sheets("Sheet1")
        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

        Dim objCommonBOl As New GlobalBOL
        Dim Logmonth As String = String.Empty
        Dim Datestr, DateMn, DateYr As Integer
        Dim Datestr1, DateMn1 As String
        Dim ProdDate As Date
        ProdDate = dtpDailyProdKCPDate.Value
        Datestr = ProdDate.Day
        DateMn = ProdDate.Month
        DateYr = ProdDate.Year
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

        Logmonth = Format(dtpDailyProdKCPDate.Value, "dd/MM/yyyy")
        Logmonth = Logmonth.Replace("/", "-")

        'Dim Pageno As Integer
        'Pageno = 1
        sheet.Cells(1, 9) = Format(Date.Today, "dd/MM/yyyy")
        Dim lEstate As String
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        lEstate = strArray(1)
        sheet.Cells(2, 1) = "Estate/Mill :" & lEstate
        sheet.Cells(2, 4) = "DATE :" & Format(dtpDailyProdKCPDate.Value, "dd/MM/yyyy")


        'sheet.Cells(2, 9) = Pageno
        strMonthlyProdRptName = "DAILY PRODUCTION KCP REPORT " & "" & Logmonth & ""  'ds.Tables(0).Rows(0).Item("ToDT").ToString()
        '  sheet.Cells(5, 1) = "DAILY PRODUCTION KCP REPORT" & "" & Logmonth & ""

        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"

        Dim dsBalanceBFQty As New DataSet

        dsBalanceBFQty = DailyProductionKCPBOL.DailyProductionKCPBFQtySelect(ObjDailyProductionKCPPPT)


        'If dsBalanceBFQty.Tables(0).Rows.Count = 0 Then

        '    If (File.Exists(StrPath)) Then
        '        File.Delete(StrPath)
        '        xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        '    Else
        '        xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        '    End If

        '    xlApp.Visible = True
        '    Cursor = Cursors.Arrow
        '    Exit Sub
        'End If

        Dim lrowCount, DescpRow As Integer
        lrowCount = 7
        DescpRow = 0
        Dim lBalanceBFQty As Decimal = 0
        If dsBalanceBFQty.Tables(0).Rows.Count <> 0 Then
            If dsBalanceBFQty.Tables(0).Rows(0).Item("BalanceBF").ToString() = "" Then
                lBalanceBFQty = 0
            Else
                lBalanceBFQty = dsBalanceBFQty.Tables(0).Rows(0).Item("BalanceBF").ToString()
            End If

            sheet.Cells(6, 4) = dsBalanceBFQty.Tables(0).Rows(0).Item("BalanceBF").ToString()
        Else
            sheet.Cells(6, 4) = "0.000"
        End If
        'sheet.Cells(6, 4) = lBalanceBFQty
        'sheet.Cells(6, 4).HorizontalAlignment = Excel.Constants.xlRight
        sheet.Cells(6, 5) = "Ton"
        sheet.Cells(6, 5).HorizontalAlignment = Excel.Constants.xlLeft
        'While (lBalanceBFQty > 0)

        '    '  sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(0).Rows(DescpRow).Item("BalanceBF").ToString()
        '    sheet.Cells(lrowCount, 5) = "Ton"

        '    lrowCount = lrowCount + 1
        '    DescpRow = DescpRow + 1
        '    lBalanceBFQty = lBalanceBFQty - 1
        'End While

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Kernel Intake"
        sheet.Cells(lrowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        sheet.Cells(lrowCount, 1).font.bold = True

        lrowCount = lrowCount + 1

        sheet.Cells(lrowCount, 1) = "Kernel Received from POM"

        sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(1).Rows(0).Item("POMKernelReceived").ToString
        sheet.Cells(lrowCount, 5) = "Ton"
        sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(3).Rows(0).Item("TotalKerRecdQtyMonthPOM").ToString
        sheet.Cells(lrowCount, 7) = "Ton"
        sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(3).Rows(0).Item("TotalKerRecdQtyYearPOM").ToString
        sheet.Cells(lrowCount, 9) = "Ton"
        lrowCount = lrowCount + 1

        sheet.Cells(lrowCount, 1) = "Kernel Received from COM"
        sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(2).Rows(0).Item("COMKernelReceived").ToString
        sheet.Cells(lrowCount, 5) = "Ton"
        sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(4).Rows(0).Item("TotalKerRecdQtyMonthCOM").ToString
        sheet.Cells(lrowCount, 7) = "Ton"
        sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(4).Rows(0).Item("TotalKerRecdQtyYearCOM").ToString
        sheet.Cells(lrowCount, 9) = "Ton"
        lrowCount = lrowCount + 1

        sheet.Cells(lrowCount, 1) = "Kernel Received from SOM"
        sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(25).Rows(0).Item("SOMKernelReceived").ToString
        sheet.Cells(lrowCount, 5) = "Ton"
        sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(26).Rows(0).Item("TotalKerRecdQtyMonthSOM").ToString
        sheet.Cells(lrowCount, 7) = "Ton"
        sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(26).Rows(0).Item("TotalKerRecdQtyYearSOM").ToString
        sheet.Cells(lrowCount, 9) = "Ton"
        lrowCount = lrowCount + 1

        sheet.Cells(lrowCount, 1) = "Total Kernel Intake"
        sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(17).Rows(0).Item("POMCOMKernelReceived").ToString
        ' sheet.Cells(lrowCount, 4).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Cells(lrowCount, 5) = "Ton"
        'Dim lsumCOMPOMMonth As Decimal
        'lsumCOMPOMMonth = Val(dsBalanceBFQty.Tables(18).Rows(0).Item("TotalKerRecdQtyMonthCOMPOM").ToString) + Val(dsBalanceBFQty.Tables(3).Rows(0).Item("TotalKerRecdQtyMonthPOM").ToString)

        sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(18).Rows(0).Item("TotalKerRecdQtyMonthCOMPOM").ToString
        ' sheet.Cells(lrowCount, 6).HorizontalAlignment = Excel.Constants.xlRight
        sheet.Cells(lrowCount, 7) = "Ton"

        sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(18).Rows(0).Item("TotalKerRecdQtyYearCOMPOM").ToString
        ' sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlRight
        sheet.Cells(lrowCount, 9) = "Ton"

        lrowCount = lrowCount + 2

        sheet.Cells(lrowCount, 1) = "Kernel Processsed"
        sheet.Cells(lrowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        sheet.Cells(lrowCount, 1).font.bold = True
        Dim lKernelProcessedToday As Decimal = 0


        If dsBalanceBFQty.Tables(5).Rows.Count <> 0 Then
            sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(5).Rows(0).Item("KernelProcessedToday").ToString
            sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(5).Rows(0).Item("KernelProcessedMTD").ToString
            sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(5).Rows(0).Item("KernelProcessesYTD").ToString
            lKernelProcessedToday = dsBalanceBFQty.Tables(5).Rows(0).Item("KernelProcessedToday").ToString
        Else

            sheet.Cells(lrowCount, 4) = "0.000"
            sheet.Cells(lrowCount, 6) = "0.000"
            sheet.Cells(lrowCount, 8) = "0.000"
        End If



        sheet.Cells(lrowCount, 5) = "Ton"
        sheet.Cells(lrowCount, 7) = "Ton"
        sheet.Cells(lrowCount, 9) = "Ton"


        lrowCount = lrowCount + 2

        sheet.Cells(lrowCount, 1) = "Balance Carried Forward"
        sheet.Cells(lrowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
        sheet.Cells(lrowCount, 1).font.bold = True

        'Dim lBalanceCarriedForward As Decimal
        '' Dim lBalanceCF As String
        'lBalanceCarriedForward = lBalanceBFQty + dsBalanceBFQty.Tables(17).Rows(0).Item("POMCOMKernelReceived").ToString - lKernelProcessedToday

        ' lBalanceCF = lBalanceCarriedForward
        '  If dsBalanceBFQty.Tables(5).Rows.Count <> 0 Then
        sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(22).Rows(0).Item("BalanceCarriedForward").ToString
        sheet.Cells(lrowCount, 5) = "Ton"



        lrowCount = lrowCount + 2

        sheet.Cells(lrowCount, 1) = "PKO Productions"
        sheet.Cells(lrowCount, 1).font.bold = True
        sheet.Cells(lrowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous



        'Dim dsCPKO As New DataSet

        'dsCPKO = DailyProductionKCPBOL.DailyProductionKCPCPKOCFSelect(ObjDailyProductionKCPPPT)
        'Dim dsLab As New DataSet
        'dsLab = DailyProductionKCPBOL.DailyProductionKCPKernelBalanceCFSelect(ObjDailyProductionKCPPPT)

        'sheet.Cells(lrowCount, 1) = "CPKO"

        ' Palani
        Dim dcPKOProduction As Decimal = 0

        If dsBalanceBFQty.Tables(14).Rows.Count = 0 Then
            sheet.Cells(lrowCount, 4) = "0.000"
            sheet.Cells(lrowCount, 6) = "0.000"
            sheet.Cells(lrowCount, 8) = "0.000"
        Else

            sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(14).Rows(0).Item("CPKOProdcutionToday").ToString
            dcPKOProduction = dsBalanceBFQty.Tables(14).Rows(0).Item("CPKOProdcutionToday").ToString

            sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(14).Rows(0).Item("TotalPKOProdQtyMonth").ToString

            sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(14).Rows(0).Item("TotalPKOProdQtyYear").ToString

        End If
        sheet.Cells(lrowCount, 5) = "Ton"
        sheet.Cells(lrowCount, 7) = "Ton"
        sheet.Cells(lrowCount, 9) = "Ton"

        lrowCount = lrowCount + 1
        Dim lOERMonth As Decimal = 0
        Dim lOERYear As Decimal = 0

        sheet.Cells(lrowCount, 1) = "Oil Extraction Rate"
        If dsBalanceBFQty.Tables(5).Rows.Count = 0 Then
            sheet.Cells(lrowCount, 4) = "0.00"
            sheet.Cells(lrowCount, 6) = "0.00"
            sheet.Cells(lrowCount, 8) = "0.00"

        Else
            sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(5).Rows(0).Item("OERTodate").ToString
            sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(19).Rows(0).Item("OERToDate").ToString
            sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(19).Rows(0).Item("OERYear").ToString
            'sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlLeft


        End If
        sheet.Cells(lrowCount, 5) = "%"
        sheet.Cells(lrowCount, 7) = "%"
        sheet.Cells(lrowCount, 9) = "%"

        lrowCount = lrowCount + 1

        ''sheet.Cells(lrowCount, 5) = "%"
        ''sheet.Cells(lrowCount, 6) = lOERMonth
        ''sheet.Cells(lrowCount, 7) = "%"
        ''sheet.Cells(lrowCount, 8) = lOERYear
        ''sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlLeft
        ''sheet.Cells(lrowCount, 9) = "%"
        ''lrowCount = lrowCount + 1
        ''Dim dsBalanceBFQty As New DataSet

        'dsBalanceBFQty = DailyProductionKCPBOL.DailyProductionKCPBFQtySelect(ObjDailyProductionKCPPPT)
        sheet.Cells(lrowCount, 1) = "PKME"

        sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(19).Rows(0).Item("CakeToday").ToString
        sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(19).Rows(0).Item("CakeMonth").ToString
        sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(19).Rows(0).Item("CakeYear").ToString


        sheet.Cells(lrowCount, 5) = "Ton"
        sheet.Cells(lrowCount, 7) = "Ton"
        sheet.Cells(lrowCount, 9) = "Ton"
        lrowCount = lrowCount + 1

        If (dsBalanceBFQty.Tables(24).Rows.Count > 0) Then
            sheet.Cells(lrowCount, 1) = "Loss On Kernel"
            sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(24).Rows(0).Item("LossOfKernel").ToString
            sheet.Cells(lrowCount, 5) = "Ton"
            lrowCount = lrowCount + 2
        End If


        sheet.Cells(lrowCount, 1) = "Quality"
        sheet.Cells(lrowCount, 1).font.bold = True
        sheet.Cells(lrowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "FFA"
        If dsBalanceBFQty.Tables(15).Rows.Count <> 0 Then
            sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(15).Rows(0).Item("PKOProductionFFAP").ToString
            sheet.Cells(lrowCount, 6) = FormatNumber(dsBalanceBFQty.Tables(15).Rows(0).Item("FFAPMonthValue").ToString, 2)
            sheet.Cells(lrowCount, 8) = FormatNumber(dsBalanceBFQty.Tables(15).Rows(0).Item("FFAPYearValue").ToString, 2)
        Else
            sheet.Cells(lrowCount, 4) = "0.00"
            sheet.Cells(lrowCount, 6) = "0.00"
            sheet.Cells(lrowCount, 8) = "0.00"
        End If


        sheet.Cells(lrowCount, 5) = "%"
        sheet.Cells(lrowCount, 7) = "%"
        sheet.Cells(lrowCount, 9) = "%"
        ' Dim lFFAPMonth, lFFAPYear As Decimal

        'If dsBalanceBFQty.Tables(15).Rows.Count <> 0 Then
        '    lFFAPMonth = dsBalanceBFQty.Tables(15).Rows(0).Item("FFAPMonthValue").ToString  'Math.Round((lPKOProductionFFAP * lCPKOProdcutionToday + (lFFAPMonthValue * lTotalPKOProdQtyMonth)) / lTotalPKOProdQtyMonth, 2)
        '    lFFAPYear = dsBalanceBFQty.Tables(15).Rows(0).Item("FFAPYearValue").ToString 'Math.Round((lPKOProductionFFAP * lCPKOProdcutionToday + (lFFAPYearValue * lTotalPKOProdQtyYear)) / lTotalPKOProdQtyYear, 2)
        'End If


        'If dsBalanceBFQty.Tables(15).Rows.Count <> 0 Then
        '    sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(15).Rows(0).Item("FFAPMonthValue").ToString
        '    sheet.Cells(lrowCount, 7) = "%"
        '    sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(15).Rows(0).Item("FFAPYearValue").ToString
        '    sheet.Cells(lrowCount, 9) = "%"
        'End If
        lrowCount = lrowCount + 1

        sheet.Cells(lrowCount, 1) = "Moist"
        If dsBalanceBFQty.Tables(15).Rows.Count <> 0 Then
            sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(15).Rows(0).Item("PKOProductionMoistureP").ToString
        Else
            sheet.Cells(lrowCount, 4) = "0.00"

        End If

        sheet.Cells(lrowCount, 5) = "%"
        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Dirt"
        If dsBalanceBFQty.Tables(15).Rows.Count <> 0 Then
            sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(15).Rows(0).Item("PKOProductionDirtP").ToString
        Else
            sheet.Cells(lrowCount, 4) = "0.00"
        End If

        sheet.Cells(lrowCount, 5) = "%"

        lrowCount = lrowCount + 2

        sheet.Cells(lrowCount, 1) = "Transhipment CPKO"
        sheet.Cells(lrowCount, 1).font.bold = True
        sheet.Cells(lrowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "CPKO"
        sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(6).Rows(0).Item("CPKOToday").ToString
        sheet.Cells(lrowCount, 5) = "Ton"
        sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(7).Rows(0).Item("TotalCPKOMonth").ToString
        sheet.Cells(lrowCount, 7) = "Ton"
        sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(8).Rows(0).Item("TotalCPKOYr").ToString
        sheet.Cells(lrowCount, 9) = "Ton"
        lrowCount = lrowCount + 2






        Dim loadingDescp As String
        Dim lLoadinLocationDescpcount As Integer = 0

        lLoadinLocationDescpcount = dsBalanceBFQty.Tables(9).Rows.Count

        Dim lDescpCount As Integer = 0
        sheet.Cells(lrowCount, 1) = "Loading CPKO"
        sheet.Cells(lrowCount, 1).font.bold = True
        sheet.Cells(lrowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        lrowCount = lrowCount + 1
        If dsBalanceBFQty.Tables(9).Rows.Count <> 0 Then
            While lLoadinLocationDescpcount > 0
                loadingDescp = dsBalanceBFQty.Tables(9).Rows(lDescpCount).Item("CPKODescp").ToString

                ' loadingDescp = "Darmang COM"
                Dim dsLoadDescp As New DataSet

                dsLoadDescp = DailyProductionKCPBOL.DailyProductionLoadingCPKOSelect(ObjDailyProductionKCPPPT, loadingDescp)


                sheet.Cells(lrowCount, 1) = "CPKO at " & loadingDescp & ""
                sheet.Cells(lrowCount, 4) = dsLoadDescp.Tables(0).Rows(0).Item("Qty").ToString
                sheet.Cells(lrowCount, 5) = "Ton"
                sheet.Cells(lrowCount, 6) = dsLoadDescp.Tables(0).Rows(0).Item("TotalCPLoadOMonth").ToString
                sheet.Cells(lrowCount, 7) = "Ton"
                'sheet.Cells(lrowCount, 8) = dsLoadDescp.Tables(1).Rows(0).Item("TotalCPLoadOyear").ToString
                'sheet.Cells(lrowCount, 9) = "Ton"

                lDescpCount = lDescpCount + 1
                lLoadinLocationDescpcount = lLoadinLocationDescpcount - 1
                lrowCount = lrowCount + 1
                loadingDescp = ""
                dsLoadDescp.Clear()
            End While
        Else
            lrowCount = lrowCount - 1
            sheet.Cells(lrowCount, 4).numberformat = "@"
            sheet.Cells(lrowCount, 4) = "0.000"
            sheet.Cells(lrowCount, 5) = "Ton"
            sheet.Cells(lrowCount, 6).numberformat = "@"
            sheet.Cells(lrowCount, 6) = "0.000"
            sheet.Cells(lrowCount, 7) = "Ton"
            lrowCount = lrowCount + 1

        End If


        lrowCount = lrowCount + 1


        sheet.Cells(lrowCount, 1) = "CPKO Stocks"
        sheet.Cells(lrowCount, 1).font.bold = True
        sheet.Cells(lrowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        sheet.Cells(lrowCount, 6) = " Quality in storage tank"
        sheet.Cells(lrowCount, 6).font.bold = True
        sheet.Range(sheet.Cells(lrowCount, 6), sheet.Cells(lrowCount, 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        sheet.Range(sheet.Cells(lrowCount, 6), sheet.Cells(lrowCount, 11)).Merge()
        sheet.Cells(lrowCount, 6).HorizontalAlignment = Excel.Constants.xlCenter
        lrowCount = lrowCount + 1

        sheet.Cells(lrowCount, 1) = "Last Stock"
        sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(10).Rows(0).Item("LastCPKOStock").ToString
        sheet.Cells(lrowCount, 5) = "Ton"
        sheet.Cells(lrowCount, 6) = "FFA"
        sheet.Cells(lrowCount, 8) = "Moisture"
        sheet.Cells(lrowCount, 10) = "Dirt"
        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Mill"
        ' lrowCount = lrowCount + 1

        Dim lCPKOStocks As Integer = 0
        Dim lCPKOStockCount As Integer

        lCPKOStockCount = dsBalanceBFQty.Tables(21).Rows.Count
        lrowCount = lrowCount + 1
        '  Dim ltotalStock As Decimal = 0


        While (lCPKOStockCount > 0)

            sheet.Cells(lrowCount, 1) = dsBalanceBFQty.Tables(21).Rows(lCPKOStocks).Item("TankNo").ToString
            sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(21).Rows(lCPKOStocks).Item("CurrentReading").ToString
            sheet.Cells(lrowCount, 5) = "Ton"
            sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(21).Rows(lCPKOStocks).Item("FFAP").ToString
            sheet.Cells(lrowCount, 7) = "%"
            sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(21).Rows(lCPKOStocks).Item("MoistureP").ToString
            sheet.Cells(lrowCount, 9) = "%"
            sheet.Cells(lrowCount, 10) = dsBalanceBFQty.Tables(21).Rows(lCPKOStocks).Item("DirtP").ToString
            sheet.Cells(lrowCount, 11) = "%"


            '   ltotalStock = ltotalStock + Val(dsBalanceBFQty.Tables(0).Rows(lCPKOStocks).Item("BalanceBF").ToString)

            lCPKOStocks = lCPKOStocks + 1
            lCPKOStockCount = lCPKOStockCount - 1
            lrowCount = lrowCount + 1

        End While
        lCPKOStockCount = 0

        sheet.Cells(lrowCount, 1) = "Pontoon"
        lrowCount = lrowCount + 1

        lCPKOStockCount = dsBalanceBFQty.Tables(23).Rows.Count
        ' lrowCount = lrowCount + 1
        '  Dim ltotalStock As Decimal = 0

        lCPKOStocks = 0
        While (lCPKOStockCount > 0)

            sheet.Cells(lrowCount, 1) = dsBalanceBFQty.Tables(23).Rows(lCPKOStocks).Item("TankNo").ToString
            sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(23).Rows(lCPKOStocks).Item("CurrentReading").ToString
            sheet.Cells(lrowCount, 5) = "Ton"
            'sheet.Cells(lrowCount, 6) = dsBalanceBFQty.Tables(21).Rows(lCPKOStocks).Item("FFAP").ToString
            'sheet.Cells(lrowCount, 7) = "%"
            'sheet.Cells(lrowCount, 8) = dsBalanceBFQty.Tables(21).Rows(lCPKOStocks).Item("MoistureP").ToString
            'sheet.Cells(lrowCount, 9) = "%"
            'sheet.Cells(lrowCount, 10) = dsBalanceBFQty.Tables(21).Rows(lCPKOStocks).Item("DirtP").ToString
            'sheet.Cells(lrowCount, 11) = "%"


            '   ltotalStock = ltotalStock + Val(dsBalanceBFQty.Tables(0).Rows(lCPKOStocks).Item("BalanceBF").ToString)

            lCPKOStocks = lCPKOStocks + 1
            lCPKOStockCount = lCPKOStockCount - 1
            lrowCount = lrowCount + 1

        End While

        'Dim lCPKOStockPantoon As Integer = 0
        'Dim lCPKOStockPantoonCount As Integer = 0

        'Dim lTotalCPOCount As Integer
        'lTotalCPOCount = 0
        'lCPKOStockPantoonCount = dsBalanceBFQty.Tables(16).Rows.Count
        'If dsBalanceBFQty.Tables(16).Rows.Count <> 0 Then


        '    While (lCPKOStockPantoonCount > 0)
        '        sheet.Cells(lrowCount, 1) = "Stock on Pontoon (" & dsBalanceBFQty.Tables(16).Rows(lTotalCPOCount).Item("LoadingDescp").ToString & ")"
        '        sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(16).Rows(lTotalCPOCount).Item("CPOTransQty").ToString
        '        sheet.Cells(lrowCount, 5) = "Ton"
        '        '  ltotalStock = ltotalStock + Val(dsBalanceBFQty.Tables(16).Rows(lTotalCPOCount).Item("CPOTransQty").ToString)

        '        lTotalCPOCount = lTotalCPOCount + 1
        '        lCPKOStockPantoonCount = lCPKOStockPantoonCount - 1
        '        lrowCount = lrowCount + 1
        '    End While
        'End If

        sheet.Cells(lrowCount, 1) = "Total Stock"
        sheet.Cells(lrowCount, 1).font.Bold = True
        sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(20).Rows(0).Item("totalStock").ToString
        sheet.Cells(lrowCount, 5) = "Ton"

        lrowCount = lrowCount + 2
        'sheet.Cells(lrowCount, 1) = " Quality in storage tank"
        'sheet.Cells(lrowCount, 1).font.Bold = True

        'lrowCount = lrowCount + 1

        'Dim lTankrowcount As Integer = 0
        'Dim lTankCount As Integer

        'lTankCount = dsBalanceBFQty.Tables(11).Rows.Count

        'While (lTankCount > 0)
        '    sheet.Cells(lrowCount, 1) = dsBalanceBFQty.Tables(12).Rows(lTankrowcount).Item("TankNo").ToString
        '    lrowCount = lrowCount + 1
        '    sheet.Cells(lrowCount, 1) = "FFA"
        '    sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(12).Rows(lTankrowcount).Item("FFAP").ToString
        '    sheet.Cells(lrowCount, 5) = "%"
        '    lrowCount = lrowCount + 1

        '    sheet.Cells(lrowCount, 1) = "Moist"
        '    sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(12).Rows(lTankrowcount).Item("MoistureP").ToString
        '    sheet.Cells(lrowCount, 5) = "%"
        '    lrowCount = lrowCount + 1

        '    sheet.Cells(lrowCount, 1) = "Dirt"
        '    sheet.Cells(lrowCount, 4) = dsBalanceBFQty.Tables(12).Rows(lTankrowcount).Item("DirtP").ToString
        '    sheet.Cells(lrowCount, 5) = "%"
        '    lrowCount = lrowCount + 1
        '    lTankCount = lTankCount - 1
        '    lTankrowcount = lTankrowcount + 1
        'End While
        'lrowCount = lrowCount + 1

        sheet.Cells(lrowCount, 1) = "Capacity"
        sheet.Cells(lrowCount, 1).font.Bold = True
        sheet.Cells(lrowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Processing"
        sheet.Cells(lrowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        sheet.Cells(lrowCount, 1).font.Bold = True

        Dim DsBd As New DataSet
        DsBd = DailyProductionKCPBOL.DailProductionSartStopHrsSelect(ObjDailyProductionKCPPPT)
        Dim lStartTimeStr As String = ""
        Dim lEndTimeStr As String = ""

        If DsBd.Tables(0).Rows.Count <> 0 Then
            If DsBd.Tables(0).Rows(0).Item("StartTime1").ToString = "" Then
                If DsBd.Tables(0).Rows(0).Item("StartTime2").ToString = "" Then
                    lStartTimeStr = DsBd.Tables(0).Rows(0).Item("StartTime3").ToString
                    lEndTimeStr = DsBd.Tables(0).Rows(0).Item("endtime3").ToString
                Else
                    lStartTimeStr = DsBd.Tables(0).Rows(0).Item("StartTime2").ToString
                    If DsBd.Tables(0).Rows(0).Item("StartTime3").ToString <> "" Then
                        lEndTimeStr = DsBd.Tables(0).Rows(0).Item("endtime3").ToString
                    Else
                        lEndTimeStr = DsBd.Tables(0).Rows(0).Item("endtime2").ToString
                    End If
                End If
            Else
                lStartTimeStr = DsBd.Tables(0).Rows(0).Item("StartTime1").ToString
                If DsBd.Tables(0).Rows(0).Item("endtime3").ToString <> "" Then
                    lEndTimeStr = DsBd.Tables(0).Rows(0).Item("endtime3").ToString
                ElseIf DsBd.Tables(0).Rows(0).Item("endtime2").ToString <> "" Then
                    lEndTimeStr = DsBd.Tables(0).Rows(0).Item("endtime2").ToString
                Else
                    lEndTimeStr = DsBd.Tables(0).Rows(0).Item("endtime1").ToString
                End If
            End If

            lrowCount = lrowCount + 1
            sheet.Cells(lrowCount, 1) = "Start Time"
            sheet.Cells(lrowCount, 4) = lStartTimeStr
            lrowCount = lrowCount + 1
            sheet.Cells(lrowCount, 1) = "Stop Time"
            sheet.Cells(lrowCount, 4) = lEndTimeStr
            lrowCount = lrowCount + 1
            sheet.Cells(lrowCount, 1) = "Total Time"
            sheet.Cells(lrowCount, 4) = DsBd.Tables(0).Rows(0).Item("TotalHours").ToString
            lrowCount = lrowCount + 1
        End If

        Dim dsBDMonthYear As New DataSet

        dsBDMonthYear = DailyProductionKCPBOL.DailProductionBDSelect(ObjDailyProductionKCPPPT)

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Mechanical BreakDown"
        If DsBd.Tables(0).Rows.Count <> 0 Then
            If DsBd.Tables(0).Rows(0).Item("MechanicalBD").ToString <> "" Then
                sheet.Cells(lrowCount, 4) = DsBd.Tables(0).Rows(0).Item("MechanicalBD").ToString
                sheet.Cells(lrowCount, 8) = ToModifyTime(DsBd.Tables(0).Rows(0).Item("MechanicalBDYTD").ToString)
            Else
                sheet.Cells(lrowCount, 4) = "00:00"
                sheet.Cells(lrowCount, 8) = "00:00"
            End If
        Else
            sheet.Cells(lrowCount, 4) = "00:00"
            sheet.Cells(lrowCount, 8) = "00:00"
        End If
        sheet.Cells(lrowCount, 5) = "hr"
        sheet.Cells(lrowCount, 6) = ToModifyTime(dsBDMonthYear.Tables(2).Rows(0).Item("MonthValuesMechanicalBD").ToString)
        sheet.Cells(lrowCount, 7) = "hr"
        sheet.Cells(lrowCount, 9) = "hr"

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Electrical BreakDown"
        If DsBd.Tables(0).Rows.Count <> 0 Then
            If DsBd.Tables(0).Rows(0).Item("ElectricalBD").ToString <> "" Then
                sheet.Cells(lrowCount, 4) = DsBd.Tables(0).Rows(0).Item("ElectricalBD").ToString
                sheet.Cells(lrowCount, 8) = DsBd.Tables(0).Rows(0).Item("ElectricalBDYTD").ToString
            Else
                sheet.Cells(lrowCount, 4) = "00:00"
                sheet.Cells(lrowCount, 8) = "00:00"
            End If
        Else
            sheet.Cells(lrowCount, 4) = "00:00"
            sheet.Cells(lrowCount, 8) = "00:00"
        End If
        sheet.Cells(lrowCount, 5) = "hr"
        sheet.Cells(lrowCount, 6) = ToModifyTime(dsBDMonthYear.Tables(5).Rows(0).Item("MonthValuesElectricalBD").ToString)
        sheet.Cells(lrowCount, 7) = "hr"

        sheet.Cells(lrowCount, 9) = "hr"

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Processing BreakDown"
        If DsBd.Tables(0).Rows.Count <> 0 Then
            If DsBd.Tables(0).Rows(0).Item("ProcessingBD").ToString <> "" Then
                sheet.Cells(lrowCount, 4) = DsBd.Tables(0).Rows(0).Item("ProcessingBD").ToString
                sheet.Cells(lrowCount, 8) = DsBd.Tables(0).Rows(0).Item("ProcessingBDYTD").ToString
            Else
                sheet.Cells(lrowCount, 4) = "00:00"
                sheet.Cells(lrowCount, 8) = "00:00"
            End If
        Else
            sheet.Cells(lrowCount, 4) = "00:00"
            sheet.Cells(lrowCount, 8) = "00:00"
        End If
        sheet.Cells(lrowCount, 5) = "hr"
        sheet.Cells(lrowCount, 6) = ToModifyTime(dsBDMonthYear.Tables(8).Rows(0).Item("MonthValuesProcessingBD").ToString)
        sheet.Cells(lrowCount, 7) = "hr"

        sheet.Cells(lrowCount, 9) = "hr"

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Total BreakDown"
        If DsBd.Tables(0).Rows.Count <> 0 Then
            If DsBd.Tables(0).Rows(0).Item("TotalBD").ToString <> "" Then
                sheet.Cells(lrowCount, 4) = DsBd.Tables(0).Rows(0).Item("TotalBD").ToString
            Else
                sheet.Cells(lrowCount, 4) = "00:00"
            End If
        Else
            sheet.Cells(lrowCount, 4) = "00:00"
        End If
        sheet.Cells(lrowCount, 5) = "hr"
        Dim MonthValuesTotalBDHours As String
        MonthValuesTotalBDHours = ToaddHours(dsBDMonthYear.Tables(2).Rows(0).Item("MonthValuesMechanicalBD").ToString, dsBDMonthYear.Tables(5).Rows(0).Item("MonthValuesElectricalBD").ToString)
        MonthValuesTotalBDHours = ToaddHours(MonthValuesTotalBDHours, dsBDMonthYear.Tables(8).Rows(0).Item("MonthValuesProcessingBD").ToString)

        Dim YearValuesTotalBDHours As String
        If DsBd.Tables(0).Rows.Count <> 0 Then
            YearValuesTotalBDHours = ToaddHours(DsBd.Tables(0).Rows(0).Item("MechanicalBDYTD").ToString, DsBd.Tables(0).Rows(0).Item("ElectricalBDYTD").ToString)
            YearValuesTotalBDHours = ToaddHours(YearValuesTotalBDHours, DsBd.Tables(0).Rows(0).Item("ProcessingBDYTD").ToString)

        Else
            YearValuesTotalBDHours = "00:00"
        End If

        Dim lEffectiveMonth As String
        Dim lEffectiveYear As String
        If DsBd.Tables(0).Rows.Count <> 0 Then
            lEffectiveMonth = ToSubHours(DsBd.Tables(0).Rows(0).Item("MonthToDateHrs").ToString, MonthValuesTotalBDHours)
            lEffectiveYear = ToSubHours(DsBd.Tables(0).Rows(0).Item("YearToDateHrs").ToString, YearValuesTotalBDHours)
        Else
            lEffectiveMonth = "00:00"
            lEffectiveYear = "00:00"
        End If








        sheet.Cells(lrowCount, 6) = ToModifyTime(MonthValuesTotalBDHours)
        sheet.Cells(lrowCount, 7) = "hr"
        sheet.Cells(lrowCount, 8) = ToModifyTime(YearValuesTotalBDHours)
        sheet.Cells(lrowCount, 9) = "hr"


        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Effective Processing Hours"
        If DsBd.Tables(0).Rows.Count <> 0 Then
            If DsBd.Tables(0).Rows(0).Item("EffectiveProcessingHours").ToString <> "" Then
                sheet.Cells(lrowCount, 4) = DsBd.Tables(0).Rows(0).Item("EffectiveProcessingHours").ToString
            Else
                sheet.Cells(lrowCount, 4) = "00:00"
            End If
        Else
            sheet.Cells(lrowCount, 4) = "00:00"
        End If

        sheet.Cells(lrowCount, 5) = "hr"
        sheet.Cells(lrowCount, 6) = lEffectiveMonth
        sheet.Cells(lrowCount, 7) = "hr"
        sheet.Cells(lrowCount, 8) = lEffectiveYear
        sheet.Cells(lrowCount, 9) = "hr"

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Throughput"
        If DsBd.Tables(0).Rows.Count > 0 Then
            Dim LDEC As String
            LDEC = Val(DsBd.Tables(0).Rows(0).Item("Throughput").ToString)
            sheet.Cells(lrowCount, 4) = "" & LDEC
            sheet.Cells(lrowCount, 4).HorizontalAlignment = Excel.Constants.xlRight
        End If
        sheet.Cells(lrowCount, 5) = "Ton/Hr"
        Dim lEffectiveHrsmonth, lEffectiveHrsDecYear As Decimal

        If lEffectiveMonth <> "00:00" Then
            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = lEffectiveMonth
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = Math.Round(Min1 / 60, 2) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)
            lEffectiveHrsmonth = Hrs1 + lmin1
        End If

        If lEffectiveYear <> "00:00" Then
            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = lEffectiveYear
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = Math.Round(Min1 / 60, 2) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)
            lEffectiveHrsDecYear = Hrs1 + lmin1
        End If
        ' Dim lstr As Decimal = 0

        If lEffectiveHrsmonth > 0 And dsBalanceBFQty.Tables(5).Rows.Count > 0 Then

            Dim LDEC As String
            LDEC = Math.Round((Val(dsBalanceBFQty.Tables(5).Rows(0).Item("KernelProcessedMTD").ToString) / lEffectiveHrsmonth), 2)
            sheet.Cells(lrowCount, 6) = "" & LDEC
            '  sheet.Cells(lrowCount, 6).NumberFormat = "0.00"
            sheet.Cells(lrowCount, 6).HorizontalAlignment = Excel.Constants.xlRight

        End If
        sheet.Cells(lrowCount, 7) = "Ton/Hr"

        If lEffectiveHrsDecYear > 0 And dsBalanceBFQty.Tables(5).Rows.Count > 0 Then
            Dim LDEC As String
            LDEC = Math.Round(Val(dsBalanceBFQty.Tables(5).Rows(0).Item("KernelProcessesYTD").ToString) / lEffectiveHrsDecYear, 2)
            'If Len(LDEC) < 3 Then
            '    LDEC = LDEC + CStr(".00")
            'End If
            '  sheet.Cells(lrowCount, 8).NumberFormat = "0.00"
            sheet.Cells(lrowCount, 8) = LDEC
            '  sheet.Cells(lrowCount, 8) = "" & LDEC

            sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlRight
        End If
        sheet.Cells(lrowCount, 9) = "Ton/Hr"
        lrowCount = lrowCount + 2

        Dim dsPressInfo As New DataSet
        dsPressInfo = DailyProductionKCPBOL.DailProductionPressInfoSelect(ObjDailyProductionKCPPPT)
        sheet.Range(sheet.Cells(lrowCount, 1), sheet.Cells(lrowCount, 9)).Merge()

        sheet.Cells(lrowCount, 1) = "Press Stage1 "
        sheet.Range(sheet.Cells(lrowCount, 1), sheet.Cells(lrowCount, 9)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        sheet.Cells(lrowCount, 1).font.bold = True
        sheet.Cells(lrowCount, 1).HorizontalAlignment = Excel.Constants.xlCenter

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Status"
        sheet.Cells(lrowCount, 2) = "Age of screw"
        sheet.Cells(lrowCount, 4) = "Press No"
        sheet.Cells(lrowCount, 6) = "Capacity(kg)"
        sheet.Cells(lrowCount, 8) = "Op.Hours"
        sheet.Cells(lrowCount, 1).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Cells(lrowCount, 2).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Cells(lrowCount, 4).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Cells(lrowCount, 6).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Range(sheet.Cells(lrowCount, 1), sheet.Cells(lrowCount, 9)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous


        If dsPressInfo.Tables(0).Rows.Count > 0 Then


            Dim lStagePress1Count, lStageRow As Integer
            lStagePress1Count = dsPressInfo.Tables(0).Rows.Count
            lStageRow = 0
            lrowCount = lrowCount + 1
            While (lStagePress1Count > 0)

                sheet.Cells(lrowCount, 1) = dsPressInfo.Tables(0).Rows(lStageRow).Item("ScrewStatus").ToString
                sheet.Cells(lrowCount, 2) = ToModifyTime(dsPressInfo.Tables(0).Rows(lStageRow).Item("ScrewAge").ToString)
                sheet.Cells(lrowCount, 4) = dsPressInfo.Tables(0).Rows(lStageRow).Item("Press").ToString
                sheet.Range(sheet.Cells(lrowCount, 4), sheet.Cells(lrowCount, 5)).Merge()
                sheet.Cells(lrowCount, 6) = dsPressInfo.Tables(0).Rows(lStageRow).Item("Capacity").ToString
                sheet.Cells(lrowCount, 8) = dsPressInfo.Tables(0).Rows(lStageRow).Item("OPHrs").ToString

                sheet.Cells(lrowCount, 1).HorizontalAlignment = Excel.Constants.xlLeft
                sheet.Cells(lrowCount, 2).HorizontalAlignment = Excel.Constants.xlRight
                sheet.Cells(lrowCount, 4).HorizontalAlignment = Excel.Constants.xlLeft
                sheet.Cells(lrowCount, 6).HorizontalAlignment = Excel.Constants.xlRight
                sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlRight

                lStagePress1Count = lStagePress1Count - 1
                lStageRow = lStageRow + 1
                lrowCount = lrowCount + 1
            End While
            sheet.Cells(lrowCount, 6) = "Total Operation Hrs Stage 1"
            sheet.Range(sheet.Cells(lrowCount, 6), sheet.Cells(lrowCount, 7)).Merge()
            sheet.Cells(lrowCount, 6).font.bold = True
            sheet.Cells(lrowCount, 8) = dsPressInfo.Tables(2).Rows(0).Item("TotalPressHrsToday").ToString
            sheet.Cells(lrowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
            sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlRight
            lrowCount = lrowCount + 1
            sheet.Cells(lrowCount, 6) = "Utilization %"
            sheet.Range(sheet.Cells(lrowCount, 6), sheet.Cells(lrowCount, 7)).Merge()
            sheet.Cells(lrowCount, 6).font.bold = True
            sheet.Cells(lrowCount, 8) = dsPressInfo.Tables(2).Rows(0).Item("UtilizationToday").ToString
            sheet.Cells(lrowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
            sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlRight
            lrowCount = lrowCount + 1
            sheet.Cells(lrowCount, 5) = "Average Press Throughput Stage 1"
            sheet.Range(sheet.Cells(lrowCount, 5), sheet.Cells(lrowCount, 7)).Merge()
            sheet.Cells(lrowCount, 5).font.bold = True

            sheet.Cells(lrowCount, 8) = dsPressInfo.Tables(2).Rows(0).Item("AvgPressThrToday").ToString

            'Dim dcStage1 As Decimal = 0
            'dcStage1 = lKernelProcessedToday * 1000 / Convert.ToDouble(Replace(dsPressInfo.Tables(2).Rows(0).Item("TotalPressHrsToday_Time").ToString, ":", "."))
            'sheet.Cells(lrowCount, 8) = dcStage1.ToString("0.00")

            sheet.Cells(lrowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
            sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlRight

            lrowCount = lrowCount + 1
        End If
        lrowCount = lrowCount + 1


        sheet.Range(sheet.Cells(lrowCount, 1), sheet.Cells(lrowCount, 9)).Merge()
        sheet.Cells(lrowCount, 1) = "Press Stage2 "
        sheet.Range(sheet.Cells(lrowCount, 1), sheet.Cells(lrowCount, 9)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        sheet.Cells(lrowCount, 1).font.bold = True
        sheet.Cells(lrowCount, 1).HorizontalAlignment = Excel.Constants.xlCenter

        lrowCount = lrowCount + 1
        sheet.Cells(lrowCount, 1) = "Status"
        sheet.Cells(lrowCount, 2) = "Age of screw"
        sheet.Cells(lrowCount, 4) = "Press No"
        sheet.Cells(lrowCount, 6) = "Capacity(kg)"
        sheet.Cells(lrowCount, 8) = "Op.Hours"
        sheet.Cells(lrowCount, 1).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Cells(lrowCount, 2).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Cells(lrowCount, 4).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Cells(lrowCount, 6).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlLeft
        sheet.Range(sheet.Cells(lrowCount, 1), sheet.Cells(lrowCount, 9)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

        lrowCount = lrowCount + 1
        If dsPressInfo.Tables(1).Rows.Count > 0 Then


            Dim lStagePress1Count, lStageRow As Integer
            lStagePress1Count = dsPressInfo.Tables(1).Rows.Count
            lStageRow = 0

            While (lStagePress1Count > 0)

                sheet.Cells(lrowCount, 1) = dsPressInfo.Tables(1).Rows(lStageRow).Item("ScrewStatus").ToString
                sheet.Cells(lrowCount, 2) = ToModifyTime(dsPressInfo.Tables(1).Rows(lStageRow).Item("ScrewAge").ToString)
                sheet.Cells(lrowCount, 4) = dsPressInfo.Tables(1).Rows(lStageRow).Item("PressM").ToString
                sheet.Range(sheet.Cells(lrowCount, 4), sheet.Cells(lrowCount, 5)).Merge()
                sheet.Cells(lrowCount, 6) = dsPressInfo.Tables(1).Rows(lStageRow).Item("Capacity").ToString
                sheet.Cells(lrowCount, 8) = dsPressInfo.Tables(1).Rows(lStageRow).Item("OPHrs").ToString

                sheet.Cells(lrowCount, 1).HorizontalAlignment = Excel.Constants.xlLeft
                sheet.Cells(lrowCount, 2).HorizontalAlignment = Excel.Constants.xlRight
                sheet.Cells(lrowCount, 4).HorizontalAlignment = Excel.Constants.xlLeft
                sheet.Cells(lrowCount, 6).HorizontalAlignment = Excel.Constants.xlRight
                sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlRight


                lStagePress1Count = lStagePress1Count - 1
                lStageRow = lStageRow + 1
                lrowCount = lrowCount + 1

            End While

            If dsPressInfo.Tables(3).Rows.Count > 0 Then

                sheet.Cells(lrowCount, 6) = "Total Operation Hrs Stage 2"
                sheet.Range(sheet.Cells(lrowCount, 6), sheet.Cells(lrowCount, 7)).Merge()
                sheet.Cells(lrowCount, 6).font.bold = True
                sheet.Cells(lrowCount, 8) = dsPressInfo.Tables(3).Rows(0).Item("TotalPressHrsToday").ToString
                sheet.Cells(lrowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlRight
                lrowCount = lrowCount + 1
                sheet.Cells(lrowCount, 6) = "Utilization %"
                sheet.Range(sheet.Cells(lrowCount, 6), sheet.Cells(lrowCount, 7)).Merge()
                sheet.Cells(lrowCount, 6).font.bold = True
                sheet.Cells(lrowCount, 8) = dsPressInfo.Tables(3).Rows(0).Item("UtilizationToday").ToString
                sheet.Cells(lrowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlRight
                lrowCount = lrowCount + 1
                sheet.Cells(lrowCount, 5) = "Average Press Throughput Stage 2"
                sheet.Range(sheet.Cells(lrowCount, 5), sheet.Cells(lrowCount, 7)).Merge()
                sheet.Cells(lrowCount, 5).font.bold = True

                'sheet.Cells(lrowCount, 8) = dsPressInfo.Tables(3).Rows(0).Item("AvgPressThrToday").ToString

                Dim dcStage2 As Decimal = 0
                Dim TotalPressHrsToday_Time As Decimal = Convert.ToDouble(Replace(dsPressInfo.Tables(3).Rows(0).Item("TotalPressHrsToday_Time").ToString, ":", "."))
                If TotalPressHrsToday_Time > 0 Then
                    dcStage2 = ((lKernelProcessedToday - dcPKOProduction) * 1000) / TotalPressHrsToday_Time
                End If
                sheet.Cells(lrowCount, 8) = dcStage2.ToString("0.00")

                sheet.Cells(lrowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                sheet.Cells(lrowCount, 8).HorizontalAlignment = Excel.Constants.xlRight

            End If
            lrowCount = lrowCount + 1
            'CPO/KERNEL WRITEOFF


            'lrowCount = lrowCount + 1
        End If

        If dsBalanceBFQty.Tables(27).Rows.Count > 0 Then
            lrowCount = lrowCount + 1
            'sheet.Cells(lrowCount, 2) = "19"
            sheet.Cells(lrowCount, 1).font.bold = True

            sheet.Range(sheet.Cells(lrowCount, 1), sheet.Cells(lrowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            'sheet.Range(sheet.Cells(lrowCount, 3), sheet.Cells(lrowCount, 5)).Merge()
            sheet.Cells(lrowCount, 1) = "CPO/Kernel Writeoff"

            Dim dtWriteoff As DataTable = dsBalanceBFQty.Tables(27)


            lrowCount = lrowCount + 1
            sheet.Cells(lrowCount, 1) = "Storage Location"
            sheet.Cells(lrowCount, 3) = "Qty(Mt)"

            sheet.Cells(lrowCount, 5) = "Reason"
            sheet.Range(sheet.Cells(lrowCount, 5), sheet.Cells(lrowCount, 8)).Merge()

            sheet.Range(sheet.Cells(lrowCount, 1), sheet.Cells(lrowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Range(sheet.Cells(lrowCount, 1), sheet.Cells(lrowCount, 5)).HorizontalAlignment = Excel.Constants.xlCenter
            lrowCount = lrowCount + 1
            With sheet
                For Each dr In dtWriteoff.Rows
                    If Not (dr("TankNo") Is DBNull.Value) Then
                        .Cells(lrowCount, 1) = dr("TankNo")
                    Else
                        .Cells(lrowCount, 1) = dr("KernelStorage")
                    End If

                    '.Range(sheet.Cells(lrowCount, 3), sheet.Cells(lrowCount, 4)).Merge()

                    .Cells(lrowCount, 3) = dr("Writeoff")
                    '.Cells(lrowCount, 4) = "Ton"
                    '.Range(sheet.Cells(lrowCount, 5), sheet.Cells(lrowCount, 7)).Merge()

                    .Cells(lrowCount, 5) = dr("Reason")
                    .Range(sheet.Cells(lrowCount, 5), sheet.Cells(lrowCount, 8)).Merge()

                    '.Range(sheet.Cells(lrowCount, 3), sheet.Cells(lrowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDot
                    sheet.Range(sheet.Cells(lrowCount, 1), sheet.Cells(lrowCount, 8)).HorizontalAlignment = Excel.Constants.xlLeft
                    sheet.Cells(lrowCount, 3).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    lrowCount = lrowCount + 1
                Next
            End With
        Else
            lrowCount = lrowCount + 1
            'sheet.Range(sheet.Cells(lrowCount, 3), sheet.Cells(lrowCount, 12)).Merge()
            'sheet.Range(sheet.Cells(lrowCount, 3), sheet.Cells(lrowCount + 6, 12)).Merge()
            'sheet.Cells(lrowCount, 3).wraptext = True
        End If
        lrowCount = lrowCount + 1
        sheet.Protect("RANNBSP@2010")

        xlApp.Visible = True

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        Cursor = Cursors.Arrow

        ' xlApp.Workbooks.Open(StrPath)

        ' Cursor = Cursors.Arrow

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message())
        'Finally
        '    Cursor = Cursors.Arrow

        '    ' after completing all operations close & quit   
        '    xlWorkBook.Close()
        '    xlApp.Quit()

        '    ' and release the object for better performance. if you didnt release it will be in the worker process and will affect the server performance.   

        '    releaseObject(xlApp)
        '    releaseObject(xlWorkBook)
        '    releaseObject(sheet)

        'End Try
    End Sub


    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub



    Private Function ToModifyTime(ByVal ModifyTime As String)
        Dim Hrs As String = "00"
        Dim Min As String = "00"
        Dim str As String
        Dim strArr() As String
        str = ModifyTime
        strArr = str.Split(":")
        If strArr(0).Length = 1 Then
            Hrs = "0" + strArr(0)
        Else
            Hrs = strArr(0)
        End If
        Min = strArr(1)
        ModifyTime = Hrs + ":" + Min
        Return ModifyTime
    End Function




    Private Function ToaddHours(ByVal Hours1 As String, ByVal Hours2 As String)
        Dim Calchrs As String
        Dim strArr4(), strArr3() As String
        Dim Str4, Str3 As String
        Str4 = Hours1
        strArr4 = Str4.Split(":")
        Str3 = Hours2
        strArr3 = Str3.Split(":")

        Dim Lhrs2, lmin2 As Integer

        Lhrs2 = CInt(strArr4(0)) + CInt(strArr3(0))
        lmin2 = CInt(strArr4(1)) + CInt(strArr3(1))

        If lmin2 >= 60 Then
            lmin2 = lmin2 - 60
            Lhrs2 = Lhrs2 + 1
        End If
        Dim Strhrs2 As String = "00"
        Dim StrMin2 As String = "00"


        If Lhrs2 < 10 Then
            Strhrs2 = "0" + Convert.ToString(Lhrs2)
        Else
            Strhrs2 = Lhrs2
        End If

        If lmin2 < 10 Then
            StrMin2 = "0" + Convert.ToString(lmin2)
        Else
            StrMin2 = lmin2
        End If
        Calchrs = Strhrs2 + ":" + StrMin2
        Return Calchrs
    End Function


    Private Function ToSubHours(ByVal Hours1 As String, ByVal Hours2 As String)
        Dim Calchrs As String
        Dim strArr4(), strArr3() As String
        Dim Str4, Str3 As String
        Str4 = Hours1
        strArr4 = Str4.Split(":")
        Str3 = Hours2
        strArr3 = Str3.Split(":")

        Dim Lhrs2, lmin2 As Integer

        Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
        lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

        If lmin2 < 0 Then
            lmin2 = lmin2 + 60
            Lhrs2 = Lhrs2 - 1
        End If


        Dim Strhrs2 As String = "00"
        Dim StrMin2 As String = "00"


        If Lhrs2 < 10 Then
            Strhrs2 = "0" + Convert.ToString(Lhrs2)
        Else
            Strhrs2 = Lhrs2
        End If

        If lmin2 < 10 Then
            StrMin2 = "0" + Convert.ToString(lmin2)
        Else
            StrMin2 = lmin2
        End If

        Calchrs = Strhrs2 + ":" + StrMin2
        Return Calchrs
    End Function

End Class