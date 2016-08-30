Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports Common_BOL
Imports BSP.MDIParent
Imports System.Data.SqlClient
Public Class IPRStatusfrm


    Public lStockCategory As String = String.Empty
    Public Shared lStockCategoryID As String = String.Empty
    Public Shared lStockCategoryCode As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(IPRStatusfrm))
    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        GridIPRViewBind()
        If dgvIRPView.Rows.Count <> 0 Then
            Exit Sub
        Else
            DisplayInfoMessage("msg1")
            ''MessageBox.Show("There is no record found for your search criteria")
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub IPRStatusfrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  
        chkIPRdate.Focus()
        dtpviewIPRDate.Format = DateTimePickerFormat.Custom
        dtpviewIPRDate.CustomFormat = "dd/MM/yyyy"

        GlobalBOL.SetDateTimePicker(Me.dtpviewIPRDate)
        cmbStatus.Text = "OPEN"
        GridIPRViewBind()

        SetUICulture(GlobalPPT.strLang)
        chkIPRdate.Focus()

      

    End Sub
    Private Sub GridIPRViewBind()
        dgvIRPView.DataSource = Nothing

        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        Dim dt As New DataTable
        With objIPRPPT
            Dim str As String = cmbStatus.SelectedItem.ToString()
 

            If chkIPRdate.Checked = True Then
                .IPRdate = dtpviewIPRDate.Value
            Else
                .IPRdate = Nothing
            End If
            .IPRNo = Me.txtviewIPRNo.Text.Trim
            .DeliveredTo = Me.txtviewDeliveredto.Text.Trim
            .Classification = Me.txtviewClassification.Text.Trim
            .RequiredFor = Me.txtviewRequiredfor.Text.Trim
            .STCategory = Me.txtviewCategory.Text.Trim
            .MainStatus = cmbStatus.SelectedItem.ToString()

        End With

        dt = objIPRBOL.GetIPRDetails(objIPRPPT)
        If dt.Rows.Count <> 0 Then
            dgvIRPView.AutoGenerateColumns = False
            Me.dgvIRPView.DataSource = dt

            dgvIRPView.AutoGenerateColumns = False
 
        Else
            Exit Sub
        End If
    End Sub
    Sub SetUICulture(ByVal culture As String)

        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)


            pnlIPRStatus.Text = rm.GetString("pnlIPRStatus.Text")
            lblsearchCategory.Text = rm.GetString("lblsearchCategory.Text")
            lblviewIPRDate.Text = rm.GetString("lblviewIPRDate.Text")
            lblviewIPRno.Text = rm.GetString("lblviewIPRno.Text")
            lblviewCategory.Text = rm.GetString("lblviewCategory.Text")
            lblviewClassification.Text = rm.GetString("lblviewClassification.Text")
            lblviewRequiredfor.Text = rm.GetString("lblviewRequiredfor.Text")
            lblviewDeliveredto.Text = rm.GetString("lblviewDeliveredto.Text")
            lblviewMainstatus.Text = rm.GetString("lblviewMainstatus.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
           
           

            dgvIRPView.Columns("gvIPRNo").HeaderText = rm.GetString("dgvIRPView.Columns(gvIPRNo).HeaderText")
            dgvIRPView.Columns("gvIPRDate").HeaderText = rm.GetString("dgvIRPView.Columns(gvIPRDate).HeaderText")
            dgvIRPView.Columns("gvSTCategory").HeaderText = rm.GetString("dgvIRPView.Columns(gvSTCategory).HeaderText")
            dgvIRPView.Columns("gvRequiredfor").HeaderText = rm.GetString("dgvIRPView.Columns(gvRequiredfor).HeaderText")
            dgvIRPView.Columns("gvlRequiredDate").HeaderText = rm.GetString("dgvIRPView.Columns(gvlRequiredDate).HeaderText")
            'dgvIRPView.Columns("gvD").HeaderText = rm.GetString("dgvIRPView.Columns(gvD).HeaderText")
            dgvIRPView.Columns("gvDeliveredto").HeaderText = rm.GetString("dgvIRPView.Columns(gvDeliveredto).HeaderText")
            dgvIRPView.Columns("gvClassification").HeaderText = rm.GetString("dgvIRPView.Columns(gvClassification).HeaderText")
            dgvIRPView.Columns("gvMainStatus").HeaderText = rm.GetString("dgvIRPView.Columns(gvMainStatus).HeaderText")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnviewCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewCategory.Click
        Dim StockCategory As New CategoryLookup()
        StockCategory.BindStockCategory()
        NonStockIPRFrm.StrFrmName = "IPR"

        Dim result As DialogResult = CategoryLookup.ShowDialog()

        If CategoryLookup.DialogResult = Windows.Forms.DialogResult.OK Then

            Me.lStockCategory = CategoryLookup._lStockCategoryCode
            Me.txtviewCategory.Text = lStockCategory
 
            lStockCategoryCode = CategoryLookup._lStockCategory
 
            lStockCategoryID = CategoryLookup._lStockCategoryID
 
        End If
    End Sub

  
    Private Sub IPRStatusfrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub chkIPRdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkIPRdate.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbStatus.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtviewCategory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtviewCategory.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtviewClassification_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtviewClassification.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtviewIPRNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtviewIPRNo.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtviewRequiredfor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtviewRequiredfor.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtviewDeliveredto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtviewDeliveredto.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dtpviewIPRDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpviewIPRDate.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub chkIPRdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIPRdate.CheckedChanged

        If chkIPRdate.Checked = True Then
            dtpviewIPRDate.Enabled = True
        Else
            dtpviewIPRDate.Enabled = False
        End If

    End Sub

End Class