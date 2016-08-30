Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Math

Public Class DailyReportFrm
    Public Shared FromDate As String = String.Empty
    Public Shared ToDate As String = String.Empty
    Public Shared StrFrmName As String = String.Empty


    Private Sub btnviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewReport.Click
        Dim objWBTicketInOutPPT As New WBWeighingInOutPPT
        Dim objWBTicketInOutBOL As New WBWeighingInOutBOL

        FromDate = dtpFromDate.Value
        ToDate = dtpToDate.Value

        If rbtnProduct.Checked = True Then
            StrFrmName = "WBDailyReportbyProduct"
            ReportODBCMethod.ShowDialog()
        ElseIf rbtnSupplier.Checked = True Then
            StrFrmName = "WBDailyReportbySupplier"
            ReportODBCMethod.ShowDialog()
        ElseIf rbtnVehicle.Checked = True Then
            StrFrmName = "WBDailyReportbyVehicle"
            ReportODBCMethod.ShowDialog()
        ElseIf rbtnTNo.Checked = True Then
            StrFrmName = "WBDailyReportbyTicketNo"
            ReportODBCMethod.ShowDialog()
        End If
        StrFrmName = ""
    End Sub

    Private Sub DailyReportFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFromDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        dtpFromDate.MaxDate = Date.Today

        dtpToDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        dtpToDate.MaxDate = Date.Today


        SetUICulture(GlobalPPT.strLang)
        dtpFromDate.Format = DateTimePickerFormat.Custom
        dtpFromDate.CustomFormat = "dd/MM/yyyy"

        dtpToDate.Format = DateTimePickerFormat.Custom
        dtpToDate.CustomFormat = "dd/MM/yyyy"
        btnviewReport.Enabled = False
    End Sub

    Private Sub rbtnVehicle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnVehicle.CheckedChanged
        If rbtnProduct.Checked = True Or rbtnSupplier.Checked = True Or rbtnVehicle.Checked = True Or rbtnTNo.Checked = True Then
            btnviewReport.Enabled = True
        Else
            btnviewReport.Enabled = False
        End If
    End Sub

    Private Sub rbtnSupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSupplier.CheckedChanged
        If rbtnProduct.Checked = True Or rbtnSupplier.Checked = True Or rbtnVehicle.Checked = True Then
            btnviewReport.Enabled = True
        Else
            btnviewReport.Enabled = False
        End If
    End Sub

    Private Sub rbtnProduct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnProduct.CheckedChanged
        If rbtnProduct.Checked = True Or rbtnSupplier.Checked = True Or rbtnVehicle.Checked = True Or rbtnTNo.Checked = True Then
            btnviewReport.Enabled = True
        Else
            btnviewReport.Enabled = False
        End If
    End Sub

    'Private Sub rbtnVehicle_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnVehicle.MouseHover, rbtnSupplier.MouseHover, rbtnProduct.MouseHover
    '    If rbtnProduct.Checked = False And rbtnSupplier.Checked = False And rbtnVehicle.Checked = False Then
    '        ToolTip1.Show("Please, select any option to view Report", gbReportOption)
    '    End If
    'End Sub



    Private Sub rbtnVehicle_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnVehicle.MouseHover, rbtnSupplier.MouseHover, rbtnProduct.MouseHover
        If rbtnProduct.Checked = False And rbtnSupplier.Checked = False And rbtnVehicle.Checked = False Then


            'ToolTip1.Show("Please, select any option to view Report", gbReportOption)

            If GlobalPPT.strLang = "en" Then
                ToolTip1.Show("Please, select any option to view Report", gbReportOption)
            ElseIf GlobalPPT.strLang = "ms" Then
                ToolTip1.Show("Silakan, pilih pilihan untuk melihat Laporan", gbReportOption)
            End If
        End If
    End Sub


    Private Sub DailyReportFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DailyReportFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)



            plWeighingDailyReport.CaptionText = rm.GetString("plWeighingDailyReport.CaptionText")


            lblsearchby.Text = rm.GetString("lblsearchby.Text")
            lblFromDate.Text = rm.GetString("lblFromDate.Text")
            lblToDate.Text = rm.GetString("lblToDate.Text")
            lblReceivedBy.Text = rm.GetString("lblReceivedBy.Text")
            rbtnVehicle.Text = rm.GetString("rbtnVehicle.Text")
            rbtnSupplier.Text = rm.GetString("rbtnSupplier.Text")
            rbtnProduct.Text = rm.GetString("rbtnProduct.Text")
            btnviewReport.Text = rm.GetString("btnviewReport.Text")



        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub rbtnTNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnTNo.CheckedChanged
        If rbtnProduct.Checked = True Or rbtnSupplier.Checked = True Or rbtnVehicle.Checked = True Or rbtnTNo.Checked = True Then
            btnviewReport.Enabled = True
        Else
            btnviewReport.Enabled = False
        End If
    End Sub

End Class