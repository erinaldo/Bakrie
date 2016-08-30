Imports Store_BOL
Imports Store_PPT
Imports Common_PPT
Imports Common_BOL
Imports System.Data.SqlClient

Public Class APSupplierLookUp

    Public _lSupplierID As String = String.Empty
    Public _lSupplierCode As String = String.Empty
    Public _lSupplierName As String = String.Empty

    Public Sub BindSupplier()

        Dim dt As New DataTable
        Dim objLPOPPT As New LocalPurchaseOrderPPT
        Dim objLPOBOL As New LocalPurchaseOrderBOL
        objLPOPPT.SupplierID = txtSupplier.Text
        dt = objLPOBOL.SearchSupplier(objLPOPPT)
        If dt.Rows.Count <> 0 Then
            dgvSupplier.AutoGenerateColumns = False
            dgvSupplier.DataSource = dt
        Else
            dt.Clear()
            DisplayInfoMessage("msg01")
            ''MsgBox("No Records Found")
            dgvSupplier.DataSource = dt
            txtSupplier.Text = ""
        End If

    End Sub

    Private Sub SupplierLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BindSupplier()
        SetUICulture(GlobalPPT.strLang)

    End Sub
    Private Sub dgvSupplier_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSupplier.CellDoubleClick

        SupplierGrid_Click()

    End Sub
    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(APSupplierLookUp))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

           
            lblSupplier.Text = rm.GetString("lblSupplier.Text")
            lblsearchCategory.Text = rm.GetString("lblsearchCategory.Text")
           
            dgvSupplier.Columns("dgclSupplierName").HeaderText = rm.GetString("dgvLPOView.Columns(dgclSupplierName).HeaderText")
            dgvSupplier.Columns("dgclSupplierCode").HeaderText = rm.GetString("dgvLPOView.Columns(dgclSupplierCode).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub dgvSupplier_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Return Then
            SupplierGrid_Click()
            e.Handled = True
        End If
        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgvSupplier, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgvSupplier, e)
        'End If

    End Sub
    Private Sub btnSupplierSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierSearch.Click

        BindSupplier()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        DialogResult = DialogResult.Cancel
        txtSupplier.Text = String.Empty

    End Sub

    Private Sub ClearAfterSearch()

        txtSupplier.Text = String.Empty

    End Sub

    Private Sub SupplierGrid_Click()

        If dgvSupplier.Rows.Count > 0 Then
            _lSupplierID = dgvSupplier.SelectedRows(0).Cells("dgclSupplierID").Value
            _lSupplierCode = dgvSupplier.SelectedRows(0).Cells("dgclSupplierCode").Value
            _lSupplierName = dgvSupplier.SelectedRows(0).Cells("dgclSupplierName").Value
            DialogResult = DialogResult.OK
        End If

    End Sub

    Private Sub APSupplierLookUp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(APSupplierLookUp))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub


End Class