Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports System.Math

Public Class StoreConsignmentstockmovementsReportView

    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty


    Private Sub StoreConsignmentstockmovementsReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"

        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()

        Dim rpt As New ConsignmentstockMovementsReport
        Dim tblAdt As New Odbc.OdbcDataAdapter

        Dim _GlobalBOL As New GlobalBOL
        Dim objCons As New StoreConsignmentstockmovementsReportFrm

        Dim ds As New DataSet

        cmd.Connection = con

        cmd.CommandText = "Store.StockDetailConsignmentSTOCKMovementRpt '" & StoreConsignmentstockmovementsReportFrm.strActiveMonthYrId & "','" & GlobalPPT.strEstateID & "'"
        cmd.CommandType = CommandType.StoredProcedure
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "StockDetailConsignmentSTOCKMovementRpt;1")


        Dim txtRptName As CrystalDecisions.CrystalReports.Engine.TextObject
        txtRptName = CType(rpt.ReportDefinition.ReportObjects.Item("txtRptName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtRptName.Text = "CONSIGNMENTS STOCK MOVEMENT " + _GlobalBOL.PMonthName(StoreConsignmentstockmovementsReportFrm.intConsignmentMonth, StoreConsignmentstockmovementsReportFrm.intConsignmentYear, GlobalPPT.strLang)


        Dim txtPrintedby As CrystalDecisions.CrystalReports.Engine.TextObject
        txtPrintedby = CType(rpt.ReportDefinition.ReportObjects.Item("txtPrintedby"), CrystalDecisions.CrystalReports.Engine.TextObject)
        txtPrintedby.Text = GlobalPPT.strDisplayName

        Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
        txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim strArray As String()
        strArray = GlobalPPT.strEstateName.Split("-")
        txtEstateName.Text = strArray(1)

        If ds.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
        Else
            MessageBox.Show("There is no record for the login month")
            CrystalReportViewer1.ReportSource = rpt
            'Me.Close()
        End If

    End Sub

End Class