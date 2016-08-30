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

Public Class DistribusiViewReport
    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty



    Private Sub DistribusiViewReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password


        If DistribusiCheckrollReport.chkReport = 1 Then
            GetDistribusiCheckrollHARVLAINReportForPANENLAIN()
        End If

        If DistribusiCheckrollReport.chkReport = 2 Then
            GetDistribusiCheckrollHARVLAINReportForLAINLAIN()
        End If

        If DistribusiCheckrollReport.chkReport = 3 Then
            GetDistribusiCheckrollHARVReport()
        End If
    End Sub


    Private Sub GetDistribusiCheckrollHARVLAINReportForPANENLAIN()
        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New DistribusiCheckrollHARVLAINReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds, dsFiscal, dsSubReport As New DataSet
        cmd.Connection = con

        Dim txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
        Dim dtFrom As Date = DateTime.Parse(DistribusiCheckrollReport.strFiscalYearFromDate, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
        Dim dtTo As Date = DateTime.Parse(DistribusiCheckrollReport.strFiscalYearToDate, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)

        cmd.CommandText = "checkRoll.DistribusiCheckrollHARVLAINReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & dtFrom.Date.ToString("yyyyMMdd") & "','" & dtTo.Date.ToString("yyyyMMdd") & "'"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "DistribusiCheckrollHARVLAINReport;1")

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
        ParamterDescreteValue4.Value = DistribusiCheckrollReport.strFiscalYearFromDate
        ParamterField3.CurrentValues.Add(ParamterDescreteValue4)
        ParamterFields.Add(ParamterField3)

        ParamterField4.ParameterFieldName = "@ToDT"
        ParamterDescreteValue5.Value = DistribusiCheckrollReport.strFiscalYearToDate
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

        Dim rpt As New DistribusiCheckrollLAINLAINReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds, dsFiscal, dsSubReport As New DataSet
        cmd.Connection = con

        Dim txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
        Dim dtFrom As Date = DateTime.Parse(DistribusiCheckrollReport.strFiscalYearFromDate, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
        Dim dtTo As Date = DateTime.Parse(DistribusiCheckrollReport.strFiscalYearToDate, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)

        cmd.CommandText = "checkRoll.DistribusiCheckrollLAINDOLAINReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & dtFrom.Date.ToString("yyyyMMdd") & "','" & dtTo.Date.ToString("yyyyMMdd") & "'"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "DistribusiCheckrollLAINDOLAINReport;1")

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
        ParamterDescreteValue4.Value = DistribusiCheckrollReport.strFiscalYearFromDate
        ParamterField3.CurrentValues.Add(ParamterDescreteValue4)
        ParamterFields.Add(ParamterField3)

        ParamterField4.ParameterFieldName = "@ToDT"
        ParamterDescreteValue5.Value = DistribusiCheckrollReport.strFiscalYearToDate
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

        Dim rpt As New DistribusiCheckrollHarvReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds, dsFiscal, dsSubReport As New DataSet
        cmd.Connection = con

        Dim txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
        Dim dtFrom As Date = DateTime.Parse(DistribusiCheckrollReport.strFiscalYearFromDate, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
        Dim dtTo As Date = DateTime.Parse(DistribusiCheckrollReport.strFiscalYearToDate, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)

        cmd.CommandText = "checkRoll.DistribusiCheckrollHARVReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & dtFrom.Date.ToString("yyyyMMdd") & "','" & dtTo.Date.ToString("yyyyMMdd") & "'"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "DistribusiCheckrollHARVReport;1")

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
        ParamterDescreteValue4.Value = DistribusiCheckrollReport.strFiscalYearFromDate
        ParamterField3.CurrentValues.Add(ParamterDescreteValue4)
        ParamterFields.Add(ParamterField3)

        ParamterField4.ParameterFieldName = "@ToDT"
        ParamterDescreteValue5.Value = DistribusiCheckrollReport.strFiscalYearToDate
        ParamterField4.CurrentValues.Add(ParamterDescreteValue5)
        ParamterFields.Add(ParamterField4)


        CrystalReportViewer1.ParameterFieldInfo = ParamterFields
        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
    End Sub
End Class

