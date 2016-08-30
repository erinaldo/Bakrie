Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient
Imports Common_BOL
Imports Common_PPT
Imports Store_BOL
Imports Store_PPT
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Public Class ReportFrm
    Dim cryRpt As New ReportDocument
    Dim lAppPath As String
    Dim strDatasource As String
    Dim strDataBase As String = String.Empty
    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty

    Public Sub DataBaseSource()
        strDatasource = GlobalPPT.SelectedDB.Server
        strDataBase = GlobalPPT.SelectedDB.DBName
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
    End Sub

    Private Sub ReportFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DataBaseSource()

        Dim ParamterFields As New CrystalDecisions.Shared.ParameterFields
        Dim ParamterField1 As New CrystalDecisions.Shared.ParameterField
        Dim ParamterField2 As New CrystalDecisions.Shared.ParameterField

        Dim ParamterDescreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue
        Dim ParamterDescreteValue3 As New CrystalDecisions.Shared.ParameterDiscreteValue

        ParamterField1.ParameterFieldName = "@ActiveMonthYearID"
        ParamterDescreteValue2.Value = GlobalPPT.strActMthYearID
        ParamterField1.CurrentValues.Add(ParamterDescreteValue2)
        ParamterFields.Add(ParamterField1)

        ParamterField2.ParameterFieldName = "@EstateID"
        ParamterDescreteValue3.Value = GlobalPPT.strEstateID
        ParamterField2.CurrentValues.Add(ParamterDescreteValue3)
        ParamterFields.Add(ParamterField2)
        crvReport.ParameterFieldInfo = ParamterFields
        If InternalPurchaseRequisitionFrm.StrFrmName = "IPR" Then
            IPRReport()
        ElseIf InternalServiceRequisitionFrm.StrFrmName = "ISR" Then
            ISRReport()
        ElseIf StoreIssueVoucherFrm.StrFrmName = "SIV" Then
            SIVReport()
        ElseIf EstateMillDeliveryNoteFrm.StrFrmName = "EstMillDelivery" Then
            EstMillDeliveryReport()
        ElseIf InternalTransferNoteINFrm.StrFrmName = "ITNIn" Then
            ITNInReport()
        ElseIf InternalTransferNoteOUTFrm.StrFrmName = "ITNOut" Then
            ITNOUTReport()
        End If
       

    End Sub
    Public Sub IPRReport()
        lAppPath = (Application.StartupPath & "\Reports\IPRReport.rpt")
        cryRpt.Load(lAppPath)
        cryRpt.SetDatabaseLogon(strServerUserName, strServerPassword, strDatasource, strDataBase)
        crvReport.ReportSource = cryRpt
    End Sub

    Public Sub ISRReport()

        lAppPath = (Application.StartupPath & "\Reports\ISRReport.rpt")
        cryRpt.Load(lAppPath)
        cryRpt.SetDatabaseLogon(strServerUserName, strServerPassword, strDatasource, strDataBase)
        crvReport.ReportSource = cryRpt
    End Sub

    Public Sub SIVReport()
        lAppPath = (Application.StartupPath & "\Reports\SIVReport.rpt")
        cryRpt.Load(lAppPath)
        cryRpt.SetDatabaseLogon(strServerUserName, strServerPassword, strDatasource, strDataBase)
        crvReport.ReportSource = cryRpt
    End Sub
    Public Sub EstMillDeliveryReport()

        lAppPath = (Application.StartupPath & "\Reports\EstMillDeliveryReport.rpt")
        cryRpt.Load(lAppPath)
        cryRpt.SetDatabaseLogon(strServerUserName, strServerPassword, strDatasource, strDataBase)
        crvReport.ReportSource = cryRpt
    End Sub
    Public Sub ITNInReport()
        lAppPath = (Application.StartupPath & "\Reports\ITNInReport.rpt")
        cryRpt.Load(lAppPath)
        cryRpt.SetDatabaseLogon(strServerUserName, strServerPassword, strDatasource, strDataBase)
        crvReport.ReportSource = cryRpt
    End Sub
    Public Sub ITNOUTReport()
        lAppPath = (Application.StartupPath & "\Reports\ITNOUTReport.rpt")
        cryRpt.Load(lAppPath)
        cryRpt.SetDatabaseLogon(strServerUserName, strServerPassword, strDatasource, strDataBase)
        crvReport.ReportSource = cryRpt
    End Sub

End Class