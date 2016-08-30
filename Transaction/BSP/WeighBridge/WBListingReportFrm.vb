Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Math
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections
Imports System.Windows.Forms.RowStyle

    Public Class WBListingReportFrm
        Dim RptDate As String

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlRange As Excel.Range



        Private Sub WBListingReportFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            dtpDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
            dtpDate.MaxDate = Date.Today

            dtpDate.Format = DateTimePickerFormat.Custom
            dtpDate.CustomFormat = "dd/MM/yyyy"

        End Sub

        Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        Cursor = Cursors.WaitCursor
        ViewReport()
        Cursor = Cursors.Arrow

    End Sub
    Private Sub ViewReport()
        Dim WBlistingRptName = String.Empty
        Dim objGlobalBOL As New GlobalBOL
        RptDate = objGlobalBOL.PMonthName(dtpDate.Value.Month, dtpDate.Value.Year, GlobalPPT.strLang)

        WBlistingRptName = "Daily Weighing In/Out Listing Report - " & RptDate & ""

        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        xlApp = New Excel.Application



        Dim TemPath As String = Application.StartupPath & "\Reports\WeighBridge\Excel\WBListingReport.xlsx"
        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\WeighBridge\Excel\WBListingReport.xlsx")
        Else
            MsgBox("Weignbridge In\Out Listing report template missing.Please contact system administrator.")
            Exit Sub
        End If

        Dim ReportDirectory As String = String.Empty

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            MessageBox.Show("Report directory not found", "BSP")
            Exit Sub
        End If

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Weighbride Reports")

        If Not di.Exists Then
            di.Create()
        End If

        Dim con1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        Dim da1 As New SqlDataAdapter
        Dim ds1 As New DataSet


        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName


        Dim constr1 As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & StrInitialCatlog & ";User=" & strServerUserName & "; pwd=" & strServerPassword & ";Max Pool Size=100;Connection Timeout=60;"

        con1 = New SqlConnection(constr1)
        con1.Open()

        cmd1.Connection = con1
        cmd1.CommandText = "Weighbridge.WBListingReport"
        cmd1.CommandType = CommandType.StoredProcedure
        cmd1.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd1.Parameters.AddWithValue("@Date", dtpDate.Value)

        Dim sheetNo As Excel.Worksheet
        sheetNo = xlWorkBook.Sheets("Sheet1")
        sheetNo = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
        'Header Data
        sheetNo.Cells(3, 3).font.bold = True
        sheetNo.Cells(3, 3) = GlobalPPT.strEstateName.Substring(GlobalPPT.strEstateName.IndexOf("-") + 1)
        sheetNo.Cells(3, 6) = dtpDate.Value
        sheetNo.Cells(2, 14) = GlobalPPT.strUserName
        sheetNo.Cells(3, 14) = Date.Today


        'DB Data
        'xlApp.Visible = True
        da1.SelectCommand = cmd1
        da1.Fill(ds1, "Data")

        If ds1.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("Did not match any record", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim rowcountTB As Integer = 0
        Dim rowcountQty As Integer = 0
        Dim rowcount = ds1.Tables(0).Rows.Count
        Dim Qtyrowcount = ds1.Tables(1).Rows.Count - 1
        Dim lrow As Integer = 6
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim TotalQty As Decimal = 0.0
        Dim WBTicketNo As String = ds1.Tables(1).Rows(rowcountQty).Item("WBTicketNo")
        Dim WBNextTicketNo As String = ds1.Tables(1).Rows(rowcountQty + 1).Item("WBTicketNo")
        
        While i < rowcount


            sheetNo.Cells((lrow + rowcountQty), 2) = ds1.Tables(0).Rows(rowcountTB).Item("WBTicketNo")
            sheetNo.Cells((lrow + rowcountQty), 3) = ds1.Tables(0).Rows(rowcountTB).Item("WeighingDate")
            sheetNo.Cells((lrow + rowcountQty), 4) = ds1.Tables(0).Rows(rowcountTB).Item("Name")
            sheetNo.Cells((lrow + rowcountQty), 5) = ds1.Tables(0).Rows(rowcountTB).Item("ProductDescp")
            sheetNo.Cells((lrow + rowcountQty), 6) = ds1.Tables(0).Rows(rowcountTB).Item("WBVehicleID")
            sheetNo.Cells((lrow + rowcountQty), 7) = ds1.Tables(0).Rows(rowcountTB).Item("DriverName")
            sheetNo.Cells((lrow + rowcountQty), 8) = ds1.Tables(0).Rows(rowcountTB).Item("FirstWeight")
            sheetNo.Cells((lrow + rowcountQty), 9) = ds1.Tables(0).Rows(rowcountTB).Item("SecondWeight")
            sheetNo.Cells((lrow + rowcountQty), 10) = ds1.Tables(0).Rows(rowcountTB).Item("NetWeight")
            TotalQty = ds1.Tables(0).Rows(rowcountTB).Item("TotalQty")
            If rowcountQty < Qtyrowcount Then
                If WBTicketNo <> WBNextTicketNo Then
                    sheetNo.Cells((lrow + rowcountQty), 11) = ds1.Tables(1).Rows(rowcountQty).Item("YOP")
                    sheetNo.Cells((lrow + rowcountQty), 12) = ds1.Tables(1).Rows(rowcountQty).Item("Div")
                    sheetNo.Cells((lrow + rowcountQty), 13) = ds1.Tables(1).Rows(rowcountQty).Item("Block")
                    sheetNo.Cells((lrow + rowcountQty), 14) = ds1.Tables(1).Rows(rowcountQty).Item("Qty")
                    rowcountQty += 1
                End If
                While WBTicketNo = WBNextTicketNo
                    sheetNo.Cells((lrow + rowcountQty), 11) = ds1.Tables(1).Rows(rowcountQty).Item("YOP")
                    sheetNo.Cells((lrow + rowcountQty), 12) = ds1.Tables(1).Rows(rowcountQty).Item("Div")
                    sheetNo.Cells((lrow + rowcountQty), 13) = ds1.Tables(1).Rows(rowcountQty).Item("Block")
                    sheetNo.Cells((lrow + rowcountQty), 14) = ds1.Tables(1).Rows(rowcountQty).Item("Qty")
                    If rowcountQty + 1 < Qtyrowcount Then
                        WBNextTicketNo = ds1.Tables(1).Rows(rowcountQty + 1).Item("WBTicketNo")
                        rowcountQty += 1
                    Else
                        rowcountQty += 1
                        sheetNo.Cells((lrow + rowcountQty), 11) = ds1.Tables(1).Rows(rowcountQty).Item("YOP")
                        sheetNo.Cells((lrow + rowcountQty), 12) = ds1.Tables(1).Rows(rowcountQty).Item("Div")
                        sheetNo.Cells((lrow + rowcountQty), 13) = ds1.Tables(1).Rows(rowcountQty).Item("Block")
                        sheetNo.Cells((lrow + rowcountQty), 14) = ds1.Tables(1).Rows(rowcountQty).Item("Qty")
                        WBTicketNo = ""
                        lrow += 1

                    End If
                End While
                sheetNo.Range(sheetNo.Cells((lrow + rowcountQty), 13), sheetNo.Cells((lrow + rowcountQty), 14)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Range(sheetNo.Cells((lrow + rowcountQty), 13), sheetNo.Cells((lrow + rowcountQty), 14)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Cells((lrow + rowcountQty), 13).font.bold = True
                sheetNo.Cells((lrow + rowcountQty), 14).font.bold = True
                sheetNo.Cells((lrow + rowcountQty), 13) = "Total Qty"
                sheetNo.Cells((lrow + rowcountQty), 14) = TotalQty
                'sheetNo.Cells((lrow + rowcountQty), 11) = ds1.Tables(1).Rows(rowcountQty).Item("YOP")
                'sheetNo.Cells((lrow + rowcountQty), 12) = ds1.Tables(1).Rows(rowcountQty).Item("Div")
                'sheetNo.Cells((lrow + rowcountQty), 13) = ds1.Tables(1).Rows(rowcountQty).Item("Block")
                'sheetNo.Cells((lrow + rowcountQty), 14) = ds1.Tables(1).Rows(rowcountQty).Item("Qty")
                'rowcountQty += 1
            Else
                'lrow += 1
                sheetNo.Cells((lrow + rowcountQty), 11) = ds1.Tables(1).Rows(rowcountQty).Item("YOP")
                sheetNo.Cells((lrow + rowcountQty), 12) = ds1.Tables(1).Rows(rowcountQty).Item("Div")
                sheetNo.Cells((lrow + rowcountQty), 13) = ds1.Tables(1).Rows(rowcountQty).Item("Block")
                sheetNo.Cells((lrow + rowcountQty), 14) = ds1.Tables(1).Rows(rowcountQty).Item("Qty")
                lrow += 1
                'For Total Qty
                sheetNo.Range(sheetNo.Cells((lrow + rowcountQty), 13), sheetNo.Cells((lrow + rowcountQty), 14)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Range(sheetNo.Cells((lrow + rowcountQty), 13), sheetNo.Cells((lrow + rowcountQty), 14)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheetNo.Cells((lrow + rowcountQty), 13).font.bold = True
                sheetNo.Cells((lrow + rowcountQty), 14).font.bold = True

                sheetNo.Cells((lrow + rowcountQty), 13) = "Total Qty"
                sheetNo.Cells((lrow + rowcountQty), 14) = TotalQty


                'rowcountQty += 1
            End If
            lrow += 1


            WBTicketNo = ds1.Tables(1).Rows(rowcountQty).Item("WBTicketNo")
            i += 1
            lrow += 1
            rowcountTB += 1
            'rowcountQty += 1
        End While


        xlApp.Visible = True
        Dim strProductionRptName, lTextMonth As String
        lTextMonth = Format(dtpDate.Value, "dd/MM/yyyy")
        lTextMonth = lTextMonth.Replace("/", "-")
        strProductionRptName = "WeighInOut Listing Report - " & lTextMonth & ""

        sheetNo.Protect("RANNBSP@2010")

        Dim StrPath As String = "" & sDirName & "\BSP Weighbride Reports\" & strProductionRptName & ".xls"

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

    End Sub
End Class