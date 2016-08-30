Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Common_BOL
Imports System.Configuration
Public Class StoreIPRReportFrm

    'Public strSTIPRID As String = String.Empty
    Public lStockCategory As String = String.Empty
    Public Shared strSTIPRNo As String = String.Empty
    'Public strSTIPRDate As Date = Nothing
    'Public strClassification As String = String.Empty
    'Public strCategory As String = String.Empty
    'Public strCategoryCode As String = String.Empty
    'Public strRequiredfor As String = String.Empty
    'Public strDeliveredto As String = String.Empty
    'Public strStatus As String = String.Empty
    'Public strMakeModel As String = String.Empty
    'Public strFixedAssetNo As String = String.Empty
    'Public strChassisSerialNo As String = String.Empty
    'Public strEngine As String = String.Empty
    'Public strModifiedOn As String = String.Empty
    Public Shared strUsageCOAID As String = String.Empty
    'Public strUsageCOADescp As String = String.Empty
    Public strUsageCOACode As String = String.Empty
    'Public strRequiredDate As Date = Nothing
    'Public strD As String = String.Empty
    'Public strRemarks As String = String.Empty
    '
    Dim strServerUserName As String = String.Empty
    Dim strServerPassword As String = String.Empty
    Dim strDSN As String = String.Empty
    '

    Private Sub StoreInternalPurchaseRequisitionRequestReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtpviewIPRDate.Format = DateTimePickerFormat.Custom
        dtpviewIPRDate.CustomFormat = "dd/MM/yyyy"
        BindIPRDetails()
        SetUICulture(GlobalPPT.strLang)

    End Sub


    Private Sub InternalPurchaseRequisitionApprovalFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        BindIPRDetails()

    End Sub

    Public Sub BindIPRDetails()

        dgvIPRApproval.DataSource = Nothing
        Dim objIPRApprovalPPT As New InternalPurchaseRequisitionApprovalPPT
        Dim objIPRApprovalBOL As New InternalPurchaseRequisitionApprovalBOL
        Dim dt As New DataTable
        With objIPRApprovalPPT
            If chkIPRdate.Checked = True Then
                .IPRdate = Format(Me.dtpviewIPRDate.Value, "MM/dd/yyyy")
            Else
                .IPRdate = Nothing
            End If
            .IPRNo = Me.txtviewIPRNo.Text
            .DeliveredTo = Me.txtviewDeliveredto.Text
            .Classification = Me.txtviewClassification.Text
            .RequiredFor = Me.txtviewRequiredfor.Text
            .STCategory = Me.txtviewCategory.Text
            '.MainStatus = "OPEN"
        End With

        dt = objIPRApprovalBOL.STIPRSelectForReport(objIPRApprovalPPT)
        If dt.Rows.Count <> 0 Then
            lblView.Visible = False
            dgvIPRApproval.Visible = True
            dgvIPRApproval.AutoGenerateColumns = False
            dgvIPRApproval.DataSource = dt
            'Exit Sub
        Else
            lblView.Visible = True
            dgvIPRApproval.Visible = False
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

    Sub SetUICulture(ByVal culture As String)

        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StoreIPRReportFrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)


            btnClose.Text = rm.GetString("btnClose.Text")
            lblsearchBy.Text = rm.GetString("lblsearchBy.Text")
            lblviewIPRDate.Text = rm.GetString("lblviewIPRDate.Text")
            lblviewIPRno.Text = rm.GetString("lblviewIPRno.Text")
            lblviewCategory.Text = rm.GetString("lblviewCategory.Text")
            lblviewClassification.Text = rm.GetString("lblviewClassification.Text")
            lblviewRequiredfor.Text = rm.GetString("lblviewRequiredfor.Text")
            lblviewDeliveredto.Text = rm.GetString("lblviewDeliveredto.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
            lblView.Text = rm.GetString("lblView.Text ")


            dgvIPRApproval.Columns("dgclIPRNo").HeaderText = rm.GetString("dgvIRPView.Columns(dgclIPRNo).HeaderText")
            dgvIPRApproval.Columns("dgclIPRDate").HeaderText = rm.GetString("dgvIRPView.Columns(dgclIPRDate).HeaderText")
            dgvIPRApproval.Columns("dgclCategory").HeaderText = rm.GetString("dgvIRPView.Columns(dgclCategory).HeaderText")
            dgvIPRApproval.Columns("dgclRequiredfor").HeaderText = rm.GetString("dgvIRPView.Columns(dgclRequiredfor).HeaderText")
            ' dgvIPRApproval.Columns("dgclRequiredDate").HeaderText = rm.GetString("dgvIRPView.Columns(dgclRequiredDate).HeaderText")
            dgvIPRApproval.Columns("dgclDeliveredto").HeaderText = rm.GetString("dgvIRPView.Columns(dgclDeliveredto).HeaderText")
            dgvIPRApproval.Columns("dgclClassification").HeaderText = rm.GetString("dgvIRPView.Columns(dgclClassification).HeaderText")
            dgvIPRApproval.Columns("dgclStatus").HeaderText = rm.GetString("dgvIRPView.Columns(dgclStatus).HeaderText")
            dgvIPRApproval.Columns("dgclViewDetails").HeaderText = rm.GetString("dgvIRPView.Columns(dgclViewDetails).HeaderText")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnviewCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewCategory.Click

        Dim StockCategory As New CategoryLookup()
        StockCategory.BindStockCategory()
        Dim result As DialogResult = CategoryLookup.ShowDialog()
        If CategoryLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lStockCategory = CategoryLookup._lStockCategory
            txtviewCategory.Text = lStockCategory
            'lStockCategoryID = CategoryLookup._lStockCategoryID
        End If

    End Sub

    Private Sub dgvIPRApproval_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIPRApproval.CellContentClick

        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        Dim dt As New DataTable

        If e.ColumnIndex = 17 Then
            With objIPRPPT
                strSTIPRNo = dgvIPRApproval.SelectedRows(0).Cells("dgclIPRNo").Value.ToString()
                strUsageCOAID = dgvIPRApproval.SelectedRows(0).Cells("gvUsageCOAID").Value.ToString()
                strUsageCOACode = dgvIPRApproval.SelectedRows(0).Cells("gvUsageCOACode").Value.ToString()
                StoreIPRReportView.Show()
            End With

            '
            
            '
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