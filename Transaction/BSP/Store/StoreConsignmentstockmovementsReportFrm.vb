Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT

Public Class StoreConsignmentstockmovementsReportFrm

    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StoreConsignmentstockmovementsReportFrm))
    Public Shared strActiveMonthYrId As String = String.Empty
    Public Shared intConsignmentYear As Integer
    Public Shared intConsignmentMonth As Integer

    Private Sub StoreConsignmentstockmovementsReportFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetUICulture(GlobalPPT.strLang)
        Bind_cmbYearandMonth()

    End Sub

    Private Sub Bind_cmbYearandMonth()

        Dim ds As DataSet
        Dim objCONSPPT As New ConsignmentReceivedPPT
        Dim objCONSBOL As New ConsignmentReceivedBOL
        ds = objCONSBOL.Bind_cmbYearandMonth(objCONSPPT)

        If ds.Tables.Count > 0 Then

            If ds.Tables(0).Rows.Count > 0 Then

                cmbYearSearch.DataSource = ds.Tables(0)
                cmbYearSearch.DisplayMember = "AYear"
                cmbYearSearch.ValueMember = "AYear"
                'cmbYearSearch.SelectedIndex = -1
                'cmbYearSearch.Text = "-SELECT-"

            End If

            If ds.Tables(1).Rows.Count > 0 Then

                cmbMonthSearch.DataSource = ds.Tables(1)
                cmbMonthSearch.DisplayMember = "AMonth"
                cmbMonthSearch.ValueMember = "ActiveMonthYearID"
                'cmbMonthSearch.SelectedIndex = -1
                'cmbMonthSearch.Text = "-SELECT-"

            End If

        End If

    End Sub

    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StoreConsignmentstockmovementsReportFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnViewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click

        If cmbYearSearch.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg01")
            'MessageBox.Show("Please Select Year")
        Else
            If cmbMonthSearch.Text.Trim = String.Empty Then
                DisplayInfoMessage("Msg02")
                'MessageBox.Show("Please Select Month")
            Else
                strActiveMonthYrId = cmbMonthSearch.SelectedValue.ToString()
                intConsignmentYear = cmbYearSearch.SelectedValue

                Dim strmonth As String = String.Empty
                strmonth = cmbMonthSearch.Text

                'If strmonth <> String.Empty Then
                '    intConsignmentMonth = Convert.ToInt32(strmonth)
                'End If

                If strmonth <> String.Empty Then

                    Select Case strmonth
                        Case "January"
                            intConsignmentMonth = 1
                        Case "February"
                            intConsignmentMonth = 2
                        Case "March"
                            intConsignmentMonth = 3
                        Case "April"
                            intConsignmentMonth = 4
                        Case "May"
                            intConsignmentMonth = 5
                        Case "June"
                            intConsignmentMonth = 6
                        Case "July"
                            intConsignmentMonth = 7
                        Case "August"
                            intConsignmentMonth = 8
                        Case "September"
                            intConsignmentMonth = 9
                        Case "October"
                            intConsignmentMonth = 10
                        Case "November"
                            intConsignmentMonth = 11
                        Case "December"
                            intConsignmentMonth = 12

                    End Select

                End If

                StoreConsignmentstockmovementsReportView.ShowDialog()

            End If
        End If

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        ' Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StoreSIVReportFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            pnlConsrpt.CaptionText = rm.GetString("pnlConsrpt.CaptionText") 'lblSearchBy
            lblSearchBy.Text = rm.GetString("lblSearchBy.Text")
            lblMonthSerach.Text = rm.GetString("lblMonthSerach.Text")
            lblYearSerach.Text = rm.GetString("lblYearSerach.Text")

            'lblRemarksSearch.Text = rm.GetString("lblRemarksSearch.Text")
            btnViewReport.Text = rm.GetString("btnViewReport.Text")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


 
    Private Sub StoreConsignmentstockmovementsReportFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class