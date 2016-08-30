Imports Vehicle_PPT
Imports Vehicle_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class VHDistributionVehicleLookup
    Public psVHID As String = String.Empty
    Public psVHDesc As String = String.Empty
    Public psVHWSCode As String = String.Empty
    Public psVHCategoryID As String = String.Empty
    Public psVHCategory As String = String.Empty
    Public psVHCategoryType As String = String.Empty
    Public psUOM As String = String.Empty
    Public dtcmbVHCategory As DataTable


    Private ldtLogDate As Date
    Public Property pdtLogDate() As Date
        Get
            Return ldtLogDate
        End Get
        Set(ByVal value As Date)
            ldtLogDate = value
        End Set
    End Property

    Private Sub VHNoLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbVHType.Text = cmbVHType.Items(0) 'For Default SELECT ALL
        SetUICulture(GlobalPPT.strLang)
        BindGrid()
        ''GetVHCategoryData()
        FillComboVHCategory()
        ''cmbVHCategory.Text = "--Select Category--"
    End Sub
    Private Sub FillComboVHCategory()
        Dim objSIV As New VehicleDistributionPPT
        Dim ds As New DataSet
        ds = VehicleDistributionBOL.VHNCategoryGet(objSIV)
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
        Dim objSIV As New VehicleDistributionPPT
        Dim ds As New DataSet
        ds = VehicleDistributionBOL.VHNCategoryGet(objSIV)
        dtcmbVHCategory = ds.Tables(0)
    End Sub
    Private Sub BindGrid()
        Dim objVHNo As New VehicleDistributionPPT
        Dim ds As New DataSet
        objVHNo.pdDistributionDT = pdtLogDate
        ds = VehicleDistributionBOL.GetVHNo(objVHNo, "NO")
        If ds.Tables.Count <> 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                dgVHNo.AutoGenerateColumns = False
                dgVHNo.DataSource = ds.Tables(0)
            End If
        End If
    End Sub

    Private Sub btnVHNoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVHNoSearch.Click
        Dim objVHNoPPT As New VehicleDistributionPPT
        Dim lType As String = String.Empty
        Dim ds As New DataSet
        objVHNoPPT.VHWSCode = txtVHNoSearch.Text.Trim()
        objVHNoPPT.VHDesc = txtVHDescSearch.Text.Trim()
        objVHNoPPT.pdDistributionDT = pdtLogDate
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
            'ElseIf cmbVHType.Text = "Workshop" Then
            '    lType = "W"
        ElseIf cmbVHType.Text = "Others" Then
            lType = "O"
        Else
            lType = String.Empty
        End If
        objVHNoPPT.Type = lType
        ds = VehicleDistributionBOL.GetVHNo(objVHNoPPT, "NO")
        

        'dgVHNo.Visible = True
        'dgVHNo.AutoGenerateColumns = False
        'dgVHNo.DataSource = ds.Tables(0)
        'dgVHNo.Visible = False

        dgVHNo.Visible = True
        dgVHNo.AutoGenerateColumns = False
        dgVHNo.DataSource = ds.Tables(0)


        If (ds.Tables(0).Rows.Count <= 0 And (txtVHNoSearch.Text <> String.Empty Or txtVHDescSearch.Text <> String.Empty Or cmbVHCategory.SelectedIndex > 0 Or cmbVHType.SelectedIndex > 0)) Then
            txtVHNoSearch.Focus()
            MsgBox("No record found.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Error")
        End If
        'FillComboVHCategory()
        'cmbVHCategory.Text = "--Select Category--"
    End Sub

    Private Sub dgVHNo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgVHNo.CellDoubleClick
        If dgVHNo.RowCount <> 0 Then
            Dim objYOP As New VehicleDistributionPPT
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
                psVHCategoryType = dgVHNo.CurrentRow.Cells("dgclType").Value.ToString
            End If
            If Not dgVHNo.CurrentRow.Cells("dgclCategory").Value.ToString() Is DBNull.Value Then
                psVHCategory = dgVHNo.CurrentRow.Cells("dgclCategory").Value.ToString()
            End If
            If Not dgVHNo.CurrentRow.Cells("dgclUOM").Value.ToString() Is DBNull.Value Then
                psUOM = dgVHNo.CurrentRow.Cells("dgclUOM").Value.ToString()
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
            MessageBox.Show("There is no record to select")
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VHDistributionVehicleLookup))
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class