Imports WeighBridge_BOL
Imports WeighBridge_PPT
Imports Common_PPT
Imports System.Data.SqlClient
Public Class VehicleCodeLookUp

    Public _lVehicleCode As String = String.Empty
    Public _lVehicleDesc As String = String.Empty
    Public _lSupplier As String = String.Empty
    Public _ProductNo As String = String.Empty
    Public _lSupplierDetID As String = String.Empty
    Public _lSupplierCustID As String = String.Empty
    Public _ProductID As String = String.Empty
    Public _ProductDesc As String = String.Empty

    Private Sub BindVehicleCodeGrid()
        Dim dt As New DataTable
        Dim objWBWeighingInOutPPT As New WBWeighingInOutPPT
        Dim objWBWeighingInOutBOL As New WBWeighingInOutBOL
        objWBWeighingInOutPPT.VehicleCodeSearch = txtSearchVehicleCode.Text.Trim
        objWBWeighingInOutPPT.VehicleDescSearch = txtSearchVehicleDesc.Text.Trim
        dt = objWBWeighingInOutBOL.WBVehicleCode_Select(objWBWeighingInOutPPT)
        dgvVehicleCode.AutoGenerateColumns = False
        dgvVehicleCode.DataSource = dt
        If txtSearchVehicleCode.Text = String.Empty And txtSearchVehicleDesc.Text = String.Empty Then
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
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleCodeLookUp))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub VehicleCodeLookUp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub VehicleCodeLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearchVehicleCode.Text = String.Empty
        txtSearchVehicleDesc.Text = String.Empty
        BindVehicleCodeGrid()
        SetUICulture(GlobalPPT.strLang)
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        txtSearchVehicleCode.Text = String.Empty
        txtSearchVehicleDesc.Text = String.Empty
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnVehicleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVehicleSearch.Click
        BindVehicleCodeGrid()
    End Sub


    Private Sub dgvVehicleCode_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVehicleCode.CellDoubleClick
        GridClick_event()
    End Sub

    Private Sub dgvVehicleCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvVehicleCode.KeyDown
        If e.KeyCode = Keys.Return Then
            GridClick_event()
            e.Handled = True
        End If
    End Sub

    Private Sub GridClick_event()
        If dgvVehicleCode.RowCount > 0 Then
            If Not dgvVehicleCode.SelectedRows(0).Cells("dgclVehicleCode").Value Is DBNull.Value Then
                _lVehicleCode = dgvVehicleCode.SelectedRows(0).Cells("dgclVehicleCode").Value
            Else
                _lVehicleCode = String.Empty
            End If

            If Not dgvVehicleCode.SelectedRows(0).Cells("dgclVehicleDesc").Value Is DBNull.Value Then
                _lVehicleDesc = dgvVehicleCode.SelectedRows(0).Cells("dgclVehicleDesc").Value
            Else
                _lVehicleDesc = String.Empty
            End If
            'If Not dgvVehicleCode.SelectedRows(0).Cells("dgclSupplier").Value Is DBNull.Value Then
            '    _lSupplier = dgvVehicleCode.SelectedRows(0).Cells("dgclSupplier").Value
            'Else
            '    _lSupplier = String.Empty
            'End If

            'If Not Me.dgvVehicleCode.SelectedRows(0).Cells("dgclProductCode").Value Is DBNull.Value Then
            '    _ProductNo = dgvVehicleCode.SelectedRows(0).Cells("dgclProductCode").Value
            'Else
            '    _ProductNo = String.Empty
            'End If

            If Not dgvVehicleCode.SelectedRows(0).Cells("dgclSupplierDetID").Value Is DBNull.Value Then
                _lSupplierDetID = dgvVehicleCode.SelectedRows(0).Cells("dgclSupplierDetID").Value
            Else
                _lSupplierDetID = String.Empty
            End If
            'If Not dgvVehicleCode.SelectedRows(0).Cells("dgclSupplierCustID").Value Is DBNull.Value Then
            '    _lSupplierCustID = dgvVehicleCode.SelectedRows(0).Cells("dgclSupplierCustID").Value
            'Else
            '    _lSupplierCustID = String.Empty
            'End If

            'If Not dgvVehicleCode.SelectedRows(0).Cells("dgclProductID").Value Is DBNull.Value Then
            '    _ProductID = dgvVehicleCode.SelectedRows(0).Cells("dgclProductID").Value
            'Else
            '    _ProductID = String.Empty
            'End If

            'If Not dgvVehicleCode.SelectedRows(0).Cells("dgclProductDesc").Value Is DBNull.Value Then
            '    _ProductDesc = dgvVehicleCode.SelectedRows(0).Cells("dgclProductDesc").Value
            'Else
            '    _ProductDesc = String.Empty
            'End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleCodeLookUp))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblSearchVehicleCode.Text = rm.GetString("lblSearchVehicleCode.Text")
            lblSearchVehicleDesc.Text = rm.GetString("lblSearchVehicleDesc.Text")
            pnlVehicleSearch.CaptionText = rm.GetString("pnlVehicleSearch.CaptionText")
        
            dgvVehicleCode.Columns("dgclVehicleCode").HeaderText = rm.GetString("dgvVehicleCode.Columns(dgclVehicleCode).HeaderText")
            dgvVehicleCode.Columns("dgclVehicleDesc").HeaderText = rm.GetString("dgvVehicleCode.Columns(dgclVehicleDesc).HeaderText")
            dgvVehicleCode.Columns("dgclSupplier").HeaderText = rm.GetString("dgvVehicleCode.Columns(dgclSupplier).HeaderText")
            dgvVehicleCode.Columns("dgclProductCode").HeaderText = rm.GetString("dgvVehicleCode.Columns(dgclProductCode).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVehicleSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnVehicleSearch.KeyDown
        BindVehicleCodeGrid()
    End Sub
End Class