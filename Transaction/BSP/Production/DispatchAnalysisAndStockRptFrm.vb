Imports System.Windows.Forms
Imports Common_PPT
Imports Common_BOL
Imports Common_DAL
Imports System.Collections
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.Data.SqlClient
Imports System.IO
Imports Production_BOL

Public Class DispatchAnalysisAndStockRptFrm


    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        ViewReport(dtpDate.Value)

    End Sub

    Private Sub ViewReport(ByVal dtValue As Date)


        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet

        ' Dim sheet1 As Excel.Worksheet
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        xlApp = New Excel.Application
        'xlApp.Cursor = Excel.XlMousePointer.xlWait
             Dim ReportDirectory As String = String.Empty
        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\DispatchAnalysis_Stock_Report_Template.xls"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\DispatchAnalysis_Stock_Report_Template.xls")
        Else
            MsgBox("ADispatch analysis stock report template missing.Please contact system administrator.")
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

        'strDSN = "" & ConfigurationManager.AppSettings.Item("oDataSource").ToString & ""
        'strServerUserName = "" & ConfigurationManager.AppSettings.Item("oUserName").ToString & ""
        'strServerPassword = "" & ConfigurationManager.AppSettings.Item("oPassword").ToString & ""
        'StrInitialCatlog = "" & ConfigurationManager.AppSettings.Item("oDataBase").ToString & ""

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName



        Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        con = New SqlConnection(constr)

        con.Open()


        cmd.Connection = con
        cmd.CommandText = "Production.SOPSelectForDispatchAnalysisStockrpt"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@CPOProductionDate", Format(dtpDate.Value, "yyyy/MM/dd"))

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "SOPSelectForDispatchAnalysisStockrpt")

        Dim strMonthlyAccountsRptName As String
        strMonthlyAccountsRptName = Format(dtpDate.Value, "dd/MM/yyyy")

        strMonthlyAccountsRptName = "DISPATCH ANALYSIS STOCK REPORT - " & strMonthlyAccountsRptName

        Try

            If ds.Tables(0) IsNot Nothing Then
                Dim lEstate As String
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                lEstate = strArray(1)

                sheet.Cells(2, 2) = "Estate/Mill :" & lEstate
                sheet.Cells(1, 11) = Format(Date.Today(), "dd/MM/yyyy")  'from date
                'sheet.Cells(3, 9) = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")  'from date
                'sheet.Cells(3, 11) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy") 'to date

                Dim objGlobalBOL As New GlobalBOL
                Dim strMonthName As String = String.Empty
                Dim strFullMonthName As String = String.Empty
                strMonthName = objGlobalBOL.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                'strFullMonthName = GlobalDAL.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

                sheet.Cells(5, 2) = strMonthlyAccountsRptName

                sheet.Cells(10, 7).HorizontalAlignment = Excel.Constants.xlRight
                'sheet.Cells(10, 7).font.alignment = Excel.Constants.xlCenter
                sheet.Cells(10, 7) = "Mill Dispatch " & strMonthName

                sheet.Cells(15, 7).HorizontalAlignment = Excel.Constants.xlRight
                'sheet.Cells(15, 7).font.align = Excel.Constants.xlCenter
                sheet.Cells(15, 7) = "Mill Dispatch " & strMonthName

                sheet.Cells(11, 6) = ds.Tables(0).Rows(0).Item("QltCPOMoisture").ToString()
                sheet.Cells(12, 6) = ds.Tables(0).Rows(0).Item("QltCPODirt").ToString()
                sheet.Cells(13, 6) = ds.Tables(0).Rows(0).Item("QltCPOFFA").ToString()

                sheet.Cells(16, 6) = ds.Tables(0).Rows(0).Item("QltFKMoisture").ToString()
                sheet.Cells(17, 6) = ds.Tables(0).Rows(0).Item("QltFKBrokenKernel").ToString()
                sheet.Cells(18, 6) = ds.Tables(0).Rows(0).Item("QltFKDirt").ToString()

                Dim intTable3Count As Integer = 0
                Dim int3rdTableStarCount As Integer = 24

                If ds.Tables(1) IsNot Nothing Then '3rd table and data construction

                    intTable3Count = ds.Tables(1).Rows.Count
                    Dim intLrowNo As Integer = 0
                    Dim intCPOCurrentReading As Integer = 0

                    While (intTable3Count > 0)

                        sheet.Cells(int3rdTableStarCount, 4) = ds.Tables(1).Rows(intLrowNo).Item("TankNo")
                        sheet.Cells(int3rdTableStarCount, 4).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int3rdTableStarCount, 4).HorizontalAlignment = Excel.Constants.xlLeft
                        sheet.Cells(int3rdTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        sheet.Cells(int3rdTableStarCount, 5) = ds.Tables(1).Rows(intLrowNo).Item("Capacity")
                        sheet.Cells(int3rdTableStarCount, 5).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int3rdTableStarCount, 5).HorizontalAlignment = Excel.Constants.xlRight
                        sheet.Cells(int3rdTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        sheet.Cells(int3rdTableStarCount, 6) = ds.Tables(1).Rows(intLrowNo).Item("CurrentReading")
                        intCPOCurrentReading += ds.Tables(1).Rows(intLrowNo).Item("CurrentReading")
                        sheet.Cells(int3rdTableStarCount, 6).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int3rdTableStarCount, 6).HorizontalAlignment = Excel.Constants.xlRight
                        sheet.Cells(int3rdTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous


                        sheet.Cells(int3rdTableStarCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                        sheet.Cells(int3rdTableStarCount, 7) = ds.Tables(1).Rows(intLrowNo).Item("FFAP")
                        sheet.Cells(int3rdTableStarCount, 7).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int3rdTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        sheet.Cells(int3rdTableStarCount, 8) = ds.Tables(1).Rows(intLrowNo).Item("MoistureP")
                        sheet.Cells(int3rdTableStarCount, 8).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int3rdTableStarCount, 8).HorizontalAlignment = Excel.Constants.xlRight
                        sheet.Cells(int3rdTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        sheet.Cells(int3rdTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int3rdTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        int3rdTableStarCount = int3rdTableStarCount + 1
                        intLrowNo = intLrowNo + 1
                        intTable3Count = intTable3Count - 1

                        If intTable3Count = 0 Then

                            sheet.Cells(int3rdTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int3rdTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int3rdTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int3rdTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int3rdTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int3rdTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int3rdTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int3rdTableStarCount, 5) = "Total"
                            sheet.Cells(int3rdTableStarCount, 5).font.bold = True
                            sheet.Cells(int3rdTableStarCount, 5).VerticalAlignment = Excel.Constants.xlCenter
                            sheet.Cells(int3rdTableStarCount, 5).HorizontalAlignment = Excel.Constants.xlCenter
                            sheet.Range(sheet.Cells(int3rdTableStarCount, 4), sheet.Cells(int3rdTableStarCount, 5)).Merge()

                            sheet.Cells(int3rdTableStarCount, 6) = intCPOCurrentReading.ToString()

                        End If

                    End While

                End If


                Dim intTable4Count As Integer = 0
                Dim int4thTableStarCount As Integer
                'If intTable3Count > 0 Then
                int4thTableStarCount = int3rdTableStarCount + 2
                'Else
                '    int4thTableStarCount = int3rdTableStarCount + 2
                'End If


                If ds.Tables(2) IsNot Nothing Then '4th table and data construction

                    intTable4Count = ds.Tables(2).Rows.Count
                    If intTable4Count <> 0 Then
                        Dim intLrowNo As Integer = 0
                        Dim intPKOCurrentReading As Integer = 0
                        'int4thTableStarCount = int3rdTableStarCount + 2


                        sheet.Cells(int4thTableStarCount, 6) = "PKO STOCK"
                        sheet.Cells(int4thTableStarCount, 6).font.bold = True
                        sheet.Range(sheet.Cells(int4thTableStarCount, 6), sheet.Cells(int4thTableStarCount, 7)).Merge()
                        sheet.Cells(int4thTableStarCount, 7).VerticalAlignment = Excel.Constants.xlCenter
                        sheet.Cells(int4thTableStarCount, 7).HorizontalAlignment = Excel.Constants.xlCenter

                        int4thTableStarCount = int4thTableStarCount + 2

                        sheet.Cells(int4thTableStarCount, 4) = "TankNo"
                        sheet.Cells(int4thTableStarCount, 4).font.bold = True
                        sheet.Cells(int4thTableStarCount, 4).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int4thTableStarCount, 4).HorizontalAlignment = Excel.Constants.xlLeft
                        sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        sheet.Cells(int4thTableStarCount, 5) = "Capacity (Tons)"
                        sheet.Cells(int4thTableStarCount, 5).WrapText = True
                        sheet.Cells(int4thTableStarCount, 5).font.bold = True
                        sheet.Cells(int4thTableStarCount, 5).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int4thTableStarCount, 5).HorizontalAlignment = Excel.Constants.xlRight
                        sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        sheet.Cells(int4thTableStarCount, 6) = "Stock Tons"
                        sheet.Cells(int4thTableStarCount, 6).font.bold = True
                        sheet.Cells(int4thTableStarCount, 6).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int4thTableStarCount, 6).HorizontalAlignment = Excel.Constants.xlRight
                        sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        sheet.Cells(int4thTableStarCount, 7) = "FFA%"
                        sheet.Cells(int4thTableStarCount, 7).font.bold = True
                        sheet.Cells(int4thTableStarCount, 7).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int4thTableStarCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                        sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        sheet.Cells(int4thTableStarCount, 8) = "Moisture %"
                        sheet.Cells(int4thTableStarCount, 8).font.bold = True
                        sheet.Cells(int4thTableStarCount, 8).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int4thTableStarCount, 8).HorizontalAlignment = Excel.Constants.xlRight
                        sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        sheet.Cells(int4thTableStarCount, 9) = "Date Last Cleaned"
                        sheet.Cells(int4thTableStarCount, 9).WrapText = True
                        sheet.Cells(int4thTableStarCount, 9).font.bold = True
                        sheet.Cells(int4thTableStarCount, 9).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int4thTableStarCount, 9).HorizontalAlignment = Excel.Constants.xlLeft
                        sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous


                        int4thTableStarCount = int4thTableStarCount + 1

                        While (intTable4Count > 0)

                            sheet.Cells(int4thTableStarCount, 4) = ds.Tables(2).Rows(intLrowNo).Item("TankNo")
                            sheet.Cells(int4thTableStarCount, 4).HorizontalAlignment = Excel.Constants.xlLeft
                            sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int4thTableStarCount, 5) = ds.Tables(2).Rows(intLrowNo).Item("Capacity")
                            sheet.Cells(int4thTableStarCount, 5).HorizontalAlignment = Excel.Constants.xlRight
                            sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int4thTableStarCount, 6) = ds.Tables(2).Rows(intLrowNo).Item("CurrentReading")
                            intPKOCurrentReading += ds.Tables(2).Rows(intLrowNo).Item("CurrentReading")
                            sheet.Cells(int4thTableStarCount, 6).HorizontalAlignment = Excel.Constants.xlRight
                            sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int4thTableStarCount, 7) = ds.Tables(2).Rows(intLrowNo).Item("FFAP")
                            sheet.Cells(int4thTableStarCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                            sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int4thTableStarCount, 8) = ds.Tables(2).Rows(intLrowNo).Item("MoistureP")
                            sheet.Cells(int4thTableStarCount, 8).HorizontalAlignment = Excel.Constants.xlRight
                            sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            int4thTableStarCount = int4thTableStarCount + 1
                            intLrowNo = intLrowNo + 1
                            intTable4Count = intTable4Count - 1

                            If intTable4Count = 0 Then

                                sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                                sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                                sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                                sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                                sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                                sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(int4thTableStarCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                                sheet.Cells(int4thTableStarCount, 5) = "Total"
                                sheet.Cells(int4thTableStarCount, 5).font.bold = True
                                sheet.Cells(int4thTableStarCount, 5).VerticalAlignment = Excel.Constants.xlCenter
                                sheet.Cells(int4thTableStarCount, 5).HorizontalAlignment = Excel.Constants.xlCenter
                                sheet.Range(sheet.Cells(int4thTableStarCount, 4), sheet.Cells(int4thTableStarCount, 5)).Merge()

                                sheet.Cells(int4thTableStarCount, 6) = intPKOCurrentReading.ToString()

                            End If

                        End While
                    End If
                End If

                Dim intTable5Count As Integer = 0
                Dim int5thTableStarCount As Integer
                int5thTableStarCount = int4thTableStarCount + 2

                If ds.Tables(3) IsNot Nothing Then '4th table and data construction

                    intTable5Count = ds.Tables(3).Rows.Count
                    Dim intLrowNo As Integer = 0
                    Dim intFKOCurrentReading As Integer = 0
                    'int5thTableStarCount = int4thTableStarCount + 2

                    sheet.Cells(int5thTableStarCount, 7) = "KERNAL STOCK"
                    sheet.Cells(int5thTableStarCount, 7).font.bold = True
                    sheet.Range(sheet.Cells(int5thTableStarCount, 6), sheet.Cells(int5thTableStarCount, 7)).Merge()
                    sheet.Cells(int5thTableStarCount, 7).verticalAlignment = HorizontalAlignment.Center
                    sheet.Cells(int5thTableStarCount, 7).HorizontalAlignment = HorizontalAlignment.Center

                    int5thTableStarCount = int5thTableStarCount + 2

                    sheet.Cells(int5thTableStarCount, 6) = "Station"
                    sheet.Cells(int5thTableStarCount, 6).font.bold = True
                    sheet.Cells(int5thTableStarCount, 6).VerticalAlignment = Excel.Constants.xlTop
                    sheet.Cells(int5thTableStarCount, 6).HorizontalAlignment = Excel.Constants.xlLeft
                    sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(int5thTableStarCount, 7) = "Stock"
                    sheet.Cells(int5thTableStarCount, 7).font.bold = True
                    sheet.Cells(int5thTableStarCount, 7).VerticalAlignment = Excel.Constants.xlTop
                    sheet.Cells(int5thTableStarCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                    sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    int5thTableStarCount = int5thTableStarCount + 1

                    While (intTable5Count > 0)

                        sheet.Cells(int5thTableStarCount, 6) = ds.Tables(3).Rows(intLrowNo).Item("Code")
                        sheet.Cells(int5thTableStarCount, 6).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int5thTableStarCount, 6).HorizontalAlignment = Excel.Constants.xlLeft
                        sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        sheet.Cells(int5thTableStarCount, 7) = ds.Tables(3).Rows(intLrowNo).Item("CurrentReading")
                        intFKOCurrentReading += ds.Tables(3).Rows(intLrowNo).Item("CurrentReading")
                        sheet.Cells(int5thTableStarCount, 7).VerticalAlignment = Excel.Constants.xlTop
                        sheet.Cells(int5thTableStarCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                        sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                        sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                        int5thTableStarCount = int5thTableStarCount + 1
                        intLrowNo = intLrowNo + 1
                        intTable5Count = intTable5Count - 1


                        If intTable5Count = 0 Then

                            sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int5thTableStarCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(int5thTableStarCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            sheet.Cells(int5thTableStarCount, 6) = "Total"
                            sheet.Cells(int5thTableStarCount, 6).font.bold = True
                            sheet.Cells(int5thTableStarCount, 6).VerticalAlignment = Excel.Constants.xlCenter
                            sheet.Cells(int5thTableStarCount, 6).HorizontalAlignment = Excel.Constants.xlCenter
                            'sheet.Range(sheet.Cells(int4thTableStarCount, 5), sheet.Cells(int4thTableStarCount, 6)).Merge()

                            sheet.Cells(int5thTableStarCount, 7) = intFKOCurrentReading.ToString()

                        End If


                    End While

                End If
                sheet.Protect("RANNBSP@2010")

                strMonthlyAccountsRptName = strMonthlyAccountsRptName.Replace("/", "-")
               

                Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyAccountsRptName & ".xls"
                xlApp.StatusBar = True
                xlApp.Visible = True

                If (File.Exists(StrPath)) Then
                    File.Delete(StrPath)
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                Else
                    xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
                End If

            End If

        Catch ex As Exception
            xlApp.Visible = True
        End Try

    End Sub

    Private Sub DispatchAnalysisAndStockRptFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DispatchAnalysisAndStockRptFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dtpDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpDate.MaxDate = GlobalPPT.FiscalYearToDate
        Dim TempDate As Date = dtpDate.Value
        Dim NowDate As Date = Now()
        If Now() >= GlobalPPT.FiscalYearFromDate And dtpDate.Value <= GlobalPPT.FiscalYearFromDate Then
            dtpDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        End If

        dtpDate.MaxDate = dtpDate.Value
        If GlobalPPT.strLang <> "en" Then
            ' btnSearch.Text = "Mencari"
            btnClose.Text = "Tutup"
            btnViewReport.Text = "Lihat Laporan"
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class