Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports Common_DAL
Imports CheckRoll_DAL
Imports Accounts_BOL
Imports System.Data.SqlClient

Public Class ViewReport

    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDatasource As String = String.Empty
    Dim strDataBase As String = String.Empty
    Dim strDSN As String = String.Empty
    Dim _GlobalBOL As New GlobalBOL

    Public _Source As String = String.Empty
    Public _Formula As String = String.Empty
    Public cryRpt As New ReportDocument
    Private Rd As CrystalDecisions.CrystalReports.Engine.ReportDocument = Nothing

    ' By Dadang Adi Hendradi
    ' Kamis, 10 Des 2009, 15:30
    Private Conn As OdbcConnection
    Private adapter As OdbcDataAdapter
    Private SelectCommand As OdbcCommand

    Private DS As System.Data.DataSet
    Private ActiveMonthYearID As String = GlobalPPT.strActMthYearID
    Private ReportUserName As String = String.Empty
    Private FromDT As String = String.Empty
    Private ToDT As String = String.Empty
    Private ci As ConnectionInfo

    ' Jum'at, 19 Mar 2010, 23:39 dipindah ke private variable aja
    Private oDSN As String = String.Empty 'BSPDSN
    Private oDatabase As String = String.Empty
    Private oUserName As String = String.Empty
    Private oPwd As String = String.Empty
    Public tmpMandorBesarID As String = String.Empty

    Private Sub ViewReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFormula.Text = _Formula
        txtSource.Text = _Source

     
        oDSN = GlobalPPT.SelectedDB.DSN
        oUserName = GlobalPPT.SelectedDB.User
        oPwd = GlobalPPT.SelectedDB.Password
        oDatabase = GlobalPPT.SelectedDB.DBName



        Dim connectionString As String
        'connectionString = "DSN=" + oDSN + ";UID=" + oUserName + "; pwd=" + oPwd + ";"
        connectionString = "DSN=" + GlobalPPT.SelectedDB.DSN + ";UID=" + GlobalPPT.SelectedDB.User + "; pwd=" + GlobalPPT.SelectedDB.Password + ";"

        Conn = New OdbcConnection()
        Conn.ConnectionString = connectionString
        Conn.Open()

        ' CONNECTION INFO
        ci = New ConnectionInfo()

        ci.ServerName = oDSN
        ci.DatabaseName = oDatabase
        ci.UserID = oUserName
        ci.Password = oPwd

        ' Senin, 01 Feb 2010, 03:04
        Dim dt As DataTable

        dt = CheckRoll_DAL.CheckrollMonthEndClosingDAL.CRGetActiveMonthYearIDFromLogin()
        If dt.Rows.Count = 0 Then
            ActiveMonthYearID = GlobalPPT.strActMthYearID
        Else
            ActiveMonthYearID = dt.Rows(0).Item("ActiveMonthYearID").ToString()
        End If
        ' END Senin, 01 Feb 2010, 03:04

        ' Senin, 01 Feb 2010, 11:59
        ReportUserName = GlobalPPT.strUserName
        ' END Senin, 01 Feb 2010, 11:59

        If txtSource.Text = "CRSalaryReport" Then

            Try
                Dim psEstateType As String

                psEstateType = JournalBOL.EstateTypeSelect()


                If psEstateType <> "M" Then
                    Dim report As CRSalaryReport = New CRSalaryReport()

                    '' modified by Kumar on jul 9 2010
                    '  Dim report As CRSlipSalaryReport = New CRSlipSalaryReport()

                    Dim tblAdt As New Odbc.OdbcDataAdapter

                    Dim ds As New DataSet
                    Dim con As New Odbc.OdbcConnection
                    Dim cmd As New Odbc.OdbcCommand
                    Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                    con = New Odbc.OdbcConnection(constr)
                    con.Open()

                    cmd.Connection = con

                    cmd.CommandText = "Checkroll.CRSalaryReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                    cmd.CommandTimeout = 1800
                    cmd.CommandType = CommandType.StoredProcedure
                    tblAdt.SelectCommand = cmd
                    tblAdt.Fill(ds, "CRSalaryReport;1")
                    FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                    ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                    report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                    report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                    report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"


                    Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim lTextmonth As String = String.Empty
                    Dim objCommonBOl As New GlobalBOL
                    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                    txtMonthYear.Text = "CHECKROLL REPORT FOR KHT/KHL  " & lTextmonth & ""

                    Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim strArray As String()
                    strArray = GlobalPPT.strEstateName.Split("-")
                    txtEstateName.Text = strArray(1)


                    report.SetDataSource(ds.Tables(0))
                    CRV.ReportSource = report
                    CRV.ShowGroupTreeButton = True

                    'export to XML, featured added on 24 Sep 2013.. Pushpa's request
                    Dim EnableXML As Boolean = False
                    If EnableXML Then
                        If MessageBox.Show("Do you want to export the report to XML?", "Export to XML?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Dim fileSave As New SaveFileDialog()
                            fileSave.Filter = "XML File|*.xml"
                            fileSave.FilterIndex = 1
                            fileSave.RestoreDirectory = True

                            If fileSave.ShowDialog() = DialogResult.OK Then
                                ds.WriteXml(fileSave.FileName)
                            End If
                            fileSave.Dispose()
                        End If
                    End If

                Else
                    Dim reportmill As CRSalaryReportformill = New CRSalaryReportformill()

                    '' modified by Kumar on jul 9 2010
                    '  Dim report As CRSlipSalaryReport = New CRSlipSalaryReport()

                    Dim tblAdt As New Odbc.OdbcDataAdapter

                    Dim ds As New DataSet
                    Dim con As New Odbc.OdbcConnection
                    Dim cmd As New Odbc.OdbcCommand
                    Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                    con = New Odbc.OdbcConnection(constr)
                    con.Open()

                    cmd.Connection = con

                    cmd.CommandText = "Checkroll.CRSalaryReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                    cmd.CommandType = CommandType.StoredProcedure
                    tblAdt.SelectCommand = cmd
                    tblAdt.Fill(ds, "CRSalaryReport;1")
                    FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                    ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                    reportmill.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                    reportmill.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                    reportmill.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"


                    Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtMonthYear = CType(reportmill.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim lTextmonth As String = String.Empty
                    Dim objCommonBOl As New GlobalBOL
                    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                    txtMonthYear.Text = "CHECKROLL REPORT FOR KHT/KHL  " & lTextmonth & ""

                    Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtEstateName = CType(reportmill.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim strArray As String()
                    strArray = GlobalPPT.strEstateName.Split("-")
                    txtEstateName.Text = strArray(1)


                    reportmill.SetDataSource(ds.Tables(0))

                    CRV.ReportSource = reportmill
                    CRV.ShowGroupTreeButton = True

                End If





                ''SelectCommand = New OdbcCommand()
                ''SelectCommand.Connection = Conn
                ''SelectCommand.CommandType = CommandType.StoredProcedure
                ''SelectCommand.CommandText = "Checkroll.CRSalaryReport"

                ''DS = New DataSet()

                ''adapter = New OdbcDataAdapter()
                ''adapter.SelectCommand = SelectCommand
                ''adapter.Fill(DS)

                ' '' Setting
                ''report.SetDataSource(DS)
                'SetDBLogonForReport(ci, report.Database.Tables)
                'CRV.ReportSource = report
                'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"

                'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                'CRV.SelectionFormula = _
                '"{CRSalaryReport;1.EstateID} = '" + GlobalPPT.strEstateID + "' AND " + _
                '"{CRSalaryReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"

                'CRV.ShowGroupTreeButton = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Checkroll", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        ElseIf txtSource.Text = "AttendanceSumReport" Then
            Dim report As AttendanceSumReport2 = New AttendanceSumReport2() ' Buatan gua sendiri

            '' modified by Kumar on jul 9 2010

            Dim tblAdt As New Odbc.OdbcDataAdapter

            Dim ds As New DataSet
            Dim con As New Odbc.OdbcConnection
            Dim cmd As New Odbc.OdbcCommand
            Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
            con = New Odbc.OdbcConnection(constr)
            con.Open()

            cmd.Connection = con

            cmd.CommandText = "Checkroll.AttendanceSumReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "AttendanceSumReport;1")
            'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
            'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
            'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
            'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
            report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"

            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "ATTENDANCE SUMMARY FOR " & lTextmonth & ""



            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)


            report.SetDataSource(ds.Tables(0))
            CRV.ReportSource = report
            CRV.ShowGroupTreeButton = True



            'Dim report As AttendanceSumReport2 = New AttendanceSumReport2() ' Buatan gua sendiri

            'SelectCommand = New OdbcCommand()
            'SelectCommand.Connection = Conn
            'SelectCommand.CommandType = CommandType.StoredProcedure
            'SelectCommand.CommandText = "Checkroll.AttendanceSumReport"

            'DS = New DataSet()

            'adapter = New OdbcDataAdapter()
            'adapter.SelectCommand = SelectCommand
            'adapter.Fill(DS)

            '' Setting
            'report.SetDataSource(DS)
            'SetDBLogonForReport(ci, report.Database.Tables)
            '' Selasa, 02 Feb 2010, 11:42
            'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            '' END Selasa, 02 Feb 2010, 11:42
            'CRV.ReportSource = report
            'CRV.SelectionFormula = "{AttendanceSumReport;1.ActiveMonthYearId}='" + ActiveMonthYearID + "'"
            'CRV.ShowGroupTreeButton = True

        ElseIf txtSource.Text = "DetailPremiReport" Then
            'Jum'at, 11 Des 2009, 01:48
            Try
                Dim report As CRDetailPremiPanenReport = New CRDetailPremiPanenReport()

                '' modified by Kumar on jul 9 2010

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRDetailPremiPanenReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRDetailPremiPanenReport;1")
                'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "DETAIL PREMI PANEN REPORT FOR " & lTextmonth & ""



                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True



                'Dim report As CRDetailPremiPanenReport = New CRDetailPremiPanenReport()

                'SelectCommand = New OdbcCommand()
                'SelectCommand.Connection = Conn
                'SelectCommand.CommandType = CommandType.StoredProcedure
                'SelectCommand.CommandText = "Checkroll.CRDetailPremiPanenReport"

                'DS = New DataSet()

                'adapter = New OdbcDataAdapter()
                'adapter.SelectCommand = SelectCommand
                'adapter.Fill(DS)

                '' Setting
                'report.SetDataSource(DS)
                'SetDBLogonForReport(ci, report.Database.Tables)

                'CRV.ReportSource = report
                'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                'CRV.SelectionFormula = "{CRDetailPremiPanenReport;1.ActiveMonthYearId}='" + ActiveMonthYearID + "'"

                'CRV.ShowGroupTreeButton = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf txtSource.Text = "CRDetailPremiDeresReport" Then
            'Jum'at, 11 Des 2009, 01:48
            Try
                Dim report As CRDetailPremiDeresReport = New CRDetailPremiDeresReport()

                '' modified by Kumar on jul 9 2010

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRDetailPremiDeresReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRDetailPremiDeresReport;1")
                'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "DETAIL PREMI DERES REPORT FOR " & lTextmonth & ""



                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "AllowanceDeductionSummary" Then
            'Jum'at, 11 Des 2009, 01:48
            Try
                Dim report As AllowanceDeductionSummary = New AllowanceDeductionSummary()

                '' modified by Kumar on jul 9 2010

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.AllowanceCrosstabReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "AllowanceCrosstabReport;1")
                'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"


                'Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                'txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                'Dim lTextmonth As String = String.Empty
                'Dim objCommonBOl As New GlobalBOL
                'lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                'txtMonthYear.Text = "DETAIL PREMI DERES REPORT FOR " & lTextmonth & ""



                'Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                'txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                'Dim strArray As String()
                'strArray = GlobalPPT.strEstateName.Split("-")
                'txtEstateName.Text = strArray(1)


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


        ElseIf txtSource.Text = "CRDANoTeamReport" Then
            'Jum'at, 11 Des 2009, 01:48
            Dim report As DailyAttendanceNoTeamReport = New DailyAttendanceNoTeamReport()

            SelectCommand = New OdbcCommand()
            SelectCommand.Connection = Conn
            SelectCommand.CommandType = CommandType.StoredProcedure
            SelectCommand.CommandText = "Checkroll.CRDANoTeamReport"

            DS = New DataSet()

            adapter = New OdbcDataAdapter()
            adapter.SelectCommand = SelectCommand
            adapter.Fill(DS)

            ' Setting
            report.SetDataSource(DS)
            SetDBLogonForReport(ci, report.Database.Tables)
            ' Selasa, 02 Feb 2010, 14:28
            report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            ' END Selasa, 02 Feb 2010, 14:28
            CRV.ReportSource = report
            CRV.SelectionFormula = "{CRDANoTeamReport;1.EstateID} = '" + GlobalPPT.strEstateID + "' AND " + _
            "{CRDANoTeamReport;1.RDate} >= DateSerial(" + _
            GlobalPPT.FiscalYearFromDate.Year.ToString() + "," + _
            GlobalPPT.FiscalYearFromDate.Month.ToString() + "," + _
            GlobalPPT.FiscalYearFromDate.Day.ToString() + ") AND " + _
            "{CRDANoTeamReport;1.RDate} <= DateSerial(" + _
            GlobalPPT.FiscalYearToDate.Year.ToString() + "," + _
            GlobalPPT.FiscalYearToDate.Month.ToString() + "," + _
            GlobalPPT.FiscalYearToDate.Day.ToString() + ")"

            'CRV.SelectionFormula = "{CRDANoTeamReport;1.EstateID} = '" + GlobalPPT.strEstateID + "' " '+ _
            '"{CRDANoTeamReport;1.RDate} >= #" + GlobalPPT.FiscalYearFromDate.ToString() + "# AND " + _
            '"{CRDANoTeamReport;1.RDate} <= #" + GlobalPPT.FiscalYearToDate.ToString() + "#"

        ElseIf txtSource.Text = "CRAdvancePaymentReport" Then
            'Senin, 21 Des 2009, 10:12
            'Place: Kuala Lumpur
            '' modified by Kumar on jul 9 2010

            Try

                Dim report As CRAdvancePaymentReport = New CRAdvancePaymentReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()


                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRAdvancePaymentReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRAdvancePaymentReport;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"

                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "ADVANCE CHECKROLL REPORT FOR " & lTextmonth & ""


                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True


                'Try

                '    Dim report As CRAdvancePaymentReport = New CRAdvancePaymentReport()

                '    'SelectCommand = New OdbcCommand()
                '    'SelectCommand.Connection = Conn
                '    'SelectCommand.CommandType = CommandType.StoredProcedure
                '    'SelectCommand.CommandText = "Checkroll.CRAdvancePaymentReport"

                '    'DS = New DataSet()

                '    'adapter = New OdbcDataAdapter()
                '    'adapter.SelectCommand = SelectCommand
                '    'adapter.Fill(DS)

                '    '' Setting
                '    'report.SetDataSource(DS)
                '    SetDBLogonForReport(ci, report.Database.Tables)
                '    ' Selasa, 02 Feb 2010, 11:42
                '    report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                '    ' END Selasa, 02 Feb 2010, 11:42
                '    CRV.ReportSource = report
                '    CRV.SelectionFormula = "{CRAdvancePaymentReport;1.ActiveMonthYearId}='" + ActiveMonthYearID + "'"


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Checkroll", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

        ElseIf txtSource.Text = "CRRekapitulasiAdvancePaymentReport" Then
            'Senin, 21 Des 2009, 10:18
            'Place: Kuala Lumpur

            '' modified by Kumar on jul 9 2010


            Dim report As CRRekapitulasiAdvancePaymentReport = New CRRekapitulasiAdvancePaymentReport()

            Dim tblAdt As New Odbc.OdbcDataAdapter

            Dim ds As New DataSet
            Dim con As New Odbc.OdbcConnection
            Dim cmd As New Odbc.OdbcCommand
            Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
            con = New Odbc.OdbcConnection(constr)
            con.Open()


            cmd.Connection = con

            cmd.CommandText = "Checkroll.CRRekapitulasiAdvancePaymentReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "CRRekapitulasiAdvancePaymentReport;1")
            report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"

            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "REKAPITULASI ADVANCE CHECKROLL ALL TEAM REPORT FOR " & lTextmonth & ""


            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)


            report.SetDataSource(ds.Tables(0))
            CRV.ReportSource = report
            CRV.ShowGroupTreeButton = True


            'Dim report As CRRekapitulasiAdvancePaymentReport = New CRRekapitulasiAdvancePaymentReport()

            'SelectCommand = New OdbcCommand()
            'SelectCommand.Connection = Conn
            'SelectCommand.CommandType = CommandType.StoredProcedure
            'SelectCommand.CommandText = "Checkroll.CRRekapitulasiAdvancePaymentReport"

            'ds = New DataSet()

            'adapter = New OdbcDataAdapter()
            'adapter.SelectCommand = SelectCommand
            'adapter.Fill(ds)

            '' Setting
            'report.SetDataSource(ds)
            'SetDBLogonForReport(ci, report.Database.Tables)

            '' Selasa, 02 Feb 2010, 13:56
            'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            '' END Selasa, 02 Feb 2010, 13:56
            'CRV.ReportSource = report
            'CRV.SelectionFormula = "{CRRekapitulasiAdvancePaymentReport;1.ActiveMonthYearId}='" + ActiveMonthYearID + "'"

        ElseIf txtSource.Text = "CRRiceAllowanceReport" Then
            'Selasa, 22 Des 2009, 16:34

            Dim report As CRRiceAllowanceReport = New CRRiceAllowanceReport()

            '' modified by Kumar on jul 9 2010

            Dim tblAdt As New Odbc.OdbcDataAdapter

            Dim ds As New DataSet
            Dim con As New Odbc.OdbcConnection
            Dim cmd As New Odbc.OdbcCommand
            Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
            con = New Odbc.OdbcConnection(constr)
            con.Open()

            cmd.Connection = con

            cmd.CommandText = "Checkroll.CRRiceAllowanceReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            'add on 26/9/2009 by suraya
            cmd.CommandTimeout = 900
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "CRRiceAllowanceReport;1")
            'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
            'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
            'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
            'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
            report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"

            'Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            'txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            'lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            'txtMonthYear.Text = "RICE ALLOWANCE REPORT FOR " & lTextmonth & ""

            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)


            report.SetDataSource(ds.Tables(0))
            CRV.ReportSource = report
            CRV.ShowGroupTreeButton = True

            'Dim report As CRRiceAllowanceReport = New CRRiceAllowanceReport()

            'SelectCommand = New OdbcCommand()
            'SelectCommand.Connection = Conn
            'SelectCommand.CommandType = CommandType.StoredProcedure
            'SelectCommand.CommandText = "Checkroll.CRRiceAllowanceReport"

            'DS = New DataSet()

            'adapter = New OdbcDataAdapter()
            'adapter.SelectCommand = SelectCommand
            'adapter.Fill(DS)

            '' Setting
            'report.SetDataSource(DS)
            'SetDBLogonForReport(ci, report.Database.Tables)
            '' Selasa, 02 Feb 2010, 14:28
            'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            '' END Selasa, 02 Feb 2010, 14:28
            'CRV.ReportSource = report
            'CRV.SelectionFormula = "{CRRiceAllowanceReport;1.ActiveMonthYearId}='" + ActiveMonthYearID + "'"

            'CRV.ShowGroupTreeButton = True

            'ElseIf txtSource.Text = "CRMaterialUsageReport" Then
            '    'Kamis, 22 Des 2009, 10:43
            '    Try
            '        Dim report As CRMaterialUsageReport = New CRMaterialUsageReport()

            '        SelectCommand = New OdbcCommand()
            '        SelectCommand.Connection = Conn
            '        SelectCommand.CommandType = CommandType.StoredProcedure
            '        SelectCommand.CommandText = "Checkroll.CRMaterialUsageReport"

            '        DS = New DataSet()

            '        adapter = New OdbcDataAdapter()
            '        adapter.SelectCommand = SelectCommand
            '        adapter.Fill(DS)

            '        ' Setting
            '        report.SetDataSource(DS)
            '        SetDBLogonForReport(ci, report.Database.Tables)

            '        ' Selasa, 02 Feb 2010, 13:26
            '        report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            '        ' END Selasa, 02 Feb 2010, 13:26
            '        CRV.ReportSource = report
            '        CRV.SelectionFormula = "{CRMaterialUsageReport;1.ActiveMonthYearId}='" + ActiveMonthYearID + "'"

            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            '    End Try

        ElseIf txtSource.Text = "CROvertimePaymentReport" Then
            '' modified by Kumar on jul 9 2010
            'Kamis, 22 Des 2009, 10:50
            Dim report As CROvertimePaymentReport = New CROvertimePaymentReport()

            Dim tblAdt As New Odbc.OdbcDataAdapter

            Dim ds As New DataSet
            Dim con As New Odbc.OdbcConnection
            Dim cmd As New Odbc.OdbcCommand
            Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
            con = New Odbc.OdbcConnection(constr)
            con.Open()

            cmd.Connection = con

            cmd.CommandText = "Checkroll.CROvertimePaymentReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "CROvertimePaymentReport;1")
            report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"


            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "OVERTIME PAYMENT REPORT FOR " & lTextmonth & ""


            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)


            report.SetDataSource(ds.Tables(0))
            CRV.ReportSource = report
            CRV.ShowGroupTreeButton = True

            'Dim report As CROvertimePaymentReport = New CROvertimePaymentReport()

            'SelectCommand = New OdbcCommand()
            'SelectCommand.Connection = Conn
            'SelectCommand.CommandType = CommandType.StoredProcedure
            'SelectCommand.CommandText = "Checkroll.CROvertimePaymentReport"

            'DS = New DataSet()

            'adapter = New OdbcDataAdapter()
            'adapter.SelectCommand = SelectCommand
            'adapter.Fill(DS)

            '' Setting
            'report.SetDataSource(DS)
            'SetDBLogonForReport(ci, report.Database.Tables)

            '' Selasa, 02 Feb 2010, 13:56
            'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            '' END Selasa, 02 Feb 2010, 13:56
            'CRV.ReportSource = report
            'CRV.SelectionFormula = "{CROvertimePaymentReport;1.ActiveMonthYearId}='" + ActiveMonthYearID + "'"

            'CRV.ShowGroupTreeButton = True
        ElseIf txtSource.Text = "CRPremiRubberReport" Then
            Dim report As CRPremiRubberReport = New CRPremiRubberReport()

            Dim tblAdt As New Odbc.OdbcDataAdapter

            Dim ds As New DataSet
            Dim con As New Odbc.OdbcConnection
            Dim cmd As New Odbc.OdbcCommand
            Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
            con = New Odbc.OdbcConnection(constr)
            con.Open()

            cmd.Connection = con

            cmd.CommandText = "Checkroll.PremiRubberReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "PremiRubberReport;1")
            report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"


            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "Premi Rubber Report for " & lTextmonth & ""


            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)


            report.SetDataSource(ds.Tables(0))
            CRV.ReportSource = report
            CRV.ShowGroupTreeButton = True


        ElseIf txtSource.Text = "CRTHRPaymentReport" Then
            ' By Dadang Adi H
            ' Selasa, 29 Des 2009, 17:42
            ' Place: Kuala Lumpur

            Try
                ''Modified by Kumar
                Dim report As CRTHRPaymentReport = New CRTHRPaymentReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRTHRPaymentReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRTHRPaymentReport;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"

                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "PEMBAYARAN THR FOR " & lTextmonth & ""


                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True



                'Dim report As CRTHRPaymentReport = New CRTHRPaymentReport()

                ''SelectCommand = New OdbcCommand()
                ''SelectCommand.Connection = Conn
                ''SelectCommand.CommandType = CommandType.StoredProcedure
                ''SelectCommand.CommandText = "Checkroll.CRTHRPaymentReport"

                ''DS = New DataSet()

                ''adapter = New OdbcDataAdapter()
                ''adapter.SelectCommand = SelectCommand
                ''adapter.Fill(DS)

                '' Setting
                ''report.SetDataSource(DS)
                'SetDBLogonForReport(ci, report.Database.Tables)
                '' Selasa, 02 Feb 2010, 13:56
                'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                '' END Selasa, 02 Feb 2010, 13:56
                'CRV.ReportSource = report
                'CRV.SelectionFormula = _
                '    "{CRTHRPaymentReport;1.EstateID} = '" + GlobalPPT.strEstateID + "' AND " + _
                '    "{CRTHRPaymentReport;1.YearPeriod} = " + GlobalPPT.intLoginYear.ToString()

                'CRV.ShowGroupTreeButton = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            'ElseIf txtSource.Text = "CRDailyAttendanceWithTeamReport" Then
            '    ' By Dadang Adi H
            '    ' Selasa, 29 Des 2009, 18:58
            '    ' Place: Kuala Lumpur
            '    ' Listing Report: CRDailyAttendanceWithTeamReport
            '    Try

            '        Dim report As CRDailyAttendanceWithTeamReport = New CRDailyAttendanceWithTeamReport()

            '        'SelectCommand = New OdbcCommand()
            '        'SelectCommand.Connection = Conn
            '        'SelectCommand.CommandType = CommandType.StoredProcedure
            '        'SelectCommand.CommandText = "[Checkroll].[CRDailyAttendanceWithTeamReport]"

            '        'DS = New DataSet()

            '        'adapter = New OdbcDataAdapter()
            '        'adapter.SelectCommand = SelectCommand
            '        'adapter.Fill(DS)

            '        '' Setting
            '        'report.SetDataSource(DS)
            '        SetDBLogonForReport(ci, report.Database.Tables)
            '        ' Selasa, 02 Feb 2010, 12:24
            '        report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            '        ' END Selasa, 02 Feb 2010, 12:24
            '        CRV.ReportSource = report
            '        CRV.SelectionFormula = _Formula

            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    End Try

        ElseIf txtSource.Text = "CRDailyReceiptionWithTeamReport" Then
            ' By Dadang Adi H
            ' Selasa, 29 Des 2009, 19:28
            ' Place: Kuala Lumpur
            ' Listing Report: CRDailyReceiptionWithTeamReport
            Try

                Dim report As CRDailyReceiptionWithTeamReport = New CRDailyReceiptionWithTeamReport()

                'SelectCommand = New OdbcCommand()
                'SelectCommand.Connection = Conn
                'SelectCommand.CommandType = CommandType.StoredProcedure
                'SelectCommand.CommandText = "[Checkroll].[CRDailyReceiptionWithTeamReport]"

                'DS = New DataSet()

                'adapter = New OdbcDataAdapter()
                'adapter.SelectCommand = SelectCommand
                'adapter.Fill(DS)

                '' Setting
                'report.SetDataSource(DS)
                SetDBLogonForReport(ci, report.Database.Tables)
                ' Selasa, 02 Feb 2010, 13:26
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                ' END Selasa, 02 Feb 2010, 13:26
                CRV.ReportSource = report
                CRV.SelectionFormula = _Formula

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRDailyActivityDistributionWithTeamReport" Then
            ' By Dadang Adi H
            ' Selasa, 29 Des 2009, 20:09
            ' Place: Kuala Lumpur
            ' Listing Report: CRDailyActivityDistributionWithTeamReport
            Try

                Dim report As CRDailyActivityDistributionWithTeamReport = New CRDailyActivityDistributionWithTeamReport()

                SelectCommand = New OdbcCommand()
                SelectCommand.Connection = Conn
                SelectCommand.CommandType = CommandType.StoredProcedure
                SelectCommand.CommandText = "[Checkroll].[CRDailyActivityDistributionWithTeamReport]"

                DS = New DataSet()

                adapter = New OdbcDataAdapter()
                adapter.SelectCommand = SelectCommand
                adapter.Fill(DS)

                ' Setting
                report.SetDataSource(DS)
                SetDBLogonForReport(ci, report.Database.Tables)
                ' Selasa, 02 Feb 2010, 11:42
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                ' END Selasa, 02 Feb 2010, 11:42
                CRV.ReportSource = report
                CRV.SelectionFormula = _Formula

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        ElseIf txtSource.Text = "CRDailyCostingByKHTKHLReport" Then
            ' By Dadang Adi H
            ' Selasa, 29 Des 2009, 21:05
            ' Place: Kuala Lumpur
            Try

                Dim report As CRDailyCostingByKHTKHLReport = New CRDailyCostingByKHTKHLReport()

                SelectCommand = New OdbcCommand()
                SelectCommand.Connection = Conn
                SelectCommand.CommandType = CommandType.StoredProcedure
                SelectCommand.CommandText = "Checkroll.CRDailyCostingByKHTKHLReport"

                DS = New DataSet()

                adapter = New OdbcDataAdapter()
                adapter.SelectCommand = SelectCommand
                adapter.Fill(DS)

                ' Setting
                report.SetDataSource(DS)
                SetDBLogonForReport(ci, report.Database.Tables)
                ' Selasa, 02 Feb 2010, 12:25
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                ' END Selasa, 02 Feb 2010, 12:25
                CRV.ReportSource = report
                CRV.SelectionFormula = _
                    "{CRDailyCostingByKHTKHLReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                    "{CRDailyCostingByKHTKHLReport;1.ActiveMonthYearId} ='" + ActiveMonthYearID + "'"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CREstateMonthlyProductionReport" Then
            ' By Dadang Adi H
            ' Sabtu, 02 Jan 2009, 23:26
            ' Place: Kuala Lumpur
            '  Dim p As ParameterField

            Try

                Dim report As CREstateMonthlyProductionReport = New CREstateMonthlyProductionReport()

                '' modified by Kumar on jul 9 2010

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CREstateMonthlyProductionReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRRiceAllowanceReport;1")
                'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)

                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "ESTATE MONTHLY ACTIVITY REPORT " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

                'Dim report As CREstateMonthlyProductionReport = New CREstateMonthlyProductionReport()

                'SelectCommand = New OdbcCommand()
                'SelectCommand.Connection = Conn
                'SelectCommand.CommandType = CommandType.StoredProcedure
                'SelectCommand.CommandText = "Checkroll.CREstateMonthlyProductionReport"

                'DS = New DataSet()

                'adapter = New OdbcDataAdapter()
                'adapter.SelectCommand = SelectCommand
                'adapter.Fill(DS)

                '' Setting
                'report.SetDataSource(DS)
                'SetDBLogonForReport(ci, report.Database.Tables)
                '' Selasa, 02 Feb 2010, 13:26
                'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                '' END Selasa, 02 Feb 2010, 13:26
                'CRV.ReportSource = report

                '' Senin, 4 Jan 2010, 16:42
                '' Tambah AMonth in selection Formula, sebagaiman di store procedure
                'CRV.SelectionFormula = _
                '    "{CREstateMonthlyProductionReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                '"{CREstateMonthlyProductionReport;1.AYear} = " + GlobalPPT.intLoginYear.ToString() + " AND " + _
                '"{CREstateMonthlyProductionReport;1.AMonth} = " + GlobalPPT.IntLoginMonth.ToString()

                'Dim currentParameterValues As New CrystalDecisions.Shared.ParameterValues()
                'Dim cureentParameterDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()


                'cureentParameterDiscreteValue.Value = GlobalPPT.IntActiveMonth
                'currentParameterValues.Add(cureentParameterDiscreteValue)

                'p = CRV.ParameterFieldInfo("pMonth")
                'p.CurrentValues = currentParameterValues

                '    '---
                '    ' Atau pake cara dibawah ini juga bisa
                '    '---

                '    'Dim paramFields As CrystalDecisions.Shared.ParameterFields
                '    'Dim paramField As CrystalDecisions.Shared.ParameterField
                '    'Dim currentValues As CrystalDecisions.Shared.ParameterValues

                '    'paramFields = CRV.ParameterFieldInfo
                '    'paramField = paramFields("pMonth")
                '    'currentValues = paramField.CurrentValues
                '    'cureentParameterDiscreteValue.Value = GlobalPPT.IntLoginMonth
                '    'currentParameterValues.Add(cureentParameterDiscreteValue)
                '    'CRV.ParameterFieldInfo = paramFields

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRRekapLapMandorPanenReport" Then
            ' By Dadang Adi H
            ' Jum'at, 08 Jan 2010, 22:45
            ' Place: Kuala Lumpur

            '' modified by Kumar on jul 9 2010

            Try

                Dim report As CRRekapLapMandorPanenReport = New CRRekapLapMandorPanenReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()


                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRRekapLapMandorPanenReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRRekapLapMandorPanenReport;1")
                FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"

                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "RECEPTION FOR HARVESTER " & lTextmonth & ""



                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report





                'SelectCommand = New OdbcCommand()
                'SelectCommand.Connection = Conn
                'SelectCommand.CommandType = CommandType.StoredProcedure
                'SelectCommand.CommandText = "Checkroll.CRRekapLapMandorPanenReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"

                'DS = New DataSet()

                'adapter = New OdbcDataAdapter()
                'adapter.SelectCommand = SelectCommand
                'adapter.Fill(DS)

                '' Setting
                'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"

                'report.SetDataSource(DS)
                'CRV.ReportSource = report
                'CRV.SelectionFormula = _
                '   "{CRRekapLapMandorPanenReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                '   "{CRRekapLapMandorPanenReport;1.ActiveMonthYearID} ='" + GlobalPPT.strActMthYearID + "'"

                'CRV.ShowGroupTreeButton = True

                '' '' '' ''SetDBLogonForReport(ci, report.Database.Tables)
                ' '' '' '' '' Selasa, 02 Feb 2010, 14:28

                '' '' '' ''CRV.ReportSource = report
                ''CRV.SelectionFormula = _
                ''    "{CRRekapLapMandorPanenReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                ''    "{CRRekapLapMandorPanenReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"

                '' '' '' ''CRV.ShowGroupTreeButton = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRRekapLapMandorLainMasterReport" Then
            ' By Dadang Adi H
            ' Jum'at, 08 Jan 2010, 22:45
            ' Place: Kuala Lumpur
            'Try

            '    Dim report As CRRekapLapMandorLainMasterReport = New CRRekapLapMandorLainMasterReport()

            '    SelectCommand = New OdbcCommand()
            '    SelectCommand.Connection = Conn
            '    SelectCommand.CommandType = CommandType.StoredProcedure
            '    SelectCommand.CommandText = "Checkroll.CRRekapLapMandorLainMasterReport"

            '    DS = New DataSet()

            '    adapter = New OdbcDataAdapter()
            '    adapter.SelectCommand = SelectCommand
            '    adapter.Fill(DS)

            '    ' Setting
            '    report.SetDataSource(DS)
            '    SetDBLogonForReport(ci, report.Database.Tables)
            '    ' Selasa, 02 Feb 2010, 13:56
            '    report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            '    ' END Selasa, 02 Feb 2010, 13:56
            '    CRV.ReportSource = report
            '    CRV.SelectionFormula = _
            '        "{CRRekapLapMandorLainMasterReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
            '        "{CRRekapLapMandorLainMasterReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"

            'Catch ex As Exception
            '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try

        ElseIf txtSource.Text = "CRCheckrollForKHLKHTReport" Then
            ' By Dadang Adi H
            ' Sabtu, 09 Jan 2010, 18:00
            ' Place: Kuala Lumpur
            Try

                Dim report As CRCheckrollForKHLKHTReport = New CRCheckrollForKHLKHTReport()

                SelectCommand = New OdbcCommand()
                SelectCommand.Connection = Conn
                SelectCommand.CommandType = CommandType.StoredProcedure
                SelectCommand.CommandText = "Checkroll.CRCheckrollForKHLKHTReport"

                DS = New DataSet()

                adapter = New OdbcDataAdapter()
                adapter.SelectCommand = SelectCommand
                adapter.Fill(DS)

                ' Setting
                report.SetDataSource(DS)
                SetDBLogonForReport(ci, report.Database.Tables)
                ' Selasa, 02 Feb 2010, 11:42
                FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                ' END Selasa, 02 Feb 2010, 11:42
                CRV.ReportSource = report
                CRV.SelectionFormula = _
                    "{CRCheckrollForKHLKHTReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                    "{CRCheckrollForKHLKHTReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRWorkingDistributionReport" Then
            ' By Dadang Adi H
            ' Ahad, 10 Jan 2010, 15:06
            ' Place: Kuala Lumpur
            Try

                Dim report As CRWorkingDistributionReport = New CRWorkingDistributionReport()
                '' modified by Kumar on jul 9 2010
                '  Dim report As CRSlipSalaryReport = New CRSlipSalaryReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRWorkingDistributionReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRWorkingDistributionReport;1")
                'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                '  report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)

                Dim txtuserName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtuserName = CType(report.ReportDefinition.ReportObjects.Item("txtuserName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                txtuserName.Text = GlobalPPT.strUserName

                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "WORKING DISTRIBUTION FOR " & lTextmonth & ""



                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

                'Dim report As CRWorkingDistributionReport = New CRWorkingDistributionReport()

                'SelectCommand = New OdbcCommand()
                'SelectCommand.Connection = Conn
                'SelectCommand.CommandType = CommandType.StoredProcedure
                'SelectCommand.CommandText = "Checkroll.CRWorkingDistributionReport"

                'DS = New DataSet()

                'adapter = New OdbcDataAdapter()
                'adapter.SelectCommand = SelectCommand
                'adapter.Fill(DS)

                '' Setting
                'report.SetDataSource(DS)
                'SetDBLogonForReport(ci, report.Database.Tables)
                '' Selasa, 02 Feb 2010, 14:28
                'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                '' END Selasa, 02 Feb 2010, 14:28
                'CRV.ReportSource = report
                'CRV.SelectionFormula = _
                '    "{CRWorkingDistributionReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                '    "{CRWorkingDistributionReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CROtherPaymentReport" Then
            ' By Dadang Adi H
            ' Ahad, 10 Jan 2010, 18:55
            ' Place: Kuala Lumpur
            Try
                ''Modified by Kumar on jul 7 2010
                Dim report As CROtherPaymentReport = New CROtherPaymentReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CROtherPaymentReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CROtherPaymentReport;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "FRINGE BENEFIT / OTHER PAYMENT FOR " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True


                'Dim report As CROtherPaymentReport = New CROtherPaymentReport()

                ''SelectCommand = New OdbcCommand()
                ''SelectCommand.Connection = Conn
                ''SelectCommand.CommandType = CommandType.StoredProcedure
                ''SelectCommand.CommandText = "Checkroll.CROtherPaymentReport"

                ''DS = New DataSet()

                ''adapter = New OdbcDataAdapter()
                ''adapter.SelectCommand = SelectCommand
                ''adapter.Fill(DS)

                ' '' Setting
                ''report.SetDataSource(DS)
                'SetDBLogonForReport(ci, report.Database.Tables)
                '' Selasa, 02 Feb 2010, 13:56
                'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                '' END Selasa, 02 Feb 2010, 13:56
                'CRV.ReportSource = report
                'CRV.SelectionFormula = _
                '    "{CROtherPaymentReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                '    "{CROtherPaymentReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"

                'CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRMoneyDenominationReport" Then
            ' By Dadang Adi H
            ' Senin, 01 Feb 2010, 00:48
            ' Place: Balikpapan
            Try
                '' modified by Kumar on jul 9 2010


                Dim report As CRMoneyDenominationReport = New CRMoneyDenominationReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRMoneyDenominationReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRMoneyDenominationReport;1")
                FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "MONEY DENOMINATION SALARY ALL TEAM FOR " & lTextmonth & ""
                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf txtSource.Text = "MoneyDenomByDivision" Then
            ' By Dadang Adi H
            ' Senin, 01 Feb 2010, 00:48
            ' Place: Balikpapan
            Try
                '' modified by Kumar on jul 9 2010


                Dim report As CrMoneyDenominationByMandorBesar = New CrMoneyDenominationByMandorBesar()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRMoneyDenominationReportByMandorBesar'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & tmpMandorBesarID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRMoneyDenominationReport;1")
                FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "MONEY DENOMINATION SALARY FOR " & lTextmonth & ""
                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRRekapitulasiGajiKaryawanReport" Then
            Try
                Dim psEstateType As String

                psEstateType = JournalBOL.EstateTypeSelect()


                If psEstateType <> "M" Then


                    Dim report As CRRekapitulasiGajiKaryawanReport = New CRRekapitulasiGajiKaryawanReport()

                    Dim tblAdt As New Odbc.OdbcDataAdapter

                    Dim ds As New DataSet
                    Dim con As New Odbc.OdbcConnection
                    Dim cmd As New Odbc.OdbcCommand
                    Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                    con = New Odbc.OdbcConnection(constr)
                    con.Open()

                    cmd.Connection = con

                    cmd.CommandText = "Checkroll.CRRekapitulasiGajiKaryawanReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                    cmd.CommandType = CommandType.StoredProcedure
                    tblAdt.SelectCommand = cmd
                    tblAdt.Fill(ds, "CRRekapitulasiGajiKaryawanReport;1")
                    report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                    Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim strArray As String()
                    strArray = GlobalPPT.strEstateName.Split("-")
                    txtEstateName.Text = strArray(1)

                    Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim lTextmonth As String = String.Empty
                    Dim objCommonBOl As New GlobalBOL
                    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                    txtMonthYear.Text = "REKAPITULASI GAJI KARYAWAN FOR " & lTextmonth & ""
                    report.SetDataSource(ds.Tables(0))
                    CRV.ReportSource = report
                    CRV.ShowGroupTreeButton = True



                Else


                    Dim reportMill As CRRekapitulasiGajiKaryawanReportForMill = New CRRekapitulasiGajiKaryawanReportForMill()

                    Dim tblAdt As New Odbc.OdbcDataAdapter

                    Dim ds As New DataSet
                    Dim con As New Odbc.OdbcConnection
                    Dim cmd As New Odbc.OdbcCommand
                    Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                    con = New Odbc.OdbcConnection(constr)
                    con.Open()

                    cmd.Connection = con

                    cmd.CommandText = "Checkroll.CRRekapitulasiGajiKaryawanReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                    cmd.CommandType = CommandType.StoredProcedure
                    tblAdt.SelectCommand = cmd
                    tblAdt.Fill(ds, "CRRekapitulasiGajiKaryawanReport;1")
                    reportMill.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                    Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtEstateName = CType(reportMill.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim strArray As String()
                    strArray = GlobalPPT.strEstateName.Split("-")
                    txtEstateName.Text = strArray(1)

                    Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtMonthYear = CType(reportMill.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim lTextmonth As String = String.Empty
                    Dim objCommonBOl As New GlobalBOL
                    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                    txtMonthYear.Text = "REKAPITULASI GAJI KARYAWAN FOR " & lTextmonth & ""
                    reportMill.SetDataSource(ds.Tables(0))
                    CRV.ReportSource = reportMill
                    CRV.ShowGroupTreeButton = True

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Checkroll", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try



            'ElseIf txtSource.Text = "CRAnalysisHarvestingCostReport" Then
            '    ' By Dadang Adi H
            '    ' Selasa, 02 Feb 2010, 01:24
            '    ' Place: Balikpapan
            '    Try
            '        Dim report As CRAnalysisHarvestingCostReport = New CRAnalysisHarvestingCostReport()

            '        '' modified by Kumar on jul 9 2010

            '        Dim tblAdt As New Odbc.OdbcDataAdapter

            '        Dim ds As New DataSet
            '        Dim con As New Odbc.OdbcConnection
            '        Dim cmd As New Odbc.OdbcCommand
            '        Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
            '        con = New Odbc.OdbcConnection(constr)
            '        con.Open()

            '        cmd.Connection = con

            '        cmd.CommandText = "Checkroll.CRAnalysisHarvestingCostReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            '        cmd.CommandType = CommandType.StoredProcedure
            '        tblAdt.SelectCommand = cmd
            '        tblAdt.Fill(ds, "CRAnalysisHarvestingCostReport;1")
            '        'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
            '        'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
            '        'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
            '        'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
            '        report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            '        Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            '        txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '        Dim strArray As String()
            '        strArray = GlobalPPT.strEstateName.Split("-")
            '        txtEstateName.Text = strArray(1)

            '        Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            '        txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '        Dim lTextmonth As String = String.Empty
            '        Dim objCommonBOl As New GlobalBOL
            '        lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            '        txtMonthYear.Text = "ANALYSIS HARVESTING COST FOR " & lTextmonth & ""

            '        report.SetDataSource(ds.Tables(0))
            '        CRV.ReportSource = report
            '        CRV.ShowGroupTreeButton = True

            '        'Dim report As CRAnalysisHarvestingCostReport = New CRAnalysisHarvestingCostReport()

            '        'SelectCommand = New OdbcCommand()
            '        'SelectCommand.Connection = Conn
            '        'SelectCommand.CommandType = CommandType.StoredProcedure
            '        'SelectCommand.CommandText = "Checkroll.CRAnalysisHarvestingCostReport"

            '        'DS = New DataSet()

            '        'adapter = New OdbcDataAdapter()
            '        'adapter.SelectCommand = SelectCommand
            '        'adapter.Fill(DS)

            '        '' Setting
            '        'report.SetDataSource(DS)
            '        'SetDBLogonForReport(ci, report.Database.Tables)
            '        'CRV.ReportSource = report
            '        'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            '        'CRV.SelectionFormula = _
            '        '    "{CRAnalysisHarvestingCostReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
            '        '    "{CRAnalysisHarvestingCostReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"
            '    Catch ex As Exception
            '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    End Try

        ElseIf txtSource.Text = "CRAnalysisHarvestingCostReport" Then
            Try
                Dim report As CRAnalysisHarvestingCostReport2 = New CRAnalysisHarvestingCostReport2()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRAnalysisHarvestingCostReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure

                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "AnalyHarvestingCost;1")

                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"

                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)

                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "ANALYSIS HARVESTING COST FOR " & lTextmonth & ""


                'BINDING the records
                report.SetDataSource(ds.Tables(0))

                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

                'CRV.SelectionFormula = _
                '"{AnalyHarvestingCost.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                '"{AnalyHarvestingCost.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRAnalysisRubberCostReport" Then
            Try
                Dim report As CRAnalysisRubberCostReport = New CRAnalysisRubberCostReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRAnalysisRubberCostReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure

                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "AnalyHarvestingCost;1")

                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"

                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)

                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "ANALYSIS RUBBER COST FOR " & lTextmonth & ""

                'BINDING the records
                report.SetDataSource(ds.Tables(0))

                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

                'CRV.SelectionFormula = _
                '"{AnalyHarvestingCost.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                '"{AnalyHarvestingCost.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRMoneyDenominationAdvanceCheckrollReport" Then
            ' By Dadang Adi H
            ' Senin, 15 Feb 2010, 00:22
            ' Place: Kebun
            Try
                '' modified by Kumar on jul 9 2010


                Dim report As CRMoneyDenominationAdvanceCheckrollReport = New CRMoneyDenominationAdvanceCheckrollReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()


                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRMoneyDenominationAdvanceCheckrollReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRMoneyDenominationAdvanceCheckrollReport;1")
                FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)

                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "REQUEST ADVANCE SALARY MONEY KHL/KHT FOR " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True


                '    Dim report As CRMoneyDenominationAdvanceCheckrollReport = New CRMoneyDenominationAdvanceCheckrollReport()

                '    SelectCommand = New OdbcCommand()
                '    SelectCommand.Connection = Conn
                '    SelectCommand.CommandType = CommandType.StoredProcedure
                '    SelectCommand.CommandText = "Checkroll.CRMoneyDenominationAdvanceCheckrollReport"

                '    DS = New DataSet()

                '    adapter = New OdbcDataAdapter()
                '    adapter.SelectCommand = SelectCommand
                '    adapter.Fill(DS)

                '    ' Setting
                '    report.SetDataSource(DS)
                '    SetDBLogonForReport(ci, report.Database.Tables)
                '    CRV.ReportSource = report
                '    FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                '    ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                '    report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                '    report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                '    report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                '    CRV.SelectionFormula = _
                '        "{CRMoneyDenominationAdvanceCheckrollReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                '        "{CRMoneyDenominationAdvanceCheckrollReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRSlipAdvancePaymentReport" Then
            ' By Dadang Adi H
            ' Senin, 15 Feb 2010, 00:37
            ' Place: Kebun
            ' Slip pake store procedure yg sama utk Advance Payment yaitu: CRAdvancePaymentReport

            '' modified by Kumar on jul 9 2010

            Try

                Dim report As CRSlipAdvancePaymentReport = New CRSlipAdvancePaymentReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()


                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRAdvancePaymentReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                ' cmd.CommandText = "Checkroll.CRSlipAdvancePaymentReport'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRAdvancePaymentReport;1")
                FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "SLIP ADVANCE CHECKROLL FOR " & lTextmonth & ""



                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True


                'Try

                '    Dim report As CRSlipAdvancePaymentReport = New CRSlipAdvancePaymentReport()

                '    SelectCommand = New OdbcCommand()
                '    SelectCommand.Connection = Conn
                '    SelectCommand.CommandType = CommandType.StoredProcedure
                '    SelectCommand.CommandText = "Checkroll.CRAdvancePaymentReport"

                '    ds = New DataSet()

                '    adapter = New OdbcDataAdapter()
                '    adapter.SelectCommand = SelectCommand
                '    adapter.Fill(ds)

                '    ' Setting
                '    report.SetDataSource(ds)
                '    SetDBLogonForReport(ci, report.Database.Tables)
                '    CRV.ReportSource = report
                '    FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                '    ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                '    report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                '    report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                '    report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                '    CRV.SelectionFormula = _
                '        "{CRAdvancePaymentReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                '        "{CRAdvancePaymentReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"

                '    CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRRecapitulationPremiMandorAndKraniReport" Then
            ' By Dadang Adi H
            ' Senin, 22 Feb 2010, 17:40
            ' Place: Balikpapan
            Try
                Dim report As CRRecapitulationPremiMandorAndKraniReport = New CRRecapitulationPremiMandorAndKraniReport()

                '' modified by Kumar on jul 9 2010

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRRecapitulationPremiMandorAndKraniReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRRecapitulationPremiMandorAndKraniReport;1")
                'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)



                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "RECAPITULATION PREMI MANDOR AND KRANI FOR " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True


                'Dim report As CRRecapitulationPremiMandorAndKraniReport = New CRRecapitulationPremiMandorAndKraniReport()

                'SelectCommand = New OdbcCommand()
                'SelectCommand.Connection = Conn
                'SelectCommand.CommandType = CommandType.StoredProcedure
                'SelectCommand.CommandText = "Checkroll.CRRecapitulationPremiMandorAndKraniReport"

                'DS = New DataSet()

                'adapter = New OdbcDataAdapter()
                'adapter.SelectCommand = SelectCommand
                'adapter.Fill(DS)

                '' Setting
                'report.SetDataSource(DS)
                'SetDBLogonForReport(ci, report.Database.Tables)
                'CRV.ReportSource = report
                'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                'CRV.SelectionFormula = _
                '    "{CRRecapitulationPremiMandorAndKraniReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                '    "{CRRecapitulationPremiMandorAndKraniReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRRekapPremiMandorKeraniDeres" Then
            Try
                Dim report As CRRekapPremiMandorKeraniDeres = New CRRekapPremiMandorKeraniDeres()
                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRRecapitulationPremiMandorAndKraniDeresReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRRecapitulationPremiMandorAndKraniDeresReport;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)



                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "RECAPITULATION PREMI MANDOR AND KRANI DERES FOR " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True
                
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "RekapPremiMandor" Then
            Try
                Dim report As RekapPremiMandorBesar = New RekapPremiMandorBesar()
                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.RekapPremiMandorBesar'" & GlobalPPT.strActMthYearID & "','" & GlobalPPT.strEstateID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "RekapPremiMandorBesar;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)



                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "RECAPITULATION Premi Mandor Besar " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "PrintPanenReport" Then
            Try
                Dim report As PrintTeamPanen = New PrintTeamPanen()
                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRPanenTeamPrint'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','Panen'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "PrintTeamPanen;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf txtSource.Text = "PrintDeresReport" Then
            Try
                Dim report As PrintTeamDeres = New PrintTeamDeres()
                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRPanenTeamPrint'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','Deres'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "PrintTeamPanen;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf txtSource.Text = "PrintLainReport" Then
            Try
                Dim report As PrintTeamLain = New PrintTeamLain()
                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRPanenTeamPrint'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','Lain'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "PrintTeamLain;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRAdvanceRiceReport" Then
            ' By Dadang Adi H
            ' Senin, 22 Feb 2010, 17:54
            ' Place: Balikpapan
            Try
                Dim report As CRAdvanceRiceReport = New CRAdvanceRiceReport()

                '' modified by Kumar on jul 9 2010

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRAdvanceRiceReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRAdvanceRiceReport;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "ADVANCE RICE REPORT FOR " & lTextmonth & ""



                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True



                'Dim report As CRAdvanceRiceReport = New CRAdvanceRiceReport()

                'SelectCommand = New OdbcCommand()
                'SelectCommand.Connection = Conn
                'SelectCommand.CommandType = CommandType.StoredProcedure
                'SelectCommand.CommandText = "Checkroll.CRAdvanceRiceReport"

                'DS = New DataSet()

                'adapter = New OdbcDataAdapter()
                'adapter.SelectCommand = SelectCommand
                'adapter.Fill(DS)

                '' Setting
                'report.SetDataSource(DS)
                'SetDBLogonForReport(ci, report.Database.Tables)
                'CRV.ReportSource = report
                'report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                'CRV.SelectionFormula = _
                '    "{CRAdvanceRiceReport;1.EstateID} ='" + GlobalPPT.strEstateID + "' AND " + _
                '    "{CRAdvanceRiceReport;1.ActiveMonthYearID} ='" + ActiveMonthYearID + "'"

                'CRV.ShowGroupTreeButton = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRSlipSalaryReport" Then
            Try
                Dim psEstateType As String

                psEstateType = JournalBOL.EstateTypeSelect()


                If psEstateType <> "M" Then
                    Dim report As CRSlipSalaryReport = New CRSlipSalaryReport()

                    Dim tblAdt As New Odbc.OdbcDataAdapter

                    Dim ds As New DataSet
                    Dim con As New Odbc.OdbcConnection
                    Dim cmd As New Odbc.OdbcCommand
                    Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                    con = New Odbc.OdbcConnection(constr)
                    con.Open()

                    cmd.Connection = con

                    cmd.CommandText = "Checkroll.CRSalaryReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                    cmd.CommandType = CommandType.StoredProcedure
                    tblAdt.SelectCommand = cmd
                    tblAdt.Fill(ds, "CRSalaryReport;1")
                    FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                    ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                    report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                    report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                    report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                    Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim strArray As String()
                    strArray = GlobalPPT.strEstateName.Split("-")
                    txtEstateName.Text = strArray(1)


                    Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim lTextmonth As String = String.Empty
                    Dim objCommonBOl As New GlobalBOL
                    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                    txtMonthYear.Text = " SLIP SALARY CHECKROLL FOR KHT/KHL " & lTextmonth & ""


                    report.SetDataSource(ds.Tables(0))
                    CRV.ReportSource = report
                    CRV.ShowGroupTreeButton = True

                Else
                    Dim reportmill As CRSlipSalaryReportForMILL = New CRSlipSalaryReportForMILL()


                    '  Dim report As CRSlipSalaryReport = New CRSlipSalaryReport()

                    Dim tblAdt As New Odbc.OdbcDataAdapter

                    Dim ds As New DataSet
                    Dim con As New Odbc.OdbcConnection
                    Dim cmd As New Odbc.OdbcCommand
                    Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                    con = New Odbc.OdbcConnection(constr)
                    con.Open()

                    cmd.Connection = con

                    cmd.CommandText = "Checkroll.CRSalaryReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                    cmd.CommandType = CommandType.StoredProcedure
                    tblAdt.SelectCommand = cmd
                    tblAdt.Fill(ds, "CRSalaryReport;1")
                    FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                    ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                    reportmill.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                    reportmill.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                    reportmill.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                    Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtEstateName = CType(reportmill.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim strArray As String()
                    strArray = GlobalPPT.strEstateName.Split("-")
                    txtEstateName.Text = strArray(1)


                    Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                    txtMonthYear = CType(reportmill.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    Dim lTextmonth As String = String.Empty
                    Dim objCommonBOl As New GlobalBOL
                    lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                    txtMonthYear.Text = " SLIP SALARY CHECKROLL FOR KHT/KHL " & lTextmonth & ""


                    reportmill.SetDataSource(ds.Tables(0))
                    CRV.ReportSource = reportmill
                    CRV.ShowGroupTreeButton = True


                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Checkroll", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try



        ElseIf txtSource.Text = "CRPieceRateReport" Then
            Try
                Dim report As PieceRateReport = New PieceRateReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()


                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRPieceRateReport'" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRPieceRateReport;1")
                report.SetDataSource(ds.Tables(0))

                'CRV.SelectionFormula = txtFormula.Text

                CRV.ReportSource = report


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' By Dadang Adi H
            ' Senin, 22 Feb 2010, 18:00
            ' Place: Balikpapan
            '
            ' Store procedure yg dipake sama dgn Salary Report yaitu : CRSalaryReport

        ElseIf txtSource.Text = "CRSlipTHRPaymentReport" Then
            'stanley@24-11-2011
            Try
                Dim report As CRSlipTHRPaymentReport = New CRSlipTHRPaymentReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()

                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRTHRPaymentReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRTHRPaymentReport;1")
                'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = " SLIP THR FOR " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        ElseIf txtSource.Text = "CRMoneyDenominationTHRReport" Then
            'stanley@24-11-2011
            Try
                Dim report As CRMoneyDenominationTHRReport = New CRMoneyDenominationTHRReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()


                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRMoneyDenominationTHRReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRMoneyDenominationTHRReport;1")
                'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
                'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
                'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
                'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)

                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "MONEY DENOMINATION THR ALL TEAM FOR " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))
                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CREmpAllowanceDeductionReport" Then
            ' By Dadang Adi H
            ' Selasa, 23 Feb 2010, 11:02
            ' Place: Balikpapan
            ' Listing Report: CREmpAllowanceDeductionReport
            Try

                Dim report As CREmpAllowanceDeductionReport = New CREmpAllowanceDeductionReport()

                SelectCommand = New OdbcCommand()
                SelectCommand.Connection = Conn
                SelectCommand.CommandType = CommandType.StoredProcedure
                SelectCommand.CommandText = "[Checkroll].[CREmpAllowanceDeductionReport]"

                DS = New DataSet()

                adapter = New OdbcDataAdapter()
                adapter.SelectCommand = SelectCommand
                adapter.Fill(DS, "CREmpAllowanceDeductionReport;1")

                ' Setting
                report.SetDataSource(DS.Tables(0))
                SetDBLogonForReport(ci, report.Database.Tables)
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                CRV.ReportSource = report
                CRV.SelectionFormula = _Formula

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf txtSource.Text = "CRDailyReceptionWithTeamByGangReport" Then
            ' By Naxim
            ' on 10 Oct 2013
            Try

                Dim report As CRDailyReceptionWithTeamByGangeReport = New CRDailyReceptionWithTeamByGangeReport()

                SelectCommand = New OdbcCommand()
                SelectCommand.Connection = Conn
                SelectCommand.CommandType = CommandType.StoredProcedure
                'SelectCommand.CommandText = "[Checkroll].[CRDailyReceiptionWithTeamByGangeReport]"
                SelectCommand.CommandText = _Formula

                DS = New DataSet()

                adapter = New OdbcDataAdapter()
                adapter.SelectCommand = SelectCommand
                adapter.Fill(DS, "CRDailyReceptionWithTeamByGangReport;1")

                ' Setting
                report.SetDataSource(DS.Tables(0))
                SetDBLogonForReport(ci, report.Database.Tables)
                CRV.ReportSource = report

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRCensusReport" Then
            ' By Dadang Adi H
            ' Selasa, 23 Feb 2010, 13:33
            ' Place: Balikpapan
            ' Listing Report: CRCensusReport
            Try

                Dim report As CRCensusReport = New CRCensusReport()

                SelectCommand = New OdbcCommand()
                SelectCommand.Connection = Conn
                SelectCommand.CommandType = CommandType.StoredProcedure
                SelectCommand.CommandText = "[Checkroll].[CRCensusReport]"

                DS = New DataSet()

                adapter = New OdbcDataAdapter()
                adapter.SelectCommand = SelectCommand
                adapter.Fill(DS)

                ' Setting
                report.SetDataSource(DS)
                SetDBLogonForReport(ci, report.Database.Tables)
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                CRV.ReportSource = report
                CRV.SelectionFormula = _Formula

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "CRDAReport" Then

            ''Modified by kumar

            Dim report As CRDAReport = New CRDAReport()

            Dim tblAdt As New Odbc.OdbcDataAdapter


            Dim con As New SqlConnection()
            Dim cmd As New SqlCommand()
            Dim constr As String = Common_PPT.GlobalPPT.ConnectionString
            con = New SqlConnection(constr)
            con.Open()

            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "Checkroll.CRDAReport"
            
            Dim eid As SqlParameter = cmd.Parameters.Add("@EstateID", SqlDbType.NVarChar, 50)
            eid.Value = GlobalPPT.strEstateID
            Dim mon As SqlParameter = cmd.Parameters.Add("@ActiveMonthYearID", SqlDbType.NVarChar, 50)
            mon.Value = GlobalPPT.strActMthYearID
            cmd.CommandTimeout = 1800
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
            'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
            'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
            'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
            report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)


            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "DAILY ATTENDANCE REPORT FOR " & lTextmonth & ""


            report.SetDataSource(ds.Tables(0))
            CRV.ReportSource = report



        ElseIf txtSource.Text = "CRDAMandor" Then

            ''Modified by kumar

            Dim report As CRDAMandor = New CRDAMandor()

            Dim tblAdt As New Odbc.OdbcDataAdapter


            Dim con As New SqlConnection()
            Dim cmd As New SqlCommand()
            Dim constr As String = Common_PPT.GlobalPPT.ConnectionString
            con = New SqlConnection(constr)
            con.Open()

            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "Checkroll.CRDAReportMandor"

            Dim eid As SqlParameter = cmd.Parameters.Add("@EstateID", SqlDbType.NVarChar, 50)
            eid.Value = GlobalPPT.strEstateID
            Dim mon As SqlParameter = cmd.Parameters.Add("@ActiveMonthYearID", SqlDbType.NVarChar, 50)
            mon.Value = GlobalPPT.strActMthYearID
            cmd.CommandTimeout = 1800
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            'FromDT = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
            'ToDT = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
            'report.DataDefinition.FormulaFields("FromDT").Text = "'" + FromDT + "'"
            'report.DataDefinition.FormulaFields("ToDT").Text = "'" + ToDT + "'"
            report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)


            Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
            txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim lTextmonth As String = String.Empty
            Dim objCommonBOl As New GlobalBOL
            lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
            txtMonthYear.Text = "DAILY ATTENDANCE MANDOR BESAR / MANDOR / KERANI REPORT FOR " & lTextmonth & ""


            report.SetDataSource(ds.Tables(0))
            CRV.ReportSource = report



        ElseIf txtSource.Text = "CRRekapLapMandorLainReport" Then
            
            Try

                Dim report As CRRekapLapMandorLainReport = New CRRekapLapMandorLainReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()


                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRRekapLapMandorLainReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRRekapLapMandorLainReport;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "REKAP LAPORAN MANDOR LAIN-LAIN " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))

                CRV.SelectionFormula = txtFormula.Text

                CRV.ReportSource = report


               
                'CRV.ShowGroupTreeButton = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf txtSource.Text = "RekapSalarySignature" Then
            Try

                Dim report As CRSalarySignature = New CRSalarySignature()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()


                cmd.Connection = con

                cmd.CommandText = "Checkroll.CRRekapPengajian'" & GlobalPPT.strActMthYearID & "','" & GlobalPPT.strEstateID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRTHRPaymentReport;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "REKAP PENGGAJIAN KARYAWAN " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))

                CRV.SelectionFormula = txtFormula.Text

                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf txtSource.Text = "CRBonusPaymentReport" Then
            Try

                Dim report As CRBonusPaymentReport = New CRBonusPaymentReport()

                Dim tblAdt As New Odbc.OdbcDataAdapter

                Dim ds As New DataSet
                Dim con As New Odbc.OdbcConnection
                Dim cmd As New Odbc.OdbcCommand
                Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"
                con = New Odbc.OdbcConnection(constr)
                con.Open()


                cmd.Connection = con

                cmd.CommandText = "Checkroll. CRBonusPaymentReport'" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
                cmd.CommandType = CommandType.StoredProcedure
                tblAdt.SelectCommand = cmd
                tblAdt.Fill(ds, "CRTHRPaymentReport;1")
                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
                Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
                txtEstateName = CType(report.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim strArray As String()
                strArray = GlobalPPT.strEstateName.Split("-")
                txtEstateName.Text = strArray(1)


                Dim txtMonthYear As CrystalDecisions.CrystalReports.Engine.TextObject
                txtMonthYear = CType(report.ReportDefinition.ReportObjects.Item("txtMonthYear"), CrystalDecisions.CrystalReports.Engine.TextObject)
                Dim lTextmonth As String = String.Empty
                Dim objCommonBOl As New GlobalBOL
                lTextmonth = objCommonBOl.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intActiveYear, GlobalPPT.strLang)
                txtMonthYear.Text = "REKAP BAYARAN BONUS " & lTextmonth & ""


                report.SetDataSource(ds.Tables(0))

                CRV.SelectionFormula = txtFormula.Text

                CRV.ReportSource = report
                CRV.ShowGroupTreeButton = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        'If txtSource.Text = "DailyAttendance" Then
        '    '=============================================
        '    'SOURCE From DailyAttendance Screen
        '    '=============================================
        '    Dim rpt As New DailyAttendance
        '    Dim tblAdt As New Odbc.OdbcDataAdapter
        '    Dim ds As New DataSet
        '    cmd.Connection = con

        '    cmd.CommandText = "Checkroll.CRDANoTeamReport"
        '    cmd.CommandType = CommandType.StoredProcedure
        '    tblAdt.SelectCommand = cmd
        '    tblAdt.Fill(ds, "DailyAttendance;1")
        '    rpt.SetDataSource(ds)
        '    txtFormula.Text = _Formula
        '    Crv.SelectionFormula = txtFormula.Text

        '    Crv.ReportSource = rpt
        '    Crv.RefreshReport()
        'End If

        'If txtSource.Text = "Salary" Then
        '    '=============================================
        '    'SOURCE From DailyAttendance Screen
        '    '=============================================
        '    Dim rpt As New SalaryReport
        '    Dim tblAdt As New Odbc.OdbcDataAdapter
        '    Dim ds As New DataSet
        '    cmd.Connection = con

        '    cmd.CommandText = "Checkroll.CRSalaryReport"
        '    cmd.CommandType = CommandType.StoredProcedure
        '    tblAdt.SelectCommand = cmd
        '    tblAdt.Fill(ds, "SalaryReport;1")
        '    rpt.SetDataSource(ds)
        '    txtFormula.Text = _Formula
        '    Crv.SelectionFormula = txtFormula.Text
        '    'BATAS


        '    'cryRpt.Load((Application.StartupPath & "\Reports\SalaryReport.rpt"))
        '    'cryRpt.SetDatabaseLogon(strServerUserName, strServerPassword, strDatasource, strDataBase)
        '    'BATAS
        '    Crv.ReportSource = rpt
        '    'BATAS
        '    Crv.RefreshReport()
        'End If

        'If txtSource.Text = "DetailPremiReport" Then
        '    '=============================================
        '    'SOURCE From DailyAttendance Screen
        '    '=============================================

        '    Dim rpt As New DetPremiPanen
        '    Dim tblAdt As New Odbc.OdbcDataAdapter
        '    Dim ds As New DataSet
        '    cmd.Connection = con

        '    cmd.CommandText = "Checkroll.DetailPremiReport"
        '    cmd.CommandType = CommandType.StoredProcedure
        '    tblAdt.SelectCommand = cmd
        '    tblAdt.Fill(ds, "DetailPremiReport;1")
        '    rpt.SetDataSource(ds)
        '    txtFormula.Text = _Formula
        '    Crv.SelectionFormula = txtFormula.Text
        '    'BATAS

        '    'cryRpt.Load((Application.StartupPath & "\Reports\DetPremiPanen.rpt"))
        '    'cryRpt.SetDatabaseLogon(strServerUserName, strServerPassword, strDatasource, strDataBase)
        '    'BATAS
        '    Crv.ReportSource = rpt
        '    'BATAS
        '    Crv.RefreshReport()

        'End If

        '' By Dadang Adi
        '' Selasa, 24 Nov 2009, 13:43
        'If txtSource.Text = "AttendanceSumReport.rpt" Then
        '    Dim rd As New ReportDocument
        '    Dim conn As New SqlClient.SqlConnection
        '    Dim command As New OdbcCommand 'SqlClient.SqlCommand ' 3 Des 2009
        '    Dim adapter As New OdbcDataAdapter 'SqlClient.SqlDataAdapter
        '    Dim dt As New DataTable


        '    'conn.ConnectionString = ConfigurationManager.ConnectionStrings("BSP").ConnectionString()
        '    cmd.Connection = con
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.CommandText = "[Checkroll].[AttendanceSumReport]"

        '    adapter.SelectCommand = cmd
        '    adapter.Fill(dt)

        '    Dim reportPath As String

        '    reportPath = Application.StartupPath + "\Checkroll\Report\" + txtSource.Text
        '    rd.Load(reportPath)
        '    'SetDBLogonForReport(myConnectionInfo, rd)

        '    Crv.ReportSource = rd
        '    Crv.SelectionFormula = _Formula
        '    Crv.RefreshReport()
        'End If
        '' END Selasa, 24 Nov 2009, 13:43

    End Sub

    Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo, _
                                    ByVal paramTables As CrystalDecisions.CrystalReports.Engine.Tables)
        ' By DADANG
        ' Thursday, 10 Dec 2009, 17:17
        Dim myTables As Tables = paramTables


        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables

            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo

            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CRV.PrintReport()
    End Sub

    Private Sub CRV_ReportRefresh(ByVal source As System.Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CRV.ReportRefresh
        ' By Dadang Adi Hendradi
        ' Jum'at, 19 Mar 2010, 11:28
        Dim EstateIDParameterValues As New CrystalDecisions.Shared.ParameterValues()
        Dim ActiveMonthYearIDParameterValues As New CrystalDecisions.Shared.ParameterValues()
        Dim EstateIDDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim ActiveMonthYearIDDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim pFields As New CrystalDecisions.Shared.ParameterFields
        Dim pField As CrystalDecisions.Shared.ParameterField

        If txtSource.Text = "CRDAReport" Then
            Try
                ci.ServerName = oDSN
                ci.DatabaseName = oDatabase
                ci.UserID = oUserName
                ci.Password = oPwd

                Dim report As CRDAReport = New CRDAReport()

                SetDBLogonForReport(ci, report.Database.Tables)
                CRV.ReportSource = report

                EstateIDDiscreteValue.Value = GlobalPPT.strEstateID '"M1";
                EstateIDParameterValues.Add(EstateIDDiscreteValue)

                ActiveMonthYearIDDiscreteValue.Value = ActiveMonthYearID '"01R10";
                ActiveMonthYearIDParameterValues.Add(ActiveMonthYearIDDiscreteValue)

                pField = CRV.ParameterFieldInfo("@EstateID")
                pField.CurrentValues = EstateIDParameterValues
                pFields.Add(pField)

                pField = CRV.ParameterFieldInfo("@ActiveMonthYearID")
                pField.CurrentValues = ActiveMonthYearIDParameterValues
                pFields.Add(pField)

                CRV.ParameterFieldInfo = pFields

                report.DataDefinition.FormulaFields("FUserName").Text = "'" + ReportUserName + "'"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Checkroll Report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub
End Class