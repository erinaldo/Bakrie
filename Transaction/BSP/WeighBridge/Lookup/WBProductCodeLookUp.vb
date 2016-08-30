Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports Common_PPT
Imports System.Data.SqlClient
Public Class WBProductCodeLookUp

    Public _lProductCode As String = String.Empty
    Public _lProductDesc As String = String.Empty
    Public _lProductID As String = String.Empty

    Private Sub WBProductCodeLookUp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub WBProductCodeLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSerachProductCode.Text = String.Empty
        txtSearchProductDesc.Text = String.Empty
        ProductCodeGrid()
        SetUICulture(GlobalPPT.strLang)
    End Sub

    Private Sub ProductCodeGrid()
        Dim dt As New DataTable
        Dim objWBWeighingInOutPPT As New WBWeighingInOutPPT
        Dim objWBWeighingInOutBOL As New WBWeighingInOutBOL
        objWBWeighingInOutPPT.ProductCodeSearch = txtSerachProductCode.Text.Trim
        objWBWeighingInOutPPT.ProductDescSearch = txtSearchProductDesc.Text.Trim
        dt = objWBWeighingInOutBOL.WBProductCode_Select(objWBWeighingInOutPPT)
        dgvProductCode.AutoGenerateColumns = False
        dgvProductCode.DataSource = dt
        If txtSerachProductCode.Text = String.Empty And txtSearchProductDesc.Text = String.Empty Then
            If dt.Rows.Count <= 0 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("No Records Found")
            End If
        Else
            If dt.Rows.Count <= 0 Then
                DisplayInfoMessage("Msg2")
                ''MessageBox.Show("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBProductCodeLookUp))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        txtSerachProductCode.Text = String.Empty
        txtSearchProductDesc.Text = String.Empty
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub dgvProductCode_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductCode.CellDoubleClick
        GridCell_Click()
    End Sub

    Private Sub GridCell_Click()
        If dgvProductCode.Rows.Count > 0 Then
            If Not dgvProductCode.SelectedRows(0).Cells("dgclProductCode").Value Is DBNull.Value Then
                _lProductCode = dgvProductCode.SelectedRows(0).Cells("dgclProductCode").Value
            End If
            If Not dgvProductCode.SelectedRows(0).Cells("dgclProductID").Value Is DBNull.Value Then
                _lProductID = dgvProductCode.SelectedRows(0).Cells("dgclProductID").Value
            End If
            If Not dgvProductCode.SelectedRows(0).Cells("dgclProductDesc").Value Is DBNull.Value Then
                _lProductDesc = dgvProductCode.SelectedRows(0).Cells("dgclProductDesc").Value
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        ProductCodeGrid()
    End Sub

    Private Sub dgvProductCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvProductCode.KeyDown
        If e.KeyCode = Keys.Return Then
            GridCell_Click()
            e.Handled = True
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBProductCodeLookUp))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblSearchProductCode.Text = rm.GetString("lblSearchProductCode.Text")
            lblSearchProductDesc.Text = rm.GetString("lblSearchProductDesc.Text")
            pnlProductSearch.CaptionText = rm.GetString("pnlProductSearch.CaptionText")
            'Me.WBProductCodeLookUp.Text = rm.GetString("WBProductCodeLookUp.Text")
            dgvProductCode.Columns("dgclProductCode").HeaderText = rm.GetString("dgvProductCode.Columns(dgclProductCode).HeaderText")
            dgvProductCode.Columns("dgclProductDesc").HeaderText = rm.GetString("dgvProductCode.Columns(dgclProductDesc).HeaderText")
   
        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnView_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnView.KeyPress
        ProductCodeGrid()
    End Sub
End Class