Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports System.Math
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal
Imports System.Drawing.Printing
Imports BSP.LoginFrm



Public Class SummaryReportsFrm
    Public Shared StrFrmName As String = String.Empty
    Public Shared strAmonth As String = String.Empty
    Public Shared strAYear As String = String.Empty
    Public Shared strmonname As String = String.Empty
    Public Shared strtask As String = String.Empty
    Public Shared strFrmDate As String = String.Empty
    Public Shared strToDate As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryReportsFrm))




    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

        If IsValid() = False Then
            Exit Sub
        End If

        Reportget()

    End Sub

    Private Sub SummaryReportsFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SetUICulture(GlobalPPT.strLang)
        Dim ds As DataSet
        Dim objSummaryReportsPPT As New SummaryReportsPPT
        Dim objSummaryReportsBOL As New SummaryReportsBOL
        Dim Lmonth As String
        Dim LYear As String
        Lmonth = GlobalPPT.IntLoginMonth
        LYear = GlobalPPT.intLoginYear

        ''temp start
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
        ''temp end 

        ds = objSummaryReportsBOL.GetInterfaceYear(objSummaryReportsPPT)

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

    Private Function IsValid() As Boolean

        If rbAdjustmentSummary.Checked = False And rbIDNSummary.Checked = False And rbITININSummary.Checked = False And rbITNOUTSummary.Checked = False And rbRGNSummary.Checked = False Then
            DisplayInfoMessage("msg01")
            ''MessageBox.Show("Please select any one of the Reports")
            Return False
        ElseIf cbMonth.Text = String.Empty And cbYear.Text = String.Empty Then
            DisplayInfoMessage("msg07")
            ''MessageBox.Show("There is no record found")
            Return False

        End If
        Return True
    End Function

    Private Sub Reportget()
     

        Dim objSummaryReportsPPT As New SummaryReportsPPT
        Dim objSummaryReportsBOL As New SummaryReportsBOL
        Dim strsummaryname As String = String.Empty
        Dim ds As New DataSet
        Dim complete As String = String.Empty

        objSummaryReportsPPT.AMonth = cbMonth.SelectedValue
        objSummaryReportsPPT.AYear = cbYear.Text

        If rbIDNSummary.Checked = True Then
            objSummaryReportsPPT.Task = "Estate/Mill Delivery note approval"
            strtask = "Estate/Mill Delivery note approval"
        ElseIf rbITININSummary.Checked = True Then
            objSummaryReportsPPT.Task = "Internal Transfer Note IN approval"
            strtask = "Internal Transfer Note IN approval"
        ElseIf rbITNOUTSummary.Checked = True Then
            objSummaryReportsPPT.Task = "Internal Transfer Note OUT approval"
            strtask = "Internal Transfer Note OUT approval"
        ElseIf rbAdjustmentSummary.Checked = True Then
            objSummaryReportsPPT.Task = "Stock adjustment approval"
            strtask = "Stock adjustment approval"
        ElseIf rbRGNSummary.Checked = True Then
            objSummaryReportsPPT.Task = "Return goods note approval"
            strtask = "Return goods note approval"
        End If

        ds = objSummaryReportsBOL.GetTaskComplete(objSummaryReportsPPT)

        If ds.Tables(0).Rows.Count > 0 Then
            complete = ds.Tables(0).Rows(0).Item("Complete").ToString()
        End If


        If complete = "N" Then

            If strtask = "Estate/Mill Delivery note approval" Then

                Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryReportsFrm))
                If MsgBox(rm.GetString("msg02"), MsgBoxStyle.YesNo) <> Windows.Forms.DialogResult.Cancel Then
                    objSummaryReportsPPT.AMonth = cbMonth.SelectedValue
                    objSummaryReportsPPT.AYear = cbYear.Text
                    ds = objSummaryReportsBOL.GetFYearDate(objSummaryReportsPPT)
                    strFrmDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                    strToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()
                    IDNSummary()
                Else
                    Exit Sub
                End If
                complete = String.Empty
                '' MessageBox.Show("Some of Estate/Mill Delivery note  not approved, do you still want to preview the report YES/NO", "BSP", MessageBoxButtons.OKCancel, _
            End If



            If strtask = "Internal Transfer Note IN approval" Then

                Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryReportsFrm))
                If MsgBox(rm.GetString("msg03"), MsgBoxStyle.YesNo) <> Windows.Forms.DialogResult.No Then
                    objSummaryReportsPPT.AMonth = cbMonth.SelectedValue
                    objSummaryReportsPPT.AYear = cbYear.Text
                    ds = objSummaryReportsBOL.GetFYearDate(objSummaryReportsPPT)
                    strFrmDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                    strToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()
                    ITNINSummary()
                Else
                    Exit Sub
                End If
                complete = String.Empty
                '' MessageBox.Show("Some of Internal Transfer Note IN  not approved, do you still want to preview the report YES/NO", "BSP", MessageBoxButtons.OKCancel, _
            End If


            If strtask = "Internal Transfer Note OUT approval" Then
                ''If MessageBox.Show("Some of Internal Transfer Note OUT  not approved, do you still want to preview the report YES/NO", "BSP", MessageBoxButtons.OKCancel, _
                Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryReportsFrm))
                If MsgBox(rm.GetString("msg04"), MsgBoxStyle.YesNo) <> Windows.Forms.DialogResult.No Then
                    objSummaryReportsPPT.AMonth = cbMonth.SelectedValue
                    objSummaryReportsPPT.AYear = cbYear.Text
                    ds = objSummaryReportsBOL.GetFYearDate(objSummaryReportsPPT)
                    strFrmDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                    strToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()
                    ITNOUTSummary()
                Else
                    Exit Sub
                End If
                complete = String.Empty
            End If



            If strtask = "Stock adjustment approval" Then
                ''If MessageBox.Show("Some of Stock adjustment  not approved, do you still want to preview the report YES/NO", "BSP", MessageBoxButtons.OKCancel, _
                Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryReportsFrm))
                If MsgBox(rm.GetString("msg05"), MsgBoxStyle.YesNo) <> Windows.Forms.DialogResult.No Then
                    objSummaryReportsPPT.AMonth = cbMonth.SelectedValue
                    objSummaryReportsPPT.AYear = cbYear.Text
                    ds = objSummaryReportsBOL.GetFYearDate(objSummaryReportsPPT)
                    strFrmDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                    strToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()
                    AdjustmentSummary()
                Else
                    Exit Sub
                End If
                complete = String.Empty
            End If


            If strtask = "Return goods note approval" Then
                ''If MessageBox.Show("Some of Return goods note  not approved, do you still want to preview the report YES/NO", "BSP", MessageBoxButtons.OKCancel, _
                Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryReportsFrm))
                If MsgBox(rm.GetString("msg06"), MsgBoxStyle.YesNo) <> Windows.Forms.DialogResult.No Then
                    objSummaryReportsPPT.AMonth = cbMonth.SelectedValue
                    objSummaryReportsPPT.AYear = cbYear.Text
                    ds = objSummaryReportsBOL.GetFYearDate(objSummaryReportsPPT)
                    strFrmDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
                    strToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()
                    RGNSummary()
                Else
                    Exit Sub
                End If
                complete = String.Empty

            End If

        Else

            objSummaryReportsPPT.AMonth = cbMonth.SelectedValue
            objSummaryReportsPPT.AYear = cbYear.Text
            ds = objSummaryReportsBOL.GetFYearDate(objSummaryReportsPPT)
            strFrmDate = ds.Tables(0).Rows(0).Item("FromDT").ToString()
            strToDate = ds.Tables(0).Rows(0).Item("ToDT").ToString()

            If rbIDNSummary.Checked = True Then
                IDNSummary()

            ElseIf rbITININSummary.Checked = True Then
                ITNINSummary()

            ElseIf rbITNOUTSummary.Checked = True Then
                ITNOUTSummary()

            ElseIf rbAdjustmentSummary.Checked = True Then
                AdjustmentSummary()

            ElseIf rbRGNSummary.Checked = True Then
                RGNSummary()

            End If

            End If
    End Sub

    Private Sub IDNSummary()
        StrFrmName = "IDNSummaryReport"
        strAmonth = cbMonth.SelectedValue
        strAYear = cbYear.Text
        strmonname = cbMonth.SelectedValue
        ReportODBCMethod.ShowDialog()
        StrFrmName = ""
        strAmonth = ""
        strAYear = ""
    End Sub
    Private Sub ITNINSummary()
        StrFrmName = "ITNINSummary"
        strAmonth = cbMonth.SelectedValue
        strAYear = cbYear.Text
        strmonname = cbMonth.SelectedValue
        ReportODBCMethod.ShowDialog()
        StrFrmName = ""
        strAmonth = ""
        strAYear = ""
    End Sub
    Private Sub ITNOUTSummary()
        StrFrmName = "ITNOUTSummary"
        strAmonth = cbMonth.SelectedValue
        strAYear = cbYear.Text
        strmonname = cbMonth.SelectedValue
        ReportODBCMethod.ShowDialog()
        StrFrmName = ""
        strAmonth = ""
        strAYear = ""
    End Sub
    Private Sub AdjustmentSummary()
        StrFrmName = "AdjustmentSummary"
        strAmonth = cbMonth.SelectedValue
        strAYear = cbYear.Text
        strmonname = cbMonth.SelectedValue
        ReportODBCMethod.ShowDialog()
        StrFrmName = ""
        strAmonth = ""
        strAYear = ""
    End Sub
    Private Sub RGNSummary()
        StrFrmName = "RGNSummary"
        strAmonth = cbMonth.SelectedValue
        strAYear = cbYear.Text
        strmonname = cbMonth.SelectedValue
        ReportODBCMethod.ShowDialog()
        StrFrmName = ""
        strAmonth = ""
        strAYear = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub
    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryReportsFrm))
        Try
             
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            pnlSummaryrpts.CaptionText = rm.GetString("pnlSummaryrpts.CaptionText")
            lblsearchBy.Text = rm.GetString("lblsearchBy.Text")
            lblMonth.Text = rm.GetString("lblMonth.Text")
            lblYear.Text = rm.GetString("lblYear.Text")
            rbIDNSummary.Text = rm.GetString("rbIDNSummary.Text")
            rbITININSummary.Text = rm.GetString("rbITININSummary.Text")
            rbITNOUTSummary.Text = rm.GetString("rbITNOUTSummary.Text")
            rbRGNSummary.Text = rm.GetString("rbRGNSummary.Text")
            rbAdjustmentSummary.Text = rm.GetString("rbAdjustmentSummary.Text")
            btnReport.Text = rm.GetString("btnReport.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
        
        Catch
            
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SummaryReportsFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub SummaryReportsFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class