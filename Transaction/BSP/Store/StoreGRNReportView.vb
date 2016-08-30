Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports System.Math

Public Class StoreGRNReportView


    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty

    Private Sub StoreGRNReportView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"

        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim cmd1 As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()


        Dim rpt As New GRNReport
        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim tblAdt1 As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet
        Dim ds1 As New DataSet
        cmd.Connection = con
        If GRNReportInterfaceFrm.StrFrmName = "GRNReport" Then

            cmd.CommandText = "Store.GRNReportFortheMonth '" & GlobalPPT.strEstateID & "','" & GRNReportInterfaceFrm.strAmonth & "','" & GRNReportInterfaceFrm.strAYear & "'"
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "GRNReportFortheMonth;1")

            'Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            'txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'txtPrintedby.Text = GlobalPPT.strUserName

            Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
            txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtPrintedby.Text = GlobalPPT.strDisplayName

            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1)

            Dim txtFromDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtFromDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtFromDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtFromDate.Text = GRNReportInterfaceFrm.strFrmDate


            Dim txtToDate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtToDate = CType(rpt.ReportDefinition.ReportObjects.Item("txtToDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtToDate.Text = GRNReportInterfaceFrm.strToDate


        End If



        Dim _GlobalBOL As New GlobalBOL
        Dim MdiParent As New MDIParent
        If MdiParent.strMenuID = "M11" Then

            Dim txtTitle As CrystalDecisions.CrystalReports.Engine.TextObject

            txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtTitle.Text = "SUMMARY PENERIMAAN   " & _GlobalBOL.PMonthName(GRNReportInterfaceFrm.strAmonth, GRNReportInterfaceFrm.strAYear, GlobalPPT.strLang)

        ElseIf MdiParent.strMenuID = "M23" Then

            Dim txtTitle As CrystalDecisions.CrystalReports.Engine.TextObject
            txtTitle = CType(rpt.ReportDefinition.ReportObjects.Item("txtTitle"), CrystalDecisions.CrystalReports.Engine.TextObject)
            txtTitle.Text = "RECEIVING SUMMARY " & _GlobalBOL.PMonthName(GlobalPPT.IntLoginMonth, GlobalPPT.intLoginYear, GlobalPPT.strLang)

        End If


        If ds.Tables(0).Rows.Count > 0 Then

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt

        Else

            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt

        End If

    End Sub

End Class