Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration


Public Class DailyCostingReportView

    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty
    Public Yop As String
    Public FieldNo As String


    Private Sub PettyCashPaymentReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'strDSN = "" & ConfigurationManager.AppSettings.Item("oDSN").ToString & ""
        'strServerUserName = "" & ConfigurationManager.AppSettings.Item("oUserName").ToString & ""
        'strServerPassword = "" & ConfigurationManager.AppSettings.Item("oPassword").ToString & ""



        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password


        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"

        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        'Dim rpt As New DailyCostingRpt
        'Dim tblAdt As New Odbc.OdbcDataAdapter

        'Dim ds As New DataSet

        'cmd.Connection = con

        'cmd.CommandText = "checkRoll.CRDailyCostingByKHTKHLReport '" & GlobalPPT.strEstateID & "','" & DailyCostingRpt.startDate & "','" & DailyCostingRpt.EndDate & "'"
        'cmd.CommandType = CommandType.StoredProcedure
        'tblAdt.SelectCommand = cmd
        'tblAdt.Fill(ds, "CRDailyCostingByKHTKHLReport;1")

        'Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
        'txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'Dim strArray As String()
        'strArray = GlobalPPT.strEstateName.Split("-")
        'txtEstateName.Text = strArray(1)

        ''Dim txtFromToDate As CrystalDecisions.CrystalReports.Engine.TextObject
        ''txtEstateName = CType(rpt.ReportDefinitio.ReportObjects.Item("txtFromToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ''txtFromToDate.Text = "Daily Costing Report From " & Format(DailyCostingRpt.startDate, "dd/MM/yyyy") & " To " & Format(DailyCostingRpt.EndDate, "dd/MM/yyyy") & ""
        ''rpt.SetDataSource(ds)
        'CrystalReportViewer1.ReportSource = rpt
        Dim rpt
        If Me.Tag = "YOP" Then
            rpt = New CRDailyCostingByKHTKHLReport
        Else
            rpt = New CRDailyCostingByKHTKHLReport
        End If
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet
        cmd.Connection = con

        Dim txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName


        Dim objCommonBOl As New GlobalBOL
        Dim lTextmonth As String = String.Empty
        lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)

        Dim txtFromToDate, txtPeriode As CrystalDecisions.CrystalReports.Engine.TextObject
        txtFromToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromToDate.Text = "DAILY COSTING REPORT " & lTextmonth & ""

        txtPeriode = CType(rpt.ReportDefinition.ReportObjects.Item("txtPeriode"), CrystalDecisions.CrystalReports.Engine.TextObject)

        If Me.Tag = "YOP" Then
            cmd.CommandText = "checkRoll.CRDailyCostingByYOPorField '" & GlobalPPT.strEstateID & "','" & DailyCostingRptByYop.startDate.ToString("yyyy-MM-dd") & "','" & DailyCostingRptByYop.EndDate.ToString("yyyy-MM-dd") & "','" & GlobalPPT.strActMthYearID & "','" & GlobalPPT.IntActiveMonth & "','" & GlobalPPT.intActiveYear & "','" & Yop & "','" & FieldNo & "'"
            txtPeriode.Text = "Period: " & Format(DailyCostingRptByYop.startDate, "dd/MM/yyyy") & " to " & Format(DailyCostingRptByYop.EndDate, "dd/MM/yyyy") & ""
            txtFromToDate.Text = "DAILY COSTING REPORT BY YOP/FIELD " & lTextmonth & ""
        Else
            cmd.CommandText = "checkRoll.CRDailyCostingByKHTKHLReport '" & GlobalPPT.strEstateID & "','" & DailyCostingRpt.startDate.ToString("yyyy-MM-dd") & "','" & DailyCostingRpt.EndDate.ToString("yyyy-MM-dd") & "','" & GlobalPPT.strActMthYearID & "','" & GlobalPPT.IntActiveMonth & "','" & GlobalPPT.intActiveYear & "','" & "" & "'"
            txtPeriode.Text = "Period: " & Format(DailyCostingRpt.startDate, "dd/MM/yyyy") & " to " & Format(DailyCostingRpt.EndDate, "dd/MM/yyyy") & ""
            txtFromToDate.Text = "DAILY COSTING REPORT " & lTextmonth & ""
        End If
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "CRDailyCostingByKHTKHLReport;1")

       ' txtMonthYear.Text = "PURCHASE REQUISITION PROOF LIST " & lTextmonth & ""


   
         Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
        txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        txtEstateName.Text = strArray(1)

        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt

    End Sub


End Class