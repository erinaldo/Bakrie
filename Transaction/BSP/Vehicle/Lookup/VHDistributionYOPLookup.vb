Imports Vehicle_PPT
Imports Vehicle_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class VHDistributionYOPLookup
    ''Public strYop As String = String.Empty
    ''Public strYopID As String = String.Empty
    ''Public strYOPName As String = String.Empty
    ''Private Sub YOPLookup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ''    SetUICulture(globalppt.strlang)
    ''    BindYOP()
    ''End Sub
    ''Sub SetUICulture(ByVal culture As String)
    ''    ' get a reference to the ResourceManager for this form
    ''    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(YOPLookup))
    ''    Try
    ''        'set the culture as per the selection and 
    ''        'load the appropriate strings for button, label, etc.
    ''        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

    ''        lblsearchYOP.Text = rm.GetString("lblsearchYOP.Text")
    ''        panYOPLookUp.CaptionText = rm.GetString("panYOPLookUp.CaptionText")

    ''        dgYOP.Columns("dgclYOP").HeaderText = rm.GetString("dgYOP.Columns(dgclYOP).HeaderText")
    ''        dgYOP.Columns("dgclYOPID").HeaderText = rm.GetString("dgYOP.Columns(dgclYOPID).HeaderText")
    ''        dgYOP.Columns("dgclName").HeaderText = rm.GetString("dgYOP.Columns(dgclName).HeaderText")

    ''    Catch
    ''        'display a message if the culture is not supported
    ''        'try passing bn (Bengali) for testing
    ''        MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    ''    End Try
    ''End Sub
    ''Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    ''    Me.Close()
    ''End Sub

    ''Private Sub btnYOPSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYOPSearch.Click
    ''    Dim objYOPPPt As New VehicleDistributionPPT
    ''    Dim ds As New DataSet
    ''    objYOPPPt.YOP = txtYOPSearch.Text.Trim()
    ''    objYOPPPt.YOPName = txtYOPNameSearch.Text.Trim()
    ''    If (VehicleDistributionBOL.GetYOP(objYOPPPt).Tables(0).Rows.Count <= 0) Then
    ''        MessageBox.Show("No Records Found")
    ''        dgYOP.DataSource = ds
    ''        dgYOP.AutoGenerateColumns = False
    ''    Else
    ''        ds = VehicleDistributionBOL.GetYOP(objYOPPPt)
    ''        dgYOP.DataSource = ds.Tables(0)
    ''    End If
    ''End Sub


    ''Private Sub dgYOP_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgYOP.CellDoubleClick
    ''    If dgYOP.RowCount <> 0 Then
    ''        Dim objYOP As New VehicleDistributionPPT
    ''        strYopID = dgYOP.CurrentRow.Cells("dgclYOPID").Value.ToString()
    ''        strYop = dgYOP.CurrentRow.Cells("dgclYOP").Value.ToString()
    ''        strYOPName = dgYOP.CurrentRow.Cells("dgclName").Value.ToString()
    ''        Me.Close()
    ''    Else
    ''        MessageBox.Show("There is no record to select")
    ''    End If
    ''End Sub



    ''Private Sub BindYOP()
    ''    Dim objYop As New VehicleDistributionPPT
    ''    Dim ds As New DataSet
    ''    ds = VehicleDistributionBOL.GetYOP(objYop)
    ''    dgYOP.DataSource = ds.Tables(0)
    ''End Sub
End Class