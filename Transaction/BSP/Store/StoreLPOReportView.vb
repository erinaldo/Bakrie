Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports System.Math
Public Class StoreLPOReportView
    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty


    Private Sub StoreLPOReportViewFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"

        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim cmd1 As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)

        con.Open()

        Dim rpt As New LPOReportForLPONo
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet
        cmd.Connection = con
        cmd.CommandText = "Store.LPOReportForLPONO '" & StoreLPOReportFrm.strSTLPONo & "','" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "LPOReportForLPONO;1")

        'Dim txtEstate As CrystalDecisions.CrystalReports.Engine.TextObject
        'txtEstate = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'txtEstate.Text = GlobalPPT.strEstateName

        'Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
        'txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstate"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'Dim strArray As String()
        'strArray = GlobalPPT.strEstateName.Split("-")
        'txtEstateName.Text = strArray(1)

        'Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
        'txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'txtPrintedby.Text = GlobalPPT.strUserName

        If ds.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
        Else
            MessageBox.Show("There is no record for the login month")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            'Me.Close()
        End If

    End Sub
End Class