Imports Common_BOL
Imports Common_PPT
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class CRViewer

    Private _reportData As ReportData

    Public Sub New(ByVal reportData As ReportData)
        'initialize report
        Me.InitializeComponent()

        '================== Example Report Viewer Usage ========================

        'Dim reportData As New ReportData
        'reportData.ReportSource = "Reports\CRPieceRateReport.rpt"
        'Dim par1 As New ReportData.ReportParameter
        'par1.Name = "@EmpID"
        'par1.Value = "01R600"
        'reportData.Parameters = New List(Of ReportData.ReportParameter)
        'reportData.Parameters.Add(par1)

        'Dim reportViewer As New CRViewer(reportData)
        'reportViewer.ShowDialog()

        '==========================================================

        _reportData = reportData
    End Sub

    Private Sub CRViewer_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub CRViewer_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        ReportView()
    End Sub

    Dim Server As String = GlobalPPT.SelectedDB.DSN
    Dim Database As String = GlobalPPT.SelectedDB.DBName
    Dim User As String = GlobalPPT.SelectedDB.User
    Dim Pass As String = GlobalPPT.SelectedDB.Password

    Sub ReportView()
        Dim crReportDocument As New ReportDocument

        If _reportData.ReportSource = String.Empty Then
            'embbeded report

            crReportDocument = _reportData.ReportObject

            For Each parameter In _reportData.Parameters
                'assign the parameters with value
                ParameterAdd(parameter.Name, parameter.Value, crReportDocument)
            Next

            ' pass database connection information
            Dim myTable As CrystalDecisions.CrystalReports.Engine.Table
            Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()

            For Each myTable In crReportDocument.Database.Tables
                Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
                myConnectionInfo.ServerName = Server
                myConnectionInfo.DatabaseName = Database
                myConnectionInfo.UserID = User
                myConnectionInfo.Password = Pass
                myTableLogonInfo.ConnectionInfo = myConnectionInfo
                myTable.ApplyLogOnInfo(myTableLogonInfo)
            Next

            'crReportDocument.SetDatabaseLogon(User, Pass, Server, Database)
            crystalViewer.ReportSource = crReportDocument
        Else
            If System.IO.File.Exists(_reportData.ReportSource) Then
                'crReportDocument.Load("reports\rptLeaveReport.rpt") ' report path
                crReportDocument.Load(_reportData.ReportSource) ' report path

                For Each parameter In _reportData.Parameters
                    'assign the parameters with value
                    ParameterAdd(parameter.Name, parameter.Value, crReportDocument)
                Next

                ' pass database connection information
                Dim myTable As CrystalDecisions.CrystalReports.Engine.Table
                Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()

                For Each myTable In crReportDocument.Database.Tables
                    Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
                    myConnectionInfo.ServerName = Server
                    myConnectionInfo.DatabaseName = Database
                    myConnectionInfo.UserID = User
                    myConnectionInfo.Password = Pass
                    myTableLogonInfo.ConnectionInfo = myConnectionInfo
                    myTable.ApplyLogOnInfo(myTableLogonInfo)
                Next

                'crReportDocument.SetDatabaseLogon(User, Pass, Server, Database)
                crystalViewer.ReportSource = crReportDocument
            Else
                MessageBox.Show("Could not locate the report from \n" + _reportData.ReportSource, "Report not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If





    End Sub

    Sub ParameterAdd(ByVal pstrName As String, ByVal pstrValue As String, ByVal crReportDocument As ReportDocument)


        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition

        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        'Set discrete value
        crParameterDiscreteValue.Value = pstrValue

        'Access first parameter field definition
        crParameterFieldDefinitions = crReportDocument.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item(pstrName)

        ' Add parameter value
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Add(crParameterDiscreteValue)

        ' Apply the current value to the parameter definition
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    End Sub


    
End Class

Public Class ReportData
    Public Property ReportSource As String
    Public Property Parameters As List(Of ReportParameter)
    Public Property ReportObject As Object

    Public Class ReportParameter
        Public Property Name As String
        Public Property Value As String
    End Class
End Class