Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class InternalPurchaseRequisitionApprovalFrm

    Public strSTIPRID As String = String.Empty
    Public lStockCategory As String = String.Empty
    Public strSTIPRNo As String = String.Empty
    Public strSTIPRDate As Date = Nothing
    Public strClassification As String = String.Empty
    Public strCategory As String = String.Empty
    Public strCategoryCode As String = String.Empty
    Public strRequiredfor As String = String.Empty
    Public strDeliveredto As String = String.Empty
    Public strStatus As String = String.Empty
    Public strMakeModel As String = String.Empty
    Public strFixedAssetNo As String = String.Empty
    Public strChassisSerialNo As String = String.Empty
    Public strEngine As String = String.Empty
    Public strModifiedOn As String = String.Empty
    Public strUsageCOAID As String = String.Empty
    Public strUsageCOADescp As String = String.Empty
    Public strUsageCOACode As String = String.Empty
    Public strRequiredDate As Date = Nothing
    Public strD As String = String.Empty
    Public strRemarks As String = String.Empty
    Public strMRCNo As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalPurchaseRequisitionApprovalFrm))

    Private Sub InternalPurchaseRequisitionApprovalFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            .MainStatus = "OPEN"
        End With

        dt = objIPRApprovalBOL.IPRApprovalGet(objIPRApprovalPPT)
        If dt.Rows.Count <> 0 Then
            lblNoRecordFound.Visible = False
            dgvIPRApproval.AutoGenerateColumns = False
            dgvIPRApproval.DataSource = dt
            ' Exit Sub
        Else
            dgvIPRApproval.Visible = False
            lblNoRecordFound.Visible = True
            Exit Sub
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvIPRApproval_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIPRApproval.CellContentClick
        Dim IPRDate As String
        Dim RequiredDate As String
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        Dim dt As New DataTable
        If e.ColumnIndex = 17 Then

            With objIPRPPT
                strSTIPRID = dgvIPRApproval.SelectedRows(0).Cells("dgclIPRID").Value.ToString()
                strSTIPRNo = dgvIPRApproval.SelectedRows(0).Cells("dgclIPRNo").Value.ToString()
                IPRDate = dgvIPRApproval.SelectedRows(0).Cells("dgclIPRDate").Value.ToString()
                strSTIPRDate = New Date(IPRDate.Substring(6, 4), IPRDate.Substring(3, 2), IPRDate.Substring(0, 2))
                strClassification = dgvIPRApproval.SelectedRows(0).Cells("dgclClassification").Value.ToString()
                strRequiredfor = dgvIPRApproval.SelectedRows(0).Cells("dgclRequiredFor").Value.ToString()
                RequiredDate = dgvIPRApproval.SelectedRows(0).Cells("dgclRequiredDate").Value.ToString()
                strRequiredDate = New Date(RequiredDate.Substring(6, 4), RequiredDate.Substring(3, 2), RequiredDate.Substring(0, 2))
                strD = dgvIPRApproval.SelectedRows(0).Cells("dgclD").Value.ToString()
                strRemarks = dgvIPRApproval.SelectedRows(0).Cells("dgclRemarks").Value.ToString()
                strDeliveredto = dgvIPRApproval.SelectedRows(0).Cells("dgclDeliveredTo").Value.ToString()
                strCategory = dgvIPRApproval.SelectedRows(0).Cells("dgclCategory").Value.ToString()
                strCategoryCode = dgvIPRApproval.SelectedRows(0).Cells("dgclSTCategoryCode").Value.ToString()
                strStatus = dgvIPRApproval.SelectedRows(0).Cells("dgclStatus").Value.ToString()
                strMakeModel = dgvIPRApproval.SelectedRows(0).Cells("dgclMakeModel").Value.ToString()
                strEngine = dgvIPRApproval.SelectedRows(0).Cells("dgclEngine").Value.ToString()
                strChassisSerialNo = dgvIPRApproval.SelectedRows(0).Cells("dgclChassisSerialNo").Value.ToString()
                strFixedAssetNo = dgvIPRApproval.SelectedRows(0).Cells("dgclFixedAssetNo").Value.ToString()
                strModifiedOn = dgvIPRApproval.SelectedRows(0).Cells("dgclModifiedOn").Value.ToString()
                strUsageCOAID = Me.dgvIPRApproval.SelectedRows(0).Cells("gvUsageCOAID").Value.ToString()
                strUsageCOACode = Me.dgvIPRApproval.SelectedRows(0).Cells("gvUsageCOACode").Value.ToString()
                strUsageCOADescp = Me.dgvIPRApproval.SelectedRows(0).Cells("gvUsageCOADescp").Value.ToString()
                strMRCNo = dgvIPRApproval.SelectedRows(0).Cells("MRCNo").Value
            End With
            Dim form As InternalPurchaseRequisitionFrm
            form = New InternalPurchaseRequisitionFrm()
            form.BindIPRMast_inApproval(strSTIPRID, strSTIPRNo, strSTIPRDate, strClassification, strRequiredfor, strRequiredDate, strD, strDeliveredto, strCategory, strCategoryCode, strStatus, strMakeModel, strEngine, strChassisSerialNo, strFixedAssetNo, strModifiedOn, strRemarks, strUsageCOAID, strUsageCOACode, strUsageCOADescp, strMRCNo)
            form.BindIPRDet_inApproval(strSTIPRID)
            form.cmbStatus.Focus()
            form.hasLoadVisibility = True
            form.lblTotalValue.Text = String.Empty
            form.lblUnitPriceValue.Text = String.Empty
            form.VisibilityLastPurchasenTotalPrice(True)
            'Visibility = True
            form.ShowDialog()
            'InternalPurchaseRequisitionFrm.VisibilityLastPurchasenTotalPriceTrue()

        'InternalPurchaseRequisitionFrm.StartPosition = FormStartPosition.CenterScreen
        BindIPRDetails()
        End If
    End Sub

    Private _visibility As Boolean = False
    Public Property Visibility() As Boolean
        Get
            Return _visibility
        End Get
        Set(value As Boolean)
            _visibility = value
        End Set
    End Property

    Private Sub btnviewCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewCategory.Click

        NonStockIPRFrm.StrFrmName = "IPR"
        Dim StockCategory As New CategoryLookup()
        StockCategory.BindStockCategory()

        Dim result As DialogResult = CategoryLookup.ShowDialog()
        If CategoryLookup.DialogResult = Windows.Forms.DialogResult.OK Then
            lStockCategory = CategoryLookup._lStockCategoryCode
            txtviewCategory.Text = lStockCategory
            'lStockCategoryID = CategoryLookup._lStockCategoryID
        End If
    End Sub

    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        'Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InternalPurchaseRequisitionApprovalFrm))
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
            lblNoRecordFound.Text = rm.GetString("lblNoRecordFound.Text")
            btnSearch.Text = rm.GetString("btnSearch.Text")
         

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

   
    Private Sub chkIPRdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIPRdate.CheckedChanged

        If chkIPRdate.Checked = True Then
            dtpviewIPRDate.Enabled = True
        Else
            dtpviewIPRDate.Enabled = False
        End If

    End Sub

End Class