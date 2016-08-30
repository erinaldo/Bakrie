Imports WeighBridge_BOL
Public Class WBAverageBunchWeight

    Dim dtABW As DataTable
    Dim dtHistoricalABW As DataTable

    Private Sub WBAverageBunchWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tcABW.Controls.Remove(tbMissing)
        dtpMonth.Value = Now()
    End Sub

    Sub ViewABW()
        Dim objWBAverageBunchWeightBOL As New WBAverageBunchWeightBOL()
        dtHistoricalABW = objWBAverageBunchWeightBOL.WBAverageBunchWeightSelect(dtpMonth.Value.Year, dtpMonth.Value.Month)
        tcABW.Controls.Remove(tbMissing)
        If dtHistoricalABW.Rows.Count > 0 Then
            dgwABW.DataSource = dtHistoricalABW.DefaultView
            ' get unique suppliers
            Dim dtSuppliers As DataTable = dtHistoricalABW.DefaultView.ToTable(True, "Supplier")
            cmbHABWSupplier.DataSource = dtSuppliers
            cmbHABWSupplier.DisplayMember = "Supplier"
            cmbHABWSupplier.ValueMember = "Supplier"
            cmbHABWSupplier.Enabled = True
        Else
            dgwABW.DataSource = Nothing
            dgwABW.Rows.Clear()
            cmbHABWSupplier.Enabled = False
            cmbHABWBlock.Enabled = False
            btnABWFilter.Enabled = False
        End If

    End Sub

    Private Sub btnProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProc.Click
        Cursor = Cursors.WaitCursor
        btnProc.Enabled = False

        Cursor = Cursors.WaitCursor
        tcABW.SelectedTab = tbCurrent ' activate Current month tab
        tcABW.Controls.Remove(tbMissing) ' remove Missing blocks tab

        Dim objWBAverageBunchWeightBOL As New WBAverageBunchWeightBOL()
        Dim dtResult As DataTable = objWBAverageBunchWeightBOL.WBAverageBunchWeightProcess(NumericUpDownMonths.Value)

        If dtResult.Rows.Count = 0 Then
            MessageBox.Show("Average Bunch Weight Processed", "Processing Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            tcABW.Controls.Add(tbMissing)
            tcABW.SelectedTab = tbMissing ' activate Missing blocks tab
            dgwMissing.DataSource = dtResult.DefaultView
        End If

        btnProc.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Cursor = Cursors.WaitCursor
        tcABW.SelectedTab = tbCurrent ' activate Current month tab
        tcABW.Controls.Remove(tbMissing) ' disable Missing blocks tab

        btnCalculate.Enabled = False
        btnProc.Enabled = False
        cmbSupplier.Enabled = False
        cmbBlock.Enabled = False
        btnFilter.Enabled = False
        lblSingleBlock.Text = "0"
        lblTotalDeliveries.Text = "0"

        Dim objWBAverageBunchWeightBOL As New WBAverageBunchWeightBOL()
        Dim ds As DataSet = objWBAverageBunchWeightBOL.WBAverageBunchWeightCalculate(NumericUpDownMonths.Value)

        If ds.Tables(0).Rows.Count > 0 Then
            ' if there are blocks which don't have ABW for previous month cannot proceed the calculation
            tcABW.Controls.Add(tbMissing)
            tcABW.SelectedTab = tbMissing ' activate Missing blocks tab
            dgwMissing.DataSource = ds.Tables(0).DefaultView
        Else
            dtABW = ds.Tables(2)
            dgvABW.DataSource = dtABW.DefaultView

            If ds.Tables(1).Rows.Count > 0 Then
                lblSingleBlock.Text = ds.Tables(1).Rows(0)("SingleBlockDeliveries").ToString()
                lblTotalDeliveries.Text = ds.Tables(1).Rows(0)("TotalDeliveries").ToString()
            End If

            btnProc.Enabled = True
            cmbSupplier.Enabled = True

            ' get unique estates
            Dim dtEstates As DataTable = dtABW.DefaultView.ToTable(True, "Supplier")
            cmbSupplier.DataSource = dtEstates
            cmbSupplier.DisplayMember = "Supplier"
            cmbSupplier.ValueMember = "Supplier"
        End If



        btnCalculate.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub cmbEstate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSupplier.SelectedIndexChanged
        dtABW.DefaultView.RowFilter = "Supplier = '" & cmbSupplier.Text & "'"
        Dim dtBlock As DataTable = dtABW.DefaultView.ToTable(True, "Block")
        cmbBlock.DataSource = dtBlock
        cmbBlock.DisplayMember = "Block"
        cmbBlock.ValueMember = "Block"

        cmbBlock.Enabled = True
        btnFilter.Enabled = True
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        dtABW.DefaultView.RowFilter = "Supplier = '" & cmbSupplier.Text & "' AND Block = '" + cmbBlock.Text + "'"
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dtpMonth_ValueChanged(sender As Object, e As EventArgs) Handles dtpMonth.ValueChanged
        ViewABW()
    End Sub

    Private Sub cmbHABWSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHABWSupplier.SelectedIndexChanged
        dtHistoricalABW.DefaultView.RowFilter = "Supplier = '" & cmbHABWSupplier.Text & "'"
        Dim dtBlock As DataTable = dtHistoricalABW.DefaultView.ToTable(True, "Block")
        cmbHABWBlock.DataSource = dtBlock
        cmbHABWBlock.DisplayMember = "Block"
        cmbHABWBlock.ValueMember = "Block"

        cmbHABWBlock.Enabled = True
        btnABWFilter.Enabled = True
    End Sub

    Private Sub btnABWFilter_Click(sender As Object, e As EventArgs) Handles btnABWFilter.Click
        dtHistoricalABW.DefaultView.RowFilter = "Supplier = '" & cmbHABWSupplier.Text & "' AND Block = '" + cmbHABWBlock.Text + "'"
    End Sub
End Class