Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class VHMasterSubBlockLookup
    Public psBlockId As String = String.Empty
    Public psBlockName As String = String.Empty
    Public psYop As String = String.Empty
    Public psYopID As String = String.Empty
    Public psYopName As String = String.Empty
    Public psDIV As String = String.Empty
    Public psDIVID As String = String.Empty
    Public psDIVName As String = String.Empty
    Public psPlantedHect As String = String.Empty
    Public psBlockStatus As String = String.Empty
    Public psCropID As String = String.Empty
    Public psCropIDValue As String = String.Empty
    Public oilPalmOnly As Boolean = False
    Public cropID As String = String.Empty

    Private Sub SubBlockLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetUICulture(GlobalPPT.strLang)
        Dim dscrop As New DataSet
        If cropID <> String.Empty Then
            dscrop = StoreIssueVoucherBOL.GetCropID(cropID)
            psCropIDValue = dscrop.Tables(0).Rows(0).Item(2).ToString()
        End If    
        Dim objSubBlock As New StoreIssueVoucherPPT
        'objSubBlock.BlockStatus = GlobalPPT.psAcctExpenditureType
        objSubBlock.CropID = psCropIDValue
        Dim ds As New DataSet
        ds = StoreIssueVoucherBOL.GetSubBlock(objSubBlock, "NO")
        If ds.Tables(0).Rows.Count > 0 Then
            dgSubBlock.AutoGenerateColumns = False
            dgSubBlock.DataSource = ds.Tables(0)
        End If
        'Dim dscrop As New DataSet
        'dscrop = StoreIssueVoucherBOL.GetCropID(cropID)
        'psCropIDValue = dscrop.Tables(0).Rows(0).Item(1).ToString()
    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VHMasterSubBlockLookup))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            lblsearchSubBlock.Text = rm.GetString("lblsearchSubBlock.Text")
            panSubBlockLookUp.CaptionText = rm.GetString("panSubBlockLookUp.CaptionText")
            lblDivSearch.Text = rm.GetString("lblDivSearch.Text")
            lblYOPSearch.Text = rm.GetString("lblYOPSearch.Text")
            lblBlockName.Text = rm.GetString("lblBlockName.Text")

            dgSubBlock.Columns("dgclBlockName").HeaderText = rm.GetString("dgSubBlock.Columns(dgclBlockName).HeaderText")
            dgSubBlock.Columns("dgclDivName").HeaderText = rm.GetString("dgSubBlock.Columns(dgclDivName).HeaderText")
            dgSubBlock.Columns("dgclYOP").HeaderText = rm.GetString("dgSubBlock.Columns(dgclYOP).HeaderText")
            dgSubBlock.Columns("dgclBlockStatus").HeaderText = rm.GetString("dgSubBlock.Columns(dgclBlockStatus).HeaderText")
            dgSubBlock.Columns("dgclPlantedHect").HeaderText = rm.GetString("dgSubBlock.Columns(dgclPlantedHect).HeaderText")

        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSubBlockSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubBlockSearch.Click
        Dim objBlockPPt As New StoreIssueVoucherPPT
        Dim ds As New DataSet
        dgSubBlock.DataSource = Nothing
        objBlockPPt.Div = txtDivSearch.Text.Trim()
        objBlockPPt.YOP = txtYOPSearch.Text.Trim()
        objBlockPPt.BlockName = txtBlockNameSearch.Text.Trim()
        ' objBlockPPt.BlockStatus = GlobalPPT.psAcctExpenditureType
        If (StoreIssueVoucherBOL.GetSubBlock(objBlockPPt, "NO").Tables(0).Rows.Count <= 0) Then
            lblNoRecord.Visible = True
            dgSubBlock.Visible = False
            'dgSubBlock.DataSource = Nothing

        Else
            ds = StoreIssueVoucherBOL.GetSubBlock(objBlockPPt, "NO")
            dgSubBlock.Visible = True
            lblNoRecord.Visible = False
            dgSubBlock.AutoGenerateColumns = False
            dgSubBlock.DataSource = ds.Tables(0)

        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgSubBlock_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSubBlock.CellDoubleClick
        If dgSubBlock.RowCount <> 0 Then
            Dim objYOP As New StoreIssueVoucherPPT
            psBlockId = dgSubBlock.CurrentRow.Cells("dgclBlockID").Value.ToString()
            If dgSubBlock.CurrentRow.Cells("dgclBlockName").Value.ToString() <> String.Empty Then
                psBlockName = dgSubBlock.CurrentRow.Cells("dgclBlockName").Value.ToString()
            End If
            psDIVID = dgSubBlock.CurrentRow.Cells("dgclDivID").Value.ToString()
            If dgSubBlock.CurrentRow.Cells("dgclDiv").Value.ToString() <> String.Empty Then
                psDIV = dgSubBlock.CurrentRow.Cells("dgclDiv").Value.ToString()
            End If
            If dgSubBlock.CurrentRow.Cells("dgclDivName").Value.ToString() <> String.Empty Then
                psDIVName = dgSubBlock.CurrentRow.Cells("dgclDivName").Value.ToString()
            End If
            psYopID = dgSubBlock.CurrentRow.Cells("dgclYOPID").Value.ToString()
            If dgSubBlock.CurrentRow.Cells("dgclYOP").Value.ToString() <> String.Empty Then
                psYop = dgSubBlock.CurrentRow.Cells("dgclYOP").Value.ToString()
            End If
            If dgSubBlock.CurrentRow.Cells("dgclName").Value.ToString() <> String.Empty Then
                psYopName = dgSubBlock.CurrentRow.Cells("dgclName").Value.ToString()
            End If
            If dgSubBlock.CurrentRow.Cells("dgclPlantedHect").Value.ToString() <> String.Empty Then
                psPlantedHect = dgSubBlock.CurrentRow.Cells("dgclPlantedHect").Value.ToString()
            End If
            If dgSubBlock.CurrentRow.Cells("dgclBlockStatus").Value.ToString() <> String.Empty Then
                psBlockStatus = dgSubBlock.CurrentRow.Cells("dgclBlockStatus").Value.ToString()
            End If
            If (dgSubBlock.CurrentRow.Cells("dgcCropID").Value <> Nothing) Then
                If dgSubBlock.CurrentRow.Cells("dgcCropID").Value.ToString() <> String.Empty Then
                    psCropID = dgSubBlock.CurrentRow.Cells("dgcCropID").Value.ToString()
                End If
            End If
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("There is no record to select")
        End If
    End Sub
End Class