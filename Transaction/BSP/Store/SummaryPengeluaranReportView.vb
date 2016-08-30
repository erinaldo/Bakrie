Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports System.Math

Public Class SummaryPengeluaranReportView


    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty
    Public stDate As String = String.Empty
    Public endDate As String = String.Empty
    Private Sub SummaryPengeluaranReportView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim _GlobalBOL As New GlobalBOL

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"

        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New SummaryPengeluaran
        Dim tblAdt As New Odbc.OdbcDataAdapter

        Dim ds As New DataSet

        cmd.Connection = con
        If SummaryPengeluaranReportInterfaceFrm.StrFrmName = "SummaryPen" Then


            cmd.CommandText = "Store.SummaryPengeluaranReport '" & GlobalPPT.strEstateID & "','" & SummaryPengeluaranReportInterfaceFrm.strAmonth & "','" & SummaryPengeluaranReportInterfaceFrm.strAYear & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "SummaryPengeluaranReport;1")


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
            txtTitle.Text = "SUMMARY PENGELUARAN " + _GlobalBOL.PMonthName(SummaryPengeluaranReportInterfaceFrm.strAmonth, SummaryPengeluaranReportInterfaceFrm.strAYear, GlobalPPT.strLang)


            If ds.Tables(0).Rows.Count > 0 Then
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt
            Else
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt
                'Me.Close()
            End If

        End If

    End Sub

End Class