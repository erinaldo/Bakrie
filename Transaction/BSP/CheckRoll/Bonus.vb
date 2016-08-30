
Imports Common_PPT
Imports CheckRoll_DAL

Public Class Bonus

    Private Sub Bonus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        If Me.txtNoofMonths.Value <= 0 Then
            MsgBox("Please enter a valid no of months", vbInformation)
            Exit Sub
        End If

        If txtDeductionSBSI.Value < 0 Then
            MsgBox("Please enter valid Deduction SPSI", vbInformation)
            Exit Sub
        End If


        If txtDeductionSPSB.Value < 0 Then
            MsgBox("Please enter valid Deduction SPSB", vbInformation)
            Exit Sub
        End If

        If Me.txtTunjanganBeras.Value < 0 Then
            MsgBox("Please enter valid Harga Beras", vbInformation)
            Exit Sub
        End If


        LblMsg.Visible = True
        LblMsg.Text = "Processing..."
        LblMsg.Refresh()

        Cursor = Cursors.WaitCursor
        If Me.optPreviousBonus.Checked = True Then
            'BonusDAL.CRBonusInsertOtherMonth(dtpProcDate.Value, Month(Me.dtOtherMonthYear.Value), Year(Me.dtOtherMonthYear.Value))
            BonusDAL.CRBonusInsert(dtpProcDate.Value, Me.txtNoofMonths.Value, txtDeductionSBSI.Value, txtDeductionSPSB.Value, txtTunjanganBeras.Value, Month(Me.dtOtherMonthYear.Value), Year(Me.dtOtherMonthYear.Value))
        Else
            BonusDAL.CRBonusInsert(dtpProcDate.Value, Me.txtNoofMonths.Value, txtDeductionSBSI.Value, txtDeductionSPSB.Value, txtTunjanganBeras.Value, 0, 0)
        End If
       
        Cursor = Cursors.Default

        LblMsg.Text = "Finish."
        LblMsg.Refresh()

    End Sub

    Private Sub optPreviousBonus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optPreviousBonus.CheckedChanged
        If Me.optPreviousBonus.Checked = True Then
            Me.dtOtherMonthYear.Enabled = True
        Else
            Me.dtOtherMonthYear.Enabled = False
        End If
    End Sub

    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs) Handles Label7.Click

    End Sub
End Class