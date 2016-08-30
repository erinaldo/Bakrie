'--------------------------------
'
' By Dadang Adi H
' Jum'at, 08 Jan 2010, 22:29
'
'--------------------------------
Public Class RekapLaporanMandor

    Private Sub RekapLaporanMandor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ' Jum'at, 08 Jan 2010, 22:29
        Me.Close()
    End Sub

    Private Sub btnRekapLapMandorTPanen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRekapLapMandorTPanen.Click
        '----------------------------------
        ' Rekap Laporan Mandor Team Panen
        '----------------------------------
        ' By Dadang
        ' Jum'at, 08 Jan 2010, 22:40
        ' Place: Kuala Lumpur
        Cursor = Cursors.WaitCursor

        Dim report As New ViewReport()
        Dim ReportName As String


        ReportName = "CRRekapLapMandorPanenReport"
        report._Source = ReportName
        report.ShowDialog()

        Cursor = Cursors.Default

    End Sub

    Private Sub btnRekapLapMandorTLain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRekapLapMandorTLain.Click
        '----------------------------------
        ' Rekap Laporan Mandor Team Panen
        '----------------------------------
        ' By Dadang
        ' Jum'at, 08 Jan 2010, 11:59
        ' Place: Kuala Lumpur
        Cursor = Cursors.WaitCursor

        Dim report As New ViewReport()
        Dim ReportName As String

        'ReportName = "CRRekapLapMandorLainMasterReport"
        ' Kamis, 18 Mar 2010, 18:31
        ReportName = "CRRekapLapMandorLainReport"
        ' END Kamis, 18 Mar 2010, 18:31
        report._Source = ReportName
        report.ShowDialog()

        Cursor = Cursors.Default

    End Sub
End Class