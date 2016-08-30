''======
'
' Programmer : Dadang Adi Hendradi
' Created    : Ahad, 27 Dec 2009, 16:19
' Place      : Kuala Lumpur 
'
Imports Common_PPT
Imports CheckRoll_DAL

Public Class THR

    Private Sub THR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtpProcDate.MinDate = GlobalPPT.FiscalYearFromDate
        dtpProcDate.MaxDate = GlobalPPT.FiscalYearToDate

        ' Jum'at, 12 Mar 2010, 18:07
        Dim startDate As Date = New Date(GlobalPPT.intActiveYear, 1, 1) ' Jan
        Dim EndDate As Date = New Date(GlobalPPT.intActiveYear, 12, 31) ' Dec

        dtpProcDate.MinDate = startDate
        dtpProcDate.MaxDate = EndDate
        ' END Jum'at, 12 Mar 2010, 18:07

        If Now() >= GlobalPPT.FiscalYearFromDate And Now() <= GlobalPPT.FiscalYearToDate Then
            dtpProcDate.Value = Now()
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ' Senin, 28 Dec 2009, 11:04
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' Selasa, 29 Dec 2009, 17:23
        LblMsg.Visible = True
        LblMsg.Text = "Processing..."
        LblMsg.Refresh()
        If Me.txtTunjanganBeras.Value < 0 Then
            MsgBox("Please enter a valid Harga Beras", vbInformation)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        THRDAL.CRTHRInsert(dtpProcDate.Value, Me.txtTunjanganBeras.Value)

        ' Jum'at, 1 Jan 2010, 13:48
        CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("N")
        ' END Jum'at, 1 Jan 2010, 13:48

        Cursor = Cursors.Default

        LblMsg.Text = "Finish."
        LblMsg.Refresh()

    End Sub

End Class