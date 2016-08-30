Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient

Public Class ReportODBCMethod


    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty

    Private Sub ReportODBCMethod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''strDSN = "DSN= " & ConfigurationManager.AppSettings.Item("oDSN").ToString & ""
        'strServerUserName = "UID=" & ConfigurationManager.AppSettings.Item("oUserName").ToString & ""
        'strServerPassword = "pwd=" & ConfigurationManager.AppSettings.Item("oPassword").ToString & ""

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password


        '  Dim constr As String = "" & strDSN & ";" & strServerUserName & "; " & strServerPassword & ";"
        'Dim constr1 As String = "DSN=BSPDSN;UID=sa;pwd=sql2008;"

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        ' Dim constr As String = "DSN=BSPDSN;" & strServerUserName & "; " & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()



        'Store Reports Start

        If InternalPurchaseRequisitionFrm.StrFrmName = "IPR" Then
            Dim rpt As New IPRReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName
            cmd.CommandText = "Store.IPRReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & InternalPurchaseRequisitionFrm.psIPRID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "IPRReport;1")
            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)

            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "PURCHASE REQUISITION PROOF LIST " & lTextmonth & ""

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            InternalPurchaseRequisitionFrm.StrFrmName = String.Empty
        ElseIf InternalServiceRequisitionFrm.StrFrmName = "ISR" Then
            Dim rpt As New ISRReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            cmd.CommandText = "Store.ISRReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & InternalServiceRequisitionFrm.psSTISRID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "ISRReport;1")
            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "INTERNAL SERVICE REQUISTION PROOF LIST " & lTextmonth & ""
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            InternalServiceRequisitionFrm.StrFrmName = String.Empty


        ElseIf NonStockIPRFrm.StrFrmName = "NonStockIPR" Then
            Dim rpt As New STNonStockIPRReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            cmd.CommandText = "Store.STNonStockIPRReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & NonStockIPRFrm.psNonIPRID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "STNonStockIPRReport;1")
            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "NON STOCK IPR PROOF LIST " & lTextmonth & ""
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            NonStockIPRFrm.StrFrmName = String.Empty

        ElseIf StoreIssueVoucherFrm.StrFrmName = "SIV" Then
            Dim rpt As New SIVReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            cmd.CommandText = "Store.SIVReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & StoreIssueVoucherFrm.psSIVSTIssueId & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "SIVReport;1")
            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "STORE ISSUE VOUCHER PROOF LIST " & lTextmonth & ""
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            StoreIssueVoucherFrm.StrFrmName = String.Empty


        ElseIf EstateMillDeliveryNoteFrm.StrFrmName = "EstMillDelivery" Then
            Dim rpt As New EstMillDeliveryReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            cmd.CommandText = "Store.STMillDeliveryReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & EstateMillDeliveryNoteFrm.psSTEstMillDeliveryID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "STMillDeliveryReport;1")
            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "ESTATE/MILL DELIVERY NOTE PROOF LIST " & lTextmonth & ""

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            EstateMillDeliveryNoteFrm.StrFrmName = String.Empty

        ElseIf InternalTransferNoteINFrm.StrFrmName = "ITNIn" Then
            Dim rpt As New ITNInReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            cmd.CommandText = "Store.ITNINReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "ITNINReport;1")
            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "TRANSFER NOTE IN PROOF LIST " & lTextmonth & ""

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            InternalTransferNoteINFrm.StrFrmName = String.Empty

        ElseIf InternalTransferNoteOUTFrm.StrFrmName = "ITNOut" Then
            Dim rpt As New ITNOutReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            cmd.CommandText = "Store.ITNOutReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "ITNOutReport;1")
            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "TRANSFER NOTE OUT PROOF LIST " & lTextmonth & ""

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            InternalTransferNoteOUTFrm.StrFrmName = String.Empty

        ElseIf LocalPuchaseOrderFrm.StrFrmName = "LPOReport" Then
            'Dim rpt As New LPOReport
            Dim rpt As New LPOReportNew
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            'Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            'txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'txtPrintedby.Text = GlobalPPT.strUserName

            cmd.CommandText = "Store.LPOReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & LocalPuchaseOrderFrm.psSTLPOID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "LPOReport;1")

            'Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            'txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'Dim objCommonBOl As New GlobalBOL
            'Dim lTextmonth As String = String.Empty
            'lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            'txtMonthYear.Text = "PURCHASE ORDER PROOF LIST " & lTextmonth & ""

            rpt.SetDataSource(ds)

            Dim total As Double
            For Each dr As DataRow In ds.Tables(0).Rows
                total = total + (CDbl(dr.Item("Qty")) * CDbl(dr.Item("UnitPrice")))
            Next

            Dim vATPercent = (total * CDbl(ds.Tables(0).Rows(0).Item("VATPercent"))) / 100
            Dim Sumtotal = total + vATPercent
            Dim objTerbilang As New Terbilang
            Dim txtTerbilang As CrystalDecisions.CrystalReports.Engine.TextObject
            txtTerbilang = CType(rpt.ReportDefinition.ReportObjects.Item("txtTerbilang"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim toRound = Format(Sumtotal, "0")
            txtTerbilang.Text = objTerbilang.GetFigures(toRound.ToString()) & " Rupiah"

            CrystalReportViewer1.ReportSource = rpt
            LocalPuchaseOrderFrm.StrFrmName = String.Empty

        ElseIf StockAdjustmentFrm.StrFrmName = "STA" Then
            Dim rpt As New STAReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName
            cmd.CommandText = "Store.STAReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "STAReport;1")
            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "STOCK ADJUSTMENT PROOF LIST " & lTextmonth & ""

            'Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strDisplayName

            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)

            Dim txtFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFromDate.Text = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            StockAdjustmentFrm.StrFrmName = String.Empty
            '' ------------------ SUMMARY REPORTS   ----------------------------------------------------------------------

            ''-------------------- IDN SUMMARY REPORT----------

        ElseIf SummaryReportsFrm.StrFrmName = "IDNSummaryReport" Then

            Dim objCommonBOl As New GlobalBOL

            Dim rpt As New IDNSummaryReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strDisplayName


            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)

            Dim txtFrmDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFrmDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFrmDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFrmDate.Text = SummaryReportsFrm.strFrmDate

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = SummaryReportsFrm.strToDate

            Dim txtTitle As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim lTextmonth As String = String.Empty
            Dim lTextyear As String = String.Empty
            txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            lTextmonth = SummaryReportsFrm.strmonname

            GlobalPPT.IntLoginMonth = lTextmonth
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

            txtTitle.Text = "DELIVERY NOTE SUMMARY " & lTextmonth & " "



            cmd.CommandText = "Store.SummaryReport '" & GlobalPPT.strEstateID & "','" & SummaryReportsFrm.strAmonth & "','" & SummaryReportsFrm.strAYear & "','" & SummaryReportsFrm.strtask & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "SummaryReport;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            SummaryReportsFrm.StrFrmName = ""

            ''-------------------- ITNIN SUMMARY REPORT----------

        ElseIf SummaryReportsFrm.StrFrmName = "ITNINSummary" Then
            Dim objCommonBOl As New GlobalBOL
            Dim rpt As New ITNINSummaryReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strDisplayName

            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)


            Dim txtFrmDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFrmDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFrmDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFrmDate.Text = SummaryReportsFrm.strFrmDate

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = SummaryReportsFrm.strToDate

            Dim txtTitle As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim lTextmonth As String = String.Empty
            Dim lTextyear As String = String.Empty
            txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            lTextmonth = SummaryReportsFrm.strmonname

            GlobalPPT.IntLoginMonth = SummaryReportsFrm.strmonname
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

            txtTitle.Text = "TRANSFER NOTE IN SUMMARY " & lTextmonth & " "

            cmd.CommandText = "Store.SummaryReport '" & GlobalPPT.strEstateID & "','" & SummaryReportsFrm.strAmonth & "','" & SummaryReportsFrm.strAYear & "','" & SummaryReportsFrm.strtask & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "SummaryReport;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            SummaryReportsFrm.StrFrmName = ""

            ''-------------------- ITNOUT SUMMARY REPORT----------

        ElseIf SummaryReportsFrm.StrFrmName = "ITNOUTSummary" Then
            Dim objCommonBOl As New GlobalBOL
            Dim rpt As New ITNOUTSummaryReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strDisplayName

            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)

            Dim txtFrmDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFrmDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFrmDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFrmDate.Text = SummaryReportsFrm.strFrmDate

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = SummaryReportsFrm.strToDate

            Dim txtTitle As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim lTextmonth As String = String.Empty
            Dim lTextyear As String = String.Empty
            txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            lTextmonth = SummaryReportsFrm.strmonname

            GlobalPPT.IntLoginMonth = SummaryReportsFrm.strmonname
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtTitle.Text = "INTERNEL TRANSFER NOTE OUT SUMMARY " & lTextmonth & " "

            cmd.CommandText = "Store.SummaryReport '" & GlobalPPT.strEstateID & "','" & SummaryReportsFrm.strAmonth & "','" & SummaryReportsFrm.strAYear & "','" & SummaryReportsFrm.strtask & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "SummaryReport;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            SummaryReportsFrm.StrFrmName = ""

            ''-------------------- Adjustment SUMMARY REPORT----------

        ElseIf SummaryReportsFrm.StrFrmName = "AdjustmentSummary" Then
            Dim objCommonBOl As New GlobalBOL
            Dim rpt As New AdjustmentSummaryReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strDisplayName

            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)


            Dim txtFrmDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFrmDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFrmDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFrmDate.Text = SummaryReportsFrm.strFrmDate

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = SummaryReportsFrm.strToDate

            Dim txtTitle As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim lTextmonth As String = String.Empty
            Dim lTextyear As String = String.Empty
            txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            lTextmonth = SummaryReportsFrm.strmonname

            GlobalPPT.IntLoginMonth = SummaryReportsFrm.strmonname
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtTitle.Text = "ADJUSTMENT SUMMARY " & lTextmonth & " "

            cmd.CommandText = "Store.SummaryReport '" & GlobalPPT.strEstateID & "','" & SummaryReportsFrm.strAmonth & "','" & SummaryReportsFrm.strAYear & "','" & SummaryReportsFrm.strtask & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "SummaryReport;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            SummaryReportsFrm.StrFrmName = ""

            ''-------------------- RGN SUMMARY REPORT----------

        ElseIf SummaryReportsFrm.StrFrmName = "RGNSummary" Then
            Dim objCommonBOl As New GlobalBOL
            Dim rpt As New AdjustmentSummaryReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strDisplayName


            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)

            Dim txtFrmDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFrmDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFrmDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFrmDate.Text = SummaryReportsFrm.strFrmDate

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = SummaryReportsFrm.strToDate

            Dim txtTitle As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim lTextmonth As String = String.Empty
            Dim lTextyear As String = String.Empty
            txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            lTextmonth = SummaryReportsFrm.strmonname

            GlobalPPT.IntLoginMonth = SummaryReportsFrm.strmonname
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtTitle.Text = "RETURN GOODS NOTE SUMMARY " & lTextmonth & " "

            cmd.CommandText = "Store.SummaryReport '" & GlobalPPT.strEstateID & "','" & SummaryReportsFrm.strAmonth & "','" & SummaryReportsFrm.strAYear & "','" & SummaryReportsFrm.strtask & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "SummaryReport;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            SummaryReportsFrm.StrFrmName = ""

            ''--------------End Summary Reports-----------------------------------------------

            ''--------------ITN IN & OUT REPORTS------------------------------------------------------''
        ElseIf ITNINReportInterfacefrm.strFrmName = "ITNIN" Then

            Dim rpt As New InternalTransferNoteRpt
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtFiscal.Text = "TRANSFER NOTE IN " & lTextmonth & " "

            cmd.CommandText = "[Store].[InternalTransferNoteReportGet] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & "IN" & "','" & ITNINReportInterfacefrm.strINID & "','" & "" & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "InternalTransferNoteReportGet;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            ITNINReportInterfacefrm.strFrmName = ""
        ElseIf ITNINReportInterfacefrm.strFrmName = "ITNINALL" Then

            Dim rpt As New InternalTransferNoteRpt
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtFiscal.Text = "TRANSFER NOTE IN " & lTextmonth & " "

            cmd.CommandText = "[Store].[InternalTransferNoteReportGet] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & "INALL" & "','" & "" & "','" & "" & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "InternalTransferNoteReportGet;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            ITNINReportInterfacefrm.strFrmName = ""


        ElseIf ITNOUTReportInterfacefrm.strFrmName = "ITNOUT" Then
            Dim rpt As New InternalTransferNoteRpt
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            ''GlobalPPT.IntLoginMonth = SummaryReportsFrm.strmonname
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtFiscal.Text = "TRANSFER NOTE OUT " & lTextmonth & " "

            cmd.CommandText = "[Store].[InternalTransferNoteReportGet] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & "OUT" & "','" & "" & "','" & ITNOUTReportInterfacefrm.stroutID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "InternalTransferNoteReportGet;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            ITNINReportInterfacefrm.strFrmName = ""

        ElseIf ITNOUTReportInterfacefrm.strFrmName = "ITNOUTALL" Then

            Dim rpt As New InternalTransferNoteRpt
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            ''GlobalPPT.IntLoginMonth = SummaryReportsFrm.strmonname
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtFiscal.Text = "TRANSFER NOTE OUT " & lTextmonth & " "

            cmd.CommandText = "[Store].[InternalTransferNoteReportGet] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & "OUTALL" & "','" & "" & "','" & "" & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "InternalTransferNoteReportGet;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            ITNINReportInterfacefrm.strFrmName = ""



            ''--------------END OF ITN IN & OUT REPORTS-----------------------------------------------''



            'Store Reports End

            'Accounts Reports Start

        ElseIf PettyCashPaymentFrm.StrFrmName = "PCP" Then
            Dim rpt As New PettyCashPaymentReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            cmd.CommandText = "Accounts.PettyCashPaymentReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "PettyCashPaymentReport;1")


            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "PETTY CASH PAYMENT PROOF LIST " & lTextmonth & ""

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt

        ElseIf JournalFrm.StrFrmName = "Journal" Then
            Dim rpt As New AccJournalReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "JOURNAL PROOF LIST " & lTextmonth & ""

            cmd.CommandText = "Accounts.AccJournalReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "AccJournalReport;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            JournalFrm.StrFrmName = ""
            'Accounts Reports End


            'WeighBridge Reports Start

        ElseIf WBWeighingInOutFrm.StrFrmName = "WBWeighingInOutRpt" Then
            Dim rpt As New WeighBridgeReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            Dim weight As String = WBWeighingInOutFrm.lWeight

            cmd.Connection = con
            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            cmd.CommandText = "WeighBridge.WBWeighingInOutWBTicketReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & weight & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "WBWeighingInOutWBTicketReport;1")
            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "WEIGH BRIDGE TICKET PROOF LIST " & lTextmonth & ""

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            WBWeighingInOutFrm.StrFrmName = ""

            'ElseIf WBWeighingInOutFrm.StrFrmName = "WBWeighingInOutRpt" Then
            '    Dim rpt As New WeighBridgeReport
            '    Dim tblAdt As New Odbc.OdbcDataAdapter
            '    Dim ds As New DataSet
            '    cmd.Connection = con

            '    Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            '    txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '    txtPrintedby.Text = GlobalPPT.strUserName

            '    cmd.CommandText = "WeighBridge.WBWeighingInOutWBTicketReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            '    cmd.CommandType = CommandType.StoredProcedure
            '    tblAdt.SelectCommand = cmd
            '    tblAdt.Fill(ds, "WBWeighingInOutWBTicketReport;1")
            '    Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            '    txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '    Dim objCommonBOl As New GlobalBOL
            '    Dim lTextmonth As String = String.Empty
            '    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            '    txtMonthYear.Text = "WEIGH BRIDGE TICKET PROOF LIST " & lTextmonth & ""

            '    rpt.SetDataSource(ds)
            '    CrystalReportViewer1.ReportSource = rpt
            '    WBWeighingInOutFrm.StrFrmName = ""
            'ElseIf WBWeighingInOutFrm.StrFrmName = "WBTicketNORpt" Then
            '    Dim WBTicketNo As String = WBWeighingInOutFrm.WBRicketNo
            '    Dim rpt As New WeighBridgeTicket
            '    Dim tblAdt As New Odbc.OdbcDataAdapter
            '    Dim ds As New DataSet
            '    cmd.Connection = con

            '    cmd.CommandText = "Weighbridge.WBWeighingInOutReport '" & GlobalPPT.strEstateID & "','" & WBTicketNo & "','" & GlobalPPT.strActMthYearID & "'"
            '    cmd.CommandType = CommandType.StoredProcedure
            '    tblAdt.SelectCommand = cmd
            '    tblAdt.Fill(ds, "WBWeighingInOutReport;1")
            '    'rpt = New LPOReport
            '    'rpt.SetParameterValue("@EstateID", GlobalPPT.strEstateID)
            '    'rpt.SetParameterValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            '    'rpt.Database.Dispose()
            '    'Dim tbl As New DataTable
            '    'tbl = ds.Tables(0)

            '    rpt.SetDataSource(ds)
            '    CrystalReportViewer1.ReportSource = rpt
            '    CrystalReportViewer1.PrintReport()
            '    Me.Close()

        ElseIf WBWeighingInOutFrm.StrFrmName = "WBTicketNORpt" Then
            Dim WBTicketNo As String = WBWeighingInOutFrm.WBRicketNo
            Dim Others As String = WBWeighingInOutFrm.Others
            Dim rpt As New WeighBridgeTicket
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            cmd.CommandText = "Weighbridge.WBWeighingInOutReport '" & GlobalPPT.strEstateID & "','" & WBTicketNo & "','" & GlobalPPT.strActMthYearID & "','" & Others & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "WBWeighingInOutReport;1")

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            WBWeighingInOutFrm.StrFrmName = String.Empty


        ElseIf WBWeighingTicketReportFrm.StrFrmName = "WBTicketRpt" Then
            Dim WBTicketNo As String = WBWeighingTicketReportFrm.WBRicketNo
            Dim Others As String = WBWeighingTicketReportFrm.Others
            Dim rpt As New WeighBridgeTicket
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            cmd.CommandText = "Weighbridge.WBWeighingInOutReport '" & GlobalPPT.strEstateID & "','" & WBTicketNo & "','" & GlobalPPT.strActMthYearID & "','" & Others & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "WBWeighingInOutReport;1")

            rpt.SetDataSource(ds)
            'rpt.PrintOptions.Pri.PrintSettings.PrintMode = PrintMode.Scale;

            CrystalReportViewer1.ReportSource = rpt
            'CrystalReportViewer1.PrintSettings.PrintMode = PrintMode.Scale
            'report.PrintSettings.PagesOnSheet = PagesOnSheet.One
            'report.PrintSettings.PrintOnSheetHeight = 210
            '' paper height in millimeters 
            'report.PrintSettings.PrintOnSheetWidth = 148
            ' paper width in millimeters

            WBWeighingTicketReportFrm.StrFrmName = String.Empty

            'WB Daily Report 

        ElseIf DailyReportFrm.StrFrmName = "WBDailyReportbyProduct" Then
            Dim FromDate As Date = DailyReportFrm.FromDate
            Dim ToDate As Date = DailyReportFrm.ToDate
            Dim WBFromDate As String = Format(FromDate, "yyyy-MM-dd")
            Dim WBToDate As String = Format(ToDate, "yyyy-MM-dd")
            Dim rpt As New DailyReportbyProduct
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            Dim txtFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFromDate.Text = Format(FromDate, "dd/MM/yyyy")

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = Format(ToDate, "dd/MM/yyyy")

            Dim txtGTFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtGTFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtGTFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtGTFromDate.Text = Format(FromDate, "dd/MM/yyyy")

            Dim txtGTToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtGTToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtGTToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtGTToDate.Text = Format(ToDate, "dd/MM/yyyy")

            Dim txtEstate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstate.Text = strArray(1)


            cmd.CommandText = "Weighbridge.WBWeighingDailyReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & WBFromDate & "','" & WBToDate & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "WBWeighingDailyReport;1")

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ShowGroupTreeButton = True
            CrystalReportViewer1.ShowGroupTree()

            DailyReportFrm.StrFrmName = ""
        ElseIf DailyReportFrm.StrFrmName = "WBDailyReportbySupplier" Then
            Dim FromDate As Date = DailyReportFrm.FromDate
            Dim ToDate As Date = DailyReportFrm.ToDate
            Dim WBFromDate As String = Format(FromDate, "yyyy-MM-dd")
            Dim WBToDate As String = Format(ToDate, "yyyy-MM-dd")
            Dim rpt As New DailyReportbySupplier
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            Dim txtFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFromDate.Text = Format(FromDate, "dd/MM/yyyy")

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = Format(ToDate, "dd/MM/yyyy")

            Dim txtGTFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtGTFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtGTFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtGTFromDate.Text = Format(FromDate, "dd/MM/yyyy")

            Dim txtGTToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtGTToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtGTToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtGTToDate.Text = Format(ToDate, "dd/MM/yyyy")


            Dim txtEstate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstate.Text = strArray(1)


            cmd.CommandText = "Weighbridge.WBWeighingDailyReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & WBFromDate & "','" & WBToDate & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "WBWeighingDailyReport;1")

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ShowGroupTree()
            CrystalReportViewer1.ShowGroupTreeButton = True
            DailyReportFrm.StrFrmName = ""

        ElseIf DailyReportFrm.StrFrmName = "WBDailyReportbyVehicle" Then
            Dim FromDate As Date = DailyReportFrm.FromDate
            Dim ToDate As Date = DailyReportFrm.ToDate
            Dim WBFromDate As String = Format(FromDate, "yyyy-MM-dd")
            Dim WBToDate As String = Format(ToDate, "yyyy-MM-dd")
            Dim rpt As New DailyReportbyVehicle
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            Dim txtFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFromDate.Text = Format(FromDate, "dd/MM/yyyy")

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = Format(ToDate, "dd/MM/yyyy")

            Dim txtGTFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtGTFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtGTFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtGTFromDate.Text = Format(FromDate, "dd/MM/yyyy")

            Dim txtGTToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtGTToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtGTToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtGTToDate.Text = Format(ToDate, "dd/MM/yyyy")

            Dim txtEstate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstate.Text = strArray(1)


            cmd.CommandText = "Weighbridge.WBWeighingDailyReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & WBFromDate & "','" & WBToDate & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "WBWeighingDailyReport;1")

            rpt.SetDataSource(ds)


            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ShowGroupTree()
            CrystalReportViewer1.ShowGroupTreeButton = True
            DailyReportFrm.StrFrmName = ""
            'ElseIf Me.Name = "DispatchCPOandPKO" Then

            '    Dim xlApp As Excel.Application
            '    Dim xlWorkBook As Excel.Workbook
            '    Dim sheet As Excel.Worksheet
            '    Dim cCell As Excel.Range
            '    Dim cRow As Excel.Range
            '    Dim strServerUserName As String = String.Empty
            '    Dim strServerPassword As String = String.Empty
            '    Dim strDSN As String = String.Empty
            '    Dim StrInitialCatlog As String = String.Empty
            '    xlApp = New Excel.Application
            '    xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Dispatch_CPO_PKO_for_the_month.xls")
            '    xlApp.Visible = True
            '    sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)


            '    Dim intRowCount As Integer
            '    Dim intPKORowCount As Integer

            '    Dim con1 As New SqlConnection
            '    Dim cmd1 As New SqlCommand
            '    Dim da1 As New SqlDataAdapter


            '    strDSN = "" & ConfigurationManager.AppSettings.Item("oDataSource").ToString & ""
            '    strServerUserName = "" & ConfigurationManager.AppSettings.Item("oUserName").ToString & ""
            '    strServerPassword = "" & ConfigurationManager.AppSettings.Item("oPassword").ToString & ""
            '    StrInitialCatlog = "" & ConfigurationManager.AppSettings.Item("oDataBase").ToString & ""


            '      Dim constr1 As String = " Data Source=" & strDSN & "; Initial Catalog=" & StrInitialCatlog & ";User=" & strServerUserName & "; pwd=" & strServerPassword & ";Max Pool Size=100;Connection Timeout=60;"
            '    con1 = New SqlConnection(constr1)
            '    con1.Open()

            '    cmd1.Connection = con1
            '    cmd1.CommandText = "Production.DispatchCPOandPKOForMonth" ' '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & strSSTIssueID & "' "
            '    cmd1.CommandType = CommandType.StoredProcedure
            '    cmd1.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
            '    cmd1.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            '    cmd1.Parameters.AddWithValue("@Period", GlobalPPT.IntLoginMonth)
            '    cmd1.Parameters.AddWithValue("@FYear", GlobalPPT.intLoginYear)
            '    cmd1.Parameters.AddWithValue("@ToDate", System.DateTime.Today.AddDays(-1))
            '    cmd1.Parameters.AddWithValue("@ToDateYear", System.DateTime.Today.AddDays(-1))

            '    Dim ds As New DataSet
            '    Dim tblAdt As New Odbc.OdbcDataAdapter

            '    da1.SelectCommand = cmd1
            '    da1.Fill(ds, "Sample")

            '    If ds.Tables(0).Rows.Count > 0 Then
            '        sheet.Cells(13, 2) = ds.Tables(0).Rows(0).Item("CPOMillWeightMonth")
            '        sheet.Cells(19, 4) = ds.Tables(0).Rows(0).Item("CPOMillWeightMonth")
            '    End If
            '    If ds.Tables(1).Rows.Count > 0 Then
            '        sheet.Cells(13, 3) = ds.Tables(1).Rows(0).Item("CPOMillWeightYear")
            '        sheet.Cells(19, 5) = ds.Tables(1).Rows(0).Item("CPOMillWeightYear")
            '    End If
            '    If ds.Tables(2).Rows.Count > 0 Then
            '        sheet.Cells(14, 2) = ds.Tables(2).Rows(0).Item("PKOMillWeightMonth")
            '        sheet.Cells(20, 4) = ds.Tables(2).Rows(0).Item("PKOMillWeightMonth")
            '    End If
            '    If ds.Tables(3).Rows.Count > 0 Then
            '        sheet.Cells(14, 3) = ds.Tables(3).Rows(0).Item("PKOMillWeightYear")
            '        sheet.Cells(20, 5) = ds.Tables(3).Rows(0).Item("PKOMillWeightYear")
            '    End If



            '    If ds.Tables(6).Rows.Count > 0 And ds.Tables(7).Rows.Count > 0 Then
            '        sheet.Cells(19, 1) = ds.Tables(6).Rows(0).Item("CropYieldCode")
            '        sheet.Cells(19, 2) = ds.Tables(6).Rows(0).Item("QtyMonthToDate")
            '        sheet.Cells(19, 3) = ds.Tables(6).Rows(0).Item("QtyYearToDate")
            '        sheet.Cells(19, 6) = (ds.Tables(6).Rows(0).Item("QtyMonthToDate") - ds.Tables(0).Rows(0).Item("CPOMillWeightMonth"))
            '        sheet.Cells(19, 7) = (ds.Tables(6).Rows(0).Item("QtyYearToDate") - ds.Tables(1).Rows(0).Item("CPOMillWeightYear"))
            '        sheet.Cells(20, 1) = ds.Tables(7).Rows(0).Item("CropYieldCode")
            '        sheet.Cells(20, 2) = ds.Tables(7).Rows(0).Item("QtyMonthToDate")
            '        sheet.Cells(20, 3) = ds.Tables(7).Rows(0).Item("QtyYearToDate")
            '        sheet.Cells(20, 6) = (ds.Tables(7).Rows(0).Item("QtyMonthToDate") - ds.Tables(2).Rows(0).Item("PKOMillWeightMonth"))
            '        sheet.Cells(20, 7) = (ds.Tables(7).Rows(0).Item("QtyYearToDate") - ds.Tables(3).Rows(0).Item("PKOMillWeightYear"))
            '    End If

            '    intRowCount = ds.Tables(4).Rows.Count
            '    Dim intRow As Integer = 25
            '    Dim i As Integer = 0
            '    If intRowCount > 0 Then
            '        While intRowCount > 0
            '            sheet.Cells(intRow, 1) = ds.Tables(4).Rows(i).Item("DispatchDate")
            '            sheet.Cells(intRow, 2) = ds.Tables(4).Rows(i).Item("ProductCode")
            '            sheet.Cells(intRow, 3) = ds.Tables(4).Rows(i).Item("ShipPontoon")
            '            sheet.Cells(intRow, 4) = ds.Tables(4).Rows(i).Item("DOA")
            '            sheet.Cells(intRow, 5) = ds.Tables(4).Rows(i).Item("DCL")
            '            sheet.Cells(intRow, 6) = ds.Tables(4).Rows(i).Item("DepartureDate")
            '            sheet.Cells(intRow, 7) = ds.Tables(4).Rows(i).Item("MillWeight")
            '            sheet.Cells(intRow, 8) = ds.Tables(4).Rows(i).Item("LoadingLocationCode")
            '            sheet.Cells(intRow, 9) = ds.Tables(4).Rows(i).Item("BAPNo")
            '            intRowCount = intRowCount - 1
            '            intRow = intRow + 1
            '            i = i + 1

            '        End While
            '    End If


            '    Dim intPKORow As Integer = intRow
            '    Dim j As Integer = 0
            '    Dim lEstate As String
            '    Dim lDate As String
            '    Dim lMonth As String
            '    Dim lYear As String

            '    If ds.Tables(8).Rows.Count > 0 Then
            '        lDate = Format(System.DateTime.Now, "dd/MM/yyyy")
            '        lEstate = ds.Tables(8).Rows(0).Item("EstateName")
            '        lMonth = ds.Tables(8).Rows(0).Item("Amonth")
            '        lYear = ds.Tables(8).Rows(0).Item("AYear")
            '        Dim objCommonBOl As New GlobalBOL
            '        lMonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            '        sheet.Cells(5, 1) = "Estate/Mill :" & lEstate & " "
            '        sheet.Cells(3, 7) = "Date :" & lDate & " "
            '        sheet.Cells(8, 1) = "Dispatch - CPO and PKO for the Month of " & lMonth & " " '& lYear & " "
            '    End If

            '    intPKORowCount = ds.Tables(5).Rows.Count
            '    If intPKORowCount > 0 Then
            '        While intPKORowCount > 0
            '            sheet.Cells(intPKORow, 1) = ds.Tables(5).Rows(j).Item("DispatchDate")
            '            sheet.Cells(intPKORow, 2) = ds.Tables(5).Rows(j).Item("ProductCode")
            '            sheet.Cells(intPKORow, 3) = ds.Tables(5).Rows(j).Item("ShipPontoon")
            '            sheet.Cells(intPKORow, 4) = ds.Tables(5).Rows(j).Item("DOA")
            '            sheet.Cells(intPKORow, 5) = ds.Tables(5).Rows(j).Item("DCL")
            '            sheet.Cells(intPKORow, 6) = ds.Tables(5).Rows(j).Item("DepartureDate")
            '            sheet.Cells(intPKORow, 7) = ds.Tables(5).Rows(j).Item("MillWeight")
            '            sheet.Cells(intPKORow, 8) = ds.Tables(5).Rows(j).Item("LoadingLocationCode")
            '            sheet.Cells(intPKORow, 9) = ds.Tables(5).Rows(j).Item("BAPNo")
            '            intPKORowCount = intPKORowCount - 1
            '            intPKORow = intPKORow + 1
            '            j = j + 1
            '        End While
            '    End If

            '    ''Production Proof List starts here
            '    'ElseIf GradingFFBfrm.StrFrmName = "Grading FFB" Then
            '    '    Dim rpt As New GradingFFBReport
            '    '    Dim tblAdt As New Odbc.OdbcDataAdapter
            '    '    Dim ds As New DataSet
            '    '    cmd.Connection = con

            '    '    Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            '    '    txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '    '    txtPrintedby.Text = GlobalPPT.strUserName

            '    '    cmd.CommandText = "Production.GradingFFBReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            '    '    cmd.CommandType = CommandType.StoredProcedure
            '    '    tblAdt.SelectCommand = cmd
            '    '    tblAdt.Fill(ds, "GradingFFBReport;1")
            '    '    Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            '    '    txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '    '    Dim objCommonBOl As New GlobalBOL
            '    '    Dim lTextmonth As String = String.Empty
            '    '    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            '    '    txtMonthYear.Text = "GradingFFB Proof List " & lTextmonth & ""

            '    '    rpt.SetDataSource(ds)
            '    '    CrystalReportViewer1.ReportSource = rpt

            '    'ElseIf DispatchFrm.StrFrmName = "Dispatch" Then
            '    '    Dim rpt As New DispatchRpt
            '    '    Dim tblAdt As New Odbc.OdbcDataAdapter
            '    '    Dim ds As New DataSet
            '    '    cmd.Connection = con

            '    '    Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            '    '    txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '    '    txtPrintedby.Text = GlobalPPT.strUserName

            '    '    cmd.CommandText = "Production.DispatchRpt '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            '    '    cmd.CommandType = CommandType.StoredProcedure
            '    '    tblAdt.SelectCommand = cmd
            '    '    tblAdt.Fill(ds, "DispatchRpt;1")
            '    '    rpt.SetDataSource(ds)
            '    '    Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            '    '    txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '    '    Dim objCommonBOl As New GlobalBOL
            '    '    Dim lTextmonth As String = String.Empty
            '    '    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            '    '    txtMonthYear.Text = "Dispatch Proof List " & lTextmonth & ""

            '    '    CrystalReportViewer1.ReportSource = rpt

        ElseIf DailyReportFrm.StrFrmName = "WBDailyReportbyTicketNo" Then
            Dim FromDate As Date = DailyReportFrm.FromDate
            Dim ToDate As Date = DailyReportFrm.ToDate
            Dim WBFromDate As String = Format(FromDate, "yyyy-MM-dd")
            Dim WBToDate As String = Format(ToDate, "yyyy-MM-dd")
            Dim rpt As New DailyReportbyTicketNo
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            Dim txtFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFromDate.Text = Format(FromDate, "dd/MM/yyyy")

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = Format(ToDate, "dd/MM/yyyy")

            'Dim txtGTFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            'txtGTFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtGTFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'txtGTFromDate.Text = Format(FromDate, "dd/MM/yyyy")

            'Dim txtGTToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            'txtGTToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtGTToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'txtGTToDate.Text = Format(ToDate, "dd/MM/yyyy")

            Dim txtEstate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstate.Text = strArray(1)


            cmd.CommandText = "Weighbridge.WBWeighingDailyReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & WBFromDate & "','" & WBToDate & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "WBWeighingDailyReport;1")

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            DailyReportFrm.StrFrmName = ""
        ElseIf WBCropReport.StrFrmName = "WBFieldBlockDailyReport" Then
            Dim FromDate As Date = WBCropReport.FromDate
            Dim ToDate As Date = WBCropReport.ToDate
            Dim WBFromDate As String = Format(FromDate, "yyyy-MM-dd")
            Dim WBToDate As String = Format(ToDate, "yyyy-MM-dd")
            Dim rpt As New WBBlockandField
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strUserName

            Dim txtFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFromDate.Text = Format(FromDate, "dd/MM/yyyy")

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = Format(ToDate, "dd/MM/yyyy")

            Dim txtGTFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtGTFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtGTFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtGTFromDate.Text = Format(FromDate, "dd/MM/yyyy")

            Dim txtGTToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtGTToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtGTToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtGTToDate.Text = Format(ToDate, "dd/MM/yyyy")


            Dim txtEstate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstate.Text = strArray(1)


            cmd.CommandText = "Weighbridge.WBFieldBlockDailyReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & WBFromDate & "','" & WBToDate & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "WBFieldBlockDailyReport;1")

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ShowGroupTreeButton = True
            DailyReportFrm.StrFrmName = ""

        ElseIf PettyCashReceiptFrm.StrFrmName = "PCR" Then
            Dim rpt As New PettyCashReceiptReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strDisplayName

            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)

            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "PETTY CASH RECEIPT PROOF LIST " & lTextmonth & ""

            'Dim txtEstate As CrystalDecisions.CrystalReports.Engine.TextObject
            'txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'txtEstate.Text = GlobalPPT.strEstateName

            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)

            Dim txtFrmDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFrmDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFrmDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFrmDate.Text = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")

            cmd.CommandText = "Accounts.PettyCashReceiptReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "PettyCashReceiptReport;1")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt

        ElseIf ReturnGoodsNoteFrm.StrFrmName = "RGNReport" Then

            Dim rpt As New RGNReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet

            cmd.Connection = con

            'Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            'txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'txtPrintedby.Text = GlobalPPT.strUserName
            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strDisplayName

            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)


            Dim txtFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFromDate.Text = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")



            cmd.CommandText = "Store.RGNReport1 '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "RGNReport1;1")

            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(rpt.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)

            Dim objCommonBOl As New GlobalBOL
            Dim lTextmonth As String = String.Empty
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "RETURN GOODS NOTE PRROF LIST " & lTextmonth & ""

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt

        ElseIf Me.Name = "DispatchCPOandPKO" Then
            Dim strMonthlyProdRptName As String = String.Empty
            Dim strFullMonthName As String = String.Empty
            Dim objGlobalBOL As New GlobalBOL
            strFullMonthName = objGlobalBOL.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

            strMonthlyProdRptName = "Dispatch - CPO and PKO for the Month " & strFullMonthName & ""

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim sheet As Excel.Worksheet
            Dim strServerUserName As String = String.Empty
            Dim strServerPassword As String = String.Empty
            Dim strDSN As String = String.Empty
            Dim StrInitialCatlog As String = String.Empty
            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(Application.StartupPath & "\Reports\Production\Excel\Dispatch_CPO_PKO_for_the_month.xls")
            xlApp.Visible = True
            sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)


            Dim intRowCount As Integer
            Dim intPKORowCount As Integer

            Dim con1 As New SqlConnection
            Dim cmd1 As New SqlCommand
            Dim da1 As New SqlDataAdapter


            strDSN = GlobalPPT.SelectedDB.DSN
            strServerUserName = GlobalPPT.SelectedDB.User
            strServerPassword = GlobalPPT.SelectedDB.Password
            StrInitialCatlog = GlobalPPT.SelectedDB.DBName

            Dim constr1 As String = " Data Source=" & strDSN & "; Initial Catalog=" & StrInitialCatlog & ";User=" & strServerUserName & "; pwd=" & strServerPassword & ";Max Pool Size=100;Connection Timeout=60;"
            con1 = New SqlConnection(constr1)
            con1.Open()

            cmd1.Connection = con1
            cmd1.CommandText = "Production.DispatchCPOandPKOForMonth" ' '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & strSSTIssueID & "' "
            cmd1.CommandType = CommandType.StoredProcedure
            cmd1.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
            cmd1.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            cmd1.Parameters.AddWithValue("@Period", GlobalPPT.IntLoginMonth)
            cmd1.Parameters.AddWithValue("@FYear", GlobalPPT.intLoginYear)
            cmd1.Parameters.AddWithValue("@ToDate", System.DateTime.Today.AddDays(-1))
            cmd1.Parameters.AddWithValue("@ToDateYear", System.DateTime.Today.AddDays(-1))

            Dim ds As New DataSet
            Dim tblAdt As New Odbc.OdbcDataAdapter

            da1.SelectCommand = cmd1
            da1.Fill(ds, "Sample")

            If ds.Tables(0).Rows.Count > 0 Then
                sheet.Cells(13, 2) = ds.Tables(0).Rows(0).Item("CPOMillWeightMonth")
                sheet.Cells(19, 4) = ds.Tables(0).Rows(0).Item("CPOMillWeightMonth")
            End If
            If ds.Tables(1).Rows.Count > 0 Then
                sheet.Cells(13, 3) = ds.Tables(1).Rows(0).Item("CPOMillWeightYear")
                sheet.Cells(19, 5) = ds.Tables(1).Rows(0).Item("CPOMillWeightYear")
            End If
            If ds.Tables(2).Rows.Count > 0 Then
                sheet.Cells(14, 2) = ds.Tables(2).Rows(0).Item("PKOMillWeightMonth")
                sheet.Cells(20, 4) = ds.Tables(2).Rows(0).Item("PKOMillWeightMonth")
            End If
            If ds.Tables(3).Rows.Count > 0 Then
                sheet.Cells(14, 3) = ds.Tables(3).Rows(0).Item("PKOMillWeightYear")
                sheet.Cells(20, 5) = ds.Tables(3).Rows(0).Item("PKOMillWeightYear")
            End If



            If ds.Tables(6).Rows.Count > 0 And ds.Tables(7).Rows.Count > 0 Then
                sheet.Cells(19, 1) = ds.Tables(6).Rows(0).Item("CropYieldCode")
                sheet.Cells(19, 2) = ds.Tables(6).Rows(0).Item("QtyMonthToDate")
                sheet.Cells(19, 3) = ds.Tables(6).Rows(0).Item("QtyYearToDate")
                sheet.Cells(19, 6) = (ds.Tables(6).Rows(0).Item("QtyMonthToDate") - ds.Tables(0).Rows(0).Item("CPOMillWeightMonth"))
                sheet.Cells(19, 7) = (ds.Tables(6).Rows(0).Item("QtyYearToDate") - ds.Tables(1).Rows(0).Item("CPOMillWeightYear"))
                sheet.Cells(20, 1) = ds.Tables(7).Rows(0).Item("CropYieldCode")
                sheet.Cells(20, 2) = ds.Tables(7).Rows(0).Item("QtyMonthToDate")
                sheet.Cells(20, 3) = ds.Tables(7).Rows(0).Item("QtyYearToDate")
                sheet.Cells(20, 6) = (ds.Tables(7).Rows(0).Item("QtyMonthToDate") - ds.Tables(2).Rows(0).Item("PKOMillWeightMonth"))
                sheet.Cells(20, 7) = (ds.Tables(7).Rows(0).Item("QtyYearToDate") - ds.Tables(3).Rows(0).Item("PKOMillWeightYear"))
            End If

            intRowCount = ds.Tables(4).Rows.Count
            Dim intRow As Integer = 25
            Dim i As Integer = 0
            If intRowCount > 0 Then
                While intRowCount > 0

                    sheet.Cells(intRow, 1).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intRow, 1) = ds.Tables(4).Rows(i).Item("DispatchDate")

                    sheet.Cells(intRow, 2).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intRow, 2) = ds.Tables(4).Rows(i).Item("ProductCode")

                    sheet.Cells(intRow, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intRow, 3) = ds.Tables(4).Rows(i).Item("ShipPontoon")

                    sheet.Cells(intRow, 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intRow, 4) = ds.Tables(4).Rows(i).Item("DOA")

                    sheet.Cells(intRow, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intRow, 5) = ds.Tables(4).Rows(i).Item("DCL")

                    sheet.Cells(intRow, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intRow, 6) = ds.Tables(4).Rows(i).Item("DepartureDate")

                    sheet.Cells(intRow, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intRow, 7) = ds.Tables(4).Rows(i).Item("MillWeight")

                    sheet.Cells(intRow, 8).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intRow, 8) = ds.Tables(4).Rows(i).Item("LoadingLocationCode")

                    sheet.Cells(intRow, 9).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intRow, 9) = ds.Tables(4).Rows(i).Item("BAPNo")
                    intRowCount = intRowCount - 1
                    intRow = intRow + 1
                    i = i + 1

                End While
            End If


            Dim intPKORow As Integer = intRow
            Dim j As Integer = 0
            Dim lEstate As String
            Dim lDate As String
            Dim lMonth As String
            Dim lYear As String

            If ds.Tables(8).Rows.Count > 0 Then
                lDate = Format(System.DateTime.Now, "dd/MM/yyyy")
                lEstate = ds.Tables(8).Rows(0).Item("EstateName")
                lMonth = ds.Tables(8).Rows(0).Item("Amonth")
                lYear = ds.Tables(8).Rows(0).Item("AYear")
                Dim objCommonBOl As New GlobalBOL
                lMonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                sheet.Cells(5, 1) = "Estate/Mill :" & lEstate & " "
                sheet.Cells(3, 7) = "Date :" & lDate & " "
                sheet.Cells(8, 1) = "Dispatch - CPO and PKO for the Month of " & lMonth & " " '& lYear & " "
            End If

            intPKORowCount = ds.Tables(5).Rows.Count
            If intPKORowCount > 0 Then
                While intPKORowCount > 0

                    'sheet.Cells(int3rdTableStarCount, 4).VerticalAlignment = Excel.Constants.xlTop
                    'sheet.Cells(int3rdTableStarCount, 4).HorizontalAlignment = Excel.Constants.xlLeft
                    sheet.Cells(intPKORow, 1).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 1).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 1).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intPKORow, 1) = ds.Tables(5).Rows(j).Item("DispatchDate")

                    sheet.Cells(intPKORow, 2).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 2).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 2).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 2).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous


                    sheet.Cells(intPKORow, 2) = ds.Tables(5).Rows(j).Item("ProductCode")



                    sheet.Cells(intPKORow, 3).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 3).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 3).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 3).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous


                    sheet.Cells(intPKORow, 3) = ds.Tables(5).Rows(j).Item("ShipPontoon")




                    sheet.Cells(intPKORow, 4).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 4).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 4).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 4).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intPKORow, 4) = ds.Tables(5).Rows(j).Item("DOA")



                    sheet.Cells(intPKORow, 5).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 5).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 5).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 5).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous


                    sheet.Cells(intPKORow, 5) = ds.Tables(5).Rows(j).Item("DCL")


                    sheet.Cells(intPKORow, 6).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 6).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 6).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 6).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous


                    sheet.Cells(intPKORow, 6) = ds.Tables(5).Rows(j).Item("DepartureDate")




                    sheet.Cells(intPKORow, 7).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 7).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 7).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 7).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intPKORow, 7) = ds.Tables(5).Rows(j).Item("MillWeight")


                    sheet.Cells(intPKORow, 8).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 8).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 8).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 8).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intPKORow, 8) = ds.Tables(5).Rows(j).Item("LoadingLocationCode")


                    sheet.Cells(intPKORow, 9).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 9).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 9).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(intPKORow, 9).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                    sheet.Cells(intPKORow, 9) = ds.Tables(5).Rows(j).Item("BAPNo")

                    intPKORowCount = intPKORowCount - 1
                    intPKORow = intPKORow + 1
                    j = j + 1

                End While

            End If
            Dim StrPath As String = Application.StartupPath & "\Reports\Production\Excel\" & strMonthlyProdRptName & ".xls"
            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If
        End If




    End Sub


End Class