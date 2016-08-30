Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_PPT
Imports CheckRoll_BOL
Imports CheckRoll_DAL
Public Class DetailPremiPanenForm
    Public LSource As String = String.Empty
    Public LFormula As String = String.Empty
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProc.Click
        LFormula = "{DetailPremiReport;1.ActiveMonthYearId}= '" & GlobalPPT.strActMthYearID & "'"
        LSource = "DetailPremiReport"
        ViewReport._Formula = LFormula
        ViewReport._Source = LSource
        ViewReport.ShowDialog()
    End Sub

    Private Sub DetailPremiPanenForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StartDate.Value = GlobalPPT.FiscalYearFromDate
        EndDate.Value = GlobalPPT.FiscalYearToDate

        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()
    End Sub
End Class