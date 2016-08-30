Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports System.Math

Public Class StoreLedgerSummaryReportView

    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty

    Private Sub StoreLedgerSummaryReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim _GlobalBOL As New GlobalBOL

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"

        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim cmd1 As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()


        'If StockIssueInterfaceFrm.StrFrmName = "StockIssue" Then


        Dim rpt As New StoreLedgerSummaryReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim tblAdt1 As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet
        Dim ds1 As New DataSet
        cmd.Connection = con

        cmd.CommandText = "Accounts.LedgerSummaryReoprt '" & GlobalPPT.strEstateID & "','" & StoreLedgerSummaryFrm.IntYear & "','" & StoreLedgerSummaryFrm.Intmonth & "' ,'" & StoreLedgerSummaryFrm.modid & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        Cursor = Cursors.WaitCursor
        tblAdt.Fill(ds, "LedgerSummaryReoprt;1")

        Dim txtTotalReceiptDebit As CrystalDecisions.CrystalReports.Engine.TextObject
        txtTotalReceiptDebit = CType(rpt.ReportDefinition.ReportObjects.Item("txtTotalReceiptDebit"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtTotalReceiptDebit.Text = ds.Tables(0).Rows(0).Item("Total Receipt Debit")

        Dim txtTotalReceiptCredit As CrystalDecisions.CrystalReports.Engine.TextObject
        txtTotalReceiptCredit = CType(rpt.ReportDefinition.ReportObjects.Item("txtTotalReceiptCredit"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtTotalReceiptCredit.Text = ds.Tables(1).Rows(0).Item("Total Receipt Credit")

        Dim txtTotalIssuesDebit As CrystalDecisions.CrystalReports.Engine.TextObject
        txtTotalIssuesDebit = CType(rpt.ReportDefinition.ReportObjects.Item("txtTotalIssuesDebit"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtTotalIssuesDebit.Text = ds.Tables(2).Rows(0).Item("Total Issues Debit")

        Dim txtTotalIssuesCredit As CrystalDecisions.CrystalReports.Engine.TextObject
        txtTotalIssuesCredit = CType(rpt.ReportDefinition.ReportObjects.Item("txtTotalIssuesCredit"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtTotalIssuesCredit.Text = ds.Tables(3).Rows(0).Item("Total Issues Credit")

        Dim TotalDebit As CrystalDecisions.CrystalReports.Engine.TextObject
        TotalDebit = CType(rpt.ReportDefinition.ReportObjects.Item("txtTotalDebit"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'TotalDebit.Text = Convert.ToInt32(ds.Tables(0).Rows(0).Item("Total Receipt Debit")) + Convert.ToInt32(ds.Tables(2).Rows(0).Item("Total Issues Debit"))
        TotalDebit.Text = Convert.ToDouble(ds.Tables(0).Rows(0).Item("Total Receipt Debit")) + Convert.ToDouble(ds.Tables(2).Rows(0).Item("Total Issues Debit"))

        Dim txtTotalCredit As CrystalDecisions.CrystalReports.Engine.TextObject
        txtTotalCredit = CType(rpt.ReportDefinition.ReportObjects.Item("txtTotalCredit"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'txtTotalCredit.Text = Convert.ToInt32(ds.Tables(1).Rows(0).Item("Total Receipt Credit")) + Convert.ToInt32(ds.Tables(3).Rows(0).Item("Total Issues Credit"))
        txtTotalCredit.Text = Convert.ToDouble(ds.Tables(1).Rows(0).Item("Total Receipt Credit")) + Convert.ToDouble(ds.Tables(3).Rows(0).Item("Total Issues Credit"))

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
        'txtFromDate.Text = Format(StoreLedgerSummaryFrm.strFiscalYearFromDate, "dd/MM/yyyy") 

        Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate.Text = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
        'txtToDate.Text = Format(StoreLedgerSummaryFrm.strFiscalYearToDate, "dd/MM/yyyy")

        Dim txtTitle As CrystalDecisions.CrystalReports.Engine.TextObject
        txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtTitle.Text = "STOCK LEDGER SUMMARY " + _GlobalBOL.PMonthName(StoreLedgerSummaryFrm.Intmonth, StoreLedgerSummaryFrm.IntYear, GlobalPPT.strLang)


        If ds.Tables(0).Rows.Count > 0 Then
            '
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            Cursor = Cursors.Default
            '
        Else
            'MessageBox.Show("There is no record for the login month")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
        End If

        'End If

    End Sub

End Class