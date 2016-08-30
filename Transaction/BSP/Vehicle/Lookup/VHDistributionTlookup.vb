Imports Vehicle_PPT
Imports Vehicle_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class VHDistributionTlookup

    Public strTId As String = String.Empty
    Public strTCode As String = String.Empty
    Public strTValue As String = String.Empty
    Public strTDesc As String = String.Empty
    Public strTAbbrev As String = String.Empty
    Public Shared strTcodeDecide As String = String.Empty

    Private Sub Tlookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        Dim objTlookup As New VehicleDistributionPPT
        objTlookup.TDecide = strTcodeDecide
        Dim ds As New DataSet
        'dgTlookup.AutoGenerateColumns = False
        ds = VehicleDistributionBOL.TlookupSearch(objTlookup, "NO")
        If ds.Tables(0).Rows.Count > 0 Then
            dgTlookup.DataSource = ds.Tables(0)
        End If

    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VHDistributionTlookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchAnalysisCode.Text = rm.GetString("lblsearchAnalysisCode.Text")
            panTLookup.CaptionText = rm.GetString("panTLookup.CaptionText")
            lblTValue.Text = rm.GetString("lblTValue.Text")
            lblTDesc.Text = rm.GetString("lblTDesc.Text")
            dgTlookup.Columns("TAnalysisId").HeaderText = rm.GetString("dgTlookup.Columns(TAnalysisId).HeaderText")
            dgTlookup.Columns("TAnalysisCode").HeaderText = rm.GetString("dgTlookup.Columns(TAnalysisCode).HeaderText")
            dgTlookup.Columns("TValue").HeaderText = rm.GetString("dgTlookup.Columns(TValue).HeaderText")
            dgTlookup.Columns("TAnalysisDescp").HeaderText = rm.GetString("dgTlookup.Columns(TAnalysisDescp).HeaderText")
            dgTlookup.Columns("TAnalysisAbbrev").HeaderText = rm.GetString("dgTlookup.Columns(TAnalysisAbbrev).HeaderText")
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgTlookup_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgTlookup.CellDoubleClick
        If dgTlookup.RowCount <> 0 Then
            Dim objTID As New VehicleDistributionPPT
            strTId = dgTlookup.CurrentRow.Cells("TAnalysisId").Value.ToString() 'TAnalysisId
            strTCode = dgTlookup.CurrentRow.Cells("TAnalysisCode").Value.ToString()
            strTValue = dgTlookup.CurrentRow.Cells("TValue").Value.ToString()
            strTDesc = dgTlookup.CurrentRow.Cells("TAnalysisDescp").Value.ToString()
            strTAbbrev = dgTlookup.CurrentRow.Cells("TAnalysisAbbrev").Value.ToString()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("There is no record to select")
            'Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub btnTSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTSearch.Click
        Dim ds As New DataSet
        Dim objT As New VehicleDistributionPPT
        objT.TDecide = strTcodeDecide
        If strTcodeDecide = "T0" Then
            objT.T0Value = txtTValueSearch.Text.Trim()
            objT.T0Desc = txtTDescSearch.Text.Trim()
            If (VehicleDistributionBOL.TlookupSearch(objT, "NO").Tables(0).Rows.Count <= 0) Then
                MessageBox.Show("No Records Found")
                dgTlookup.DataSource = ds
            Else
                ds = VehicleDistributionBOL.TlookupSearch(objT, "NO")
                dgTlookup.DataSource = ds.Tables(0)
            End If
        End If
        If strTcodeDecide = "T1" Then
            objT.T1Value = txtTValueSearch.Text.Trim()
            objT.T1Desc = txtTDescSearch.Text.Trim()
            If (VehicleDistributionBOL.TlookupSearch(objT, "NO").Tables(0).Rows.Count <= 0) Then
                MessageBox.Show("No Records Found")
                dgTlookup.DataSource = ds
            Else
                ds = VehicleDistributionBOL.TlookupSearch(objT, "NO")
                dgTlookup.DataSource = ds.Tables(0)
            End If
        End If
        If strTcodeDecide = "T2" Then
            objT.T2Value = txtTValueSearch.Text.Trim()
            objT.T2Desc = txtTDescSearch.Text.Trim()
            If (VehicleDistributionBOL.TlookupSearch(objT, "NO").Tables(0).Rows.Count <= 0) Then
                MessageBox.Show("No Records Found")
                dgTlookup.DataSource = ds
            Else
                ds = VehicleDistributionBOL.TlookupSearch(objT, "NO")
                dgTlookup.DataSource = ds.Tables(0)
            End If
        End If
        If strTcodeDecide = "T3" Then
            objT.T3Value = txtTValueSearch.Text.Trim()
            objT.T3Desc = txtTDescSearch.Text.Trim()
            If (VehicleDistributionBOL.TlookupSearch(objT, "NO").Tables(0).Rows.Count <= 0) Then
                MessageBox.Show("No Records Found")
                dgTlookup.DataSource = ds
            Else
                ds = VehicleDistributionBOL.TlookupSearch(objT, "NO")
                dgTlookup.DataSource = ds.Tables(0)
            End If
        End If
        If strTcodeDecide = "T4" Then
            objT.T4Value = txtTValueSearch.Text.Trim()
            objT.T4Desc = txtTDescSearch.Text.Trim()
            If (VehicleDistributionBOL.TlookupSearch(objT, "NO").Tables(0).Rows.Count <= 0) Then
                MessageBox.Show("No Records Found")
                dgTlookup.DataSource = ds
            Else
                ds = VehicleDistributionBOL.TlookupSearch(objT, "NO")
                dgTlookup.DataSource = ds.Tables(0)
            End If
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Public Sub BindTLookup()
        SetUICulture(GlobalPPT.strLang)
        Dim objTlookup As New VehicleDistributionPPT
        ' Dim strEMDN As EstateMillDeliveryNoteFrm
        objTlookup.TDecide = strTcodeDecide
        Dim ds As New DataSet
        'dgTlookup.AutoGenerateColumns = False
        ds = VehicleDistributionBOL.TlookupSearch(objTlookup, "NO")
        If ds.Tables(0).Rows.Count > 0 Then
            dgTlookup.DataSource = ds.Tables(0)
        End If
    End Sub

End Class