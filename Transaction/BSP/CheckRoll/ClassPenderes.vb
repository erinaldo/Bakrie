Imports CheckRoll_BOL
Imports CheckRoll_DAL
Imports CheckRoll_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Threading

Public Class ClassPenderes
    Private currentYear as Int16
    Private currentMonth as Int16
    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        If ValidateControl() Then
            Try
                currentYear=lstAyear.SelectedValue
                currentMonth=lstAMonth.SelectedIndex + 1
                ProgressUpdate.Visible=True
                ProgressUpdate.Value = 0
                btnSaveAll.Enabled = False
                LblLoading.Visible = True
                Dim list As List(Of ClassPenderesDetailPPT)
                list = New List(Of ClassPenderesDetailPPT)()
                For Each gridDetail In dgvGradeDetail.Rows
                    Dim objDetailPPT As New ClassPenderesDetailPPT
                    With objDetailPPT
                        '.GradeMonthId = IdGrade
                        .EmpId = gridDetail.Cells("dgvEmpId").value.ToString()
                        .Classes = gridDetail.Cells("dgvClass").value.ToString()
                    End With
                    list.Add(objDetailPPT)
                    '                    objBOL.ClassPenderesDetailInsert(objDetailPPT) 'Save Detail Prosses
                Next
                Dim objs As List(Of Object)
                objs = New List(Of Object)()
                Dim objPPT As New ClassPenderesPPT
                With objPPT
                    .ZYear = lstAyear.SelectedValue
                    .ZMonth = lstAMonth.SelectedIndex + 1
                    .TotalBudget = txtTotalBudget.Text
                End With
                objs.Add(objPPT)
                objs.Add(list)
                ThreadPool.QueueUserWorkItem(AddressOf SaveClassPenderes, objs)

            Catch ex As Exception
                btnSaveAll.Enabled = True
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub
    Private Delegate Sub SetMaximumProgressbarDelegate(value As Int16)
    Private Sub SetMaximumProgressbar(value As Int16)
        If (InvokeRequired) Then
            MyBase.BeginInvoke(New SetMaximumProgressbarDelegate(AddressOf Me.SetMaximumProgressbar), value)
            Exit Sub
        End If
        ProgressUpdate.Maximum = value
    End Sub
    Private Delegate Sub SetUpdateProgressbarDelegate()
    Private Sub SetUpdateProgressbar()
        If (InvokeRequired) Then
            MyBase.BeginInvoke(New SetUpdateProgressbarDelegate(AddressOf Me.SetUpdateProgressbar))
            Exit Sub
        End If
        LblLoading.Text = "PLEASE WAIT " + ProgressUpdate.Value.ToString() +" Of "+ProgressUpdate.Maximum.ToString()
        ProgressUpdate.Value = ProgressUpdate.Value + 1
    End Sub
    Private Delegate Sub ComplateDelegate()
    Private Function ComplateDelegateSub()

        If (InvokeRequired) Then
            MyBase.BeginInvoke(New ComplateDelegate(AddressOf Me.ComplateDelegateSub))
            Exit Function
        End If
        MessageBox.Show("Data successfull saved !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LblLoading.Visible = False
        btnSaveAll.Enabled = True
        ProgressUpdate.Visible=false
        ClearAll()
        OnLoadForm()
    End Function
    
    Private Sub SaveClassPenderes(state As Object)
        Dim objs = DirectCast(state, List(Of Object))
        Dim objBOL As New ClassPenderesBOL
        Dim dtIdGrade As DataTable
        dtIdGrade = objBOL.ClassPenderesInsert(DirectCast(objs.ToArray()(0), ClassPenderesPPT)) 'Save Master Prosses
        Dim IdGrade As String
        Dim list As List(Of ClassPenderesDetailPPT)
        list = DirectCast(objs.ToArray()(1), List(Of ClassPenderesDetailPPT))
        IdGrade = dtIdGrade.Rows(0).Item("ID").ToString()
        Dim result = objBOL.SelectAllDataRubber(New DateTime(currentYear, currentMonth, 1)).Rows
        SetMaximumProgressbar(result.Count)
        For Each o As System.Data.DataRow In result
            objBOL.UpdateDailyReceptionForRubber(o.Item(9).ToString(), New DateTime(currentYear, currentMonth, 1), o.Item(1).ToString(), o.Item(10).ToString(), o.Item(2).ToString(), o.Item(2).ToString(), CDbl(o.Item(3).ToString()), CDbl(o.Item(4).ToString()), CDbl(o.Item(5).ToString()), CDbl(o.Item(6).ToString()), CDbl(o.Item(7).ToString()), CDbl(o.Item(8).ToString()))
            SetUpdateProgressbar()
        Next
        objBOL.ClassPenderesDetailsDelete(Convert.ToInt64(IdGrade))
        For Each gridDetail In list
            gridDetail.GradeMonthId = IdGrade
            objBOL.ClassPenderesDetailInsert(gridDetail) 'Save Detail Prosses
        Next
        ComplateDelegateSub()
    End Sub
    Private Sub ClearAll()
        txtTotalBudget.Clear()
        dgvGradeDetail.Rows.Clear()
        TxtTotalLatex.Clear()
        TxtCupLump.Clear()
        TxtGrandTotal.Clear()
        TxtTreeLace.Clear()
    End Sub

    Private Function ValidateControl() As Boolean
        If lstAyear.SelectedValue Is Nothing Then
            MessageBox.Show("Please select Year!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If lstAMonth.SelectedIndex.ToString() Is Nothing Then
            MessageBox.Show("Please select Month!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If txtTotalBudget.Text = String.Empty Then
            MessageBox.Show("Please fill Total Budget!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If dgvGradeDetail.RowCount = 0 Then
            MessageBox.Show("Please generate employee!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub ClassPenderes_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim dtblYears As New DataTable
        Dim obj As New EstateBOL
        Dim intAYear As Integer
        Dim intAMonth As Integer
        intAYear = CType(Today.Year, Integer)
        intAMonth = CType(Today.Month, Integer)
        dtblYears = obj.GetActiveYears(GlobalPPT.strEstateID, GlobalPPT.strEstateCode, intAYear, intAMonth, GlobalPPT.strUserName, GlobalPPT.strUserName)

        With lstAyear
            .DataSource = dtblYears
            .DisplayMember = "AYear"
            .ValueMember = "AYear"
        End With

        With listYear
            .DataSource = dtblYears
            .DisplayMember = "AYear"
            .ValueMember = "AYear"
        End With

        OnLoadForm()
    End Sub

    Private Sub GetActiveYearMonth(ByVal strEstateId As String, ByVal ModID As Integer)

        Dim obj As New EstateBOL
        Dim dsActive As New DataSet
        Dim intCount As Integer
        Dim drvListItem As DataRowView

        dsActive = obj.GetActiveYearMonth(strEstateId, ModID)

        If dsActive.Tables(0).Rows.Count > 0 Then

            Dim strYear As String = dsActive.Tables(0).Rows(0).Item(0).ToString
            intCount = 0

            For Each drvListItem In lstAyear.Items
                If strYear = drvListItem.Item(0).ToString Then
                    Exit For
                End If
                intCount = intCount + 1
            Next

            Dim intAMonth As Integer = CType(dsActive.Tables(0).Rows(0).Item(1).ToString, Integer)
            lstAMonth.SelectedIndex = intAMonth - 1
            listMonth.SelectedIndex = intAMonth - 1

            Dim intActiveYear As Integer
            intActiveYear = CType(dsActive.Tables(0).Rows(0).Item(0).ToString, Integer)
            lstAyear.Text = intActiveYear
            listYear.Text = intActiveYear
        End If
    End Sub

    Private Sub OnLoadForm()
        Dim dtGradeMonth As New DataTable
        dtGradeMonth = ClassPenderesDAL.ClassPenderesMonthSelectAll(Nothing, Nothing)
        If dtGradeMonth.Rows.Count > 0 Then
            dgvClassPenderesView.DataSource = dtGradeMonth
        Else
            dgvClassPenderesView.Rows.Clear()
        End If
        tcAdvancePayment.SelectedTab = tabView
        GetActiveYearMonth(GlobalPPT.strEstateID, 6)

    End Sub

    Private Sub BtnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles BtnGenerate.Click
        Dim dtGradeMonth As New DataTable
        dtGradeMonth = ClassPenderesDAL.ClassPenderesMonthSelectAll(lstAMonth.SelectedIndex + 1, lstAyear.SelectedValue)
        'If dtGradeMonth.Rows.Count > 0 Then
        If dtGradeMonth.Rows.Count > 0 Then
            MessageBox.Show("Data already exists!", "Warning", MessageBoxButtons.OK)
        Else
            Dim month() As String = lstAMonth.SelectedItem.ToString().Split("-")
            Dim dt As New DataTable
            Dim dateRubber As String
            If lstAMonth.SelectedIndex < 9 Then
                dateRubber = lstAyear.Text & "-0" & lstAMonth.SelectedIndex + 1
            Else
                dateRubber = lstAyear.Text & "-" & lstAMonth.SelectedIndex + 1
            End If
            dt = ClassPenderesDAL.ClassPenderesEmployeeSelect(dateRubber)
            If dt.Rows.Count > 0 Then
                dgvGradeDetail.Rows.Clear()
                For Each rowsEmp In dt.Rows
                    dgvGradeDetail.Rows.Add(lstAyear.SelectedValue, month(1), rowsEmp("GangName").ToString(), rowsEmp("EmpName").ToString(), rowsEmp("EmpId").ToString(), rowsEmp("EmpCode").ToString(), "A", rowsEmp("Latex").ToString(), rowsEmp("CupLump").ToString(), rowsEmp("TreeLace").ToString())
                Next
            Else
                dgvGradeDetail.Rows.Clear()
                MessageBox.Show("No Employee Penderes Record Found!", "Warning", MessageBoxButtons.OK)
            End If

            CalculatedSum()

        End If
    End Sub

    Private Sub CalculatedSum()
        Dim totalLatex As Double = 0
        Dim totalCupLump As Double = 0
        Dim totalTreeLace As Double = 0
        Dim grandTotal As Double = 0
        For i As Integer = 0 To dgvGradeDetail.RowCount - 1
            If Not String.IsNullOrEmpty(dgvGradeDetail.Rows(i).Cells("dgcLatex").Value) Then
                totalLatex += dgvGradeDetail.Rows(i).Cells("dgcLatex").Value
            End If
            If Not String.IsNullOrEmpty(dgvGradeDetail.Rows(i).Cells("dgcCupLump").Value) Then
                totalCupLump += dgvGradeDetail.Rows(i).Cells("dgcCupLump").Value
            End If
            If Not String.IsNullOrEmpty(dgvGradeDetail.Rows(i).Cells("dgcTreeLace").Value) Then
                totalTreeLace += dgvGradeDetail.Rows(i).Cells("dgcTreeLace").Value
            End If
        Next
        TxtTotalLatex.Text = totalLatex
        TxtCupLump.Text = totalCupLump
        TxtTreeLace.Text = totalTreeLace
        grandTotal = totalLatex + totalCupLump + totalTreeLace
        TxtGrandTotal.Text = grandTotal
    End Sub

    Private Sub dgvClassPenderesView_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvClassPenderesView.MouseDoubleClick
        Dim GradMonthId As String
        Dim DateRubber As String
        If dgvClassPenderesView.SelectedRows(0).Cells("dgvZMonth").Value < 10 Then
            DateRubber = dgvClassPenderesView.SelectedRows(0).Cells("dgvZYear").Value & "-0" & dgvClassPenderesView.SelectedRows(0).Cells("dgvZMonth").Value
        Else
            DateRubber = dgvClassPenderesView.SelectedRows(0).Cells("dgvZYear").Value & "-" & dgvClassPenderesView.SelectedRows(0).Cells("dgvZMonth").Value
        End If
        GradMonthId = dgvClassPenderesView.SelectedRows(0).Cells("dgvId").Value.ToString()
        Dim dtGradeMonthDetail As New DataTable
        dtGradeMonthDetail = ClassPenderesDAL.ClassPenderesMonthDetailSelect(GradMonthId, DateRubber)
        If dtGradeMonthDetail.Rows.Count > 0 Then
            dgvGradeDetail.Rows.Clear()
            txtTotalBudget.Text = dtGradeMonthDetail.Rows(0).Item("TotalBudget").ToString()
            lstAyear.SelectedValue = dtGradeMonthDetail.Rows(0).Item("ZYear").ToString()
            lstAMonth.SelectedIndex = (dtGradeMonthDetail.Rows(0).Item("ZMonth")) - 1

            Dim convertMonth() As String = lstAMonth.SelectedItem.ToString().Split("-")
            For Each rowsEmp In dtGradeMonthDetail.Rows
                dgvGradeDetail.Rows.Add(rowsEmp("ZYear").ToString(), convertMonth(1), rowsEmp("GangName").ToString(), rowsEmp("EmpName").ToString(), rowsEmp("EmpId").ToString(), rowsEmp("EmpCode").ToString(), rowsEmp("Class").ToString(), rowsEmp("Latex").ToString(), rowsEmp("CupLump").ToString(), rowsEmp("TreeLace").ToString())
            Next
        Else
            dgvGradeDetail.Rows.Clear()
        End If

        Dim obj As New EstateBOL
        Dim dsActive As New DataSet
        Dim intCount As Integer
        Dim drvListItem As DataRowView

        dsActive = obj.GetActiveYearMonth(GlobalPPT.strEstateID, 6)
        If dsActive.Tables(0).Rows.Count > 0 Then
            Dim strYear As String = dsActive.Tables(0).Rows(0).Item(0).ToString
            intCount = 0
            For Each drvListItem In lstAyear.Items
                If strYear = drvListItem.Item(0).ToString Then
                    Exit For
                End If
                intCount = intCount + 1
            Next
            Dim intAMonth As Integer = CType(dsActive.Tables(0).Rows(0).Item(1).ToString, Integer)
            Dim intActiveYear As Integer
            intActiveYear = CType(dsActive.Tables(0).Rows(0).Item(0).ToString, Integer)
            If dgvClassPenderesView.SelectedRows(0).Cells("dgvZMonth").Value <> intAMonth And dgvClassPenderesView.SelectedRows(0).Cells("dgvZYear").Value <> intActiveYear Then
                dgvGradeDetail.ReadOnly = True
                btnSaveAll.Enabled = False
                BtnGenerate.Enabled = False
            Else
                dgvGradeDetail.ReadOnly = False
                btnSaveAll.Enabled = True
                BtnGenerate.Enabled = True
            End If
        End If
        CalculatedSum()
        tcAdvancePayment.SelectedTab = tabEntry
    End Sub

    Private Sub BtnReset_Click(sender As System.Object, e As System.EventArgs) Handles BtnReset.Click
        ClearAll()
        dgvGradeDetail.Enabled = True
        btnSaveAll.Enabled = True
        BtnGenerate.Enabled = True
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnSearchView_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchView.Click
        Dim dtGradeMonth As New DataTable
        dtGradeMonth = ClassPenderesDAL.ClassPenderesMonthSelectAll(listMonth.SelectedIndex + 1, listYear.SelectedValue)
        'If dtGradeMonth.Rows.Count > 0 Then
        dgvClassPenderesView.DataSource = dtGradeMonth
        'Else
        'dgvClassPenderesView.Rows.Clear()
        'End If
    End Sub
End Class