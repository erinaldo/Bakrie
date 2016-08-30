Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Math
Public Class WBCropReport
    Public Shared FromDate As String = String.Empty
    Public Shared ToDate As String = String.Empty
    Public Shared StrFrmName As String = String.Empty
    Private Sub btnviewReport_Click(sender As System.Object, e As System.EventArgs) Handles btnviewReport.Click
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL

        FromDate = dtpFromDate.Value
        ToDate = dtpToDate.Value
        StrFrmName = "WBFieldBlockDailyReport"
        ReportODBCMethod.ShowDialog()

    End Sub

    Private Sub WBCropReport_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        dtpFromDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        dtpFromDate.MaxDate = Date.Today

        dtpToDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        dtpToDate.MaxDate = Date.Today

        dtpFromDate.Format = DateTimePickerFormat.Custom
        dtpFromDate.CustomFormat = "dd/MM/yyyy"

        dtpToDate.Format = DateTimePickerFormat.Custom
        dtpToDate.CustomFormat = "dd/MM/yyyy"

    End Sub
End Class