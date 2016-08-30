

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
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.Marshal

Public Class pph21KaryawanReport
    Public intYear As Integer
    Public intAfterGetInterfaceYear As Integer
    Private DTTaskMonitor As System.Data.DataTable = Nothing
  
    Private Sub DistribusiCheckrollReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim CheckrollTASK As String = Nothing
        Dim completed As String = Nothing

        Dim mdiparent As New MDIParent

        If MdiParent.strMenuID = "M274" Then
            btnReport.Location = New Point(220, 301)
            btnClose.Location = New Point(344, 301)
            plReport.Size = New Size(771, 334)
            GroupBox1.Visible = True
            GroupBox1.Enabled = True
            GroupBox2.Visible = True
            GroupBox2.Enabled = True
            GroupBox3.Visible = True
            GroupBox3.Enabled = True
            StartSeqNoLabel.Visible = True
            StartSeqNoLabel.Enabled = True
            Label3.Visible = True
            StartSeqNoTextBox.Visible = True
            StartSeqNoTextBox.Enabled = True
            NPWPLabel.Visible = True
            NPWPLabel.Enabled = True
            Label4.Visible = True
            NPWPTextBox.Visible = True
            NPWPTextBox.Enabled = True
            EmployerNameLabel.Visible = True
            EmployerNameLabel.Enabled = True
            Label5.Visible = True
            EmployerNameTextBox.Visible = True
            EmployerNameTextBox.Enabled = True
            AlamatLabel.Visible = True
            AlamatLabel.Enabled = True
            Label11.Visible = True
            AlamatTextBox.Visible = True
            AlamatTextBox.Enabled = True
            TempatLabel.Visible = True
            TempatLabel.Enabled = True
            Label6.Visible = True
            TempatTextBox.Visible = True
            TempatTextBox.Enabled = True
            TanggalLabel.Visible = True
            TanggalLabel.Enabled = True
            Label10.Visible = True
            TanggalDTP.Visible = True
            TanggalDTP.Enabled = True
            JabatanLabel.Visible = True
            JabatanLabel.Enabled = True
            Label7.Visible = True
            JabatanTextBox.Visible = True
            JabatanTextBox.Enabled = True
            RadioButton1.Visible = True
            RadioButton1.Enabled = True
            RadioButton2.Visible = True
            RadioButton2.Enabled = True
            NPWPKuasaLabel.Visible = True
            NPWPKuasaLabel.Enabled = True
            Label9.Visible = True
            NPWPKuasaTextBox.Visible = True
            NPWPKuasaTextBox.Enabled = True
            NameKuasaLabel.Visible = True
            NameKuasaLabel.Enabled = True
            Label8.Visible = True
            NameKuasaTextBox.Visible = True
            NameKuasaTextBox.Enabled = True
        Else
            btnReport.Location = New Point(220, 130)
            btnClose.Location = New Point(344, 130)
            plReport.Size = New Size(771, 173)
            GroupBox1.Visible = False
            GroupBox1.Enabled = False
            GroupBox2.Visible = False
            GroupBox2.Enabled = False
            GroupBox3.Visible = False
            GroupBox3.Enabled = False
            StartSeqNoLabel.Enabled = False
            StartSeqNoLabel.Visible = False
            Label3.Visible = False
            StartSeqNoTextBox.Enabled = False
            StartSeqNoTextBox.Visible = False
            NPWPLabel.Enabled = False
            NPWPLabel.Visible = False
            Label4.Visible = False
            NPWPTextBox.Enabled = False
            NPWPTextBox.Visible = False
            EmployerNameLabel.Enabled = False
            EmployerNameLabel.Visible = False
            Label5.Visible = False
            EmployerNameTextBox.Enabled = False
            EmployerNameTextBox.Visible = False
            AlamatLabel.Visible = False
            AlamatLabel.Enabled = False
            Label11.Visible = False
            AlamatTextBox.Visible = False
            AlamatTextBox.Enabled = False
            TempatLabel.Visible = False
            TempatLabel.Enabled = False
            Label6.Visible = False
            TempatTextBox.Visible = False
            TempatTextBox.Enabled = False
            TanggalLabel.Visible = False
            TanggalLabel.Enabled = False
            Label10.Visible = False
            TanggalDTP.Visible = False
            TanggalDTP.Enabled = False
            JabatanLabel.Visible = False
            JabatanLabel.Enabled = False
            Label7.Visible = False
            JabatanTextBox.Visible = False
            JabatanTextBox.Enabled = False
            RadioButton1.Visible = False
            RadioButton1.Enabled = False
            RadioButton2.Visible = False
            RadioButton2.Enabled = False
            NPWPKuasaLabel.Visible = False
            NPWPKuasaLabel.Enabled = False
            Label9.Visible = False
            NPWPKuasaTextBox.Visible = False
            NPWPKuasaTextBox.Enabled = False
            NameKuasaLabel.Visible = False
            NameKuasaLabel.Enabled = False
            Label8.Visible = False
            NameKuasaTextBox.Visible = False
            NameKuasaTextBox.Enabled = False
        End If

        DTTaskMonitor = CheckRoll_DAL.CheckrollMonthEndClosingDAL.CRTaskMonitorGET()
        If DTTaskMonitor.Rows.Count > 0 Then
            For Each dr As DataRow In DTTaskMonitor.Rows

                CheckrollTASK = dr.Item("TASK").ToString()
                completed = dr.Item("Complete").ToString()

                If CheckrollTASK = "Checkroll monthly Processing" AndAlso completed = "N" Then
                    Exit For
                End If
            Next
            If CheckrollTASK = "Checkroll monthly Processing" AndAlso completed = "N" Then
                If MessageBox.Show( _
                      "Checkroll Monthly processing not done.You are about to view the reports. Do you want to proceed. " + vbCrLf + _
                      "If Yes, click OK, otherwise click Cancel", _
                      "PPH21 Karyawan Reports", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                    Return
                End If
            End If

        End If
        intAfterGetInterfaceYear = 0
        GetInterface()
        intAfterGetInterfaceYear = 1
    End Sub

    Private Sub GetInterface()

        Dim ds As DataSet

        Dim objReportBOL As New ProcessBOL

        Dim LYear As String

        Dim mdiparent As New MDIParent

        LYear = GlobalPPT.intLoginYear

        If mdiparent.strMenuID = "M274" Then
            ds = objReportBOL.GetInterfaceYearPPH21CR_SPT(LYear)
        Else
            ds = objReportBOL.GetInterfaceYearPPH21CR(LYear)
        End If

        If ds.Tables.Count > 0 Then

            If ds.Tables(0).Rows.Count > 0 Then

                cbYear.DataSource = ds.Tables(0)
                cbYear.DisplayMember = "AYear"
                cbYear.ValueMember = "AYear"
            End If

            cbYear.Text = LYear

            If ds.Tables(1).Rows.Count > 0 Then


                Dim dr As DataRow = ds.Tables(1).NewRow()
                dr(1) = "All"
                ds.Tables(1).Rows.InsertAt(dr, 0)
                cbMonth.DataSource = ds.Tables(1)
                cbMonth.DisplayMember = "EmpCode"
                cbMonth.ValueMember = "EmpID"
            End If

            Dim ds2 As DataSet

            If mdiparent.strMenuID = "M274" Then
                ds2 = objReportBOL.GetActiveMonthYear()
                If ds2.Tables.Count > 0 Then

                    If ds2.Tables(0).Rows.Count > 0 Then
                        Dim ds1 As DataSet
                        StartSeqNoTextBox.Enabled = True
                        If cbMonth.Text <> "All" Then
                            ds1 = objReportBOL.GetSPTSeqNo(Convert.ToInt32(cbYear.Text), "")
                            If ds1.Tables(0).Rows(0).Item("SeqNo") = 0 Then
                                'MessageBox.Show("No urut has been generated for this employee, please enter starting sequence number and select Emp.Code All and click View Report.", "BSP", MessageBoxButtons.OK)
                                StartSeqNoTextBox.Text = "1"
                            Else
                                StartSeqNoTextBox.Text = ds1.Tables(0).Rows(0).Item("SeqNo").ToString
                            End If
                        Else
                            ds1 = objReportBOL.GetSPTSeqNo(Convert.ToInt32(cbYear.Text), "")
                            If ds1.Tables(0).Rows(0).Item("SeqNo") = 0 Then
                                'MessageBox.Show("No urut number has been generated for all employee, please enter starting sequence number and select Emp.Code All and click View Report.", "BSP", MessageBoxButtons.OK)
                                StartSeqNoTextBox.Text = "1"
                            Else
                                StartSeqNoTextBox.Text = ds1.Tables(0).Rows(0).Item("SeqNo").ToString
                            End If
                        End If

                        If Convert.ToInt32(cbYear.Text) <> ds2.Tables(0).Rows(0).Item("AYear") Then
                            StartSeqNoTextBox.Enabled = False
                        Else
                            StartSeqNoTextBox.Enabled = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If (MessageBox.Show("Do you want to close this screen? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
            Me.Close()
        End If
    End Sub

    Private Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        If cbYear.Text = String.Empty Or cbMonth.Text = String.Empty Then
            MessageBox.Show("Month and Year is required", "BSP", MessageBoxButtons.OK)
            Exit Sub
            Return
        End If

        Dim mdiparent As New MDIParent


        If mdiparent.strMenuID = "M274" Then
            Try
                Integer.Parse(StartSeqNoTextBox.Text)
            Catch ex As Exception
                MessageBox.Show("No. urut should be an numeric integer value and integer value > 0", "BSP", MessageBoxButtons.OK)
                StartSeqNoTextBox.Focus()
                Exit Sub
                Return
            End Try

            If NPWPTextBox.Text <> String.Empty Then
                If (Len(NPWPTextBox.Text) < 20) Then
                    MessageBox.Show("Pemotong Pajak NPWP should be 20 characters in format eg. 87.056.112.3-813.000", "BSP", MessageBoxButtons.OK)
                    NPWPTextBox.Focus()
                    Exit Sub
                    Return
                End If
            End If

            If NPWPKuasaTextBox.Text <> String.Empty Then
                If (Len(NPWPKuasaTextBox.Text) < 20) Then
                    MessageBox.Show("Pemotong Pajak / Kuasa NPWP should be 20 characters in format eg. 87.056.112.3-813.000", "BSP", MessageBoxButtons.OK)
                    NPWPKuasaTextBox.Focus()
                    Exit Sub
                    Return
                End If
            End If
        End If

        If cbMonth.Text = "All" Then
            If (MessageBox.Show("Generate and display report for ALL employee ? If yes please click 'OK' or click 'Cancel'", "Confirmation", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then

                'added by Stanley@07-09-2011
                If mdiparent.strMenuID = "M274" Then
                    LampiranSPTTahunanPPH21()
                End If

                If mdiparent.strMenuID = "M275" Then
                    PPH21KaryawanReport()
                End If

                If mdiparent.strMenuID = "M276" Then
                    PPH21KaryawanFinalReport()
                End If
            End If
        Else
            'added by Stanley@07-09-2011
            If mdiparent.strMenuID = "M274" Then
                LampiranSPTTahunanPPH21()
            End If

            If mdiparent.strMenuID = "M275" Then
                PPH21KaryawanReport()
            End If

            If mdiparent.strMenuID = "M276" Then
                PPH21KaryawanFinalReport()
            End If
        End If

    End Sub

    Private Sub PPH21KaryawanReport()

        Dim fMsg As New ProgressingFrm
        fMsg.TopMost = True
        fMsg.Show()
        ' fMsg.lblMessage.Refresh()
        fMsg.lblTitle.Refresh()
        fMsg.lblTitle.Text = "DATA PPH 21 KARYAWAN Report Processing . . ."
        fMsg.lblTitle.Refresh()

        Cursor = Cursors.WaitCursor

        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim ReportDirectory As String = String.Empty

        Dim sheet As Excel.Worksheet
        xlApp = New Excel.Application

        Dim TemPath As String = Application.StartupPath & "\Reports\Checkroll\Excel\PPH21Employee_Report_Template.xls"

        If (File.Exists(TemPath)) Then

            xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath & "\Reports\Checkroll\Excel\PPH21Employee_Report_Template.xls")
        Else
            MsgBox("DATA PPH 21 KARYAWAN report template missing.Please contact system administrator.")
            Exit Sub
        End If

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            MessageBox.Show("Report directory not found", "BSP")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Checkroll Reports")
        ' Determine whether the directory exists.
        If Not di.Exists Then
            di.Create()
        End If

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName

        Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd1 As New SqlCommand
        Dim da As New SqlDataAdapter
        con = New SqlConnection(constr)

        con.Open()

        cmd.Connection = con
        cmd.CommandText = "Checkroll.PPH21KaryawanReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        If cbYear.Text = "All" Then
            cmd.Parameters.AddWithValue("@EmpID", "")
        Else
            cmd.Parameters.AddWithValue("@EmpID", cbMonth.SelectedValue)
        End If
        cmd.Parameters.AddWithValue("@Year", cbYear.SelectedValue)


        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "PPH21KaryawanReport")
        Dim Pageno As Integer
        Pageno = 1


        sheet = xlWorkBook.Sheets("Sheet1")
        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)


        Dim objCommonBOl As New GlobalBOL
        sheet.Cells(4, 9) = "Date: " & String.Format("{0:dd/MM/yyyy}", Date.Today)

        sheet.Cells(5, 2) = "Estate/Mill :" & GlobalPPT.strEstateName.Substring(GlobalPPT.strEstateName.IndexOf("-") + 1) & " "
        'sheet.Cells(6, 8) = ds.Tables(0).Rows(0).Item("FromDT").ToString()
        'sheet.Cells(6, 10) = ds.Tables(0).Rows(0).Item("ToDT").ToString()
        '' sheet.Cells(5, 10) = Pageno

        strMonthlyProdRptName = "DATA PPH 21 KARYAWAN - " & " " & GlobalPPT.intActiveYear & ""
        sheet.Cells(8, 2) = "DATA PPH 21 KARYAWAN - " & " " & GlobalPPT.intActiveYear & ""


        Dim StrPath As String = "" & sDirName & "\BSP Checkroll Reports\" & strMonthlyProdRptName & ".xls"
        If ds.Tables(0).Rows.Count = 0 Then
            'sheet.Protect("RANNBSP@2010")

            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If
            xlApp.Visible = True
            Cursor = Cursors.Default
            Exit Sub
        End If


        Dim CountRecords As Integer = 0
        Dim nikRowCount As Integer = 11
        Dim nikColumnCount As Integer = 1
        Dim startIndex, EndIndex, lcount, TCount As New Integer
        Dim oRng As Excel.Range


        If ds IsNot Nothing Then
            CountRecords = ds.Tables(0).Rows.Count
            'CountRecords = 26

            While CountRecords > 0

                sheet.Cells(nikRowCount, nikColumnCount) = "NIK    :"
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount).HorizontalAlignment = Excel.Constants.xlLeft
                sheet.Cells(nikRowCount, nikColumnCount) = "'" + ds.Tables(0).Rows(lcount).Item("NIK").ToString()
                nikColumnCount = 1
                nikRowCount = nikRowCount + 1
                sheet.Cells(nikRowCount, nikColumnCount) = "Nama :"
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("Nama").ToString()
                nikColumnCount = 1
                nikRowCount = nikRowCount + 1
                sheet.Cells(nikRowCount, nikColumnCount) = "Status :"
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("MStatus").ToString()
                nikColumnCount = 1
                nikRowCount = nikRowCount + 2

                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount) = "Period"
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(nikRowCount, nikColumnCount) = "Gaji / Upah Pokok"
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(nikRowCount, nikColumnCount) = "Tunjangan"
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(nikRowCount, nikColumnCount) = "Premi Asuransi"
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(nikRowCount, nikColumnCount) = "THR / Bonus"
                nikColumnCount = nikColumnCount + 1


                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(nikRowCount, nikColumnCount) = "PPH21 yang telah dibayar"
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(nikRowCount, nikColumnCount) = "PPH21 Terhutang"
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(nikRowCount, nikColumnCount) = "PPH21 Ditanggung Pemerintah"
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

                sheet.Cells(nikRowCount, nikColumnCount) = "PPH21 Ditanggung Karyawan"
                nikColumnCount = nikColumnCount + 1
                Dim CountPeriod As Integer = 0
                startIndex = nikRowCount + 1
                Dim nik As String = String.Empty
                nik = ds.Tables(0).Rows(lcount).Item("NIK").ToString()

                fMsg.lblTitle.Refresh()
                fMsg.lblTitle.Text = "DATA PPH 21 KARYAWAN Report Processing for Employee " & ds.Tables(0).Rows(lcount).Item("Nama").ToString() & ". . ."
                fMsg.lblTitle.Refresh()

                While nik = ds.Tables(0).Rows(lcount).Item("NIK").ToString()
                    nikRowCount = nikRowCount + 1
                    nikColumnCount = 1

                    sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("Period").ToString()
                    sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    nikColumnCount = nikColumnCount + 1
                    sheet.Cells(nikRowCount, nikColumnCount) = IIf(ds.Tables(0).Rows(lcount).Item("Gaji").ToString().Trim() = "", "0", ds.Tables(0).Rows(lcount).Item("Gaji").ToString().Trim())
                    sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    nikColumnCount = nikColumnCount + 1
                    sheet.Cells(nikRowCount, nikColumnCount) = IIf(ds.Tables(0).Rows(lcount).Item("Tunjangan").ToString().Trim() = "", "0", ds.Tables(0).Rows(lcount).Item("Tunjangan").ToString().Trim())
                    sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    nikColumnCount = nikColumnCount + 1
                    sheet.Cells(nikRowCount, nikColumnCount) = IIf(ds.Tables(0).Rows(lcount).Item("Premi_Asuransi").ToString().Trim() = "", "0", ds.Tables(0).Rows(lcount).Item("Premi_Asuransi").ToString().Trim())
                    ' sheet.Cells(nikRowCount, nikColumnCount).numberformat = "0"
                    sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    nikColumnCount = nikColumnCount + 1
                    sheet.Cells(nikRowCount, nikColumnCount) = IIf(ds.Tables(0).Rows(lcount).Item("THR").ToString().Trim() = "", "0", ds.Tables(0).Rows(lcount).Item("THR").ToString().Trim())
                    sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    nikColumnCount = nikColumnCount + 1
                    sheet.Cells(nikRowCount, nikColumnCount) = IIf(ds.Tables(0).Rows(lcount).Item("PPH21_yang_telah_dibayar").ToString().Trim() = "", "0", ds.Tables(0).Rows(lcount).Item("PPH21_yang_telah_dibayar").ToString().Trim())
                    sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    nikColumnCount = nikColumnCount + 1
                    sheet.Cells(nikRowCount, nikColumnCount) = IIf(ds.Tables(0).Rows(lcount).Item("PPH21_Terhutang").ToString().Trim() = "", "0", ds.Tables(0).Rows(lcount).Item("PPH21_Terhutang").ToString().Trim())
                    sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    nikColumnCount = nikColumnCount + 1
                    sheet.Cells(nikRowCount, nikColumnCount) = IIf(ds.Tables(0).Rows(lcount).Item("PPH21_Ditanggung_Pemerintah").ToString().Trim() = "", "0", ds.Tables(0).Rows(lcount).Item("PPH21_Ditanggung_Pemerintah").ToString().Trim())
                    sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    nikColumnCount = nikColumnCount + 1
                    sheet.Cells(nikRowCount, nikColumnCount) = IIf(ds.Tables(0).Rows(lcount).Item("PPH21_Ditanggung_Karyawan").ToString().Trim() = "", "0", ds.Tables(0).Rows(lcount).Item("PPH21_Ditanggung_Karyawan").ToString().Trim())
                    sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                    nikColumnCount = 1

                    ' nikRowCount = nikRowCount + 1
                    lcount = lcount + 1
                    CountPeriod = CountPeriod + 1
                    CountRecords = CountRecords - 1

                    If CountRecords = 0 Then
                        Exit While
                    End If
                End While

                EndIndex = nikRowCount
                nikRowCount = nikRowCount + 1
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount) = "Total :"

                'B
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
                oRng.Formula = "=SUM(B" & startIndex & ":B" & EndIndex & ")"

                'C
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
                oRng.Formula = "=SUM(C" & startIndex & ":C" & EndIndex & ")"

                'D
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
                oRng.Formula = "=SUM(D" & startIndex & ":D" & EndIndex & ")"

                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
                oRng.Formula = "=SUM(E" & startIndex & ":E" & EndIndex & ")"

                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
                oRng.Formula = "=SUM(F" & startIndex & ":F" & EndIndex & ")"

                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
                oRng.Formula = "=SUM(G" & startIndex & ":G" & EndIndex & ")"

                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
                oRng.Formula = "=SUM(H" & startIndex & ":H" & EndIndex & ")"

                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
                oRng.Formula = "=SUM(I" & startIndex & ":I" & EndIndex & ")"

                nikColumnCount = 1
                TCount = TCount + 1
                nikRowCount = nikRowCount + 5
            End While
        End If

      
        sheet.Columns().AutoFit()

        ' sheet.Protect("RANNBSP@2010")

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        Cursor = Cursors.Default
        fMsg.Close()
        sheet.Visible = True
        xlApp.Visible = True

    End Sub

    Private Sub PPH21KaryawanFinalReport()

        Dim fMsg As New ProgressingFrm
        fMsg.TopMost = True
        fMsg.Show()
        ' fMsg.lblMessage.Refresh()
        fMsg.lblTitle.Refresh()
        fMsg.lblTitle.Text = "DATA PPH 21 KARYAWAN Final Report Processing . . ."
        fMsg.lblTitle.Refresh()

        Cursor = Cursors.WaitCursor
        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim ReportDirectory As String = String.Empty

        Dim sheet As Excel.Worksheet
        xlApp = New Excel.Application

        Dim TemPath As String = Application.StartupPath & "\Reports\Checkroll\Excel\PPH21Employee_Final_Report_Template.xls"

        If (File.Exists(TemPath)) Then

            xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath & "\Reports\Checkroll\Excel\PPH21Employee_Final_Report_Template.xls")
        Else
            MsgBox("DATA PPH 21 KARYAWAN report template missing.Please contact system administrator.")
            Exit Sub
        End If

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            MessageBox.Show("Report directory not found", "BSP")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Checkroll Reports")
        ' Determine whether the directory exists.
        If Not di.Exists Then
            di.Create()
        End If

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName

        Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd1 As New SqlCommand
        Dim da As New SqlDataAdapter
        con = New SqlConnection(constr)

        con.Open()

        cmd.Connection = con
        cmd.CommandText = "Checkroll.PPH21KaryawanFinalReport"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        If cbYear.Text = "All" Then
            cmd.Parameters.AddWithValue("@EmpID", "")
        Else
            cmd.Parameters.AddWithValue("@EmpID", cbMonth.SelectedValue)
        End If
        cmd.Parameters.AddWithValue("@Year", cbYear.SelectedValue)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "PPH21KaryawanFinalReport")
        Dim Pageno As Integer
        Pageno = 1


        sheet = xlWorkBook.Sheets("Sheet1")
        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)


        Dim objCommonBOl As New GlobalBOL
        sheet.Cells(5, 14) = "Tgl Cetak : " & String.Format("{0:dd/MM/yyyy}", Date.Today)

        sheet.Cells(5, 2) = "Estate/Mill : " & GlobalPPT.strEstateName.Substring(GlobalPPT.strEstateName.IndexOf("-") + 1) & " "
        'sheet.Cells(6, 8) = ds.Tables(0).Rows(0).Item("FromDT").ToString()
        'sheet.Cells(6, 10) = ds.Tables(0).Rows(0).Item("ToDT").ToString()
        '' sheet.Cells(5, 10) = Pageno

        strMonthlyProdRptName = "DATA PPH 21 KARYAWAN FINAL - " & " " & cbYear.SelectedValue & ""
        sheet.Cells(8, 2) = "DATA PPH 21 KARYAWAN FINAL - " & " " & cbYear.SelectedValue & ""

        Dim StrPath As String = "" & sDirName & "\BSP Checkroll Reports\" & strMonthlyProdRptName & ".xls"
        If ds.Tables(0).Rows.Count = 0 Then
            'sheet.Protect("RANNBSP@2010")

            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If
            xlApp.Visible = True
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim nikRowCount As Integer = 11
        Dim nikColumnCount As Integer = 1
        Dim startIndex, EndIndex, lcount, TCount As New Integer
        Dim oRng As Excel.Range


        If ds IsNot Nothing Then
            'CountRecords = ds.Tables(0).Rows.Count

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount) = "NIK"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "Nama"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "Status"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "MASA (BULAN)"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "Gaji / Upah Pokok"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "Tunjangan"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "Premi Asuransi"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "THR / Bonus"
            nikColumnCount = nikColumnCount + 1


            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "PPH21 Terhutang"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "PPH21 Ditanggung Pemerintah"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "PPH21 Ditanggung Karyawan"
            nikColumnCount = nikColumnCount + 1



            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "PPH21 telah di bayar"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "PPH21 Final"
            nikColumnCount = nikColumnCount + 1

            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            sheet.Cells(nikRowCount, nikColumnCount) = "Remarks"
            nikColumnCount = nikColumnCount + 1


            Dim CountPeriod As Integer = 0
            CountPeriod = ds.Tables(0).Rows.Count
            startIndex = nikRowCount + 1
            While CountPeriod > 0
                nikRowCount = nikRowCount + 1
                nikColumnCount = 1
                fMsg.lblTitle.Refresh()
                fMsg.lblTitle.Text = "DATA PPH 21 KARYAWAN Final Report Processing for Employee " & ds.Tables(0).Rows(lcount).Item("Nama").ToString() & ". . ."
                fMsg.lblTitle.Refresh()

                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Cells(nikRowCount, nikColumnCount) = "'" + ds.Tables(0).Rows(lcount).Item("NIK").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("Nama").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("MStatus").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1


                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("Period").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("Gaji").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("Tunjangan").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("Premi_Asuransi").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("THR").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1
               
                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("PPH21_Terhutang").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("PPH21_Ditanggung_Pemerintah").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1
                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("PPH21_Ditanggung_Karyawan").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1


                'sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("PPH21_telah_di_bayar").ToString()
                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("pph21_yang_telah_dibayar").ToString()

                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("PPH21_Final").ToString()
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = nikColumnCount + 1

                sheet.Cells(nikRowCount, nikColumnCount) = ds.Tables(0).Rows(lcount).Item("Remarks").ToString()
                'sheet.Cells(nikRowCount, nikColumnCount) = ""
                sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                nikColumnCount = 1

                ' nikRowCount = nikRowCount + 1
                lcount = lcount + 1
                CountPeriod = CountPeriod - 1

            End While

            EndIndex = nikRowCount
            nikRowCount = nikRowCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount) = "Total :"

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous


            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
            oRng.Formula = "=SUM(E" & startIndex & ":E" & EndIndex & ")"

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
            oRng.Formula = "=SUM(F" & startIndex & ":F" & EndIndex & ")"

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
            oRng.Formula = "=SUM(G" & startIndex & ":G" & EndIndex & ")"

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
            oRng.Formula = "=SUM(H" & startIndex & ":H" & EndIndex & ")"

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
            oRng.Formula = "=SUM(I" & startIndex & ":I" & EndIndex & ")"

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
            oRng.Formula = "=SUM(J" & startIndex & ":J" & EndIndex & ")"

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
            oRng.Formula = "=SUM(K" & startIndex & ":K" & EndIndex & ")"

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
            oRng.Formula = "=SUM(L" & startIndex & ":L" & EndIndex & ")"

            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
            oRng.Formula = "=SUM(M" & startIndex & ":M" & EndIndex & ")"


            nikColumnCount = nikColumnCount + 1
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            sheet.Cells(nikRowCount, nikColumnCount).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            oRng = sheet.Cells.Item(nikRowCount, nikColumnCount)
            oRng.Formula = "=SUM(N" & startIndex & ":N" & EndIndex & ")"

            nikColumnCount = 1

        End If

        sheet.Columns().AutoFit()

        ' sheet.Protect("RANNBSP@2010")

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        Cursor = Cursors.Default
        fMsg.Close()
        sheet.Visible = True
        xlApp.Visible = True

    End Sub

    Private Sub LampiranSPTTahunanPPH21()

        Dim fMsg As New ProgressingFrm
        fMsg.TopMost = True
        'fMsg.Show()
        ' fMsg.lblMessage.Refresh()
        fMsg.lblTitle.Refresh()
        fMsg.lblTitle.Text = "Data SPT Tahunan PPH PASAL 21 Report Processing . . ."
        fMsg.lblTitle.Refresh()

        Cursor = Cursors.WaitCursor

        'to fix an Excel bug need to change the culture info
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim strMonthlyProdRptName As String = String.Empty
        Dim strServerUserName As String = String.Empty
        Dim strServerPassword As String = String.Empty
        Dim strDSN As String = String.Empty
        Dim StrInitialCatlog As String = String.Empty
        Dim ReportDirectory As String = String.Empty

        Dim sheet As Excel.Worksheet = Nothing
        Dim xsheet As Excel.Worksheet = Nothing

        xlApp = New Excel.Application

        Dim TemPath As String = Application.StartupPath & "\Reports\Checkroll\Excel\Lampiran_SPT_Tahunan_PPH21_Template.xls"

        If (File.Exists(TemPath)) Then

            xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath & "\Reports\Checkroll\Excel\Lampiran_SPT_Tahunan_PPH21_Template.xls")
        Else
            MsgBox("Data SPT Tahunan PPH PASAL 21 report template missing. Please contact system administrator.")
            Exit Sub
        End If

        ReportDirectory = "" & ConfigurationManager.AppSettings.Item("oReportDirectory").ToString & ""

        Dim sDirName As String
        sDirName = ReportDirectory + ":"
        Dim dDir As New DirectoryInfo(sDirName)

        If Not dDir.Exists Then
            MessageBox.Show("Report directory not found", "BSP")
            Cursor = Cursors.Arrow
            Exit Sub
        End If

        Dim di As DirectoryInfo = New DirectoryInfo("" & sDirName & "\BSP Checkroll Reports")
        ' Determine whether the directory exists.
        If Not di.Exists Then
            di.Create()
        End If

        strDSN = GlobalPPT.SelectedDB.DSN
        strServerUserName = GlobalPPT.SelectedDB.User
        strServerPassword = GlobalPPT.SelectedDB.Password
        StrInitialCatlog = GlobalPPT.SelectedDB.DBName

        Dim constr As String = " Data Source=" & GlobalPPT.SelectedDB.Server & "; Initial Catalog=" & GlobalPPT.SelectedDB.DBName & ";User=" & GlobalPPT.SelectedDB.User & "; pwd=" & GlobalPPT.SelectedDB.Password & ";Max Pool Size=100;Connection Timeout=60;"
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cmd1 As New SqlCommand
        Dim da As New SqlDataAdapter
        con = New SqlConnection(constr)

        con.Open()

        cmd.Connection = con
        cmd.CommandText = "Checkroll.LampiranSPTTahunanPPH21"
        cmd.CommandTimeout = 1800
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EstateID", GlobalPPT.strEstateID)
        If cbMonth.Text = "All" Then
            cmd.Parameters.AddWithValue("@EmpID", "")
        Else
            cmd.Parameters.AddWithValue("@EmpID", cbMonth.SelectedValue)
        End If
        cmd.Parameters.AddWithValue("@Year", cbYear.SelectedValue)

        Dim tblAdt As New SqlDataAdapter
        Dim ds As New DataSet
        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "LampiranSPTTahunanPPH21")
        Dim Pageno As Integer
        Pageno = 1

        sheet = xlWorkBook.Sheets("Sheet1")
        sheet = DirectCast(xlWorkBook.Sheets(1), Excel.Worksheet)

        strMonthlyProdRptName = "SPT Tahunan PPH PASAL 21 - " & " " & GlobalPPT.intActiveYear & ""
        Dim iSeqNo As Integer
        iSeqNo = Int(Val(StartSeqNoTextBox.Text))
        Dim StrPath As String = "" & sDirName & "\BSP Checkroll Reports\" & strMonthlyProdRptName & ".xls"
        If ds.Tables(0).Rows.Count = 0 Then
            'sheet.Protect("RANNBSP@2010")

            If (File.Exists(StrPath)) Then
                File.Delete(StrPath)
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            Else
                xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
            End If
            xlApp.Visible = True
            Cursor = Cursors.Default
            fMsg.Close()
            Exit Sub
        End If

        Dim iDataCount As Integer
        iDataCount = ds.Tables(0).Rows.Count
        Dim iSheetCount As Integer
        iSheetCount = 0

        Dim sSPT_Year As String
        sSPT_Year = Trim(Str(cbYear.SelectedValue))

        Dim iPosCount As Integer
        Dim iMaxLen As Integer
        Dim sNPWPNo As String


        Dim objReportBOL As New CheckRoll_BOL.ProcessBOL

        Dim iActiveMth As Integer
        Dim ds2 As DataSet
        Dim ds3 As DataSet

        ds2 = objReportBOL.GetActiveMonthYear()
        If ds2.Tables.Count > 0 Then

            If ds2.Tables(0).Rows.Count > 0 Then
                If Convert.ToInt32(cbYear.Text) <> ds2.Tables(0).Rows(0).Item("AYear") Then
                    iActiveMth = 0
                Else
                    iActiveMth = 1
                End If
            End If
        End If

        Dim dTanggal As Date
        Dim iTgl As Integer
        Dim iBln As Integer
        Dim iThn As Integer
        Dim TTlBruto As Double
        Dim TtlPengurangan As Double
        dTanggal = TanggalDTP.Value
        iTgl = Microsoft.VisualBasic.DateAndTime.Day(dTanggal)
        iBln = Month(dTanggal)
        iThn = Year(dTanggal)

        If ds IsNot Nothing Then

            If (iActiveMth = 1) And (cbMonth.Text = "All") Then
                CheckRoll_DAL.ProcessDal.SPT21Delete(Convert.ToInt32(cbYear.Text))
            End If

            iSeqNo = Int(Val(StartSeqNoTextBox.Text))
            While (iSheetCount < iDataCount)

                xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(iSheetCount + 1))
                sheet.Activate()
                sheet.Cells.Select()

                xlApp.Selection.Copy()

                'Name of the sheet if multiple
                xlWorkBook.Sheets(iSheetCount + 2).Name = iSeqNo.ToString() & "-" & ds.Tables(0).Rows(iSheetCount).Item("EmpCode")

                xsheet = xlWorkBook.Sheets(iSheetCount + 2)
                xsheet = DirectCast(xlWorkBook.Sheets(iSheetCount + 2), Excel.Worksheet)
                xsheet.Activate()
                xsheet.Paste()

                fMsg.lblTitle.Refresh()
                fMsg.lblTitle.Text = "Data SPT Tahunan PPH PASAL 21 Report Processing for Employee " & ds.Tables(0).Rows(iSheetCount).Item("EmpName") & ". . ."
                fMsg.lblTitle.Refresh()

                If (iActiveMth = 1) And (cbMonth.Text = "All") Then
                    CheckRoll_DAL.ProcessDal.SPT21Insert(Convert.ToInt32(cbYear.Text), ds.Tables(0).Rows(iSheetCount).Item("EmpId"), iSeqNo)
                End If

                With xsheet.PageSetup
                    .Zoom = False
                    .PaperSize = Excel.XlPaperSize.xlPaperA4
                    .FitToPagesWide = 1
                    .FitToPagesTall = 1
                End With

                xsheet.Cells(8, 32) = Strings.Mid(sSPT_Year, 3, 1)
                xsheet.Cells(8, 34) = Strings.Mid(sSPT_Year, 4, 1)

                If (iActiveMth = 0) Then
                    ds3 = objReportBOL.GetSPTSeqNo(Convert.ToInt32(cbYear.Text), ds.Tables(0).Rows(iSheetCount).Item("EmpCode"))
                    'iSeqNo = ds3.Tables(0).Rows(0).Item("SeqNo")
                End If

                iMaxLen = Len(iSeqNo.ToString)
                If iMaxLen > 6 Then
                    iMaxLen = 6
                End If

                iPosCount = 1
                'Nombor URUT
                While (iPosCount <= iMaxLen)

                    If (iPosCount <= 3) Then
                        xsheet.Cells(8, 17 + iPosCount) = Mid(iSeqNo.ToString, iPosCount, 1)
                    Else
                        xsheet.Cells(8, 18 + iPosCount) = Mid(iSeqNo.ToString, iPosCount, 1)
                    End If

                    iPosCount = iPosCount + 1

                End While

                sNPWPNo = ""
                If (NPWPTextBox.Text <> String.Empty) And (Trim(NPWPTextBox.Text) <> String.Empty) Then
                    If (Len(NPWPTextBox.Text) > 1) Then
                        sNPWPNo = Mid(Trim(NPWPTextBox.Text), 1, 2)
                        sNPWPNo = sNPWPNo + Mid(Trim(NPWPTextBox.Text), 4, 3)
                        sNPWPNo = sNPWPNo + Mid(Trim(NPWPTextBox.Text), 8, 3)
                        sNPWPNo = sNPWPNo + Mid(Trim(NPWPTextBox.Text), 12, 1)
                        sNPWPNo = sNPWPNo + Mid(Trim(NPWPTextBox.Text), 14, 3)
                        sNPWPNo = sNPWPNo + Mid(Trim(NPWPTextBox.Text), 18, 3)
                    End If

                    iPosCount = 1

                    iMaxLen = Len(sNPWPNo)
                    If iMaxLen > 15 Then
                        iMaxLen = 15
                    End If
                    'NPWP Pemotong Pajak, from the text box
                    While (iPosCount <= iMaxLen)

                        If (iPosCount <= 2) Then
                            xsheet.Cells(12, 14 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '15-16
                        ElseIf (iPosCount <= 5) Then
                            xsheet.Cells(12, 16 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '19-21
                        ElseIf (iPosCount <= 8) Then
                            xsheet.Cells(12, 17 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '23-25
                        ElseIf (iPosCount <= 9) Then
                            xsheet.Cells(12, 18 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '27
                        ElseIf (iPosCount <= 12) Then
                            xsheet.Cells(12, 19 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '29-31
                        ElseIf (iPosCount <= 15) Then
                            xsheet.Cells(12, 20 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '33-35
                        End If

                        iPosCount = iPosCount + 1

                    End While
                End If

                'iMaxLen = Len(EmployerNameTextBox.Text)
                'If iMaxLen > 22 Then
                '    iMaxLen = 22
                'End If

                'iPosCount = 1

                'If (iMaxLen > 0) Then
                '    While (iPosCount <= iMaxLen)

                '        If (iPosCount <= 3) Then
                '            xsheet.Cells(16, 14 + iPosCount) = Mid(EmployerNameTextBox.Text, iPosCount, 1)
                '        Else
                '            xsheet.Cells(16, 15 + iPosCount) = Mid(EmployerNameTextBox.Text, iPosCount, 1)
                '        End If

                '        iPosCount = iPosCount + 1

                '    End While
                'End If
                'Nama Pemotong Pajak
                If (EmployerNameTextBox.Text <> String.Empty) And (Trim(EmployerNameTextBox.Text) <> String.Empty) Then
                    xsheet.Cells(14, 15) = EmployerNameTextBox.Text
                End If
                'Alamat Pemotong Pajak
                If (AlamatTextBox.Text <> String.Empty) And (Trim(AlamatTextBox.Text) <> String.Empty) Then
                    xsheet.Cells(17, 15) = AlamatTextBox.Text
                End If

                'Nama Pegawai
                If (ds.Tables(0).Rows(iSheetCount).Item("EMPName").ToString <> String.Empty) And (Trim(ds.Tables(0).Rows(iSheetCount).Item("EMPName")).ToString <> String.Empty) Then
                    xsheet.Cells(19, 15) = ds.Tables(0).Rows(iSheetCount).Item("EMPName").ToString.ToUpper()
                End If
                'NPWPNo
                sNPWPNo = ""
                If (ds.Tables(0).Rows(iSheetCount).Item("HaveNPWP") = "Y") Then
                    If (Len(Trim(ds.Tables(0).Rows(iSheetCount).Item("NPWP"))) > 1) Then
                        sNPWPNo = Mid(Trim(ds.Tables(0).Rows(iSheetCount).Item("NPWP")), 1, 2)
                        sNPWPNo = sNPWPNo + Mid(Trim(ds.Tables(0).Rows(iSheetCount).Item("NPWP")), 4, 3)
                        sNPWPNo = sNPWPNo + Mid(Trim(ds.Tables(0).Rows(iSheetCount).Item("NPWP")), 8, 3)
                        sNPWPNo = sNPWPNo + Mid(Trim(ds.Tables(0).Rows(iSheetCount).Item("NPWP")), 12, 1)
                        sNPWPNo = sNPWPNo + Mid(Trim(ds.Tables(0).Rows(iSheetCount).Item("NPWP")), 14, 3)
                        sNPWPNo = sNPWPNo + Mid(Trim(ds.Tables(0).Rows(iSheetCount).Item("NPWP")), 18, 3)
                    End If
                End If

                iPosCount = 1

                iMaxLen = Len(sNPWPNo)
                If iMaxLen > 15 Then
                    iMaxLen = 15
                End If

                While (iPosCount <= iMaxLen)

                    If (iPosCount <= 2) Then
                        xsheet.Cells(21, 14 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '15-16
                    ElseIf (iPosCount <= 5) Then
                        xsheet.Cells(21, 16 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '19-21
                    ElseIf (iPosCount <= 8) Then
                        xsheet.Cells(21, 17 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '23-25
                    ElseIf (iPosCount <= 9) Then
                        xsheet.Cells(21, 18 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '27
                    ElseIf (iPosCount <= 12) Then
                        xsheet.Cells(21, 19 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '29-31
                    ElseIf (iPosCount <= 15) Then
                        xsheet.Cells(21, 20 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '33-35
                    End If

                    iPosCount = iPosCount + 1

                End While
                'Alamat Pegawai
                If (AlamatTextBox.Text <> String.Empty) And (Trim(AlamatTextBox.Text) <> String.Empty) Then
                    xsheet.Cells(23, 15) = AlamatTextBox.Text
                End If

                'Status
                If (Mid(ds.Tables(0).Rows(iSheetCount).Item("MaritalStatus"), 1, 1) = "K") Then
                    xsheet.Cells(25, 15) = "X"
                ElseIf (Mid(ds.Tables(0).Rows(iSheetCount).Item("MaritalStatus"), 1, 2) = "TK") Then
                    xsheet.Cells(25, 18) = "X"
                End If
                'Jenis Kelamain
                If (ds.Tables(0).Rows(iSheetCount).Item("Gender") = "M") Then
                    xsheet.Cells(25, 23) = "X"
                ElseIf (ds.Tables(0).Rows(iSheetCount).Item("Gender") = "F") Then
                    xsheet.Cells(25, 27) = "X"
                End If
                'Tangungan Keluarga
                If (Mid(ds.Tables(0).Rows(iSheetCount).Item("MaritalStatus"), 1, 1) = "K") Then
                    xsheet.Cells(27, 16) = Mid(ds.Tables(0).Rows(iSheetCount).Item("MaritalStatus"), 2, Len(Trim(ds.Tables(0).Rows(iSheetCount).Item("MaritalStatus"))))
                ElseIf (Mid(ds.Tables(0).Rows(iSheetCount).Item("MaritalStatus"), 1, 2) = "TK") Then
                    xsheet.Cells(27, 22) = Mid(ds.Tables(0).Rows(iSheetCount).Item("MaritalStatus"), 3, Len(Trim(ds.Tables(0).Rows(iSheetCount).Item("MaritalStatus"))))
                End If
                'Jabatan
                If (JabatanTextBox.Text <> String.Empty) And (Trim(JabatanTextBox.Text) <> String.Empty) Then
                    xsheet.Cells(29, 15) = JabatanTextBox.Text
                End If
                xsheet.Cells(29, 36) = "INDONESIA"
                'Masa Perolehan
                'If (ds.Tables(0).Rows(iSheetCount).Item("First_Period") < 10) Then
                '    xsheet.Cells(30, 34) = "0"
                '    xsheet.Cells(30, 35) = Trim(Str(ds.Tables(0).Rows(iSheetCount).Item("First_Period")))
                'Else
                '    xsheet.Cells(30, 34) = Strings.Mid(Trim(Str(ds.Tables(0).Rows(iSheetCount).Item("First_Period"))), 1, 1)
                '    xsheet.Cells(30, 35) = Strings.Mid(Trim(Str(ds.Tables(0).Rows(iSheetCount).Item("First_Period"))), 2, 1)
                'End If
                'Akhir Perolehan
                'If (ds.Tables(0).Rows(iSheetCount).Item("Last_Period") < 10) Then
                '    xsheet.Cells(8, 32) = "0"
                '    xsheet.Cells(8, 33) = Trim(Str(ds.Tables(0).Rows(iSheetCount).Item("Last_Period")))
                'Else
                '    xsheet.Cells(8, 35) = Strings.Mid(Trim(Str(ds.Tables(0).Rows(iSheetCount).Item("Last_Period"))), 1, 1)
                '    xsheet.Cells(8, 36) = Strings.Mid(Trim(Str(ds.Tables(0).Rows(iSheetCount).Item("Last_Period"))), 2, 1)
                'End If

                xsheet.Cells(36, 29) = ds.Tables(0).Rows(iSheetCount).Item("GajiPokok")
                xsheet.Cells(39, 29) = ds.Tables(0).Rows(iSheetCount).Item("TunjanganPajak")
                xsheet.Cells(42, 29) = ds.Tables(0).Rows(iSheetCount).Item("TunjanganLain")
                xsheet.Cells(45, 29) = 0
                xsheet.Cells(48, 29) = ds.Tables(0).Rows(iSheetCount).Item("Ansurance")
                xsheet.Cells(51, 29) = 0
                xsheet.Cells(54, 29) = ds.Tables(0).Rows(iSheetCount).Item("TunjanganJasa")
                TTlBruto = ds.Tables(0).Rows(iSheetCount).Item("GajiPokok") + ds.Tables(0).Rows(iSheetCount).Item("TunjanganPajak") + ds.Tables(0).Rows(iSheetCount).Item("TunjanganLain") + ds.Tables(0).Rows(iSheetCount).Item("Ansurance") + ds.Tables(0).Rows(iSheetCount).Item("TunjanganJasa")
                xsheet.Cells(57, 29) = TTlBruto
                If (TTlBruto * 5 / 100) > ds.Tables(0).Rows(iSheetCount).Item("MaxAllowance") Then
                    xsheet.Cells(62, 29) = ds.Tables(0).Rows(iSheetCount).Item("MaxAllowance")
                Else
                    xsheet.Cells(62, 29) = CDbl(TTlBruto) * 5 / 100
                End If

                xsheet.Cells(65, 29) = 0
                'xsheet.Cells(68, 30) = CDbl(xsheet.Cells(62, 30)) + CDbl(xsheet.Cells(65, 30))

                'xsheet.Cells(73, 30) = CDbl(xsheet.Cells(57, 30)) - CDbl(xsheet.Cells(68, 30))
              
                'If ds.Tables(0).Rows(iSheetCount).Item("Remarks") = "Kurang Potong" Then
                '    xsheet.Cells(114, 6) = "X"
                'Else
                '    xsheet.Cells(114, 6) = ""
                'End If
                'xsheet.Cells(114, 30) = "NIHIL"

                'If ds.Tables(0).Rows(iSheetCount).Item("Remarks") = "Lebih Potong" Then
                '    xsheet.Cells(117, 6) = "X"
                'Else
                '    xsheet.Cells(117, 6) = ""
                'End If
                'xsheet.Cells(117, 30) = "NIHIL"

                'xsheet.Cells(120, 6) = "X"
                'xsheet.Cells(120, 20) = "1"
                'xsheet.Cells(120, 21) = "2"
                'xsheet.Cells(120, 24) = Strings.Mid(sSPT_Year, 1, 1)
                'xsheet.Cells(120, 25) = Strings.Mid(sSPT_Year, 2, 1)
                'xsheet.Cells(120, 26) = Strings.Mid(sSPT_Year, 3, 1)
                'xsheet.Cells(120, 27) = Strings.Mid(sSPT_Year, 4, 1)
                'xsheet.Cells(120, 30) = "NIHIL"
                'xsheet.Cells(123, 30) = "NIHIL"

                'If (TempatTextBox.Text <> String.Empty) And (Trim(TempatTextBox.Text) <> String.Empty) Then
                '    xsheet.Cells(126, 19) = TempatTextBox.Text
                'End If

                If iTgl < 10 Then
                    xsheet.Cells(102, 26) = "0"
                    xsheet.Cells(102, 27) = iTgl.ToString
                Else
                    xsheet.Cells(102, 26) = Mid(iTgl.ToString, 1, 1)
                    xsheet.Cells(102, 27) = Mid(iTgl.ToString, 2, 1)
                End If

                If iBln < 10 Then
                    xsheet.Cells(102, 29) = "0"
                    xsheet.Cells(102, 30) = iBln.ToString
                Else
                    xsheet.Cells(102, 29) = Mid(iBln.ToString, 1, 1)
                    xsheet.Cells(102, 30) = Mid(iBln.ToString, 2, 1)
                End If

                xsheet.Cells(102, 32) = Mid(iThn.ToString, 1, 1)
                xsheet.Cells(102, 33) = Mid(iThn.ToString, 2, 1)
                xsheet.Cells(102, 34) = Mid(iThn.ToString, 3, 1)
                xsheet.Cells(102, 35) = Mid(iThn.ToString, 4, 1)

                'If RadioButton1.Checked Then
                '    xsheet.Cells(128, 4) = "X"
                'Else
                '    xsheet.Cells(128, 12) = "X"
                'End If

                'If (NameKuasaTextBox.Text <> String.Empty) And (Trim(NameKuasaTextBox.Text) <> String.Empty) Then
                '    xsheet.Cells(130, 8) = NameKuasaTextBox.Text()
                'End If

                'sNPWPNo = ""
                'If (NPWPKuasaTextBox.Text <> String.Empty) And (Trim(NPWPKuasaTextBox.Text) <> String.Empty) Then
                '    If (Len(NPWPKuasaTextBox.Text) > 1) Then
                '        sNPWPNo = Mid(Trim(NPWPKuasaTextBox.Text), 1, 2)
                '        sNPWPNo = sNPWPNo + Mid(Trim(NPWPKuasaTextBox.Text), 4, 3)
                '        sNPWPNo = sNPWPNo + Mid(Trim(NPWPKuasaTextBox.Text), 8, 3)
                '        sNPWPNo = sNPWPNo + Mid(Trim(NPWPKuasaTextBox.Text), 12, 1)
                '        sNPWPNo = sNPWPNo + Mid(Trim(NPWPKuasaTextBox.Text), 14, 3)
                '        sNPWPNo = sNPWPNo + Mid(Trim(NPWPKuasaTextBox.Text), 18, 3)
                '    End If

                '    iPosCount = 1

                '    iMaxLen = Len(sNPWPNo)
                '    If iMaxLen > 15 Then
                '        iMaxLen = 15
                '    End If

                '    While (iPosCount <= iMaxLen)

                '        If (iPosCount <= 2) Then
                '            xsheet.Cells(132, 7 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '8-7
                '        ElseIf (iPosCount <= 5) Then
                '            xsheet.Cells(132, 8 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '11-13
                '        ElseIf (iPosCount <= 8) Then
                '            xsheet.Cells(132, 9 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '15-17
                '        ElseIf (iPosCount <= 9) Then
                '            xsheet.Cells(132, 11 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '20
                '        ElseIf (iPosCount <= 12) Then
                '            xsheet.Cells(132, 12 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '22-24
                '        ElseIf (iPosCount <= 15) Then
                '            xsheet.Cells(132, 13 + iPosCount) = Mid(sNPWPNo, iPosCount, 1)    '26-28
                '        End If

                '        iPosCount = iPosCount + 1

                '    End While
                'End If

                If (iActiveMth = 1) Then
                    iSeqNo = iSeqNo + 1
                ElseIf (cbMonth.Text = "All") Then
                    iSeqNo = iSeqNo + 1
                End If

                iSheetCount = iSheetCount + 1

            End While

            If (iSheetCount > 0) Then
                xlApp.DisplayAlerts = False
                CType(xlApp.ActiveWorkbook.Sheets(1), Excel.Worksheet).Delete()
                xlApp.DisplayAlerts = True

                CType(xlApp.ActiveWorkbook.Sheets(1), Excel.Worksheet).Activate()
            End If

        End If

        'sheet.Columns().AutoFit()

        ' sheet.Protect("RANNBSP@2010")

        If (File.Exists(StrPath)) Then
            File.Delete(StrPath)
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        Else
            xlWorkBook.SaveAs(StrPath, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, Excel.XlSaveAsAccessMode.xlShared, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing)
        End If

        ' put CultureInfo back to original
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

        Cursor = Cursors.Default
        fMsg.Close()
        xsheet.Visible = True
        xlApp.Visible = True

        'Clean up
        sheet = Nothing
        xsheet = Nothing
        xlWorkBook = Nothing
        xlApp = Nothing

    End Sub

    Private Sub cbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMonth.SelectedIndexChanged

        Dim mdiparent As New MDIParent
        Cursor = Cursors.WaitCursor

        If intAfterGetInterfaceYear = 1 Then
            If mdiparent.strMenuID = "M274" Then
                Dim objReportBOL As New ProcessBOL
                Dim ds2 As DataSet

                ds2 = objReportBOL.GetActiveMonthYear()
                If ds2.Tables.Count > 0 Then

                    If ds2.Tables(0).Rows.Count > 0 Then
                        Dim ds1 As DataSet
                        StartSeqNoTextBox.Enabled = True
                        If cbMonth.Text <> "All" Then
                            ds1 = objReportBOL.GetSPTSeqNo(Convert.ToInt32(cbYear.Text), cbMonth.SelectedValue)
                            If ds1.Tables(0).Rows(0).Item("SeqNo") = 0 Then
                                If intAfterGetInterfaceYear = 1 Then
                                    MessageBox.Show("No urut number has been generated for this employee, please enter starting sequence number and select Emp.Code All and click View Report.", "BSP", MessageBoxButtons.OK)
                                End If
                                StartSeqNoTextBox.Text = "1"
                            Else
                                StartSeqNoTextBox.Text = ds1.Tables(0).Rows(0).Item("SeqNo").ToString
                            End If
                        Else
                            ds1 = objReportBOL.GetSPTSeqNo(Convert.ToInt32(cbYear.Text), "")
                            If ds1.Tables(0).Rows(0).Item("SeqNo") = 0 Then
                                If intAfterGetInterfaceYear = 1 Then
                                    MessageBox.Show("No urut number has been generated for all employee, please enter starting sequence number and select Emp.Code All and click View Report.", "BSP", MessageBoxButtons.OK)
                                End If
                                StartSeqNoTextBox.Text = "1"
                            Else
                                StartSeqNoTextBox.Text = ds1.Tables(0).Rows(0).Item("SeqNo").ToString
                            End If
                        End If

                        If Convert.ToInt32(cbYear.Text) <> ds2.Tables(0).Rows(0).Item("AYear") Then
                            StartSeqNoTextBox.Enabled = False
                        Else
                            StartSeqNoTextBox.Enabled = True
                        End If
                    End If
                End If
            End If
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub cbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbYear.SelectedIndexChanged

        Dim objReportBOL As New ProcessBOL
        Dim mdiparent As New MDIParent
        Dim ds As DataSet
        Cursor = Cursors.WaitCursor

        If intAfterGetInterfaceYear = 1 Then
            ds = objReportBOL.GetSPTForYear(Convert.ToInt32(cbYear.Text))

            If ds.Tables.Count > 0 Then

                If ds.Tables(0).Rows.Count > 0 Then


                    Dim dr As DataRow = ds.Tables(0).NewRow()
                    dr(1) = "All"
                    ds.Tables(0).Rows.InsertAt(dr, 0)
                    cbMonth.DataSource = ds.Tables(0)
                    cbMonth.DisplayMember = "EmpID"
                    cbMonth.ValueMember = "EmpID"
                End If

                If mdiparent.strMenuID = "M274" Then
                    Dim ds2 As DataSet

                    ds2 = objReportBOL.GetActiveMonthYear()
                    If ds2.Tables.Count > 0 Then

                        If ds2.Tables(0).Rows.Count > 0 Then
                            Dim ds1 As DataSet
                            StartSeqNoTextBox.Enabled = True
                            If cbMonth.Text <> "All" Then
                                ds1 = objReportBOL.GetSPTSeqNo(Convert.ToInt32(cbYear.Text), cbMonth.SelectedValue)
                                If ds1.Tables(0).Rows(0).Item("SeqNo") = 0 Then
                                    If intAfterGetInterfaceYear = 1 Then
                                        MessageBox.Show("No urut number has been generated for this employee, please enter starting sequence number and select Emp.Code All and click View Report.", "BSP", MessageBoxButtons.OK)
                                    End If
                                    StartSeqNoTextBox.Text = "1"
                                Else
                                    StartSeqNoTextBox.Text = ds1.Tables(0).Rows(0).Item("SeqNo").ToString
                                End If
                            Else
                                ds1 = objReportBOL.GetSPTSeqNo(Convert.ToInt32(cbYear.Text), "")
                                If ds1.Tables(0).Rows(0).Item("SeqNo") = 0 Then
                                    If intAfterGetInterfaceYear = 1 Then
                                        MessageBox.Show("No urut number has been generated for all employee, please enter starting sequence number and select Emp.Code All and click View Report.", "BSP", MessageBoxButtons.OK)
                                    End If
                                    StartSeqNoTextBox.Text = "1"
                                Else
                                    StartSeqNoTextBox.Text = ds1.Tables(0).Rows(0).Item("SeqNo").ToString
                                End If
                            End If

                            If Convert.ToInt32(cbYear.Text) <> ds2.Tables(0).Rows(0).Item("AYear") Then
                                StartSeqNoTextBox.Enabled = False
                            Else
                                StartSeqNoTextBox.Enabled = True
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Cursor = Cursors.Default

    End Sub

End Class