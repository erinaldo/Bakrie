Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_DAL
Imports Common_PPT
Imports System.Configuration

Public Class VehicleViewReportInTabRpt

    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty
    Dim _GlobalBOL As New GlobalBOL
    Public strReportName As String

    Private Sub VehicleViewReportInTabRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'VehicleFarmTractorHEVehicleRunningLog.SelectTab(1)
        'VehicleFarmTractorHEVehicleRunningLog.SelectTab(0)
        'VehicleFarmTractorHEVehicleRunningLog.SelectedIndex = 0

        'VehicleFarmTractorHEVehicleRunningLog.Height = Me.Height
        'VehicleFarmTractorHEVehicleRunningLog.Width = Me.Width

        VehicleFarmTractorHEVehicleRunningLogReportFrm.Cursor = Cursors.WaitCursor
        VehicleFarmTractorHEVehicleRunningLogRpt()
        VehicleFarmTractorHEVehicleRunningLogReportFrm.Cursor = Cursors.Arrow


        'InternalTransferNoteInReport()
        'InternalTransferNoteOutReport()

    End Sub
    'Private Sub VehicleViewReportInTabRpt_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.FormClosed

    'End Sub



    Private Sub InternalTransferNoteInReport()

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New InternalTransferNoteRpt
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim dsRunningLogReport As New DataSet
        cmd.Connection = con

        cmd.CommandText = "[Store].[InternalTransferNoteReportGet] '" & GlobalPPT.strEstateID & "','" & "01R22" & "','" & "IN" & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsRunningLogReport, "InternalTransferNoteReportGet;1")

        Dim txtEstate, txtFromDate, txtToDate, txtFiscal, txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject

        txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        txtFiscal.Text = "TRANSFER NOTE IN " & _GlobalBOL.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intLoginYear, GlobalPPT.strLang)
        txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
        txtFromDate.Text = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
        txtToDate.Text = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")

        'If dsRunningLogReport.Tables(0).Rows.Count > 0 Then

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@EstateID"
        ParamterDescreteValue1.Value = GlobalPPT.strEstateID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue2.Value = "01R22"
        ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField2)
        crvVehFarmTractorHeVegRunninglog.ParameterFieldInfo = ParamterFields

        ParamterField3.ParameterFieldName = "@InOrOut"
        ParamterDescreteValue3.Value = "IN"
        ParamterField3.CurrentValues.Add(ParamterDescreteValue3)
        ParamterFields.Add(ParamterField3)
        crvVehFarmTractorHeVegRunninglog.ParameterFieldInfo = ParamterFields

        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(dsRunningLogReport)
        crvVehFarmTractorHeVegRunninglog.ReportSource = rpt
        'End If
    End Sub

    Private Sub InternalTransferNoteOutReport()

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New InternalTransferNoteRpt
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim dsRunningLogReport As New DataSet
        cmd.Connection = con

        cmd.CommandText = "[Store].[InternalTransferNoteReportGet] '" & GlobalPPT.strEstateID & "','" & "01R22" & "','" & "IN" & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsRunningLogReport, "InternalTransferNoteReportGet;1")

        Dim txtEstate, txtFromDate, txtToDate, txtFiscal, txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject

        txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        txtFiscal.Text = "TRANSFER NOTE OUT " & _GlobalBOL.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intLoginYear, GlobalPPT.strLang)
        txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
        txtFromDate.Text = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
        txtToDate.Text = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")

        'If dsRunningLogReport.Tables(0).Rows.Count > 0 Then

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@EstateID"
        ParamterDescreteValue1.Value = GlobalPPT.strEstateID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue2.Value = "01R22"
        ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField2)
        crvVehFarmTractorHeVegRunninglog.ParameterFieldInfo = ParamterFields

        ParamterField3.ParameterFieldName = "@InOrOut"
        ParamterDescreteValue3.Value = "Out"
        ParamterField3.CurrentValues.Add(ParamterDescreteValue3)
        ParamterFields.Add(ParamterField3)
        crvVehFarmTractorHeVegRunninglog.ParameterFieldInfo = ParamterFields

        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(dsRunningLogReport)
        crvVehFarmTractorHeVegRunninglog.ReportSource = rpt
        'End If
    End Sub

    Private Sub VehicleFarmTractorHEVehicleRunningLogRpt()

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New VehicleFarmTractorHEVehicleRunningLogReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim dsRunningLogReport As New DataSet
        cmd.Connection = con

        cmd.CommandText = "[Vehicle].[VehicleRunningLogReportGet] '" & GlobalPPT.strEstateID & "','" & VehicleFarmTractorHEVehicleRunningLogReportFrm.strActMthYearID & "'" '& "','" & GlobalPPT.IntActiveMonth & "','" & GlobalPPT.intActiveYear & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsRunningLogReport, "VehicleRunningLogReportGet;1")

        Dim txtEstate, txtFromDate, txtToDate, txtFiscal, txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject

        txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        'txtFiscal.Text = "VEHICLE, FARM TRACTOR, HE, VEHICLE RUNNING LOG " & General.MonthYear(GlobalPPT.IntActiveMonth) & " " & GlobalPPT.intActiveYear.ToString() '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
        txtFiscal.Text = "VEHICLE RUNNING LOG " & _GlobalBOL.PMonthName(VehicleFarmTractorHEVehicleRunningLogReportFrm.strmonth, VehicleFarmTractorHEVehicleRunningLogReportFrm.strYear, GlobalPPT.strLang)
        txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
        txtFromDate.Text = VehicleFarmTractorHEVehicleRunningLogReportFrm.strFiscalYearFromDate
        txtToDate.Text = VehicleFarmTractorHEVehicleRunningLogReportFrm.strFiscalYearToDate

        'If dsRunningLogReport.Tables(0).Rows.Count > 0 Then

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@EstateID"
        ParamterDescreteValue1.Value = GlobalPPT.strEstateID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@ActiveMonthYearID"
        'ParamterDescreteValue2.Value = "01R22"
        ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField2)
        crvVehFarmTractorHeVegRunninglog.ParameterFieldInfo = ParamterFields

        'ParamterField2.ParameterFieldName = "@LogedInMonth"
        'ParamterDescreteValue2.Value = GlobalPPT.IntActiveMonth
        'ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
        'ParamterFields.Add(ParamterField2)
        'crvVehFarmTractorHeVegRunninglog.ParameterFieldInfo = ParamterFields

        'ParamterField3.ParameterFieldName = "@LogedInYear"
        'ParamterDescreteValue3.Value = GlobalPPT.intActiveYear
        'ParamterField3.CurrentValues.Add(ParamterDescreteValue3)
        'ParamterFields.Add(ParamterField3)

        crvVehFarmTractorHeVegRunninglog.ParameterFieldInfo = ParamterFields

        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(dsRunningLogReport)
        crvVehFarmTractorHeVegRunninglog.ReportSource = rpt
        'End If

    End Sub

    Private Function RunningVehicleReportCalculation(ByVal dsRunningVehicle As DataSet) As DataSet

        Dim local As String

        For r As Integer = 0 To dsRunningVehicle.Tables(0).Rows.Count - 1
            For c As Integer = 4 To dsRunningVehicle.Tables(0).Columns.Count - 2
                If Not IsDBNull(dsRunningVehicle.Tables(0).Rows(r)(c)) Then

                    local = Convert.ToString(dsRunningVehicle.Tables(0).Rows(r)(c))
                    local = (local.Substring(0, local.LastIndexOf("."))).Replace(".", ".")
                    dsRunningVehicle.Tables(0).Rows(r)(c) = Format(Convert.ToDecimal(local), "0,0.0,0").Replace(".", ".")

                End If
            Next
        Next

        'Start Calculate the Total
        Dim sec, row, column As Integer
        Dim dsRunningVehicleData As DataSet = New DataSet

        dsRunningVehicleData.Tables.Add(dsRunningVehicle.Tables(0).Clone)

        'Move redunt rows as a single row
        For row = 0 To dsRunningVehicle.Tables(0).Rows.Count - 1
            If dsRunningVehicleData.Tables(0).Rows.Count = 0 Then
                dsRunningVehicleData.Tables(0).ImportRow(dsRunningVehicle.Tables(0).Rows(row))
                dsRunningVehicleData.Tables(0).AcceptChanges()
            ElseIf dsRunningVehicleData.Tables(0).Rows(dsRunningVehicleData.Tables(0).Rows.Count - 1)(0) <> dsRunningVehicle.Tables(0).Rows(row)(0) Or dsRunningVehicleData.Tables(0).Rows(dsRunningVehicleData.Tables(0).Rows.Count - 1)(1) <> dsRunningVehicle.Tables(0).Rows(row)(1) Then
                dsRunningVehicleData.Tables(0).ImportRow(dsRunningVehicle.Tables(0).Rows(row))
                dsRunningVehicleData.Tables(0).AcceptChanges()
            Else
                For column = 0 To dsRunningVehicle.Tables(0).Columns.Count - 2

                    Dim time As String = Convert.ToString(dsRunningVehicle.Tables(0).Rows(row)(column))

                    If time <> String.Empty And time <> "00:00" Then

                        'Dim dd As String = dsRunningVehicle.Tables(0).Rows(row)(column)

                        'dsRunningVehicleData.Tables(0).Rows(dsRunningVehicleData.Tables(0).Rows.Count - 1)(column) = Format(Convert.ToDecimal(dsRunningVehicle.Tables(0).Rows(row)(column)), "0,0.0,0")
                        dsRunningVehicleData.Tables(0).Rows(dsRunningVehicleData.Tables(0).Rows.Count - 1)(column) = dsRunningVehicle.Tables(0).Rows(row)(column)
                        dsRunningVehicleData.Tables(0).AcceptChanges()
                    End If
                Next
            End If
        Next

        'Add by row
        Dim s As Int32 = dsRunningVehicleData.Tables(0).Rows.Count
        For row = 0 To dsRunningVehicleData.Tables(0).Rows.Count - 1
            'Since the last column in total we subtract by 2
            For column = 5 To dsRunningVehicleData.Tables(0).Columns.Count - 2
                If Convert.ToString(dsRunningVehicleData.Tables(0).Rows(row)(column)) <> String.Empty Then
                    Dim strArray() As String = Convert.ToString(dsRunningVehicleData.Tables(0).Rows(row)(column)).Split(".")
                    'Get the time into seconds and add the seconds
                    sec = sec + TimeSpan.FromHours(Convert.ToDouble(strArray(0))).TotalSeconds + TimeSpan.FromMinutes(Convert.ToDouble(strArray(1))).TotalSeconds

                End If
            Next

            Dim lsDays As String

            If Convert.ToString(TimeSpan.FromSeconds(sec)).Contains(".") Then
                lsDays = Convert.ToString(TimeSpan.FromSeconds(sec)).Substring(0, Convert.ToString(TimeSpan.FromSeconds(sec)).IndexOf("."))
                lsDays = Convert.ToString((Convert.ToInt32(lsDays) * 24) + TimeSpan.FromSeconds(sec).Hours).PadLeft(2, "0") + "." + Convert.ToString(TimeSpan.FromSeconds(sec).Minutes).PadLeft(2, "0")
            Else
                lsDays = Convert.ToString(TimeSpan.FromSeconds(sec).Hours).PadLeft(2, "0") + "." + Convert.ToString(TimeSpan.FromSeconds(sec).Minutes).PadLeft(2, "0")
            End If

            dsRunningVehicleData.Tables(0).Rows(row)(column) = Format(Convert.ToDecimal(lsDays), "0,0.0,0")

            sec = 0

        Next

        dsRunningVehicleData.Tables(0).Rows.Add(dsRunningVehicleData.Tables(0).NewRow)

        'Add by Column

        For column = 5 To dsRunningVehicleData.Tables(0).Columns.Count - 1
            For row = 0 To (dsRunningVehicleData.Tables(0).Rows.Count - 2)
                If Convert.ToString(dsRunningVehicleData.Tables(0).Rows(row)(column)) <> String.Empty Then
                    Dim strArray() As String
                    If (dsRunningVehicleData.Tables(0).Columns.Count - 1) <> column Then
                        strArray = Convert.ToString(dsRunningVehicleData.Tables(0).Rows(row)(column)).Split(".")
                    Else
                        strArray = Convert.ToString(dsRunningVehicleData.Tables(0).Rows(row)(column)).Split(".")
                    End If
                    sec = sec + TimeSpan.FromHours(Convert.ToDouble(strArray(0))).TotalSeconds + TimeSpan.FromMinutes(Convert.ToDouble(strArray(1))).TotalSeconds
                End If
            Next

            Dim lsDays As String

            If Convert.ToString(TimeSpan.FromSeconds(sec)).Contains(".") Then
                lsDays = Convert.ToString(TimeSpan.FromSeconds(sec)).Substring(0, Convert.ToString(TimeSpan.FromSeconds(sec)).IndexOf("."))
                lsDays = Convert.ToString((Convert.ToInt32(lsDays) * 24) + TimeSpan.FromSeconds(sec).Hours) + "." + Format(TimeSpan.FromSeconds(sec).Minutes, "0,0")
            Else
                lsDays = Convert.ToString(TimeSpan.FromSeconds(sec).Hours) + "." + Format(TimeSpan.FromSeconds(sec).Minutes, "0,0")
            End If

            If Format(Convert.ToDecimal(lsDays), "0,0.0,0") <> "00.00" Then

                Dim J As Int16 = dsRunningVehicleData.Tables(0).Rows.Count

                dsRunningVehicleData.Tables(0).Rows(row)(column) = Format(Convert.ToDecimal(lsDays), "0,0.0,0")
            End If

            sec = 0

        Next

        column = dsRunningVehicleData.Tables(0).Columns.Count

        Dim dt As DataTable = dsRunningVehicleData.Tables(0)

        'Add text "Total" at the end of the row
        If dsRunningVehicleData.Tables(0).Rows.Count > 0 Then
            dsRunningVehicleData.Tables(0).Rows(dsRunningVehicleData.Tables(0).Rows.Count - 1)(1) = "Total"
            dsRunningVehicleData.Tables(0).AcceptChanges()
        End If


        Return dsRunningVehicleData

    End Function

    Private Function RekapitulasiJamBengkelsReportCalculation(ByVal dsRekapitulasiJamBengkel As DataSet) As DataSet

        'dsRekapitulasiJamBengkel.Tables(0).Columns.Add("Total")

        Dim row As Integer
        Dim column As Integer

        Dim sec As Integer
        sec = 0

        For row = 0 To dsRekapitulasiJamBengkel.Tables(0).Rows.Count - 1
            For column = 4 To dsRekapitulasiJamBengkel.Tables(0).Columns.Count - 2
                If Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)) <> String.Empty Then
                    Dim strArray() As String = Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)).Split(":")

                    sec = sec + TimeSpan.FromHours(Convert.ToDouble(strArray(0))).TotalSeconds + TimeSpan.FromMinutes(Convert.ToDouble(strArray(1))).TotalSeconds

                End If
            Next

            'dsRekapitulasiJamBengkelData.Tables(0).Rows(row)(column) = Convert.ToString(TimeSpan.FromSeconds(sec))

            Dim lsDays As String

            If Convert.ToString(TimeSpan.FromSeconds(sec)).Contains(".") Then
                lsDays = Convert.ToString(TimeSpan.FromSeconds(sec)).Substring(0, Convert.ToString(TimeSpan.FromSeconds(sec)).IndexOf("."))
                Dim j As Integer = (Convert.ToInt32(lsDays) * 24) + TimeSpan.FromSeconds(sec).Hours
                lsDays = Format(j, "0,0") + ":" + Format(TimeSpan.FromSeconds(sec).Minutes, "0,0")
            Else
                lsDays = Format(TimeSpan.FromSeconds(sec).Hours, "0,0") + ":" + Format(TimeSpan.FromSeconds(sec).Minutes, "0,0")
            End If

            dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column) = lsDays

            sec = 0

        Next

        For row = 0 To dsRekapitulasiJamBengkel.Tables(0).Rows.Count - 1
            For column = 4 To dsRekapitulasiJamBengkel.Tables(0).Columns.Count - 2
                If Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)) <> String.Empty Then

                    If Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)).Length >= 7 Then
                        dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column) = Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)).Substring(0, Convert.ToString(dsRekapitulasiJamBengkel.Tables(0).Rows(row)(column)).LastIndexOf(":"))
                    End If
                End If
            Next
        Next

        Return dsRekapitulasiJamBengkel

    End Function

    Private Sub EngineFarmTractorVehicleReport()

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New EngineFarmTractorVehiclesRpt
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet
        cmd.Connection = con

        cmd.CommandText = "[Vehicle].[EngineFarmTractorVehicleReportGET]'" & GlobalPPT.strEstateID & "','" & VehicleFarmTractorHEVehicleRunningLogReportFrm.strActMthYearID & "','" & GlobalPPT.intLoginYear & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "EngineFarmTractorVehicleReportGET;1")

        Dim txtBulan, txtEstate, txtFromDate, txtToDate, txtTitle, txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject



        txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtBulan = CType(rpt.ReportDefinition.ReportObjects.Item("txtBulan"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'txtSubTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtSubTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        'txtTitle.Text = "ENGINE /FARM TRACTOR /H.E/VEHICLE DISTRIBUTION " & General.MonthYear(GlobalPPT.IntActiveMonth) & " " & GlobalPPT.intActiveYear.ToString() '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
        txtTitle.Text = "VEHICLE DISTRIBUTION " & _GlobalBOL.PMonthName(VehicleFarmTractorHEVehicleRunningLogReportFrm.strmonth, VehicleFarmTractorHEVehicleRunningLogReportFrm.strYear, GlobalPPT.strLang)
        txtBulan.Text = _GlobalBOL.PMonthName(VehicleFarmTractorHEVehicleRunningLogReportFrm.strmonth, VehicleFarmTractorHEVehicleRunningLogReportFrm.strYear, GlobalPPT.strLang)
        txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
        txtFromDate.Text = VehicleFarmTractorHEVehicleRunningLogReportFrm.strFiscalYearFromDate
        txtToDate.Text = VehicleFarmTractorHEVehicleRunningLogReportFrm.strFiscalYearToDate

        'If ds.Tables(0).Rows.Count > 0 Then

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
        'Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@EstateID"
        ParamterDescreteValue2.Value = GlobalPPT.strActMthYearID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue2.Value = GlobalPPT.strActMthYearID
        ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField2)

        'ParamterField3.ParameterFieldName = "@LYear"
        'ParamterDescreteValue3.Value = GlobalPPT.IntLoginMonth
        'ParamterField2.CurrentValues.Add(ParamterDescreteValue3)
        'ParamterFields.Add(ParamterField3)


        crvEngineFarnTractorHEVehicle.ParameterFieldInfo = ParamterFields
        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(ds)
        crvEngineFarnTractorHEVehicle.ReportSource = rpt
        'End If

    End Sub

    Private Sub RunningVehicleReport()

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim no As Decimal
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New RunningVehicleRpt1
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim dsRunningLogReport As New DataSet
        cmd.Connection = con

        cmd.CommandText = "[Vehicle].[RunningVehicleReportGET] '" & GlobalPPT.strEstateID & "','" & VehicleFarmTractorHEVehicleRunningLogReportFrm.strActMthYearID & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsRunningLogReport, "RunningVehicleReportGET;1")

        Dim txtTotal, txtDec, txtNov, txtOct, txtSep, txtAug, txtJuly, txtMay, txtApr, txtFeb, txtMar, txtEstate, txtFromDate, txtToDate, txtFiscal, txtPrintedBy, txtJan, txtJune As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txtTotalk, txtDeck, txtNovk, txtOctk, txtSepk, txtAugk, txtJulyk, txtMayk, txtAprk, txtFebk, txtMark, txtJank, txtJunek As CrystalDecisions.CrystalReports.Engine.TextObject

        txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        'txtFiscal.Text = "RUNNING VEHICLE " & General.MonthYear(GlobalPPT.IntActiveMonth) & " " & GlobalPPT.intActiveYear.ToString() '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
        txtFiscal.Text = "VEHICLE RUNNING HOUR SUMMARY " & _GlobalBOL.PMonthName(VehicleFarmTractorHEVehicleRunningLogReportFrm.strmonth, VehicleFarmTractorHEVehicleRunningLogReportFrm.strYear, GlobalPPT.strLang)
        txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
        txtFromDate.Text = VehicleFarmTractorHEVehicleRunningLogReportFrm.strFiscalYearFromDate
        txtToDate.Text = VehicleFarmTractorHEVehicleRunningLogReportFrm.strFiscalYearToDate



        txtJan = CType(rpt.ReportDefinition.ReportObjects.Item("txtJan"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtJan.Text = ToaddHours("M1", dsRunningLogReport.Tables(0))

        txtFeb = CType(rpt.ReportDefinition.ReportObjects.Item("txtFeb"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFeb.Text = ToaddHours("M2", dsRunningLogReport.Tables(0))

        txtMar = CType(rpt.ReportDefinition.ReportObjects.Item("txtMar"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtMar.Text = ToaddHours("M3", dsRunningLogReport.Tables(0))

        txtApr = CType(rpt.ReportDefinition.ReportObjects.Item("txtApr"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtApr.Text = ToaddHours("M4", dsRunningLogReport.Tables(0))

        txtMay = CType(rpt.ReportDefinition.ReportObjects.Item("txtMay"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtMay.Text = ToaddHours("M5", dsRunningLogReport.Tables(0))

        txtJune = CType(rpt.ReportDefinition.ReportObjects.Item("txtJune"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtJune.Text = ToaddHours("M6", dsRunningLogReport.Tables(0))

        txtJuly = CType(rpt.ReportDefinition.ReportObjects.Item("txtJuly"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtJuly.Text = ToaddHours("M7", dsRunningLogReport.Tables(0))

        txtAug = CType(rpt.ReportDefinition.ReportObjects.Item("txtAug"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtAug.Text = ToaddHours("M8", dsRunningLogReport.Tables(0))

        txtSep = CType(rpt.ReportDefinition.ReportObjects.Item("txtSep"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtSep.Text = ToaddHours("M9", dsRunningLogReport.Tables(0))

        txtOct = CType(rpt.ReportDefinition.ReportObjects.Item("txtOct"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtOct.Text = ToaddHours("M10", dsRunningLogReport.Tables(0))

        txtNov = CType(rpt.ReportDefinition.ReportObjects.Item("txtNov"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtNov.Text = ToaddHours("M11", dsRunningLogReport.Tables(0))

        txtDec = CType(rpt.ReportDefinition.ReportObjects.Item("txtDec"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtDec.Text = ToaddHours("M12", dsRunningLogReport.Tables(0))

        txtTotal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTotal"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtTotal.Text = ToaddHours("Total", dsRunningLogReport.Tables(0))


        txtJank = CType(rpt.ReportDefinition.ReportObjects.Item("txtJank"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M1", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtJank.Text = String.Empty
        Else
            txtJank.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtFebk = CType(rpt.ReportDefinition.ReportObjects.Item("txtFebk"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M2", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtFebk.Text = String.Empty
        Else
            txtFebk.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtMark = CType(rpt.ReportDefinition.ReportObjects.Item("txtMark"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M3", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtMark.Text = String.Empty
        Else
            txtMark.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtAprk = CType(rpt.ReportDefinition.ReportObjects.Item("txtAprk"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M4", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtAprk.Text = String.Empty
        Else
            txtAprk.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtMayk = CType(rpt.ReportDefinition.ReportObjects.Item("txtMayk"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M5", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtMayk.Text = String.Empty
        Else
            txtMayk.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtJunek = CType(rpt.ReportDefinition.ReportObjects.Item("txtJunek"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M6", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtJunek.Text = String.Empty
        Else
            txtJunek.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtJulyk = CType(rpt.ReportDefinition.ReportObjects.Item("txtJulyk"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M7", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtJulyk.Text = String.Empty
        Else
            txtJulyk.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtAugk = CType(rpt.ReportDefinition.ReportObjects.Item("txtAugk"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M8", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtAugk.Text = String.Empty
        Else
            txtAugk.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtSepk = CType(rpt.ReportDefinition.ReportObjects.Item("txtSepk"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M9", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtSepk.Text = String.Empty
        Else
            txtSepk.Text = String.Format("{0:d2}", no.ToString)
        End If


        txtOctk = CType(rpt.ReportDefinition.ReportObjects.Item("txtOctk"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M10", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtOctk.Text = String.Empty
        Else
            txtOctk.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtNovk = CType(rpt.ReportDefinition.ReportObjects.Item("txtNovk"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M11", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtNovk.Text = String.Empty
        Else
            txtNovk.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtDeck = CType(rpt.ReportDefinition.ReportObjects.Item("txtDeck"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("M12", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtDeck.Text = String.Empty
        Else
            txtDeck.Text = String.Format("{0:d2}", no.ToString)
        End If

        txtTotalk = CType(rpt.ReportDefinition.ReportObjects.Item("txtTotalk"), CrystalDecisions.CrystalReports.Engine.TextObject)
        no = ToaddKms("Total", dsRunningLogReport.Tables(0))
        If no = 0 Then
            txtTotalk.Text = String.Empty
        Else
            txtTotalk.Text = String.Format("{0:d2}", no.ToString)
        End If




        'RunningVehicleReportCalculation(dsRunningLogReport.Tables(0))

        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(dsRunningLogReport)
        crvRunningVehicle.ReportSource = rpt
    End Sub

    Private Function ToaddHours(ByVal Month As String, ByVal VHDataTable As DataTable)
        Dim Calchrs As String
        Dim strArr0(), strArr1() As String
        Dim Str0, Str1 As String
        Dim DataCount As Integer
        Dim Lhrs, lmin As Integer
        Dim KMS As Decimal
        Calchrs = "00:00"
        DataCount = VHDataTable.Rows.Count
        Dim MonthValue As String
        MonthValue = Month
        MonthValue = "" & MonthValue & ""
        KMS = 0
        Dim ROWS As Integer = 0
        '  If VHDataTable.Rows(ROWS).Item("UOM").ToString = "Hrs" Then
        While (DataCount > 0)
            If VHDataTable.Rows(ROWS).Item("UOM").ToString = "Hrs" Then


                Str0 = Calchrs
                strArr0 = Str0.Split(":")
                Str1 = VHDataTable.Rows(ROWS).Item(MonthValue).ToString
                strArr1 = Str1.Split(".")

                Lhrs = CInt(strArr1(0)) + CInt(strArr0(0))
                lmin = CInt(strArr1(1)) + CInt(strArr0(1))

                If lmin >= 60 Then
                    lmin = lmin - 60
                    Lhrs = Lhrs + 1
                End If
                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs2 = Lhrs
                End If

                If lmin < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin)
                Else
                    StrMin2 = lmin
                End If

                Calchrs = Strhrs2 + ":" + StrMin2
            End If
            DataCount = DataCount - 1
            ROWS = ROWS + 1
        End While

        '  End If
        If Calchrs = "00:00" Then
            Calchrs = String.Empty
        End If

        Return Calchrs
    End Function

    Private Function ToaddKms(ByVal Month As String, ByVal VHDataTable As DataTable)
        Dim CalcKms, tmpKms As Decimal
        ' Dim strTotal As String
        Dim DataCount As Integer
        '  Dim Lhrs, lmin As Integer
        Dim KMS As Decimal
        CalcKms = "0.00"
        DataCount = VHDataTable.Rows.Count
        Dim MonthValue As String
        MonthValue = Month
        MonthValue = "" & MonthValue & ""
        KMS = 0.0
        Dim ROWS As Integer = 0
        '  If VHDataTable.Rows(ROWS).Item("UOM").ToString = "Hrs" Then
        While (DataCount > 0)
            If VHDataTable.Rows(ROWS).Item("UOM").ToString = "Kms" Then

                tmpKms = Val(VHDataTable.Rows(ROWS).Item(MonthValue).ToString)
                CalcKms = tmpKms + CalcKms

            End If
            DataCount = DataCount - 1
            ROWS = ROWS + 1
        End While

        '  End If
        'If CalcKms = 0 Then
        '    CalcKms = System.DBNull
        'End If

        Return CalcKms
    End Function

    Private Sub VehicleTransportFFBReport()

        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New VehicleTransportFFBRpt
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim dsVehicleTransportFFBReport As New DataSet
        cmd.Connection = con

        cmd.CommandText = "[Vehicle].[VehicleTransportFFBReportGet] '" & GlobalPPT.strEstateID & "','" & VehicleFarmTractorHEVehicleRunningLogReportFrm.strActMthYearID & "'"
        'cmd.CommandText = "[Vehicle].[VehicleTransportFFBReportGet] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.IntLoginMonth & "','" & GlobalPPT.intLoginYear & "'"

        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsVehicleTransportFFBReport, "VehicleTransportFFBReportGet;1")

        Dim txtEstate, txtFromDate, txtToDate, txtFiscal, txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject

        txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedBy.Text = GlobalPPT.strUserName

        'txtFiscal.Text = "VEHICLE TRANSPORT FFB " & General.MonthYear(GlobalPPT.IntActiveMonth) & " " & GlobalPPT.intActiveYear.ToString() '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
        txtFiscal.Text = "VEHICLE TRANSPORT FFB " & _GlobalBOL.PMonthName(VehicleFarmTractorHEVehicleRunningLogReportFrm.strmonth, VehicleFarmTractorHEVehicleRunningLogReportFrm.strYear, GlobalPPT.strLang)
        txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
        txtFromDate.Text = VehicleFarmTractorHEVehicleRunningLogReportFrm.strFiscalYearFromDate
        txtToDate.Text = VehicleFarmTractorHEVehicleRunningLogReportFrm.strFiscalYearToDate

        'If dsVehicleTransportFFBReport.Tables(0).Rows.Count > 0 Then

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
        'Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
        'Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@EstateID"
        ParamterDescreteValue2.Value = GlobalPPT.strEstateID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue2.Value = GlobalPPT.IntLoginMonth
        ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField2)

        'ParamterField3.ParameterFieldName = "@LogedInYear"
        'ParamterDescreteValue3.Value = GlobalPPT.intLoginYear
        'ParamterField3.CurrentValues.Add(ParamterDescreteValue3)
        'ParamterFields.Add(ParamterField3)

        crvVehTransportFFB.ParameterFieldInfo = ParamterFields
        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(dsVehicleTransportFFBReport)
        crvVehTransportFFB.ReportSource = rpt

        'Dim vvr As New VehicleViewReport
        'vvr.crvVehicle.ParameterFieldInfo = ParamterFields

        'rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        'rpt.SetDataSource(dsVehicleTransportFFBReport)
        'vvr.crvVehicle.ReportSource = rpt

        'End If

    End Sub

    Private Sub VehicleFarmTractorHEVehicleRunningLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VehicleFarmTractorHEVehicleRunningLog.SelectedIndexChanged

        Select Case VehicleFarmTractorHEVehicleRunningLog.SelectedIndex
            Case 0
                'Me.Cursor = Cursors.WaitCursor
                VehicleFarmTractorHEVehicleRunningLogReportFrm.Cursor = Cursors.WaitCursor
                VehicleFarmTractorHEVehicleRunningLogRpt()
                'Me.Cursor = Cursors.Arrow
                VehicleFarmTractorHEVehicleRunningLogReportFrm.Cursor = Cursors.Arrow
                'VehicleFarmTractorHEVehicleRunningLog.Height = Me.Height
                'VehicleFarmTractorHEVehicleRunningLog.Width = Me.Width
            Case 1
                'Me.Cursor = Cursors.WaitCursor
                VehicleFarmTractorHEVehicleRunningLogReportFrm.Cursor = Cursors.WaitCursor
                VehicleTransportFFBReport()
                'Me.Cursor = Cursors.Arrow
                VehicleFarmTractorHEVehicleRunningLogReportFrm.Cursor = Cursors.Arrow

                'VehicleFarmTractorHEVehicleRunningLog.Height = Me.Height
                'VehicleFarmTractorHEVehicleRunningLog.Width = Me.Width
            Case 2
                'Me.Cursor = Cursors.WaitCursor
                VehicleFarmTractorHEVehicleRunningLogReportFrm.Cursor = Cursors.WaitCursor
                RunningVehicleReport()
                'Me.Cursor = Cursors.Arrow
                VehicleFarmTractorHEVehicleRunningLogReportFrm.Cursor = Cursors.Arrow
                'VehicleFarmTractorHEVehicleRunningLog.Height = Me.Height
                'VehicleFarmTractorHEVehicleRunningLog.Width = Me.Width
            Case 3
                'Me.Cursor = Cursors.WaitCursor
                VehicleFarmTractorHEVehicleRunningLogReportFrm.Cursor = Cursors.WaitCursor
                EngineFarmTractorVehicleReport()
                'Me.Cursor = Cursors.Arrow
                VehicleFarmTractorHEVehicleRunningLogReportFrm.Cursor = Cursors.Arrow
                'VehicleFarmTractorHEVehicleRunningLog.Height = Me.Height
                'VehicleFarmTractorHEVehicleRunningLog.Width = Me.Width
        End Select

    End Sub

    'Private Function RunningVehicleReportCalculation(ByVal dsRunningVehicle As DataSet) As DataSet

    '    Dim local As String

    '    For r As Integer = 0 To dsRunningVehicle.Tables(0).Rows.Count - 1
    '        For c As Integer = 5 To dsRunningVehicle.Tables(0).Columns.Count - 2
    '            If Not IsDBNull(dsRunningVehicle.Tables(0).Rows(r)(c)) Then

    '                local = Convert.ToString(dsRunningVehicle.Tables(0).Rows(r)(c))
    '                local = (local.Substring(0, local.LastIndexOf(":"))).Replace(":", ".")
    '                dsRunningVehicle.Tables(0).Rows(r)(c) = Format(Convert.ToDecimal(local), "0,0.0,0").Replace(".", ":")

    '            End If
    '        Next
    '    Next

    '    'Start Calculate the Total

    '    Dim dsRunningVehicleData As DataSet = New DataSet

    '    dsRunningVehicleData.Tables.Add(dsRunningVehicle.Tables(0).Clone)

    '    'dsRunningVehicleData.Tables(0).Columns.Add("Total")

    '    Dim row As Integer
    '    Dim column As Integer

    '    'Move redunt rows as a single row
    '    For row = 0 To dsRunningVehicle.Tables(0).Rows.Count - 1
    '        If dsRunningVehicleData.Tables(0).Rows.Count = 0 Then
    '            dsRunningVehicleData.Tables(0).ImportRow(dsRunningVehicle.Tables(0).Rows(row))
    '        ElseIf dsRunningVehicleData.Tables(0).Rows(dsRunningVehicleData.Tables(0).Rows.Count - 1)(0) <> dsRunningVehicle.Tables(0).Rows(row)(0) Or dsRunningVehicleData.Tables(0).Rows(dsRunningVehicleData.Tables(0).Rows.Count - 1)(1) <> dsRunningVehicle.Tables(0).Rows(row)(1) Then
    '            dsRunningVehicleData.Tables(0).ImportRow(dsRunningVehicle.Tables(0).Rows(row))
    '        Else
    '            For column = 0 To dsRunningVehicle.Tables(0).Columns.Count - 2
    '                If Convert.ToString(dsRunningVehicle.Tables(0).Rows(row)(column)) <> String.Empty Then

    '                    'Dim dd As String = dsRunningVehicle.Tables(0).Rows(row)(column)

    '                    'dsRunningVehicleData.Tables(0).Rows(dsRunningVehicleData.Tables(0).Rows.Count - 1)(column) = Format(Convert.ToDecimal(dsRunningVehicle.Tables(0).Rows(row)(column)), "0,0.0,0")
    '                    dsRunningVehicleData.Tables(0).Rows(dsRunningVehicleData.Tables(0).Rows.Count - 1)(column) = dsRunningVehicle.Tables(0).Rows(row)(column)
    '                End If
    '            Next
    '        End If
    '    Next

    '    Dim sec As Integer
    '    sec = 0

    '    'Add by row
    '    For row = 0 To dsRunningVehicleData.Tables(0).Rows.Count - 1
    '        'Since the last column in total we subtract by 2
    '        For column = 5 To dsRunningVehicleData.Tables(0).Columns.Count - 2
    '            If Convert.ToString(dsRunningVehicleData.Tables(0).Rows(row)(column)) <> String.Empty Then
    '                Dim strArray() As String = Convert.ToString(dsRunningVehicleData.Tables(0).Rows(row)(column)).Split(":")
    '                'Get the time into seconds and add the seconds
    '                sec = sec + TimeSpan.FromHours(Convert.ToDouble(strArray(0))).TotalSeconds + TimeSpan.FromMinutes(Convert.ToDouble(strArray(1))).TotalSeconds

    '            End If
    '        Next

    '        Dim lsDays As String

    '        If Convert.ToString(TimeSpan.FromSeconds(sec)).Contains(".") Then
    '            lsDays = Convert.ToString(TimeSpan.FromSeconds(sec)).Substring(0, Convert.ToString(TimeSpan.FromSeconds(sec)).IndexOf("."))
    '            lsDays = Convert.ToString((Convert.ToInt32(lsDays) * 24) + TimeSpan.FromSeconds(sec).Hours).PadLeft(2, "0") + "." + Convert.ToString(TimeSpan.FromSeconds(sec).Minutes).PadLeft(2, "0")
    '        Else
    '            lsDays = Convert.ToString(TimeSpan.FromSeconds(sec).Hours).PadLeft(2, "0") + "." + Convert.ToString(TimeSpan.FromSeconds(sec).Minutes).PadLeft(2, "0")
    '        End If

    '        dsRunningVehicleData.Tables(0).Rows(row)(column) = Format(Convert.ToDecimal(lsDays), "0,0.0,0")

    '        sec = 0

    '    Next

    '    dsRunningVehicleData.Tables(0).Rows.Add(dsRunningVehicleData.Tables(0).NewRow)

    '    'Add by Column
    '    For column = 5 To dsRunningVehicleData.Tables(0).Columns.Count - 1
    '        For row = 0 To (dsRunningVehicleData.Tables(0).Rows.Count - 2)
    '            If Convert.ToString(dsRunningVehicleData.Tables(0).Rows(row)(column)) <> String.Empty Then
    '                Dim strArray() As String
    '                If (dsRunningVehicleData.Tables(0).Columns.Count - 1) <> column Then
    '                    strArray = Convert.ToString(dsRunningVehicleData.Tables(0).Rows(row)(column)).Split(":")
    '                Else
    '                    strArray = Convert.ToString(dsRunningVehicleData.Tables(0).Rows(row)(column)).Split(".")
    '                End If
    '                sec = sec + TimeSpan.FromHours(Convert.ToDouble(strArray(0))).TotalSeconds + TimeSpan.FromMinutes(Convert.ToDouble(strArray(1))).TotalSeconds
    '            End If
    '        Next

    '        Dim lsDays As String

    '        If Convert.ToString(TimeSpan.FromSeconds(sec)).Contains(".") Then
    '            lsDays = Convert.ToString(TimeSpan.FromSeconds(sec)).Substring(0, Convert.ToString(TimeSpan.FromSeconds(sec)).IndexOf("."))
    '            lsDays = Convert.ToString((Convert.ToInt32(lsDays) * 24) + TimeSpan.FromSeconds(sec).Hours) + "." + Format(TimeSpan.FromSeconds(sec).Minutes, "0,0")
    '        Else
    '            lsDays = Convert.ToString(TimeSpan.FromSeconds(sec).Hours) + "." + Format(TimeSpan.FromSeconds(sec).Minutes, "0,0")
    '        End If

    '        If Format(Convert.ToDecimal(lsDays), "0,0.0,0") <> "00.00" Then

    '            Dim J As Int16 = dsRunningVehicleData.Tables(0).Rows.Count

    '            dsRunningVehicleData.Tables(0).Rows(row)(column) = Format(Convert.ToDecimal(lsDays), "0,0.0,0")
    '        End If

    '        sec = 0

    '    Next

    '    column = dsRunningVehicle.Tables(0).Columns.Count

    '    Dim dt As DataTable = dsRunningVehicleData.Tables(0)

    '    'Add text "Total" at the end of the row
    '    If dsRunningVehicleData.Tables(0).Rows.Count > 0 Then
    '        dsRunningVehicleData.Tables(0).Rows(dsRunningVehicleData.Tables(0).Rows.Count - 1)(1) = "Total"
    '        dsRunningVehicleData.Tables(0).AcceptChanges()
    '    End If


    '    Return dsRunningVehicleData
    'End Function

    'Private Sub RunningVehicleReport()

    '    strDSN = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oDSN").ToString) & ""
    '    strServerUserName = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oUserName").ToString) & ""
    '    strServerPassword = "" & Common_DAL.EncryptDAL.Decrypt(ConfigurationManager.AppSettings.Item("oPassword").ToString) & ""

    '    Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
    '    Dim con As New Odbc.OdbcConnection
    '    Dim cmd As New Odbc.OdbcCommand
    '    Dim da As New Odbc.OdbcDataAdapter
    '    con = New Odbc.OdbcConnection(constr)
    '    con.Open()

    '    Dim rpt As New RunningVehicleRpt
    '    Dim tblAdt As New Odbc.OdbcDataAdapter
    '    Dim dsRunningLogReport As New DataSet
    '    cmd.Connection = con

    '    cmd.CommandText = "[Vehicle].[RunningVehicleReportGET]"
    '    cmd.CommandType = CommandType.StoredProcedure
    '    tblAdt.SelectCommand = cmd
    '    tblAdt.Fill(dsRunningLogReport, "RunningVehicleReportGET;1")

    '    Dim txtEstate, txtFromDate, txtToDate, txtFiscal, txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject

    '    txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtPrintedBy = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    txtPrintedBy.Text = GlobalPPT.strUserName

    '    txtFiscal.Text = "RUNNING VEHICLE " & General.MonthYear(GlobalPPT.IntActiveMonth) & " " & GlobalPPT.intActiveYear.ToString() '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
    '    txtEstate.Text = GlobalPPT.strEstateName.Substring(3)
    '    txtFromDate.Text = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
    '    txtToDate.Text = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")

    '    If dsRunningLogReport.Tables(0).Rows.Count > 0 Then

    '        'Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
    '        'Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
    '        'Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField
    '        'Dim ParamterField3 As New CrystalDecisions.Shared.ParameterField

    '        'Dim ParamterDescreteValue1 As New CrystalDecisions.Shared.ParameterDiscreteValue
    '        'Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
    '        'Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

    '        'ParamterField1.ParameterFieldName = "@EstateID"
    '        'ParamterDescreteValue1.Value = GlobalPPT.strEstateID
    '        'ParamterField1.CurrentValues.Add(ParamterDescreteValue1)
    '        'ParamterFields.Add(ParamterField1)

    '        'ParamterField2.ParameterFieldName = "@LogedInMonth"
    '        'ParamterDescreteValue2.Value = GlobalPPT.IntActiveMonth
    '        'ParamterField2.CurrentValues.Add(ParamterDescreteValue1)
    '        'ParamterFields.Add(ParamterField2)
    '        'crvVehicle.ParameterFieldInfo = ParamterFields

    '        'ParamterField3.ParameterFieldName = "@LogedInYear"
    '        'ParamterDescreteValue3.Value = GlobalPPT.intActiveYear
    '        'ParamterField3.CurrentValues.Add(ParamterDescreteValue3)
    '        'ParamterFields.Add(ParamterField3)
    '        'crvVehicle.ParameterFieldInfo = ParamterFields

    '        Dim dsCalculated As DataSet = RunningVehicleReportCalculation(dsRunningLogReport)
    '        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
    '        rpt.SetDataSource(dsCalculated)
    '        crvRunningVehicle.ReportSource = rpt

    '    End If

    '    'ReportDocument.ReportDefinition.ReportObjects.Item("Line58").ObjectFormat.EnableSuppress = True
    '    rpt.ReportDefinition.ReportObjects.Item("Line58").
    'End Sub


End Class