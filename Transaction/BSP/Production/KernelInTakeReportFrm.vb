Imports Production_PPT
Imports Production_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal


Public Class KernelInTakeReportFrm

    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If cbMonth.SelectedValue Is Nothing Or cbYear.SelectedValue Is Nothing Then
            If GlobalPPT.strLang <> "en" Then
                MessageBox.Show("Silahkan Pilih Bulan dan Tahun")
            Else
                MessageBox.Show("Please Choose Month and Year")
            End If

            Exit Sub
        End If
    End Sub

    Private Sub KernelInTakeReportFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ProductionKCPReportFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetInterface()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
        Me.Close()
        ' End If
    End Sub

    Private Sub GetInterface()

        Dim ds As New DataSet
        Dim objProductionKCPReportPPT As New ProductionKCPReportPPT
        Dim objProductionKCPReportBOL As New ProductionKCPReportBOL
        ds = objProductionKCPReportBOL.GetInterfaceYear(objProductionKCPReportPPT)
        If ds.Tables(0).Rows.Count > 0 Then
            cbYear.DataSource = ds.Tables(0)
            cbYear.DisplayMember = "AYear"
            cbYear.ValueMember = "AYear"
        End If


        Dim Months As New ArrayList

        'add month structure entries to the arraylist
        With Months
            .Add("JANUARY")
            .Add("FEBRUARY")
            .Add("MARCH")
            .Add("APRIL")
            .Add("MAY")
            .Add("JUNE")
            .Add("JULY")
            .Add("AUGUST")
            .Add("SEPTEMBER")
            .Add("OCTOBER")
            .Add("NOVEMBER")
            .Add("DECEMBER")
        End With

        cbMonth.DataSource = Months

        cbYear.SelectedValue = Date.Now.Year

        Select Case Date.Now.Month
            Case 1
                cbMonth.SelectedIndex = 0
            Case 2
                cbMonth.SelectedIndex = 1
            Case 3
                cbMonth.SelectedIndex = 2
            Case 4
                cbMonth.SelectedIndex = 3
            Case 5
                cbMonth.SelectedIndex = 4
            Case 6
                cbMonth.SelectedIndex = 5
            Case 7
                cbMonth.SelectedIndex = 6
            Case 8
                cbMonth.SelectedIndex = 7
            Case 9
                cbMonth.SelectedIndex = 8
            Case 10
                cbMonth.SelectedIndex = 9
            Case 11
                cbMonth.SelectedIndex = 10
            Case 12
                cbMonth.SelectedIndex = 11
        End Select

    End Sub

 

End Class