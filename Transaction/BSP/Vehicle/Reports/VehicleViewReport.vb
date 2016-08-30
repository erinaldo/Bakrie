Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration

Public Class VehicleViewReport

    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty
    Public strReportName As String
    Dim _GlobalBOL As New GlobalBOL

    Dim objDistribusiBiayaBengkelReportPPT As New Vehicle_PPT.DistribusiBiayaBengkelReportPPT



    Private Sub VehicleViewReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case (strReportName)
            Case "DistribusiBiayaBengkelsReport"
                DistribusiBiayaBengkelsReport()
            Case "VehicleRunningExpenditureReport"
                VehicleRunningExpenditureReport()
            Case "VehicleRunningExpenditureReportByCostCode"
                VehicleRunningExpenditureReport2()
        End Select

    End Sub

    Private Sub DistribusiBiayaBengkelsReport()

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New DistribusiBiayaBengkelRpt
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim dsDistibusiRpt As New DataSet
        cmd.Connection = con
        'Dim a As String = String.Empty
        'a = DistribusiBiayaBengkelReportFrm.strActMthYearID

        cmd.CommandText = "[Vehicle].[DistibusiBiayaBengkelReportGET] '" & GlobalPPT.strEstateID & "','" & DistribusiBiayaBengkelReportFrm.strActMthYearID & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsDistibusiRpt, "DistibusiBiayaBengkelReportGET;1")

        Dim txtBulan, txtEstate, txtFromDate, txtToDate, txtFiscal, txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject

        txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtBulan = CType(rpt.ReportDefinition.ReportObjects.Item("txtBulan"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        txtFiscal.Text = "DISTRIBUSI BIAYA BENGKEL " & _GlobalBOL.PMonthName(DistribusiBiayaBengkelReportFrm.strmonth, DistribusiBiayaBengkelReportFrm.strYear, GlobalPPT.strLang)
        txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
        txtFromDate.Text = DistribusiBiayaBengkelReportFrm.strFiscalYearFromDate
        txtToDate.Text = DistribusiBiayaBengkelReportFrm.strFiscalYearToDate
        txtBulan.Text = _GlobalBOL.PMonthName(DistribusiBiayaBengkelReportFrm.strmonth, DistribusiBiayaBengkelReportFrm.strYear, GlobalPPT.strLang)
        'If dsDistibusiRpt.Tables(0).Rows.Count > 0 Then

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue2.Value = GlobalPPT.strActMthYearID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@EstateID"
        ParamterDescreteValue2.Value = GlobalPPT.strEstateID
        ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField2)
        crvVehicle.ParameterFieldInfo = ParamterFields

        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(dsDistibusiRpt)
        crvVehicle.ReportSource = rpt

        'End If
    End Sub

    Private Sub VehicleRunningExpenditureReport()

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New VehicleRunningExpenditureReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim dsDistibusiRpt As New DataSet
        cmd.Connection = con

        cmd.CommandText = "[Vehicle].[VehicleRunningExpenditureReport] '" & GlobalPPT.strEstateID & "','" & VehicleRunningExpenditureReportFrm.strActMthYearID & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsDistibusiRpt, "VehicleRunningExpenditureReport;1")

        Dim txtEstate, txtLoginUser, txtFromDate, txtToDate, txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject

        txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtLoginUser = CType(rpt.ReportDefinition.ReportObjects.Item("txtLoginUser"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtLoginUser.Text = GlobalPPT.strUserName

        txtFiscal.Text = "VEHICLE RUNNING EXPENDITURE " & _GlobalBOL.PMonthName(VehicleRunningExpenditureReportFrm.strmonth, VehicleRunningExpenditureReportFrm.strYear, GlobalPPT.strLang)  '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
        txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
        txtFromDate.Text = VehicleRunningExpenditureReportFrm.strFiscalYearFromDate
        txtToDate.Text = VehicleRunningExpenditureReportFrm.strFiscalYearToDate

        'If dsDistibusiRpt.Tables(0).Rows.Count > 0 Then

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue2.Value = GlobalPPT.strActMthYearID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@EstateID"
        ParamterDescreteValue2.Value = GlobalPPT.strEstateID
        ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField2)
        crvVehicle.ParameterFieldInfo = ParamterFields

        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(dsDistibusiRpt)
        crvVehicle.ReportSource = rpt

        'End If
    End Sub
    Private Sub VehicleRunningExpenditureReport2()

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New VehicleRunningExpenditureReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim dsDistibusiRpt As New DataSet
        cmd.Connection = con

        cmd.CommandText = "[Vehicle].[VehicleRunningExpenditureReport] '" & GlobalPPT.strEstateID & "','" & VehicleRunningExpenditureReportFrm2.strActMthYearID & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsDistibusiRpt, "VehicleRunningExpenditureReport;1")

        Dim txtEstate, txtLoginUser, txtFromDate, txtToDate, txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject

        txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtLoginUser = CType(rpt.ReportDefinition.ReportObjects.Item("txtLoginUser"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtLoginUser.Text = GlobalPPT.strUserName

        txtFiscal.Text = "VEHICLE RUNNING EXPENDITURE " & _GlobalBOL.PMonthName(VehicleRunningExpenditureReportFrm2.strmonth, VehicleRunningExpenditureReportFrm2.strYear, GlobalPPT.strLang)  '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
        txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
        txtFromDate.Text = VehicleRunningExpenditureReportFrm2.strFiscalYearFromDate
        txtToDate.Text = VehicleRunningExpenditureReportFrm2.strFiscalYearToDate

        'If dsDistibusiRpt.Tables(0).Rows.Count > 0 Then

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue2.Value = GlobalPPT.strActMthYearID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@EstateID"
        ParamterDescreteValue2.Value = GlobalPPT.strEstateID
        ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField2)
        crvVehicle.ParameterFieldInfo = ParamterFields

        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(dsDistibusiRpt)
        crvVehicle.ReportSource = rpt

        'End If
    End Sub
    'Private Sub VehicleFarmTractorHEVehicleRunningLogRpt()

    '    strDSN = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oDSN").ToString) & ""
    '    strServerUserName = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oUserName").ToString) & ""
    '    strServerPassword = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oPassword").ToString) & ""

    '    Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
    '    Dim con As New Odbc.OdbcConnection
    '    Dim cmd As New Odbc.OdbcCommand
    '    Dim da As New Odbc.OdbcDataAdapter
    '    con = New Odbc.OdbcConnection(constr)
    '    con.Open()

    '    Dim rpt As New VehicleFarmTractorHEVehicleRunningLogReport
    '    Dim tblAdt As New Odbc.OdbcDataAdapter
    '    Dim dsRunningLogReport As New DataSet
    '    cmd.Connection = con

    '    cmd.CommandText = "[Vehicle].[VehicleRunningLogReportGet] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.IntActiveMonth & "','" & GlobalPPT.intActiveYear & "'"
    '    cmd.CommandType = CommandType.StoredProcedure
    '    tblAdt.SelectCommand = cmd
    '    tblAdt.Fill(dsRunningLogReport, "VehicleRunningLogReportGet;1")

    '    Dim txtEstate, txtFromDate, txtToDate, txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject

    '    txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)

    '    txtFiscal.Text = "Vehicle, Farm Tractor, HE, Vehicle Running Log " & General.MonthYear(GlobalPPT.IntActiveMonth) & " " & GlobalPPT.intActiveYear.ToString() '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
    '    txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
    '    txtFromDate.Text = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
    '    txtToDate.Text = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")

    '    'If dsRunningLogReport.Tables(0).Rows.Count > 0 Then

    '    Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
    '    Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
    '    Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
    '    Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField

    '    Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
    '    Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
    '    Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

    '    ParamterField1.ParameterFieldName = "@EstateID"
    '    ParamterDescreteValue1.Value = GlobalPPT.strEstateID
    '    ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
    '    ParamterFields.Add(ParamterField1)

    '    ParamterField2.ParameterFieldName = "@LogedInMonth"
    '    ParamterDescreteValue2.Value = GlobalPPT.IntActiveMonth
    '    ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
    '    ParamterFields.Add(ParamterField2)
    '    crvVehicle.ParameterFieldInfo = ParamterFields

    '    ParamterField3.ParameterFieldName = "@LogedInYear"
    '    ParamterDescreteValue3.Value = GlobalPPT.intActiveYear
    '    ParamterField3.CurrentValues.Add(ParamterDescreteValue3)
    '    ParamterFields.Add(ParamterField3)
    '    crvVehicle.ParameterFieldInfo = ParamterFields

    '    rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
    '    rpt.SetDataSource(dsRunningLogReport)
    '    crvVehicle.ReportSource = rpt
    '    'End If

    'End Sub

    'Private Sub RekapitulasiJamBengkelsReport()

    '    strDSN = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oDSN").ToString) & ""
    '    strServerUserName = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oUserName").ToString) & ""
    '    strServerPassword = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oPassword").ToString) & ""

    '    Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
    '    Dim con As New Odbc.OdbcConnection
    '    Dim cmd As New Odbc.OdbcCommand
    '    Dim da As New Odbc.OdbcDataAdapter
    '    con = New Odbc.OdbcConnection(constr)
    '    con.Open()

    '    Dim rpt As New RekapitulasiJamBengkelsRpt
    '    Dim tblAdt As New Odbc.OdbcDataAdapter
    '    Dim dsRekapitulasi As New DataSet
    '    cmd.Connection = con

    '    cmd.CommandText = "[Vehicle].[RekapitulasiJamBengkelReportGET] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
    '    cmd.CommandType = CommandType.StoredProcedure
    '    tblAdt.SelectCommand = cmd
    '    tblAdt.Fill(dsRekapitulasi, "RekapitulasiJamBengkelReportGET;1")

    '    Dim txtEstate, txtFromDate, txtToDate, txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject

    '    txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)

    '    txtFiscal.Text = "REKAPITULASI JAM BENGKEL " & General.MonthYear(GlobalPPT.IntActiveMonth) & " " & GlobalPPT.intActiveYear.ToString() '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
    '    txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
    '    txtFromDate.Text = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
    '    txtToDate.Text = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")

    '    'If dsRekapitulasi.Tables(0).Rows.Count > 0 Then

    '    Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
    '    Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
    '    Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField

    '    Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
    '    Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue

    '    ParamterField1.ParameterFieldName = "@EstateID"
    '    ParamterDescreteValue1.Value = GlobalPPT.strEstateID
    '    ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
    '    ParamterFields.Add(ParamterField1)

    '    ParamterField2.ParameterFieldName = "@ActiveMonthYearID"
    '    ParamterDescreteValue2.Value = GlobalPPT.strActMthYearID
    '    ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
    '    ParamterFields.Add(ParamterField2)

    '    crvVehicle.ParameterFieldInfo = ParamterFields
    '    rpt.SetDatabaseLogon(strServerUserName, strServerPassword)

    '    Dim dsCalculated As DataSet = RekapitulasiJamBengkelsReportCalculation(dsRekapitulasi)

    '    rpt.SetDataSource(dsCalculated)
    '    crvVehicle.ReportSource = rpt
    '    'End If

    'End Sub

    'Private Function RekapitulasiJamBengkelsReportCalculation(ByVal dsRekapitulasiJamBengkel As DataSet) As DataSet

    '    'dsRekapitulasiJamBengkel.Tables(0).Columns.Add("Total")

    '    Dim row As Integer
    '    Dim column As Integer

    '    Dim sec As Integer
    '    sec = 0

    '    For row = 0 To dsRekapitulasiJamBengkel.Tables(0).Rows.Count - 1
    '        For column = 4 To dsRekapitulasiJamBengkel.Tables(0).Columns.Count - 2
    '            If Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)) <> String.Empty Then
    '                Dim strArray() As String = Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)).Split(":")

    '                sec = sec + TimeSpan.FromHours(Convert.ToDouble(strArray(0))).TotalSeconds + TimeSpan.FromMinutes(Convert.ToDouble(strArray(1))).TotalSeconds

    '            End If
    '        Next

    '        'dsRekapitulasiJamBengkelData.Tables(0).Rows(row)(column) = Convert.ToString(TimeSpan.FromSeconds(sec))

    '        Dim lsDays As String

    '        If Convert.ToString(TimeSpan.FromSeconds(sec)).Contains(".") Then
    '            lsDays = Convert.ToString(TimeSpan.FromSeconds(sec)).Substring(0, Convert.ToString(TimeSpan.FromSeconds(sec)).IndexOf("."))
    '            Dim j As Integer = (Convert.ToInt32(lsDays) * 24) + TimeSpan.FromSeconds(sec).Hours
    '            lsDays = Format(j, "0,0") + ":" + Format(TimeSpan.FromSeconds(sec).Minutes, "0,0")
    '        Else
    '            lsDays = Format(TimeSpan.FromSeconds(sec).Hours, "0,0") + ":" + Format(TimeSpan.FromSeconds(sec).Minutes, "0,0")
    '        End If

    '        dsRekapitulasiJamBengkel.Tables(0).Rows(row)(2) = lsDays

    '        sec = 0

    '    Next

    '    For row = 0 To dsRekapitulasiJamBengkel.Tables(0).Rows.Count - 1
    '        For column = 3 To dsRekapitulasiJamBengkel.Tables(0).Columns.Count - 2
    '            If Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)) <> String.Empty Then
    '                'Dim len As Integer = Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)).Substring(0, Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)).LastIndexOf(":")).Length
    '                Dim lsTime As String = Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)).Substring(0, Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)).LastIndexOf(":"))
    '                If lsTime.Length > 4 Then
    '                    dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column) = lsTime
    '                Else
    '                    Dim t As TimeSpan = TimeSpan.Parse(Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)))
    '                    Dim s As String = (String.Format("{0:00}", t.Hours) & ":") + String.Format("{0:00}", t.Minutes)
    '                    dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column) = (String.Format("{0:00}", t.Hours) & ":") + String.Format("{0:00}", t.Minutes)
    '                End If
    '            End If
    '        Next
    '    Next

    '    Return dsRekapitulasiJamBengkel

    'End Function

End Class