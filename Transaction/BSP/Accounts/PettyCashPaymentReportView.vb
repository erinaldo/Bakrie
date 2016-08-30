Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports System.Math


Public Class PettyCashPaymentReportView

    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty


    Private Sub PettyCashPaymentReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password

        Dim constr As String = " DSN=" & strDSN & ";UID=" & strServerUserName & "; pwd=" & strServerPassword & ";"

        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        con = New Odbc.OdbcConnection(constr)
        con.Open()


        If PettyCashPaymentReportFrm.rptName = "PCP" Then
            Dim rpt As New PettyCashPaymentReportForPCVNO
            Dim tblAdt As New Odbc.OdbcDataAdapter

            Dim ds As New DataSet

            cmd.Connection = con

            cmd.CommandText = "Accounts.PettyCashPaymentReportForPCVNO '" & PettyCashPaymentReportFrm.strVoucherNo & "','" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandTimeout = 1800
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "PettyCashPaymentReportForPCVNO;1")

            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1) + " " + "Petty Cash"

            Dim intCount, intTotalAmt, intRowCount As Decimal
            Dim strTotalAmt As String = String.Empty
            intCount = 0
            intRowCount = ds.Tables(0).Rows.Count

            While intRowCount > 0
                intTotalAmt += ds.Tables(0).Rows(intCount).Item("Amount")
                intCount = intCount + 1
                intRowCount = intRowCount - 1
            End While

            Dim objclsConversion As New clsConversion
            strTotalAmt = objclsConversion.ConvertNumberToWords(intTotalAmt) + "Rp"

            'ToWord
            Dim ToWord As CrystalDecisions.CrystalReports.Engine.TextObject
            ToWord = CType(rpt.ReportDefinition.ReportObjects.Item("ToWord"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'ToWord.Text = strTotalAmt
            ToWord.Text = StrConv(strTotalAmt, VbStrConv.ProperCase)

            'txtAccountCode
            'If ds.Tables(1).Rows.Count > 0 Then

            '    Dim txtAccountCode As CrystalDecisions.CrystalReports.Engine.TextObject
            '    txtAccountCode = CType(rpt.ReportDefinition.ReportObjects.Item("txtAccountCode"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '    txtAccountCode.Text = ds.Tables(1).Rows(0).Item("COACode")

            'End If

            If ds.Tables(0).Rows.Count > 0 Then
                rpt.SetDataSource(ds.Tables(0))
                CrystalReportViewer1.ReportSource = rpt
            Else
                CrystalReportViewer1.ReportSource = rpt
            End If

        ElseIf PenerimaanCashReceiptReportFrm.rptName <> "" Then
            Dim rpt As New PenerimanCashReceived
            '  Dim rpt As New testHalfPage


            Dim tblAdt As New Odbc.OdbcDataAdapter

            Dim ds As New DataSet

            cmd.Connection = con

            cmd.CommandText = "Accounts.PenerimaanCashReceiptReport '" & PenerimaanCashReceiptReportFrm.strReceiptNo & "','" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
            cmd.CommandTimeout = 1800
            cmd.CommandType = CommandType.StoredProcedure
            tblAdt.SelectCommand = cmd
            tblAdt.Fill(ds, "PenerimaanCashReceiptReport;1")

            Dim txtEstateName As CrystalDecisions.CrystalReports.Engine.TextObject
            txtEstateName = CType(rpt.ReportDefinition.ReportObjects.Item("txtEstateName"), CrystalDecisions.CrystalReports.Engine.TextObject)
            Dim strArray As String()
            strArray = GlobalPPT.strEstateName.Split("-")
            txtEstateName.Text = strArray(1) + " " + "Petty Cash"

            Dim intTotalAmt As Decimal
            Dim strTotalAmt As String = String.Empty
            If ds.Tables(0).Rows.Count <> 0 Then
                intTotalAmt = ds.Tables(0).Rows(0).Item("Amount")
            End If
            Dim objclsConversion As New clsConversion
            strTotalAmt = objclsConversion.ConvertNumberToWords(intTotalAmt) + "Rp"

            'ToWord
            Dim ToWord As CrystalDecisions.CrystalReports.Engine.TextObject
            ToWord = CType(rpt.ReportDefinition.ReportObjects.Item("ToWord"), CrystalDecisions.CrystalReports.Engine.TextObject)
            'ToWord.Text = strTotalAmt
            ToWord.Text = StrConv(strTotalAmt, VbStrConv.ProperCase)

            '  Dim printSettings As System.Drawing.Printing.PrinterSettings

            '   rpt.PrintOptions.PaperSize.Paper10x14. = PaperSize.Paper10x14
            ' rpt.PrintOptions.PaperSize.




            If ds.Tables(0).Rows.Count > 0 Then
                rpt.SetDataSource(ds.Tables(0))
                CrystalReportViewer1.ReportSource = rpt
            Else
                CrystalReportViewer1.ReportSource = rpt
            End If

        End If

        PettyCashPaymentReportFrm.rptName = ""
        PenerimaanCashReceiptReportFrm.rptName = ""
    End Sub


End Class