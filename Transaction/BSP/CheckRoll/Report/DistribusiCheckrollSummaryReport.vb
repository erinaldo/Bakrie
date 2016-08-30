

Imports CheckRoll_PPT
Imports CheckRoll_BOL
Imports Common_PPT
Imports Common_BOL
Imports Common_DAL
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Vehicle_PPT
Imports Vehicle_BOL
Public Class DistribusiCheckrollSummaryReport
    Public Shared intMonth As Integer
    Public Shared intYear As Integer
    Public Shared chkReport As Integer
    Public Shared strActMthYearID As String = String.Empty
    Public Shared strmonth As String = String.Empty
    Public Shared strYear As String = String.Empty
    Public Shared strFiscalYearFromDate As String = String.Empty
    Public Shared strFiscalYearToDate As String = String.Empty
    Private Sub DistribusiCheckrollSummaryReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetInterface()
    End Sub

    Private Sub GetInterface()

        Dim ds As DataSet

        Dim objReportBOL As New ProcessBOL
        Dim Lmonth As String
        Dim LYear As String
        Lmonth = GlobalPPT.IntLoginMonth
        LYear = GlobalPPT.intLoginYear

        If Lmonth = 1 Then
            Lmonth = "January"
        ElseIf Lmonth = 2 Then
            Lmonth = "February"
        ElseIf Lmonth = 3 Then
            Lmonth = "March"
        ElseIf Lmonth = 4 Then
            Lmonth = "April"
        ElseIf Lmonth = 5 Then
            Lmonth = "May"
        ElseIf Lmonth = 6 Then
            Lmonth = "June"
        ElseIf Lmonth = 7 Then
            Lmonth = "July"
        ElseIf Lmonth = 8 Then
            Lmonth = "August"
        ElseIf Lmonth = 9 Then
            Lmonth = "September"
        ElseIf Lmonth = 10 Then
            Lmonth = "October"
        ElseIf Lmonth = 11 Then
            Lmonth = "November"
        ElseIf Lmonth = 12 Then
            Lmonth = "December"
        End If
      
        ds = objReportBOL.GetInterfaceYearDistribusiCR()

        If ds.Tables.Count > 0 Then

            If ds.Tables(0).Rows.Count > 0 Then

                cbYear.DataSource = ds.Tables(0)
                cbYear.DisplayMember = "AYear"
                cbYear.ValueMember = "AYear"
            End If

            cbYear.Text = LYear

            If ds.Tables(1).Rows.Count > 0 Then

                cbMonth.DataSource = ds.Tables(1)
                cbMonth.DisplayMember = "MONTH"
                cbMonth.ValueMember = "AMonth"

            End If

            cbMonth.Text = Lmonth
        End If
    End Sub

   

    Private Sub ActiveMonthYearIDGet()
        Dim objDistribusiBiayaBengkelReportPPT As New DistribusiBiayaBengkelReportPPT
        Dim objDistribusiBiayaBengkelReportBOL As New DistribusiBiayaBengkelReportBOL
        Dim ds As New DataSet

        objDistribusiBiayaBengkelReportPPT.AYear = cbYear.Text
        objDistribusiBiayaBengkelReportPPT.AMonth = cbMonth.SelectedValue.ToString()

        ds = objDistribusiBiayaBengkelReportBOL.ActiveMonthYearIDGet(objDistribusiBiayaBengkelReportPPT)

        If ds.Tables(0).Rows.Count > 0 Then
            strActMthYearID = ds.Tables(0).Rows(0).Item("ActiveMonthYearID")
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            Me.Close()
        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim DistribusiViewSummaryReportReportFrm As New DistribusiViewSummaryReport
        Dim objDistribusiBiayaBengkelReportPPT As New DistribusiBiayaBengkelReportPPT
        Dim objDistribusiBiayaBengkelReportBOL As New DistribusiBiayaBengkelReportBOL

        Dim objReportBOL As New ProcessBOL
        Dim ds As New DataSet
        Dim complete As String = String.Empty

        If cbYear.Text = String.Empty Or cbMonth.Text = String.Empty Then
            MessageBox.Show("Month and Year is required", "BSP", MessageBoxButtons.OK)
            Exit Sub
            Return
        End If


        ActiveMonthYearIDGet()
        objDistribusiBiayaBengkelReportPPT.AMonth = cbMonth.SelectedValue
        objDistribusiBiayaBengkelReportPPT.AYear = cbYear.Text
        ds = objDistribusiBiayaBengkelReportBOL.GetFYearDate(objDistribusiBiayaBengkelReportPPT)


        strFiscalYearFromDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
        strFiscalYearToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()
        strmonth = cbMonth.SelectedValue.ToString
        strYear = cbYear.SelectedValue.ToString

        If rdPLain.Checked Then
            chkReport = 1
        ElseIf RdRawat.Checked Then
            chkReport = 2
        ElseIf rdPDL.Checked Then
            chkReport = 3
        End If

        DistribusiViewSummaryReport.Cursor = Cursors.WaitCursor
        DistribusiViewSummaryReport.Show()
        DistribusiViewSummaryReport.Cursor = Cursors.Arrow
    End Sub

End Class