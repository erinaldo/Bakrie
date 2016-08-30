Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Data

Public Class WBWeighingTicketReportFrm

    Public Shared WBRicketNo As String = String.Empty
    Public Shared StrFrmName As String = String.Empty
    Public Shared Others As String = String.Empty
    Private Sub WBWeighingTicketReportFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        Dim dt As DataTable
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL

        dt = objWBTicketInOutBOL.WBTicket_Report(objWBTicketInOutPPT)
        cmbTicketNo.DataSource = dt
        cmbTicketNo.DisplayMember = "WBTicketNo"
        'cmbTicketNo.Text = "-SELECT-"
    End Sub

    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        'PrintFlag = False
        WBRicketNo = cmbTicketNo.Text
        Others = 0
        StrFrmName = "WBTicketRpt"
        'ReportODBCMethod.CrystalReportViewer1.Visible = False
        ReportODBCMethod.ShowDialog()
    End Sub

    Private Sub WBWeighingTicketReportFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBWeighingTicketReportFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)



            plWBWeighingTicketReport.CaptionText = rm.GetString("plWBWeighingTicketReport.CaptionText")

            lblWeighingTicket.Text = rm.GetString("lblWeighingTicket.Text")

            lblsearchby.Text = rm.GetString("lblsearchby.Text")

            btnviewReport.Text = rm.GetString("btnviewReport.Text")



        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class