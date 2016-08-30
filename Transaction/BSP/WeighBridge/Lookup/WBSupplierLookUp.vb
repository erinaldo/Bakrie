Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Public Class WBSupplierLookUp
    Public _lSupplierCode As String = String.Empty
    Public _lSupplierDesc As String = String.Empty
    Public _lSupplierCustID As String = String.Empty
    Public _lCompany As String = String.Empty
    Public _lProductCode As String = String.Empty
    Public _lProductDesc As String = String.Empty
    Public _lProductID As String = String.Empty

    Private Sub SupplierGrid()
        Dim dt As New DataTable
        Dim objWBWeighingInOutPPT As New WBWeighingInOutPPT
        Dim objWBWeighingInOutBOL As New WBWeighingInOutBOL
        objWBWeighingInOutPPT.SupplierCodeSearch = txtSearchSupplierCode.Text.Trim
        objWBWeighingInOutPPT.SupplierNameSearch = txtSearchSupplerName.Text.Trim
        If cmbCompany.Text = "Outside Company" Then
            objWBWeighingInOutPPT.Company = "2"
        ElseIf cmbCompany.Text = "Own Company" Then
            objWBWeighingInOutPPT.Company = "1"
        ElseIf cmbCompany.Text = "ALL" Then
            objWBWeighingInOutPPT.Company = String.Empty
        ElseIf cmbCompany.Text = String.Empty Then
            objWBWeighingInOutPPT.Company = String.Empty
        End If

        dt = objWBWeighingInOutBOL.WBSupplier_Select(objWBWeighingInOutPPT)
        dgvSupplier.AutoGenerateColumns = False
        dgvSupplier.DataSource = dt
        If txtSearchSupplierCode.Text = String.Empty And txtSearchSupplerName.Text = String.Empty And cmbCompany.Text = "ALL" Then
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

    Private Sub WBSupplierLookUp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub WBSupplierLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearchSupplierCode.Text = String.Empty
        txtSearchSupplerName.Text = String.Empty
        cmbCompany.Text = "ALL"
        SupplierGrid()
        SetUICulture(GlobalPPT.strLang)
    End Sub

    Private Sub GridCell_Click()
        If dgvSupplier.Rows.Count > 0 Then
            If Not dgvSupplier.SelectedRows(0).Cells("dgclSupplierCode").Value Is DBNull.Value Then
                _lSupplierCode = dgvSupplier.SelectedRows(0).Cells("dgclSupplierCode").Value
            End If
            If Not dgvSupplier.SelectedRows(0).Cells("dgclSupplierName").Value Is DBNull.Value Then
                _lSupplierDesc = dgvSupplier.SelectedRows(0).Cells("dgclSupplierName").Value
            End If
            If Not dgvSupplier.SelectedRows(0).Cells("dgclSupplierID").Value Is DBNull.Value Then
                _lSupplierCustID = dgvSupplier.SelectedRows(0).Cells("dgclSupplierID").Value
            End If
            If Not dgvSupplier.SelectedRows(0).Cells("dgclCompany").Value Is DBNull.Value Then
                'If dgvSupplier.SelectedRows(0).Cells("dgclCompany").Value = 1 Then
                '    _lCompany = "Own  "
                'End If
                _lCompany = dgvSupplier.SelectedRows(0).Cells("dgclCompany").Value
            End If
            If Not dgvSupplier.SelectedRows(0).Cells("dgclProductCode").Value Is DBNull.Value Then
                _lProductCode = dgvSupplier.SelectedRows(0).Cells("dgclProductCode").Value
            Else
                _lProductCode = String.Empty
            End If
            If Not dgvSupplier.SelectedRows(0).Cells("dgclProductDesc").Value Is DBNull.Value Then
                _lProductDesc = dgvSupplier.SelectedRows(0).Cells("dgclProductDesc").Value
            Else
                _lProductDesc = String.Empty
            End If
            If Not dgvSupplier.SelectedRows(0).Cells("dgclProductID").Value Is DBNull.Value Then
                _lProductID = dgvSupplier.SelectedRows(0).Cells("dgclProductID").Value
            Else
                _lProductID = String.Empty
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        txtSearchSupplierCode.Text = String.Empty
        txtSearchSupplerName.Text = String.Empty
        cmbCompany.Text = String.Empty

        '_lSupplierCode = String.Empty
        '_lProductCode = String.Empty
        '_lSupplierCustID = String.Empty
        '_lProductID = String.Empty
        '_lProductDesc = String.Empty
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        'Me.Close()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        SupplierGrid()
    End Sub

    Private Sub dgvSupplier_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSupplier.CellDoubleClick
        GridCell_Click()
    End Sub

    Private Sub dgvSupplier_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvSupplier.KeyDown
        If e.KeyCode = Keys.Return Then
            GridCell_Click()
            e.Handled = True
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBSupplierLookUp))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblSearchSupplierCode.Text = rm.GetString("lblSearchSupplierCode.Text")
            lblSearchSupplierName.Text = rm.GetString("lblSearchSupplierName.Text")
            pnlSupplierSearch.CaptionText = rm.GetString("pnlSupplierSearch.CaptionText")
            'Me.WBProductCodeLookUp.Text = rm.GetString("WBProductCodeLookUp.Text")
            dgvSupplier.Columns("dgclSupplierCode").HeaderText = rm.GetString("dgvSupplier.Columns(dgclSupplierCode).HeaderText")
            dgvSupplier.Columns("dgclSupplierName").HeaderText = rm.GetString("dgvSupplier.Columns(dgclSupplierName).HeaderText")
            dgvSupplier.Columns("dgclProductCode").HeaderText = rm.GetString("dgvSupplier.Columns(dgclProductCode).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(WBSupplierLookUp))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnView_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnView.KeyPress
        SupplierGrid()
    End Sub
End Class