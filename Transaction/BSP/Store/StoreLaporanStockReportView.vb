Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports System.Math

Public Class StoreLaporanStockReportView


    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty
    Public stDate As String = String.Empty
    Public endDate As String = String.Empty
    Private Sub StoreLaporanStockReportView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"

        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        'Dim cmd1 As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()


        Dim rpt As New LaporanStock
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim tblAdt1 As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet
        'Dim ds1 As New DataSet
        cmd.Connection = con
        'cmd1.Connection = con

        If LaporanStockReportInterface.StrFrmName = "Laporanstock" Then

            cmd.CommandText = "Store.LaporanStockReport '" & GlobalPPT.strEstateID & "','" & LaporanStockReportInterface.strAmonth & "','" & LaporanStockReportInterface.strAYear & "','" & LaporanStockReportInterface.strIsZero & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "LaporanStockReport;1")

            'cmd1.CommandText = "Store.LaporanStockReportGT '" & GlobalPPT.strEstateID & "','" & LaporanStockReportInterface.strAmonth & "','" & LaporanStockReportInterface.strAYear & "'"
            'cmd1.CommandType = CommandType.StoredProcedure
            'tblAdt.SelectCommand = cmd1
            'tblAdt.Fill(ds1, "LSGT")

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
            txtFromDate.Text = stDate

            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = endDate

            Dim _GlobalBOL As New GlobalBOL
            Dim txtTitle As CrystalDecisions.CrystalReports.Engine.TextObject
            txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtTitle.Text = "LAPORAN STOCK " & _GlobalBOL.PMonthName(LaporanStockReportInterface.strAmonth, LaporanStockReportInterface.strAYear, GlobalPPT.strLang)


            If ds.Tables(0).Rows.Count > 0 Then

                rpt.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt

            Else

                rpt.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt

            End If





        End If

    End Sub

End Class