Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class VHNoLookup

    Public psVHID As String = String.Empty
    Public psVHDesc As String = String.Empty
    Public psVHWSCode As String = String.Empty
    Public psVHCategoryID As String = String.Empty
    Public psVHCategory As String = String.Empty
    Public psVHCategoryType As String = String.Empty
    Public psVHType As String = String.Empty
    Public dtcmbVHCategory As DataTable

    Private Sub VHNoLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If psVHType <> String.Empty Then
            cmbVHType.Text = cmbVHType.Items(0) 'For Default SELECT ALL
            cmbVHType.Enabled = True
        ElseIf psVHType = "Vehicle" Then
            cmbVHType.Text = cmbVHType.Items(1)
            cmbVHType.Enabled = False

        ElseIf psVHType = "Workshop" Then
            cmbVHType.Text = cmbVHType.Items(2)
            cmbVHType.Enabled = False
        ElseIf psVHType = "Others" Then
            cmbVHType.Text = cmbVHType.Items(3)
            cmbVHType.Enabled = False
        ElseIf psVHType = "NOWorkshop" Then
            cmbVHType.Text = "NOWorkshop"
            cmbVHType.Enabled = False
        End If

        SetUICulture(GlobalPPT.strLang)
        BindGrid()
        ''GetVHCategoryData()
        FillComboVHCategory()
        ''cmbVHCategory.Text = "--Select Category--"
        txtVHNoSearch.Text = String.Empty

        txtVHNoSearch.Focus()
    End Sub
    Private Sub FillComboVHCategory()

        Dim objSIV As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        ds = StoreIssueVoucherBOL.VHNCategoryGet(objSIV)
        dtcmbVHCategory = ds.Tables(0)
        Try
            Dim dr As DataRow = dtcmbVHCategory.NewRow()
            dr(0) = "--Select Category--"
            dr(1) = "--Select Category--"
            dtcmbVHCategory.Rows.InsertAt(dr, 0)
            dtcmbVHCategory.AcceptChanges()

            'cmbSIVNO.Items.Clear()
            cmbVHCategory.DataSource = Nothing
            cmbVHCategory.DataSource = dtcmbVHCategory
            cmbVHCategory.DisplayMember = "Category"
            cmbVHCategory.ValueMember = "VHCategoryID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub GetVHCategoryData()

        Dim objSIV As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        ds = StoreIssueVoucherBOL.VHNCategoryGet(objSIV)
        dtcmbVHCategory = ds.Tables(0)

    End Sub
    Private Sub BindGrid()

        Dim objVHNoPPT As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        Dim lType As String = String.Empty

        If cmbVHType.Text = "Vehicle" Then
            lType = "V"
        ElseIf cmbVHType.Text = "Workshop" Then
            lType = "W"
        ElseIf cmbVHType.Text = "Others" Then
            lType = "O"
        ElseIf cmbVHType.Text = "NOWorkshop" Then
            lType = "N"
        Else
            lType = String.Empty
        End If

        objVHNoPPT.Type = lType


        ds = StoreIssueVoucherBOL.GetVHNo(objVHNoPPT, "NO")
        If ds.Tables.Count <> 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                dgVHNo.AutoGenerateColumns = False
                dgVHNo.DataSource = ds.Tables(0)
            End If
        End If

    End Sub

    Private Sub btnVHNoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVHNoSearch.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objVHNoPPT As New StoreIssueVoucherPPT
        Dim lType As String = String.Empty
        Dim ds As New DataSet
        objVHNoPPT.VHWSCode = txtVHNoSearch.Text.Trim()
        objVHNoPPT.VHDesc = txtVHDescSearch.Text.Trim()
        If cmbVHCategory.Items.Count > 0 Then
            If cmbVHCategory.Text <> "--Select Category--" Then
                objVHNoPPT.VHCategoryID = cmbVHCategory.SelectedValue 'if search criteria is  based on vhcategoryId
            Else
                objVHNoPPT.VHCategoryID = String.Empty
            End If
        Else
            objVHNoPPT.VHCategoryID = String.Empty
        End If
        ''If cmbVHCategory.Items.Count > 0 Then 
        ''    objVHNoPPT.VHCategoryID = cmbVHCategory.Text 'if search criteria is  based on vhcategory
        ''Else
        ''    objVHNoPPT.VHCategoryID = String.Empty
        ''End If

        If cmbVHType.Text = "Vehicle" Then
            lType = "V"
        ElseIf cmbVHType.Text = "Workshop" Then
            lType = "W"
        ElseIf cmbVHType.Text = "Others" Then
            lType = "O"
        ElseIf cmbVHType.Text = "NOWorkshop" Then
            lType = "N"
        Else
            lType = String.Empty
        End If

        objVHNoPPT.Type = lType
        ds = StoreIssueVoucherBOL.GetVHNo(objVHNoPPT, "NO")
        If (ds.Tables(0).Rows.Count <= 0) Then
            lblNoRecord.Visible = True
            dgVHNo.AutoGenerateColumns = False
            dgVHNo.DataSource = ds.Tables(0)
            'dgVHNo.Visible = False
        Else
            lblNoRecord.Visible = False
            dgVHNo.Visible = True
            dgVHNo.AutoGenerateColumns = False
            dgVHNo.DataSource = ds.Tables(0)
        End If
        ''FillComboVHCategory()
        'cmbVHCategory.Text = "--Select Category--"
        'ClearAfterSearch
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgVHNo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVHNo.CellDoubleClick

        Grid_Click()

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VHNoLookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchVHNo.Text = rm.GetString("lblsearchVHNo.Text")
            panVHNoLookUp.CaptionText = rm.GetString("panVHNoLookUp.CaptionText")
            lblVHNo.Text = rm.GetString("lblVHNo.Text")
            lblVechileDesc.Text = rm.GetString("lblVechileDesc.Text")
            lblVHCategory.Text = rm.GetString("lblVHCategory.Text")
            lblVHType.Text = rm.GetString("lblVHType.Text")

            dgVHNo.Columns("dgclVHNo").HeaderText = rm.GetString("dgVHWSCode.Columns(dgclVHNo).HeaderText")
            dgVHNo.Columns("dgclVHDescp").HeaderText = rm.GetString("dgVHNo.Columns(dgclVHDescp).HeaderText")
            dgVHNo.Columns("dgclCategory").HeaderText = rm.GetString("dgVHNo.Columns(dgclCategory).HeaderText")
            dgVHNo.Columns("dgclType").HeaderText = rm.GetString("dgVHNo.Columns(dgclType).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ClearAfterSearch()

        txtVHNoSearch.Text = String.Empty
        txtVHDescSearch.Text = String.Empty

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub VHNoLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub
    Private Sub Grid_Click()

        If dgVHNo.RowCount <> 0 Then
            Dim objYOP As New StoreIssueVoucherPPT
            If Not dgVHNo.CurrentRow.Cells("dgclVHID").Value.ToString() Is DBNull.Value Then
                psVHID = dgVHNo.CurrentRow.Cells("dgclVHID").Value.ToString()
            End If
            If Not dgVHNo.CurrentRow.Cells("dgclVHDescp").Value.ToString() Is DBNull.Value Then
                psVHDesc = dgVHNo.CurrentRow.Cells("dgclVHDescp").Value.ToString()
            End If
            If Not dgVHNo.CurrentRow.Cells("dgclVHNo").Value.ToString() Is DBNull.Value Then
                psVHWSCode = dgVHNo.CurrentRow.Cells("dgclVHNo").Value.ToString()
            End If
            If Not dgVHNo.CurrentRow.Cells("dgclVHCategoryID").Value.ToString() Is DBNull.Value Then
                psVHCategoryID = dgVHNo.CurrentRow.Cells("dgclVHCategoryID").Value.ToString()
            End If
            If Not dgVHNo.CurrentRow.Cells("dgclType").Value.ToString() Is DBNull.Value Then
                psVHCategoryType = dgVHNo.CurrentRow.Cells("dgclType").Value
            End If
            If Not dgVHNo.CurrentRow.Cells("dgclCategory").Value.ToString() Is DBNull.Value Then
                psVHCategory = dgVHNo.CurrentRow.Cells("dgclCategory").Value.ToString()
            End If
            ''If Not dgVHNo.CurrentRow.Cells("dgclType").Value Is DBNull.Value Then
            ''    If dgVHNo.CurrentRow.Cells("dgclType").Value = "Vehicle" Then
            ''        psVHCategoryType = "V"
            ''    End If
            ''    If dgVHNo.CurrentRow.Cells("dgclType").Value = "Workshop" Then
            ''        psVHCategoryType = "W"
            ''    End If
            ''    If dgVHNo.CurrentRow.Cells("dgclType").Value = "Others" Then
            ''        psVHCategoryType = "O"
            ''    End If
            ''End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            DisplayInfoMessage("msg01")
            ''MessageBox.Show("There is no record to select")
        End If

    End Sub

    Private Sub dgVHNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgVHNo.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Click()
            e.Handled = True
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VHNoLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
End Class