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
Imports System.Globalization
Imports System.Windows.Forms.RowStyle

Public Class DailyProductionRptFrm


    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Cursor = Cursors.WaitCursor
       
        ''ProductionMillWorkingHours(dtpDate.Value)
        ViewReport(dtpDate.Value)

        Cursor = Cursors.Arrow

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
        'xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\DailyProductionReport_CPO.xlsx")

        Dim ReportDirectory As String = String.Empty
        Dim TemPath As String = Application.StartupPath & "\Production\Report\Excel\Daily_Production_Report_CPO_Template.xls"

        'Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\Daily_Production_Report_CPO_Template.xls"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(TemPath)
        Else
            MsgBox("Daily production report template missing. Please contact system administrator.")
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

        sheet.Cells(2, 2) = "Estate/Mill : " & GlobalPPT.strEstateName.Substring(GlobalPPT.strEstateName.IndexOf("-") + 1)
        sheet.Cells(2, 6) = "DATE : " & Format(dtpDate.Value, "dd/MM/yyyy")  'from date
        'sheet.Cells(2, 14) = "Date : " & Format(dtpDate.Value, "dd/MM/yyyy")  'from date
        sheet.Cells(1, 14) = "PRINT DATE : " & Format(DateTime.Now, "dd/MM/yyyy")  'from date
        'sheet.Cells(3, 9) = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")  'from date
        'sheet.Cells(3, 11) = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy") 'to date
        sheet.Cells(1, 6) = "CPO DAILY PRODUCTION REPORT" ' & Format(dtpDate.Value, "ddMMyyyy") & ""

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
        cmd.CommandText = "[Production].[DailyProductionReport]"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@Date", Format(dtpDate.Value, "yyyy/MM/dd"))

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "DailyProductionReport")

        'Try

        If ds.Tables(0) IsNot Nothing Then

            If ds.Tables(0).Rows.Count > 0 Then

                With sheet
                    'FFB()
                    ''.Cells(6, 7) = ds.Tables(0).Rows(0)("Today_FFB")
                    ''.Cells(6, 13) = ds.Tables(0).Rows(0)("ToMonth_FFB")
                    ''.Cells(6, 16) = ds.Tables(0).Rows(0)("ToYear_FFB")
                    ''.Cells(6, 7).numberformat = "0.000"
                    ''.Cells(6, 13).numberformat = "0.000"
                    ''.Cells(6, 16).numberformat = "0.000"
                    'Balance Brought Forward
                    .Cells(7, 7) = ds.Tables(0).Rows(0)("Today_BalanceFFBBFQty")
                    .Cells(7, 7).numberformat = "0.000"
                    ''.Cells(7, 13) = ds.Tables(0).Rows(0)("ToMonth_BalanceFFBBFQty")
                    ''.Cells(7, 16) = ds.Tables(0).Rows(0)("ToYear_BalanceFFBBFQty")
                    ''.Cells(7, 13).numberformat = "0.000"
                    ''.Cells(7, 16).numberformat = "0.000"
                End With
            End If

            Dim liRowCount As Integer = 8
            Dim ldFFBSumFromREA As Decimal = 0
            Dim ldFFBSumFromOthers As Decimal = 0
            If ds.Tables(1) IsNot Nothing Then 'Estates
                For Each dr In ds.Tables(1).Rows
                    With sheet
                        .Cells(liRowCount, 3) = dr("Name").ToString
                        .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                        .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(dr("Today_NetWeight").ToString), 3)
                        .Cells(liRowCount, 7).numberformat = "0.000"
                        .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 8) = "Kg"
                        .Cells(liRowCount, 10) = dr("NoTrips").ToString
                        .Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 11) = "Trip"
                        .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(dr("ToMonth_NetWeight").ToString), 3)
                        .Cells(liRowCount, 13).numberformat = "0.000"
                        .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 14) = "Kg"
                        .Cells(liRowCount, 16) = Math.Round(Convert.ToDecimal(dr("ToYear_NetWeight").ToString), 3)
                        .Cells(liRowCount, 16).numberformat = "0.000"
                        .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 17) = "Kg"
                    End With
                    liRowCount = liRowCount + 1
                    ldFFBSumFromREA += Convert.ToDecimal(dr("Today_NetWeight"))
                Next
            End If

            'Total FFB received from REA
            'sheet.Cells(liRowCount, 3).font.bold = True
            'sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            'sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
            'sheet.Cells(liRowCount, 3) = "Total FFB received from REA"
            'sheet.Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ldFFBSumFromREA), 3)
            'sheet.Cells(liRowCount, 7).numberformat = "0.000"
            'sheet.Cells(liRowCount, 8) = "Kg"
            'liRowCount = liRowCount + 1

            'commented by palani
            'liRowCount = liRowCount - 1

            If ds.Tables(2) IsNot Nothing Then
                For Each dr In ds.Tables(2).Rows
                    With sheet
                        .Cells(liRowCount, 3) = dr("Name").ToString
                        .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                        .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(dr("Today_NetWeight").ToString), 3)
                        .Cells(liRowCount, 7).numberformat = "0.000"
                        .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 8) = "Kg"
                        .Cells(liRowCount, 10) = dr("NoTrips").ToString
                        .Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 11) = "Trip"
                        .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(dr("ToMonth_NetWeight").ToString), 3)
                        sheet.Cells(liRowCount, 13).numberformat = "0.000"
                        .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 14) = "Kg"
                        .Cells(liRowCount, 16) = Math.Round(Convert.ToDecimal(dr("ToYear_NetWeight").ToString), 3)
                        sheet.Cells(liRowCount, 16).numberformat = "0.000"
                        .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 17) = "Kg"
                    End With
                    liRowCount = liRowCount + 1
                    ldFFBSumFromOthers += Convert.ToDecimal(dr("Today_NetWeight"))
                Next
            End If

            Dim averageCageLorryWeight As Decimal = Math.Round(Convert.ToDecimal(0), 2)

            With sheet

                ''Total FFB Received from Outside Estates
                .Cells(liRowCount, 3).font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3) = "Total FFB Received from Outside Estates"
                .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ldFFBSumFromOthers), 3)
                .Cells(liRowCount, 7).numberformat = "0.000"
                .Cells(liRowCount, 8) = "Kg"

                'FFB Received Today
                liRowCount = liRowCount + 1

                .Cells(liRowCount, 3).font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3) = "FFB Received Today"
                .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal((ldFFBSumFromREA + ldFFBSumFromOthers)), 3)
                .Cells(liRowCount, 7).numberformat = "0.000"
                .Cells(liRowCount, 7) = Math.Round(Val(ds.Tables(0).Rows(0)("today_FFBReceived").ToString), 3)
                .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(liRowCount, 8) = "Kg"

                'FFB Received MTD

                .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal((ldFFBSumFromREA + ldFFBSumFromOthers)), 3)
                .Cells(liRowCount, 13).numberformat = "0.000"
                .Cells(liRowCount, 13) = Math.Round(Val(ds.Tables(0).Rows(0)("today_FFBReceivedMTD").ToString), 3)
                .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(liRowCount, 14) = "Kg"



                .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                '  .Cells(liRowCount, 16) = Math.Round(Convert.ToDecimal((ldFFBSumFromREA + ldFFBSumFromOthers)), 3)
                .Cells(liRowCount, 16).numberformat = "0.000"
                .Cells(liRowCount, 16) = Math.Round(Val(ds.Tables(0).Rows(0)("today_FFBReceivedYTD").ToString), 3)
                .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(liRowCount, 17) = "Kg"

                If ds.Tables(0).Rows.Count > 0 Then

                    'Total FFB on Mill
                    liRowCount = liRowCount + 1

                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Total FFB on Mill"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_BalanceFFBBFQty")) + Convert.ToDecimal(ds.Tables(0).Rows(0)("today_FFBReceived"))), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8) = "Kg"



                    'FFB Processed
                    liRowCount = liRowCount + 2

                    .Cells(liRowCount, 2) = "2"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "FFB Processed"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_FFBProcessedACT").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8) = "Kg"
                    .Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 10) = ds.Tables(0).Rows(0)("Today_LorryPrcessedACT").ToString
                    ' .Cells(liRowCount, 10).numberformat = "0.000"
                    .Cells(liRowCount, 11) = "Lorry"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 13) = Math.Round(Val(ds.Tables(0).Rows(0)("ToMonth_FFBProcessedACT").ToString), 3)
                    .Cells(liRowCount, 13).numberformat = "0.000"
                    .Cells(liRowCount, 14) = "Kg"
                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 16) = Math.Round(Val(ds.Tables(0).Rows(0)("ToYear_FFBProcessedACT").ToString), 3)
                    .Cells(liRowCount, 16).numberformat = "0.000"
                    .Cells(liRowCount, 17) = "Kg"

                    'Balance Carried Forward
                    liRowCount = liRowCount + 2

                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Balance Carried Forward"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_BalanceFFBCFQty").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8) = "Kg"
                    .Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 10) = ds.Tables(0).Rows(0)("Today_BalanceFFBCFNoLorry").ToString
                    .Cells(liRowCount, 11).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 11) = "Lorry"
                    '.Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    '.Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("ToMonth_BalanceFFBCFQty").ToString), 3)
                    '.Cells(liRowCount, 13).numberformat = "0.000"
                    '.Cells(liRowCount, 14) = "Kg"

                    'Extraction 							
                    ' ''liRowCount = liRowCount + 2

                    ' ''.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 17)).Merge()
                    ' ''.Cells(liRowCount, 10).font.bold = True
                    ' ''.Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlCenter
                    ' ''.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 17)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    ' ''.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 17)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    '' ''sheet.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 17)).Fill(Excel.XlColorIndex.xlColorIndexAutomatic) = Excel.XlFillWith.xlFillWithContents
                    '' ''sheet.Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    '' ''sheet.Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ' ''.Cells(liRowCount, 10) = "Extraction"

                    'Average Cage/Lorry Weight 		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft
                    .Cells(liRowCount, 3) = "Average Cage/Lorry Weight"
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlRight

                    If Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_LorryPrcessedACT")) > 0 Then
                        averageCageLorryWeight = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_FFBProcessedACT")) / Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_LorryPrcessedACT")), 2)
                    End If

                    .Cells(liRowCount, 7) = averageCageLorryWeight.ToString()

                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"




                    'CPO Produced
                    liRowCount = liRowCount + 2

                    .Cells(liRowCount, 2) = "3"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "CPO Produced"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_CPOQtyToday").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"

                    '' cpo produced monthtodate

                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("month_cpoqty").ToString), 3)
                    .Cells(liRowCount, 13).numberformat = "0.000"
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "Kg"

                    '' cpo produced year-to-date

                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 16) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("ToYear_CPOQtyToday").ToString), 3)
                    .Cells(liRowCount, 16).numberformat = "0.000"
                    .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 17) = "Kg"


                    'Modified by kumar
                    ''Oil Extraction

                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Oil Extraction"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_OER").ToString), 2)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    '   .Cells(liRowCount, 13) = ds.Tables(0).Rows(0)("ToMonth_OER").ToString 
                    If Val(ds.Tables(0).Rows(0)("ToMonth_CPOQtyToday").ToString) <> 0 And Val(ds.Tables(0).Rows(0)("ToMonth_FFBProcessedACT").ToString) <> 0 Then
                        '.Cells(liRowCount, 13) = Math.Round((Val(ds.Tables(0).Rows(0)("ToMonth_CPOQtyToday").ToString) * 100 / (Val(ds.Tables(0).Rows(0)("ToMonth_FFBProcessedACT").ToString) - Val(ds.Tables(0).Rows(0)("ToMonth_LossOfKernelMTD").ToString))), 2)
                        .Cells(liRowCount, 13) = Math.Round((Val(ds.Tables(0).Rows(0)("ToMonth_CPOQtyToday").ToString) * 100 / (Val(ds.Tables(0).Rows(0)("ToMonth_FFBProcessedACT").ToString))), 2)
                    Else
                        .Cells(liRowCount, 13) = 0
                    End If
                    .Cells(liRowCount, 13).numberformat = "0.00"
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "%"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'Modified by kumar

                    '' .Cells(liRowCount, 16) = ds.Tables(0).Rows(0)("ToYear_OER").ToString

                    If Val(ds.Tables(0).Rows(0)("ToYear_CPOQtyToday").ToString) <> 0 And Val(ds.Tables(0).Rows(0)("ToYear_FFBProcessedACT").ToString) <> 0 Then
                        '.Cells(liRowCount, 16) = Math.Round((Val(ds.Tables(0).Rows(0)("ToYear_CPOQtyToday").ToString) * 100 / (Val(ds.Tables(0).Rows(0)("ToYear_FFBProcessedACT").ToString) - Val(ds.Tables(0).Rows(0)("ToYear_LossOfKernelYTD").ToString))), 2)
                        .Cells(liRowCount, 16) = Math.Round((Val(ds.Tables(0).Rows(0)("ToYear_CPOQtyToday").ToString) * 100 / (Val(ds.Tables(0).Rows(0)("ToYear_FFBProcessedACT").ToString))), 2)
                    Else
                        .Cells(liRowCount, 16) = 0
                    End If

                    .Cells(liRowCount, 16).numberformat = "0.00"
                    .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 17) = "%"
                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'Kernel Produced

                    liRowCount = liRowCount + 2

                    .Cells(liRowCount, 2) = "4"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Kernel Produced"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Val(ds.Tables(0).Rows(0)("Today_KernelQtyToday").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8) = "Kg"
                    ''.Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ''.Cells(liRowCount, 10) = Math.Round(Val(ds.Tables(0).Rows(0)("Today_KER").ToString), 2)
                    ''.Cells(liRowCount, 10).numberformat = "0.00"
                    ''.Cells(liRowCount, 11) = "%"

                    'Modified by kumar
                    ' .Cells(liRowCount, 13) = ds.Tables(0).Rows(0)("ToMonth_KER").ToString


                    ''.Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ' ''Modified by kumar
                    ' '' .Cells(liRowCount, 16) = ds.Tables(0).Rows(0)("ToYear_KER").ToString
                    ''If Val(ds.Tables(0).Rows(0)("ToYear_KernelQtyToday").ToString) <> 0 And Val(ds.Tables(0).Rows(0)("ToYear_FFBProcessedACT").ToString) <> 0 Then
                    ''    .Cells(liRowCount, 16) = Math.Round((Val(ds.Tables(0).Rows(0)("ToYear_KernelQtyToday").ToString) * 100 / (Val(ds.Tables(0).Rows(0)("ToYear_FFBProcessedACT").ToString) - Val(ds.Tables(0).Rows(0)("ToYear_LossOfKernelYTD").ToString))), 2)
                    ''Else
                    ''    .Cells(liRowCount, 16) = 0
                    ''End If

                    ''.Cells(liRowCount, 16).numberformat = "0.00"
                    ''.Cells(liRowCount, 17) = "%"

                    ''Kernel Extraction Rate

                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Kernel Extraction Rate"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Val(ds.Tables(0).Rows(0)("today_ker").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"


                    If Val(ds.Tables(0).Rows(0)("ToMonth_KernelQtyToday").ToString) <> 0 And Val(ds.Tables(0).Rows(0)("ToMonth_FFBProcessedACT").ToString) <> 0 Then
                        '.Cells(liRowCount, 13) = Math.Round((Val(ds.Tables(0).Rows(0)("ToMonth_KernelQtyToday").ToString) * 100 / (Val(ds.Tables(0).Rows(0)("ToMonth_FFBProcessedACT").ToString) - Val(ds.Tables(0).Rows(0)("ToMonth_LossOfKernelMTD").ToString))), 2)
                        .Cells(liRowCount, 13) = Math.Round((Val(ds.Tables(0).Rows(0)("ToMonth_KernelQtyToday").ToString) * 100 / (Val(ds.Tables(0).Rows(0)("ToMonth_FFBProcessedACT").ToString))), 2)
                    Else
                        .Cells(liRowCount, 13) = 0
                    End If
                    .Cells(liRowCount, 13).numberformat = "0.00"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "%"

                    If Val(ds.Tables(0).Rows(0)("ToYear_KernelQtyToday").ToString) <> 0 And Val(ds.Tables(0).Rows(0)("ToYear_FFBProcessedACT").ToString) <> 0 Then
                        .Cells(liRowCount, 16) = Math.Round((Val(ds.Tables(0).Rows(0)("ToYear_KernelQtyToday").ToString) * 100 / (Val(ds.Tables(0).Rows(0)("ToYear_FFBProcessedACT").ToString) - Val(ds.Tables(0).Rows(0)("ToYear_LossOfKernelYTD").ToString))), 2)
                    Else
                        .Cells(liRowCount, 16) = 0
                    End If
                    '.Cells(liRowCount, 16) = Math.Round((Val(ds.Tables(0).Rows(0)("toyear_Kernelqtytoday").ToString)) / (Val(ds.Tables(0).Rows(0)("ToYear_FFBProcessedACT").ToString)))
                    .Cells(liRowCount, 16).numberformat = "0.00"
                    .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 17) = "%"
                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous



                    'CPO Quality
                    liRowCount = liRowCount + 2
                    .Cells(liRowCount, 2) = "5"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "CPO Quality"

                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "FFA"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_CPOQualityFFAP").ToString), 2)
                    ''.Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_CPOQualityFFAP").ToString), 2)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"

                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("today_cpoqualityffapmtd").ToString), 2)
                    .Cells(liRowCount, 13).numberformat = "0.00"
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "%"


                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Moisture"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_CPOQualityMoistureP").ToString), 2)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Dirt"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_CPOQualityDirtP").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"

                    'Kernel Quality
                    liRowCount = liRowCount + 2
                    .Cells(liRowCount, 2) = "6"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Kernel Quality"

                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Moisture"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_KernelQualityMoistureP").ToString), 2)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 8) = "%"
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Dirt"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_KernelQualityDirtP").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8) = "%"
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Broken Kernel"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_KernelQualityBrokenKernel").ToString), 2)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 8) = "%"

                    'Transhipment  CPO
                    liRowCount = liRowCount + 2
                    .Cells(liRowCount, 2) = "7"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Transhipment  CPO"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_TransCPO").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"



                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("MTD_transcpo").ToString), 3)
                    .Cells(liRowCount, 13).numberformat = "0.000"
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "Kg"





                    'Kernel Transferred to KCP
                    liRowCount = liRowCount + 2
                    .Cells(liRowCount, 2) = "8"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Kernel Transferred to KCP"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_TransKCP").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"

                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("MTD_transKernel").ToString), 3)
                    .Cells(liRowCount, 13).numberformat = "0.000"
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "Kg"





                Else
                    'Total FFB on Mill
                    liRowCount = liRowCount + 1

                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Total FFB on Mill"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0 + ldFFBSumFromREA + ldFFBSumFromOthers), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"

                    'FFB Processed
                    liRowCount = liRowCount + 2

                    .Cells(liRowCount, 2) = "2"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "FFB Processed"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"
                    .Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 10) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 11).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 11) = "Lorry"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 13).numberformat = "0.000"
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "Kg"
                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 16) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 17) = "Kg"

                    'Balance Carried Forward
                    liRowCount = liRowCount + 2

                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Balance Carried Forward"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"
                    .Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 10) = Math.Round(Convert.ToDecimal(0), 2)
                    .Cells(liRowCount, 11).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 11) = "Lorry"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 13).numberformat = "0.000"
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "Kg"

                    'Extraction 							
                    ''liRowCount = liRowCount + 2

                    ''.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 17)).Merge()
                    ''.Cells(liRowCount, 10).font.bold = True
                    ''.Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlCenter
                    ''.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 17)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    ''.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 17)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ' ''sheet.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 17)).Fill(Excel.XlColorIndex.xlColorIndexAutomatic) = Excel.XlFillWith.xlFillWithContents
                    ' ''sheet.Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    ' ''sheet.Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ''.Cells(liRowCount, 10) = "Extraction"

                    'CPO Produced
                    liRowCount = liRowCount + 1

                    .Cells(liRowCount, 2) = "3"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "CPO Produced"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"
                    ''.Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ''.Cells(liRowCount, 10) = Math.Round(Convert.ToDecimal(0), 2)
                    ''.Cells(liRowCount, 10).numberformat = "0.00"
                    ''.Cells(liRowCount, 11) = "%"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(0), 2)
                    .Cells(liRowCount, 13).numberformat = "0.00"
                    ''.Cells(liRowCount, 14) = "%"
                    ''.Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ''.Cells(liRowCount, 16) = Math.Round(Convert.ToDecimal(0), 2)
                    ''.Cells(liRowCount, 16).numberformat = "0.00"
                    ''.Cells(liRowCount, 17) = "%"

                    'Kernel Produced
                    liRowCount = liRowCount + 2

                    .Cells(liRowCount, 2) = "4"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Kernel Produced"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"
                    ''.Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ''.Cells(liRowCount, 10) = Math.Round(Convert.ToDecimal(0), 2)
                    ''.Cells(liRowCount, 10).numberformat = "0.00"
                    ''.Cells(liRowCount, 11) = "%"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(0), 2)
                    .Cells(liRowCount, 13).numberformat = "0.00"
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "%"
                    ''.Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ''.Cells(liRowCount, 16) = Math.Round(Convert.ToDecimal(0), 2)
                    ''.Cells(liRowCount, 16).numberformat = "0.00"
                    ''.Cells(liRowCount, 17) = "%"

                    'CPO Quality
                    liRowCount = liRowCount + 2
                    .Cells(liRowCount, 2) = "5"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "CPO Quality"

                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "FFA"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 2)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Moisture"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 2)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Dirt"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"

                    'Kernel Quality
                    liRowCount = liRowCount + 2
                    .Cells(liRowCount, 2) = "6"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Kernel Quality"

                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Moisture"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 2)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Dirt"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3) = "Broken Kernel"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 2)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "%"

                    'Transhipment  CPO
                    liRowCount = liRowCount + 2
                    .Cells(liRowCount, 2) = "7"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Transhipment  CPO"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"

                    'Kernel Transferred to KCP
                    liRowCount = liRowCount + 2
                    .Cells(liRowCount, 2) = "8"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Kernel Transferred to KCP"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"
                End If

                'Loading CPO
                liRowCount = liRowCount + 2
                .Cells(liRowCount, 2) = "9"
                .Cells(liRowCount, 3).font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3) = "Loading CPO"

            End With
            liRowCount = liRowCount + 1

            If ds.Tables(3) IsNot Nothing Then
                For Each dr In ds.Tables(3).Rows
                    With sheet
                        .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                        .Cells(liRowCount, 3) = dr("Location").ToString
                        .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(dr("Today_LoadCPO").ToString), 3)
                        .Cells(liRowCount, 7).numberformat = "0.000"
                        .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                        .Cells(liRowCount, 8) = "Kg"

                        .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(dr("MTD_loadcpo").ToString), 3)
                        .Cells(liRowCount, 13).numberformat = "0.000"
                        .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                        .Cells(liRowCount, 14) = "Kg"


                    End With

                    liRowCount = liRowCount + 1
                Next
            End If

            If ds.Tables(3).Rows.Count = 0 Then
                liRowCount = liRowCount - 1
                sheet.Cells(liRowCount, 7).numberformat = "0.000"
                sheet.Cells(liRowCount, 7) = "0.000"
                sheet.Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                sheet.Cells(liRowCount, 8) = "Kg"
                'sheet.Cells(liRowCount, 13).numberformat = "0.000"
                'sheet.Cells(liRowCount, 13) = "0.000"
                'sheet.Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                'sheet.Cells(liRowCount, 14) = "Kg"
                liRowCount = liRowCount + 1
            End If


            'If ds.Tables(4) IsNot Nothing Then
            '    For Each dr In ds.Tables(4).Rows
            '        With sheet
            '            .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
            '            .Cells(liRowCount, 3) = dr("Location").ToString
            '            '.Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(dr("Today_LoadCPO").ToString), 3)
            '            '.Cells(liRowCount, 7).numberformat = "0.000"
            '            '.Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            '            '.Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            '            '.Cells(liRowCount, 8) = "Kg"

            '            .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(dr("MTD_loadcpo").ToString), 3)
            '            .Cells(liRowCount, 13).numberformat = "0.000"
            '            .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            '            .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            '            .Cells(liRowCount, 14) = "Kg"


            '        End With

            '        liRowCount = liRowCount + 1
            '    Next
            'End If

            'If ds.Tables(4).Rows.Count = 0 Then
            '    liRowCount = liRowCount - 1
            '    'sheet.Cells(liRowCount, 7).numberformat = "0.000"
            '    'sheet.Cells(liRowCount, 7) = "0.000"
            '    'sheet.Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            '    'sheet.Cells(liRowCount, 8) = "Kg"
            '    sheet.Cells(liRowCount, 13).numberformat = "0.000"
            '    sheet.Cells(liRowCount, 13) = "0.000"
            '    sheet.Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            '    sheet.Cells(liRowCount, 14) = "Kg"
            '    liRowCount = liRowCount + 1
            'End If


            With sheet

                'CPO Stocks	
                liRowCount = liRowCount + 1
                .Cells(liRowCount, 2) = "10"
                .Cells(liRowCount, 3).font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3) = "CPO Stocks"


                'Quality in storage

                .Cells(liRowCount, 10).font.bold = True
                .Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 17)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 17)).Merge()
                .Cells(liRowCount, 10) = "Quality in storage"
                .Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlCenter
                '' Moist & Dirt

                liRowCount = liRowCount + 1
                .Cells(liRowCount, 10) = "FFA"
                .Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlCenter

                .Cells(liRowCount, 13) = "Moisture"
                .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 13).HorizontalAlignment = Excel.Constants.xlCenter

                .Cells(liRowCount, 16) = "Dirt"
                .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 16).HorizontalAlignment = Excel.Constants.xlCenter


            End With
            If ds.Tables(0).Rows.Count > 0 Then

                With sheet

                    'Last Stock		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Last Stock"
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("LastStockCPO").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"

                End With
            Else
                With sheet

                    'Last Stock		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Last Stock"
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"

                End With
            End If

            'Tank List
            Dim ldTotalStocks As Decimal = 0
            liRowCount = liRowCount + 1
            If ds.Tables(5) IsNot Nothing Then
                sheet.Cells(liRowCount, 3) = "Mill"



                liRowCount = liRowCount + 1
                For Each dr In ds.Tables(5).Rows
                    With sheet
                        .Cells(liRowCount, 3).numberformat = "@"
                        .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                        .Cells(liRowCount, 3) = dr("TankNo").ToString
                        .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(dr("CurrentReading").ToString), 3)
                        .Cells(liRowCount, 7).numberformat = "0.000"
                        .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 8) = "Kg"

                        .Cells(liRowCount, 10) = Math.Round(Convert.ToDecimal(dr("FFAP").ToString), 3)
                        .Cells(liRowCount, 10).numberformat = "0.00"
                        .Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlRight
                        .Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 11).HorizontalAlignment = Excel.Constants.xlCenter
                        .Cells(liRowCount, 11) = "%"

                        .Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(dr("MoistureP").ToString), 3)
                        .Cells(liRowCount, 13).numberformat = "0.00"
                        .Cells(liRowCount, 13).HorizontalAlignment = Excel.Constants.xlRight
                        .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                        .Cells(liRowCount, 14) = "%"

                        .Cells(liRowCount, 16) = Math.Round(Convert.ToDecimal(dr("DirtP").ToString), 3)
                        .Cells(liRowCount, 16).numberformat = "0.000"
                        .Cells(liRowCount, 16).HorizontalAlignment = Excel.Constants.xlRight
                        .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                        .Cells(liRowCount, 17) = "%"


                    End With
                    ldTotalStocks += Convert.ToDecimal(dr("CurrentReading"))
                    liRowCount = liRowCount + 1
                Next
            End If


            If ds.Tables(8) IsNot Nothing Then
                sheet.Cells(liRowCount, 3) = "Pontoon"
                liRowCount = liRowCount + 1
                For Each dr In ds.Tables(8).Rows
                    With sheet
                        .Cells(liRowCount, 3).numberformat = "@"
                        .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                        .Cells(liRowCount, 3) = dr("TankNo").ToString
                        .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(dr("CurrentReading").ToString), 3)
                        .Cells(liRowCount, 7).numberformat = "0.000"
                        .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                        .Cells(liRowCount, 8) = "Kg"
                    End With
                    ldTotalStocks += Convert.ToDecimal(dr("CurrentReading"))
                    liRowCount = liRowCount + 1
                Next
            End If


            With sheet

                'Total Stocks		
                'liRowCount = liRowCount + 1
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3).font.bold = True
                .Cells(liRowCount, 3) = "Total Stocks"
                .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ldTotalStocks.ToString), 3)
                .Cells(liRowCount, 7).numberformat = "0.000"
                .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(liRowCount, 8) = "Kg"

                'Palm Kernel Stocks	

                liRowCount = liRowCount + 2
                .Cells(liRowCount, 2) = "11"
                .Cells(liRowCount, 3).font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3) = "Palm Kernel Stocks"


                '!!!!!!!!!!!! Removed on Request by JOHN on 22 April 2014 -----------------

                ''Quality in storage for kernal

                '.Cells(liRowCount, 10).font.bold = True
                '.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 14)).Merge()
                '.Cells(liRowCount, 10) = "Quality in storage"
                '.Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlCenter
                '' Moist & Dirt

                liRowCount = liRowCount + 1

                '.Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlCenter
                '.Cells(liRowCount, 10) = "Moisture"
                '.Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                '.Cells(liRowCount, 13).HorizontalAlignment = Excel.Constants.xlCenter
                '.Cells(liRowCount, 13) = "Dirt"
                '.Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous



                If ds.Tables(0).Rows.Count > 0 Then

                    'Last Stock		

                    ''''''liRowCount = liRowCount + 1

                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Last Stock"
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("LastStockKernel").ToString), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"




                Else

                    'Last Stock		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Last Stock"
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"


                End If

            End With

            'Total Stock Kernel	
            Dim ldTotalStocksKernel As Decimal = 0
            liRowCount = liRowCount + 1
            If ds.Tables(6) IsNot Nothing Then
                For Each dr In ds.Tables(6).Rows
                    With sheet
                        .Cells(liRowCount, 3).numberformat = "@"
                        .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                        .Cells(liRowCount, 3) = dr("KernelName").ToString
                        .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft
                        .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(dr("CurrentReading").ToString), 3)
                        .Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                        .Cells(liRowCount, 7).numberformat = "0.000"
                        .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                        .Cells(liRowCount, 8) = "Kg"

                        '.Cells(liRowCount, 10) = Math.Round(Convert.ToDecimal(dr("FFAP").ToString), 3)
                        '.Cells(liRowCount, 10).numberformat = "0.000"
                        '.Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlRight
                        '.Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        '.Cells(liRowCount, 11).HorizontalAlignment = Excel.Constants.xlCenter
                        '.Cells(liRowCount, 11) = "%"

                        '.Cells(liRowCount, 10) = Math.Round(Convert.ToDecimal(dr("moisterP").ToString), 3)
                        '.Cells(liRowCount, 10).numberformat = "0.000"
                        '.Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlRight
                        '.Cells(liRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        '.Cells(liRowCount, 11).HorizontalAlignment = Excel.Constants.xlCenter
                        '.Cells(liRowCount, 11) = "%"

                        '.Cells(liRowCount, 13) = Math.Round(Convert.ToDecimal(dr("DirtP").ToString), 3)
                        '.Cells(liRowCount, 13).numberformat = "0.000"
                        '.Cells(liRowCount, 13).HorizontalAlignment = Excel.Constants.xlRight
                        '.Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                        '.Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                        '.Cells(liRowCount, 14) = "%"




                    End With
                    ldTotalStocksKernel += Convert.ToDecimal(dr("CurrentReading"))
                    liRowCount = liRowCount + 1
                Next
            End If

            With sheet

                'Total Stock Kernel		
                'liRowCount = liRowCount + 1
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3).font.bold = True
                .Cells(liRowCount, 3) = "Total Stock Kernel"
                .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(ldTotalStocksKernel.ToString), 3)
                .Cells(liRowCount, 7).numberformat = "0.000"
                .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(liRowCount, 8) = "Kg"

                'Capacity Mill	
                liRowCount = liRowCount + 2
                .Cells(liRowCount, 2) = "12"
                .Cells(liRowCount, 3).font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3) = "Capacity Mill"

                If ds.Tables(0).Rows.Count > 0 Then

                    'Process Start Time		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft
                    .Cells(liRowCount, 3) = "Process Start Time"
                    .Cells(liRowCount, 7).numberformat = "@"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                    .Cells(liRowCount, 7) = ds.Tables(0).Rows(0)("StartTime").ToString
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Hrs"

                    'Process Stop Time		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft
                    .Cells(liRowCount, 3) = "Process Stop Time"
                    .Cells(liRowCount, 7).numberformat = "@"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                    .Cells(liRowCount, 7) = ds.Tables(0).Rows(0)("StopTime").ToString
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Hrs"

                    'Total Process Time	
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft
                    .Cells(liRowCount, 3) = "Total Process Time"
                    .Cells(liRowCount, 7).numberformat = "@"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                    .Cells(liRowCount, 7) = ds.Tables(0).Rows(0)("TotalTime").ToString
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Hrs"

                    'Mechanical Break Down
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Mechanical Break Down"
                    .Cells(liRowCount, 7).numberformat = "@"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                    .Cells(liRowCount, 7) = ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    '.Cells(liRowCount, 7).numberformat = "@"
                    '.Cells(liRowCount, 7).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 8) = "Hrs"
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter

                    .Cells(liRowCount, 13).numberformat = "@"
                    .Cells(liRowCount, 13).HorizontalAlignment = Excel.Constants.xlRight
                    .Cells(liRowCount, 13) = ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString
                    '.Cells(liRowCount, 13).numberformat = "@"
                    '.Cells(liRowCount, 13).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14) = "Hrs"
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter

                    .Cells(liRowCount, 16).numberformat = "@"
                    .Cells(liRowCount, 16).HorizontalAlignment = Excel.Constants.xlRight
                    .Cells(liRowCount, 16) = ds.Tables(0).Rows(0)("ToYear_MechanicalBD").ToString
                    '.Cells(liRowCount, 13).numberformat = "@"
                    '.Cells(liRowCount, 13).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 17) = "Hrs"

                    'Electrical Break Down
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Electrical Break Down"
                    .Cells(liRowCount, 7).numberformat = "@"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 7) = ds.Tables(0).Rows(0)("Today_ElectricalBD").ToString
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Hrs"

                    .Cells(liRowCount, 13).numberformat = "@"
                    .Cells(liRowCount, 13).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 13) = ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "Hrs"


                    .Cells(liRowCount, 16).numberformat = "@"
                    .Cells(liRowCount, 16).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 16) = ds.Tables(0).Rows(0)("ToYear_ElectricalBD").ToString
                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 17) = "Hrs"

                    'Processing Break Down
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Processing Break Down"
                    .Cells(liRowCount, 7).numberformat = "@"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 7) = ds.Tables(0).Rows(0)("Today_ProcessingBD").ToString

                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Hrs"

                    .Cells(liRowCount, 13).numberformat = "@"
                    .Cells(liRowCount, 13).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 13) = ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "Hrs"

                    .Cells(liRowCount, 16).numberformat = "@"
                    .Cells(liRowCount, 16).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 16) = ds.Tables(0).Rows(0)("ToYear_ProcessingBD").ToString
                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 17) = "Hrs"

                    'Dim ls As String = ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.Length - 3)



                    Dim ltsToDate_TotalBreakDown As TimeSpan = New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.Substring(ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                    + New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("Today_ElectricalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("Today_ElectricalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("Today_ElectricalBD").ToString.Substring(ds.Tables(0).Rows(0)("Today_ElectricalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                    + New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("Today_ProcessingBD").ToString.Substring(0, ds.Tables(0).Rows(0)("Today_ProcessingBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("Today_ProcessingBD").ToString.Substring(ds.Tables(0).Rows(0)("Today_ProcessingBD").ToString.IndexOf(":") + 1, 2)), 0)





                    Dim ltsToMonth_TotalBreakDown As TimeSpan = New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.Substring(ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                    + New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.Substring(ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                    + New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.Substring(ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.IndexOf(":") + 1, 2)), 0)

                    Dim ltsYear_TotalBreakDown As TimeSpan = New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("Toyear_MechanicalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("Toyear_MechanicalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("Toyear_MechanicalBD").ToString.Substring(ds.Tables(0).Rows(0)("ToYear_MechanicalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                   + New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToYear_ElectricalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToYear_ElectricalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToYear_ElectricalBD").ToString.Substring(ds.Tables(0).Rows(0)("ToYear_ElectricalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                   + New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToYear_ProcessingBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToYear_ProcessingBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToYear_ProcessingBD").ToString.Substring(ds.Tables(0).Rows(0)("ToYear_ProcessingBD").ToString.IndexOf(":") + 1, 2)), 0)


                    'Total Break Down
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Total Break Down"
                    .Cells(liRowCount, 7).numberformat = "@"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 7) = (ltsToDate_TotalBreakDown.Hours).ToString().PadLeft(2, "0") + ":" + ltsToDate_TotalBreakDown.Minutes.ToString().PadLeft(2, "0") 'Convert.ToString(ltsToDate_TotalBreakDown).Substring(0, 5)
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Hrs"

                    .Cells(liRowCount, 13).numberformat = "@"
                    .Cells(liRowCount, 13).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 13) = (ltsToMonth_TotalBreakDown.Hours).ToString().PadLeft(2, "0") + ":" + ltsToMonth_TotalBreakDown.Minutes.ToString().PadLeft(2, "0") 'Convert.ToString(ltsToMonth_TotalBreakDown).Substring(0, 5)
                    '.Cells(liRowCount, 13).numberformat = "@"
                    '.Cells(liRowCount, 13).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "Hrs"

                    .Cells(liRowCount, 16).numberformat = "@"
                    .Cells(liRowCount, 16).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 16) = (ltsYear_TotalBreakDown.Hours + (ltsYear_TotalBreakDown.Days * 24)).ToString().PadLeft(2, "0") + ":" + ltsYear_TotalBreakDown.Minutes.ToString().PadLeft(2, "0") 'Convert.ToString(ltsToMonth_TotalBreakDown).Substring(0, 5)
                    '.Cells(liRowCount, 13).numberformat = "@" 
                    '.Cells(liRowCount, 13).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 17) = "Hrs"

                    Dim ltsToDate_EffectiveProcesingHours As TimeSpan = New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("TotalTime").ToString.Substring(0, ds.Tables(0).Rows(0)("TotalTime").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("TotalTime").ToString.Substring(ds.Tables(0).Rows(0)("TotalTime").ToString.IndexOf(":") + 1, 2)), 0).Subtract(ltsToDate_TotalBreakDown).Duration()

                    'Effective Procesing Hours

                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Effective Procesing Hours"
                    .Cells(liRowCount, 7).numberformat = "@"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 7) = (ltsToDate_EffectiveProcesingHours.Hours).ToString().PadLeft(2, "0") + ":" + ltsToDate_EffectiveProcesingHours.Minutes.ToString().PadLeft(2, "0")  'Convert.ToString(ltsToDate_EffectiveProcesingHours).Substring(0, 5)
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Hrs"






                    Dim eph1 As String
                    Dim eph As String
                    eph1 = ToaddHours(ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString, ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString)

                    eph = ToaddHours(eph1, ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString)

                    Dim epMTD As String

                    epMTD = TosubHours((ds.Tables(0).Rows(0)("MonthToDateHrs").ToString), eph)




                    ' ''Dim EPHMTD As TimeSpan = New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("MonthToDateHrs").ToString.Substring(0, ds.Tables(0).Rows(0)("MonthToDateHrs").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("MonthToDateHrs").ToString.Substring(ds.Tables(0).Rows(0)("MonthToDateHrs").ToString.IndexOf(":") + 1, 2)), 0) _
                    ' ''- (New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.Substring(ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                    ' ''+ New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.Substring(ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                    ' ''+ New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.Substring(ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.IndexOf(":") + 1, 2)), 0))

                    .Cells(liRowCount, 13).numberformat = "@"
                    .Cells(liRowCount, 13).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 13) = epMTD
                    '' .Cells(liRowCount, 13) = (EPHMTD.Hours).ToString().PadLeft(2, "0") + ":" + EPHMTD.Minutes.ToString().PadLeft(2, "0") 'Convert.ToString(EPHMTD).Substring(0, 5)
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "Hrs"


                    Dim eph3 As String
                    Dim eph2 As String
                    eph3 = ToaddHours(ds.Tables(0).Rows(0)("ToYear_MechanicalBD").ToString, ds.Tables(0).Rows(0)("ToYear_ElectricalBD").ToString)

                    eph2 = ToaddHours(eph3, ds.Tables(0).Rows(0)("ToYear_ProcessingBD").ToString)

                    Dim epYTD As String

                    epYTD = TosubHours((ds.Tables(0).Rows(0)("YearToDateHrs").ToString), eph2)

                    .Cells(liRowCount, 16).numberformat = "@"
                    .Cells(liRowCount, 16).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 16) = epYTD
                    '' .Cells(liRowCount, 13) = (EPHMTD.Hours).ToString().PadLeft(2, "0") + ":" + EPHMTD.Minutes.ToString().PadLeft(2, "0") 'Convert.ToString(EPHMTD).Substring(0, 5)
                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 17) = "Hrs"





                    Dim ldThroughput As Decimal

                    If ltsToDate_EffectiveProcesingHours.Hours > 0 Or ltsToDate_EffectiveProcesingHours.Minutes > 0 Then
                        ldThroughput = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_FFBProcessedACT")) / (ltsToDate_EffectiveProcesingHours.Hours + (ltsToDate_EffectiveProcesingHours.Minutes / 60)), 2)
                    Else
                        ldThroughput = 0D
                    End If


                    'Throughput		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Throughput"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                    .Cells(liRowCount, 7) = ldThroughput
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg/hr"



                    Dim lTotalOPHrs As Decimal

                    Dim Hrs As Integer
                    Dim Min As Integer
                    Dim str As String
                    Dim strArr() As String
                    'Dim count As Integer
                    str = epMTD
                    strArr = str.Split(":")
                    Hrs = strArr(0)
                    Min = strArr(1)

                    Min = (Min / 60) * 100
                    Dim lmin As String
                    lmin = "." + Convert.ToString(Min)

                    lTotalOPHrs = Hrs + lmin




                    Dim MTDThroughput As Decimal

                    If lTotalOPHrs > 0 Then
                        MTDThroughput = (Val(ds.Tables(0).Rows(0)("tomonth_ffbprocessedact") / lTotalOPHrs))
                        '  .Cells(liRowCount, 13).numberformat = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("tomonth_ffbprocessedact")) / lTotalOPHrs)
                    Else
                        MTDThroughput = 0D
                    End If


                    ''  tomonth_ffbprocessedact/EPHMTD

                    .Cells(liRowCount, 13) = MTDThroughput
                    .Cells(liRowCount, 13).HorizontalAlignment = Excel.Constants.xlRight
                    .Cells(liRowCount, 13).numberformat = "0.00"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 14) = "Kg/hr"
                    '  .Cells(liRowCount, 15).numberformat = MTDThroughput

                    'Throuput YTD
                    str = epYTD
                    strArr = str.Split(":")
                    Hrs = strArr(0)
                    Min = strArr(1)

                    Min = (Min / 60) * 100
                    'Dim lmin As String
                    lmin = "." + Convert.ToString(Min)

                    lTotalOPHrs = Hrs + lmin




                    Dim YTDThroughput As Decimal

                    If lTotalOPHrs > 0 Then
                        YTDThroughput = (Val(ds.Tables(0).Rows(0)("toyear_ffbprocessedact") / lTotalOPHrs))
                        '  .Cells(liRowCount, 13).numberformat = Math.Round(Convert.ToDecimal(ds.Tables(0).Rows(0)("tomonth_ffbprocessedact")) / lTotalOPHrs)
                    Else
                        YTDThroughput = 0D
                    End If


                    ''  tomonth_ffbprocessedact/EPHMTD

                    .Cells(liRowCount, 16) = YTDThroughput
                    .Cells(liRowCount, 16).HorizontalAlignment = Excel.Constants.xlRight
                    .Cells(liRowCount, 16).numberformat = "0.00"
                    .Cells(liRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 17).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 17) = "Kg/hr"
                    '  .Cells(liRowCount, 15).numberformat = MTDThroughput




                    'Total Press Hours 
                    liRowCount = liRowCount + 2
                    .Cells(liRowCount, 2) = "13"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Total Press Hours "

                    'Number of Units in Operation		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Number of Units in Operation"
                    .Cells(liRowCount, 7) = ds.Tables(0).Rows(0)("NoUnitsOperation").ToString
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Units"

                    'Total Press Hours  		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Total Press Hours"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 7).NumberFormat = "@"
                    .Cells(liRowCount, 7) = ds.Tables(0).Rows(0)("TotalPressHours").ToString
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Hrs"

                    Dim ltsTotalPressHours As TimeSpan

                    If Convert.ToString(ds.Tables(0).Rows(0)("TotalPressHours")) <> String.Empty Then
                        ltsTotalPressHours = New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("TotalPressHours").ToString.Substring(0, ds.Tables(0).Rows(0)("TotalPressHours").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("TotalPressHours").ToString.Substring(ds.Tables(0).Rows(0)("TotalPressHours").ToString.IndexOf(":") + 1, 2)), 0)
                    End If



                    'Average Press Throughput  		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Average Press Throughput"
                    If ltsTotalPressHours.TotalHours > 0 Or ltsTotalPressHours.Minutes > 0 Then
                        ' If ltsTotalPressHours.Minutes > 0 Then
                        '    .Cells(liRowCount, 7) = Math.Round((Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_FFBProcessedACT")) / (ltsTotalPressHours.TotalHours + (ltsTotalPressHours.Minutes / 60))), 2)
                        'Else
                        .Cells(liRowCount, 7) = Math.Round((Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_FFBProcessedACT")) / (ltsTotalPressHours.TotalHours)), 2)
                        'End If

                    Else
                        .Cells(liRowCount, 7) = 0
                    End If
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg/hr"

                    ''--------------- moved average cage to FFP processed

                Else

                    'Process Start Time		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Process Start Time"
                    .Cells(liRowCount, 7) = "00:00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8) = "Hrs"

                    'Process Stop Time		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Process Stop Time"
                    .Cells(liRowCount, 7) = "00:00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8) = "Hrs"

                    'Total Process Time	
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Total Process Time"
                    .Cells(liRowCount, 7) = "00:00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8) = "Hrs"

                    'Mechanical Break Down
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Mechanical Break Down"
                    .Cells(liRowCount, 7) = "00:00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8) = "Hrs"
                    .Cells(liRowCount, 13) = "0:00"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14) = "Hrs"

                    'Electrical Break Down
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Electrical Break Down"
                    .Cells(liRowCount, 7) = "00:00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8) = "Hrs"
                    .Cells(liRowCount, 13) = "00:00"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14) = "Hrs"

                    'Processing Break Down
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Processing Break Down"
                    .Cells(liRowCount, 7) = "00:00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8) = "Hrs"
                    .Cells(liRowCount, 13) = "00:00"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14) = "Hrs"

                    ''Dim ls As String = ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.Length - 3)
                    'Dim ltsToDate_TotalBreakDown As TimeSpan = New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.Substring(ds.Tables(0).Rows(0)("Today_MechanicalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                    '+ New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("Today_ElectricalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("Today_ElectricalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("Today_ElectricalBD").ToString.Substring(ds.Tables(0).Rows(0)("Today_ElectricalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                    '+ New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("Today_ProcessingBD").ToString.Substring(0, ds.Tables(0).Rows(0)("Today_ProcessingBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("Today_ProcessingBD").ToString.Substring(ds.Tables(0).Rows(0)("Today_ProcessingBD").ToString.IndexOf(":") + 1, 2)), 0)

                    'Dim ltsToMonth_TotalBreakDown As TimeSpan = New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.Substring(ds.Tables(0).Rows(0)("ToMonth_MechanicalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                    '+ New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.Substring(ds.Tables(0).Rows(0)("ToMonth_ElectricalBD").ToString.IndexOf(":") + 1, 2)), 0) _
                    '+ New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.Substring(0, ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.Substring(ds.Tables(0).Rows(0)("ToMonth_ProcessingBD").ToString.IndexOf(":") + 1, 2)), 0)

                    'Total Break Down
                    liRowCount = liRowCount + 1
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Total Break Down"
                    .Cells(liRowCount, 7) = "0:00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8) = "Hrs"
                    .Cells(liRowCount, 13) = "0:00"
                    .Cells(liRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 14) = "Hrs"

                    'Dim ltsToDate_EffectiveProcesingHours As TimeSpan = New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("TotalTime").ToString.Substring(0, ds.Tables(0).Rows(0)("TotalTime").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("TotalTime").ToString.Substring(ds.Tables(0).Rows(0)("TotalTime").ToString.IndexOf(":") + 1, 2)), 0).Subtract(ltsToDate_TotalBreakDown).Duration()

                    'Effective Procesing Hours
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Effective Procesing Hours"
                    .Cells(liRowCount, 7) = "0:00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8) = "Hrs"

                    'Dim ldThroughput As Decimal = Convert.ToDecimal(ds.Tables(0).Rows(0)("Today_FFBProcessedACT")) / (ltsToDate_EffectiveProcesingHours.Hours + (ltsToDate_EffectiveProcesingHours.Minutes / 60))

                    'Throughput		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Throughput"
                    .Cells(liRowCount, 7) = "0.00"
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8) = "Kg/hr"


                    'Total Press Hours 
                    liRowCount = liRowCount + 2
                    .Cells(liRowCount, 2) = "13"
                    .Cells(liRowCount, 3).font.bold = True
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Total Press Hours "

                    'Number of Units in Operation		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Number of Units in Operation"
                    .Cells(liRowCount, 7) = 0
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Units"

                    'Total Press Hours  		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Total Press Hours"
                    .Cells(liRowCount, 7).NumberFormat = "@"
                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .Cells(liRowCount, 7) = "0:00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Hrs"

                    Dim ltsTotalPressHours As TimeSpan

                    If Convert.ToString(ds.Tables(0).Rows(0)("TotalPressHours")) <> String.Empty Then
                        ltsTotalPressHours = New TimeSpan(Convert.ToInt32(ds.Tables(0).Rows(0)("TotalPressHours").ToString.Substring(0, ds.Tables(0).Rows(0)("TotalPressHours").ToString.Length - 3)), Convert.ToInt32(ds.Tables(0).Rows(0)("TotalPressHours").ToString.Substring(ds.Tables(0).Rows(0)("TotalPressHours").ToString.IndexOf(":") + 1, 2)), 0)
                    End If



                    'Average Press Throughput  		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3) = "Average Press Throughput"
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 2)
                    .Cells(liRowCount, 7).numberformat = "0.00"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg/hr"

                    'Average Cage/Lorry Weight 		
                    liRowCount = liRowCount + 1
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                    .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft
                    .Cells(liRowCount, 3) = "Average Cage/Lorry Weight"
                    .Cells(liRowCount, 7) = Math.Round(Convert.ToDecimal(0), 3)
                    .Cells(liRowCount, 7).numberformat = "0.000"
                    .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Cells(liRowCount, 8).HorizontalAlignment = Excel.Constants.xlCenter
                    .Cells(liRowCount, 8) = "Kg"

                End If

                'Press Performance
                liRowCount = liRowCount + 2
                .Cells(liRowCount, 2) = "14"
                .Cells(liRowCount, 3).font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3) = "Press Performance"

                If ds.Tables(7) IsNot Nothing Then
                    Dim lbLine1 As Boolean = True
                    Dim lbLine2 As Boolean = False
                    For Each dr In ds.Tables(7).Rows
                        With sheet

                            If Convert.ToString(dr("Stage")) = "Line 1" Then

                                If lbLine1 = True Then
                                    liRowCount = liRowCount + 1
                                    'Line 1
                                    '.Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    '.Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 3) = "Line 1"
                                    .Cells(liRowCount, 3).font.bold = True
                                    .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft

                                    liRowCount = liRowCount + 1

                                    'Press No
                                    .Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 3) = "Press No"
                                    .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlCenter
                                    'Capacity
                                    .Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 5) = "Capacity"
                                    .Cells(liRowCount, 5).HorizontalAlignment = Excel.Constants.xlCenter
                                    'Operating Hours
                                    .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Merge()
                                    .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 7) = "Operating Hours"
                                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlCenter
                                    'Age of Screw
                                    .Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Merge()
                                    .Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 10) = "Age of Screw"
                                    .Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlCenter
                                    'Screw Status
                                    .Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Merge()
                                    .Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 13) = "Screw Status"
                                    .Cells(liRowCount, 13).HorizontalAlignment = Excel.Constants.xlCenter

                                    lbLine1 = False
                                    lbLine2 = True

                                    liRowCount = liRowCount + 1

                                End If

                            ElseIf Convert.ToString(dr("Stage")) = "Line 2" Then

                                If lbLine2 = True Then

                                    liRowCount = liRowCount + 1
                                    'Line 1
                                    '.Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    '.Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 3) = "Line 2"
                                    .Cells(liRowCount, 3).font.bold = True
                                    .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft

                                    liRowCount = liRowCount + 1

                                    'Press No
                                    .Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 3) = "Press No"
                                    .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlCenter
                                    'Capacity
                                    .Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 5) = "Capacity"
                                    .Cells(liRowCount, 5).HorizontalAlignment = Excel.Constants.xlCenter
                                    'Operating Hours
                                    .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Merge()
                                    .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 7) = "Operating Hours"
                                    .Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlCenter
                                    'Age of Screw
                                    .Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Merge()
                                    .Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 10) = "Age of Screw"
                                    .Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlCenter
                                    'Screw Status
                                    .Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Merge()
                                    .Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Cells(liRowCount, 13) = "Screw Status"
                                    .Cells(liRowCount, 13).HorizontalAlignment = Excel.Constants.xlCenter

                                    lbLine2 = False

                                    liRowCount = liRowCount + 1

                                End If

                            End If

                            'liRowCount = liRowCount + 1

                            .Cells(liRowCount, 3) = dr("PressNo").ToString
                            .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft
                            .Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(liRowCount, 5) = dr("Capacity").ToString
                            .Cells(liRowCount, 5).HorizontalAlignment = Excel.Constants.xlRight
                            .Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(liRowCount, 5).numberformat = "0.000"
                            .Cells(liRowCount, 7).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                            .Cells(liRowCount, 7).NumberFormat = "@"
                            .Cells(liRowCount, 7) = dr("OperatingHours").ToString
                            .Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlRight
                            .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Merge()
                            .Cells(liRowCount, 10).numberformat = "@"
                            .Cells(liRowCount, 10) = dr("ScrewAge").ToString
                            .Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlRight
                            '.Cells(liRowCount, 10).numberformat = "0.00"
                            .Cells(liRowCount, 10).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                            .Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Merge()
                            .Cells(liRowCount, 13) = dr("ScrewStatus").ToString
                            .Cells(liRowCount, 13).HorizontalAlignment = Excel.Constants.xlLeft
                            .Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Merge()
                        End With
                        liRowCount = liRowCount + 1
                    Next
                End If
                'Press Performance
                'liRowCount = liRowCount + 2
                ''Press No
                '.Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Cells(liRowCount, 3) = "Press No"
                '.Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlCenter
                ''Capacity
                '.Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Cells(liRowCount, 5) = "Capacity"
                '.Cells(liRowCount, 5).HorizontalAlignment = Excel.Constants.xlCenter
                ''Operating Hours
                '.Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Merge()
                '.Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Cells(liRowCount, 7) = "Operating Hours"
                '.Cells(liRowCount, 7).HorizontalAlignment = Excel.Constants.xlCenter
                ''Age of Screw
                '.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Merge()
                '.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Range(sheet.Cells(liRowCount, 10), sheet.Cells(liRowCount, 11)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Cells(liRowCount, 10) = "Age of Screw"
                '.Cells(liRowCount, 10).HorizontalAlignment = Excel.Constants.xlCenter
                ''Screw Status
                '.Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Merge()
                '.Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Cells(liRowCount, 13) = "Screw Status"
                '.Cells(liRowCount, 13).HorizontalAlignment = Excel.Constants.xlCenter

                'Laboratory Data
                liRowCount = liRowCount + 2
                .Cells(liRowCount, 2) = "15"
                .Cells(liRowCount, 3).font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3) = "Laboratory Data"
                .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft

                liRowCount = liRowCount + 2

                Dim rowLabDataStart As Integer = liRowCount 'used for formatting

                .Cells(liRowCount, 7) = "Standard"
                .Cells(liRowCount, 7).font.bold = True
                .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Merge()
                .Cells(liRowCount, 9) = "LINE A"
                .Cells(liRowCount, 9).font.bold = True
                .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Merge()
                .Cells(liRowCount, 11) = "LINE B"
                .Cells(liRowCount, 11).font.bold = True
                .Range(sheet.Cells(liRowCount, 11), sheet.Cells(liRowCount, 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 11), sheet.Cells(liRowCount, 12)).Merge()

                .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 12)).HorizontalAlignment = Excel.Constants.xlCenter

                liRowCount = liRowCount + 1
                .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft
                .Cells(liRowCount, 3) = "Moisture"
                .Cells(liRowCount, 3).font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()

                liRowCount = liRowCount + 1
                .Cells(liRowCount, 3) = "Kernel from Depricarper / Nut Polishing Drum"
                .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()

                Dim dvMoisture As DataView = ds.Tables(10).DefaultView
                dvMoisture.RowFilter = "Location = 'Depricarper' OR Location = 'Nut Polishing Drum'"
                Dim dtMoisture As DataTable = dvMoisture.ToTable()

                For Each dr In dtMoisture.Rows
                    If dr("Location") = "Depricarper" Then
                        If dr("Line") = "A" Then
                            .Cells(liRowCount, 9) = dr("MoistureP")
                            .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Merge()
                            .Cells(liRowCount, 9).HorizontalAlignment = Excel.Constants.xlRight
                        ElseIf dr("Line") = "B" Then
                            .Cells(liRowCount, 11) = dr("MoistureP")
                            .Range(sheet.Cells(liRowCount, 11), sheet.Cells(liRowCount, 12)).Merge()
                            .Cells(liRowCount, 11).HorizontalAlignment = Excel.Constants.xlRight
                        End If
                    ElseIf dr("Location") = "Nut Polishing Drum" Then
                        If dr("Line") = "A" Then
                            .Cells(liRowCount, 9) = dr("MoistureP")
                            .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Merge()
                            .Cells(liRowCount, 9).HorizontalAlignment = Excel.Constants.xlRight
                        ElseIf dr("Line") = "B" Then
                            .Cells(liRowCount, 11) = dr("MoistureP")
                            .Range(sheet.Cells(liRowCount, 11), sheet.Cells(liRowCount, 12)).Merge()
                            .Cells(liRowCount, 11).HorizontalAlignment = Excel.Constants.xlRight
                        End If
                    End If
                Next

                liRowCount = liRowCount + 2
                .Cells(liRowCount, 3) = "Efficiency Ripple Mill/Efficiency Rolek"
                .Cells(liRowCount, 3).font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft

                Dim dtRolexMill As DataTable = ds.Tables(9)
                liRowCount = liRowCount + 1
                .Cells(liRowCount, 3) = "No. 1"
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft

                .Cells(liRowCount + 1, 3) = "No. 2"
                .Range(sheet.Cells(liRowCount + 1, 3), sheet.Cells(liRowCount + 1, 5)).Merge()
                .Cells(liRowCount + 1, 3).HorizontalAlignment = Excel.Constants.xlLeft

                .Cells(liRowCount + 2, 3) = "Average"
                .Range(sheet.Cells(liRowCount + 2, 3), sheet.Cells(liRowCount + 2, 5)).Merge()
                .Cells(liRowCount + 2, 3).HorizontalAlignment = Excel.Constants.xlLeft

                'standards table
                Dim dtStandard As DataTable = ds.Tables(13)
                If (dtStandard.Rows.Count > 0) Then
                    If dtRolexMill.Rows.Count > 0 Then
                        'rolex standard
                        .Cells(liRowCount, 7) = dtStandard.Rows(0).Item("GenEfficiencyRolex").ToString()
                        .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Merge()
                        .Cells(liRowCount + 1, 7) = dtStandard.Rows(0).Item("GenEfficiencyRolex").ToString()
                        .Range(sheet.Cells(liRowCount + 1, 7), sheet.Cells(liRowCount + 1, 8)).Merge()
                        .Cells(liRowCount + 2, 7) = dtStandard.Rows(0).Item("GenEfficiencyRolex").ToString()
                        .Range(sheet.Cells(liRowCount + 2, 7), sheet.Cells(liRowCount + 2, 8)).Merge()
                    Else
                        'ripple mill standard
                        .Cells(liRowCount, 7) = dtStandard.Rows(0).Item("GenEfficiencyRippleMill").ToString()
                        .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Merge()
                        .Cells(liRowCount + 1, 7) = dtStandard.Rows(0).Item("GenEfficiencyRippleMill").ToString()
                        .Range(sheet.Cells(liRowCount + 1, 7), sheet.Cells(liRowCount + 1, 8)).Merge()
                        .Cells(liRowCount + 2, 7) = dtStandard.Rows(0).Item("GenEfficiencyRippleMill").ToString()
                        .Range(sheet.Cells(liRowCount + 2, 7), sheet.Cells(liRowCount + 2, 8)).Merge()
                    End If
                End If


                Dim rolexAvg_A As Double = 0
                Dim rolexAvg_B As Double = 0
                Dim rolexCount_A As Int16 = 0
                Dim rolexCount_B As Int16 = 0

                Dim rippleAvg_A As Double = 0
                Dim rippleAvg_B As Double = 0
                Dim rippleCount_A As Int16 = 0
                Dim rippleCount_B As Int16 = 0

                For Each dr In dtRolexMill.Rows
                    If dr("Equipment") = "Rolek" Then
                        If dr("No") = "1" Then
                            If dr("Line") = "A" Then
                                .Cells(liRowCount, 9) = dr("EfficiencyP")
                                .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Merge()
                                rolexAvg_A += Convert.ToDouble(dr("EfficiencyP"))
                                rolexCount_A += 1
                            ElseIf dr("Line") = "B" Then
                                .Cells(liRowCount, 11) = dr("EfficiencyP")
                                .Range(sheet.Cells(liRowCount, 11), sheet.Cells(liRowCount, 12)).Merge()
                                rolexAvg_B += Convert.ToDouble(dr("EfficiencyP"))
                                rolexCount_B += 1
                            End If
                        ElseIf dr("No") = "2" Then
                            If dr("Line") = "A" Then
                                .Cells(liRowCount + 1, 9) = dr("EfficiencyP")
                                .Range(sheet.Cells(liRowCount + 1, 9), sheet.Cells(liRowCount + 1, 10)).Merge()
                                rolexAvg_A += Convert.ToDouble(dr("EfficiencyP"))
                                rolexCount_A += 1
                            ElseIf dr("Line") = "B" Then
                                .Cells(liRowCount + 1, 11) = dr("EfficiencyP")
                                .Range(sheet.Cells(liRowCount + 1, 11), sheet.Cells(liRowCount + 1, 12)).Merge()
                                rolexAvg_B += Convert.ToDouble(dr("EfficiencyP"))
                                rolexCount_B += 1
                            End If
                        End If

                    ElseIf dr("Equipment") = "Ripple Mill" Then
                        If dr("No") = "1" Then
                            If dr("Line") = "A" Then
                                .Cells(liRowCount, 9) = dr("EfficiencyP")
                                .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Merge()
                                rippleAvg_A += Convert.ToDouble(dr("EfficiencyP"))
                                rippleCount_A += 1
                            ElseIf dr("Line") = "B" Then
                                .Cells(liRowCount, 11) = dr("EfficiencyP")
                                .Range(sheet.Cells(liRowCount, 11), sheet.Cells(liRowCount, 12)).Merge()
                                rippleAvg_B += Convert.ToDouble(dr("EfficiencyP"))
                                rippleCount_B += 1
                            End If
                        ElseIf dr("No") = "2" Then
                            If dr("Line") = "A" Then
                                .Cells(liRowCount + 1, 9) = dr("EfficiencyP")
                                .Range(sheet.Cells(liRowCount + 1, 9), sheet.Cells(liRowCount + 1, 10)).Merge()
                                rippleAvg_A += Convert.ToDouble(dr("EfficiencyP"))
                                rippleCount_A += 1
                            ElseIf dr("Line") = "B" Then
                                .Cells(liRowCount + 1, 11) = dr("EfficiencyP")
                                .Range(sheet.Cells(liRowCount + 1, 11), sheet.Cells(liRowCount + 1, 12)).Merge()
                                rippleAvg_B += Convert.ToDouble(dr("EfficiencyP"))
                                rippleCount_B += 1
                            End If
                        End If
                    End If
                Next

                'Average of Rolex A 
                If rolexCount_A <> 0 And rolexCount_B <> 0 Then
                    If rolexAvg_A <> 0 Then
                        rolexAvg_A = (rolexAvg_A / rolexCount_A)
                    End If
                    .Cells(liRowCount + 2, 9) = (rolexAvg_A).ToString("F")
                    .Range(sheet.Cells(liRowCount + 2, 9), sheet.Cells(liRowCount + 2, 10)).Merge()
                    'Average of Rolex B 
                    If rolexAvg_B <> 0 Then
                        rolexAvg_B = (rolexAvg_B / rolexCount_B)
                    End If
                    .Cells(liRowCount + 2, 11) = (rolexAvg_B).ToString("F")
                    .Range(sheet.Cells(liRowCount + 2, 11), sheet.Cells(liRowCount + 2, 12)).Merge()
                Else
                    'Average of Ripple A 
                    If rippleAvg_A <> 0 Then
                        rippleAvg_A = (rippleAvg_A / rippleCount_A)
                    End If
                    .Cells(liRowCount + 2, 9) = (rippleAvg_A).ToString("F")
                    .Range(sheet.Cells(liRowCount + 2, 9), sheet.Cells(liRowCount + 2, 10)).Merge()

                    'Average of Ripple B 
                    If rippleAvg_B <> 0 Then
                        rippleAvg_B = (rippleAvg_B / rippleCount_B)
                    End If
                    .Cells(liRowCount + 2, 11) = (rippleAvg_B).ToString("F")
                    .Range(sheet.Cells(liRowCount + 2, 11), sheet.Cells(liRowCount + 2, 12)).Merge()
                End If
                .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount + 4, 12)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount + 4, 12)).NumberFormat = "0.00"

                liRowCount = liRowCount + 5

                .Cells(liRowCount, 3) = "Kernel Losses"
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                .Cells(liRowCount, 3).font.bold = True

                .Cells(liRowCount + 1, 3) = "Fibre Cyc."
                .Range(sheet.Cells(liRowCount + 1, 3), sheet.Cells(liRowCount + 1, 5)).Merge()
                .Cells(liRowCount + 2, 3) = "LTDS 1"
                .Range(sheet.Cells(liRowCount + 2, 3), sheet.Cells(liRowCount + 2, 5)).Merge()
                .Cells(liRowCount + 3, 3) = "LTDS 2"
                .Range(sheet.Cells(liRowCount + 3, 3), sheet.Cells(liRowCount + 3, 5)).Merge()
                .Cells(liRowCount + 4, 3) = "LTDS 3"
                .Range(sheet.Cells(liRowCount + 4, 3), sheet.Cells(liRowCount + 4, 5)).Merge()
                .Cells(liRowCount + 5, 3) = "LTDS 4"
                .Range(sheet.Cells(liRowCount + 5, 3), sheet.Cells(liRowCount + 5, 5)).Merge()
                .Cells(liRowCount + 6, 3) = "Hydro Cyclone"
                .Range(sheet.Cells(liRowCount + 6, 3), sheet.Cells(liRowCount + 6, 5)).Merge()

                Dim dtKernel As DataTable = ds.Tables(11)

                For Each dr In dtKernel.Rows
                    If dr("Line") = "A" Then
                        .Cells(liRowCount + 1, 9) = dr("FibreCycP")
                        .Range(sheet.Cells(liRowCount + 1, 9), sheet.Cells(liRowCount + 1, 10)).Merge()
                        .Cells(liRowCount + 2, 9) = dr("LTDS1P")
                        .Range(sheet.Cells(liRowCount + 2, 9), sheet.Cells(liRowCount + 2, 10)).Merge()
                        .Cells(liRowCount + 3, 9) = dr("LTDS2P")
                        .Range(sheet.Cells(liRowCount + 3, 9), sheet.Cells(liRowCount + 3, 10)).Merge()
                        .Cells(liRowCount + 4, 9) = dr("LTDS3P")
                        .Range(sheet.Cells(liRowCount + 4, 9), sheet.Cells(liRowCount + 4, 10)).Merge()
                        .Cells(liRowCount + 5, 9) = dr("LTDS4P")
                        .Range(sheet.Cells(liRowCount + 5, 9), sheet.Cells(liRowCount + 5, 10)).Merge()
                        .Cells(liRowCount + 6, 9) = dr("HydroCycP")
                        .Range(sheet.Cells(liRowCount + 6, 9), sheet.Cells(liRowCount + 6, 10)).Merge()
                    ElseIf dr("Line") = "B" Then
                        .Cells(liRowCount + 1, 11) = dr("FibreCycP")
                        .Range(sheet.Cells(liRowCount + 1, 11), sheet.Cells(liRowCount + 1, 12)).Merge()
                        .Cells(liRowCount + 2, 11) = dr("LTDS1P")
                        .Range(sheet.Cells(liRowCount + 2, 11), sheet.Cells(liRowCount + 2, 12)).Merge()
                        .Cells(liRowCount + 3, 11) = dr("LTDS2P")
                        .Range(sheet.Cells(liRowCount + 3, 11), sheet.Cells(liRowCount + 3, 12)).Merge()
                        .Cells(liRowCount + 4, 11) = dr("LTDS3P")
                        .Range(sheet.Cells(liRowCount + 4, 11), sheet.Cells(liRowCount + 4, 12)).Merge()
                        .Cells(liRowCount + 5, 11) = dr("LTDS4P")
                        .Range(sheet.Cells(liRowCount + 5, 11), sheet.Cells(liRowCount + 5, 12)).Merge()
                        .Cells(liRowCount + 6, 11) = dr("HydroCycP")
                        .Range(sheet.Cells(liRowCount + 6, 11), sheet.Cells(liRowCount + 6, 12)).Merge()
                    End If
                Next

                'kernel standard
                If (dtStandard.Rows.Count > 0) Then
                    .Cells(liRowCount + 1, 7) = dtStandard.Rows(0).Item("KLFibreCyclone").ToString()
                    .Range(sheet.Cells(liRowCount + 1, 7), sheet.Cells(liRowCount + 1, 8)).Merge()
                    .Cells(liRowCount + 2, 7) = dtStandard.Rows(0).Item("KLLTDS1").ToString()
                    .Range(sheet.Cells(liRowCount + 2, 7), sheet.Cells(liRowCount + 2, 8)).Merge()
                    .Cells(liRowCount + 3, 7) = dtStandard.Rows(0).Item("KLLTDS2").ToString()
                    .Range(sheet.Cells(liRowCount + 3, 7), sheet.Cells(liRowCount + 3, 8)).Merge()
                    .Cells(liRowCount + 4, 7) = dtStandard.Rows(0).Item("KLLTDS3").ToString()
                    .Range(sheet.Cells(liRowCount + 4, 7), sheet.Cells(liRowCount + 4, 8)).Merge()
                    .Cells(liRowCount + 5, 7) = dtStandard.Rows(0).Item("KLLTDS4").ToString()
                    .Range(sheet.Cells(liRowCount + 5, 7), sheet.Cells(liRowCount + 5, 8)).Merge()
                    .Cells(liRowCount + 6, 7) = dtStandard.Rows(0).Item("KLHydrocyclone").ToString()
                    .Range(sheet.Cells(liRowCount + 6, 7), sheet.Cells(liRowCount + 6, 8)).Merge()
                End If

                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount + 6, 7)).HorizontalAlignment = Excel.Constants.xlLeft
                .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount + 6, 12)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount + 6, 12)).NumberFormat = "0.00"

                liRowCount = liRowCount + 8

                'KernelQuality
                ' data was retrieved earlier for Moisture which includes kernelquality data as well
                dvMoisture.RowFilter = "Location = 'Fresh Production' OR Location = 'After Dryer'"
                Dim dtKernelQuality As DataTable = dvMoisture.ToTable()

                .Cells(liRowCount, 3) = "Kernel Quality"
                .Cells(liRowCount, 3).Font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()

                liRowCount = liRowCount + 1
                .Cells(liRowCount, 3) = "Fresh Production"
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 4)).Merge()
                .Cells(liRowCount, 5) = "Dirt"
                .Cells(liRowCount + 1, 5) = "Moisture"
                .Cells(liRowCount + 2, 5) = "Broken Kernel"

                .Cells(liRowCount + 3, 3) = "After Dryer"
                .Range(sheet.Cells(liRowCount + 3, 3), sheet.Cells(liRowCount + 3, 4)).Merge()
                .Cells(liRowCount + 3, 5) = "Dirt"
                .Cells(liRowCount + 4, 5) = "Moisture"
                .Cells(liRowCount + 5, 5) = "Broken Kernel"

                For Each dr In dtKernelQuality.Rows
                    If dr("Location") = "Fresh Production" Then
                        If dr("Line") = "A" Then
                            .Cells(liRowCount, 9) = dr("DirtP")
                            .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Merge()
                            .Cells(liRowCount + 1, 9) = dr("MoistureP")
                            .Range(sheet.Cells(liRowCount + 1, 9), sheet.Cells(liRowCount + 1, 10)).Merge()
                            .Cells(liRowCount + 2, 9) = dr("BrokenKernel")
                            .Range(sheet.Cells(liRowCount + 2, 9), sheet.Cells(liRowCount + 2, 10)).Merge()
                        ElseIf dr("Line") = "B" Then
                            .Cells(liRowCount, 11) = dr("DirtP")
                            .Range(sheet.Cells(liRowCount, 11), sheet.Cells(liRowCount, 12)).Merge()
                            .Cells(liRowCount + 1, 11) = dr("MoistureP")
                            .Range(sheet.Cells(liRowCount + 1, 11), sheet.Cells(liRowCount + 1, 12)).Merge()
                            .Cells(liRowCount + 2, 11) = dr("BrokenKernel")
                            .Range(sheet.Cells(liRowCount + 2, 11), sheet.Cells(liRowCount + 2, 12)).Merge()
                        End If
                    ElseIf dr("Location") = "After Dryer" Then
                        If dr("Line") = "A" Then
                            .Cells(liRowCount + 3, 9) = dr("DirtP")
                            .Range(sheet.Cells(liRowCount + 3, 9), sheet.Cells(liRowCount + 3, 10)).Merge()
                            .Cells(liRowCount + 4, 9) = dr("MoistureP")
                            .Range(sheet.Cells(liRowCount + 4, 9), sheet.Cells(liRowCount + 4, 10)).Merge()
                            .Cells(liRowCount + 5, 9) = dr("BrokenKernel")
                            .Range(sheet.Cells(liRowCount + 5, 9), sheet.Cells(liRowCount + 5, 10)).Merge()
                        ElseIf dr("Line") = "B" Then
                            .Cells(liRowCount + 3, 11) = dr("DirtP")
                            .Range(sheet.Cells(liRowCount + 3, 11), sheet.Cells(liRowCount + 3, 12)).Merge()
                            .Cells(liRowCount + 4, 11) = dr("MoistureP")
                            .Range(sheet.Cells(liRowCount + 4, 11), sheet.Cells(liRowCount + 4, 12)).Merge()
                            .Cells(liRowCount + 5, 11) = dr("BrokenKernel")
                            .Range(sheet.Cells(liRowCount + 5, 11), sheet.Cells(liRowCount + 5, 12)).Merge()
                        End If
                    End If
                Next

                'kernel quality standard
                If (dtStandard.Rows.Count > 0) Then
                    .Cells(liRowCount, 7) = dtStandard.Rows(0).Item("QltFKDirt").ToString()
                    .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 8)).Merge()
                    .Cells(liRowCount + 1, 7) = dtStandard.Rows(0).Item("QltFKMoisture").ToString()
                    .Range(sheet.Cells(liRowCount + 1, 7), sheet.Cells(liRowCount + 1, 8)).Merge()
                    .Cells(liRowCount + 2, 7) = dtStandard.Rows(0).Item("QltFKBrokenKernel").ToString()
                    .Range(sheet.Cells(liRowCount + 2, 7), sheet.Cells(liRowCount + 2, 8)).Merge()
                    .Cells(liRowCount + 3, 7) = dtStandard.Rows(0).Item("QltKADirt").ToString()
                    .Range(sheet.Cells(liRowCount + 3, 7), sheet.Cells(liRowCount + 3, 8)).Merge()
                    .Cells(liRowCount + 4, 7) = dtStandard.Rows(0).Item("QltKAMoisture").ToString()
                    .Range(sheet.Cells(liRowCount + 4, 7), sheet.Cells(liRowCount + 4, 8)).Merge()
                    .Cells(liRowCount + 5, 7) = dtStandard.Rows(0).Item("QltKABrokenKernel").ToString()
                    .Range(sheet.Cells(liRowCount + 5, 7), sheet.Cells(liRowCount + 5, 8)).Merge()
                End If

                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount + 5, 7)).HorizontalAlignment = Excel.Constants.xlLeft
                .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount + 5, 12)).HorizontalAlignment = Excel.Constants.xlRight
                .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount + 5, 12)).NumberFormat = "0.00"

                liRowCount = liRowCount + 5
                'format lab data
                .Range(sheet.Cells(rowLabDataStart, 7), sheet.Cells(rowLabDataStart, 12)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(rowLabDataStart, 7), sheet.Cells(liRowCount, 7)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(rowLabDataStart, 9), sheet.Cells(liRowCount, 9)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(rowLabDataStart, 11), sheet.Cells(liRowCount, 11)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(rowLabDataStart, 13), sheet.Cells(liRowCount, 13)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 12)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                liRowCount = liRowCount + 2

                '------- Turbine Operations Hours
                sheet.Cells(liRowCount, 2) = "16"
                .Cells(liRowCount, 3) = "Machine Operations Hours"
                .Cells(liRowCount, 3).Font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()


                liRowCount = liRowCount + 1
                Dim turbineStartRow As Int16 = liRowCount

                .Cells(liRowCount, 3) = "Name"
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 4)).Merge()

                .Cells(liRowCount, 5) = "Process"

                .Cells(liRowCount, 6) = "Non Process"
                .Range(sheet.Cells(liRowCount, 6), sheet.Cells(liRowCount, 8)).Merge()

                .Cells(liRowCount, 9) = "Total Operated"
                .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Merge()

                .Cells(liRowCount, 11) = "To Date"
                .Range(sheet.Cells(liRowCount, 11), sheet.Cells(liRowCount, 12)).Merge()

                .Cells(liRowCount, 13) = "Yearly To Date"
                .Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Merge()

                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 14)).Font.Bold = True

                Dim dtMachine As DataTable = ds.Tables(12)


                liRowCount = liRowCount + 1

                For Each dr In dtMachine.Rows
                    .Cells(liRowCount, 3) = dr("MachineName")
                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 4)).Merge()

                    .Cells(liRowCount, 5) = dr("ProcessHours")

                    .Cells(liRowCount, 6) = dr("NonProcessHours")
                    .Range(sheet.Cells(liRowCount, 6), sheet.Cells(liRowCount, 8)).Merge()

                    .Cells(liRowCount, 9) = "'" + dr("TotalHours")
                    .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Merge()

                    .Cells(liRowCount, 11) = "'" + dr("MonthToDateHrs")
                    .Range(sheet.Cells(liRowCount, 11), sheet.Cells(liRowCount, 12)).Merge()

                    .Cells(liRowCount, 13) = "'" + dr("YeartoDateHrs")
                    .Range(sheet.Cells(liRowCount, 13), sheet.Cells(liRowCount, 14)).Merge()


                    .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDot

                    liRowCount = liRowCount + 1
                Next

                .Range(sheet.Cells(turbineStartRow, 5), sheet.Cells(liRowCount, 14)).HorizontalAlignment = Excel.Constants.xlCenter

                '.Range(sheet.Cells(turbineStartRow, 3), sheet.Cells(liRowCount, 3)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Range(sheet.Cells(turbineStartRow, 14), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                '.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 14)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                Dim selection As Excel.Range
                selection = .Range(sheet.Cells(turbineStartRow, 3), sheet.Cells(liRowCount, 14))
                selection.BorderAround(LineStyle:=Excel.XlLineStyle.xlContinuous, Weight:=Excel.XlBorderWeight.xlThin)

                .Range(sheet.Cells(turbineStartRow, 4), sheet.Cells(liRowCount, 4)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(turbineStartRow, 5), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(turbineStartRow, 8), sheet.Cells(liRowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(turbineStartRow, 10), sheet.Cells(liRowCount, 10)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(turbineStartRow, 12), sheet.Cells(liRowCount, 12)).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous



                liRowCount = liRowCount + 2

                '------- Shift Performace
                sheet.Cells(liRowCount, 2) = "17"
                .Cells(liRowCount, 3) = "Shift Performance"
                .Cells(liRowCount, 3).Font.bold = True
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()


                liRowCount = liRowCount + 1
                Dim shiftStartRow As Int16 = liRowCount

                '.Cells(liRowCount, 3) = "Name"
                '.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 4)).Merge()

                .Cells(liRowCount, 5) = "Shift 1"

                .Cells(liRowCount, 6) = "Shift 2"
                .Range(sheet.Cells(liRowCount, 6), sheet.Cells(liRowCount, 8)).Merge()

                .Cells(liRowCount, 9) = "Shift 3"
                .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Merge()


                .Range(sheet.Cells(liRowCount, 5), sheet.Cells(liRowCount, 10)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 10)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                .Range(sheet.Cells(liRowCount, 5), sheet.Cells(liRowCount, 10)).Font.Bold = True

                liRowCount = liRowCount + 1
                .Cells(liRowCount, 3) = "Start Time"
                .Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 4)).Merge()
                .Cells(liRowCount, 3).HorizontalAlignment = Excel.Constants.xlLeft

                .Cells(liRowCount + 1, 3) = "Stop Time"
                .Range(sheet.Cells(liRowCount + 1, 3), sheet.Cells(liRowCount + 1, 4)).Merge()
                .Cells(liRowCount + 1, 3).HorizontalAlignment = Excel.Constants.xlLeft

                .Cells(liRowCount + 2, 3) = "Total Hours"
                .Range(sheet.Cells(liRowCount + 2, 3), sheet.Cells(liRowCount + 2, 4)).Merge()
                .Cells(liRowCount + 2, 3).HorizontalAlignment = Excel.Constants.xlLeft

                .Cells(liRowCount + 3, 3) = "Total Breakdown"
                .Range(sheet.Cells(liRowCount + 3, 3), sheet.Cells(liRowCount + 3, 4)).Merge()
                .Cells(liRowCount + 3, 3).HorizontalAlignment = Excel.Constants.xlLeft

                .Cells(liRowCount + 4, 3) = "Eff Process Hours"
                .Range(sheet.Cells(liRowCount + 4, 3), sheet.Cells(liRowCount + 4, 4)).Merge()
                .Cells(liRowCount + 4, 3).HorizontalAlignment = Excel.Constants.xlLeft

                .Cells(liRowCount + 5, 3) = "Lorry Processed"
                .Range(sheet.Cells(liRowCount + 5, 3), sheet.Cells(liRowCount + 5, 4)).Merge()
                .Cells(liRowCount + 5, 3).HorizontalAlignment = Excel.Constants.xlLeft

                .Cells(liRowCount + 6, 3) = "TPH"
                .Range(sheet.Cells(liRowCount + 6, 3), sheet.Cells(liRowCount + 6, 4)).Merge()
                .Cells(liRowCount + 6, 3).HorizontalAlignment = Excel.Constants.xlLeft

                Dim dtShiftPerf As DataTable = ds.Tables(14)

                If dtShiftPerf.Rows.Count > 0 Then
                    'start time
                    .Cells(liRowCount, 5) = dtShiftPerf.Rows(0)("StartTime1")

                    .Cells(liRowCount, 6) = dtShiftPerf.Rows(0)("StartTime2")
                    .Range(sheet.Cells(liRowCount, 6), sheet.Cells(liRowCount, 8)).Merge()

                    .Cells(liRowCount, 9) = dtShiftPerf.Rows(0)("StartTime3")
                    .Range(sheet.Cells(liRowCount, 9), sheet.Cells(liRowCount, 10)).Merge()

                    'end time
                    .Cells(liRowCount + 1, 5) = dtShiftPerf.Rows(0)("EndTime1")

                    .Cells(liRowCount + 1, 6) = dtShiftPerf.Rows(0)("EndTime2")
                    .Range(sheet.Cells(liRowCount + 1, 6), sheet.Cells(liRowCount + 1, 8)).Merge()

                    .Cells(liRowCount + 1, 9) = dtShiftPerf.Rows(0)("EndTime3")
                    .Range(sheet.Cells(liRowCount + 1, 9), sheet.Cells(liRowCount + 1, 10)).Merge()
                    'Total Breakdown
                    .Cells(liRowCount + 3, 5) = dtShiftPerf.Rows(0)("TotalBreakdown1")

                    .Cells(liRowCount + 3, 6) = dtShiftPerf.Rows(0)("TotalBreakdown2")
                    .Range(sheet.Cells(liRowCount + 3, 6), sheet.Cells(liRowCount + 3, 8)).Merge()

                    .Cells(liRowCount + 3, 9) = dtShiftPerf.Rows(0)("TotalBreakdown3")
                    .Range(sheet.Cells(liRowCount + 3, 9), sheet.Cells(liRowCount + 3, 10)).Merge()

                    'lorry processed
                    .Cells(liRowCount + 5, 5) = dtShiftPerf.Rows(0)("LorryProcessedEST1")

                    .Cells(liRowCount + 5, 6) = dtShiftPerf.Rows(0)("LorryProcessedEST2")
                    .Range(sheet.Cells(liRowCount + 5, 6), sheet.Cells(liRowCount + 5, 8)).Merge()

                    .Cells(liRowCount + 5, 9) = dtShiftPerf.Rows(0)("LorryProcessedEST3")
                    .Range(sheet.Cells(liRowCount + 5, 9), sheet.Cells(liRowCount + 5, 10)).Merge()

                    'total hours
                    Dim dateStart As String = "1/1/2013 "
                    Dim TPH1 As Decimal = 0
                    Dim TPH2 As Decimal = 0
                    Dim TPH3 As Decimal = 0

                    If Not dtShiftPerf.Rows(0)("StartTime1").ToString().Length = 0 Then
                        'shift 1
                        Dim startTime As DateTime = Convert.ToDateTime(dateStart + dtShiftPerf.Rows(0)("StartTime1"))
                        Dim endTime As DateTime = Convert.ToDateTime(dateStart + dtShiftPerf.Rows(0)("EndTime1"))
                        If startTime > endTime Then
                            endTime = DateAdd(DateInterval.Day, 1, endTime)
                        End If


                        Dim minutes As Long = DateDiff(DateInterval.Minute, startTime, endTime)
                        Dim hour As Long = DateDiff(DateInterval.Hour, startTime, endTime)
                        minutes = minutes - (hour * 60)
                        Dim shift1TotalHours As String = Format(hour, "00") + ":" + Format(minutes, "00")
                        .Cells(liRowCount + 2, 5) = shift1TotalHours

                        'Eff Process Hours
                        Dim totalBreakdown As DateTime = Convert.ToDateTime(dateStart + dtShiftPerf.Rows(0)("TotalBreakdown1"))
                        Dim shiftTotalTime As DateTime
                        shiftTotalTime = DateTime.Parse(shift1TotalHours)
                        Dim effProcessHours As TimeSpan = shiftTotalTime.Subtract(totalBreakdown)
                        .Cells(liRowCount + 4, 5) = (effProcessHours.Hours & ":" & effProcessHours.Minutes)

                        If dtShiftPerf.Rows(0)("LorryProcessedEST1").ToString().Length > 0 Then
                            Dim timeToDecimal As Decimal = FormatNumber(effProcessHours.Hours + (effProcessHours.Minutes / 60), 2)

                            TPH1 = (Convert.ToDecimal(dtShiftPerf.Rows(0)("LorryProcessedEST1")) * averageCageLorryWeight) / timeToDecimal
                        End If

                        'TPH
                        .Cells(liRowCount + 6, 5) = TPH1
                    End If

                    If Not dtShiftPerf.Rows(0)("StartTime2").ToString().Length = 0 Then
                        'shift 2
                        Dim startTime As DateTime = Convert.ToDateTime(dateStart + dtShiftPerf.Rows(0)("StartTime2"))
                        Dim endTime As DateTime = Convert.ToDateTime(dateStart + dtShiftPerf.Rows(0)("EndTime2"))
                        If startTime > endTime Then
                            endTime = DateAdd(DateInterval.Day, 1, endTime)
                        End If

                        Dim minutes As Long = DateDiff(DateInterval.Minute, startTime, endTime)
                        Dim hour As Long = DateDiff(DateInterval.Hour, startTime, endTime)
                        minutes = minutes - (hour * 60)
                        Dim shift2TotalHours As String = Format(hour, "00") + ":" + Format(minutes, "00")
                        .Cells(liRowCount + 2, 6) = shift2TotalHours
                        .Range(sheet.Cells(liRowCount + 2, 6), sheet.Cells(liRowCount + 2, 8)).Merge()

                        'Eff Process Hours
                        Dim totalBreakdown As DateTime = Convert.ToDateTime(dateStart + dtShiftPerf.Rows(0)("TotalBreakdown2"))
                        Dim shiftTotalTime As DateTime
                        shiftTotalTime = DateTime.Parse(shift2TotalHours)
                        Dim effProcessHours As TimeSpan = shiftTotalTime.Subtract(totalBreakdown)
                        .Cells(liRowCount + 4, 6) = (effProcessHours.Hours & ":" & effProcessHours.Minutes)
                        .Range(sheet.Cells(liRowCount + 4, 6), sheet.Cells(liRowCount + 4, 8)).Merge()

                        If dtShiftPerf.Rows(0)("LorryProcessedEST2").ToString().Length > 0 Then
                            'Dim timeToDecimal As Decimal = FormatNumber(hour + (minutes / 60), 2)
                            Dim timeToDecimal As Decimal = FormatNumber(effProcessHours.Hours + (effProcessHours.Minutes / 60), 2)
                            TPH2 = (Convert.ToDecimal(dtShiftPerf.Rows(0)("LorryProcessedEST2")) * averageCageLorryWeight) / timeToDecimal
                        End If

                        .Cells(liRowCount + 6, 6) = TPH2
                        .Range(sheet.Cells(liRowCount + 6, 6), sheet.Cells(liRowCount + 6, 8)).Merge()
                    End If

                    If Not dtShiftPerf.Rows(0)("StartTime3").ToString().Length = 0 Then
                        'shift 3
                        Dim startTime As DateTime = Convert.ToDateTime(dateStart + dtShiftPerf.Rows(0)("StartTime3"))
                        Dim endTime As DateTime = Convert.ToDateTime(dateStart + dtShiftPerf.Rows(0)("EndTime3"))
                        If startTime > endTime Then
                            endTime = DateAdd(DateInterval.Day, 1, endTime)
                        End If

                        Dim minutes As Long = DateDiff(DateInterval.Minute, startTime, endTime)
                        Dim hour As Long = DateDiff(DateInterval.Hour, startTime, endTime)
                        minutes = minutes - (hour * 60)
                        Dim shift3TotalHours As String = Format(hour, "00") + ":" + Format(minutes, "00")
                        .Cells(liRowCount + 2, 9) = shift3TotalHours
                        .Range(sheet.Cells(liRowCount + 2, 9), sheet.Cells(liRowCount + 2, 10)).Merge()

                        'Eff Process Hours
                        Dim totalBreakdown As DateTime = Convert.ToDateTime(dateStart + dtShiftPerf.Rows(0)("TotalBreakdown3"))
                        Dim shiftTotalTime As DateTime
                        shiftTotalTime = DateTime.Parse(shift3TotalHours)
                        Dim effProcessHours As TimeSpan = shiftTotalTime.Subtract(totalBreakdown)
                        .Cells(liRowCount + 4, 9) = (effProcessHours.Hours & ":" & effProcessHours.Minutes)
                        .Range(sheet.Cells(liRowCount + 4, 9), sheet.Cells(liRowCount + 4, 10)).Merge()
                        If dtShiftPerf.Rows(0)("LorryProcessedEST3").ToString().Length > 0 Then
                            'Dim timeToDecimal As Decimal = FormatNumber(hour + (minutes / 60), 2)
                            Dim timeToDecimal As Decimal = FormatNumber(effProcessHours.Hours + (effProcessHours.Minutes / 60), 2)
                            TPH3 = (Convert.ToDecimal(dtShiftPerf.Rows(0)("LorryProcessedEST3")) * averageCageLorryWeight) / timeToDecimal
                        End If

                        .Cells(liRowCount + 6, 9) = TPH3
                        .Range(sheet.Cells(liRowCount + 6, 9), sheet.Cells(liRowCount + 6, 10)).Merge()

                    End If

                    .Range(sheet.Cells(liRowCount + 6, 5), sheet.Cells(liRowCount + 6, 10)).NumberFormat = "0.00"
                    .Range(sheet.Cells(shiftStartRow, 5), sheet.Cells(liRowCount + 6, 14)).HorizontalAlignment = Excel.Constants.xlCenter

                    .Range(sheet.Cells(shiftStartRow + 1, 3), sheet.Cells(liRowCount + 6, 3)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(shiftStartRow, 5), sheet.Cells(liRowCount + 6, 5)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(shiftStartRow, 6), sheet.Cells(liRowCount + 6, 6)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(shiftStartRow, 9), sheet.Cells(liRowCount + 6, 9)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    .Range(sheet.Cells(shiftStartRow, 11), sheet.Cells(liRowCount + 6, 11)).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    .Range(sheet.Cells(liRowCount + 6, 3), sheet.Cells(liRowCount + 6, 10)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                End If



            End With



            'If ds.Tables(6) IsNot Nothing Then
            '    For Each dr In ds.Tables(6).Rows
            '        With sheet
            '            .Cells(liRowCount, 3) = dr("PressNo").ToString
            '            .Cells(liRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            '            .Cells(liRowCount, 5) = dr("Capacity").ToString
            '            .Cells(liRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            '            .Cells(liRowCount, 7) = dr("OperatingHours").ToString
            '            .Cells(liRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            '            .Cells(liRowCount, 9) = dr("ScrewAge").ToString
            '            .Cells(liRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            '            .Cells(liRowCount, 11) = dr("ScrewStatus").ToString
            '            .Cells(liRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            '        End With
            '        liRowCount = liRowCount + 1
            '    Next
            'End If



            'Remarks
            liRowCount = liRowCount + 8
            sheet.Cells(liRowCount, 2) = "18"
            sheet.Cells(liRowCount, 3).font.bold = True

            sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            'sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
            sheet.Cells(liRowCount, 3) = "Remarks"

            If ds.Tables(0).Rows.Count > 0 Then

                liRowCount = liRowCount + 1
                sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 12)).Merge()
                sheet.Cells(liRowCount, 3).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                sheet.Cells(liRowCount, 3).VerticalAlignment = Excel.XlVAlign.xlVAlignTop
                sheet.Cells(liRowCount, 3) = ds.Tables(0).Rows(0)("Remarks").ToString.Trim()
                sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount + 6, 12)).Merge()
                sheet.Cells(liRowCount, 3).wraptext = True
            Else
                liRowCount = liRowCount + 1
                sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 12)).Merge()
                sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount + 6, 12)).Merge()
                sheet.Cells(liRowCount, 3).wraptext = True
            End If

            'CPO/KERNEL WRITEOFF

            If ds.Tables(15).Rows.Count > 0 Then
                liRowCount = liRowCount + 8
                sheet.Cells(liRowCount, 2) = "19"
                sheet.Cells(liRowCount, 3).font.bold = True

                sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 10)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                'sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 5)).Merge()
                sheet.Cells(liRowCount, 3) = "CPO/Kernel Writeoff"

                Dim dtWriteoff As DataTable = ds.Tables(15)


                liRowCount = liRowCount + 1
                sheet.Cells(liRowCount, 3) = "Storage Location"
                sheet.Cells(liRowCount, 5) = "Qty"

                sheet.Cells(liRowCount, 7) = "Reason"
                sheet.Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 10)).Merge()

                sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 10)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 7)).HorizontalAlignment = Excel.Constants.xlCenter
                liRowCount = liRowCount + 1
                With sheet
                    For Each dr In dtWriteoff.Rows
                        If Not (dr("TankNo") Is DBNull.Value) Then
                            .Cells(liRowCount, 3) = dr("TankNo")
                        Else
                            .Cells(liRowCount, 3) = dr("KernelStorage")
                        End If

                        '.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 4)).Merge()

                        .Cells(liRowCount, 5) = dr("Writeoff")
                        .Cells(liRowCount, 6) = "Kg"
                        '.Range(sheet.Cells(liRowCount, 5), sheet.Cells(liRowCount, 7)).Merge()

                        .Cells(liRowCount, 7) = dr("Reason")
                        .Range(sheet.Cells(liRowCount, 7), sheet.Cells(liRowCount, 10)).Merge()

                        '.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 8)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDot
                        sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 10)).HorizontalAlignment = Excel.Constants.xlLeft
                        sheet.Cells(liRowCount, 5).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                        liRowCount = liRowCount + 1
                    Next
                End With
            Else
                liRowCount = liRowCount + 1
                'sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount, 12)).Merge()
                'sheet.Range(sheet.Cells(liRowCount, 3), sheet.Cells(liRowCount + 6, 12)).Merge()
                'sheet.Cells(liRowCount, 3).wraptext = True
            End If

        End If


        Dim strProductionRptName, lTextMonth As String
        lTextMonth = Format(dtpDate.Value, "dd/MM/yyyy")
        lTextMonth = lTextMonth.Replace("/", "-")
        strProductionRptName = "DAILY PRODUCTION REPORT CPO " & lTextMonth & ""

        sheet.Protect("RANNBSP@2010")

        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strProductionRptName & ".xls"

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        ' xlApp.Workbooks.Open(StrPath)

        'xlApp.StatusBar = True
        xlApp.Visible = True

    End Sub

    Private Sub ProductionMillWorkingHours(ByVal dtValue As Date)

        Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim sheet As Excel.Worksheet
        ' Dim sheet1 As Excel.Worksheet
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty

        Dim strMonthlyProdRptName As String = String.Empty
        xlApp = New Excel.Application

        'xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Mill_Working_hours_Report.xlsx")

        Dim ReportDirectory As String = String.Empty
        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\Mill_Working_Hours_Report_Template.xls"

        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Mill_Working_Hours_Report_Template.xls")
        Else
            MsgBox("Mill working hours report template missing.Please contact system administrator.")
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
        cmd.CommandText = "Production.MillWorkingHoursReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        cmd.Parameters.AddWithValue("@ProductionLogDate", dtValue)

        'Dim tblAdt As New SqlDataAdapter
        'Dim ds As New DataSet
        'tblAdt.SelectCommand = cmd
        'tblAdt.Fill(ds, "MillWorkingHoursReport1")

        Dim tblAdt1 As New SqlDataAdapter
        Dim ds1 As New DataSet
        tblAdt1.SelectCommand = cmd
        tblAdt1.Fill(ds1, "MillWorkinHoursReport")


        Dim objCommonBOl As New GlobalBOL
        Dim lTextmonth As String = String.Empty

        'Dim Datestr, DateMn, DateYr As Integer
        'Dim Datestr1, DateMn1 As String
        'Dim ProdDate As New Date
        'ProdDate = dtpDate.Value
        'Datestr = ProdDate.Day
        'DateMn = ProdDate.Month
        'DateYr = ProdDate.Year
        'If Datestr < 10 Then
        '    Datestr1 = "0" + CStr(Datestr)
        'Else
        '    Datestr1 = CStr(Datestr)
        'End If
        'If DateMn < 10 Then
        '    DateMn1 = "0" + CStr(DateMn)
        'Else
        '    DateMn1 = CStr(DateMn)
        'End If
        'lTextmonth = "_" & Datestr1 & "" & DateMn1 & "" & DateYr & " "
        lTextmonth = Format(dtpDate.Value, "dd/MM/yyyy")
        lTextmonth = lTextmonth.Replace("/", "-")
        sheet.Cells(1, 13) = Format(Date.Today, "dd/MM/yyyy")
        sheet.Cells(3, 10) = ""
        sheet.Cells(3, 12) = ""

        Dim strArray As String()
        Dim lestate As String
        strArray = GlobalPPT.strEstateName.Split("-")
        lestate = strArray(1)
        sheet.Cells(2, 1) = "Estate/Mill : " & lestate & " "

        strMonthlyProdRptName = "MILL WORKING HOURS REPORT " & lTextmonth & ""
        sheet.Cells(1, 6) = "MILL WORKING HOURS REPORT"
        sheet.Cells(2, 6) = "DATE : " & Format(dtpDate.Value, "dd/MM/yyyy") & ""
        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"


        If ds1.Tables(0) IsNot Nothing And ds1.Tables(0).Rows.Count <> 0 Then


            Dim TotalCount As Integer = 0

            TotalCount = ds1.Tables(0).Rows.Count
            Dim lRowCount As Integer
            lRowCount = 9
            Dim LrowNo As Integer = 0

            While (TotalCount > 0)

                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 1) = ds1.Tables(0).Rows(LrowNo).Item("ProductionLogDate").ToString
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                Dim lStartTime, lStoptime As DateTime

                If Not ds1.Tables(0).Rows(LrowNo).Item("StartTime1") Is DBNull.Value Then

                    lStartTime = ds1.Tables(0).Rows(LrowNo).Item("StartTime1")
                    lStoptime = ds1.Tables(0).Rows(LrowNo).Item("EndTime1")


                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                        strTotalhrs = CInt(strTotalhrs) - 1
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 2) = strTotalhrs + ":" + strTotalMins
                            '   DtotalShifthrs1 = strTotalhrs + ":" + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 2) = strTotalhrs + ":" + strTotalMins
                            ' DtotalShifthrs1 = strTotalhrs + ":" + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 2) = strTotalhrs + ":00"
                        ' DtotalShifthrs1 = strTotalhrs + ":00"
                    End If
                End If


                If Not ds1.Tables(0).Rows(LrowNo).Item("StartTime2") Is DBNull.Value Then
                    lStartTime = ds1.Tables(0).Rows(LrowNo).Item("StartTime2")
                    lStoptime = ds1.Tables(0).Rows(LrowNo).Item("EndTime2")

                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                        strTotalhrs = CInt(strTotalhrs) - 1
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 3) = strTotalhrs + ":" + strTotalMins
                            ' DtotalShifthrs2 = strTotalhrs + ":" + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 3) = strTotalhrs + ":" + strTotalMins
                            '  DtotalShifthrs2 = strTotalhrs + ":" + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 3) = strTotalhrs + ":00"
                        ' DtotalShifthrs2 = strTotalhrs + ":00"
                    End If
                End If
                If Not ds1.Tables(0).Rows(LrowNo).Item("StartTime3") Is DBNull.Value Then
                    lStartTime = ds1.Tables(0).Rows(LrowNo).Item("StartTime3")
                    lStoptime = ds1.Tables(0).Rows(LrowNo).Item("EndTime3")

                    Dim strTotalhrs As String = String.Empty
                    If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
                        strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
                    ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
                        strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
                    Else
                        strTotalhrs = "0"
                    End If

                    If strTotalhrs < 10 Then
                        strTotalhrs = "0" + strTotalhrs
                    End If

                    ''''For Mins''''''
                    Dim strTotalMins As String = String.Empty
                    If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
                        strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
                    ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
                        strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
                        strTotalhrs = CInt(strTotalhrs) - 1
                    End If
                    If strTotalMins = "5" Then
                        strTotalMins = "05"
                    End If
                    If strTotalMins <> String.Empty Then
                        If strTotalhrs <> Nothing Then
                            sheet.Cells(lRowCount, 4) = strTotalhrs + ":" + strTotalMins
                            '  DtotalShifthrs3 = strTotalhrs + ":" + strTotalMins
                        Else
                            strTotalhrs = 0
                            sheet.Cells(lRowCount, 4) = strTotalhrs + ":" + strTotalMins
                            '  DtotalShifthrs3 = strTotalhrs + ":" + strTotalMins
                        End If
                    Else
                        sheet.Cells(lRowCount, 4) = strTotalhrs + ":00"
                        ' DtotalShifthrs3 = strTotalhrs + ":00"
                    End If
                End If

                Dim lTotalHours As String = String.Empty
                lTotalHours = ds1.Tables(0).Rows(LrowNo).Item("TotalHours")
                'If lTotalHours < 10 Then
                '    lTotalHours = "0" + lTotalHours
                'End If
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 5) = lTotalHours
                '  DtotalOperationhrs = lTotalHours
                Dim lProductionHours As String = String.Empty
                lProductionHours = ds1.Tables(0).Rows(LrowNo).Item("ProductionHours").ToString
                'If lProductionHours < 10 Then
                '    lProductionHours = "0" + lProductionHours
                'End If
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 6) = lProductionHours
                '  DtotalProdHrs = lProductionHours
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                'sheet.Cells(lRowCount, 7) = ds1.Tables(0).Rows(LrowNo).Item("TotalHours") - ds1.Tables(0).Rows(LrowNo).Item("ProductionHours")

                Dim lBKDownHours As String = ""
                If ds1.Tables(0).Rows(LrowNo).Item("BreakDownHours").ToString <> "" Then
                    lBKDownHours = ds1.Tables(0).Rows(LrowNo).Item("BreakDownHours").ToString
                    'If lBKDownHours < 10 Then
                    '    lBKDownHours = "0" + lBKDownHours
                    'End If
                    sheet.Cells(lRowCount, 8) = lBKDownHours
                    '  DtotalBreakDownHrs = lBKDownHours
                End If

                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(lRowCount, 13) = ds1.Tables(0).Rows(LrowNo).Item("Remarks").ToString.Trim()

                TotalCount = TotalCount - 1
                lRowCount = lRowCount + 1
                LrowNo = LrowNo + 1


            End While




        End If

        '    Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"
        sheet.Protect("RANNBSP@2010")

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        '  xlApp.Workbooks.Open(StrPath)
        xlApp.Visible = True

        Cursor = Cursors.Arrow


    End Sub

    Private Sub DailyProductionRptFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub ProductionMillWorkingHours(ByVal dtValue As Date)

    '    Cursor = Cursors.WaitCursor
    '    Dim xlApp As Excel.Application
    '    Dim xlWorkBook As Excel.Workbook
    '    Dim sheet As Excel.Worksheet
    '    ' Dim sheet1 As Excel.Worksheet
    '    Dim strServerUserName As String = String.Empty
    '    Dim strServerPassword As String = String.Empty
    '    Dim strDSN As String = String.Empty
    '    Dim StrInitialCatlog As String = String.Empty

    '    Dim strMonthlyProdRptName As String = String.Empty
    '    'Dim DtotalShifthrs1, DtotalShifthrs2, DtotalShifthrs3, DtotalOperationhrs, DtotalProdHrs, DtotalBreakDownHrs As String
    '    'Dim ltotalShifthrs1, ltotalShifthrs2, ltotalShifthrs3, ltotalOperationhrs, ltotalProdHrs, ltotalBreakDownHrs As String


    '    xlApp = New Excel.Application

    '    'xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Mill_Working_hours_Report.xlsx")

    '    Dim ReportDirectory As String = String.Empty
    '    Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\Mill_Working_Hours_Report_Template.xlsx"

    '    If (File.Exists(TemPath)) Then
    '        xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Mill_Working_Hours_Report_Template.xlsx")
    '    Else
    '        MsgBox("Mill working hours report template missing.Please contact system administrator.")
    '        Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

    '    Dim sDirName As String
    '    sDirName = ReportDirectory + ":"
    '    Dim dDir As New DirectoryInfo(sDirName)

    '    If Not dDir.Exists Then
    '        MessageBox.Show("Report directory not found", "BSP")
    '        Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Production Reports")
    '    ' Determine whether the directory exists.
    '    If Not di.Exists Then
    '        di.Create()
    '    End If


    '    sheet = xlWorkBook.Sheets("Sheet1")
    '    sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)


    '    strDSN = "" & ConfigurationManager.AppSettings.Item("oDataSource").ToString & ""
    '    strServerUserName = "" & ConfigurationManager.AppSettings.Item("oUserName").ToString & ""
    '    strServerPassword = "" & ConfigurationManager.AppSettings.Item("oPassword").ToString & ""
    '    StrInitialCatlog = "" & ConfigurationManager.AppSettings.Item("oDataBase").ToString & ""


    '    Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
    '    Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    Dim da As New SqlDataAdapter
    '    con = New SqlConnection(constr)

    '    con.Open()


    '    cmd.Connection = con
    '    cmd.CommandText = "Production.MillWorkingHoursReport"

    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
    '    cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    '    cmd.Parameters.AddWithValue("@ProductionLogDate", dtValue)

    '    'Dim tblAdt As New SqlDataAdapter
    '    'Dim ds As New DataSet
    '    'tblAdt.SelectCommand = cmd
    '    'tblAdt.Fill(ds, "MillWorkingHoursReport1")

    '    Dim tblAdt1 As New SqlDataAdapter
    '    Dim ds1 As New DataSet
    '    tblAdt1.SelectCommand = cmd
    '    tblAdt1.Fill(ds1, "MillWorkinHoursReport")


    '    Dim objCommonBOl As New GlobalBOL
    '    Dim lTextmonth As String = String.Empty

    '    Dim Datestr, DateMn, DateYr As Integer
    '    Dim Datestr1, DateMn1 As String
    '    Datestr = Date.Today.Day
    '    DateMn = Date.Today.Month
    '    DateYr = Date.Today.Year
    '    If Datestr < 10 Then
    '        Datestr1 = "0" + CStr(Datestr)
    '    Else
    '        Datestr1 = CStr(Datestr)
    '    End If
    '    If DateMn < 10 Then
    '        DateMn1 = "0" + CStr(DateMn)
    '    Else
    '        DateMn1 = CStr(DateMn)
    '    End If
    '    lTextmonth = "_" & Datestr1 & "" & DateMn1 & "" & DateYr & " "
    '    sheet.Cells(1, 13) = Format(Date.Today, "dd/MM/yyyy")
    '    sheet.Cells(3, 10) = ""
    '    sheet.Cells(3, 12) = ""

    '    Dim strArray As String()
    '    Dim lestate As String
    '    strArray = GlobalPPT.strEstateName.Split("-")
    '    lestate = strArray(1)
    '    sheet.Cells(2, 1) = "Estate/Mill :" & lestate & " "

    '    strMonthlyProdRptName = "Mill Working Hours Report" & "_" & lTextmonth & ""
    '    sheet.Cells(5, 1) = "Mill Working Hours Report" & " " & lTextmonth & ""

    '    If ds1.Tables(0).Rows.Count = 0 Then
    '        'Dim StrPath As String = Application.StartupPath & "\Reports\Production\Excel\" & strMonthlyProdRptName & ".xls"
    '        sheet.Protect("RANNBSP@2010")
    '        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"

    '        If (File.Exists(StrPath)) Then
    '            File.Delete(StrPath)
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        Else
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        End If

    '        xlApp.Visible = True
    '        Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    If ds1.Tables(0) IsNot Nothing Then


    '        Dim TotalCount As Integer = 0

    '        TotalCount = ds1.Tables(0).Rows.Count
    '        Dim lRowCount As Integer
    '        lRowCount = 13
    '        Dim LrowNo As Integer = 0

    '        While (TotalCount > 0)

    '            sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 1) = ds1.Tables(0).Rows(LrowNo).Item("ProductionLogDate").ToString
    '            sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

    '            Dim lStartTime, lStoptime As DateTime

    '            If Not ds1.Tables(0).Rows(LrowNo).Item("StartTime1") Is DBNull.Value Then

    '                lStartTime = ds1.Tables(0).Rows(LrowNo).Item("StartTime1")
    '                lStoptime = ds1.Tables(0).Rows(LrowNo).Item("EndTime1")


    '                Dim strTotalhrs As String = String.Empty
    '                If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
    '                    strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
    '                ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
    '                    strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
    '                Else
    '                    strTotalhrs = "0"
    '                End If

    '                If strTotalhrs < 10 Then
    '                    strTotalhrs = "0" + strTotalhrs
    '                End If

    '                ''''For Mins''''''
    '                Dim strTotalMins As String = String.Empty
    '                If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
    '                    strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
    '                ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
    '                    strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
    '                    strTotalhrs = CInt(strTotalhrs) - 1
    '                End If
    '                If strTotalMins = "5" Then
    '                    strTotalMins = "05"
    '                End If
    '                If strTotalMins <> String.Empty Then
    '                    If strTotalhrs <> Nothing Then
    '                        sheet.Cells(lRowCount, 2) = strTotalhrs + ":" + strTotalMins
    '                        '   DtotalShifthrs1 = strTotalhrs + ":" + strTotalMins
    '                    Else
    '                        strTotalhrs = 0
    '                        sheet.Cells(lRowCount, 2) = strTotalhrs + ":" + strTotalMins
    '                        ' DtotalShifthrs1 = strTotalhrs + ":" + strTotalMins
    '                    End If
    '                Else
    '                    sheet.Cells(lRowCount, 2) = strTotalhrs + ":00"
    '                    ' DtotalShifthrs1 = strTotalhrs + ":00"
    '                End If
    '            End If


    '            If Not ds1.Tables(0).Rows(LrowNo).Item("StartTime2") Is DBNull.Value Then
    '                lStartTime = ds1.Tables(0).Rows(LrowNo).Item("StartTime2")
    '                lStoptime = ds1.Tables(0).Rows(LrowNo).Item("EndTime2")

    '                Dim strTotalhrs As String = String.Empty
    '                If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
    '                    strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
    '                ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
    '                    strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
    '                Else
    '                    strTotalhrs = "0"
    '                End If

    '                If strTotalhrs < 10 Then
    '                    strTotalhrs = "0" + strTotalhrs
    '                End If

    '                ''''For Mins''''''
    '                Dim strTotalMins As String = String.Empty
    '                If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
    '                    strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
    '                ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
    '                    strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
    '                    strTotalhrs = CInt(strTotalhrs) - 1
    '                End If
    '                If strTotalMins = "5" Then
    '                    strTotalMins = "05"
    '                End If
    '                If strTotalMins <> String.Empty Then
    '                    If strTotalhrs <> Nothing Then
    '                        sheet.Cells(lRowCount, 3) = strTotalhrs + ":" + strTotalMins
    '                        ' DtotalShifthrs2 = strTotalhrs + ":" + strTotalMins
    '                    Else
    '                        strTotalhrs = 0
    '                        sheet.Cells(lRowCount, 3) = strTotalhrs + ":" + strTotalMins
    '                        '  DtotalShifthrs2 = strTotalhrs + ":" + strTotalMins
    '                    End If
    '                Else
    '                    sheet.Cells(lRowCount, 3) = strTotalhrs + ":00"
    '                    ' DtotalShifthrs2 = strTotalhrs + ":00"
    '                End If
    '            End If
    '            If Not ds1.Tables(0).Rows(LrowNo).Item("StartTime3") Is DBNull.Value Then
    '                lStartTime = ds1.Tables(0).Rows(LrowNo).Item("StartTime3")
    '                lStoptime = ds1.Tables(0).Rows(LrowNo).Item("EndTime3")

    '                Dim strTotalhrs As String = String.Empty
    '                If Val(lStoptime.Hour) > Val(lStartTime.Hour) Then
    '                    strTotalhrs = Val(lStoptime.Hour) - Val(lStartTime.Hour)
    '                ElseIf Val(lStartTime.Hour) > Val(lStoptime.Hour) Then
    '                    strTotalhrs = 24 - Val(lStartTime.Hour) + Val(lStoptime.Hour)
    '                Else
    '                    strTotalhrs = "0"
    '                End If

    '                If strTotalhrs < 10 Then
    '                    strTotalhrs = "0" + strTotalhrs
    '                End If

    '                ''''For Mins''''''
    '                Dim strTotalMins As String = String.Empty
    '                If Val(lStoptime.Minute) > Val(lStartTime.Minute) Then
    '                    strTotalMins = Val(lStoptime.Minute) - Val(lStartTime.Minute)
    '                ElseIf Val(lStartTime.Minute) > Val(lStoptime.Minute) Then
    '                    strTotalMins = 60 - Val(lStartTime.Minute) + Val(lStoptime.Minute)
    '                    strTotalhrs = CInt(strTotalhrs) - 1
    '                End If
    '                If strTotalMins = "5" Then
    '                    strTotalMins = "05"
    '                End If
    '                If strTotalMins <> String.Empty Then
    '                    If strTotalhrs <> Nothing Then
    '                        sheet.Cells(lRowCount, 4) = strTotalhrs + ":" + strTotalMins
    '                        '  DtotalShifthrs3 = strTotalhrs + ":" + strTotalMins
    '                    Else
    '                        strTotalhrs = 0
    '                        sheet.Cells(lRowCount, 4) = strTotalhrs + ":" + strTotalMins
    '                        '  DtotalShifthrs3 = strTotalhrs + ":" + strTotalMins
    '                    End If
    '                Else
    '                    sheet.Cells(lRowCount, 4) = strTotalhrs + ":00"
    '                    ' DtotalShifthrs3 = strTotalhrs + ":00"
    '                End If
    '            End If

    '            Dim lTotalHours As String = String.Empty
    '            lTotalHours = ds1.Tables(0).Rows(LrowNo).Item("TotalHours")
    '            'If lTotalHours < 10 Then
    '            '    lTotalHours = "0" + lTotalHours
    '            'End If
    '            sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 5) = lTotalHours
    '            '  DtotalOperationhrs = lTotalHours
    '            Dim lProductionHours As String = String.Empty
    '            lProductionHours = ds1.Tables(0).Rows(LrowNo).Item("ProductionHours").ToString
    '            'If lProductionHours < 10 Then
    '            '    lProductionHours = "0" + lProductionHours
    '            'End If
    '            sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 6) = lProductionHours
    '            '  DtotalProdHrs = lProductionHours
    '            sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

    '            'sheet.Cells(lRowCount, 7) = ds1.Tables(0).Rows(LrowNo).Item("TotalHours") - ds1.Tables(0).Rows(LrowNo).Item("ProductionHours")

    '            Dim lBKDownHours As String = ""
    '            If ds1.Tables(0).Rows(LrowNo).Item("BreakDownHours").ToString <> "" Then
    '                lBKDownHours = ds1.Tables(0).Rows(LrowNo).Item("BreakDownHours").ToString
    '                'If lBKDownHours < 10 Then
    '                '    lBKDownHours = "0" + lBKDownHours
    '                'End If
    '                sheet.Cells(lRowCount, 8) = lBKDownHours
    '                '  DtotalBreakDownHrs = lBKDownHours
    '            End If

    '            sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

    '            sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '            sheet.Cells(lRowCount, 13) = ds1.Tables(0).Rows(LrowNo).Item("Remarks")

    '            TotalCount = TotalCount - 1
    '            lRowCount = lRowCount + 1
    '            LrowNo = LrowNo + 1

    '            'ltotalShifthrs1 = ltotalShifthrs1 + DtotalShifthrs1
    '            'ltotalShifthrs2 = ltotalShifthrs2 + DtotalShifthrs2
    '            'ltotalShifthrs3 = ltotalShifthrs3 + DtotalShifthrs3
    '            'ltotalOperationhrs = ltotalOperationhrs + DtotalOperationhrs
    '            'ltotalProdHrs = ltotalProdHrs + DtotalProdHrs
    '            'ltotalBreakDownHrs = ltotalBreakDownHrs + DtotalBreakDownHrs

    '            'DtotalShifthrs1 = 0
    '            'DtotalShifthrs2 = 0
    '            'DtotalShifthrs3 = 0
    '            'DtotalOperationhrs = 0
    '            'DtotalProdHrs = 0
    '            'DtotalBreakDownHrs = 0

    '        End While

    '        ''Dim Myrange As Excel.Range
    '        ''Myrange = sheet.Range(lRowCount, 1)
    '        ''Myrange.Font.Bold = True
    '        'sheet.Cells(lRowCount, 1).font.bold = True
    '        'sheet.Cells(lRowCount, 2).font.bold = True
    '        'sheet.Cells(lRowCount, 3).font.bold = True
    '        'sheet.Cells(lRowCount, 4).font.bold = True
    '        'sheet.Cells(lRowCount, 5).font.bold = True
    '        'sheet.Cells(lRowCount, 6).font.bold = True
    '        'sheet.Cells(lRowCount, 7).font.bold = True
    '        'sheet.Cells(lRowCount, 8).font.bold = True
    '        'sheet.Cells(lRowCount, 9).font.bold = True
    '        'sheet.Cells(lRowCount, 10).font.bold = True
    '        'sheet.Cells(lRowCount, 11).font.bold = True
    '        'sheet.Cells(lRowCount, 12).font.bold = True
    '        'sheet.Cells(lRowCount, 13).font.bold = True
    '        'sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '        ''Dim strtotal As String = "Total"
    '        ''sheet.Cells(lRowCount, 1) = Font.Bold

    '        'sheet.Cells(lRowCount, 1) = "Total"

    '        'Dim intMins As Integer = 0
    '        'Dim intHrs As Integer = 0
    '        'Dim StrMin As String = "00"
    '        'Dim strHrs As String = "00"
    '        'Dim ltotalShift1hrs, ltotalShift2hrs, ltotalShift3hrs As Integer

    '        'ltotalShift1hrs = ds1.Tables(3).Rows(0).Item("TotalShift1Min").ToString
    '        'ltotalShift2hrs = ds1.Tables(3).Rows(0).Item("TotalShift2Min").ToString
    '        'ltotalShift3hrs = ds1.Tables(3).Rows(0).Item("TotalShift3Min").ToString

    '        'If ltotalShift1hrs > 0 Then
    '        '    intHrs = ltotalShift1hrs / 60
    '        '    intMins = ltotalShift1hrs Mod 60
    '        '    If intHrs < 10 Then
    '        '        strHrs = "0" + CStr(intHrs)
    '        '    Else
    '        '        strHrs = CStr(intHrs)
    '        '    End If

    '        '    If intMins < 10 Then
    '        '        StrMin = "0" + CStr(intMins)
    '        '    Else
    '        '        StrMin = CStr(intMins)
    '        '    End If

    '        '    sheet.Cells(lRowCount, 2) = strHrs + ":" + StrMin
    '        'Else
    '        '    sheet.Cells(lRowCount, 2) = ""
    '        'End If

    '        'If ltotalShift2hrs > 0 Then
    '        '    intHrs = ltotalShift2hrs / 60
    '        '    intMins = ltotalShift2hrs Mod 60
    '        '    If intHrs < 10 Then
    '        '        strHrs = "0" + CStr(intHrs)
    '        '    Else
    '        '        strHrs = CStr(intHrs)
    '        '    End If

    '        '    If intMins < 10 Then
    '        '        StrMin = "0" + CStr(intMins)
    '        '    Else
    '        '        StrMin = CStr(intMins)
    '        '    End If

    '        '    sheet.Cells(lRowCount, 3) = strHrs + ":" + StrMin
    '        'Else
    '        '    sheet.Cells(lRowCount, 3) = ""
    '        'End If
    '        'If ltotalShift3hrs > 0 Then
    '        '    intHrs = ltotalShift3hrs / 60
    '        '    intMins = ltotalShift3hrs Mod 60
    '        '    If intHrs < 10 Then
    '        '        strHrs = "0" + CStr(intHrs)
    '        '    Else
    '        '        strHrs = CStr(intHrs)
    '        '    End If

    '        '    If intMins < 10 Then
    '        '        StrMin = "0" + CStr(intMins)
    '        '    Else
    '        '        StrMin = CStr(intMins)
    '        '    End If

    '        '    sheet.Cells(lRowCount, 4) = strHrs + ":" + StrMin
    '        'Else
    '        '    sheet.Cells(lRowCount, 4) = ""
    '        'End If


    '        'sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

    '        'sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

    '        'sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'Dim ltotalHrs As String = "00:00"
    '        'ltotalHrs = ds1.Tables(13).Rows(0).Item("TotalHours").ToString

    '        'If ltotalHrs <> "" Then

    '        '    Dim Hrs As String = "00"
    '        '    Dim Min As String = "00"
    '        '    Dim str As String
    '        '    Dim strArr() As String
    '        '    'Dim count As Integer
    '        '    str = ltotalHrs
    '        '    strArr = str.Split(":")


    '        '    If strArr(0).Length = 1 Then
    '        '        Hrs = "0" + strArr(0)
    '        '    ElseIf strArr(0) <> "" Then
    '        '        Hrs = strArr(0)
    '        '    End If

    '        '    Min = strArr(1)
    '        '    ltotalHrs = Hrs + ":" + Min
    '        'End If


    '        'sheet.Cells(lRowCount, 5) = ltotalHrs

    '        'sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

    '        'Dim ltotalProductionHrs As String = "00:00"
    '        'ltotalProductionHrs = ds1.Tables(10).Rows(0).Item("TotalProductionHours").ToString
    '        'If ltotalProductionHrs <> "" Then

    '        '    Dim Hrs As String = "00"
    '        '    Dim Min As String = "00"
    '        '    Dim str As String
    '        '    Dim strArr() As String
    '        '    'Dim count As Integer
    '        '    str = ltotalProductionHrs
    '        '    strArr = str.Split(":")


    '        '    If strArr(0).Length = 1 Then
    '        '        Hrs = "0" + strArr(0)
    '        '    ElseIf strArr(0) <> "" Then
    '        '        Hrs = strArr(0)
    '        '    End If

    '        '    Min = strArr(1)
    '        '    ltotalProductionHrs = Hrs + ":" + Min
    '        'End If
    '        'sheet.Cells(lRowCount, 6) = ltotalProductionHrs

    '        'sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'Dim ltotalBDHrs As String = "00:00"
    '        'ltotalBDHrs = ds1.Tables(7).Rows(0).Item("TotalBreakDownHours").ToString
    '        'If ltotalBDHrs <> "" Then

    '        '    Dim Hrs As String = "00"
    '        '    Dim Min As String = "00"
    '        '    Dim str As String
    '        '    Dim strArr() As String
    '        '    'Dim count As Integer
    '        '    str = ltotalBDHrs
    '        '    strArr = str.Split(":")
    '        '    If strArr(0).Length = 1 Then
    '        '        Hrs = "0" + strArr(0)
    '        '    ElseIf strArr(0) <> "" Then
    '        '        Hrs = strArr(0)
    '        '    End If

    '        '    Min = strArr(1)
    '        '    ltotalBDHrs = Hrs + ":" + Min
    '        'End If

    '        'sheet.Cells(lRowCount, 8) = ltotalBDHrs



    '        'sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '        '' sheet.Cells(lRowCount, 11) = ds1.Tables(0).Rows(LrowNo).Item("Remarks")
    '        'sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
    '        '' sheet.Cells(lRowCount, 12) = ds1.Tables(0).Rows(LrowNo).Item("Remarks")
    '        'sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
    '        'sheet.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

    '        'Dim StrPath As String = Application.StartupPath & "\Reports\Production\Excel\" & strMonthlyProdRptName & ".xls"

    '        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"
    '        sheet.Protect("RANNBSP@2010")

    '        If (File.Exists(StrPath)) Then
    '            File.Delete(StrPath)
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        Else
    '            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
    '        End If

    '        '  xlApp.Workbooks.Open(StrPath)
    '        xlApp.Visible = True

    '    End If

    '    Cursor = Cursors.Arrow


    'End Sub

    Private Sub DailyProductionRptFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpDate.MaxDate = GlobalPPT.FiscalYearToDate
        Dim TempDate As Date = dtpDate.Value
        Dim NowDate As Date = Now()
        If Now() >= GlobalPPT.FiscalYearFromDate And dtpDate.Value <= GlobalPPT.FiscalYearFromDate Then
            dtpDate.Value = TempDate.Month.ToString() + "/" + (NowDate.Day.ToString() + "/" + TempDate.Year.ToString())
        End If

        'dtpDate.MaxDate = dtpDate.Value
        Dim ToDate As Date = dtpDate.Value

        dtpDate.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        If GlobalPPT.strLang <> "en" Then
            '  btnSearch.Text = "Mencari"
            btnClose.Text = "Tutup"
            btnViewReport.Text = "Lihat Laporan"
        End If
    End Sub

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


    Private Function TosubHours(ByVal Hours1 As String, ByVal Hours2 As String)

        Dim Calsubchrs As String 
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

        Calsubchrs = Strhrs2 + ":" + StrMin2

        Return Calsubchrs

    End Function



   
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class