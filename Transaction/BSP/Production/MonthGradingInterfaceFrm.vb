Imports Production_PPT
Imports Production_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports System.Configuration
Imports BSP.LoginFrm

Public Class MonthGradingInterfaceFrm

    Public Shared strmonth As Integer
    Public Shared strYear As Integer

    Private Sub MonthGradingInterfaceFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub MonthGradingInterfaceFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If GlobalPPT.strLang <> "en" Then
            ' btnSearch.Text = "Mencari"
            btnClose.Text = "Tutup"
            btnReport.Text = "Lihat Laporan"
        End If

        Dim ds As DataSet
        Dim objGradingFFBPPT As New GradingFFBPPT
        Dim objGradingFFBBOL As New GradingFFBBOL
        Dim Lmonth As String
        Dim LYear As String
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

        ds = objGradingFFBBOL.GradingFFBMonthYearGet(objGradingFFBPPT)

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        If cbMonth.Text = "" Or cbYear.Text = "" Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim ReportDirectory As String = String.Empty

        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlApp = New Excel.Application


        strmonth = cbMonth.SelectedValue
        strYear = cbYear.Text

        Dim TemPath As String = Application.StartupPath & "\Reports\Production\Excel\MonthGradingReport_Template.xls"

        If (File.Exists(TemPath)) Then

            xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath & "\Reports\Production\Excel\MonthGradingReport_Template.xls")
        Else
            MsgBox("Monthly Grading report template missing.Please contact system administrator.")
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
       
        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName


        'Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"

        Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd1 As New SqlCommand
        Dim da As New SqlDataAdapter
        con = New SqlConnection(constr)

        con.Open()



        cmd.Connection = con
        cmd.CommandText = "Production.MonthGradingReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure

        Dim strEstateid As String
        strEstateid = GlobalPPT.strEstateID
        cmd.Parameters.AddWithValue("@Estateid", strEstateid)
        cmd.Parameters.AddWithValue("@Month", strmonth)
        cmd.Parameters.AddWithValue("@Year", strYear)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "MonthGradingReport")
        Dim Pageno As Integer

        Pageno = 1
       
        strMonthlyProdRptName = "Monthly Grading Report   " & ds.Tables(0).Rows(0).Item("ToDT")


        Dim ldataCount As Integer = 0
        Dim StrPath As String = "" & sDirName & "\BSP Production Reports\" & strMonthlyProdRptName & ".xls"

        ldataCount = ds.Tables(1).Rows.Count
        Dim lSupplierCheck As Boolean = True
        Dim Row As Integer = 0
        Dim lcount As Integer = 0

        If ldataCount > 0 Then
            Dim sheet As Excel.Worksheet
            sheet = xlWorkBook.Sheets("Sheet1")
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

            Dim sheetNo As Excel.Worksheet
            While (ldataCount > 0)

                sheetNo = xlWorkBook.Worksheets.Add
                sheet.UsedRange.Copy(Type.Missing.Value)
                sheetNo.PasteSpecial(Type.Missing.Value, Type.Missing.Value)
                sheetNo.Name = ds.Tables(1).Rows(lcount).Item("SupplierName").ToString

                sheetNo.Cells(3, 11) = (GlobalPPT.strEstateName.Substring(GlobalPPT.strEstateName.IndexOf("-") + 1)).ToUpper

                Dim strtemp As String
                strtemp = "PERIODE : "
                strtemp += ds.Tables(0).Rows(0).Item("FromDT")
                strtemp += "  TO  "
                strtemp += ds.Tables(0).Rows(0).Item("ToDT")
                sheetNo.Cells(4, 11) = strtemp.ToString


                Dim CountSupplier As Integer = 0
                CountSupplier = ds.Tables(1).Rows.Count
                Dim lRowCount As Integer

                lRowCount = 9
                Dim lstr As String
                Dim lstr1 As String
                Dim lstr2 As String
                Dim lstr3 As String
                Dim lstr4 As String
                Dim lstr5 As String
                Dim lstr6 As String
                Dim lstr8 As String
                Dim lstr9 As String


                'lstr = ds.Tables(1).Rows(0).Item("UnripeFruitT").ToString
                'lstr = (lstr.Replace("<=", "  Min "))
                'lstr = (lstr.Replace(">=", "  Max "))
                'sheetNo.Cells(7, 11) = "Unripe Bunch" & "" & lstr

                'lstr1 = ds.Tables(1).Rows(0).Item("UnderripeT").ToString

                'lstr1 = (lstr1.Replace("<=", "  Min "))
                'lstr1 = (lstr1.Replace(">=", "  Max "))
                'sheetNo.Cells(7, 12) = "Underriped Bunch    " & "" & lstr1

                'lstr2 = ds.Tables(1).Rows(0).Item("RipeFruitT").ToString

                ''lstr2 = (lstr2.Replace("%", "  "))
                'lstr2 = (lstr2.Replace("<=", "  Min "))
                'lstr2 = (lstr2.Replace(">=", "  Max "))
                'sheetNo.Cells(7, 13) = "Ripe Bunch" & "" & lstr2

                'lstr3 = ds.Tables(1).Rows(0).Item("OverRipeFruitT").ToString

                ''lstr3 = (lstr3.Replace("%", "  "))
                'lstr3 = (lstr3.Replace("<=", "  Min "))
                'lstr3 = (lstr3.Replace(">=", "  Max "))
                'sheetNo.Cells(7, 14) = "O/Ripe Bunch    " & "" & lstr3

                'lstr4 = ds.Tables(1).Rows(0).Item("EmptyBunchFruitT").ToString

                ''lstr4 = (lstr4.Replace("%", "  "))
                'lstr4 = (lstr4.Replace("<=", "  Min "))
                'lstr4 = (lstr4.Replace(">=", "  Max "))
                'sheetNo.Cells(7, 15) = "Empty Bunch   " & "" & lstr4

                'lstr5 = ds.Tables(1).Rows(0).Item("PartheT").ToString

                ''lstr5 = (lstr5.Replace("%", "  "))
                'lstr5 = (lstr5.Replace("<=", "  Min "))
                'lstr5 = (lstr5.Replace(">=", "  Max "))
                'sheetNo.Cells(7, 16) = "Parthenocarp" & "" & lstr5


                'lstr6 = ds.Tables(1).Rows(0).Item("HardBunchT").ToString

                ''lstr6 = (lstr6.Replace("%", "  "))
                'lstr6 = (lstr6.Replace("<=", "  Min "))
                'lstr6 = (lstr6.Replace(">=", "  Max "))
                'sheetNo.Cells(7, 17) = "Hard Bunch    " & "" & lstr6

                'lstr8 = ds.Tables(1).Rows(0).Item("LightDamageT").ToString

                ''lstr8 = (lstr8.Replace("%", "  "))
                'lstr8 = (lstr8.Replace("<=", "  Min "))
                'lstr8 = (lstr8.Replace(">=", "  Max "))
                'sheetNo.Cells(8, 19) = "Ringan   " & "" & lstr8

                'lstr9 = ds.Tables(1).Rows(0).Item("LightDamageT").ToString

                ''lstr9 = (lstr9.Replace("%", "  "))
                'lstr9 = (lstr9.Replace("<=", "  Min "))
                'lstr9 = (lstr9.Replace(">=", "  Max "))
                'sheetNo.Cells(8, 20) = "Sedang " & "" & lstr9



                lSupplierCheck = True

                Dim a, d, f As Integer
                Dim b, c As Double

                If ldataCount > 0 Then
                    While (ldataCount > 0 And lSupplierCheck = True)

                        '  If lSupplierCheck = False Then
                        If (lcount > 0) Then
                            If ds.Tables(1).Rows(lcount).Item("GradingDate") = ds.Tables(1).Rows(lcount - 1).Item("GradingDate") And ds.Tables(1).Rows(lcount).Item("SupplierName").ToString = ds.Tables(1).Rows(lcount - 1).Item("SupplierName").ToString Then
                                sheetNo.Cells(lRowCount, 1) = ""
                            Else
                                sheetNo.Cells(lRowCount, 1) = Format(ds.Tables(1).Rows(lcount).Item("GradingDate").ToString)
                            End If
                        Else
                            sheetNo.Cells(lRowCount, 1) = Format(ds.Tables(1).Rows(lcount).Item("GradingDate").ToString)
                        End If
                        'Else
                        '    sheetNo.Cells(lRowCount, 1) = Format(ds.Tables(1).Rows(lcount).Item("GradingDate").ToString)
                        'End If

                        sheetNo.Cells(lRowCount, 2) = Format(ds.Tables(1).Rows(lcount).Item("Div").ToString)
                        sheetNo.Cells(lRowCount, 3) = Format(ds.Tables(1).Rows(lcount).Item("YOP").ToString)
                        'sheetNo.Cells(lRowCount, 4) = Format(ds.Tables(1).Rows(lcount).Item("FFBDeliveryOrderNo").ToString)
                        sheetNo.Cells(lRowCount, 4) = Format(ds.Tables(1).Rows(lcount).Item("WeighingId").ToString)
                        sheetNo.Cells(lRowCount, 5) = Format(ds.Tables(1).Rows(lcount).Item("Qty").ToString)
                        'commented and modified by stanley on 30-06-2011 .b 
                        'a = (ds.Tables(1).Rows(lcount).Item("TotalNormalFruitsJ")) + (ds.Tables(1).Rows(lcount).Item("TotalAbnormalFruitsJ"))
                        'Production.MonthGradingReport.AB = Production.MonthGradingReport.TotalNormalFruitsJ + Production.MonthGradingReport.TotalAbnormalFruitsJ
                        a = (ds.Tables(1).Rows(lcount).Item("AB"))
                        'commented and modified by stanley on 30-06-2011 .b 
                        sheetNo.Cells(lRowCount, 6) = a

                        d = (ds.Tables(1).Rows(lcount).Item("Qty")) - a
                        sheetNo.Cells(lRowCount, 7) = d
                        sheetNo.Cells(lRowCount, 8) = Format(ds.Tables(1).Rows(lcount).Item("NetWeight").ToString)
                        '  sheetNo.Cells(lRowCount, 8).numberformat = "0.000"
                        If a > 0 Then
                            c = (ds.Tables(1).Rows(lcount).Item("NetWeight")) / a
                        Else
                            c = (ds.Tables(1).Rows(lcount).Item("NetWeight")) / ds.Tables(1).Rows(lcount).Item("Qty")
                        End If
                        sheetNo.Cells(lRowCount, 9) = c

                        'Palani
                        sheetNo.Cells(lRowCount, 9).numberformat = "0.00"

                        b = (ds.Tables(1).Rows(lcount).Item("NetWeight")) / (ds.Tables(1).Rows(lcount).Item("Qty"))
                        sheetNo.Cells(lRowCount, 10) = b
                        sheetNo.Cells(lRowCount, 10).numberformat = "0.00"

                        sheetNo.Cells(lRowCount, 11) = Format(ds.Tables(1).Rows(lcount).Item("UnripeFruitP").ToString)
                        sheetNo.Cells(lRowCount, 12) = Format(ds.Tables(1).Rows(lcount).Item("UnderripeP").ToString)
                        sheetNo.Cells(lRowCount, 13) = Format(ds.Tables(1).Rows(lcount).Item("RipeFruitP").ToString)
                        sheetNo.Cells(lRowCount, 14) = Format(ds.Tables(1).Rows(lcount).Item("OverRipeFruitP").ToString)
                        sheetNo.Cells(lRowCount, 15) = Format(ds.Tables(1).Rows(lcount).Item("EmptyBunchFruitP").ToString)
                        sheetNo.Cells(lRowCount, 16) = Format(ds.Tables(1).Rows(lcount).Item("PartheP").ToString)
                        sheetNo.Cells(lRowCount, 17) = Format(ds.Tables(1).Rows(lcount).Item("HardBunchP").ToString)
                        sheetNo.Cells(lRowCount, 18) = Format(ds.Tables(1).Rows(lcount).Item("LooseFruitsP").ToString)
                        sheetNo.Cells(lRowCount, 19) = Format(ds.Tables(1).Rows(lcount).Item("LightDamageP").ToString)
                        sheetNo.Cells(lRowCount, 20) = Format(ds.Tables(1).Rows(lcount).Item("DamageP").ToString)

                        sheetNo.Cells(lRowCount, 21) = Format(ds.Tables(1).Rows(lcount).Item("UnripeFruitJ").ToString)
                        sheetNo.Cells(lRowCount, 21).NumberFormat = "0.00"

                        sheetNo.Cells(lRowCount, 22) = Format(ds.Tables(1).Rows(lcount).Item("UnderripeJ").ToString)
                        sheetNo.Cells(lRowCount, 22).NumberFormat = "0.00"

                        sheetNo.Cells(lRowCount, 23) = Format(ds.Tables(1).Rows(lcount).Item("EmptyBunchFruitJ").ToString)
                        sheetNo.Cells(lRowCount, 23).NumberFormat = "0.00"

                        f = (ds.Tables(1).Rows(lcount).Item("UnripeFruitJ")) + (ds.Tables(1).Rows(lcount).Item("UnderripeJ")) + (ds.Tables(1).Rows(lcount).Item("EmptyBunchFruitJ"))
                        sheetNo.Cells(lRowCount, 24) = f
                        sheetNo.Cells(lRowCount, 24).NumberFormat = "0.00"


                        lRowCount = lRowCount + 1
                        'CountSupplier = CountSupplier - 1
                        Row = Row + 1


                        If ldataCount > 1 Then
                            If ds.Tables(1).Rows(lcount).Item("SupplierName").ToString <> ds.Tables(1).Rows(lcount + 1).Item("SupplierName").ToString Then
                                lSupplierCheck = False
                            End If
                        Else
                            lSupplierCheck = False
                        End If

                        lcount = lcount + 1
                        ldataCount = ldataCount - 1
                        CountSupplier = CountSupplier - 1

                    End While

                    'Palani
                    sheetNo.Cells(lRowCount, 1) = "Grand Total"
                    sheetNo.Cells(lRowCount, 1).font.bold = True
                    sheetNo.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'sheetNo.Cells(lRowCount, 9) = "=sum(I9:" + "I" + (lRowCount - 1).ToString() + ")"
                    sheetNo.Cells(lRowCount, 9) = "=H" + (lRowCount).ToString() + " / F" + (lRowCount).ToString()
                    sheetNo.Cells(lRowCount, 9).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 9).font.bold = True
                    sheetNo.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount, 10) = "=H" + (lRowCount).ToString() + " / E" + (lRowCount).ToString()
                    sheetNo.Cells(lRowCount, 10).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 10).font.bold = True
                    sheetNo.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 10).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount, 5) = "=sum(E9:" + "E" + (lRowCount - 1).ToString() + ")"
                    sheetNo.Cells(lRowCount, 5).font.bold = True
                    sheetNo.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount, 6) = "=sum(F9:" + "F" + (lRowCount - 1).ToString() + ")"
                    sheetNo.Cells(lRowCount, 6).font.bold = True
                    sheetNo.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount, 7) = "=sum(G9:" + "G" + (lRowCount - 1).ToString() + ")"
                    sheetNo.Cells(lRowCount, 7).font.bold = True
                    sheetNo.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount, 8) = "=sum(H9:" + "H" + (lRowCount - 1).ToString() + ")"
                    sheetNo.Cells(lRowCount, 8).font.bold = True
                    sheetNo.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'Palani
                    'sheetNo.Cells(lRowCount, 11) = "=sum(K9:" + "K" + (lRowCount - 1).ToString() + ")"
                    'sheetNo.Cells(lRowCount, 11) = "=" + ds.Tables(2).Rows(0).Item("UnripeFruitJGT").ToString().Trim() + " / " + "F" + (lRowCount).ToString() + "*100"
                    sheetNo.Cells(lRowCount, 11) = ((Convert.ToDouble(GetValue(sheetNo.Name, "UnripeFruitJGT", ds)) / Convert.ToDouble(GetValue(sheetNo.Name, "AB2", ds))) * 100).ToString

                    sheetNo.Cells(lRowCount, 11).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 11).font.bold = True
                    sheetNo.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 11).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'sheetNo.Cells(lRowCount, 12) = "=sum(L9:" + "L" + (lRowCount - 1).ToString() + ")"
                    'sheetNo.Cells(lRowCount, 12) = "=" + ds.Tables(2).Rows(0).Item("UnderripeJGT").ToString().Trim() + " / " + "F" + (lRowCount).ToString() + "*100"
                    'Stanley@03-07-2011
                    'sheetNo.Cells(lRowCount, 12) = "=" + GetValue(sheetNo.Name, "UnderripeJGT", ds) + " / " + "F" + (lRowCount).ToString() + "*100"
                    sheetNo.Cells(lRowCount, 12) = ((Convert.ToDouble(GetValue(sheetNo.Name, "UnderripeJGT", ds)) / Convert.ToDouble(GetValue(sheetNo.Name, "AB2", ds))) * 100).ToString
                    sheetNo.Cells(lRowCount, 12).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 12).font.bold = True
                    sheetNo.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'sheetNo.Cells(lRowCount, 13) = "=sum(M9:" + "M" + (lRowCount - 1).ToString() + ")"
                    'sheetNo.Cells(lRowCount, 13) = "=" + ds.Tables(2).Rows(0).Item("RipeFruitJGT").ToString().Trim() + " / " + "F" + (lRowCount).ToString() + "*100"
                    'Stanley@03-07-2011
                    'sheetNo.Cells(lRowCount, 13) = "=" + GetValue(sheetNo.Name, "RipeFruitJGT", ds) + " / " + "F" + (lRowCount).ToString() + "*100"
                    sheetNo.Cells(lRowCount, 13) = ((Convert.ToDouble(GetValue(sheetNo.Name, "RipeFruitJGT", ds)) / Convert.ToDouble(GetValue(sheetNo.Name, "AB2", ds))) * 100).ToString
                    sheetNo.Cells(lRowCount, 13).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 13).font.bold = True
                    sheetNo.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 13).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'sheetNo.Cells(lRowCount, 14) = "=sum(N9:" + "N" + (lRowCount - 1).ToString() + ")"
                    'sheetNo.Cells(lRowCount, 14) = "=" + ds.Tables(2).Rows(0).Item("OverRipeFruitJGT").ToString().Trim() + " / " + "F" + (lRowCount).ToString() + "*100"
                    'Stanley@03-07-2011
                    'sheetNo.Cells(lRowCount, 14) = "=" + GetValue(sheetNo.Name, "OverRipeFruitJGT", ds) + " / " + "F" + (lRowCount).ToString() + "*100"
                    sheetNo.Cells(lRowCount, 14) = ((Convert.ToDouble(GetValue(sheetNo.Name, "OverRipeFruitJGT", ds)) / Convert.ToDouble(GetValue(sheetNo.Name, "AB2", ds))) * 100).ToString
                    sheetNo.Cells(lRowCount, 14).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 14).font.bold = True
                    sheetNo.Cells(lRowCount, 14).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 14).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'sheetNo.Cells(lRowCount, 15) = "=sum(O9:" + "O" + (lRowCount - 1).ToString() + ")"
                    'sheetNo.Cells(lRowCount, 15) = "=" + ds.Tables(2).Rows(0).Item("EmptyBunchFruitJGT").ToString().Trim() + " / " + "F" + (lRowCount).ToString() + "*100"
                    'Stanley@03-07-2011
                    'sheetNo.Cells(lRowCount, 15) = "=" + GetValue(sheetNo.Name, "EmptyBunchFruitJGT", ds) + " / " + "F" + (lRowCount).ToString() + "*100"
                    sheetNo.Cells(lRowCount, 15) = ((Convert.ToDouble(GetValue(sheetNo.Name, "EmptyBunchFruitJGT", ds)) / Convert.ToDouble(GetValue(sheetNo.Name, "AB2", ds))) * 100).ToString
                    sheetNo.Cells(lRowCount, 15).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 15).font.bold = True
                    sheetNo.Cells(lRowCount, 15).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 15).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'sheetNo.Cells(lRowCount, 16) = "=sum(P9:" + "P" + (lRowCount - 1).ToString() + ")"
                    'sheetNo.Cells(lRowCount, 16) = "=" + ds.Tables(2).Rows(0).Item("PartheJGT").ToString().Trim() + " / " + "F" + (lRowCount).ToString() + "*100"
                    'Stanley@03-07-2011
                    'sheetNo.Cells(lRowCount, 16) = "=" + GetValue(sheetNo.Name, "PartheJGT", ds) + " / " + "F" + (lRowCount).ToString() + "*100"
                    sheetNo.Cells(lRowCount, 16) = ((Convert.ToDouble(GetValue(sheetNo.Name, "PartheJGT", ds)) / Convert.ToDouble(GetValue(sheetNo.Name, "AB2", ds))) * 100).ToString
                    sheetNo.Cells(lRowCount, 16).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 16).font.bold = True
                    sheetNo.Cells(lRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 16).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'sheetNo.Cells(lRowCount, 17) = "=sum(Q9:" + "Q" + (lRowCount - 1).ToString() + ")"
                    'sheetNo.Cells(lRowCount, 17) = "=" + ds.Tables(2).Rows(0).Item("HardBunchJGT").ToString().Trim() + " / " + "F" + (lRowCount).ToString() + "*100"
                    'Stanley@03-07-2011
                    'sheetNo.Cells(lRowCount, 17) = "=" + GetValue(sheetNo.Name, "HardBunchJGT", ds) + " / " + "F" + (lRowCount).ToString() + "*100"
                    sheetNo.Cells(lRowCount, 17) = ((Convert.ToDouble(GetValue(sheetNo.Name, "HardBunchJGT", ds)) / Convert.ToDouble(GetValue(sheetNo.Name, "AB2", ds))) * 100).ToString
                    sheetNo.Cells(lRowCount, 17).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 17).font.bold = True
                    sheetNo.Cells(lRowCount, 17).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 17).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'sheetNo.Cells(lRowCount, 18) = "=sum(R9:" + "R" + (lRowCount - 1).ToString() + ")"
                    'sheetNo.Cells(lRowCount, 18) = "=" + ds.Tables(2).Rows(0).Item("KgOfLooseFruitGT").ToString().Trim() + " / " + "H" + (lRowCount).ToString() + "*100"
                    'Stanley@03-07-2011
                    'sheetNo.Cells(lRowCount, 18) = "=" + GetValue(sheetNo.Name, "KgOfLooseFruitGT", ds) + " / " + "F" + (lRowCount).ToString() + "*100"
                    sheetNo.Cells(lRowCount, 18) = ((Convert.ToDouble(GetValue(sheetNo.Name, "KgOfLooseFruitGT", ds)) / Convert.ToDouble(GetValue(sheetNo.Name, "NetWeight2", ds))) * 100).ToString
                    sheetNo.Cells(lRowCount, 18).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 18).font.bold = True
                    sheetNo.Cells(lRowCount, 18).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 18).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'sheetNo.Cells(lRowCount, 19) = "=sum(S9:" + "S" + (lRowCount - 1).ToString() + ")"
                    'sheetNo.Cells(lRowCount, 19) = "=" + ds.Tables(2).Rows(0).Item("lightdamagejGT").ToString().Trim() + " / " + "F" + (lRowCount).ToString() + "*100"
                    'Stanley@03-07-2011
                    'sheetNo.Cells(lRowCount, 19) = "=" + GetValue(sheetNo.Name, "lightdamagejGT", ds) + " / " + "F" + (lRowCount).ToString() + "*100"
                    sheetNo.Cells(lRowCount, 19) = ((Convert.ToDouble(GetValue(sheetNo.Name, "lightdamagejGT", ds)) / Convert.ToDouble(GetValue(sheetNo.Name, "AB2", ds))) * 100).ToString
                    sheetNo.Cells(lRowCount, 19).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 19).font.bold = True
                    sheetNo.Cells(lRowCount, 19).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 19).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    'sheetNo.Cells(lRowCount, 20) = "=sum(T9:" + "T" + (lRowCount - 1).ToString() + ")"
                    'sheetNo.Cells(lRowCount, 20) = "=" + ds.Tables(2).Rows(0).Item("damagejGT").ToString().Trim() + " / " + "F" + (lRowCount).ToString() + "*100"
                    'Stanley@03-07-2011
                    'sheetNo.Cells(lRowCount, 20) = "=" + GetValue(sheetNo.Name, "damagejGT", ds) + " / " + "F" + (lRowCount).ToString() + "*100"

                    sheetNo.Cells(lRowCount, 20) = ((Convert.ToDouble(GetValue(sheetNo.Name, "damagejGT", ds)) / Convert.ToDouble(GetValue(sheetNo.Name, "AB2", ds))) * 100).ToString
                    sheetNo.Cells(lRowCount, 20).NumberFormat = "0.00"
                    sheetNo.Cells(lRowCount, 20).font.bold = True
                    sheetNo.Cells(lRowCount, 20).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 20).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount, 21) = "=sum(U9:" + "U" + (lRowCount - 1).ToString() + ")"
                    sheetNo.Cells(lRowCount, 21).font.bold = True
                    sheetNo.Cells(lRowCount, 21).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 21).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount, 22) = "=sum(V9:" + "V" + (lRowCount - 1).ToString() + ")"
                    sheetNo.Cells(lRowCount, 22).font.bold = True
                    sheetNo.Cells(lRowCount, 22).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 22).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount, 23) = "=sum(W9:" + "W" + (lRowCount - 1).ToString() + ")"
                    sheetNo.Cells(lRowCount, 23).font.bold = True
                    sheetNo.Cells(lRowCount, 23).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 23).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount, 24) = "=sum(X9:" + "X" + (lRowCount - 1).ToString() + ")"
                    sheetNo.Cells(lRowCount, 24).font.bold = True
                    sheetNo.Cells(lRowCount, 24).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheetNo.Cells(lRowCount, 24).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount + 4, 2) = "Checked By"
                    sheetNo.Cells(lRowCount + 8, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    'sheetNo.Cells(lRowCount + 5, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount + 4, 7) = "Verified By"
                    sheetNo.Cells(lRowCount + 8, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    'sheetNo.Cells(lRowCount + 5, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Cells(lRowCount + 4, 12) = "Approved By"
                    sheetNo.Cells(lRowCount + 8, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    'sheetNo.Cells(lRowCount + 5, 12).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheetNo.Range("A1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("B1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("C1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("D1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("E1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("F1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("G1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("H1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("I1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("J1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("K1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("L1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("M1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("N1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("O1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("P1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("Q1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("R1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("S1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("T1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("U1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("V1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("W1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("X1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("Y1").EntireColumn.ColumnWidth = 13
                    sheetNo.Range("Z1").EntireColumn.ColumnWidth = 13
                  
                    sheetNo.Protect("RANNBSP@2010")

                End If


                ' ldataCount = ldataCount + 1
            End While

            sheet.Visible = False
            xlApp.Visible = True


        End If
        

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        Cursor = Cursors.Arrow
    End Sub

    Private Function GetValue(ByVal strSupplierName As String, ByVal strFieldName As String, ByVal dsTemp As DataSet) As String
        Dim strREstult As String = ""

        For intRow As Integer = 0 To dsTemp.Tables(2).Rows.Count - 1
            If (strSupplierName = dsTemp.Tables(2).Rows(intRow).Item("SuppName").ToString().Trim()) Then
                If strFieldName = "UnripeFruitJGT" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("UnripeFruitJGT").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "UnderripeJGT" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("UnderripeJGT").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "RipeFruitJGT" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("RipeFruitJGT").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "OverRipeFruitJGT" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("OverRipeFruitJGT").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "EmptyBunchFruitJGT" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("EmptyBunchFruitJGT").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "PartheJGT" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("PartheJGT").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "HardBunchJGT" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("HardBunchJGT").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "KgOfLooseFruitGT" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("KgOfLooseFruitGT").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "lightdamagejGT" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("lightdamagejGT").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "damagejGT" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("damagejGT").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "NetWeight2" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("NetWeight2").ToString().Trim()
                    Exit For
                ElseIf strFieldName = "AB2" Then
                    strREstult = dsTemp.Tables(2).Rows(intRow).Item("AB2").ToString().Trim()
                    Exit For
                End If
            End If
        Next
        If strREstult = "" Then strREstult = 0
        GetValue = strREstult
    End Function

End Class