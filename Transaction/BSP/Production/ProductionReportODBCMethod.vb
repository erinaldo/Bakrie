Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Public Class ProductionReportODBCMethod

    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty
    Private Sub ProductionReportODBCMethod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        If GradingReportInterfaceFrm.StrFrmName = "Gradingrpt" Then
            Dim rpt As New GradingReport
            Dim tblAdt As New Odbc.OdbcDataAdapter
            Dim ds As New DataSet
            cmd.Connection = con

            cmd.CommandText = "Production.GradingReport '" & GradingReportInterfaceFrm.strweiID & "','" & GradingReportInterfaceFrm.strGradingdate & "' ,'" & GlobalPPT.strEstateID & "','" & GradingReportInterfaceFrm.strAMYID & "' "
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd

            tblAdt.Fill(ds, "GradingReport;1")
            Dim txtEstateNameH As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateNameH = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateNameH"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")

            Dim ENanme As String
            ENanme = strArray(1)
            txtEstateNameH.Text = ENanme.ToUpper


            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            GradingReportInterfaceFrm.StrFrmName = String.Empty

        End If


    End Sub
End Class