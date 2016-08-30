Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports CheckRoll_BOL
Imports CheckRoll_PPT
Imports CheckRoll_DAL
Imports System.Configuration
Imports System.Globalization

Public Class DistribusiViewSummaryReport
    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty



    Private Sub DistribusiViewSummaryReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password


        If DistribusiCheckrollSummaryReport.chkReport = 1 Then
            GetDistribusiCheckrollHARVLAINReportForPANENLAIN()
        End If

        If DistribusiCheckrollSummaryReport.chkReport = 2 Then
            GetDistribusiCheckrollHARVLAINReportForLAINLAIN()
        End If

        If DistribusiCheckrollSummaryReport.chkReport = 3 Then
            GetDistribusiCheckrollHARVReport()
        End If
    End Sub


    Private Sub GetDistribusiCheckrollHARVLAINReportForPANENLAIN()
        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New DistribusiCheckrollHARVLAINSummaryReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds, dsFiscal, dsSubReport As New DataSet
        cmd.Connection = con

        Dim txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName
      
        Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
        Dim dtFrom As Date = DateTime.Parse(DistribusiCheckrollSummaryReport.strFiscalYearFromDate, culture, DateTimeStyles.NoCurrentDateDefault)
        Dim dtTo As Date = DateTime.Parse(DistribusiCheckrollSummaryReport.strFiscalYearToDate, culture, DateTimeStyles.NoCurrentDateDefault)
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "checkRoll.DistribusiCheckrollHARVLAINSummaryReport ?, ?, ?, ?"
        '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & dtFrom.Date & "','" & dtTo.Date & "'"
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        cmd.Parameters.AddWithValue("@FromDT", dtFrom.Date)
        cmd.Parameters.AddWithValue("@ToDT", dtTo.Date)

        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "DistribusiCheckrollHARVLAINSummaryReport;1")

        Dim objCommonBOl As New GlobalBOL
        Dim lTextmonth As String = String.Empty
        lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)


        Dim txtHeader As CrystalDecisions.CrystalReports.Engine.TextObject
        txtHeader = CType(rpt.ReportDefinition.ReportObjects.Item("txtHeader"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtHeader.Text = "DISTRIBUSI CHECKROLL REPORT " & lTextmonth & ""

        'txtPeriode = CType(rpt.ReportDefinition.ReportObjects.Item("txtPeriode"), CrystalDecisions.CrystalReports.Engine.TextObject)

        '  txtPeriode.Text = "Period: " & Format(DailyCostingRpt.startDate, "dd/MM/yyyy") & " to " & Format(DailyCostingRpt.EndDate, "dd/MM/yyyy") & ""

        Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
        txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        txtEstateName.Text = strArray(1)



        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField4 As New CrystalDecisions.Shared.ParameterField


        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue4 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue5 As New CrystalDecisions.Shared.ParameterDiscreteValue


        ParamterField1.ParameterFieldName = "@EstateID"
        ParamterDescreteValue2.Value = GlobalPPT.strEstateID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue3.Value = GlobalPPT.strActMthYearID
        ParamterField2.CurrentValues.Add(ParamterDescreteValue3)
        ParamterFields.Add(ParamterField2)

        ParamterField3.ParameterFieldName = "@FromDT"
        ParamterDescreteValue4.Value = DistribusiCheckrollSummaryReport.strFiscalYearFromDate
        ParamterField3.CurrentValues.Add(ParamterDescreteValue4)
        ParamterFields.Add(ParamterField3)

        ParamterField4.ParameterFieldName = "@ToDT"
        ParamterDescreteValue5.Value = DistribusiCheckrollSummaryReport.strFiscalYearToDate
        ParamterField4.CurrentValues.Add(ParamterDescreteValue5)
        ParamterFields.Add(ParamterField4)

      

        CrystalReportViewer1.ParameterFieldInfo = ParamterFields
        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt

    End Sub

    Private Sub GetDistribusiCheckrollHARVLAINReportForLAINLAIN()
        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New DistribusiCheckrollLAINLAINSummaryReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds, dsFiscal, dsSubReport As New DataSet
        cmd.Connection = con

        Dim txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
        Dim dtFrom As Date = DateTime.Parse(DistribusiCheckrollSummaryReport.strFiscalYearFromDate, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
        Dim dtTo As Date = DateTime.Parse(DistribusiCheckrollSummaryReport.strFiscalYearToDate, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)

        cmd.CommandText = "checkRoll.DistribusiCheckrollLAINDOLAINSummaryReport ?, ?, ?, ?"
        '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & dtFrom.Date & "','" & dtTo.Date & "'"

        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        cmd.Parameters.AddWithValue("@FromDT", dtFrom.Date)
        cmd.Parameters.AddWithValue("@ToDT", dtTo.Date)

        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "DistribusiCheckrollLAINDOLAINSummaryReport;1")

        Dim objCommonBOl As New GlobalBOL
        Dim lTextmonth As String = String.Empty
        lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)


        Dim txtHeader As CrystalDecisions.CrystalReports.Engine.TextObject
        txtHeader = CType(rpt.ReportDefinition.ReportObjects.Item("txtHeader"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtHeader.Text = "DISTRIBUSI CHECKROLL SUMMARY REPORT " & lTextmonth & ""

        'txtPeriode = CType(rpt.ReportDefinition.ReportObjects.Item("txtPeriode"), CrystalDecisions.CrystalReports.Engine.TextObject)

        '  txtPeriode.Text = "Period: " & Format(DailyCostingRpt.startDate, "dd/MM/yyyy") & " to " & Format(DailyCostingRpt.EndDate, "dd/MM/yyyy") & ""

        Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
        txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        txtEstateName.Text = strArray(1)

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField4 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue4 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue5 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@EstateID"
        ParamterDescreteValue2.Value = GlobalPPT.strEstateID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue3.Value = GlobalPPT.strActMthYearID
        ParamterField2.CurrentValues.Add(ParamterDescreteValue3)
        ParamterFields.Add(ParamterField2)

        ParamterField3.ParameterFieldName = "@FromDT"
        ParamterDescreteValue4.Value = DistribusiCheckrollSummaryReport.strFiscalYearFromDate
        ParamterField3.CurrentValues.Add(ParamterDescreteValue4)
        ParamterFields.Add(ParamterField3)

        ParamterField4.ParameterFieldName = "@ToDT"
        ParamterDescreteValue5.Value = DistribusiCheckrollSummaryReport.strFiscalYearToDate
        ParamterField4.CurrentValues.Add(ParamterDescreteValue5)
        ParamterFields.Add(ParamterField4)

        CrystalReportViewer1.ParameterFieldInfo = ParamterFields
        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub GetDistribusiCheckrollHARVReport()
        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New DistribusiCheckrollHarvSummaryReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds, dsFiscal, dsSubReport As New DataSet
        cmd.Connection = con

        Dim txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
        Dim dtFrom As Date = DateTime.Parse(DistribusiCheckrollSummaryReport.strFiscalYearFromDate, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
        Dim dtTo As Date = DateTime.Parse(DistribusiCheckrollSummaryReport.strFiscalYearToDate, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)

        cmd.CommandText = "checkRoll.DistribusiCheckrollHARVSummaryReport ?, ?, ?, ?"
        '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & dtFrom.Date & "','" & dtTo.Date & "'"

        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        cmd.Parameters.AddWithValue("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        cmd.Parameters.AddWithValue("@FromDT", dtFrom.Date)
        cmd.Parameters.AddWithValue("@ToDT", dtTo.Date)

        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "DistribusiCheckrollHARVSummaryReport;1")

        Dim objCommonBOl As New GlobalBOL
        Dim lTextmonth As String = String.Empty
        lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)


        Dim txtHeader As CrystalDecisions.CrystalReports.Engine.TextObject
        txtHeader = CType(rpt.ReportDefinition.ReportObjects.Item("txtHeader"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtHeader.Text = "DISTRIBUSI CHECKROLL REPORT " & lTextmonth & ""

        'txtPeriode = CType(rpt.ReportDefinition.ReportObjects.Item("txtPeriode"), CrystalDecisions.CrystalReports.Engine.TextObject)

        '  txtPeriode.Text = "Period: " & Format(DailyCostingRpt.startDate, "dd/MM/yyyy") & " to " & Format(DailyCostingRpt.EndDate, "dd/MM/yyyy") & ""

        Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
        txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        txtEstateName.Text = strArray(1)



        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField4 As New CrystalDecisions.Shared.ParameterField


        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue4 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue5 As New CrystalDecisions.Shared.ParameterDiscreteValue


        ParamterField1.ParameterFieldName = "@EstateID"
        ParamterDescreteValue2.Value = GlobalPPT.strEstateID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue3.Value = GlobalPPT.strActMthYearID
        ParamterField2.CurrentValues.Add(ParamterDescreteValue3)
        ParamterFields.Add(ParamterField2)

        ParamterField3.ParameterFieldName = "@FromDT"
        ParamterDescreteValue4.Value = DistribusiCheckrollSummaryReport.strFiscalYearFromDate
        ParamterField3.CurrentValues.Add(ParamterDescreteValue4)
        ParamterFields.Add(ParamterField3)

        ParamterField4.ParameterFieldName = "@ToDT"
        ParamterDescreteValue5.Value = DistribusiCheckrollSummaryReport.strFiscalYearToDate
        ParamterField4.CurrentValues.Add(ParamterDescreteValue5)
        ParamterFields.Add(ParamterField4)


        CrystalReportViewer1.ParameterFieldInfo = ParamterFields
        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
    End Sub
End Class

