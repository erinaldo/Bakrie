Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports System.Math

Public Class StoreStockIssueReportView


    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty
    Public stDate As String = String.Empty
    Public endDate As String = String.Empty

    Private Sub StoreStockIssueReportView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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


        If StockIssueInterfaceFrm.StrFrmName = "StockIssue" Then


            Dim rpt As New StockIssueReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim tblAdt1 As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            Dim ds1 As New DataSet
            cmd.Connection = con

            cmd.CommandText = "Store.StockIssueReport '" & GlobalPPT.strEstateID & "','" & StockIssueInterfaceFrm.strAmonth & "','" & StockIssueInterfaceFrm.strAYear & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            Cursor = Cursors.WaitCursor
            tblAdt.Fill(ds, "StockIssueReport;1")

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
            'txtFromDate.Text = Format(GlobalPPT.FiscalYearFromDate, "dd/MM/yyyy")
            txtFromDate.Text = stDate

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'txtToDate.Text = Format(GlobalPPT.FiscalYearToDate, "dd/MM/yyyy")
            txtToDate.Text = endDate

            Dim txtTitle As CrystalDecisions.CrystalReports.Engine.TextObject
            txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtTitle.Text = "STOCK ISSUE " + _GlobalBOL.PMonthName(StockIssueInterfaceFrm.strAmonth, StockIssueInterfaceFrm.strAYear, GlobalPPT.strLang)


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

        End If
    End Sub

End Class