Imports System.Data.SqlClient
Imports Common_PPT

Public Class PieceRateTransactionRptFrm

    Private Sub btnReport_Click(sender As System.Object, e As System.EventArgs) Handles btnReport.Click

        ViewReport()

    End Sub

    Sub ViewReport()

        Dim report As New ViewReport()
        Dim ReportName As String

        'ReportName = "CRRekapLapMandorLainMasterReport"
        ' Kamis, 18 Mar 2010, 18:31
        ReportName = "CRPieceRateReport"
        ' END Kamis, 18 Mar 2010, 18:31
        report._Source = ReportName

        '  report._Formula = _
        ' "{CRRekapLapMandorLainReport;1.RDate} = #" + RDate + "# AND " + _
        ' "{CRRekapLapMandorLainReport;1.GangName} = '" + GangName + "'"

        report.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


End Class