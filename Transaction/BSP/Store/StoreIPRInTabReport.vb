Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_DAL
Imports Common_PPT
Imports System.Configuration

Public Class StoreIPRInTabReport

    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty
    Dim _GlobalBOL As New GlobalBOL
    Public strReportName As String

    Private Sub StoreIPRInTabReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InternalTransferNoteInReport()
    End Sub

    Private Sub VehicleFarmTractorHEVehicleRunningLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VehicleFarmTractorHEVehicleRunningLog.SelectedIndexChanged
        Select Case VehicleFarmTractorHEVehicleRunningLog.SelectedIndex
            Case 0
                InternalTransferNoteInReport()
            Case 1
                InternalTransferNoteOutReport()
            Case 2
                '  InternalPurchaseRequisitionReport()
        End Select
    End Sub

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

        cmd.CommandText = "[Store].[InternalTransferNoteReportGet] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & "IN" & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsRunningLogReport, "InternalTransferNoteReportGet;1")

        Dim txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject


        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
      

        txtFiscal.Text = "INTERNAL TRANSFER NOTE IN " & _GlobalBOL.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intLoginYear, GlobalPPT.strLang)
       

        If dsRunningLogReport.Tables(0).Rows.Count > 0 Then

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
            ParamterDescreteValue2.Value = GlobalPPT.strActMthYearID
            ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
            ParamterFields.Add(ParamterField2)
            crvInternalTransferNoteINRpt.ParameterFieldInfo = ParamterFields

            ParamterField3.ParameterFieldName = "@InOrOut"
            ParamterDescreteValue3.Value = "IN"
            ParamterField3.CurrentValues.Add(ParamterDescreteValue3)
            ParamterFields.Add(ParamterField3)
            crvInternalTransferNoteINRpt.ParameterFieldInfo = ParamterFields

            rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
            rpt.SetDataSource(dsRunningLogReport)
            crvInternalTransferNoteINRpt.ReportSource = rpt
        End If
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

        cmd.CommandText = "[Store].[InternalTransferNoteReportGet] '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "','" & "OUT" & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(dsRunningLogReport, "InternalTransferNoteReportGet;1")

        'Dim txtEstate, txtFromDate, txtToDate, txtFiscal, txtPrintedBy As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim txtFiscal As CrystalDecisions.CrystalReports.Engine.TextObject

        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
       

        txtFiscal.Text = "INTERNAL TRANSFER NOTE OUT " & _GlobalBOL.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intLoginYear, GlobalPPT.strLang)
        

        If dsRunningLogReport.Tables(0).Rows.Count > 0 Then

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
            ParamterDescreteValue2.Value = GlobalPPT.strActMthYearID
            ParamterField2.CurrentValues.Add(ParamterDescreteValue2)
            ParamterFields.Add(ParamterField2)
            crvInternalTransferNoteOUTRpt.ParameterFieldInfo = ParamterFields

            ParamterField3.ParameterFieldName = "@InOrOut"
            ParamterDescreteValue3.Value = "Out"
            ParamterField3.CurrentValues.Add(ParamterDescreteValue3)
            ParamterFields.Add(ParamterField3)
            crvInternalTransferNoteOUTRpt.ParameterFieldInfo = ParamterFields

            rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
            rpt.SetDataSource(dsRunningLogReport)
            crvInternalTransferNoteOUTRpt.ReportSource = rpt
        End If
    End Sub

    'Private Sub InternalPurchaseRequisitionReport()

    '    strDSN = "" & ConfigurationManager.AppSettings.Item("oDSN").ToString & ""
    '    strServerUserName = "" & ConfigurationManager.AppSettings.Item("oUserName").ToString & ""
    '    strServerPassword = "" & ConfigurationManager.AppSettings.Item("oPassword").ToString & ""

    '    Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"

    '    Dim con As New Odbc.OdbcConnection
    '    Dim cmd As New Odbc.OdbcCommand
    '    Dim cmd1 As New Odbc.OdbcCommand
    '    con = New Odbc.OdbcConnection(constr)
    '    con.Open()

    '    Dim rpt As New IPRReportForIPRNo
    '    Dim tblAdt As New Odbc.OdbcDataAdapter
    '    Dim tblAdt1 As New Odbc.OdbcDataAdapter
    '    Dim ds As New DataSet
    '    Dim ds1 As New DataSet
    '    cmd.Connection = con

    '    cmd.CommandText = "Store.IPRReportForIPRNO '" & StoreIPRReportFrm.strSTIPRNo & "','" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
    '    cmd.CommandType = CommandType.StoredProcedure
    '    tblAdt.SelectCommand = cmd
    '    tblAdt.Fill(ds, "IPRReportForIPRNO;1")

    '    If ds.Tables(0).Rows.Count > 0 Then
    '        '
    '        Dim txtBudget As CrystalDecisions.CrystalReports.Engine.TextObject
    '        txtBudget = CType(rpt.ReportDefinition.ReportObjects.Item("txtBudget"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '        Dim intBudget As Integer
    '        If ds.Tables.Count > 0 Then
    '            If GlobalPPT.IntLoginMonth = 1 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M1")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 2 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M2")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 3 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M3")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 4 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M4")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 5 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M5")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 6 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M6")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 7 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M7")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 8 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M8")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 9 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M9")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 10 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M10")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 11 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M11")
    '                txtBudget.Text = intBudget
    '            ElseIf GlobalPPT.IntLoginMonth = 12 Then
    '                intBudget = ds.Tables(0).Rows(0).Item("M12")
    '                txtBudget.Text = intBudget
    '            End If
    '        End If

    '        cmd1.Connection = con
    '        cmd1.CommandText = "Store.IPRReportForIPRNOREALISASI '" & StoreIPRReportFrm.strUsageCOAID & "','" & GlobalPPT.strEstateID & "','" & GlobalPPT.IntLoginMonth & "','" & GlobalPPT.intActiveYear & "'"
    '        cmd1.CommandType = CommandType.StoredProcedure
    '        tblAdt1.SelectCommand = cmd1
    '        tblAdt1.Fill(ds1, "IPRReportForIPRNOREALISASI;1")

    '        Dim txtRealisasi As CrystalDecisions.CrystalReports.Engine.TextObject
    '        txtRealisasi = CType(rpt.ReportDefinition.ReportObjects.Item("txtRealisasi"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '        Dim intREALISASI As Integer
    '        intREALISASI = ds1.Tables(0).Rows(0).Item("REALISASI")
    '        txtRealisasi.Text = intREALISASI

    '        Dim txtSisa As CrystalDecisions.CrystalReports.Engine.TextObject
    '        txtSisa = CType(rpt.ReportDefinition.ReportObjects.Item("txtSisa"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '        txtSisa.Text = System.Math.Abs(txtBudget.Text - txtRealisasi.Text)

    '        Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
    '        txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '        txtPrintedby.Text = GlobalPPT.strUserName

    '        rpt.SetDataSource(ds)
    '        CrystalReportViewer1.ReportSource = rpt
    '        '
    '    Else
    '        MessageBox.Show("There is no record for the login month")
    '        Me.Close()
    '    End If


    'End Sub

End Class