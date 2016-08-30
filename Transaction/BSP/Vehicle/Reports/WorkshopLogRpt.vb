Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration

Public Class WorkshopLogRpt

    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty

    Private Sub WorkshopLogRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        ' Dim constr As String = "DSN=BSPDSN;" & strServerUserName & "; " & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New WorkshopLogReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet
        cmd.Connection = con

        cmd.CommandText = "Vehicle.WorkshopLogReport '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "WorkshopLogReport;1")
        'rpt = New IPRReport

        Dim txtFiscal, txtEstate, txtFromDate, txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject

        txtFiscal = CType(rpt.ReportDefinition.ReportObjects.Item("txtFiscalYearMonth"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)


        txtFiscal.Text = "Workshop Proof List " & General.MonthYear(GlobalPPT.IntActiveMonth) & " " & GlobalPPT.intActiveYear.ToString() '& " <" & GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy") & "," & GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy") & ">"
        txtFromDate.Text = GlobalPPT.FiscalYearFromDate.Date.ToString("dd/MM/yyyy")
        txtToDate.Text = GlobalPPT.FiscalYearToDate.Date.ToString("dd/MM/yyyy")
        txtEstate.Text = GlobalPPT.strEstateName.Substring(3)

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue2.Value = GlobalPPT.strActMthYearID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@EstateID"
        ParamterDescreteValue3.Value = GlobalPPT.strEstateID
        ParamterField2.CurrentValues.Add(ParamterDescreteValue3)
        ParamterFields.Add(ParamterField2)
        crvWorkshopLogRpt.ParameterFieldInfo = ParamterFields

        rpt.SetDatabaseLogon(strServerUserName, strServerPassword)
        rpt.SetDataSource(ds)
        crvWorkshopLogRpt.ReportSource = rpt
    End Sub
End Class