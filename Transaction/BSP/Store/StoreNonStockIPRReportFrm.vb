Imports Store_PPT
Imports Store_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class StoreNonStockIPRReportFrm

    Public strSTIPRID As String = String.Empty
    Public lStockCategory As String = String.Empty
    Public Shared strSTIPRNo As String = String.Empty
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

    Private Sub StoreNonStockIPRReportFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        dtpviewIPRDate.Format = DateTimePickerFormat.Custom
        dtpviewIPRDate.CustomFormat = "dd/MM/yyyy"
        BindIPRDetails()
        ' SetUICulture(GlobalPPT.strLang)

    End Sub
    Sub SetUICulture(ByVal culture As String)

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(StoreNonStockIPRReportFrm))
        Try

            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            btnSearch.Text = rm.GetString("btnSearch.Text")
            btnClose.Text = rm.GetString("btnClose.Text")

        Catch

            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub BindIPRDetails()

        dgvIPRApproval.DataSource = Nothing
        Dim objNonStockIPRApprovalPPT As New NonStockIPRApprovalPPT
        Dim objNonStockIPRApprovalBOL As New NonStockIPRApprovalBOL
        Dim dt As New DataTable

        With objNonStockIPRApprovalPPT
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
            .MainStatus = "MANAGER APPROVED"
        End With

        dt = objNonStockIPRApprovalBOL.NonStockIPRApprovalGet(objNonStockIPRApprovalPPT)

        If dt.Rows.Count <> 0 Then
            dgvIPRApproval.AutoGenerateColumns = False
            dgvIPRApproval.DataSource = dt
            Exit Sub
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        BindIPRDetails()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

    Private Sub StoreNonStockIPRReportFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub dgvIPRApproval_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIPRApproval.CellContentClick
       
        Dim objIPRPPT As New IPRPPT
        Dim objIPRBOL As New IPRBOL
        Dim dt As New DataTable
        If e.ColumnIndex = 17 Then

            With objIPRPPT

                strSTIPRNo = dgvIPRApproval.SelectedRows(0).Cells("dgclIPRNo").Value.ToString()
                strUsageCOAID = Me.dgvIPRApproval.SelectedRows(0).Cells("gvUsageCOAID").Value.ToString()
                strUsageCOACode = Me.dgvIPRApproval.SelectedRows(0).Cells("gvUsageCOACode").Value.ToString()
                StoreNonStockIPRReportView.Show()
            End With

        End If
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

    Private Sub chkIPRdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIPRdate.CheckedChanged

        If chkIPRdate.Checked = True Then
            dtpviewIPRDate.Enabled = True
        Else
            dtpviewIPRDate.Enabled = False
        End If

    End Sub

End Class