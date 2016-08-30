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

Public Class RecapitulationFFBReceivedFrm

    Dim xlApp As Excel.Application
    Dim xlWorkBook As Excel.Workbook
    'Dim sheet As Excel.Worksheet
    Dim xlRange As Excel.Range
    Dim lrow As Integer = 9
    Dim lSupplierName As Integer = 4

    Dim dt1 As String = String.Empty
    Dim dt2 As String = String.Empty
    Dim dt3 As String = String.Empty
    Dim dt4 As String = String.Empty
    Dim dt5 As String = String.Empty
    Dim dt6 As String = String.Empty
    Dim dt7 As String = String.Empty
    Dim dt8 As String = String.Empty
    Dim dt9 As String = String.Empty
    Dim dt10 As String = String.Empty
    Dim dt11 As String = String.Empty
    Dim dt12 As String = String.Empty
    Dim dt13 As String = String.Empty
    Dim dt14 As String = String.Empty
    Dim dt15 As String = String.Empty
    Dim dt16 As String = String.Empty
    Dim dt17 As String = String.Empty
    Dim dt18 As String = String.Empty
    Dim dt19 As String = String.Empty
    Dim dt20 As String = String.Empty
    Dim dt21 As String = String.Empty
    Dim dt22 As String = String.Empty
    Dim dt23 As String = String.Empty
    Dim dt24 As String = String.Empty
    Dim dt25 As String = String.Empty
    Dim dt26 As String = String.Empty
    Dim dt27 As String = String.Empty
    Dim dt28 As String = String.Empty
    Dim dt29 As String = String.Empty
    Dim dt30 As String = String.Empty
    Dim dt31 As String = String.Empty

    Dim dtFdate As Date
    Dim dtTdate As Date

    Dim dtM, dtY, Fdate, Tdate As Integer
    Dim RprtDate As String



    Private Sub RecapitulationFFBReceivedFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        dtpDate.Format = DateTimePickerFormat.Custom
        dtpDate.CustomFormat = "MMM/yyyy"
        Dim dt As New DataTable
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        With objWBTicketInOutPPT
            .FYear = dtpDate.Value.Year
            .Period = dtpDate.Value.Month
        End With
        dt = WBWeighingInOutBOL.FiscalYearDate_Get(objWBTicketInOutPPT)

        'Fdate = 26
        'Tdate = 25
        'If dtM = 1 Then
        'dtFdate = ((dtY - 1).ToString() + "-" + "12" + "-" + Fdate.ToString())
        'Else
        'dtFdate = (dtY.ToString() + "-" + (dtM - 1).ToString() + "-" + Fdate.ToString())
        'End If
        'dtTdate = (dtY.ToString() + "-" + dtM.ToString() + "-" + Tdate.ToString())

        dtFdate = dt.Rows(0).Item("FromDt").ToString()
        dtTdate = dt.Rows(0).Item("ToDt").ToString()
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strFullMonthName As String = String.Empty
        Dim WeighDate As Date = dtpDate.Value
        Dim objGlobalBOL As New GlobalBOL
        RprtDate = objGlobalBOL.PMonthName(dtpDate.Value.Month, dtpDate.Value.Year, GlobalPPT.strLang)

        'RprtDate = CType(MonthName(Month(dtpDate.Value())), String)
        strMonthlyProdRptName = "RECAPITULATION FFB RECEIVED ( BUNCHES) - " & RprtDate & ""

        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        xlApp = New Excel.Application
        'xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\WB\Excel\RecapitulationFFBReceived.xlsx")



        Dim TemPath As String = Application.StartupPath & "\Reports\WeighBridge\Excel\RecapitulationFFBReceived.xlsx"
        If (File.Exists(TemPath)) Then
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\WeighBridge\Excel\RecapitulationFFBReceived.xlsx")
        Else
            MsgBox("RecapitulationFFBReceived report template missing.Please contact system administrator.")
            Exit Sub
        End If
        'Dim TemPath As String = Application.StartupPath & "\Reports\WB\Excel\" & strMonthlyProdRptName & ".xlsx"

        'If (File.Exists(TemPath)) Then
        '    File.Delete(TemPath)
        '    xlWorkBook.SaveAs(TemPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        'Else
        '    xlWorkBook.SaveAs(TemPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        'End If
        '
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
        ' Determine whether the directory exists.
        If Not di.Exists Then
            di.Create()
        End If


        'xlApp.Visible = True
        'Dim sheetNo As Excel.Worksheet
        'sheetNo = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

        'xlApp.Visible = True
        'sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)
        Dim con1 As New SqlConnection
        Dim cmd1 As New SqlCommand
        Dim da1 As New SqlDataAdapter

        Dim con2 As New SqlConnection
        'Dim cmd2 As New SqlCommand
        'Dim da2 As New SqlDataAdapter

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName


        Dim constr1 As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & StrInitialCatlog & ";User=" & strServerUserName & "; pwd=" & strServerPassword & ";Max Pool Size=100;Connection Timeout=60;"

        con1 = New SqlConnection(constr1)
        con1.Open()

        cmd1.Connection = con1
        cmd1.CommandText = "Weighbridge.WBRecapitulationFFBReceivedReport"
        cmd1.CommandType = CommandType.StoredProcedure
        cmd1.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd1.Parameters.AddWithValue("@FromDate", dtFdate)
        cmd1.Parameters.AddWithValue("@ToDate", dtTdate)


        Dim ds1 As New DataSet
        Dim tblAdt As New Odbc.OdbcDataAdapter

        da1.SelectCommand = cmd1
        da1.Fill(ds1, "Sample")

        Dim cntSupplier As Integer = 0
        cntSupplier = ds1.Tables(0).Rows.Count

        Dim cntS As Integer = 0
        Dim Supplier(cntSupplier) As String

        Dim sheetNo As Excel.Worksheet
        sheetNo = xlWorkBook.Sheets("Sheet1")
        sheetNo = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

        Dim sheet As Excel.Worksheet
        'sheet = xlWorkBook.Sheets("Sheet")
        'sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

        If cntSupplier > 0 Then


            For cntS = 0 To cntSupplier - 1
                Supplier(cntS) = ds1.Tables(0).Rows(cntS).Item("Supplier")

                sheet = xlWorkBook.Worksheets.Add
                sheetNo.UsedRange.Copy(Type.Missing.Value)
                sheet.PasteSpecial(Type.Missing.Value, Type.Missing.Value)
                sheetNo.Visible = False

                sheet.Cells(3, 1) = strMonthlyProdRptName
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                sheet.Cells(2, 3) = strArray(1)
                sheet.Cells(2, 30) = Format(Convert.ToDateTime(dtFdate), "dd/MM/yyyy")
                sheet.Cells(2, 33) = Format(Convert.ToDateTime(dtTdate), "dd/MM/yyyy")
                sheet.Range("AD1").EntireColumn.ColumnWidth = 10

                sheet.Name = Supplier(cntS)

                sheet.Cells(lSupplierName, 1) = "Supplier : " & Supplier(cntS) & ""

                Dim cmd2 As New SqlCommand
                Dim da2 As New SqlDataAdapter

                If ds1.Tables(0).Rows.Count > 0 Then
                    Dim constr2 As String = " Data Source=" & strDSN & "; Initial Catalog=" & StrInitialCatlog & ";User=" & strServerUserName & "; pwd=" & strServerPassword & ";Max Pool Size=100;Connection Timeout=60;"

                    con2 = New SqlConnection(constr1)

                    Dim ds As New DataSet
                    Dim tblAdt1 As New Odbc.OdbcDataAdapter
                    cmd2.Connection = con2
                    cmd2.CommandText = "Weighbridge.RecapitulationFFBReceivedReport"
                    cmd2.CommandType = CommandType.StoredProcedure
                    cmd2.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
                    cmd2.Parameters.AddWithValue("@Supplier", Supplier(cntS))
                    cmd2.Parameters.AddWithValue("@FromDate", dtFdate)
                    cmd2.Parameters.AddWithValue("@ToDate", dtTdate)
                    da2.SelectCommand = cmd2
                    da2.Fill(ds, "Samp")


                    Dim WeighingDate As String = String.Empty
                    Dim WBDate As Integer = 0
                    Dim rowcountTB As Integer = 0
                    Dim SubTotal As Integer = 0
                    Dim chkDiv As String = String.Empty
                    Dim nxtDiv As String = String.Empty
                    Dim chkYOP As String = String.Empty
                    Dim oRng As Excel.Range
                    Dim strData As String
                    Dim lTotal As Integer = 0
                    Dim totSubTotal As Integer = 0

                    Dim rowcount As Integer = ds.Tables(0).Rows.Count
                    Dim i As Integer = 0
                    While i < rowcount
                        Dim Div As String = ds.Tables(0).Rows(rowcountTB).Item("Div")
                        Dim YOP As String = ds.Tables(0).Rows(rowcountTB).Item("YOP")
                        Dim Block As String = ds.Tables(0).Rows(rowcountTB).Item("Block")

                        While Div = ds.Tables(0).Rows(rowcountTB).Item("Div")
                            'to avoid rebind Div in next row

                            If chkDiv = String.Empty Or chkDiv <> Div Then
                                sheet.Cells(lrow, 1) = ds.Tables(0).Rows(rowcountTB).Item("Div")
                            End If

                            While YOP = ds.Tables(0).Rows(rowcountTB).Item("YOP") And (Div = nxtDiv Or nxtDiv = String.Empty)
                                'to avoid rebind YOP in next row
                                If (chkYOP = String.Empty Or chkYOP <> YOP) Then
                                    sheet.Cells(lrow, 2) = ds.Tables(0).Rows(rowcountTB).Item("YOP")
                                End If

                                While Block = ds.Tables(0).Rows(rowcountTB).Item("Block")
                                    If i < rowcount Then
                                        sheet.Cells(lrow, 3) = ds.Tables(0).Rows(rowcountTB).Item("Block")

                                        WeighingDate = ds.Tables(0).Rows(rowcountTB).Item("WeighingDate")
                                        WBDate = Mid(WeighingDate, 1, Len(WeighingDate) - 8)

                                        Select Case WBDate
                                            Case "26"
                                                oRng = DirectCast(sheet.Cells(lrow, 29), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 29) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 29) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt26 <> String.Empty Then
                                                    dt26 = CInt(dt26 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt26 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "27"
                                                oRng = DirectCast(sheet.Cells(lrow, 30), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 30) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 30) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt27 <> String.Empty Then
                                                    dt27 = CInt(dt27 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt27 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "28"
                                                oRng = DirectCast(sheet.Cells(lrow, 31), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 31) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 31) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt28 <> String.Empty Then
                                                    dt28 = CInt(dt28 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt28 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "29"
                                                oRng = DirectCast(sheet.Cells(lrow, 32), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 32) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 32) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt29 <> String.Empty Then
                                                    dt29 = CInt(dt29 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt29 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "30"
                                                oRng = DirectCast(sheet.Cells(lrow, 33), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 33) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 33) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt30 <> String.Empty Then
                                                    dt30 = CInt(dt30 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt30 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "31"
                                                oRng = DirectCast(sheet.Cells(lrow, 34), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 34) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 34) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt31 <> String.Empty Then
                                                    dt31 = CInt(dt31 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt31 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "1"
                                                oRng = DirectCast(sheet.Cells(lrow, 4), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 4) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 4) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt1 <> String.Empty Then
                                                    dt1 = CInt(dt1 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt1 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "2"
                                                oRng = DirectCast(sheet.Cells(lrow, 5), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 5) = (ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 5) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt2 <> String.Empty Then
                                                    dt2 = CInt(dt2 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt2 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "3"
                                                oRng = DirectCast(sheet.Cells(lrow, 6), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 6) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 6) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt3 <> String.Empty Then
                                                    dt3 = CInt(dt3 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt3 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "4"
                                                oRng = DirectCast(sheet.Cells(lrow, 7), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 7) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 7) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt4 <> String.Empty Then
                                                    dt4 = CInt(dt4 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt4 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "5"
                                                oRng = DirectCast(sheet.Cells(lrow, 8), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 8) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 8) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt5 <> String.Empty Then
                                                    dt5 = CInt(dt5 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt5 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "6"
                                                oRng = DirectCast(sheet.Cells(lrow, 9), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 9) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 9) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt6 <> String.Empty Then
                                                    dt6 = CInt(dt6 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt6 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "7"
                                                oRng = DirectCast(sheet.Cells(lrow, 10), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 10) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 10) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt7 <> String.Empty Then
                                                    dt7 = CInt(dt7 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt7 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "8"
                                                oRng = DirectCast(sheet.Cells(lrow, 11), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 11) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 11) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt8 <> String.Empty Then
                                                    dt8 = CInt(dt8 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt8 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "9"
                                                oRng = DirectCast(sheet.Cells(lrow, 12), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 12) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 12) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt9 <> String.Empty Then
                                                    dt9 = CInt(dt9 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt9 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "10"
                                                oRng = DirectCast(sheet.Cells(lrow, 13), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 13) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 13) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt10 <> String.Empty Then
                                                    dt10 = CInt(dt10 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt10 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "11"
                                                oRng = DirectCast(sheet.Cells(lrow, 14), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 14) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 14) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt11 <> String.Empty Then
                                                    dt11 = CInt(dt11 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt11 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "12"
                                                oRng = DirectCast(sheet.Cells(lrow, 15), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 15) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 15) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt12 <> String.Empty Then
                                                    dt12 = CInt(dt12 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt12 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "13"
                                                oRng = DirectCast(sheet.Cells(lrow, 16), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 16) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 16) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt13 <> String.Empty Then
                                                    dt13 = CInt(dt13 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt13 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "14"
                                                oRng = DirectCast(sheet.Cells(lrow, 17), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 17) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 17) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt14 <> String.Empty Then
                                                    dt14 = CInt(dt14 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt14 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "15"
                                                oRng = DirectCast(sheet.Cells(lrow, 18), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 18) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 18) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt15 <> String.Empty Then
                                                    dt15 = CInt(dt15 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt15 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "16"
                                                oRng = DirectCast(sheet.Cells(lrow, 19), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 19) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 19) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt16 <> String.Empty Then
                                                    dt16 = CInt(dt16 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt16 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "17"
                                                oRng = DirectCast(sheet.Cells(lrow, 20), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 20) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 20) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt17 <> String.Empty Then
                                                    dt17 = CInt(dt17 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt17 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "18"
                                                oRng = DirectCast(sheet.Cells(lrow, 21), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 21) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 21) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt18 <> String.Empty Then
                                                    dt18 = CInt(dt18 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt18 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "19"
                                                oRng = DirectCast(sheet.Cells(lrow, 22), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 22) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 22) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt19 <> String.Empty Then
                                                    dt19 = CInt(dt19 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt19 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "20"
                                                oRng = DirectCast(sheet.Cells(lrow, 23), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 23) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 23) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt20 <> String.Empty Then
                                                    dt20 = CInt(dt20 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt20 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "21"
                                                oRng = DirectCast(sheet.Cells(lrow, 30), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 24) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 24) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt21 <> String.Empty Then
                                                    dt21 = CInt(dt21 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt21 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "22"
                                                oRng = DirectCast(sheet.Cells(lrow, 31), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 25) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 25) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt22 <> String.Empty Then
                                                    dt22 = CInt(dt22 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt22 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "23"
                                                oRng = DirectCast(sheet.Cells(lrow, 32), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 26) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 26) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt23 <> String.Empty Then
                                                    dt23 = CInt(dt23 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt23 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "24"
                                                oRng = DirectCast(sheet.Cells(lrow, 27), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 27) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 27) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt24 <> String.Empty Then
                                                    dt24 = CInt(dt24 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    dt24 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case "25"
                                                oRng = DirectCast(sheet.Cells(lrow, 28), Excel.Range)
                                                strData = oRng.Value
                                                If strData <> Nothing Then
                                                    sheet.Cells(lrow, 28) = CInt(ds.Tables(0).Rows(rowcountTB).Item("Qty") + strData).ToString()
                                                Else
                                                    sheet.Cells(lrow, 28) = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                If dt25 <> String.Empty Then
                                                    dt25 = CInt(dt25 + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                Else
                                                    'dt24 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                    dt25 = ds.Tables(0).Rows(rowcountTB).Item("Qty")
                                                End If
                                                lTotal = CInt(lTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                                totSubTotal = CInt(totSubTotal + ds.Tables(0).Rows(rowcountTB).Item("Qty")).ToString()
                                            Case Else

                                                Exit Select
                                        End Select

                                        'to capture previous YOP for validation to avoid repeatation
                                        chkYOP = ds.Tables(0).Rows(rowcountTB).Item("YOP")
                                        chkDiv = ds.Tables(0).Rows(rowcountTB).Item("Div")

                                        rowcountTB = rowcountTB + 1
                                        i = i + 1

                                        'lSupplier = ds.Tables(0).Rows(rowcountTB).Item("Supplier")

                                        sheet.Cells(lrow, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheet.Cells(lrow, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheet.Cells(lrow, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                        'End of row SubTotal 
                                        If i = rowcount Then
                                            sheet.Cells(lrow, 35) = lTotal
                                            lTotal = 0
                                            'drawLine()
                                            'For l = 4 To 35
                                            '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                            '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                            'Next l
                                            lrow = lrow + 1
                                            sheet.Cells(lrow, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheet.Cells(lrow, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheet.Cells(lrow, 3) = "Sub Total"
                                            sheet.Cells(lrow, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheet.Cells(lrow, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheet.Cells(lrow, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheet.Cells(lrow, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            sheet.Cells(lrow, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                            'drawLine()
                                            'For l = 4 To 35
                                            '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                            '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                            '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                            'Next l
                                            'calcsubTotal()
                                            sheet.Cells(lrow, 4) = dt1
                                            sheet.Cells(lrow, 5) = dt2
                                            sheet.Cells(lrow, 6) = dt3
                                            sheet.Cells(lrow, 7) = dt4
                                            sheet.Cells(lrow, 8) = dt5
                                            sheet.Cells(lrow, 9) = dt6
                                            sheet.Cells(lrow, 10) = dt7
                                            sheet.Cells(lrow, 11) = dt8
                                            sheet.Cells(lrow, 12) = dt9
                                            sheet.Cells(lrow, 13) = dt10
                                            sheet.Cells(lrow, 14) = dt11
                                            sheet.Cells(lrow, 15) = dt12
                                            sheet.Cells(lrow, 16) = dt13
                                            sheet.Cells(lrow, 17) = dt14
                                            sheet.Cells(lrow, 18) = dt15
                                            sheet.Cells(lrow, 19) = dt16
                                            sheet.Cells(lrow, 20) = dt17
                                            sheet.Cells(lrow, 21) = dt18
                                            sheet.Cells(lrow, 22) = dt19
                                            sheet.Cells(lrow, 23) = dt20
                                            sheet.Cells(lrow, 24) = dt21
                                            sheet.Cells(lrow, 25) = dt22
                                            sheet.Cells(lrow, 26) = dt23
                                            sheet.Cells(lrow, 27) = dt24
                                            sheet.Cells(lrow, 28) = dt25
                                            sheet.Cells(lrow, 29) = dt26
                                            sheet.Cells(lrow, 30) = dt27
                                            sheet.Cells(lrow, 31) = dt28
                                            sheet.Cells(lrow, 32) = dt29
                                            sheet.Cells(lrow, 33) = dt30
                                            sheet.Cells(lrow, 34) = dt31
                                            sheet.Cells(lrow, 35) = totSubTotal
                                            clearSubTotal()
                                            totSubTotal = 0
                                            'lrow = 9
                                            GoTo calculateyrwise
                                        End If
                                    End If
                                End While
                                sheet.Cells(lrow, 35) = lTotal
                                lTotal = 0
                                'drawLine()
                                'For l = 4 To 35
                                '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                'Next l
                                lrow = lrow + 1
                                Block = ds.Tables(0).Rows(rowcountTB).Item("Block")
                                nxtDiv = ds.Tables(0).Rows(rowcountTB).Item("Div")
                            End While
                            YOP = ds.Tables(0).Rows(rowcountTB).Item("YOP")

                            sheet.Cells(lrow, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(lrow, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(lrow, 3) = "Sub Total"
                            sheet.Cells(lrow, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(lrow, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(lrow, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            sheet.Cells(lrow, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            'drawLine()
                            'For l = 4 To 35
                            '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            '    sheet.Cells(lrow, i).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            'Next l
                            'calcsubTotal()
                            sheet.Cells(lrow, 4) = dt1
                            sheet.Cells(lrow, 5) = dt2
                            sheet.Cells(lrow, 6) = dt3
                            sheet.Cells(lrow, 7) = dt4
                            sheet.Cells(lrow, 8) = dt5
                            sheet.Cells(lrow, 9) = dt6
                            sheet.Cells(lrow, 10) = dt7
                            sheet.Cells(lrow, 11) = dt8
                            sheet.Cells(lrow, 12) = dt9
                            sheet.Cells(lrow, 13) = dt10
                            sheet.Cells(lrow, 14) = dt11
                            sheet.Cells(lrow, 15) = dt12
                            sheet.Cells(lrow, 16) = dt13
                            sheet.Cells(lrow, 17) = dt14
                            sheet.Cells(lrow, 18) = dt15
                            sheet.Cells(lrow, 19) = dt16
                            sheet.Cells(lrow, 20) = dt17
                            sheet.Cells(lrow, 21) = dt18
                            sheet.Cells(lrow, 22) = dt19
                            sheet.Cells(lrow, 23) = dt20
                            sheet.Cells(lrow, 24) = dt21
                            sheet.Cells(lrow, 25) = dt22
                            sheet.Cells(lrow, 26) = dt23
                            sheet.Cells(lrow, 27) = dt24
                            sheet.Cells(lrow, 28) = dt25
                            sheet.Cells(lrow, 29) = dt26
                            sheet.Cells(lrow, 30) = dt27
                            sheet.Cells(lrow, 31) = dt28
                            sheet.Cells(lrow, 32) = dt29
                            sheet.Cells(lrow, 33) = dt30
                            sheet.Cells(lrow, 34) = dt31
                            sheet.Cells(lrow, 35) = totSubTotal
                            clearSubTotal()
                            totSubTotal = 0
                            lrow = lrow + 1
                        End While
                        Div = ds.Tables(0).Rows(rowcountTB).Item("Div")
                        chkYOP = String.Empty
                        sheet.Cells(lrow - 1, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    End While

calculateyrwise:
                    Dim yrYop As String = String.Empty
                    Dim y As Integer = 0
                    Dim yrsrowcount As Integer = ds.Tables(1).Rows.Count
                    Dim chkyrYOP As String = String.Empty
                    rowcountTB = 0
                    lTotal = 0
                    i = 0
                    If ds.Tables(1).Rows.Count > 0 Then
                        lrow = lrow + 2
                        sheet.Cells(lrow, 1) = "TOTAL"
                        yrYop = ds.Tables(1).Rows(rowcountTB).Item("YOP")
                        sheet.Cells(lrow, 2) = yrYop

                        For j = 0 To yrsrowcount - 1
                            While yrYop = ds.Tables(1).Rows(rowcountTB).Item("YOP") And i < yrsrowcount
                                WeighingDate = ds.Tables(1).Rows(rowcountTB).Item("WeighingDate")
                                WBDate = Mid(WeighingDate, 1, Len(WeighingDate) - 8)

                                Select Case WBDate
                                    Case "26"
                                        sheet.Cells(lrow, 29) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "27"
                                        sheet.Cells(lrow, 30) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "28"
                                        sheet.Cells(lrow, 31) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "29"
                                        sheet.Cells(lrow, 32) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "30"
                                        sheet.Cells(lrow, 33) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "31"
                                        sheet.Cells(lrow, 34) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "1"
                                        sheet.Cells(lrow, 4) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "2"
                                        sheet.Cells(lrow, 5) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "3"
                                        sheet.Cells(lrow, 6) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "4"
                                        sheet.Cells(lrow, 7) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "5"
                                        sheet.Cells(lrow, 8) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "6"
                                        sheet.Cells(lrow, 9) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "7"
                                        sheet.Cells(lrow, 10) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "8"
                                        sheet.Cells(lrow, 11) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "9"
                                        sheet.Cells(lrow, 12) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "10"
                                        sheet.Cells(lrow, 13) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "11"
                                        sheet.Cells(lrow, 14) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "12"
                                        sheet.Cells(lrow, 15) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "13"
                                        sheet.Cells(lrow, 16) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "14"
                                        sheet.Cells(lrow, 17) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "15"
                                        sheet.Cells(lrow, 18) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "16"
                                        sheet.Cells(lrow, 19) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "17"
                                        sheet.Cells(lrow, 20) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "18"
                                        sheet.Cells(lrow, 21) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "19"
                                        sheet.Cells(lrow, 22) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "20"
                                        sheet.Cells(lrow, 23) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "21"
                                        sheet.Cells(lrow, 24) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "22"
                                        sheet.Cells(lrow, 25) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "23"
                                        sheet.Cells(lrow, 16) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "24"
                                        sheet.Cells(lrow, 27) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case "25"
                                        sheet.Cells(lrow, 28) = ds.Tables(1).Rows(rowcountTB).Item("Qty")
                                        lTotal = CInt(lTotal + ds.Tables(1).Rows(rowcountTB).Item("Qty")).ToString()

                                    Case Else

                                        Exit Select
                                End Select
                                rowcountTB = rowcountTB + 1
                                i = i + 1
                                If i = yrsrowcount Then
                                    sheet.Cells(lrow, 35) = lTotal
                                    'drawLineyr()
                                    For lyr = 1 To 35
                                        sheet.Cells(lrow, lyr).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheet.Cells(lrow, lyr).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                        sheet.Cells(lrow, lyr).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                                    Next lyr
                                    lrow = lrow + 3
                                    GoTo NextSupplier
                                End If
                            End While
                            sheet.Cells(lrow, 35) = lTotal
                            lTotal = 0
                            'drawLineyr()
                            For lyr = 1 To 35
                                sheet.Cells(lrow, lyr).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(lrow, lyr).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                                sheet.Cells(lrow, lyr).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            Next lyr
                            lrow = lrow + 1
                            yrYop = ds.Tables(1).Rows(rowcountTB).Item("YOP")
                            sheet.Cells(lrow, 2) = yrYop
                        Next j
                    End If
                End If
NextSupplier:
                cmd2.Dispose()
                lrow = 9
            Next cntS
            xlApp.Visible = True
            sheetNo.Protect("RANNBSP@2010")
        Else
            sheetNo.Cells(3, 1) = strMonthlyProdRptName
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            sheetNo.Cells(2, 3) = strArray(1)
            sheetNo.Cells(2, 30) = Format(Convert.ToDateTime(dtFdate), "dd/MM/yyyy")
            sheetNo.Cells(2, 33) = Format(Convert.ToDateTime(dtTdate), "dd/MM/yyyy")
            xlApp.Visible = True
            sheetNo.Protect("RANNBSP@2010")
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
    Private Sub calcsubTotal()
        'sheet.Cells(lrow, 4) = dt26
        'sheet.Cells(lrow, 5) = dt27
        'sheet.Cells(lrow, 6) = dt28
        'sheet.Cells(lrow, 7) = dt29
        'sheet.Cells(lrow, 8) = dt30
        'sheet.Cells(lrow, 9) = dt31
        'sheet.Cells(lrow, 10) = dt1
        'sheet.Cells(lrow, 11) = dt2
        'sheet.Cells(lrow, 12) = dt3
        'sheet.Cells(lrow, 13) = dt4
        'sheet.Cells(lrow, 14) = dt5
        'sheet.Cells(lrow, 15) = dt6
        'sheet.Cells(lrow, 16) = dt7
        'sheet.Cells(lrow, 17) = dt8
        'sheet.Cells(lrow, 18) = dt9
        'sheet.Cells(lrow, 19) = dt10
        'sheet.Cells(lrow, 20) = dt11
        'sheet.Cells(lrow, 21) = dt12
        'sheet.Cells(lrow, 22) = dt13
        'sheet.Cells(lrow, 23) = dt14
        'sheet.Cells(lrow, 24) = dt15
        'sheet.Cells(lrow, 25) = dt16
        'sheet.Cells(lrow, 26) = dt17
        'sheet.Cells(lrow, 27) = dt18
        'sheet.Cells(lrow, 28) = dt19
        'sheet.Cells(lrow, 29) = dt20
        'sheet.Cells(lrow, 30) = dt21
        'sheet.Cells(lrow, 31) = dt22
        'sheet.Cells(lrow, 32) = dt23
        'sheet.Cells(lrow, 33) = dt24
        'sheet.Cells(lrow, 34) = dt25
    End Sub

    Private Sub clearSubTotal()
        dt26 = String.Empty
        dt27 = String.Empty
        dt28 = String.Empty
        dt29 = String.Empty
        dt30 = String.Empty
        dt31 = String.Empty
        dt1 = String.Empty
        dt2 = String.Empty
        dt3 = String.Empty
        dt4 = String.Empty
        dt5 = String.Empty
        dt6 = String.Empty
        dt7 = String.Empty
        dt8 = String.Empty
        dt9 = String.Empty
        dt10 = String.Empty
        dt11 = String.Empty
        dt12 = String.Empty
        dt13 = String.Empty
        dt14 = String.Empty
        dt15 = String.Empty
        dt16 = String.Empty
        dt17 = String.Empty
        dt18 = String.Empty
        dt19 = String.Empty
        dt20 = String.Empty
        dt21 = String.Empty
        dt22 = String.Empty
        dt23 = String.Empty
        dt24 = String.Empty
        dt25 = String.Empty
    End Sub

    Private Sub drawLine()
        For l = 4 To 35
            'sheet.Cells(lrow, l).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            'sheet.Cells(lrow, l).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            'sheet.Cells(lrow, l).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        Next l
    End Sub

    Private Sub drawLineyr()
        For lyr = 1 To 35
            'sheet.Cells(lrow, lyr).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            'sheet.Cells(lrow, lyr).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            'sheet.Cells(lrow, lyr).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
        Next lyr
    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        'Dim dtM, dtY, Fdate, Tdate As Integer
        'dtM = dtpDate.Value.Month
        'dtY = dtpDate.Value.Year
        'Fdate = 26
        'Tdate = 25
        'If dtM = 1 Then
        '    dtFdate = ((dtY - 1).ToString() + "-" + "12" + "-" + Fdate.ToString())
        'Else
        '    dtFdate = (dtY.ToString() + "-" + (dtM - 1).ToString() + "-" + Fdate.ToString())
        'End If

        'dtTdate = (dtY.ToString() + "-" + dtM.ToString() + "-" + Tdate.ToString())

        Dim dt As New DataTable
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        With objWBTicketInOutPPT
            .FYear = dtpDate.Value.Year
            .Period = dtpDate.Value.Month
        End With
        dt = WBWeighingInOutBOL.FiscalYearDate_Get(objWBTicketInOutPPT)
        dtFdate = dt.Rows(0).Item("FromDt").ToString()
        dtTdate = dt.Rows(0).Item("ToDt").ToString()
    End Sub

    Private Sub RecapitulationFFBReceivedFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RecapitulationFFBReceivedFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)



            plWeighingDailyReport.CaptionText = rm.GetString("plWeighingDailyReport.CaptionText")


            lblsearchby.Text = rm.GetString("lblsearchby.Text")
            lblDate.Text = rm.GetString("lblFromDate.Text")
            btnviewReport.Text = rm.GetString("btnviewReport.Text")



        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class