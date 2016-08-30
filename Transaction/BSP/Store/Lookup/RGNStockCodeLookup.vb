Imports Store_PPT
Imports Store_BOL
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class RGNStockCodeLookup

    Public psRGNStockCode As String = String.Empty
    Public psRGNStockIdValue As String = String.Empty
    Public psRGNStockDesc As String = String.Empty
    Public psRGNStockUnit As String = String.Empty
    Public psRGNStockPartNo As String = String.Empty
    Public psRGNStockIssuedQty As Integer
    Public psRGNStockIssuedValue As Integer
    Public psRGNSTIssueDetailsIDValue As String = String.Empty
    Public psRGNSTIssueIdValue As String = String.Empty
    Public psRGNStockCOAIDValue As String = String.Empty
    Public psRGNSIVCOAIDValue As String = String.Empty
    Public psRGNSIVCOACODEValue As String = String.Empty
    Public psRGNSIVCOADESCPValue As String = String.Empty
    Public psRGNVarianceCOAIDValue As String = String.Empty
    '
    Public psRGNT0Value As String = String.Empty
    Public psRGNT1Value As String = String.Empty
    Public psRGNT2Value As String = String.Empty
    Public psRGNT3Value As String = String.Empty
    Public psRGNT4Value As String = String.Empty
    Public psRGNStationValue As String = String.Empty
    Public psRGNBlockValue As String = String.Empty
    Public psRGNYOPValue As String = String.Empty
    Public psRGNDivValue As String = String.Empty
    Public psRGNVHNoValue As String = String.Empty
    Public psRGNVHDetailCostCodeValue As String = String.Empty
    Public psRGNODOReadingValue As Integer
    Public psRGNT0Id As String = String.Empty
    Public psRGNT1Id As String = String.Empty
    Public psRGNT2Id As String = String.Empty
    Public psRGNT3Id As String = String.Empty
    Public psRGNT4Id As String = String.Empty
    Public psRGNStationId As String = String.Empty
    Public psRGNBlockId As String = String.Empty
    Public psRGNYOPId As String = String.Empty
    Public psRGNDivId As String = String.Empty
    Public psRGNVHNoId As String = String.Empty
    Public psRGNVHDetailCostCodeId As String = String.Empty
    '

    Private Sub RGNStockCodeLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSIVSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSIVSearch.Click

        BindGrid(psRGNSTIssueIdValue)

    End Sub

    Public Sub BindGrid(ByVal psRGNSTIssueID)

        Dim objRGNPPt As New ReturnGoodsNotePPT
        Dim ds As New DataSet
        psRGNSTIssueIdValue = psRGNSTIssueID
        objRGNPPt.STIssueID = psRGNSTIssueIdValue
        objRGNPPt.StockCode = txtStockCodeSearch.Text
        objRGNPPt.StockDesc = txtStockDescSearch.Text
        objRGNPPt.PartNo = txtPartNoSearch.Text
        ds = ReturnGoodsNoteBOL.RGNStockDetailsGet(objRGNPPt)
        If Not ds Is Nothing Then
            If ds.Tables(0).Rows.Count > 0 Then
                dgStockCode.Visible = True
                lblNoRecord.Visible = False
                dgStockCode.AutoGenerateColumns = False
                dgStockCode.DataSource = ds.Tables(0)
            Else
                dgStockCode.AutoGenerateColumns = False
                dgStockCode.DataSource = ds.Tables(0)
                lblNoRecord.Visible = True
            End If
        End If

    End Sub

    Private Sub dgStockCode_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgStockCode.CellDoubleClick

        Grid_Click()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        ClearAfterSearch()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ClearAfterSearch()

        txtStockCodeSearch.Text = String.Empty
        txtStockDescSearch.Text = String.Empty

    End Sub

    Private Sub RGNStockCodeLookup_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Grid_Click()

        If dgStockCode.RowCount <> 0 Then

            Dim objSiv As New ReturnGoodsNotePPT
            psRGNStockCode = dgStockCode.CurrentRow.Cells("StockCode").Value.ToString()
            psRGNStockIdValue = dgStockCode.CurrentRow.Cells("StockId").Value.ToString()

            If Not dgStockCode.CurrentRow.Cells("StockDesc").Value Is DBNull.Value Then
                psRGNStockDesc = dgStockCode.CurrentRow.Cells("StockDesc").Value.ToString()
            Else
                psRGNStockDesc = String.Empty
            End If
            If Not dgStockCode.CurrentRow.Cells("Unit").Value Is DBNull.Value Then
                psRGNStockUnit = dgStockCode.CurrentRow.Cells("Unit").Value.ToString()
            Else
                psRGNStockUnit = String.Empty
            End If
            If Not dgStockCode.CurrentRow.Cells("PartNo").Value Is DBNull.Value Then
                psRGNStockPartNo = dgStockCode.CurrentRow.Cells("PartNo").Value.ToString()
            Else
                psRGNStockPartNo = String.Empty
            End If
            If Not dgStockCode.CurrentRow.Cells("IssuedQty").Value Is DBNull.Value Then
                psRGNStockIssuedQty = dgStockCode.CurrentRow.Cells("IssuedQty").Value
            Else
                psRGNStockIssuedQty = 0
            End If

            If Not dgStockCode.CurrentRow.Cells("IssuedValue").Value Is DBNull.Value Then
                psRGNStockIssuedValue = dgStockCode.CurrentRow.Cells("IssuedValue").Value.ToString()
            Else
                psRGNStockIssuedValue = 0
            End If
            If Not dgStockCode.CurrentRow.Cells("STIssueDetailsID").Value Is DBNull.Value Then
                psRGNSTIssueDetailsIDValue = dgStockCode.CurrentRow.Cells("STIssueDetailsID").Value.ToString()
            Else
                psRGNSTIssueDetailsIDValue = String.Empty
            End If
            If Not dgStockCode.CurrentRow.Cells("STIssueId").Value Is DBNull.Value Then
                psRGNSTIssueIdValue = dgStockCode.CurrentRow.Cells("STIssueId").Value.ToString()
            Else
                psRGNSTIssueIdValue = String.Empty
            End If
            If Not dgStockCode.CurrentRow.Cells("StockCOAID").Value Is DBNull.Value Then
                psRGNStockCOAIDValue = dgStockCode.CurrentRow.Cells("StockCOAID").Value.ToString()
            Else
                psRGNStockCOAIDValue = String.Empty
            End If
            If Not dgStockCode.CurrentRow.Cells("SIVCOAID").Value Is DBNull.Value Then
                psRGNSIVCOAIDValue = dgStockCode.CurrentRow.Cells("SIVCOAID").Value.ToString()
            Else
                psRGNSIVCOAIDValue = String.Empty
            End If
            If Not dgStockCode.CurrentRow.Cells("SIVCOACODE").Value Is DBNull.Value Then
                psRGNSIVCOACODEValue = dgStockCode.CurrentRow.Cells("SIVCOACODE").Value.ToString()
            Else
                psRGNSIVCOACODEValue = String.Empty
            End If
            If Not dgStockCode.CurrentRow.Cells("SIVCOADESCP").Value Is DBNull.Value Then
                psRGNSIVCOADESCPValue = dgStockCode.CurrentRow.Cells("SIVCOADESCP").Value.ToString()
            Else
                psRGNSIVCOADESCPValue = String.Empty
            End If
            If Not dgStockCode.CurrentRow.Cells("VarianceCOAID").Value Is DBNull.Value Then
                psRGNVarianceCOAIDValue = dgStockCode.CurrentRow.Cells("VarianceCOAID").Value.ToString()
            Else
                psRGNVarianceCOAIDValue = String.Empty
            End If
            '

            If Not (dgStockCode.CurrentRow.Cells("T0").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("T0").Value Is Nothing) Then
                psRGNT0Value = dgStockCode.CurrentRow.Cells("T0").Value.ToString()
                psRGNT0Id = dgStockCode.CurrentRow.Cells("T0Id").Value.ToString()
            Else
                psRGNT0Value = String.Empty
                psRGNT0Id = String.Empty
            End If

            If Not (dgStockCode.CurrentRow.Cells("T1").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("T1").Value Is Nothing) Then
                psRGNT1Value = dgStockCode.CurrentRow.Cells("T1").Value.ToString()
                psRGNT1Id = dgStockCode.CurrentRow.Cells("T1Id").Value.ToString()
            Else
                psRGNT1Value = String.Empty
                psRGNT1Id = String.Empty
            End If

            If Not (dgStockCode.CurrentRow.Cells("T2").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("T2").Value Is Nothing) Then
                psRGNT2Value = dgStockCode.CurrentRow.Cells("T2").Value.ToString()
                psRGNT2Id = dgStockCode.CurrentRow.Cells("T2Id").Value.ToString()
            Else
                psRGNT2Value = String.Empty
                psRGNT2Id = String.Empty
            End If

            If Not (dgStockCode.CurrentRow.Cells("T3").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("T3").Value Is Nothing) Then
                psRGNT3Value = dgStockCode.CurrentRow.Cells("T3").Value.ToString()
                psRGNT3Id = dgStockCode.CurrentRow.Cells("T3Id").Value.ToString()
            Else
                psRGNT3Value = String.Empty
                psRGNT3Id = String.Empty
            End If

            If Not (dgStockCode.CurrentRow.Cells("T4").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("T4").Value Is Nothing) Then
                psRGNT4Value = dgStockCode.CurrentRow.Cells("T4").Value.ToString()
                psRGNT4Id = dgStockCode.CurrentRow.Cells("T4Id").Value.ToString()
            Else
                psRGNT4Value = String.Empty
                psRGNT4Id = String.Empty
            End If

            If Not (dgStockCode.CurrentRow.Cells("Station").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("Station").Value Is Nothing) Then
                psRGNStationValue = dgStockCode.CurrentRow.Cells("Station").Value.ToString()
                psRGNStationId = dgStockCode.CurrentRow.Cells("StationId").Value.ToString()
            Else
                psRGNStationValue = String.Empty
                psRGNStationId = String.Empty
            End If

            If Not (dgStockCode.CurrentRow.Cells("Block").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("Block").Value Is Nothing) Then
                psRGNBlockValue = dgStockCode.CurrentRow.Cells("Block").Value.ToString()
                psRGNBlockId = dgStockCode.CurrentRow.Cells("BlockId").Value.ToString()
            Else
                psRGNBlockValue = String.Empty
                psRGNBlockId = String.Empty
            End If

            If Not (dgStockCode.CurrentRow.Cells("Div").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("Div").Value Is Nothing) Then
                psRGNDivValue = dgStockCode.CurrentRow.Cells("Div").Value.ToString()
                psRGNDivId = dgStockCode.CurrentRow.Cells("DivId").Value.ToString()
            Else
                psRGNDivValue = String.Empty
                psRGNDivId = String.Empty
            End If

            If Not (dgStockCode.CurrentRow.Cells("YOP").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("YOP").Value Is Nothing) Then
                psRGNYOPValue = dgStockCode.CurrentRow.Cells("YOP").Value.ToString()
                psRGNYOPId = dgStockCode.CurrentRow.Cells("YOPId").Value.ToString()
            Else
                psRGNYOPValue = String.Empty
                psRGNYOPId = String.Empty
            End If

            If Not (dgStockCode.CurrentRow.Cells("VHNo").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("VHNo").Value Is Nothing) Then
                psRGNVHNoValue = dgStockCode.CurrentRow.Cells("VHNo").Value.ToString()
                psRGNVHNoId = dgStockCode.CurrentRow.Cells("VHId").Value.ToString()
            Else
                psRGNVHNoValue = String.Empty
                psRGNVHNoId = String.Empty
            End If

            If Not (dgStockCode.CurrentRow.Cells("VHDetailCostCode").Value Is DBNull.Value Or dgStockCode.CurrentRow.Cells("VHDetailCostCode").Value Is Nothing) Then
                psRGNVHDetailCostCodeValue = dgStockCode.CurrentRow.Cells("VHDetailCostCode").Value.ToString()
                psRGNVHDetailCostCodeId = dgStockCode.CurrentRow.Cells("VHDetailCostCodeId").Value.ToString()
            Else
                psRGNVHDetailCostCodeValue = String.Empty
                psRGNVHDetailCostCodeId = String.Empty
            End If

            If Not dgStockCode.CurrentRow.Cells("ODOReading").Value Is DBNull.Value Then
                psRGNODOReadingValue = dgStockCode.CurrentRow.Cells("ODOReading").Value
            Else
                psRGNODOReadingValue = 0
            End If

            '
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else

            DisplayInfoMessage("msg01")
            ''MessageBox.Show("There is no record to select")

        End If

    End Sub

    Private Sub dgStockCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgStockCode.KeyDown

        If e.KeyCode = Keys.Return Then
            Grid_Click()
        End If
        e.Handled = True

        If e.KeyValue = 40 Then
            GlobalBOL.KeyDownEvent(dgStockCode, e)
        End If
        'If e.KeyValue = 38 Then
        '    GlobalBOL.KeyDownEvent(dgStockCode, e)
        'End If
    End Sub

    Private Sub dgStockCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgStockCode.KeyUp

        If e.KeyValue = 38 Then
            GlobalBOL.KeyUpEvent(dgStockCode, e)
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RGNStockCodeLookup))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
End Class