Imports Production_PPT
Imports Production_BOL
Imports Common_PPT
Imports Common_BOL
Imports System.Data.SqlClient
Imports System.Math

Public Class LaboratoryAnalysisFrm
    Public lLabAnalysisID As String = String.Empty
    Public lBtnSaveAll As String = "Save All"
    Dim isModifierKey As Boolean
    Dim is2Decimal As Boolean
    Dim re2DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Dim is3Decimal As Boolean
    Dim re3DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")

    Public lStationIDOilLosses As String = String.Empty
    Private lbtnAddOilLosses As String = "Add"
    Dim dtOilLosses As New DataTable("todgOilLosses")
    Dim columnOilLosses As DataColumn
    Dim rowOilLosses As DataRow
    Private lLabOilLossesID As String = String.Empty
    Private lEqptOilLosses As String = String.Empty

    Public lStationIDKernelLosses As String = String.Empty
    Private lbtnAddKernelLosses As String = "Add"
    Dim dtKernelLosses As New DataTable("todgKernelLosses")
    Dim columnKernelLosses As DataColumn
    Dim rowKernelLosses As DataRow
    Private lLabKernelLossesID As String = String.Empty
    Private lEqptKernelLosses As String = String.Empty
    Shadows mdiparent As New MDIParent


    Private lbtnAddKernelLossesPCF As String = "Add"
    Dim dtKernelLossesPCF As New DataTable("todgKernelLossesPCF")
    Dim columnKernelLossesPCF As DataColumn
    Dim rowKernelLossesPCF As DataRow
    Private lLabKernelLossesPCFID As String = String.Empty
    Dim lKLCPFLine As String = String.Empty
    ' Private lKLPCFno As String = String.Empty


    Private lbtnAddOilLossesA As String = "Add"
    Dim dtOilLossesA As New DataTable("todgOilLossesA")
    Dim columnOilLossesA As DataColumn
    Dim rowOilLossesA As DataRow
    Private lLabOilLossesAID As String = String.Empty
    Private lEqptOilLossesA As String = String.Empty

    Private lbtnAddOilLossesB As String = "Add"
    Dim dtOilLossesB As New DataTable("todgOilLossesB")
    Dim columnOilLossesB As DataColumn
    Dim rowOilLossesB As DataRow
    Private lLabOilLossesBID As String = String.Empty
    Private lDescriptionOLB As String = String.Empty

    Private lbtnAddKernelLossesFFB As String = "Add"
    Dim dtKernelLossesFFB As New DataTable("todgKernelLossesFFB")
    Dim columnKernelLossesFFB As DataColumn
    Dim rowKernelLossesFFB As DataRow
    Private lLabKernelLossesFFBID As String = String.Empty
    Private lLineKernelLossesFFB As String = String.Empty
    Dim lKernelPCFStationID As String = String.Empty


    Private lbtnAddKernelInTake As String = "Add"
    Dim dtKernelInTake As New DataTable("todgKernelInTake")
    Dim columnKernelInTake As DataColumn
    Dim rowKernelInTake As DataRow
    Private lLabKernelInTakeID As String = String.Empty
    Private lLocationKernelInTake As String = String.Empty

    Private lbtnAddEffRippleMill As String = "Add"
    Dim dtEffRippleMill As New DataTable("todgEffRippleMill")
    Dim columnEffRippleMill As DataColumn
    Dim rowEffRippleMill As DataRow
    Private lLabEffRippleMillID As String = String.Empty
    Private lLineEffRippleMill As String = String.Empty
    Private lNoEffRippleMill As String = String.Empty

    Private lbtnAddKernelQtyStorage As String = "Add"
    Dim dtKernelQtyStorage As New DataTable("todgKernelQtyStorage")
    Dim columnKernelQtyStorage As DataColumn
    Dim rowKernelQtyStorage As DataRow
    Private lLabKernelQtyStorageID As String = String.Empty
    Private lLocationKernelQtyStorage As String = String.Empty

    Private lbtnAddOilQtyStorage As String = "Add"
    Dim dtOilQtyStorage As New DataTable("todgOilQtyStorage")
    Dim columnOilQtyStorage As DataColumn
    Dim rowOilQtyStorage As DataRow
    Private lLabOilQtyStorageID As String = String.Empty
    Private lLabOilQtydstorageTankID As String = String.Empty
    Private lProductTypeOilQualityStorage As String = String.Empty

    Private lbtnAddMachineryOperation As String = "Add"
    Dim dtMachineryOperation As New DataTable("todgMachineryOperation")
    Dim columnMachineryOperation As DataColumn
    Dim rowMachineryOperation As DataRow
    Private lMachineryOperationID As String = String.Empty
    Private lMachineName As String = String.Empty
    Dim lmonthValuehrs As String = "00:00"
    Dim lYearValue As String = "00:00"
    Private MonthCount As Integer
    Private YearCount As Integer
    Dim lPrevHrs As String = "00:00"


    Private lbtnAddBWA As String = "Add"
    Dim dtBWA As New DataTable("todgBWA ")
    Dim columnBWA As DataColumn
    Dim rowBWA As DataRow
    Private llabBoilerWaterAnalysisID As String = String.Empty
    Private lBWADescp As String = String.Empty


    Private lbtnAddSoftner As String = "Add"
    Dim dtSoftner As New DataTable("todgSoftner ")
    Dim columnSoftner As DataColumn
    Dim rowSoftner As DataRow
    Private lLabSoftnerID As String = String.Empty
    Private lSoftnerDescp As String = String.Empty
    Private DecimalCheck As Boolean = False
    Dim PKOLFFAPMTDCalc As Decimal = 0
    Dim PKOLFFAPYTDCalc As Decimal = 0
    Dim CPOLFFAPMTDCalc As Decimal = 0
    Dim CPOLFFAPYTDCalc As Decimal = 0
    Dim dsMachineName As New DataTable
    Dim FFAPMonthCount As Integer
    Dim lFFACPOPrev As Decimal = 0
    Dim lFFAPKOPrev As Decimal = 0
    Dim TotalCPOFFAPCOUNTMonth As Integer
    Dim TotalCPOFFAPCOUNTYear As Integer

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LaboratoryAnalysisFrm))




    Private Sub btnOLAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOLAdd.Click
        If IsOilLossesValidAdd() Then Exit Sub
        If lbtnAddOilLosses <> "Update" Then
            AddMultipleEntryDataOilLosses()

        Else
            UpDateMultipleEntryDataOiLosses()
        End If
    End Sub
    Private Function IsOilLossesValidAdd()
        If ddlEquitOilLosses.Text = "--Select--" Then
            DisplayInfoMessage("Msg1")
            ''MessageBox.Show("This field is required.", "Equipment/Station")
            ddlEquitOilLosses.Focus()
            Return True
        End If
        If ddlTypeOilLosses.Text = "--Select--" Then
            DisplayInfoMessage("Msg2")
            '' MessageBox.Show("This field is required.", "Type")
            ddlTypeOilLosses.Focus()
            Return True
        End If
        If ddlNoOilLosses.Text = "--Select--" Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("This field is required.", "Number")
            ddlNoOilLosses.Focus()
            Return True
        End If
        If Val(txtActualpercent.Text) = 0 Then
            DisplayInfoMessage("Msg4")
            '' MessageBox.Show("This field is required.", "Actual(%)")
            txtActualpercent.Focus()
            Return True
        End If
        If ddlLineOilLosses.Text = "--Select--" Then
            DisplayInfoMessage("Msg5")
            '' MessageBox.Show("This field is required.", "Line")
            ddlLineOilLosses.Focus()
            Return True
        End If
        If Val(txtStdPercent.Text) = 0 Then
            DisplayInfoMessage("Msg6")
            ''MessageBox.Show("This field is required.", "STD(%)")
            txtStdPercent.Focus()
            Return True
        End If
        Return False
    End Function
    Private Function StationExistInOilLosses(ByVal Station As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvOilLosses.Rows
                If Station = objDataGridViewRow.Cells("dgclStationID").Value.ToString() Then
                    ddlEquitOilLosses.SelectedIndex = 0
                    ddlEquitOilLosses.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataOilLosses()


        Dim intRowcount As Integer = dtOilLosses.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not StationExistInOilLosses(ddlEquitOilLosses.SelectedValue.ToString) Then
                rowOilLosses = dtOilLosses.NewRow()
                If intRowcount = 0 And lbtnAddOilLosses = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnOilLosses = New DataColumn("LabOilLossesID", System.Type.[GetType]("System.String"))
                        dtOilLosses.Columns.Add(columnOilLosses)
                        columnOilLosses = New DataColumn("StationID", System.Type.[GetType]("System.String"))
                        dtOilLosses.Columns.Add(columnOilLosses)
                        columnOilLosses = New DataColumn("StationDescp", System.Type.[GetType]("System.String"))
                        dtOilLosses.Columns.Add(columnOilLosses)
                        columnOilLosses = New DataColumn("No", System.Type.[GetType]("System.String"))
                        dtOilLosses.Columns.Add(columnOilLosses)
                        columnOilLosses = New DataColumn("Line", System.Type.[GetType]("System.String"))
                        dtOilLosses.Columns.Add(columnOilLosses)
                        columnOilLosses = New DataColumn("Type", System.Type.[GetType]("System.String"))
                        dtOilLosses.Columns.Add(columnOilLosses)
                        columnOilLosses = New DataColumn("ActualP", System.Type.[GetType]("System.String"))
                        dtOilLosses.Columns.Add(columnOilLosses)
                        columnOilLosses = New DataColumn("STD", System.Type.[GetType]("System.String"))
                        dtOilLosses.Columns.Add(columnOilLosses)

                    Catch ex As Exception
                    End Try

                    If lLabOilLossesID <> String.Empty Then
                        rowOilLosses("LabOilLossesID") = lLabOilLossesID
                    End If

                    rowOilLosses("StationID") = ddlEquitOilLosses.SelectedValue .ToString 
                    rowOilLosses("StationDescp") = ddlEquitOilLosses.Text
                    rowOilLosses("No") = ddlNoOilLosses.Text
                    rowOilLosses("Line") = ddlLineOilLosses.Text
                    rowOilLosses("Type") = ddlTypeOilLosses.Text
                    rowOilLosses("ActualP") = txtActualpercent.Text
                    rowOilLosses("STD") = txtStdPercent.Text


                    dtOilLosses.Rows.InsertAt(rowOilLosses, intRowcount)
                    dgvOilLosses.AutoGenerateColumns = False
                Else

                    If lLabOilLossesID <> String.Empty Then
                        rowOilLosses("LabOilLossesID") = lLabOilLossesID
                    End If

                    rowOilLosses("StationID") = ddlEquitOilLosses.SelectedValue.ToString
                    rowOilLosses("StationDescp") = ddlEquitOilLosses.Text
                    rowOilLosses("No") = ddlNoOilLosses.Text
                    rowOilLosses("Line") = ddlLineOilLosses.Text
                    rowOilLosses("Type") = ddlTypeOilLosses.Text
                    rowOilLosses("ActualP") = txtActualpercent.Text
                    rowOilLosses("STD") = txtStdPercent.Text


                    dtOilLosses.Rows.InsertAt(rowOilLosses, intRowcount)
                    dgvOilLosses.AutoGenerateColumns = False

                End If

                dgvOilLosses.DataSource = dtOilLosses
                ClearOilLosses()
                ddlEquitOilLosses.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg7")
                ''MsgBox("Equipment /Station  already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataOiLosses()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If lStationIDOilLosses = ddlEquitOilLosses.SelectedValue.ToString Then
                Dim intCount As Integer = dgvOilLosses.CurrentRow.Index

                dgvOilLosses.Rows(intCount).Cells("dgclLabOilLossesID").Value = lLabOilLossesID
                dgvOilLosses.Rows(intCount).Cells("dgclStationID").Value = ddlEquitOilLosses.SelectedValue.ToString
                dgvOilLosses.Rows(intCount).Cells("dgclStationDescp").Value = ddlEquitOilLosses.Text
                dgvOilLosses.Rows(intCount).Cells("dgclNo").Value = ddlNoOilLosses.Text
                dgvOilLosses.Rows(intCount).Cells("dgclLine").Value = ddlLineOilLosses.Text
                dgvOilLosses.Rows(intCount).Cells("dgclType").Value = ddlTypeOilLosses.Text
                dgvOilLosses.Rows(intCount).Cells("dgclActualP").Value = txtActualpercent.Text
                dgvOilLosses.Rows(intCount).Cells("dgclSTD").Value = txtStdPercent.Text

                ClearOilLosses()
                ddlEquitOilLosses.SelectedIndex = 0
            ElseIf Not StationExistInOilLosses(ddlEquitOilLosses.SelectedValue.ToString) Then
                Dim intCount As Integer = dgvOilLosses.CurrentRow.Index

                dgvOilLosses.Rows(intCount).Cells("dgclLabOilLossesID").Value = lLabOilLossesID
                dgvOilLosses.Rows(intCount).Cells("dgclStationID").Value = ddlEquitOilLosses.SelectedValue.ToString
                dgvOilLosses.Rows(intCount).Cells("dgclStationDescp").Value = ddlEquitOilLosses.Text
                dgvOilLosses.Rows(intCount).Cells("dgclNo").Value = ddlNoOilLosses.Text
                dgvOilLosses.Rows(intCount).Cells("dgclLine").Value = ddlLineOilLosses.Text
                dgvOilLosses.Rows(intCount).Cells("dgclType").Value = ddlTypeOilLosses.Text
                dgvOilLosses.Rows(intCount).Cells("dgclActualP").Value = txtActualpercent.Text
                dgvOilLosses.Rows(intCount).Cells("dgclSTD").Value = txtStdPercent.Text

                ClearOilLosses()
                ddlEquitOilLosses.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg7")
                ''MsgBox("Equipment/Station already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesOilLosses()

        If dgvOilLosses.RowCount > 0 Then

            ClearOilLosses()

            If GlobalPPT.strLang = "en" Then
                btnOLAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnOLAdd.Text = "Memperbarui"
            End If
            ''btnOLAdd.Text = "Update"
            lbtnAddOilLosses = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvOilLosses.SelectedRows(0).Cells("dgclLabOilLossesID").Value IsNot Nothing Or dgvOilLosses.SelectedRows(0).Cells("dgclLabOilLossesID").Value.ToString <> String.Empty Then
                    Me.lLabOilLossesID = dgvOilLosses.SelectedRows(0).Cells("dgclLabOilLossesID").Value.ToString
                End If
            End If

            lStationIDOilLosses = Me.dgvOilLosses.SelectedRows(0).Cells("dgclStationID").Value.ToString
            ddlEquitOilLosses.Text = Me.dgvOilLosses.SelectedRows(0).Cells("dgclStationDescp").Value.ToString
            ddlNoOilLosses.Text = Me.dgvOilLosses.SelectedRows(0).Cells("dgclNo").Value.ToString
            ddlLineOilLosses.Text = Me.dgvOilLosses.SelectedRows(0).Cells("dgclLine").Value.ToString
            ddlTypeOilLosses.Text = Me.dgvOilLosses.SelectedRows(0).Cells("dgclType").Value.ToString
            txtActualpercent.Text = Me.dgvOilLosses.SelectedRows(0).Cells("dgclActualP").Value.ToString
            txtStdPercent.Text = Me.dgvOilLosses.SelectedRows(0).Cells("dgclSTD").Value.ToString

        End If

    End Sub

    Private Sub ClearOilLosses()
        'ddlEquitOilLosses.SelectedIndex = 0
        ddlNoOilLosses.SelectedIndex = 0
        ddlLineOilLosses.SelectedIndex = 0
        ddlTypeOilLosses.SelectedIndex = 0
        txtActualpercent.Text = String.Empty
        txtStdPercent.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnOLAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnOLAdd.Text = "Menambahkan"
        End If
        ''btnOLAdd.Text = "Add"
        lbtnAddOilLosses = "Add"
        lEqptOilLosses = ""
        lLabOilLossesID = ""
    End Sub
    '''Kernel Losses


    Private Function IsKernelLossesValidAdd()
        If ddlEqptKernelLosses.Text = "--Select--" Then
            DisplayInfoMessage("Msg1")
            ''MessageBox.Show("This field is required.", "Equipment/Station")
            ddlEqptKernelLosses.Focus()
            Return True
        End If
        If Val(txtKLEfficiency.Text) = 0 Then
            DisplayInfoMessage("Msg8")
            ''MessageBox.Show("This field is required.", "Efficiency")
            txtKLEfficiency.Focus()
            Return True
        End If
        If ddlLineKernelLosses.Text = "--Select--" Then
            DisplayInfoMessage("Msg5")
            ''MessageBox.Show("This field is required.", "Line")
            ddlLineKernelLosses.Focus()
            Return True
        End If
        If Val(txtKLLossesprecent.Text) = 0 Then
            DisplayInfoMessage("Msg9")
            ''MessageBox.Show("This field is required.", "Losses(%)")
            txtKLLossesprecent.Focus()
            Return True
        End If
        If ddlNoKernelLosses.Text = "--Select--" Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("This field is required.", "Number")
            ddlNoKernelLosses.Focus()
            Return True
        End If
        If Val(txtKLDirtpercent.Text) = 0 Then
            DisplayInfoMessage("Msg10")
            ''MessageBox.Show("This field is required.", "Dirt(%)")
            txtKLDirtpercent.Focus()
            Return True
        End If
        Return False
    End Function
    Private Function StationExistInKernelLosses(ByVal Station As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvKernelLosses.Rows
                If Station = objDataGridViewRow.Cells("dgKLStationID").Value.ToString() Then
                    ddlEqptKernelLosses.SelectedIndex = 0
                    ddlEqptKernelLosses.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataKernelLosses()


        Dim intRowcount As Integer = dtKernelLosses.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not StationExistInKernelLosses(ddlEqptKernelLosses.SelectedValue.ToString) Then
                rowKernelLosses = dtKernelLosses.NewRow()
                If intRowcount = 0 And lbtnAddKernelLosses = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnKernelLosses = New DataColumn("LabKernelLossesID", System.Type.[GetType]("System.String"))
                        dtKernelLosses.Columns.Add(columnKernelLosses)
                        columnKernelLosses = New DataColumn("StationID", System.Type.[GetType]("System.String"))
                        dtKernelLosses.Columns.Add(columnKernelLosses)
                        columnKernelLosses = New DataColumn("StationDescp", System.Type.[GetType]("System.String"))
                        dtKernelLosses.Columns.Add(columnKernelLosses)
                        columnKernelLosses = New DataColumn("No", System.Type.[GetType]("System.String"))
                        dtKernelLosses.Columns.Add(columnKernelLosses)
                        columnKernelLosses = New DataColumn("Line", System.Type.[GetType]("System.String"))
                        dtKernelLosses.Columns.Add(columnKernelLosses)
                        columnKernelLosses = New DataColumn("EfficiencyP", System.Type.[GetType]("System.String"))
                        dtKernelLosses.Columns.Add(columnKernelLosses)
                        columnKernelLosses = New DataColumn("LossesP", System.Type.[GetType]("System.String"))
                        dtKernelLosses.Columns.Add(columnKernelLosses)
                        columnKernelLosses = New DataColumn("DirtP", System.Type.[GetType]("System.String"))
                        dtKernelLosses.Columns.Add(columnKernelLosses)

                    Catch ex As Exception
                    End Try

                    If lLabKernelLossesID <> String.Empty Then
                        rowKernelLosses("LabKernelLossesID") = lLabKernelLossesID
                    End If
                    rowKernelLosses("StationID") = ddlEqptKernelLosses.SelectedValue.ToString
                    rowKernelLosses("StationDescp") = ddlEqptKernelLosses.Text
                    rowKernelLosses("No") = ddlNoKernelLosses.Text
                    rowKernelLosses("Line") = ddlLineKernelLosses.Text
                    rowKernelLosses("EfficiencyP") = txtKLEfficiency.Text
                    rowKernelLosses("LossesP") = txtKLLossesprecent.Text
                    rowKernelLosses("DirtP") = txtKLDirtpercent.Text

                    dtKernelLosses.Rows.InsertAt(rowKernelLosses, intRowcount)
                    dgvKernelLosses.AutoGenerateColumns = False

                Else

                    If lLabKernelLossesID <> String.Empty Then
                        rowKernelLosses("LabKernelLossesID") = lLabKernelLossesID
                    End If


                    rowKernelLosses("StationID") = ddlEqptKernelLosses.SelectedValue.ToString
                    rowKernelLosses("StationDescp") = ddlEqptKernelLosses.Text
                    rowKernelLosses("No") = ddlNoKernelLosses.Text
                    rowKernelLosses("Line") = ddlLineKernelLosses.Text
                    rowKernelLosses("EfficiencyP") = txtKLEfficiency.Text
                    rowKernelLosses("LossesP") = txtKLLossesprecent.Text
                    rowKernelLosses("DirtP") = txtKLDirtpercent.Text


                    dtKernelLosses.Rows.InsertAt(rowKernelLosses, intRowcount)
                    dgvKernelLosses.AutoGenerateColumns = False

                End If
                dgvKernelLosses.DataSource = dtKernelLosses
                ClearKernelLosses()
                ddlEqptKernelLosses.SelectedIndex = 0
            Else

                DisplayInfoMessage("Msg7")
                ''MsgBox("Equipment /Station  already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataKernelosses()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If lStationIDKernelLosses = ddlEqptKernelLosses.SelectedValue.ToString Then
                Dim intCount As Integer = dgvKernelLosses.CurrentRow.Index

                dgvKernelLosses.Rows(intCount).Cells("dgLabKernelLossesID").Value = lLabKernelLossesID
                dgvKernelLosses.Rows(intCount).Cells("dgKLStationID").Value = ddlEqptKernelLosses.SelectedValue.ToString
                dgvKernelLosses.Rows(intCount).Cells("dgKLStationDescp").Value = ddlEqptKernelLosses.Text
                dgvKernelLosses.Rows(intCount).Cells("dgKLNo").Value = ddlNoKernelLosses.Text
                dgvKernelLosses.Rows(intCount).Cells("dgKLLine").Value = ddlLineKernelLosses.Text
                dgvKernelLosses.Rows(intCount).Cells("dgKLEfficiencyP").Value = txtKLEfficiency.Text
                dgvKernelLosses.Rows(intCount).Cells("dgKLLossesP").Value = txtKLLossesprecent.Text
                dgvKernelLosses.Rows(intCount).Cells("dgKLDirtP").Value = txtKLDirtpercent.Text


                ClearKernelLosses()
                ddlEqptKernelLosses.SelectedIndex = 0
            ElseIf Not StationExistInKernelLosses(ddlEqptKernelLosses.SelectedValue.ToString) Then
                Dim intCount As Integer = dgvKernelLosses.CurrentRow.Index

                dgvKernelLosses.Rows(intCount).Cells("dgLabKernelLossesID").Value = lLabKernelLossesID
                dgvKernelLosses.Rows(intCount).Cells("dgKLStationID").Value = ddlEqptKernelLosses.SelectedValue.ToString
                dgvKernelLosses.Rows(intCount).Cells("dgKLStationDescp").Value = ddlEqptKernelLosses.Text
                dgvKernelLosses.Rows(intCount).Cells("dgKLNo").Value = ddlNoKernelLosses.Text
                dgvKernelLosses.Rows(intCount).Cells("dgKLLine").Value = ddlLineKernelLosses.Text
                dgvKernelLosses.Rows(intCount).Cells("dgKLEfficiencyP").Value = txtKLEfficiency.Text
                dgvKernelLosses.Rows(intCount).Cells("dgKLLossesP").Value = txtKLLossesprecent.Text
                dgvKernelLosses.Rows(intCount).Cells("dgKLDirtP").Value = txtKLDirtpercent.Text

                ClearKernelLosses()
                ddlEqptKernelLosses.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg7")
                ''MsgBox("Equipment/Station already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesKernelLosses()

        If dgvKernelLosses.RowCount > 0 Then

            ClearKernelLosses()
            If GlobalPPT.strLang = "en" Then
                btnKLAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnKLAdd.Text = "Memperbarui"
            End If

            ''btnKLAdd.Text = "Update"
            lbtnAddKernelLosses = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvKernelLosses.SelectedRows(0).Cells("dgLabKernelLossesID").Value IsNot Nothing Or dgvKernelLosses.SelectedRows(0).Cells("dgLabKernelLossesID").Value.ToString <> String.Empty Then
                    Me.lLabKernelLossesID = dgvKernelLosses.SelectedRows(0).Cells("dgLabKernelLossesID").Value.ToString
                End If
            End If

            lStationIDKernelLosses = Me.dgvKernelLosses.SelectedRows(0).Cells("dgKLStationID").Value.ToString
            ddlEqptKernelLosses.Text = Me.dgvKernelLosses.SelectedRows(0).Cells("dgKLStationDescp").Value.ToString
            ddlNoKernelLosses.Text = Me.dgvKernelLosses.SelectedRows(0).Cells("dgKLNo").Value.ToString
            ddlLineKernelLosses.Text = Me.dgvKernelLosses.SelectedRows(0).Cells("dgKLLine").Value.ToString
            txtKLEfficiency.Text = Me.dgvKernelLosses.SelectedRows(0).Cells("dgKLEfficiencyP").Value.ToString
            txtKLLossesprecent.Text = Me.dgvKernelLosses.SelectedRows(0).Cells("dgKLLossesP").Value.ToString
            txtKLDirtpercent.Text = Me.dgvKernelLosses.SelectedRows(0).Cells("dgKLDirtP").Value.ToString

        End If

    End Sub

    Private Sub ClearKernelLosses()
        ddlEqptKernelLosses.SelectedIndex = 0
        ddlLineKernelLosses.SelectedIndex = 0
        ddlNoKernelLosses.SelectedIndex = 0
        txtKLEfficiency.Text = String.Empty
        txtKLLossesprecent.Text = String.Empty
        txtKLDirtpercent.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnKLAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnKLAdd.Text = "Menambahkan"
        End If

        ''btnKLAdd.Text = "Add"
        lbtnAddKernelLosses = "Add"
        lEqptKernelLosses = ""
        lLabKernelLossesID = ""
    End Sub

    ''KernelLossesPCF
    Private Function IsKernelLossesPCFValidAdd()
        If ddlLineKernelLossesPCF.Text = "--Select--" Then
            DisplayInfoMessage("Msg5")
            ''MessageBox.Show("This field is required.", "Line")
            ddlLineKernelLossesPCF.Focus()
            Return True
        End If
        If Val(txtKLPCSamplepercent.Text) = 0 Then
            DisplayInfoMessage("Msg11")
            ''MessageBox.Show("This field is required.", "Sample(%)")
            txtKLPCSamplepercent.Focus()
            Return True
        End If
        If ddlNoKernelLossesPCF.Text = "--Select--" Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("This field is required.", "Number")
            ddlNoKernelLossesPCF.Focus()
            Return True
        End If
        If Val(txtKLPCFibrepercent.Text) = 0 Then
            DisplayInfoMessage("Msg12")
            ''MessageBox.Show("This field is required.", "Fibre(%)")
            txtKLPCFibrepercent.Focus()
            Return True
        End If
        If Val(txtKLPCTotalNutPercent.Text) = 0 Then
            DisplayInfoMessage("Msg13")
            ''MessageBox.Show("This field is required.", "Total Nut")
            txtKLPCTotalNutPercent.Focus()
            Return True
        End If
        Return False
    End Function
    Private Function LineKernelLossesPCF(ByVal Line As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvKernelLossesPCF.Rows
                If Line = objDataGridViewRow.Cells("dgKLPCFLine").Value.ToString() Then
                    ddlLineKernelLossesPCF.SelectedIndex = 0
                    ddlLineKernelLossesPCF.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataKernelLossesPCF()


        Dim intRowcount As Integer = dtKernelLossesPCF.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not LineKernelLossesPCF(ddlLineKernelLossesPCF.Text) Then
                rowKernelLossesPCF = dtKernelLossesPCF.NewRow()
                If intRowcount = 0 And lbtnAddKernelLossesPCF = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnKernelLossesPCF = New DataColumn("LabKernelLossesPCFID", System.Type.[GetType]("System.String"))
                        dtKernelLossesPCF.Columns.Add(columnKernelLossesPCF)
                        columnKernelLossesPCF = New DataColumn("No", System.Type.[GetType]("System.String"))
                        dtKernelLossesPCF.Columns.Add(columnKernelLossesPCF)
                        columnKernelLossesPCF = New DataColumn("Line", System.Type.[GetType]("System.String"))
                        dtKernelLossesPCF.Columns.Add(columnKernelLossesPCF)
                        columnKernelLossesPCF = New DataColumn("TotalNutP", System.Type.[GetType]("System.String"))
                        dtKernelLossesPCF.Columns.Add(columnKernelLossesPCF)
                        columnKernelLossesPCF = New DataColumn("SampleP", System.Type.[GetType]("System.String"))
                        dtKernelLossesPCF.Columns.Add(columnKernelLossesPCF)
                        columnKernelLossesPCF = New DataColumn("FibreP", System.Type.[GetType]("System.String"))
                        dtKernelLossesPCF.Columns.Add(columnKernelLossesPCF)


                    Catch ex As Exception
                    End Try

                    If lLabKernelLossesPCFID <> String.Empty Then
                        rowKernelLossesPCF("LabKernelLossesPCFID") = lLabKernelLossesPCFID
                    End If
                    rowKernelLossesPCF("No") = ddlNoKernelLossesPCF.Text
                    rowKernelLossesPCF("Line") = ddlLineKernelLossesPCF.Text
                    rowKernelLossesPCF("TotalNutP") = txtKLPCTotalNutPercent.Text
                    rowKernelLossesPCF("SampleP") = txtKLPCSamplepercent.Text
                    rowKernelLossesPCF("FibreP") = txtKLPCFibrepercent.Text

                    dtKernelLossesPCF.Rows.InsertAt(rowKernelLossesPCF, intRowcount)
                    dgvKernelLossesPCF.AutoGenerateColumns = False

                Else

                    If lLabKernelLossesPCFID <> String.Empty Then
                        rowKernelLossesPCF("LabKernelLossesPCFID") = lLabKernelLossesPCFID
                    End If
                    rowKernelLossesPCF("No") = ddlNoKernelLossesPCF.Text
                    rowKernelLossesPCF("Line") = ddlLineKernelLossesPCF.Text
                    rowKernelLossesPCF("TotalNutP") = txtKLPCTotalNutPercent.Text
                    rowKernelLossesPCF("SampleP") = txtKLPCSamplepercent.Text
                    rowKernelLossesPCF("FibreP") = txtKLPCFibrepercent.Text

                    dtKernelLossesPCF.Rows.InsertAt(rowKernelLossesPCF, intRowcount)
                    dgvKernelLossesPCF.AutoGenerateColumns = False

                End If
                dgvKernelLossesPCF.DataSource = dtKernelLossesPCF
                ClearKernelLossesPCF()

            Else
                DisplayInfoMessage("Msg14")
                ''MsgBox("Line already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataKernelossesPCF()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try


            If lKLCPFLine = ddlLineKernelLossesPCF.Text Then
                Dim intCount As Integer = dgvKernelLossesPCF.CurrentRow.Index

                dgvKernelLossesPCF.Rows(intCount).Cells("dgLabKernelLossesPCFID").Value = lLabKernelLossesPCFID
                dgvKernelLossesPCF.Rows(intCount).Cells("dgKLPCFNo").Value = ddlNoKernelLossesPCF.Text
                dgvKernelLossesPCF.Rows(intCount).Cells("dgKLPCFLine").Value = ddlLineKernelLossesPCF.Text
                dgvKernelLossesPCF.Rows(intCount).Cells("dgKLPCFTotalNutPercent").Value = txtKLPCTotalNutPercent.Text
                dgvKernelLossesPCF.Rows(intCount).Cells("dgKLPCFSample").Value = txtKLPCSamplepercent.Text
                dgvKernelLossesPCF.Rows(intCount).Cells("dgKLPCFFibre").Value = txtKLPCFibrepercent.Text


                ClearKernelLossesPCF()

            ElseIf Not LineKernelLossesPCF(ddlLineKernelLossesPCF.Text) Then
                Dim intCount As Integer = dgvKernelLossesPCF.CurrentRow.Index
                dgvKernelLossesPCF.Rows(intCount).Cells("dgLabKernelLossesPCFID").Value = lLabKernelLossesPCFID
                dgvKernelLossesPCF.Rows(intCount).Cells("dgKLPCFNo").Value = ddlNoKernelLossesPCF.Text
                dgvKernelLossesPCF.Rows(intCount).Cells("dgKLPCFLine").Value = ddlLineKernelLossesPCF.Text
                dgvKernelLossesPCF.Rows(intCount).Cells("dgKLPCFTotalNutPercent").Value = txtKLPCTotalNutPercent.Text
                dgvKernelLossesPCF.Rows(intCount).Cells("dgKLPCFSample").Value = txtKLPCSamplepercent.Text
                dgvKernelLossesPCF.Rows(intCount).Cells("dgKLPCFFibre").Value = txtKLPCFibrepercent.Text

                ClearKernelLossesPCF()
            Else
                DisplayInfoMessage("Msg14")
                ''MsgBox("Line already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesKernelLossesPCF()

        If dgvKernelLossesPCF.RowCount > 0 Then

            ClearKernelLossesPCF()
            If GlobalPPT.strLang = "en" Then
                btnKLPCFAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnKLPCFAdd.Text = "Memperbarui"
            End If
            ''btnKLPCFAdd.Text = "Update"
            lbtnAddKernelLossesPCF = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvKernelLossesPCF.SelectedRows(0).Cells("dgLabKernelLossesPCFID").Value IsNot Nothing Or dgvKernelLossesPCF.SelectedRows(0).Cells("dgLabKernelLossesPCFID").Value.ToString <> String.Empty Then
                    Me.lLabKernelLossesPCFID = dgvKernelLossesPCF.SelectedRows(0).Cells("dgLabKernelLossesPCFID").Value.ToString
                End If
            End If

            lKLCPFLine = Me.dgvKernelLossesPCF.SelectedRows(0).Cells("dgKLPCFLine").Value.ToString
            ddlNoKernelLossesPCF.Text = Me.dgvKernelLossesPCF.SelectedRows(0).Cells("dgKLPCFNo").Value.ToString
            ddlLineKernelLossesPCF.Text = Me.dgvKernelLossesPCF.SelectedRows(0).Cells("dgKLPCFLine").Value.ToString
            txtKLPCSamplepercent.Text = Me.dgvKernelLossesPCF.SelectedRows(0).Cells("dgKLPCFSample").Value.ToString
            txtKLPCTotalNutPercent.Text = Me.dgvKernelLossesPCF.SelectedRows(0).Cells("dgKLPCFTotalNutPercent").Value.ToString
            txtKLPCFibrepercent.Text = Me.dgvKernelLossesPCF.SelectedRows(0).Cells("dgKLPCFFibre").Value.ToString

        End If

    End Sub

    Private Sub ClearKernelLossesPCF()
        ddlLineKernelLossesPCF.SelectedIndex = 0
        ddlNoKernelLossesPCF.SelectedIndex = 0
        txtKLPCTotalNutPercent.Text = String.Empty
        txtKLPCSamplepercent.Text = String.Empty
        txtKLPCFibrepercent.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnKLPCFAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnKLPCFAdd.Text = "Menambahkan"
        End If

        ''btnKLPCFAdd.Text = "Add"
        lbtnAddKernelLossesPCF = "Add"
        lKLCPFLine = ""
        lLabKernelLossesPCFID = ""
    End Sub

    ''OilLossesA

    Private Function IsOilLossesAValidAdd()
        If ddlEqptOilLossesA.Text = "--Select--" Then
            DisplayInfoMessage("Msg1")
            ''MessageBox.Show("This field is required.", "Equipment/Station")
            ddlEqptOilLossesA.Focus()
            Return True
        End If
        If ddlTypeOilLossesA.Text = "--Select--" Then
            DisplayInfoMessage("Msg2")
            ''MessageBox.Show("This field is required.", "Type")
            ddlTypeOilLossesA.Focus()
            Return True
        End If
        If ddlNoOilLossesA.Text = "--Select--" Then
            DisplayInfoMessage("Msg3")
            ''MessageBox.Show("This field is required.", "Number")
            ddlNoOilLossesA.Focus()
            Return True
        End If
        If Val(txtOLAActualpercent.Text) = 0 Then
            DisplayInfoMessage("Msg4")
            ''MessageBox.Show("This field is required.", "Actual(%)")
            txtOLAActualpercent.Focus()
            Return True
        End If
        Return False
    End Function
    Private Function StationExistInOilLossesA(ByVal Equipment As String, ByVal TypeOil As String, ByVal NoOil As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvOilLossesA.Rows
                If Equipment = objDataGridViewRow.Cells("dgclOLAEquipment").Value.ToString() And _
                TypeOil = objDataGridViewRow.Cells("dgclOLAType").Value.ToString() And _
                NoOil = objDataGridViewRow.Cells("dgclOLANo").Value.ToString() Then
                    ddlEqptOilLossesA.SelectedIndex = 0
                    ddlEqptOilLossesA.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataOilLossesA()


        Dim intRowcount As Integer = dtOilLossesA.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not StationExistInOilLossesA(ddlEqptOilLossesA.Text, ddlTypeOilLossesA.Text, ddlNoOilLossesA.Text) Then
                rowOilLossesA = dtOilLossesA.NewRow()
                If intRowcount = 0 And lbtnAddOilLossesA = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnOilLossesA = New DataColumn("LabOilLossesAID", System.Type.[GetType]("System.String"))
                        dtOilLossesA.Columns.Add(columnOilLossesA)
                        columnOilLossesA = New DataColumn("Station", System.Type.[GetType]("System.String"))
                        dtOilLossesA.Columns.Add(columnOilLossesA)
                        columnOilLossesA = New DataColumn("No", System.Type.[GetType]("System.String"))
                        dtOilLossesA.Columns.Add(columnOilLossesA)
                        columnOilLossesA = New DataColumn("Type", System.Type.[GetType]("System.String"))
                        dtOilLossesA.Columns.Add(columnOilLossesA)
                        columnOilLossesA = New DataColumn("ActualP", System.Type.[GetType]("System.String"))
                        dtOilLossesA.Columns.Add(columnOilLossesA)



                    Catch ex As Exception
                    End Try
                    If lLabOilLossesAID <> String.Empty Then
                        rowOilLossesA("LabOilLossesAID") = lLabOilLossesAID
                    End If

                    rowOilLossesA("Station") = ddlEqptOilLossesA.Text
                    rowOilLossesA("No") = ddlNoOilLossesA.Text
                    rowOilLossesA("Type") = ddlTypeOilLossesA.Text
                    rowOilLossesA("ActualP") = txtOLAActualpercent.Text

                    dtOilLossesA.Rows.InsertAt(rowOilLossesA, intRowcount)
                    dgvOilLossesA.AutoGenerateColumns = False

                Else

                    If lLabOilLossesAID <> String.Empty Then
                        rowOilLossesA("LabOilLossesAID") = lLabOilLossesAID
                    End If

                    rowOilLossesA("Station") = ddlEqptOilLossesA.Text
                    rowOilLossesA("No") = ddlNoOilLossesA.Text
                    rowOilLossesA("Type") = ddlTypeOilLossesA.Text
                    rowOilLossesA("ActualP") = txtOLAActualpercent.Text

                    dtOilLossesA.Rows.InsertAt(rowOilLossesA, intRowcount)
                    dgvOilLossesA.AutoGenerateColumns = False

                End If
                dgvOilLossesA.DataSource = dtOilLossesA

                ClearOillossesA()

            Else
                DisplayInfoMessage("Msg15")
                ''MsgBox("Equipment  already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataOiLossesA()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try




            If lEqptOilLossesA = ddlEqptOilLossesA.Text Then
                Dim intCount As Integer = dgvOilLossesA.CurrentRow.Index

                dgvOilLossesA.Rows(intCount).Cells("dgclLabOilLossesAID").Value = lLabOilLossesAID
                dgvOilLossesA.Rows(intCount).Cells("dgclOLAEquipment").Value = ddlEqptOilLossesA.Text
                dgvOilLossesA.Rows(intCount).Cells("dgclOLANo").Value = ddlNoOilLossesA.Text
                dgvOilLossesA.Rows(intCount).Cells("dgclOLAType").Value = ddlTypeOilLossesA.Text
                dgvOilLossesA.Rows(intCount).Cells("dgclOLAActualpercent").Value = txtOLAActualpercent.Text


                ClearOillossesA()

            ElseIf Not StationExistInOilLossesA(ddlEqptOilLossesA.Text, ddlTypeOilLossesA.Text, ddlNoOilLossesA.Text) Then
                Dim intCount As Integer = dgvOilLossesA.CurrentRow.Index

                dgvOilLossesA.Rows(intCount).Cells("dgclLabOilLossesAID").Value = lLabOilLossesAID
                dgvOilLossesA.Rows(intCount).Cells("dgclOLAEquipment").Value = ddlEqptOilLossesA.Text
                dgvOilLossesA.Rows(intCount).Cells("dgclOLANo").Value = ddlNoOilLossesA.Text
                dgvOilLossesA.Rows(intCount).Cells("dgclOLAType").Value = ddlTypeOilLossesA.Text
                dgvOilLossesA.Rows(intCount).Cells("dgclOLAActualpercent").Value = txtOLAActualpercent.Text

                ClearOillossesA()
            Else
                DisplayInfoMessage("Msg15")
                ''MsgBox("Equipment already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesOilLossesA()

        If dgvOilLossesA.RowCount > 0 Then

            ClearOillossesA()
            If GlobalPPT.strLang = "en" Then
                btnOLAAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnOLAAdd.Text = "Memperbarui"
            End If

            ''btnOLAAdd.Text = "Update"
            lbtnAddOilLossesA = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvOilLossesA.SelectedRows(0).Cells("dgclLabOilLossesAID").Value IsNot Nothing Or dgvOilLossesA.SelectedRows(0).Cells("dgclLabOilLossesAID").Value.ToString <> String.Empty Then
                    Me.lLabOilLossesAID = dgvOilLossesA.SelectedRows(0).Cells("dgclLabOilLossesAID").Value.ToString
                End If
            End If

            lEqptOilLossesA = Me.dgvOilLossesA.SelectedRows(0).Cells("dgclOLAEquipment").Value.ToString
            ddlEqptOilLossesA.Text = Me.dgvOilLossesA.SelectedRows(0).Cells("dgclOLAEquipment").Value.ToString
            ddlNoOilLossesA.Text = Me.dgvOilLossesA.SelectedRows(0).Cells("dgclOLANo").Value.ToString
            ddlTypeOilLossesA.Text = Me.dgvOilLossesA.SelectedRows(0).Cells("dgclOLAType").Value.ToString
            txtOLAActualpercent.Text = Me.dgvOilLossesA.SelectedRows(0).Cells("dgclOLAActualpercent").Value.ToString


        End If

    End Sub


    Private Sub ClearOillossesA()
        ddlEqptOilLossesA.SelectedIndex = 0
        ddlNoOilLossesA.SelectedIndex = 0
        ddlTypeOilLossesA.SelectedIndex = 0
        txtOLAActualpercent.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnOLAAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnOLAAdd.Text = "Menambahkan"
        End If

        ''btnOLAAdd.Text = "Add"
        lbtnAddOilLossesA = "Add"
        lEqptOilLossesA = ""
        lLabOilLossesID = ""
    End Sub

    ''OilLossesB

    Private Function IsOilLossesBValidAdd()
        If ddlDescpOilLossesB.Text = "--Select--" Then
            DisplayInfoMessage("Msg16")
            ''MessageBox.Show("This field is required.", "Description")
            ddlDescpOilLossesB.Focus()
            Return True
        End If
        If ddlExpellaeStagetypeOilLossB.Text = "--Select--" Then
            DisplayInfoMessage("Msg17")
            ''MessageBox.Show("This field is required.", "Expeller Stage Type")
            ddlExpellaeStagetypeOilLossB.Focus()
            Return True
        End If
        If ddlExpStageNoOilLossB.Text = "--Select--" Then
            DisplayInfoMessage("Msg18")
            ''MessageBox.Show("This field is required.", "Expeller Stage No")
            ddlExpStageNoOilLossB.Focus()
            Return True
        End If
        If Val(txtOLBAmount.Text) = 0 Then
            DisplayInfoMessage("Msg19")
            ''MessageBox.Show("This field is required.", "Amount")
            txtOLBAmount.Focus()
            Return True
        End If
        Return False
    End Function
    Private Function DescriptionisExistInOilLossesB(ByVal Description As String, ByVal ExpellaeStagetypeOilLossB As String, ByVal ExpStageNoOilLossB As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvOilLossesB.Rows
                If Description = objDataGridViewRow.Cells("dgclOLBDescription").Value.ToString() and _
                    ExpellaeStagetypeOilLossB = objDataGridViewRow.Cells("dgclOLBExpellerStagetype").Value.ToString() and _
                    ExpStageNoOilLossB = objDataGridViewRow.Cells("dgclOLBExpellerStageNo").Value.ToString() Then
                    ddlDescpOilLossesB.SelectedIndex = 0
                    ddlDescpOilLossesB.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataOilLossesB()


        Dim intRowcount As Integer = dtOilLossesB.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not DescriptionisExistInOilLossesB(ddlDescpOilLossesB.Text, ddlExpellaeStagetypeOilLossB.Text, ddlExpStageNoOilLossB.Text) Then
                rowOilLossesB = dtOilLossesB.NewRow()
                If intRowcount = 0 And lbtnAddOilLossesB = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnOilLossesB = New DataColumn("LabOilLossesBID", System.Type.[GetType]("System.String"))
                        dtOilLossesB.Columns.Add(columnOilLossesB)
                        columnOilLossesB = New DataColumn("Descp", System.Type.[GetType]("System.String"))
                        dtOilLossesB.Columns.Add(columnOilLossesB)
                        columnOilLossesB = New DataColumn("ExpellerStageNumber", System.Type.[GetType]("System.String"))
                        dtOilLossesB.Columns.Add(columnOilLossesB)
                        columnOilLossesB = New DataColumn("ExpellerStageType", System.Type.[GetType]("System.String"))
                        dtOilLossesB.Columns.Add(columnOilLossesB)
                        columnOilLossesB = New DataColumn("Amount", System.Type.[GetType]("System.String"))
                        dtOilLossesB.Columns.Add(columnOilLossesB)


                    Catch ex As Exception
                    End Try

                    If lLabOilLossesBID <> String.Empty Then
                        rowOilLossesB("LabOilLossesBID") = lLabOilLossesBID
                    End If

                    rowOilLossesB("Descp") = ddlDescpOilLossesB.Text
                    rowOilLossesB("ExpellerStageNumber") = ddlExpStageNoOilLossB.Text
                    rowOilLossesB("ExpellerStageType") = ddlExpellaeStagetypeOilLossB.Text
                    rowOilLossesB("Amount") = txtOLBAmount.Text


                    dtOilLossesB.Rows.InsertAt(rowOilLossesB, intRowcount)
                    dgvOilLossesB.AutoGenerateColumns = False



                Else

                    If lLabOilLossesBID <> String.Empty Then
                        rowOilLossesB("LabOilLossesBID") = lLabOilLossesBID
                    End If

                    rowOilLossesB("Descp") = ddlDescpOilLossesB.Text
                    rowOilLossesB("ExpellerStageNumber") = ddlExpStageNoOilLossB.Text
                    rowOilLossesB("ExpellerStageType") = ddlExpellaeStagetypeOilLossB.Text
                    rowOilLossesB("Amount") = txtOLBAmount.Text

                    dtOilLossesB.Rows.InsertAt(rowOilLossesB, intRowcount)
                    dgvOilLossesB.AutoGenerateColumns = False

                End If
                dgvOilLossesB.DataSource = dtOilLossesB
                ClearOillossesB()

            Else
                DisplayInfoMessage("Msg20")
                ''MsgBox("Description already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataOiLossesB()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try


            If lDescriptionOLB = ddlDescpOilLossesB.Text Then
                Dim intCount As Integer = dgvOilLossesB.CurrentRow.Index

                dgvOilLossesB.Rows(intCount).Cells("dgclLabOilLossesBID").Value = lLabOilLossesBID
                dgvOilLossesB.Rows(intCount).Cells("dgclOLBDescription").Value = ddlDescpOilLossesB.Text
                dgvOilLossesB.Rows(intCount).Cells("dgclOLBExpellerStagetype").Value = ddlExpellaeStagetypeOilLossB.Text
                dgvOilLossesB.Rows(intCount).Cells("dgclOLBExpellerStageNo").Value = ddlExpStageNoOilLossB.Text
                dgvOilLossesB.Rows(intCount).Cells("dgclOLBAmount").Value = txtOLBAmount.Text



                ClearOillossesB()

            ElseIf Not DescriptionisExistInOilLossesB(ddlDescpOilLossesB.Text, ddlExpellaeStagetypeOilLossB.Text, ddlExpStageNoOilLossB.Text) Then
                Dim intCount As Integer = dgvOilLossesB.CurrentRow.Index

                dgvOilLossesB.Rows(intCount).Cells("dgclLabOilLossesBID").Value = lLabOilLossesBID
                dgvOilLossesB.Rows(intCount).Cells("dgclOLBDescription").Value = ddlDescpOilLossesB.Text
                dgvOilLossesB.Rows(intCount).Cells("dgclOLBExpellerStagetype").Value = ddlExpellaeStagetypeOilLossB.Text
                dgvOilLossesB.Rows(intCount).Cells("dgclOLBExpellerStageNo").Value = ddlExpStageNoOilLossB.Text
                dgvOilLossesB.Rows(intCount).Cells("dgclOLBAmount").Value = txtOLBAmount.Text

                ClearOillossesB()
            Else
                DisplayInfoMessage("Msg20")
                ''MsgBox("Description already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesOilLossesB()

        If dgvOilLossesB.RowCount > 0 Then

            ClearOillossesB()
            If GlobalPPT.strLang = "en" Then
                btnOLBAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnOLBAdd.Text = "Memperbarui"
            End If

            ''btnOLBAdd.Text = "Update"
            lbtnAddOilLossesB = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvOilLossesB.SelectedRows(0).Cells("dgclLabOilLossesBID").Value IsNot Nothing Or dgvOilLossesB.SelectedRows(0).Cells("dgclLabOilLossesBID").Value.ToString <> String.Empty Then
                    Me.lLabOilLossesBID = dgvOilLossesB.SelectedRows(0).Cells("dgclLabOilLossesBID").Value.ToString
                End If
            End If

            lDescriptionOLB = Me.dgvOilLossesB.SelectedRows(0).Cells("dgclOLBDescription").Value.ToString
            ddlDescpOilLossesB.Text = Me.dgvOilLossesB.SelectedRows(0).Cells("dgclOLBDescription").Value.ToString
            ddlExpStageNoOilLossB.Text = Me.dgvOilLossesB.SelectedRows(0).Cells("dgclOLBExpellerStageNo").Value.ToString
            ddlExpellaeStagetypeOilLossB.Text = Me.dgvOilLossesB.SelectedRows(0).Cells("dgclOLBExpellerStagetype").Value.ToString
            txtOLBAmount.Text = Me.dgvOilLossesB.SelectedRows(0).Cells("dgclOLBAmount").Value.ToString
        End If
    End Sub

    Private Sub ClearOillossesB()
        ddlDescpOilLossesB.SelectedIndex = 0
        ddlExpStageNoOilLossB.SelectedIndex = 0
        ddlExpellaeStagetypeOilLossB.SelectedIndex = 0
        txtOLBAmount.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnOLBAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnOLBAdd.Text = "Menambahkan"
        End If

        ''btnOLBAdd.Text = "Add"
        lbtnAddOilLossesB = "Add"
        lDescriptionOLB = ""
        lLabOilLossesBID = ""
    End Sub

    '''Kernel Losses FFB

    Private Function IsKernelLossesFFBValidAdd()
        If ddlKernelLossesFFBLine.Text = "--Select--" Then
            DisplayInfoMessage("Msg5")
            ''MessageBox.Show("This field is required.", "Line")
            ddlKernelLossesFFBLine.Focus()
            Return True
        End If
        If Val(txtFFBKLLTDS1P.Text) < 0 Then
            DisplayInfoMessage("Msg21")
            ''MessageBox.Show("This field is required.", "LTDS1(%)")
            txtFFBKLLTDS1P.Focus()
            Return True
        End If
        If Val(txtFFBKLLTDS2P.Text) < 0 Then
            DisplayInfoMessage("Msg22")
            ''MessageBox.Show("This field is required.", "LTDS2(%)")
            txtFFBKLLTDS2P.Focus()
            Return True
        End If
        If Val(txtFFBKLLTDS3P.Text) < 0 Then
            DisplayInfoMessage("Msg92")
            ''MessageBox.Show("This field is required.", "LTDS2(%)")
            txtFFBKLLTDS3P.Focus()
            Return True
        End If
        If Val(txtFFBKLLTDS4P.Text) < 0 Then
            DisplayInfoMessage("Msg94")
            ''MessageBox.Show("This field is required.", "LTDS2(%)")
            txtFFBKLLTDS4P.Focus()
            Return True
        End If
        If Val(txtFFBKLFibreCycP.Text) < 0 Then
            DisplayInfoMessage("Msg23")
            ''MessageBox.Show("This field is required.", "Fibre Cyc.(%)")
            txtFFBKLFibreCycP.Focus()
            Return True
        End If
        If Val(txtKLFFBHydroCycP.Text) < 0 Then
            DisplayInfoMessage("Msg24")
            ''MessageBox.Show("This field is required.", "Hydro Cyc.(%)")
            txtKLFFBHydroCycP.Focus()
            Return True
        End If

        If Val(txtFFBKLFruitinEb.Text) < 0 Then
            DisplayInfoMessage("Msg25")
            ''MessageBox.Show("This field is required.", "Fruit in EB")
            txtFFBKLFruitinEb.Focus()
            Return True
        End If


        Return False
    End Function

    Private Function LineExistInKernelLossesFFB(ByVal Line As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvKernelLossesFFB.Rows
                If Line = objDataGridViewRow.Cells("dgclFFBKLLine").Value.ToString() Then
                    ddlKernelLossesFFBLine.SelectedIndex = 0
                    ddlKernelLossesFFBLine.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataKernelLossesFFB()


        Dim intRowcount As Integer = dtKernelLossesFFB.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not LineExistInKernelLossesFFB(ddlKernelLossesFFBLine.Text) Then
                rowKernelLossesFFB = dtKernelLossesFFB.NewRow()
                If intRowcount = 0 And lbtnAddKernelLossesFFB = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnKernelLossesFFB = New DataColumn("LabKernelLossesFFBID", System.Type.[GetType]("System.String"))
                        dtKernelLossesFFB.Columns.Add(columnKernelLossesFFB)
                        columnKernelLossesFFB = New DataColumn("Line", System.Type.[GetType]("System.String"))
                        dtKernelLossesFFB.Columns.Add(columnKernelLossesFFB)
                        columnKernelLossesFFB = New DataColumn("LTDS1P", System.Type.[GetType]("System.String"))
                        dtKernelLossesFFB.Columns.Add(columnKernelLossesFFB)
                        columnKernelLossesFFB = New DataColumn("LTDS2P", System.Type.[GetType]("System.String"))
                        dtKernelLossesFFB.Columns.Add(columnKernelLossesFFB)
                        columnKernelLossesFFB = New DataColumn("LTDS3P", System.Type.[GetType]("System.String"))
                        dtKernelLossesFFB.Columns.Add(columnKernelLossesFFB)
                        columnKernelLossesFFB = New DataColumn("LTDS4P", System.Type.[GetType]("System.String"))
                        dtKernelLossesFFB.Columns.Add(columnKernelLossesFFB)
                        columnKernelLossesFFB = New DataColumn("FibreCycP", System.Type.[GetType]("System.String"))
                        dtKernelLossesFFB.Columns.Add(columnKernelLossesFFB)
                        columnKernelLossesFFB = New DataColumn("HydroCycP", System.Type.[GetType]("System.String"))
                        dtKernelLossesFFB.Columns.Add(columnKernelLossesFFB)
                        columnKernelLossesFFB = New DataColumn("FruitinEB", System.Type.[GetType]("System.String"))
                        dtKernelLossesFFB.Columns.Add(columnKernelLossesFFB)


                    Catch ex As Exception
                    End Try
                    If lLabKernelLossesFFBID <> String.Empty Then
                        rowKernelLossesFFB("LabKernelLossesFFBID") = lLabKernelLossesFFBID
                    End If

                    rowKernelLossesFFB("LTDS1P") = ConvertToDouble(txtFFBKLLTDS1P.Text)
                    rowKernelLossesFFB("LTDS2P") = ConvertToDouble(txtFFBKLLTDS2P.Text)
                    rowKernelLossesFFB("LTDS3P") = ConvertToDouble(txtFFBKLLTDS3P.Text)
                    rowKernelLossesFFB("LTDS4P") = ConvertToDouble(txtFFBKLLTDS4P.Text)
                    rowKernelLossesFFB("Line") = ddlKernelLossesFFBLine.Text
                    rowKernelLossesFFB("FibreCycP") = ConvertToDouble(txtFFBKLFibreCycP.Text)
                    rowKernelLossesFFB("HydroCycP") = ConvertToDouble(txtKLFFBHydroCycP.Text)
                    rowKernelLossesFFB("FruitinEB") = ConvertToDouble(txtFFBKLFruitinEb.Text)
                    dtKernelLossesFFB.Rows.InsertAt(rowKernelLossesFFB, intRowcount)
                    dgvKernelLossesFFB.AutoGenerateColumns = False

                Else

                    If lLabKernelLossesFFBID <> String.Empty Then
                        rowKernelLossesFFB("LabKernelLossesFFBID") = lLabKernelLossesFFBID
                    End If


                    rowKernelLossesFFB("LTDS1P") = ConvertToDouble(txtFFBKLLTDS1P.Text)
                    rowKernelLossesFFB("LTDS2P") = ConvertToDouble(txtFFBKLLTDS2P.Text)
                    rowKernelLossesFFB("LTDS3P") = ConvertToDouble(txtFFBKLLTDS3P.Text)
                    rowKernelLossesFFB("LTDS4P") = ConvertToDouble(txtFFBKLLTDS4P.Text)
                    rowKernelLossesFFB("Line") = ddlKernelLossesFFBLine.Text
                    rowKernelLossesFFB("FibreCycP") = ConvertToDouble(txtFFBKLFibreCycP.Text)
                    rowKernelLossesFFB("HydroCycP") = ConvertToDouble(txtKLFFBHydroCycP.Text)
                    rowKernelLossesFFB("FruitinEB") = ConvertToDouble(txtFFBKLFruitinEb.Text)
                    dtKernelLossesFFB.Rows.InsertAt(rowKernelLossesFFB, intRowcount)
                    dgvKernelLossesFFB.AutoGenerateColumns = False

                End If
                dgvKernelLossesFFB.DataSource = dtKernelLossesFFB
                ClearKernelLossesFFB()

            Else
                DisplayInfoMessage("Msg26")
                ''MsgBox("Line already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataKernelossesFFB()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If lLineKernelLossesFFB = ddlKernelLossesFFBLine.Text Then
                Dim intCount As Integer = dgvKernelLossesFFB.CurrentRow.Index

                dgvKernelLossesFFB.Rows(intCount).Cells("dgclLabKernelLossesFFBID").Value = lLabKernelLossesFFBID

                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLLine").Value = ddlKernelLossesFFBLine.Text

                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLLTDS1").Value = ConvertToDouble(txtFFBKLLTDS1P.Text)
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLLTDS2").Value = ConvertToDouble(txtFFBKLLTDS2P.Text)
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLLTDS3").Value = ConvertToDouble(txtFFBKLLTDS3P.Text)
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLLTDS4").Value = ConvertToDouble(txtFFBKLLTDS4P.Text)
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLFibreCyc").Value = ConvertToDouble(txtFFBKLFibreCycP.Text)

                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLHydroCyc").Value = ConvertToDouble(txtKLFFBHydroCycP.Text)
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLFruitinFB").Value = ConvertToDouble(txtFFBKLFruitinEb.Text)



                ClearKernelLossesFFB()

            ElseIf Not LineExistInKernelLossesFFB(ddlKernelLossesFFBLine.Text) Then
                Dim intCount As Integer = dgvKernelLossesFFB.CurrentRow.Index

                dgvKernelLossesFFB.Rows(intCount).Cells("dgclLabKernelLossesFFBID").Value = lLabKernelLossesFFBID
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLLine").Value = ddlKernelLossesFFBLine.Text

                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLLTDS1").Value = ConvertToDouble(txtFFBKLLTDS1P.Text)
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLLTDS2").Value = ConvertToDouble(txtFFBKLLTDS2P.Text)
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLLTDS3").Value = ConvertToDouble(txtFFBKLLTDS3P.Text)
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLLTDS4").Value = ConvertToDouble(txtFFBKLLTDS4P.Text)
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLFibreCyc").Value = ConvertToDouble(txtFFBKLFibreCycP.Text)

                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLHydroCyc").Value = ConvertToDouble(txtKLFFBHydroCycP.Text)
                dgvKernelLossesFFB.Rows(intCount).Cells("dgclFFBKLFruitinFB").Value = ConvertToDouble(txtFFBKLFruitinEb.Text)

                ClearKernelLossesFFB()
            Else
                DisplayInfoMessage("Msg26")
                ''MsgBox("Line already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesKernelLossesFFB()

        If dgvKernelLossesFFB.RowCount > 0 Then

            ClearKernelLossesFFB()
            If GlobalPPT.strLang = "en" Then
                btnKernelLossFFBAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnKernelLossFFBAdd.Text = "Memperbarui"
            End If
            ''btnKernelLossFFBAdd.Text = "Update"
            lbtnAddKernelLossesFFB = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvKernelLossesFFB.SelectedRows(0).Cells("dgclLabKernelLossesFFBID").Value IsNot Nothing Or dgvKernelLossesFFB.SelectedRows(0).Cells("dgclLabKernelLossesFFBID").Value.ToString <> String.Empty Then
                    Me.lLabKernelLossesFFBID = dgvKernelLossesFFB.SelectedRows(0).Cells("dgclLabKernelLossesFFBID").Value.ToString
                End If
            End If

            lLineKernelLossesFFB = Me.dgvKernelLossesFFB.SelectedRows(0).Cells("dgclFFBKLLine").Value.ToString
            ddlKernelLossesFFBLine.Text = Me.dgvKernelLossesFFB.SelectedRows(0).Cells("dgclFFBKLLine").Value.ToString
            txtFFBKLLTDS1P.Text = Me.dgvKernelLossesFFB.SelectedRows(0).Cells("dgclFFBKLLTDS1").Value.ToString
            txtFFBKLLTDS2P.Text = Me.dgvKernelLossesFFB.SelectedRows(0).Cells("dgclFFBKLLTDS2").Value.ToString
            txtFFBKLLTDS3P.Text = Me.dgvKernelLossesFFB.SelectedRows(0).Cells("dgclFFBKLLTDS3").Value.ToString
            txtFFBKLLTDS4P.Text = Me.dgvKernelLossesFFB.SelectedRows(0).Cells("dgclFFBKLLTDS4").Value.ToString
            txtFFBKLFibreCycP.Text = Me.dgvKernelLossesFFB.SelectedRows(0).Cells("dgclFFBKLFibreCyc").Value.ToString
            txtFFBKLFruitinEb.Text = Me.dgvKernelLossesFFB.SelectedRows(0).Cells("dgclFFBKLFruitinFB").Value.ToString
            txtKLFFBHydroCycP.Text = Me.dgvKernelLossesFFB.SelectedRows(0).Cells("dgclFFBKLHydroCyc").Value.ToString

        End If

    End Sub


    Private Sub ClearKernelLossesFFB()
        ddlKernelLossesFFBLine.SelectedIndex = 0
        txtFFBKLLTDS1P.Text = String.Empty
        txtFFBKLLTDS2P.Text = String.Empty
        txtFFBKLLTDS3P.Text = String.Empty
        txtFFBKLLTDS4P.Text = String.Empty
        txtFFBKLFibreCycP.Text = String.Empty
        txtKLFFBHydroCycP.Text = String.Empty
        txtFFBKLFruitinEb.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnKernelLossFFBAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnKernelLossFFBAdd.Text = "Menambahkan"
        End If

        ''btnKernelLossFFBAdd.Text = "Add"
        lbtnAddKernelLossesFFB = "Add"
        lLineKernelLossesFFB = ""
        lLabKernelLossesFFBID = ""
    End Sub

    Private Sub ClearKernelCPOPKOProduction()

        btnSaveAll.Enabled = True
        txtBKTodayKer.Text = String.Empty
        txtDirtTodayKer.Text = String.Empty
        txtMoistureTodayKer.Text = String.Empty

        txtFFATodayCPO.Text = String.Empty
        txtCPOMoisture.Text = String.Empty
        txtCPODirtToday.Text = String.Empty
        txtCPOFFAToday.Text = String.Empty
        txtCPOFFAYear.Text = String.Empty
        txtPKOFFAMonth.Text = String.Empty
        txtPKOFFAYear.Text = String.Empty

        txtPKOFFAToday.Text = String.Empty
        txtPKOMoisture.Text = String.Empty
        txtPKODirt.Text = String.Empty

        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        ''btnSaveAll.Text = "Save All"
        lBtnSaveAll = "Save All"

        'commented and edit by suraya  12-09-12

        'dtpLabAnalDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        'dtpViewLabAnalDate.MaxDate = New DateTime(Today.Year, Today.Month, Today.Day)
        'dtpLabAnalDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        'dtpViewLabAnalDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)
        'dtpLabAnalDate.Value = Date.Today
        'dtpViewLabAnalDate.Value = Date.Today

        dtpLabAnalDate.Format = DateTimePickerFormat.Custom
        dtpLabAnalDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpLabAnalDate)

        dtpViewLabAnalDate.Format = DateTimePickerFormat.Custom
        dtpViewLabAnalDate.CustomFormat = "dd/MM/yyyy"
        GlobalBOL.SetDateTimePicker(Me.dtpViewLabAnalDate)

        chkLabAnalDate.Checked = False
        dtpLabAnalDate.Enabled = True
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    '''Kernel InTake



    Private Function IsKernelIntakeValidAdd()
        If ddlKernelIntakeSourceLocation.Text = "--Select--" Then
            DisplayInfoMessage("Msg27")
            ''MessageBox.Show("This field is required.", "Source Location")
            ddlKernelIntakeSourceLocation.Focus()
            Return True
        End If
        If Val(txtKernelInTakeMoisture.Text) = 0 Then
            DisplayInfoMessage("Msg28")
            '' MessageBox.Show("This field is required.", "Moisture")
            txtKernelInTakeMoisture.Focus()
            Return True
        End If
        If Val(txtKernelInTakeReceivedTon.Text) = 0 Then
            DisplayInfoMessage("Msg29")
            ''MessageBox.Show("This field is required.", "Received Ton")
            txtKernelInTakeReceivedTon.Focus()
            Return True
        End If
        If Val(txtKernelInTakeDirt.Text) = 0 Then
            DisplayInfoMessage("Msg30")
            ''MessageBox.Show("This field is required.", "Dirt")
            txtKernelInTakeDirt.Focus()
            Return True
        End If

        If Val(txtKernelInTakeBrokenKernel.Text) = 0 Then
            DisplayInfoMessage("Msg31")
            ''MessageBox.Show("This field is required.", "Broken Kernel")
            txtKernelInTakeBrokenKernel.Focus()
            Return True
        End If
        Return False
    End Function
    Private Function LocationExistInKernelIntake(ByVal SourceLocation As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvKernelInTake.Rows
                If SourceLocation = objDataGridViewRow.Cells("dgclSourceLocation").Value.ToString() Then
                    ddlKernelIntakeSourceLocation.SelectedIndex = 0
                    ddlKernelIntakeSourceLocation.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataKernelIntake()


        Dim intRowcount As Integer = dtKernelInTake.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not LocationExistInKernelIntake(ddlKernelIntakeSourceLocation.Text) Then
                rowKernelInTake = dtKernelInTake.NewRow()
                If intRowcount = 0 And lbtnAddKernelInTake = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnKernelInTake = New DataColumn("LabKernelIntakeID", System.Type.[GetType]("System.String"))
                        dtKernelInTake.Columns.Add(columnKernelInTake)
                        columnKernelInTake = New DataColumn("SourceLocation", System.Type.[GetType]("System.String"))
                        dtKernelInTake.Columns.Add(columnKernelInTake)
                        columnKernelInTake = New DataColumn("ReceivedTon", System.Type.[GetType]("System.String"))
                        dtKernelInTake.Columns.Add(columnKernelInTake)
                        columnKernelInTake = New DataColumn("MoistureP", System.Type.[GetType]("System.String"))
                        dtKernelInTake.Columns.Add(columnKernelInTake)
                        columnKernelInTake = New DataColumn("DirtP", System.Type.[GetType]("System.String"))
                        dtKernelInTake.Columns.Add(columnKernelInTake)
                        columnKernelInTake = New DataColumn("BrokenKernel", System.Type.[GetType]("System.String"))
                        dtKernelInTake.Columns.Add(columnKernelInTake)

                    Catch ex As Exception
                    End Try

                    If lLabKernelInTakeID <> String.Empty Then
                        rowKernelInTake("LabKernelIntakeID") = lLabKernelInTakeID
                    End If
                    rowKernelInTake("SourceLocation") = ddlKernelIntakeSourceLocation.Text
                    rowKernelInTake("ReceivedTon") = txtKernelInTakeReceivedTon.Text
                    rowKernelInTake("MoistureP") = txtKernelInTakeMoisture.Text
                    rowKernelInTake("DirtP") = txtKernelInTakeDirt.Text
                    rowKernelInTake("BrokenKernel") = txtKernelInTakeBrokenKernel.Text


                    dtKernelInTake.Rows.InsertAt(rowKernelInTake, intRowcount)
                    dgvKernelInTake.AutoGenerateColumns = False

                Else

                    If lLabKernelInTakeID <> String.Empty Then
                        rowKernelInTake("LabKernelIntakeID") = lLabKernelInTakeID
                    End If
                    rowKernelInTake("SourceLocation") = ddlKernelIntakeSourceLocation.Text
                    rowKernelInTake("ReceivedTon") = txtKernelInTakeReceivedTon.Text
                    rowKernelInTake("MoistureP") = txtKernelInTakeMoisture.Text
                    rowKernelInTake("DirtP") = txtKernelInTakeDirt.Text
                    rowKernelInTake("BrokenKernel") = txtKernelInTakeBrokenKernel.Text

                    dtKernelInTake.Rows.InsertAt(rowKernelInTake, intRowcount)
                    dgvKernelInTake.AutoGenerateColumns = False

                End If
                dgvKernelInTake.DataSource = dtKernelInTake
                ClearKernelInTake()

            Else
                DisplayInfoMessage("Msg32")
                'MsgBox("Source Location already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataKernelIntake()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try



            If lLocationKernelInTake = ddlKernelIntakeSourceLocation.Text Then
                Dim intCount As Integer = dgvKernelInTake.CurrentRow.Index

                dgvKernelInTake.Rows(intCount).Cells("dgclLabKernelInTakeID").Value = lLabKernelInTakeID
                dgvKernelInTake.Rows(intCount).Cells("dgclSourceLocation").Value = ddlKernelIntakeSourceLocation.Text
                dgvKernelInTake.Rows(intCount).Cells("dgclMoisture").Value = txtKernelInTakeMoisture.Text
                dgvKernelInTake.Rows(intCount).Cells("dgclDirt").Value = txtKernelInTakeDirt.Text
                dgvKernelInTake.Rows(intCount).Cells("dgclReceivedTon").Value = txtKernelInTakeReceivedTon.Text
                dgvKernelInTake.Rows(intCount).Cells("dgclBrokenKernel").Value = txtKernelInTakeBrokenKernel.Text

                ClearKernelInTake()

            ElseIf Not LocationExistInKernelIntake(ddlKernelIntakeSourceLocation.Text) Then
                Dim intCount As Integer = dgvKernelInTake.CurrentRow.Index

                dgvKernelInTake.Rows(intCount).Cells("dgclLabKernelIntakeID").Value = lLabKernelInTakeID
                dgvKernelInTake.Rows(intCount).Cells("dgclSourceLocation").Value = ddlKernelIntakeSourceLocation.Text
                dgvKernelInTake.Rows(intCount).Cells("dgclMoisture").Value = txtKernelInTakeMoisture.Text
                dgvKernelInTake.Rows(intCount).Cells("dgclDirt").Value = txtKernelInTakeDirt.Text
                dgvKernelInTake.Rows(intCount).Cells("dgclReceivedTon").Value = txtKernelInTakeReceivedTon.Text
                dgvKernelInTake.Rows(intCount).Cells("dgclBrokenKernel").Value = txtKernelInTakeBrokenKernel.Text



                ClearKernelInTake()
            Else
                DisplayInfoMessage("Msg32")
                ''MsgBox("Source Location already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesKernelIntake()

        If dgvKernelInTake.RowCount > 0 Then

            ClearKernelInTake()
            If GlobalPPT.strLang = "en" Then
                btnKernelInTakeAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnKernelInTakeAdd.Text = "Memperbarui"
            End If

            ''btnKernelInTakeAdd.Text = "Update"
            lbtnAddKernelInTake = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvKernelInTake.SelectedRows(0).Cells("dgclLabKernelInTakeID").Value IsNot Nothing Or dgvKernelInTake.SelectedRows(0).Cells("dgclLabKernelInTakeID").Value.ToString <> String.Empty Then
                    Me.lLabKernelInTakeID = dgvKernelInTake.SelectedRows(0).Cells("dgclLabKernelInTakeID").Value.ToString
                End If
            End If

            lLocationKernelInTake = Me.dgvKernelInTake.SelectedRows(0).Cells("dgclSourceLocation").Value.ToString
            ddlKernelIntakeSourceLocation.Text = Me.dgvKernelInTake.SelectedRows(0).Cells("dgclSourceLocation").Value.ToString
            txtKernelInTakeDirt.Text = Me.dgvKernelInTake.SelectedRows(0).Cells("dgclDirt").Value.ToString
            txtKernelInTakeMoisture.Text = Me.dgvKernelInTake.SelectedRows(0).Cells("dgclMoisture").Value.ToString
            txtKernelInTakeReceivedTon.Text = Me.dgvKernelInTake.SelectedRows(0).Cells("dgclReceivedTon").Value.ToString
            txtKernelInTakeBrokenKernel.Text = Me.dgvKernelInTake.SelectedRows(0).Cells("dgclBrokenKernel").Value.ToString


        End If

    End Sub

    Private Sub ClearKernelInTake()
        ddlKernelIntakeSourceLocation.SelectedIndex = 0
        txtKernelInTakeDirt.Text = String.Empty
        txtKernelInTakeReceivedTon.Text = String.Empty
        txtKernelInTakeMoisture.Text = String.Empty
        txtKernelInTakeBrokenKernel.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnKernelInTakeAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnKernelInTakeAdd.Text = "Menambahkan"
        End If

        ''btnKernelInTakeAdd.Text = "Add"
        lbtnAddKernelInTake = "Add"
        lLocationKernelInTake = ""
        lLabKernelInTakeID = ""
    End Sub

    '''EffeciencyRippleMill


    Private Function IsEffRippleMillValidAdd()


        If ddlLineEffRippleMill.Text = "--Select--" Then
            DisplayInfoMessage("Msg5")
            ''MessageBox.Show("This field is required.", "Line")
            ddlLineEffRippleMill.Focus()
            Return True
        End If
        If ddlNoEffRippleMill.Text = "--Select--" Then
            DisplayInfoMessage("Msg3")
            '' MessageBox.Show("This field is required.", "Number")
            ddlNoEffRippleMill.Focus()
            Return True
        End If
        If ddlEquipment.Text = "--Select--" Then
            MessageBox.Show("Equipment is required.", "Equipment")
            ddlEquipment.Focus()
            Return True
        End If
        If Val(txtERMEfficiencyP.Text) = 0 Then
            DisplayInfoMessage("Msg8")
            ''MessageBox.Show("This field is required.", "Efficiency")
            txtERMEfficiencyP.Focus()
            Return True
        End If
        Return False
    End Function
    Private Function LineExistInEffRippleMill(ByVal Line As String, ByVal No As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvEffRippleMill.Rows
                If Line = objDataGridViewRow.Cells("dgclERMLine").Value.ToString() And
                    No = objDataGridViewRow.Cells("dgclERMNo").Value.ToString() Then
                    ddlLineEffRippleMill.SelectedIndex = 0
                    ddlLineEffRippleMill.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataEffRippleMill()


        Dim intRowcount As Integer = dtEffRippleMill.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not LineExistInEffRippleMill(ddlLineEffRippleMill.Text, ddlNoEffRippleMill.Text) Then
                rowEffRippleMill = dtEffRippleMill.NewRow()
                If intRowcount = 0 And lbtnAddEffRippleMill = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnEffRippleMill = New DataColumn("LabEffRippleMillID", System.Type.[GetType]("System.String"))
                        dtEffRippleMill.Columns.Add(columnEffRippleMill)
                        columnEffRippleMill = New DataColumn("Line", System.Type.[GetType]("System.String"))
                        dtEffRippleMill.Columns.Add(columnEffRippleMill)
                        columnEffRippleMill = New DataColumn("No", System.Type.[GetType]("System.String"))
                        dtEffRippleMill.Columns.Add(columnEffRippleMill)
                        columnEffRippleMill = New DataColumn("efficiencyP", System.Type.[GetType]("System.String"))
                        dtEffRippleMill.Columns.Add(columnEffRippleMill)
                        columnEffRippleMill = New DataColumn("Equipment", System.Type.[GetType]("System.String"))
                        dtEffRippleMill.Columns.Add(columnEffRippleMill)


                    Catch ex As Exception

                    End Try
                    If lLabEffRippleMillID <> String.Empty Then
                        rowEffRippleMill("LabEffRippleMillID") = lLabEffRippleMillID
                    End If

                    rowEffRippleMill("Line") = ddlLineEffRippleMill.Text
                    rowEffRippleMill("efficiencyP") = txtERMEfficiencyP.Text
                    rowEffRippleMill("No") = ddlNoEffRippleMill.Text
                    rowEffRippleMill("Equipment") = ddlEquipment.Text


                    dtEffRippleMill.Rows.InsertAt(rowEffRippleMill, intRowcount)
                    dgvEffRippleMill.AutoGenerateColumns = False


                Else

                    If lLabEffRippleMillID <> String.Empty Then
                        rowEffRippleMill("LabEffRippleMillID") = lLabEffRippleMillID
                    End If


                    rowEffRippleMill("Line") = ddlLineEffRippleMill.Text
                    rowEffRippleMill("efficiencyP") = txtERMEfficiencyP.Text
                    rowEffRippleMill("No") = ddlNoEffRippleMill.Text
                    rowEffRippleMill("Equipment") = ddlEquipment.Text


                    dtEffRippleMill.Rows.InsertAt(rowEffRippleMill, intRowcount)
                    dgvEffRippleMill.AutoGenerateColumns = False

                End If
                dgvEffRippleMill.DataSource = dtEffRippleMill
                ClearEfficiencyripleMill()

            Else
                DisplayInfoMessage("Msg26")
                ''MsgBox("Line already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataEffRippleMill()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If lLineEffRippleMill = ddlLineEffRippleMill.Text Then
                Dim intCount As Integer = dgvEffRippleMill.CurrentRow.Index

                dgvEffRippleMill.Rows(intCount).Cells("dgclLabEffRippleMill").Value = lLabEffRippleMillID
                dgvEffRippleMill.Rows(intCount).Cells("dgclERMLine").Value = ddlLineEffRippleMill.Text
                dgvEffRippleMill.Rows(intCount).Cells("dgclERMNo").Value = ddlNoEffRippleMill.Text
                dgvEffRippleMill.Rows(intCount).Cells("dgclERMEffciencyP").Value = txtERMEfficiencyP.Text
                dgvEffRippleMill.Rows(intCount).Cells("dgclEquipment").Value = ddlEquipment.Text


                ClearEfficiencyripleMill()

            ElseIf Not LineExistInEffRippleMill(ddlLineEffRippleMill.Text, ddlNoEffRippleMill.Text) Then
                Dim intCount As Integer = dgvEffRippleMill.CurrentRow.Index

                dgvEffRippleMill.Rows(intCount).Cells("dgclLabEffRippleMill").Value = lLabEffRippleMillID
                dgvEffRippleMill.Rows(intCount).Cells("dgclERMLine").Value = ddlLineEffRippleMill.Text
                dgvEffRippleMill.Rows(intCount).Cells("dgclERMNo").Value = ddlNoEffRippleMill.Text
                dgvEffRippleMill.Rows(intCount).Cells("dgclERMEffciencyP").Value = txtERMEfficiencyP.Text
                dgvEffRippleMill.Rows(intCount).Cells("dgclEquipment").Value = ddlEquipment.Text
                ClearEfficiencyripleMill()
            Else
                DisplayInfoMessage("Msg26")
                ''MsgBox("Line already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesEffRippleMill()

        If dgvEffRippleMill.RowCount > 0 Then

            ClearEfficiencyripleMill()

            If GlobalPPT.strLang = "en" Then
                btnERMAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnERMAdd.Text = "Memperbarui"
            End If
            ''btnERMAdd.Text = "Update"
            lbtnAddEffRippleMill = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvEffRippleMill.SelectedRows(0).Cells("dgclLabEffRippleMill").Value IsNot Nothing Or dgvEffRippleMill.SelectedRows(0).Cells("dgclLabEffRippleMill").Value.ToString <> String.Empty Then
                    Me.lLabEffRippleMillID = dgvEffRippleMill.SelectedRows(0).Cells("dgclLabEffRippleMill").Value.ToString
                End If
            End If

            lLineEffRippleMill = Me.dgvEffRippleMill.SelectedRows(0).Cells("dgclERMLine").Value.ToString
            ddlNoEffRippleMill.Text = Me.dgvEffRippleMill.SelectedRows(0).Cells("dgclERMNo").Value.ToString
            ddlLineEffRippleMill.Text = Me.dgvEffRippleMill.SelectedRows(0).Cells("dgclERMLine").Value.ToString
            txtERMEfficiencyP.Text = Me.dgvEffRippleMill.SelectedRows(0).Cells("dgclERMEffciencyP").Value.ToString
            ddlEquipment.Text = Me.dgvEffRippleMill.SelectedRows(0).Cells("dgclEquipment").Value.ToString
        End If

    End Sub
    Private Sub ClearEfficiencyripleMill()
        ddlLineEffRippleMill.SelectedIndex = 0
        ddlNoEffRippleMill.SelectedIndex = 0
        ddlEquipment.SelectedIndex = 0
        txtERMEfficiencyP.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnERMAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnERMAdd.Text = "Menambahkan"
        End If

        ''btnERMAdd.Text = "Add"
        lbtnAddEffRippleMill = "Add"
        lLineEffRippleMill = ""
        lLabEffRippleMillID = ""
    End Sub

    '''Kernel Qty Storage


    Private Function IsKernelQtyStorageValidAdd()
        If ddlLineKernalQuality.Text = "--Select--" Then
            'DisplayInfoMessage("Msg33")
            MsgBox("Line is required", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
            ddlLineKernalQuality.Focus()
            Return True
        End If
        If ddlKernelqtyStorageLocation.Text = "--Select--" Then
            DisplayInfoMessage("Msg33")
            ''MessageBox.Show("This field is required.", "Location")
            ddlKernelqtyStorageLocation.Focus()
            Return True
        End If
        If txtKQSMoisture.Text.Length = 0 Then
            txtKQSMoisture.Text = "0"
            '    DisplayInfoMessage("Msg28")
            '    ''MessageBox.Show("This field is required.", "Moisture")
            '    txtKQSMoisture.Focus()
            '    Return True
        End If
        If txtKQSDirt.Text.Length = 0 Then
            txtKQSDirt.Text = "0"
            'DisplayInfoMessage("Msg30")
            ''MessageBox.Show("This field is required.", "Dirt")
            'txtKQSDirt.Focus()
            'Return True
        End If
        If txtKQSBrokenKernel.Text.Length = 0 Then
            txtKQSBrokenKernel.Text = "0"
            '    DisplayInfoMessage("Msg31")
            '    ''MessageBox.Show("This field is required.", "Broken Kernel")
            '    txtKQSBrokenKernel.Focus()
            '    Return True
        End If

        Return False
    End Function
    Private Function LocationExistInKernelQtyStorage(ByVal SourceLocation As String, ByVal Line As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvKernelQtyStorage.Rows
                If SourceLocation = objDataGridViewRow.Cells("dgclKQSLocation").Value.ToString() And
                    Line = objDataGridViewRow.Cells("dgcLine").Value.ToString() Then
                    ddlKernelqtyStorageLocation.SelectedIndex = 0
                    ddlKernelqtyStorageLocation.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataKernelQtyStorage()


        Dim intRowcount As Integer = dtKernelQtyStorage.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not LocationExistInKernelQtyStorage(ddlKernelqtyStorageLocation.Text, ddlLineKernalQuality.Text) Then
                rowKernelQtyStorage = dtKernelQtyStorage.NewRow()
                If intRowcount = 0 And lbtnAddKernelQtyStorage = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnKernelQtyStorage = New DataColumn("LabKernelQtyStorageID", System.Type.[GetType]("System.String"))
                        dtKernelQtyStorage.Columns.Add(columnKernelQtyStorage)
                        columnKernelQtyStorage = New DataColumn("Line", System.Type.[GetType]("System.String"))
                        dtKernelQtyStorage.Columns.Add(columnKernelQtyStorage)
                        columnKernelQtyStorage = New DataColumn("Location", System.Type.[GetType]("System.String"))
                        dtKernelQtyStorage.Columns.Add(columnKernelQtyStorage)
                        columnKernelQtyStorage = New DataColumn("BrokenKernel", System.Type.[GetType]("System.String"))
                        dtKernelQtyStorage.Columns.Add(columnKernelQtyStorage)
                        columnKernelQtyStorage = New DataColumn("MoistureP", System.Type.[GetType]("System.String"))
                        dtKernelQtyStorage.Columns.Add(columnKernelQtyStorage)
                        columnKernelQtyStorage = New DataColumn("DirtP", System.Type.[GetType]("System.String"))
                        dtKernelQtyStorage.Columns.Add(columnKernelQtyStorage)

                    Catch ex As Exception
                    End Try
                    If lLabKernelQtyStorageID <> String.Empty Then
                        rowKernelQtyStorage("LabKernelQtyStorageID") = lLabKernelQtyStorageID
                    End If
                    rowKernelQtyStorage("Line") = ddlLineKernalQuality.Text
                    rowKernelQtyStorage("Location") = ddlKernelqtyStorageLocation.Text
                    rowKernelQtyStorage("BrokenKernel") = ConvertToDouble(txtKQSBrokenKernel.Text)
                    rowKernelQtyStorage("MoistureP") = ConvertToDouble(txtKQSMoisture.Text)
                    rowKernelQtyStorage("DirtP") = ConvertToDouble(txtKQSDirt.Text)

                    dtKernelQtyStorage.Rows.InsertAt(rowKernelQtyStorage, intRowcount)
                    dgvKernelQtyStorage.AutoGenerateColumns = False


                Else

                    If lLabKernelQtyStorageID <> String.Empty Then
                        rowKernelQtyStorage("LabKernelQtyStorageID") = lLabKernelQtyStorageID
                    End If

                    rowKernelQtyStorage("Line") = ddlLineKernalQuality.Text
                    rowKernelQtyStorage("Location") = ddlKernelqtyStorageLocation.Text
                    rowKernelQtyStorage("BrokenKernel") = ConvertToDouble(txtKQSBrokenKernel.Text)
                    rowKernelQtyStorage("MoistureP") = ConvertToDouble(txtKQSMoisture.Text)
                    rowKernelQtyStorage("DirtP") = ConvertToDouble(txtKQSDirt.Text)

                    dtKernelQtyStorage.Rows.InsertAt(rowKernelQtyStorage, intRowcount)
                    dgvKernelQtyStorage.AutoGenerateColumns = False

                End If
                dgvKernelQtyStorage.DataSource = dtKernelQtyStorage
                ClearKernelQtyStorage()

            Else
                'DisplayInfoMessage("Msg34")
                MsgBox("Location already exist for the selected Line", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
                ''MsgBox("Location already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataKernelQtyStorage()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            Dim intCount As Integer = dgvKernelQtyStorage.CurrentRow.Index

            If lLocationKernelQtyStorage = ddlKernelqtyStorageLocation.Text Then


                dgvKernelQtyStorage.Rows(intCount).Cells("dgLabKernelQtyStorageID").Value = lLabKernelQtyStorageID
                dgvKernelQtyStorage.Rows(intCount).Cells("dgcLine").Value = ddlLineKernalQuality.Text
                dgvKernelQtyStorage.Rows(intCount).Cells("dgclKQSLocation").Value = ddlKernelqtyStorageLocation.Text
                dgvKernelQtyStorage.Rows(intCount).Cells("dgclKQSMoisture").Value = ConvertToDouble(txtKQSMoisture.Text)
                dgvKernelQtyStorage.Rows(intCount).Cells("dgclKQSDirtP").Value = ConvertToDouble(txtKQSDirt.Text)
                dgvKernelQtyStorage.Rows(intCount).Cells("dgclKQSBrokenKernel").Value = ConvertToDouble(txtKQSBrokenKernel.Text)


                ClearKernelQtyStorage()

            ElseIf Not LocationExistInKernelQtyStorage(ddlKernelqtyStorageLocation.Text, ddlLineKernalQuality.Text) Then
                dgvKernelQtyStorage.Rows(intCount).Cells("dgLabKernelQtyStorageID").Value = lLabKernelQtyStorageID
                dgvKernelQtyStorage.Rows(intCount).Cells("dgcLine").Value = ddlLineKernalQuality.Text
                dgvKernelQtyStorage.Rows(intCount).Cells("dgclKQSLocation").Value = ddlKernelqtyStorageLocation.Text
                dgvKernelQtyStorage.Rows(intCount).Cells("dgclKQSMoisture").Value = ConvertToDouble(txtKQSMoisture.Text)
                dgvKernelQtyStorage.Rows(intCount).Cells("dgclKQSDirtP").Value = ConvertToDouble(txtKQSDirt.Text)
                dgvKernelQtyStorage.Rows(intCount).Cells("dgclKQSBrokenKernel").Value = ConvertToDouble(txtKQSBrokenKernel.Text)

                ClearKernelQtyStorage()
            Else
                DisplayInfoMessage("Msg34")
                ''MsgBox("Location already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesKernelQtyStorage()

        If dgvKernelQtyStorage.RowCount > 0 Then

            ClearKernelQtyStorage()

            If GlobalPPT.strLang = "en" Then
                btnKQSAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnKQSAdd.Text = "Memperbarui"
            End If
            ''btnKQSAdd.Text = "Update"
            lbtnAddKernelQtyStorage = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvKernelQtyStorage.SelectedRows(0).Cells("dgLabKernelQtyStorageID").Value IsNot Nothing Or dgvKernelQtyStorage.SelectedRows(0).Cells("dgLabKernelQtyStorageID").Value.ToString <> String.Empty Then
                    Me.lLabKernelQtyStorageID = dgvKernelQtyStorage.SelectedRows(0).Cells("dgLabKernelQtyStorageID").Value.ToString
                End If
            End If
            lLocationKernelQtyStorage = Me.dgvKernelQtyStorage.SelectedRows(0).Cells("dgclKQSLocation").Value.ToString
            ddlLineKernalQuality.Text = Me.dgvKernelQtyStorage.SelectedRows(0).Cells("dgcLine").Value.ToString
            ddlKernelqtyStorageLocation.Text = Me.dgvKernelQtyStorage.SelectedRows(0).Cells("dgclKQSLocation").Value.ToString
            txtKQSDirt.Text = Me.dgvKernelQtyStorage.SelectedRows(0).Cells("dgclKQSDirtP").Value.ToString
            txtKQSMoisture.Text = Me.dgvKernelQtyStorage.SelectedRows(0).Cells("dgclKQSMoisture").Value.ToString
            txtKQSBrokenKernel.Text = Me.dgvKernelQtyStorage.SelectedRows(0).Cells("dgclKQSBrokenKernel").Value.ToString

        End If

    End Sub

    Private Sub ClearKernelQtyStorage()
        ddlKernelqtyStorageLocation.SelectedIndex = 0
        txtKQSMoisture.Text = String.Empty
        txtKQSDirt.Text = String.Empty
        txtKQSBrokenKernel.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnKQSAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnKQSAdd.Text = "Menambahkan"
        End If
        ''btnKQSAdd.Text = "Add"
        lbtnAddKernelQtyStorage = "Add"
        lLocationKernelQtyStorage = ""
        lLabKernelQtyStorageID = ""
    End Sub

    '''Oil Qty Storage

    Private Function IsOilQtyStorageValidAdd()
        If ddlProductTypeOilQtyStorage.Text = "--Select--" Then
            DisplayInfoMessage("Msg35")
            ''MessageBox.Show("This field is required.", "Product Type")
            ddlProductTypeOilQtyStorage.Focus()
            Return True
        End If

        If ddlTankOilQtyStorage.Text = "--Select--" Then
            DisplayInfoMessage("Msg36")
            ''MessageBox.Show("This field is required.", "Tank")
            ddlTankOilQtyStorage.Focus()
            Return True
        End If
        If Val(txtOQSFFA.Text) < 0 Then
            DisplayInfoMessage("Msg37")
            ''MessageBox.Show("This field is required.", "FFA")
            txtOQSFFA.Focus()
            Return True
        End If
        If Val(txtOQSMoisture.Text) < 0 Then
            DisplayInfoMessage("Msg28")
            ''MessageBox.Show("This field is required.", "Moisture")
            txtOQSMoisture.Focus()
            Return True
        End If
        If Val(txtOQSDirt.Text) < 0 Then
            DisplayInfoMessage("Msg30")
            ''MessageBox.Show("This field is required.", "Dirt")
            txtOQSDirt.Focus()
            Return True
        End If


        Return False
    End Function
    Private Function ProductTypeExistInOilQtyStorage(ByVal ProductType As String, ByVal TankOilQtyStorage As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvOilQtyStorage.Rows
                If ProductType = objDataGridViewRow.Cells("dgclOQSProductType").Value.ToString() _
                And TankOilQtyStorage = objDataGridViewRow.Cells("dgclOQSTank").Value.ToString() Then
                    ddlProductTypeOilQtyStorage.SelectedIndex = 0
                    ddlProductTypeOilQtyStorage.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataOilQtyStorage()


        Dim intRowcount As Integer = dtOilQtyStorage.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not ProductTypeExistInOilQtyStorage(ddlProductTypeOilQtyStorage.Text, ddlTankOilQtyStorage.Text) Then
                rowOilQtyStorage = dtOilQtyStorage.NewRow()
                If intRowcount = 0 And lbtnAddOilQtyStorage = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnOilQtyStorage = New DataColumn("LabOilQtyStorageID", System.Type.[GetType]("System.String"))
                        dtOilQtyStorage.Columns.Add(columnOilQtyStorage)
                        columnOilQtyStorage = New DataColumn("ProductType", System.Type.[GetType]("System.String"))
                        dtOilQtyStorage.Columns.Add(columnOilQtyStorage)
                        columnOilQtyStorage = New DataColumn("TankID", System.Type.[GetType]("System.String"))
                        dtOilQtyStorage.Columns.Add(columnOilQtyStorage)
                        columnOilQtyStorage = New DataColumn("Tank", System.Type.[GetType]("System.String"))
                        dtOilQtyStorage.Columns.Add(columnOilQtyStorage)
                        columnOilQtyStorage = New DataColumn("FFAP", System.Type.[GetType]("System.String"))
                        dtOilQtyStorage.Columns.Add(columnOilQtyStorage)
                        columnOilQtyStorage = New DataColumn("MoistureP", System.Type.[GetType]("System.String"))
                        dtOilQtyStorage.Columns.Add(columnOilQtyStorage)
                        columnOilQtyStorage = New DataColumn("DirtP", System.Type.[GetType]("System.String"))
                        dtOilQtyStorage.Columns.Add(columnOilQtyStorage)


                    Catch ex As Exception
                    End Try

                    If lLabOilQtyStorageID <> String.Empty Then
                        rowOilQtyStorage("LabOilQtyStorageID") = lLabOilQtyStorageID
                    End If
                    rowOilQtyStorage("ProductType") = ddlProductTypeOilQtyStorage.Text
                    rowOilQtyStorage("TankID") = ddlTankOilQtyStorage.SelectedValue.ToString
                    rowOilQtyStorage("Tank") = ddlTankOilQtyStorage.Text
                    rowOilQtyStorage("MoistureP") = ConvertToDouble(txtOQSMoisture.Text)
                    rowOilQtyStorage("DirtP") = ConvertToDouble(txtOQSDirt.Text)
                    rowOilQtyStorage("FFAP") = ConvertToDouble(txtOQSFFA.Text)

                    dtOilQtyStorage.Rows.InsertAt(rowOilQtyStorage, intRowcount)
                    dgvOilQtyStorage.AutoGenerateColumns = False

                Else

                    If lLabOilQtyStorageID <> String.Empty Then
                        rowOilQtyStorage("LabOilQtyStorageID") = lLabOilQtyStorageID
                    End If

                    rowOilQtyStorage("ProductType") = ddlProductTypeOilQtyStorage.Text
                    rowOilQtyStorage("TankID") = ddlTankOilQtyStorage.SelectedValue.ToString
                    rowOilQtyStorage("Tank") = ddlTankOilQtyStorage.Text
                    rowOilQtyStorage("MoistureP") = ConvertToDouble(txtOQSMoisture.Text)
                    rowOilQtyStorage("DirtP") = ConvertToDouble(txtOQSDirt.Text)
                    rowOilQtyStorage("FFAP") = ConvertToDouble(txtOQSFFA.Text)

                    dtOilQtyStorage.Rows.InsertAt(rowOilQtyStorage, intRowcount)
                    dgvOilQtyStorage.AutoGenerateColumns = False

                End If
                dgvOilQtyStorage.DataSource = dtOilQtyStorage
                ClearOilQtyStorage()

            Else
                DisplayInfoMessage("Msg38")
                ''MsgBox("Product Type already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataOilQtyStorage()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try


            If lProductTypeOilQualityStorage = ddlProductTypeOilQtyStorage.Text Then
                Dim intCount As Integer = dgvOilQtyStorage.CurrentRow.Index

                dgvOilQtyStorage.Rows(intCount).Cells("dgLabOilQtyStorageID").Value = lLabOilQtyStorageID
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSTankID").Value = ddlTankOilQtyStorage.SelectedValue.ToString
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSTank").Value = ddlProductTypeOilQtyStorage.Text
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSProductType").Value = ddlProductTypeOilQtyStorage.Text
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSMoisture").Value = ConvertToDouble(txtOQSMoisture.Text)
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSDirt").Value = ConvertToDouble(txtOQSDirt.Text)
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSFFA").Value = ConvertToDouble(txtOQSFFA.Text)


                ClearOilQtyStorage()

            ElseIf Not ProductTypeExistInOilQtyStorage(ddlProductTypeOilQtyStorage.Text, ddlTankOilQtyStorage.Text) Then
                Dim intCount As Integer = dgvOilQtyStorage.CurrentRow.Index

                dgvOilQtyStorage.Rows(intCount).Cells("dgLabOilQtyStorageID").Value = lLabOilQtyStorageID
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSTankID").Value = ddlTankOilQtyStorage.SelectedValue.ToString
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSTank").Value = ddlProductTypeOilQtyStorage.Text
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSProductType").Value = ddlProductTypeOilQtyStorage.Text
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSMoisture").Value = ConvertToDouble(txtOQSMoisture.Text)
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSDirt").Value = ConvertToDouble(txtOQSDirt.Text)
                dgvOilQtyStorage.Rows(intCount).Cells("dgclOQSFFA").Value = ConvertToDouble(txtOQSFFA.Text)
            Else
                DisplayInfoMessage("Msg38")
                ''MsgBox("Product Type already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesOilQtyStorage()

        If dgvOilQtyStorage.RowCount > 0 Then

            ClearOilQtyStorage()

            If GlobalPPT.strLang = "en" Then
                btnOQSAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnOQSAdd.Text = "Memperbarui"
            End If
            '' btnOQSAdd.Text = "Update"
            lbtnAddOilQtyStorage = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvOilQtyStorage.SelectedRows(0).Cells("dgLabOilQtyStorageID").Value IsNot Nothing Or dgvOilQtyStorage.SelectedRows(0).Cells("dgLabOilQtyStorageID").Value.ToString <> String.Empty Then
                    Me.lLabOilQtyStorageID = dgvOilQtyStorage.SelectedRows(0).Cells("dgLabOilQtyStorageID").Value.ToString
                End If
            End If
            lProductTypeOilQualityStorage = Me.dgvOilQtyStorage.SelectedRows(0).Cells("dgclOQSProductType").Value.ToString
            ddlProductTypeOilQtyStorage.Text = Me.dgvOilQtyStorage.SelectedRows(0).Cells("dgclOQSProductType").Value.ToString
            ddlTankOilQtyStorage.Text = Me.dgvOilQtyStorage.SelectedRows(0).Cells("dgclOQSTank").Value.ToString
            txtOQSDirt.Text = Me.dgvOilQtyStorage.SelectedRows(0).Cells("dgclOQSDirt").Value.ToString
            txtOQSMoisture.Text = Me.dgvOilQtyStorage.SelectedRows(0).Cells("dgclOQSMoisture").Value.ToString
            txtOQSFFA.Text = Me.dgvOilQtyStorage.SelectedRows(0).Cells("dgclOQSFFA").Value.ToString

        End If

    End Sub

    Private Sub ClearOilQtyStorage()
        ddlProductTypeOilQtyStorage.SelectedIndex = 0
        ddlTankOilQtyStorage.SelectedIndex = 0
        txtOQSFFA.Text = String.Empty
        txtOQSMoisture.Text = String.Empty
        txtOQSDirt.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnOQSAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnOQSAdd.Text = "Menambahkan"
        End If
        ''btnOQSAdd.Text = "Add"
        lbtnAddOilQtyStorage = "Add"
        lProductTypeOilQualityStorage = ""
        lLabOilQtyStorageID = ""
    End Sub

    '''Machinery Operation

    Private Function IsMachineryOperationValidAdd()
        If ddlMachineName.Text = "--Select--" Then
            DisplayInfoMessage("Msg39")
            '' MessageBox.Show("This field is required.", "Machine Name")
            ddlMachineName.Focus()
            Return True
        End If

        If txtMOHMeterFrom.Text = "--Select--" Then
            DisplayInfoMessage("Msg40")
            ''MessageBox.Show("This field is required.", "Meter From")
            txtMOHMeterFrom.Focus()
            Return True
        End If

        If txtMOHMeterTo.Text = "" Then
            DisplayInfoMessage("Msg41")
            'MessageBox.Show("This field is required.", "Meter To")
            txtMOHMeterTo.Focus()
            Return True
        End If
        If txtMOHProcessHours.Text = "" Then
            DisplayInfoMessage("Msg42")
            ''MessageBox.Show("This field is required.", "Process Hours")
            txtMOHProcessHours.Focus()
            Return True
        End If
        If txtMOHNonProcessHours.Text = String.Empty Then
            DisplayInfoMessage("Msg43")
            ''MessageBox.Show("This field is required.", "NonProcess Hours")
            txtMOHNonProcessHours.Focus()
            Return True
        End If
        If txtMOHMonthToDate.Text = "00:00" Then
            DisplayInfoMessage("Msg44")
            ''MessageBox.Show("This field is required.", "Month To Date")
            txtMOHMonthToDate.Focus()
            Return True
        End If
        If txtMOHYearToDate.Text = "00:00" Then
            DisplayInfoMessage("Msg45")
            ''MessageBox.Show("This field is required.", "Year To Date")
            txtMOHYearToDate.Focus()
            Return True
        End If
        Return False
    End Function
    Private Function MachineNameExistInMachineryOperation(ByVal MachineName As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvMachineryOperation.Rows
                If MachineName = objDataGridViewRow.Cells("dgclMOHMachineID").Value.ToString() Then
                    ddlMachineName.SelectedIndex = 0
                    ddlMachineName.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataMachineryOperation()


        Dim intRowcount As Integer = dtMachineryOperation.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not MachineNameExistInMachineryOperation(ddlMachineName.SelectedValue.ToString) Then
                rowMachineryOperation = dtMachineryOperation.NewRow()
                If intRowcount = 0 And lbtnAddMachineryOperation = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnMachineryOperation = New DataColumn("MachineryOperationID", System.Type.[GetType]("System.String"))
                        dtMachineryOperation.Columns.Add(columnMachineryOperation)
                        columnMachineryOperation = New DataColumn("MachineName", System.Type.[GetType]("System.String"))
                        dtMachineryOperation.Columns.Add(columnMachineryOperation)
                        columnMachineryOperation = New DataColumn("MachineID", System.Type.[GetType]("System.String"))
                        dtMachineryOperation.Columns.Add(columnMachineryOperation)
                        columnMachineryOperation = New DataColumn("MeterFrom", System.Type.[GetType]("System.String"))
                        dtMachineryOperation.Columns.Add(columnMachineryOperation)
                        columnMachineryOperation = New DataColumn("MeterTo", System.Type.[GetType]("System.String"))
                        dtMachineryOperation.Columns.Add(columnMachineryOperation)
                        columnMachineryOperation = New DataColumn("Processhours", System.Type.[GetType]("System.String"))
                        dtMachineryOperation.Columns.Add(columnMachineryOperation)
                        columnMachineryOperation = New DataColumn("NonProcessHours", System.Type.[GetType]("System.String"))
                        dtMachineryOperation.Columns.Add(columnMachineryOperation)
                        columnMachineryOperation = New DataColumn("TotalHours", System.Type.[GetType]("System.String"))
                        dtMachineryOperation.Columns.Add(columnMachineryOperation)
                        columnMachineryOperation = New DataColumn("MonthTodateHrs", System.Type.[GetType]("System.String"))
                        dtMachineryOperation.Columns.Add(columnMachineryOperation)
                        columnMachineryOperation = New DataColumn("YearTodateHrs", System.Type.[GetType]("System.String"))
                        dtMachineryOperation.Columns.Add(columnMachineryOperation)


                    Catch ex As Exception
                    End Try
                    If lMachineryOperationID <> String.Empty Then
                        rowMachineryOperation("MachineryOperationID") = lMachineryOperationID
                    End If

                    rowMachineryOperation("MachineName") = ddlMachineName.Text
                    rowMachineryOperation("MachineID") = ddlMachineName.SelectedValue.ToString
                    rowMachineryOperation("MeterFrom") = txtMOHMeterFrom.Text
                    rowMachineryOperation("MeterTo") = txtMOHMeterTo.Text
                    rowMachineryOperation("Processhours") = txtMOHProcessHours.Text
                    rowMachineryOperation("NonProcesshours") = txtMOHNonProcessHours.Text
                    rowMachineryOperation("Totalhours") = txtMOHTotalHours.Text
                    rowMachineryOperation("MonthTodateHrs") = txtMOHMonthToDate.Text
                    rowMachineryOperation("YearTodateHrs") = txtMOHYearToDate.Text

                    dtMachineryOperation.Rows.InsertAt(rowMachineryOperation, intRowcount)
                    dgvMachineryOperation.AutoGenerateColumns = False



                Else

                    If lMachineryOperationID <> String.Empty Then
                        rowMachineryOperation("MachineryOperationID") = lMachineryOperationID
                    End If

                    rowMachineryOperation("MachineName") = ddlMachineName.Text
                    rowMachineryOperation("MachineID") = ddlMachineName.SelectedValue.ToString
                    rowMachineryOperation("MeterFrom") = txtMOHMeterFrom.Text
                    rowMachineryOperation("MeterTo") = txtMOHMeterTo.Text
                    rowMachineryOperation("Processhours") = txtMOHProcessHours.Text
                    rowMachineryOperation("NonProcesshours") = txtMOHNonProcessHours.Text
                    rowMachineryOperation("Totalhours") = txtMOHTotalHours.Text
                    rowMachineryOperation("MonthTodateHrs") = txtMOHMonthToDate.Text
                    rowMachineryOperation("YearTodateHrs") = txtMOHYearToDate.Text

                    dtMachineryOperation.Rows.InsertAt(rowMachineryOperation, intRowcount)
                    dgvMachineryOperation.AutoGenerateColumns = False

                End If
                dgvMachineryOperation.DataSource = dtMachineryOperation
                ClearMachineryOperation()
                ddlMachineName.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg46")
                ''MsgBox("Machine Name already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataMachineryOperation()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try


            If lMachineName = ddlMachineName.SelectedValue.ToString Then
                Dim intCount As Integer = dgvMachineryOperation.CurrentRow.Index

                dgvMachineryOperation.Rows(intCount).Cells("dgclMachineryOperationID").Value = lMachineryOperationID
                dgvMachineryOperation.Rows(intCount).Cells("dgclMOHMachineName").Value = ddlMachineName.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclMOHMachineID").Value = ddlMachineName.SelectedValue.ToString
                dgvMachineryOperation.Rows(intCount).Cells("dgclMOHMeterFrom").Value = txtMOHMeterFrom.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclMeterTo").Value = txtMOHMeterTo.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclProcesshours").Value = txtMOHProcessHours.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclNonProcessHours").Value = txtMOHNonProcessHours.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclTotalHoursToday").Value = txtMOHTotalHours.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclMonthTodatehrs").Value = txtMOHMonthToDate.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclYearTodateHrs").Value = txtMOHYearToDate.Text


                ClearMachineryOperation()
                ddlMachineName.SelectedIndex = 0
            ElseIf Not MachineNameExistInMachineryOperation(ddlMachineName.SelectedValue.ToString) Then
                Dim intCount As Integer = dgvMachineryOperation.CurrentRow.Index

                dgvMachineryOperation.Rows(intCount).Cells("dgclMachineryOperationID").Value = lMachineryOperationID
                dgvMachineryOperation.Rows(intCount).Cells("dgclMOHMachineName").Value = ddlMachineName.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclMOHMachineID").Value = ddlMachineName.SelectedValue.ToString
                dgvMachineryOperation.Rows(intCount).Cells("dgclMOHMeterFrom").Value = txtMOHMeterFrom.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclMeterTo").Value = txtMOHMeterTo.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclProcesshours").Value = txtMOHProcessHours.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclNonProcessHours").Value = txtMOHNonProcessHours.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclTotalHoursToday").Value = txtMOHTotalHours.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclMonthTodatehrs").Value = txtMOHMonthToDate.Text
                dgvMachineryOperation.Rows(intCount).Cells("dgclYearTodateHrs").Value = txtMOHYearToDate.Text

                ClearMachineryOperation()
                ddlMachineName.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg46")
                ''MsgBox("Machine Name already exist", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesMachineryOperation()

        If dgvMachineryOperation.RowCount > 0 Then

            ClearMachineryOperation()
            If GlobalPPT.strLang = "en" Then
                btnMachinelogAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnMachinelogAdd.Text = "Memperbarui"
            End If
            ''btnMachinelogAdd.Text = "Update"
            lbtnAddMachineryOperation = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvMachineryOperation.SelectedRows(0).Cells("dgclMachineryOperationID").Value IsNot Nothing Or dgvMachineryOperation.SelectedRows(0).Cells("dgclMachineryOperationID").Value.ToString <> String.Empty Then
                    Me.lMachineryOperationID = dgvMachineryOperation.SelectedRows(0).Cells("dgclMachineryOperationID").Value.ToString
                End If
            End If

            ddlMachineName.Text = Me.dgvMachineryOperation.SelectedRows(0).Cells("dgclMOHMachinename").Value.ToString
            lMachineName = Me.dgvMachineryOperation.SelectedRows(0).Cells("dgclMOHMachineID").Value.ToString
            txtMOHMeterFrom.Text = Me.dgvMachineryOperation.SelectedRows(0).Cells("dgclMOHMeterFrom").Value.ToString
            txtMOHMeterTo.Text = Me.dgvMachineryOperation.SelectedRows(0).Cells("dgclMeterTo").Value.ToString
            txtMOHProcessHours.Text = Me.dgvMachineryOperation.SelectedRows(0).Cells("dgclProcesshours").Value.ToString
            txtMOHNonProcessHours.Text = Me.dgvMachineryOperation.SelectedRows(0).Cells("dgclNonProcessHours").Value.ToString
            txtMOHTotalHours.Text = Me.dgvMachineryOperation.SelectedRows(0).Cells("dgclTotalHourstoday").Value.ToString
            lPrevHrs = Me.dgvMachineryOperation.SelectedRows(0).Cells("dgclTotalHourstoday").Value.ToString
            txtMOHMonthToDate.Text = Me.dgvMachineryOperation.SelectedRows(0).Cells("dgclMonthTodateHrs").Value.ToString
            txtMOHYearToDate.Text = Me.dgvMachineryOperation.SelectedRows(0).Cells("dgclYearTodateHrs").Value.ToString


        End If

    End Sub
    Private Sub ClearMachineryOperation()
        ' ddlMachineName.SelectedIndex = 0
        txtMOHMeterFrom.Text = String.Empty
        txtMOHMeterTo.Text = String.Empty
        txtMOHProcessHours.Text = String.Empty
        txtMOHNonProcessHours.Text = String.Empty
        txtMOHTotalHours.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnMachinelogAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnMachinelogAdd.Text = "Menambahkan"
        End If

        '' btnMachinelogAdd.Text = "Add"
        lbtnAddMachineryOperation = "Add"
        lMachineName = ""
        lMachineryOperationID = ""
        txtMOHMonthToDate.Text = "00:00"
        txtMOHYearToDate.Text = "00:00"
    End Sub

    '''Boiler Water Analysis

    Private Function IsBWAValidAdd()


        If ddlBWADescp.Text = "--Select--" Then
            DisplayInfoMessage("Msg16")
            ''MessageBox.Show("This field is required.", "Description")
            ddlBWADescp.Focus()
            Return True
        End If
        If ddlBWAAmount.Text = "--Select--" Then
            DisplayInfoMessage("Msg2")
            ''MessageBox.Show("This field is required.", "Type")
            ddlBWAAmount.Focus()
            Return True
        End If
        If Val(txtBWAValue.Text) = 0 Then
            DisplayInfoMessage("Msg47")
            ''MessageBox.Show("This field is required.", "Value")
            txtBWAValue.Focus()
            Return True
        End If
        Return False
    End Function
    Private Function BWAExistInBWA(ByVal Descp As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvBoilerWaterAnalysis.Rows
                If Descp = objDataGridViewRow.Cells("dgclBWADescp").Value.ToString() Then
                    ddlBWADescp.SelectedIndex = 0
                    ddlBWADescp.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataBWA()


        Dim intRowcount As Integer = dtBWA.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not BWAExistInBWA(ddlBWADescp.Text) Then
                rowBWA = dtBWA.NewRow()
                If intRowcount = 0 And lbtnAddBWA = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnBWA = New DataColumn("LabBoilerWaterAnalysisID", System.Type.[GetType]("System.String"))
                        dtBWA.Columns.Add(columnBWA)
                        columnBWA = New DataColumn("Description", System.Type.[GetType]("System.String"))
                        dtBWA.Columns.Add(columnBWA)
                        columnBWA = New DataColumn("Type", System.Type.[GetType]("System.String"))
                        dtBWA.Columns.Add(columnBWA)
                        columnBWA = New DataColumn("Value", System.Type.[GetType]("System.String"))
                        dtBWA.Columns.Add(columnBWA)


                    Catch ex As Exception
                    End Try

                    If llabBoilerWaterAnalysisID <> String.Empty Then
                        rowBWA("LabBoilerWaterAnalysisID") = llabBoilerWaterAnalysisID
                    End If


                    rowBWA("Description") = ddlBWADescp.Text
                    rowBWA("Type") = ddlBWAAmount.Text
                    rowBWA("Value") = txtBWAValue.Text

                    dtBWA.Rows.InsertAt(rowBWA, intRowcount)
                    dgvBoilerWaterAnalysis.AutoGenerateColumns = False


                Else

                    If llabBoilerWaterAnalysisID <> String.Empty Then
                        rowBWA("LabBoilerWaterAnalysisID") = llabBoilerWaterAnalysisID
                    End If


                    rowBWA("Description") = ddlBWADescp.Text
                    rowBWA("Type") = ddlBWAAmount.Text
                    rowBWA("Value") = txtBWAValue.Text

                    dtBWA.Rows.InsertAt(rowBWA, intRowcount)
                    dgvBoilerWaterAnalysis.AutoGenerateColumns = False

                End If
                dgvBoilerWaterAnalysis.DataSource = dtBWA

                ClearBoilWaterAnalysis()

            Else
                DisplayInfoMessage("Msg48")
                ''MsgBox("Description already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataBWA()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try


            If lBWADescp = ddlBWADescp.Text Then
                Dim intCount As Integer = dgvBoilerWaterAnalysis.CurrentRow.Index

                dgvBoilerWaterAnalysis.Rows(intCount).Cells("dgLabBoilerWaterID").Value = llabBoilerWaterAnalysisID
                dgvBoilerWaterAnalysis.Rows(intCount).Cells("dgclBWADescp").Value = ddlBWADescp.Text
                dgvBoilerWaterAnalysis.Rows(intCount).Cells("dgclBWAAmount").Value = ddlBWAAmount.Text
                dgvBoilerWaterAnalysis.Rows(intCount).Cells("dgclBWAValue").Value = txtBWAValue.Text


                ClearBoilWaterAnalysis()

            ElseIf Not BWAExistInBWA(ddlBWADescp.Text) Then
                Dim intCount As Integer = dgvBoilerWaterAnalysis.CurrentRow.Index

                dgvBoilerWaterAnalysis.Rows(intCount).Cells("dgLabBoilerWaterID").Value = llabBoilerWaterAnalysisID
                dgvBoilerWaterAnalysis.Rows(intCount).Cells("dgclBWADescp").Value = ddlBWADescp.Text
                dgvBoilerWaterAnalysis.Rows(intCount).Cells("dgclBWAAmount").Value = ddlBWAAmount.Text
                dgvBoilerWaterAnalysis.Rows(intCount).Cells("dgclBWAValue").Value = txtBWAValue.Text

                ClearBoilWaterAnalysis()
            Else
                DisplayInfoMessage("Msg48")
                ''MsgBox("Description already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesBWA()

        If dgvBoilerWaterAnalysis.RowCount > 0 Then

            ClearEfficiencyripleMill()

            If GlobalPPT.strLang = "en" Then
                btnBWAAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnBWAAdd.Text = "Memperbarui"
            End If

            ''btnBWAAdd.Text = "Update"
            lbtnAddBWA = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvBoilerWaterAnalysis.SelectedRows(0).Cells("dgLabBoilerWaterID").Value IsNot Nothing Or dgvBoilerWaterAnalysis.SelectedRows(0).Cells("dgLabBoilerWaterID").Value.ToString <> String.Empty Then
                    Me.llabBoilerWaterAnalysisID = dgvBoilerWaterAnalysis.SelectedRows(0).Cells("dgLabBoilerWaterID").Value.ToString
                End If
            End If

            lBWADescp = Me.dgvBoilerWaterAnalysis.SelectedRows(0).Cells("dgclBWADescp").Value.ToString
            ddlBWADescp.Text = Me.dgvBoilerWaterAnalysis.SelectedRows(0).Cells("dgclBWADescp").Value.ToString
            ddlBWAAmount.Text = Me.dgvBoilerWaterAnalysis.SelectedRows(0).Cells("dgclBWAAmount").Value.ToString
            txtBWAValue.Text = Me.dgvBoilerWaterAnalysis.SelectedRows(0).Cells("dgclBWAValue").Value.ToString
        End If

    End Sub
    Private Sub ClearBoilWaterAnalysis()
        ddlBWADescp.SelectedIndex = 0
        ddlBWAAmount.SelectedIndex = 0
        txtBWAValue.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnBWAAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnBWAAdd.Text = "Menambahkan"
        End If

        ''btnBWAAdd.Text = "Add"
        lbtnAddBWA = "Add"
        lBWADescp = ""
        llabBoilerWaterAnalysisID = ""
    End Sub

    '''Softner



    Private Function IsSoftnerValidAdd()


        If ddlSoftnerDescp.Text = "--Select--" Then
            DisplayInfoMessage("Msg16")
            ''MessageBox.Show("This field is required.", "Description")
            ddlSoftnerDescp.Focus()
            Return True
        End If
        If txtSoftnerType.Text = "" Then
            DisplayInfoMessage("Msg2")
            ''MessageBox.Show("This field is required.", "Type")
            txtSoftnerType.Focus()
            Return True
        End If
        If Val(txtSoftDosage.Text) = 0 Then
            DisplayInfoMessage("Msg49")
            ''MessageBox.Show("This field is required.", "dosage")
            txtSoftDosage.Focus()
            Return True
        End If
        Return False
    End Function
    Private Function SoftnerDescpInSoftner(ByVal Descp As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvSoftner.Rows
                If Descp = objDataGridViewRow.Cells("dgclSoftnerDescp").Value.ToString() Then
                    ddlSoftnerDescp.SelectedIndex = 0
                    ddlSoftnerDescp.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub AddMultipleEntryDataSoftner()


        Dim intRowcount As Integer = dtSoftner.Rows.Count
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If Not SoftnerDescpInSoftner(ddlSoftnerDescp.Text) Then
                rowSoftner = dtSoftner.NewRow()
                If intRowcount = 0 And lbtnAddSoftner = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnSoftner = New DataColumn("LabSoftnerID", System.Type.[GetType]("System.String"))
                        dtSoftner.Columns.Add(columnSoftner)
                        columnSoftner = New DataColumn("Description", System.Type.[GetType]("System.String"))
                        dtSoftner.Columns.Add(columnSoftner)
                        columnSoftner = New DataColumn("Type", System.Type.[GetType]("System.String"))
                        dtSoftner.Columns.Add(columnSoftner)
                        columnSoftner = New DataColumn("Dosage", System.Type.[GetType]("System.String"))
                        dtSoftner.Columns.Add(columnSoftner)
                        columnSoftner = New DataColumn("Anion", System.Type.[GetType]("System.String"))
                        dtSoftner.Columns.Add(columnSoftner)

                    Catch ex As Exception
                    End Try

                    If lLabSoftnerID <> String.Empty Then
                        rowSoftner("LabSoftnerID") = llabBoilerWaterAnalysisID
                    End If


                    rowSoftner("Description") = ddlSoftnerDescp.Text
                    rowSoftner("Type") = txtSoftnerType.Text
                    rowSoftner("Dosage") = txtSoftDosage.Text
                    rowSoftner("Anion") = txtAnion.Text

                    dtSoftner.Rows.InsertAt(rowSoftner, intRowcount)
                    dgvSoftner.AutoGenerateColumns = False


                Else

                    If lLabSoftnerID <> String.Empty Then
                        rowSoftner("LabSoftnerID") = llabBoilerWaterAnalysisID
                    End If


                    rowSoftner("Description") = ddlSoftnerDescp.Text
                    rowSoftner("Type") = txtSoftnerType.Text
                    rowSoftner("Dosage") = txtSoftDosage.Text
                    rowSoftner("Anion") = txtAnion.Text
                    dtSoftner.Rows.InsertAt(rowSoftner, intRowcount)
                    dgvSoftner.AutoGenerateColumns = False

                End If
                dgvSoftner.DataSource = dtSoftner

                ClearSoftner()

            Else
                DisplayInfoMessage("Msg48")
                ''MsgBox("Description already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UpDateMultipleEntryDataSoftner()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL

        Try

            If lSoftnerDescp = ddlSoftnerDescp.Text Then
                Dim intCount As Integer = dgvSoftner.CurrentRow.Index

                dgvSoftner.Rows(intCount).Cells("dgLabSoftnerID").Value = lLabSoftnerID
                dgvSoftner.Rows(intCount).Cells("dgclSoftnerDescp").Value = ddlSoftnerDescp.Text
                dgvSoftner.Rows(intCount).Cells("dgclSoftnerType").Value = txtSoftnerType.Text
                dgvSoftner.Rows(intCount).Cells("dgclSoftnerDosage").Value = txtSoftDosage.Text
                dgvSoftner.Rows(intCount).Cells("dgcAnion").Value = txtAnion.Text

                ClearSoftner()

            ElseIf Not SoftnerDescpInSoftner(ddlSoftnerDescp.Text) Then
                Dim intCount As Integer = dgvSoftner.CurrentRow.Index

                dgvSoftner.Rows(intCount).Cells("dgLabSoftnerID").Value = lLabSoftnerID
                dgvSoftner.Rows(intCount).Cells("dgclSoftnerDescp").Value = ddlSoftnerDescp.Text
                dgvSoftner.Rows(intCount).Cells("dgclSoftnerType").Value = txtSoftnerType.Text
                dgvSoftner.Rows(intCount).Cells("dgclSoftnerDosage").Value = txtSoftDosage.Text
                dgvSoftner.Rows(intCount).Cells("dgcAnion").Value = txtAnion.Text

                ClearSoftner()
            Else
                DisplayInfoMessage("Msg48")
                ''MsgBox("Description already exist ", MsgBoxStyle.Critical, "BSP-Message")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MultipleDateEntryValuesSoftner()

        If dgvSoftner.RowCount > 0 Then

            ClearSoftner()
            If GlobalPPT.strLang = "en" Then
                btnSoftnerAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSoftnerAdd.Text = "Memperbarui"
            End If

            '' btnSoftnerAdd.Text = "Update"
            lbtnAddSoftner = "Update"

            If Not lBtnSaveAll = "Save All" Then
                If dgvSoftner.SelectedRows(0).Cells("dgLabSoftnerID").Value IsNot Nothing Or dgvSoftner.SelectedRows(0).Cells("dgLabSoftnerID").Value.ToString <> String.Empty Then
                    Me.lLabSoftnerID = dgvSoftner.SelectedRows(0).Cells("dgLabSoftnerID").Value.ToString
                End If
            End If

            lSoftnerDescp = Me.dgvSoftner.SelectedRows(0).Cells("dgclSoftnerDescp").Value.ToString
            ddlSoftnerDescp.Text = Me.dgvSoftner.SelectedRows(0).Cells("dgclSoftnerDescp").Value.ToString
            txtSoftnerType.Text = Me.dgvSoftner.SelectedRows(0).Cells("dgclSoftnerType").Value.ToString
            txtSoftDosage.Text = Me.dgvSoftner.SelectedRows(0).Cells("dgclSoftnerDosage").Value.ToString
        End If

    End Sub
    Private Sub ClearSoftner()
        ddlSoftnerDescp.SelectedIndex = 0
        txtSoftnerType.Text = String.Empty
        txtSoftDosage.Text = String.Empty
        If GlobalPPT.strLang = "en" Then
            btnSoftnerAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSoftnerAdd.Text = "Menambahkan"
        End If

        ''btnSoftnerAdd.Text = "Add"
        lbtnAddSoftner = "Add"
        lSoftnerDescp = ""
        lLabSoftnerID = ""
    End Sub


    Private Sub btnOLReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOLReset.Click
        ClearOilLosses()
        ddlEquitOilLosses.SelectedIndex = 0
        ddlEquitOilLosses.Focus()

    End Sub

    Private Sub btnKLReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKLReset.Click
        ClearKernelLosses()

        ddlEqptKernelLosses.Focus()
    End Sub

    Private Sub btnKLPCReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKLPCReset.Click
        ClearKernelLossesPCF()

        ddlLineKernelLossesPCF.Focus()
    End Sub


    Private Sub btnOLAReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOLAReset.Click
        ClearOillossesA()

        ddlEqptOilLossesA.Focus()
    End Sub


    Private Sub btnOLBReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOLBReset.Click
        ClearOillossesB()

        ddlDescpOilLossesB.Focus()
    End Sub

    Private Sub btnKernelLossReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKernelLossReset.Click
        ClearKernelLossesFFB()

        ddlKernelLossesFFBLine.Focus()
    End Sub

    Private Sub btnKernelInTakeReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKernelInTakeReset.Click
        ClearKernelInTake()

        ddlKernelIntakeSourceLocation.Focus()
    End Sub

    Private Sub btnERMReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ClearEfficiencyripleMill()

        ddlLineEffRippleMill.Focus()
    End Sub


    Private Sub btnKQSReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKQSReset.Click
        ClearKernelQtyStorage()

        ddlKernelqtyStorageLocation.Focus()
    End Sub

    Private Sub gbOQSReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbOQSReset.Click
        ClearOilQtyStorage()
        ddlProductTypeOilQtyStorage.Focus()
    End Sub


    Private Sub btnBWAReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBWAReset.Click
        ClearBoilWaterAnalysis()
        ddlBWADescp.Focus()
    End Sub

    Private Sub btnSoftnerReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoftnerReset.Click
        ClearSoftner()
        ddlSoftnerDescp.Focus()
    End Sub

    Private Sub OilLossesStationSelect()
        Dim ds As New DataSet
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        ds = LaboratoryAnalysisBOL.LabOilKernelLossesStationSearch(objLaboratoryAnalysisPPT, "Oil Losses")

        If ds.Tables(0).Rows.Count = 0 Then
            DisplayInfoMessage("Msg50")
            ''MsgBox("No Records in Station,Please Add the Records in Production-Station")
        End If
        ddlEquitOilLosses.DataSource = ds.Tables(0)
        ddlEquitOilLosses.DisplayMember = "StationDescp"
        ddlEquitOilLosses.ValueMember = "StationID"

        Dim dr As DataRow = ds.Tables(0).NewRow()
        dr(0) = "--Select--"
        dr(1) = "--Select--"
        ds.Tables(0).Rows.InsertAt(dr, 0)

        ddlEquitOilLosses.SelectedIndex = 0

     
    End Sub
    Private Sub KernelLossesStationSelect()
        Dim ds As New DataSet
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        ds = LaboratoryAnalysisBOL.LabOilKernelLossesStationSearch(objLaboratoryAnalysisPPT, "Kernel Losses")

        If ds.Tables(0).Rows.Count = 0 Then
            DisplayInfoMessage("Msg50")
            ''MsgBox("No Records in Station,Please Add the Records in Production-Station")
        End If
        ddlEqptKernelLosses.DataSource = ds.Tables(0)
        ddlEqptKernelLosses.DisplayMember = "StationDescp"
        ddlEqptKernelLosses.ValueMember = "StationID"


        Dim dr As DataRow = ds.Tables(0).NewRow()
        dr(0) = "--Select--"
        dr(1) = "--Select--"
        ds.Tables(0).Rows.InsertAt(dr, 0)

        ddlEqptKernelLosses.SelectedIndex = 0


    End Sub

    Private Sub OilQtyStorageTankSelect()
        Dim ds As New DataSet
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT

        ds = LaboratoryAnalysisBOL.LabOilQualityStorageTankNo_Select(objLaboratoryAnalysisPPT)
        If ds.Tables(0).Rows.Count = 0 Then
            DisplayInfoMessage("Msg51")
            ''MsgBox("No Records in Tank Master,Please Add the Records in Production-Tank Master")
        End If
        ddlTankOilQtyStorage.DataSource = ds.Tables(0)
        ddlTankOilQtyStorage.DisplayMember = "TankNo"
        ddlTankOilQtyStorage.ValueMember = "TankID"

        Dim dr As DataRow = ds.Tables(0).NewRow()
        dr(0) = "--Select--"
        dr(1) = "--Select--"
        ds.Tables(0).Rows.InsertAt(dr, 0)
        ddlTankOilQtyStorage.SelectedIndex = 0

    End Sub

    Private Sub CPOPKOFFAPSelect()
        Dim ds As New DataSet
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        objLaboratoryAnalysisPPT.LabAnalysisDate = dtpLabAnalDate.Value
        ds = LaboratoryAnalysisBOL.LAbProductionFFAPSelect(objLaboratoryAnalysisPPT)
        If ds.Tables(0).Rows.Count > 0 Then
            CPOLFFAPMTDCalc = Val(ds.Tables(0).Rows(0).Item("MonthCPOProductionFFAP").ToString)
            PKOLFFAPMTDCalc = Val(ds.Tables(0).Rows(0).Item("MonthPKOProductionFFAP").ToString)
            TotalCPOFFAPCOUNTMonth = Val(ds.Tables(0).Rows(0).Item("CPOFFAPCOUNTMonth").ToString)
        End If
        If ds.Tables(1).Rows.Count > 0 Then
            CPOLFFAPYTDCalc = Val(ds.Tables(1).Rows(0).Item("YearCPOProductionFFAP").ToString)
            PKOLFFAPYTDCalc = Val(ds.Tables(1).Rows(0).Item("YearPKOProductionFFAP").ToString)
            TotalCPOFFAPCOUNTYear = Val(ds.Tables(1).Rows(0).Item("CPOFFAPCOUNTYear").ToString)
        End If

        FFAPMonthCount = ds.Tables(2).Rows(0).Item("FFAPMonthCount").ToString
       
        If FFAPMonthCount = 0 Or (FFAPMonthCount = 1 And lBtnSaveAll <> "Save All") Then
            txtCPOFFAToday.Enabled = True
            txtCPOFFAYear.Enabled = True
            txtPKOFFAMonth.Enabled = True
            txtPKOFFAYear.Enabled = True
        Else
            txtCPOFFAToday.Enabled = False
            txtCPOFFAYear.Enabled = False
            txtPKOFFAMonth.Enabled = False
            txtPKOFFAYear.Enabled = False
        End If



    End Sub
    Private Sub LabKeyValuePairSelect(ByVal KeyName As String, ByVal GroupBox As String)
        Dim ds As New DataSet
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        ds = LaboratoryAnalysisBOL.LabKeyValuePair_Select(KeyName)

        If KeyName = "LabNo" And GroupBox = "OilLosses" Then
            ddlNoOilLosses.DataSource = ds.Tables(0)
            ddlNoOilLosses.DisplayMember = "ValueName"
            ddlNoOilLosses.ValueMember = "ValueName"

            '  If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlNoOilLosses.SelectedIndex = 0
        ElseIf KeyName = "LabNo" And GroupBox = "KernelLosses" Then
            ddlNoKernelLosses.DataSource = ds.Tables(0)
            ddlNoKernelLosses.DisplayMember = "ValueName"
            ddlNoKernelLosses.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlNoKernelLosses.SelectedIndex = 0
        ElseIf KeyName = "LabNo" And GroupBox = "KernelLossesPCF" Then

            ddlNoKernelLossesPCF.DataSource = ds.Tables(0)
            ddlNoKernelLossesPCF.DisplayMember = "ValueName"
            ddlNoKernelLossesPCF.ValueMember = "ValueName"

            'If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlNoKernelLossesPCF.SelectedIndex = 0
        ElseIf KeyName = "LabNo" And GroupBox = "OilLossA" Then
            ddlNoOilLossesA.DataSource = ds.Tables(0)
            ddlNoOilLossesA.DisplayMember = "ValueName"
            ddlNoOilLossesA.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlNoOilLossesA.SelectedIndex = 0

        ElseIf KeyName = "LabNo" And GroupBox = "OilLossB" Then
            ddlExpStageNoOilLossB.DataSource = ds.Tables(0)
            ddlExpStageNoOilLossB.DisplayMember = "ValueName"
            ddlExpStageNoOilLossB.ValueMember = "ValueName"
            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlExpStageNoOilLossB.SelectedIndex = 0
        ElseIf KeyName = "EfficiencyEquipmentNo" Then
            ddlNoEffRippleMill.DataSource = ds.Tables(0)
            ddlNoEffRippleMill.DisplayMember = "ValueName"
            ddlNoEffRippleMill.ValueMember = "ValueName"
            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlNoEffRippleMill.SelectedIndex = 0
        ElseIf KeyName = "EfficiencyEquipment" Then
            ddlEquipment.DataSource = ds.Tables(0)
            ddlEquipment.DisplayMember = "ValueName"
            ddlEquipment.ValueMember = "ValueName"
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            ddlEquipment.SelectedIndex = 0
        End If

        If KeyName = "LabLine" And GroupBox = "OilLosses" Then
            ddlLineOilLosses.DataSource = ds.Tables(0)
            ddlLineOilLosses.DisplayMember = "ValueName"
            ddlLineOilLosses.ValueMember = "ValueName"
            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlLineOilLosses.SelectedIndex = 0
        ElseIf KeyName = "LabLine" And GroupBox = "KernelLosses" Then

            ddlLineKernelLosses.DataSource = ds.Tables(0)
            ddlLineKernelLosses.DisplayMember = "ValueName"
            ddlLineKernelLosses.ValueMember = "ValueName"
            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlLineKernelLosses.SelectedIndex = 0
        ElseIf KeyName = "LabLine" And GroupBox = "KernelLossesPCF" Then

            ddlLineKernelLossesPCF.DataSource = ds.Tables(0)
            ddlLineKernelLossesPCF.DisplayMember = "ValueName"
            ddlLineKernelLossesPCF.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If

            ddlLineKernelLossesPCF.SelectedIndex = 0
        ElseIf KeyName = "LabLine" And GroupBox = "KernelLossesFFB" Then


            ddlKernelLossesFFBLine.DataSource = ds.Tables(0)
            ddlKernelLossesFFBLine.DisplayMember = "ValueName"
            ddlKernelLossesFFBLine.ValueMember = "ValueName"
            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If

            ddlKernelLossesFFBLine.SelectedIndex = 0
        ElseIf KeyName = "LabLine" And GroupBox = "EffRippleMill" Then
            ddlLineEffRippleMill.DataSource = ds.Tables(0)
            ddlLineEffRippleMill.DisplayMember = "ValueName"
            ddlLineEffRippleMill.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlLineEffRippleMill.SelectedIndex = 0

            ddlLineKernalQuality.DataSource = ds.Tables(0)
            ddlLineKernalQuality.DisplayMember = "ValueName"
            ddlLineKernalQuality.ValueMember = "ValueName"

            ddlLineKernalQuality.SelectedIndex = 0
        End If
        If KeyName = "LabOLType" Then
            ddlTypeOilLosses.DataSource = ds.Tables(0)
            ddlTypeOilLosses.DisplayMember = "ValueName"
            ddlTypeOilLosses.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlTypeOilLosses.SelectedIndex = 0

        ElseIf KeyName = "LabEquipment" Then
            ddlEqptOilLossesA.DataSource = ds.Tables(0)
            ddlEqptOilLossesA.DisplayMember = "ValueName"
            ddlEqptOilLossesA.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlEqptOilLossesA.SelectedIndex = 0

        ElseIf KeyName = "LabDescp" Then

            ddlDescpOilLossesB.DataSource = ds.Tables(0)
            ddlDescpOilLossesB.DisplayMember = "ValueName"
            ddlDescpOilLossesB.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlDescpOilLossesB.SelectedIndex = 0

        ElseIf KeyName = "LabOLAType" Then
            ddlTypeOilLossesA.DataSource = ds.Tables(0)
            ddlTypeOilLossesA.DisplayMember = "ValueName"
            ddlTypeOilLossesA.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlTypeOilLossesA.SelectedIndex = 0
        ElseIf KeyName = "LabStage" Then

            ddlExpellaeStagetypeOilLossB.DataSource = ds.Tables(0)
            ddlExpellaeStagetypeOilLossB.DisplayMember = "ValueName"
            ddlExpellaeStagetypeOilLossB.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            '  End If
            ddlExpellaeStagetypeOilLossB.SelectedIndex = 0

        ElseIf KeyName = "LabSourceLocation" Then

            ddlKernelIntakeSourceLocation.DataSource = ds.Tables(0)
            ddlKernelIntakeSourceLocation.DisplayMember = "ValueName"
            ddlKernelIntakeSourceLocation.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlKernelIntakeSourceLocation.SelectedIndex = 0

        ElseIf KeyName = "LabProductType" Then
            ddlProductTypeOilQtyStorage.DataSource = ds.Tables(0)
            ddlProductTypeOilQtyStorage.DisplayMember = "ValueName"
            ddlProductTypeOilQtyStorage.ValueMember = "ValueName"

            'If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlProductTypeOilQtyStorage.SelectedIndex = 0

        ElseIf KeyName = "LabBWADescp" Then
            ddlBWADescp.DataSource = ds.Tables(0)
            ddlBWADescp.DisplayMember = "ValueName"
            ddlBWADescp.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlBWADescp.SelectedIndex = 0
        ElseIf KeyName = "LabBWAType" Then
            ddlBWAAmount.DataSource = ds.Tables(0)
            ddlBWAAmount.DisplayMember = "ValueName"
            ddlBWAAmount.ValueMember = "ValueName"

            'If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlBWAAmount.SelectedIndex = 0
        ElseIf KeyName = "LabKernelLocation" Then
            ddlKernelqtyStorageLocation.DataSource = ds.Tables(0)
            ddlKernelqtyStorageLocation.DisplayMember = "ValueName"
            ddlKernelqtyStorageLocation.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlKernelqtyStorageLocation.SelectedIndex = 0
        ElseIf KeyName = "LabSoftner" Then
            ddlSoftnerDescp.DataSource = ds.Tables(0)
            ddlSoftnerDescp.DisplayMember = "ValueName"
            ddlSoftnerDescp.ValueMember = "ValueName"

            ' If ds IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).NewRow()
            dr(0) = "--Select--"
            dr(1) = "--Select--"
            ds.Tables(0).Rows.InsertAt(dr, 0)
            'End If
            ddlSoftnerDescp.SelectedIndex = 0
        End If


    End Sub
    Private Sub MachinNameSelect()

        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        dsMachineName = LaboratoryAnalysisBOL.MachineryOperationMachineName_Select(objLaboratoryAnalysisPPT)

        If dsMachineName.Rows.Count = 0 Then
            DisplayInfoMessage("Msg52")
            ''MsgBox("No Records in Machinery Master,Please Add the Records in Production-Machinery Master")
        End If

        ddlMachineName.DataSource = dsMachineName
        ddlMachineName.DisplayMember = "MachineName"
        ddlMachineName.ValueMember = "MachineID"

        Dim dr As DataRow = dsMachineName.NewRow()
        dr(1) = "--Select--"
        dsMachineName.Rows.InsertAt(dr, 0)

        ddlMachineName.SelectedIndex = 0

    End Sub

    Private Sub ProductionQtyVaules()
        Dim ds As New DataSet
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        objLaboratoryAnalysisPPT.LabAnalysisDate = dtpLabAnalDate.Value
        ds = LaboratoryAnalysisBOL.LabAnalCPOPKOKernelQty_Select(objLaboratoryAnalysisPPT)

        If ds.Tables(0) IsNot Nothing And ds.Tables(0).Rows.Count > 0 Then
            txtCPOToday.Text = ds.Tables(0).Rows(0).Item("CPOQtyToday").ToString
            txtCPOMonthToDate.Text = ds.Tables(0).Rows(0).Item("CPOQtyMonthToDate").ToString
            txtCPOYearToDate.Text = ds.Tables(0).Rows(0).Item("CPOQtyYearToDate").ToString
        Else
            txtCPOToday.Text = ""
            txtCPOMonthToDate.Text = ""
            txtCPOYearToDate.Text = ""
        End If
        If ds.Tables(1) IsNot Nothing And ds.Tables(1).Rows.Count > 0 Then
            txtPKOToday.Text = ds.Tables(1).Rows(0).Item("PKOQtyToday").ToString
            txtPKOMonthToDate.Text = ds.Tables(1).Rows(0).Item("PKOQtyMonthToDate").ToString
            txtPKOYearToDate.Text = ds.Tables(1).Rows(0).Item("PKOQtyYearToDate").ToString
        Else
            txtPKOToday.Text = ""
            txtPKOMonthToDate.Text = ""
            txtPKOYearToDate.Text = ""
        End If

        If ds.Tables(2) IsNot Nothing And ds.Tables(2).Rows.Count > 0 Then
            txtKernelToday.Text = ds.Tables(2).Rows(0).Item("KernelQtyToday").ToString
            txtKernelMonthToDate.Text = ds.Tables(2).Rows(0).Item("KernelQtyMonthToDate").ToString
            txtKernelYearToDate.Text = ds.Tables(2).Rows(0).Item("KernelQtyYearToDate").ToString
        Else
            txtKernelToday.Text = ""
            txtKernelMonthToDate.Text = ""
            txtKernelYearToDate.Text = ""
        End If
    End Sub

    Private Sub CPOPKOMonthYearValues()
        'Dim ds As New DataSet
        'Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        'objLaboratoryAnalysisPPT.LabAnalysisDate = dtpLabAnalDate.Value
        'ds = LaboratoryAnalysisBOL.LabFFAPMonthYearValue_Select(objLaboratoryAnalysisPPT)

        'If ds.Tables(1) IsNot Nothing And ds.Tables(1).Rows.Count > 0 Then
        '    txtCPOFFAToday.Text = ds.Tables(1).Rows(0).Item("MonthValuesCPOFFAP").ToString
        '    txtPKOFFAMonth.Text = ds.Tables(1).Rows(0).Item("MonthValuesPKOFFAP").ToString
        '    ' Display. Value = {[Laboratory Analysis.Quality 1 Tab.FFA today*PKO Production.Production Qty(today)] + [Laboratory Analysis.Quality 1 Tab.FFA (Month to date)*PKO Production.Production Qty(Month to date)]} / PKO Production.Production Qty(Month to date)
        'Else
        '    txtCPOFFAToday.Text = ""
        '    txtPKOFFAMonth.Text = ""
        'End If
        'If ds.Tables(2) IsNot Nothing And ds.Tables(2).Rows.Count > 0 Then
        '    txtCPOFFAYear.Text = ds.Tables(2).Rows(0).Item("YearValuesCPOFFAP").ToString
        '    txtPKOFFAYear.Text = ds.Tables(2).Rows(0).Item("YearValuesPKOFFAP").ToString
        'Else
        '    txtCPOFFAYear.Text = ""
        '    txtPKOFFAYear.Text = ""
        'End If
    End Sub
    Private Sub MOHMonthYearSelect()
        Dim ds As New DataSet
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        objLaboratoryAnalysisPPT.LabAnalysisDate = dtpLabAnalDate.Value
        If ddlMachineName.SelectedIndex <> 0 Then
            objLaboratoryAnalysisPPT.MOHMachineID = ddlMachineName.SelectedValue.ToString
            ds = LaboratoryAnalysisBOL.LabMOHMonthYearHrsSelect(objLaboratoryAnalysisPPT)

        Else
            txtMOHMonthToDate.Text = "00:00"
            txtMOHYearToDate.Text = "00:00"
            txtMOHMonthToDate.Enabled = False
            txtMOHYearToDate.Enabled = False
            Exit Sub
        End If



        If ds.Tables(3) IsNot Nothing And ds.Tables(3).Rows.Count > 0 Then
            Dim lTotalSumMonthHrs As String
            Dim lMonthTodateHrsFirst As String
            lTotalSumMonthHrs = ds.Tables(3).Rows(0).Item("TotalSumMonthHrs").ToString
            lMonthTodateHrsFirst = ds.Tables(6).Rows(0).Item("MonthTodateHrsFirst").ToString

            If lTotalSumMonthHrs <> "00:00" And lMonthTodateHrsFirst <> "00:00" Then
                'Dim ProcessHrs As String
                Dim strArr(), strArr1() As String
                Dim Str, Str1 As String
                Str = lTotalSumMonthHrs
                strArr = Str.Split(":")
                Str1 = lMonthTodateHrsFirst
                strArr1 = Str1.Split(":")

                Dim Lhrs, lmin As Integer

                Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                lmin = strArr1(1) + strArr(1)

                If lmin >= 60 Then
                    lmin = lmin - 60
                    Lhrs = Lhrs + 1
                End If



                Dim Strhrs As String = "00"
                Dim StrMin As String = "00"

                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                txtMOHMonthToDate.Text = Strhrs + ":" + StrMin
            Else
                txtMOHMonthToDate.Text = ""
                txtMOHMonthToDate.Text = "00:00"
                txtMOHMonthToDate.Enabled = True
            End If

        End If


        If ds.Tables(9) IsNot Nothing And ds.Tables(9).Rows.Count > 0 Then
            Dim lTotalSumYearHrs As String
            Dim lYearTodateHrsFirst As String
            lTotalSumYearHrs = ds.Tables(9).Rows(0).Item("TotalSumYearHrs").ToString
            lYearTodateHrsFirst = ds.Tables(12).Rows(0).Item("YearTodateHrsFirst").ToString

            If lTotalSumYearHrs <> "00:00" And lYearTodateHrsFirst <> "00:00" Then
                'Dim ProcessHrs As String
                Dim strArr(), strArr1() As String
                Dim Str, Str1 As String
                Str = lTotalSumYearHrs
                strArr = Str.Split(":")
                Str1 = lYearTodateHrsFirst
                strArr1 = Str1.Split(":")

                Dim Lhrs, lmin As Integer

                Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                lmin = strArr1(1) + strArr(1)

                If lmin >= 60 Then
                    lmin = lmin - 60
                    Lhrs = Lhrs + 1
                End If



                Dim Strhrs As String = "00"
                Dim StrMin As String = "00"

                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                txtMOHYearToDate.Text = Strhrs + ":" + StrMin
            Else
                txtMOHYearToDate.Text = ""
                txtMOHYearToDate.Text = "00:00"
                txtMOHYearToDate.Enabled = True
            End If
        End If

        If txtMOHYearToDate.Text = "00:00" Then

            objLaboratoryAnalysisPPT.LabAnalysisDate = dtpLabAnalDate.Value
            ds = LaboratoryAnalysisBOL.LabMOHMonthYearHrsCheck(objLaboratoryAnalysisPPT)

            If ds.Tables(6) IsNot Nothing And ds.Tables(6).Rows.Count > 0 Then
                txtMOHYearToDate.Text = ds.Tables(6).Rows(0).Item("YearToDateHrs").ToString
            Else
                txtMOHYearToDate.Text = ""
            End If


        End If
        If txtMOHYearToDate.Text = "00:00" Then

            objLaboratoryAnalysisPPT.LabAnalysisDate = dtpLabAnalDate.Value
            ds = LaboratoryAnalysisBOL.LabMOHMonthYearHrsCheck(objLaboratoryAnalysisPPT)

            If ds.Tables(6) IsNot Nothing And ds.Tables(6).Rows.Count > 0 Then
                txtMOHYearToDate.Text = ds.Tables(6).Rows(0).Item("YearToDateHrs").ToString
            Else
                txtMOHYearToDate.Text = ""
            End If


        End If

    End Sub

    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then
            Dim i As Integer = 0
            Dim J As Integer = 0
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In grdname.Rows

                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            i = grdname.Rows.Count
            For J = 0 To i - 1
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
        End If
    End Sub


    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        tbLabAnalysis.SelectedTab = tbLaboratoryAnalysis

    End Sub
    Private Sub LabBoilerWaterDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabBoilerWater_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvBoilerWaterAnalysis.DataSource = ds.Tables(0)
            dgvBoilerWaterAnalysis.AutoGenerateColumns = False
            dtBWA = ds.Tables(0)
        End If
    End Sub
    Private Sub LabEffRippleMillDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabEffRippleMill_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvEffRippleMill.DataSource = ds.Tables(0)
            dgvEffRippleMill.AutoGenerateColumns = False
            dtEffRippleMill = ds.Tables(0)
        End If
    End Sub
    Private Sub LabKernelIntakeDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabKernelIntake_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvKernelInTake.DataSource = ds.Tables(0)
            dgvKernelInTake.AutoGenerateColumns = False
            dtKernelInTake = ds.Tables(0)
        End If
    End Sub
    Private Sub LabKernelLossesFFBDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabKernelLossesFFB_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvKernelLossesFFB.AutoGenerateColumns = False
            dgvKernelLossesFFB.DataSource = ds.Tables(0)
            dtKernelLossesFFB = ds.Tables(0)
        End If
    End Sub
    Private Sub LabKernelLossesDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabKernelLosses_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvKernelLosses.DataSource = ds.Tables(0)
            dgvKernelLosses.AutoGenerateColumns = False
            dtKernelLosses = ds.Tables(0)
        End If
    End Sub
    Private Sub LabKernelLossesPCFDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabKernelLossesPCF_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvKernelLossesPCF.DataSource = ds.Tables(0)
            dgvKernelLossesPCF.AutoGenerateColumns = False
            dtKernelLossesPCF = ds.Tables(0)
        End If
    End Sub
    Private Sub LabKernelQualityStorageDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabKernelQualityStorage_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvKernelQtyStorage.DataSource = ds.Tables(0)
            dgvKernelQtyStorage.AutoGenerateColumns = False
            dtKernelQtyStorage = ds.Tables(0)
        End If

    End Sub
    Private Sub LabOilLossesDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabOilLosses_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvOilLosses.AutoGenerateColumns = False
            dgvOilLosses.DataSource = ds.Tables(0)
            dtOilLosses = ds.Tables(0)
        End If
    End Sub
    Private Sub LabOilLossesBFFBDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabOilLossesBFFB_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvOilLossesB.AutoGenerateColumns = False
            dgvOilLossesB.DataSource = ds.Tables(0)
            dtOilLossesB = ds.Tables(0)
        End If
    End Sub
    Private Sub LabOilLossesFFBDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabOilLossesFFB_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvOilLossesA.AutoGenerateColumns = False
            dgvOilLossesA.DataSource = ds.Tables(0)
            dtOilLossesA = ds.Tables(0)
        End If
    End Sub

    Private Sub LabOilQualityStorageDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabOilQualityStorage_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvOilQtyStorage.AutoGenerateColumns = False
            dgvOilQtyStorage.DataSource = ds.Tables(0)
            dtOilQtyStorage = ds.Tables(0)
        End If
    End Sub

    Private Sub LabSoftnerDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.LabSoftner_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvSoftner.DataSource = ds.Tables(0)
            dgvSoftner.AutoGenerateColumns = False
            dtSoftner = ds.Tables(0)
        End If
    End Sub
    Private Sub MachineryOperationDG()
        Dim ds As New DataSet
        Dim ObjLaboratoryanalysis As New LaboratoryAnalysisPPT
        ObjLaboratoryanalysis.LabAnalysisID = lLabAnalysisID
        ds = LaboratoryAnalysisBOL.MachineryOperation_Select(ObjLaboratoryanalysis)
        If ds IsNot Nothing And ds.Tables(0).Rows.Count <> 0 Then
            dgvMachineryOperation.AutoGenerateColumns = False
            dgvMachineryOperation.DataSource = ds.Tables(0)
            dtMachineryOperation = ds.Tables(0)
        End If
    End Sub
    Private Sub UpdateLaboratoryAnalysis()
        If dgvLaboratoryAnalysis.Rows.Count > 0 Then

            If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSaveAll.Enabled = True
                End If
            End If



            tbLabAnalysis.SelectedTab = tbLaboratoryAnalysis
            dtpLabAnalDate.Enabled = False

            lLabAnalysisID = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgLabAnalysisID").Value.ToString
            dtpLabAnalDate.Value = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgLabAnalDate").Value.ToString
            txtFFATodayCPO.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgCPOProductionFFAP").Value.ToString
            lFFACPOPrev = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgCPOProductionFFAP").Value.ToString
            txtCPOFFAToday.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgCPOProductionFFAPMTD").Value.ToString
            txtCPOFFAYear.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgCPOProductionFFAPYTD").Value.ToString

            txtCPOMoisture.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgCPOProductionMoistureP").Value.ToString
            txtCPODirtToday.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgCPOProductionDirtP").Value.ToString
            txtMoistureTodayKer.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgKERProductionMoistureP").Value.ToString
            txtDirtTodayKer.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgKERProductionDirtP").Value.ToString
            txtBKTodayKer.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgKERProductionBrokenKernel").Value.ToString
            txtPKOFFAToday.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgPKOProductionFFAP").Value.ToString
            lFFAPKOPrev = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgPKOProductionFFAP").Value.ToString
            txtPKOFFAMonth.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgPKOProductionFFAPMTD").Value.ToString
            txtPKOFFAYear.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgPKOProductionFFAPYTD").Value.ToString

            txtPKOMoisture.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgPKOProductionMoistureP").Value.ToString
            txtPKODirt.Text = dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgPKOProductionDirtP").Value.ToString

            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "Update All"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If

            ''btnSaveAll.Text = "Update All"
            lBtnSaveAll = "Update"
            ProductionQtyVaules()
            CPOPKOFFAPSelect()
            CPOPKOMonthYearValues()
            '  MOHMonthYearSelect()
            LabBoilerWaterDG()
            LabEffRippleMillDG()
            LabKernelIntakeDG()
            LabKernelLossesFFBDG()
            LabKernelLossesDG()
            LabKernelLossesPCFDG()
            LabKernelQualityStorageDG()
            LabOilLossesDG()
            LabOilLossesBFFBDG()
            LabOilLossesFFBDG()
            LabOilQualityStorageDG()
            LabSoftnerDG()
            MachineryOperationDG()


            '***************!!!!!!--- The following lines were commented to enable updating previous laboratory data ----------
            '***************!!!!!!--- Previously user will be able to edit only the latest laboratory data --------------------
            '***************!!!!!!--- Changed on 22 March 2013 - Requested by Engersaal after discussing with REAK ------------

            'Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
            'Dim ds As New DataSet
            'ObjLaboratoryAnalysisPPT.lLabAnalysisDate = "01/01/1900"
            'ds = LaboratoryAnalysisBOL.LaboratoryAnalysis_Select(ObjLaboratoryAnalysisPPT)

            'If dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgLabAnalDate").Value.ToString <> ds.Tables(0).Rows(0).Item("LabAnalysisDate") Then
            '    btnSaveAll.Enabled = False
            '    '  DisplayInfoMessage("msg177")
            '    DisplayInfoMessage("msg176")
            'End If
        Else
            DisplayInfoMessage("Msg53")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If dgvLaboratoryAnalysis.RowCount > 0 Then
            UpdateLaboratoryAnalysis()
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LaboratoryAnalysisFrm))
        Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ds As New DataSet
        ObjLaboratoryAnalysisPPT.lLabAnalysisDate = "01/01/1900"
        ds = LaboratoryAnalysisBOL.LaboratoryAnalysis_Select(ObjLaboratoryAnalysisPPT)

        If dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgLabAnalDate").Value.ToString = ds.Tables(0).Rows(0).Item("LabAnalysisDate") Then

            ' Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
            Dim objLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL
            If dgvLaboratoryAnalysis.Rows.Count > 0 Then
                If MsgBox(rm.GetString("Msg91"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    ''If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    lLabAnalysisID = Me.dgvLaboratoryAnalysis.SelectedRows(0).Cells("dgLabAnalysisID").Value.ToString()
                    With ObjLaboratoryAnalysisPPT
                        .LabAnalysisID = lLabAnalysisID
                    End With
                    LaboratoryAnalysisBOL.LaboratoryAnalysisDelete(ObjLaboratoryAnalysisPPT)
                    BindDataGrid()
                    DisplayInfoMessage("Msg54")
                    ''MsgBox("Data Successfully Deleted!")
                    txtMOHMonthToDate.Text = ""
                    txtMOHYearToDate.Text = ""
                    txtMOHMonthToDate.Text = "00:00"
                    txtMOHYearToDate.Text = "00:00"
                End If
            Else
                DisplayInfoMessage("Msg55")
                ''MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            DisplayInfoMessage("msg177")
            '  DisplayInfoMessage("msg176")
        End If
    End Sub

    Private Sub dgvLaboratoryAnalysis_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLaboratoryAnalysis.CellDoubleClick

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdateLaboratoryAnalysis()
            End If
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If chkLabAnalDate.Checked = False Then
            DisplayInfoMessage("Msg56")
            ''MsgBox("Please Enter Criteria to Search!")
            BindDataGrid()
            Exit Sub
        Else
            BindDataGrid()
            If dgvLaboratoryAnalysis.RowCount = 0 Then
                DisplayInfoMessage("Msg57")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub

    Private Sub btnOthersClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOthersClose.Click

        Dim Datagridcheck As Boolean = False

        If (dgvOilLosses.RowCount > 0 Or dgvKernelLosses.RowCount > 0 Or dgvKernelLossesPCF.RowCount > 0 Or dgvOilLossesA.RowCount > 0 Or dgvOilLossesB.RowCount > 0 Or dgvKernelLossesFFB.RowCount > 0 Or dgvSoftner.RowCount > 0 Or dgvKernelInTake.RowCount > 0 Or dgvEffRippleMill.RowCount > 0 Or dgvKernelQtyStorage.RowCount > 0 Or dgvOilQtyStorage.RowCount > 0 Or dgvMachineryOperation.RowCount > 0 Or dgvBoilerWaterAnalysis.RowCount > 0) Then
            Datagridcheck = True
        End If

        If btnSaveAll.Enabled = True And Datagridcheck = True Then
            If MsgBox(rm.GetString("Msg90"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                tbLabAnalysis.SelectedIndex = 0
                GlobalPPT.IsButtonClose = True
                Me.Close()
            Else
                GlobalPPT.IsButtonClose = False
                Exit Sub
            End If

        Else
            Me.Close()
        End If


        'Dim Datagridcheck As Boolean = False

        'If (dgvOilLosses.RowCount > 0 Or dgvKernelLosses.RowCount > 0 Or dgvKernelLossesPCF.RowCount > 0 Or dgvOilLossesA.RowCount > 0 Or dgvOilLossesB.RowCount > 0 Or dgvKernelLossesFFB.RowCount > 0 Or dgvSoftner.RowCount > 0 Or dgvKernelInTake.RowCount > 0 Or dgvEffRippleMill.RowCount > 0 Or dgvKernelQtyStorage.RowCount > 0 Or dgvOilQtyStorage.RowCount > 0 Or dgvMachineryOperation.RowCount > 0 Or dgvBoilerWaterAnalysis.RowCount > 0) Then
        '    Datagridcheck = True
        'End If

        'If btnSaveAll.Enabled = True And Datagridcheck = True Then
        '    If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

        '        Me.Close()
        '    Else

        '        Exit Sub
        '    End If
        'Else
        '    Me.Close()

        'End If
        ''Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LaboratoryAnalysisFrm))
        ''If MsgBox(rm.GetString("Msg90"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
        ''    
        ''End If

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearKernelCPOPKOProduction()
        ClearBoilWaterAnalysis()
        ClearEfficiencyripleMill()
        ClearKernelInTake()
        ClearKernelLossesFFB()
        ClearKernelLosses()
        ClearKernelLossesPCF()
        ClearKernelQtyStorage()
        ClearOilLosses()
        ClearOillossesB()
        ClearOillossesA()
        ClearOilQtyStorage()
        ClearSoftner()
        ClearMachineryOperation()
        ddlEqptKernelLosses.SelectedIndex = 0
        ddlEquitOilLosses.SelectedIndex = 0
        ddlMachineName.SelectedIndex = 0
        ClearGridView(dgvOilLosses)
        ClearGridView(dgvKernelLosses)
        ClearGridView(dgvKernelLossesPCF)
        ClearGridView(dgvOilLossesA)
        ClearGridView(dgvOilLossesB)
        ClearGridView(dgvKernelLossesFFB)
        ClearGridView(dgvKernelInTake)
        ClearGridView(dgvEffRippleMill)
        ClearGridView(dgvKernelQtyStorage)
        ClearGridView(dgvOilQtyStorage)
        ClearGridView(dgvMachineryOperation)
        ClearGridView(dgvBoilerWaterAnalysis)
        ClearGridView(dgvSoftner)
        GlobalPPT.IsRetainFocus = False
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub

    Private Sub tbLabAnalysis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbLabAnalysis.SelectedIndexChanged

        'MachinNameSelect()
        'OilLossesStationSelect()
        'OilQtyStorageTankSelect()
        'KernelLossesStationSelect()
        'KernelPCFStationSelect()
        'CPOPKOMonthYearValues()
        'ProductionQtyVaules()
        ''MOHMonthYearSelect()
        '' CPOPKOFFAPSelect()
        'ClearKernelCPOPKOProduction()
        'ClearBoilWaterAnalysis()
        'ClearEfficiencyripleMill()
        'ClearKernelInTake()
        'ClearKernelLossesFFB()
        'ClearKernelLosses()
        'ClearKernelLossesPCF()
        'ClearKernelQtyStorage()
        'ClearOilLosses()
        'ClearOillossesB()
        'ClearOillossesA()
        'ClearOilQtyStorage()
        'ClearSoftner()

        'ClearMachineryOperation()
        'chkLabAnalDate.Checked = False
        'dtpViewLabAnalDate.Enabled = False
        'ClearGridView(dgvOilLosses)
        'ClearGridView(dgvKernelLosses)
        'ClearGridView(dgvKernelLossesPCF)
        'ClearGridView(dgvOilLossesA)
        'ClearGridView(dgvOilLossesB)
        'ClearGridView(dgvKernelLossesFFB)
        'ClearGridView(dgvKernelInTake)
        'ClearGridView(dgvEffRippleMill)
        'ClearGridView(dgvKernelQtyStorage)
        'ClearGridView(dgvOilQtyStorage)
        'ClearGridView(dgvMachineryOperation)
        'ClearGridView(dgvBoilerWaterAnalysis)
        'ClearGridView(dgvSoftner)
        'If tbLabAnalysis.SelectedIndex <> 0 Then
        '    BindDataGrid()
        'End If

        'tcLaboratoryAnalysis.SelectedIndex = 0

        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub chkLabAnalDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLabAnalDate.CheckedChanged
        If chkLabAnalDate.Checked = True Then
            dtpViewLabAnalDate.Enabled = True
        Else
            dtpViewLabAnalDate.Enabled = False
        End If
    End Sub

    Private Sub dgvKernelLosses_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKernelLosses.CellDoubleClick
        MultipleDateEntryValuesKernelLosses()
    End Sub


    Private Sub btnResetMachinelog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMachinelog.Click
        ClearMachineryOperation()
        ddlMachineName.SelectedIndex = 0
        ddlMachineName.Focus()
    End Sub


    Private Sub btnKLAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKLAdd.Click
        If IsKernelLossesValidAdd() Then Exit Sub
        If lbtnAddKernelLosses <> "Update" Then
            AddMultipleEntryDataKernelLosses()

        Else
            UpDateMultipleEntryDataKernelosses()
        End If
    End Sub
    Private Sub KernelPCFStationSelect()
        Dim Ds As New DataSet
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Ds = LaboratoryAnalysisBOL.LabKernelLossesPCFStationIDSelect()

        If Ds.Tables(0).Rows.Count <> 0 Then
            lKernelPCFStationID = Ds.Tables(0).Rows(0).Item("StationID")
        Else
            ' DisplayInfoMessage("Msg58")
            ''MsgBox("No PRESS CAKE FIBER Records ,Please insert the record in Production-Station ")
            Exit Sub
        End If



    End Sub

    Private Sub btnKLPCFAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKLPCFAdd.Click
        If lKernelPCFStationID = "" Then
            ' DisplayInfoMessage("Msg58")
            '' MsgBox("No PRESS CAKE FIBER Records ,Please insert the record in Production-Station ")
            Exit Sub
        End If
        If IsKernelLossesPCFValidAdd() Then Exit Sub
        If lbtnAddKernelLossesPCF <> "Update" Then
            AddMultipleEntryDataKernelLossesPCF()

        Else
            UpDateMultipleEntryDataKernelossesPCF()
        End If
    End Sub

    Private Sub btnOLAAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOLAAdd.Click
        If IsOilLossesAValidAdd() Then Exit Sub
        If lbtnAddOilLossesA <> "Update" Then
            AddMultipleEntryDataOilLossesA()
        Else
            UpDateMultipleEntryDataOiLossesA()
        End If
    End Sub

    Private Sub btnOLBAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOLBAdd.Click
        If IsOilLossesBValidAdd() Then Exit Sub
        If lbtnAddOilLossesB <> "Update" Then
            AddMultipleEntryDataOilLossesB()
        Else
            UpDateMultipleEntryDataOiLossesB()
        End If
    End Sub

    Private Sub btnKernelLossAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKernelLossFFBAdd.Click
        If IsKernelLossesFFBValidAdd() Then Exit Sub
        If lbtnAddKernelLossesFFB <> "Update" Then
            AddMultipleEntryDataKernelLossesFFB()
        Else
            UpDateMultipleEntryDataKernelossesFFB()
        End If
    End Sub

    Private Sub btnKernelInTakeAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKernelInTakeAdd.Click
        If IsKernelIntakeValidAdd() Then Exit Sub
        If lbtnAddKernelInTake <> "Update" Then
            AddMultipleEntryDataKernelIntake()

        Else
            UpDateMultipleEntryDataKernelIntake()
        End If
    End Sub

    Private Sub btnERMAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnERMAdd.Click
        If IsEffRippleMillValidAdd() Then Exit Sub
        If lbtnAddEffRippleMill <> "Update" Then
            AddMultipleEntryDataEffRippleMill()

        Else
            UpDateMultipleEntryDataEffRippleMill()
        End If
    End Sub

    Private Sub btnKQSAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKQSAdd.Click
        If IsKernelQtyStorageValidAdd() Then Exit Sub
        If lbtnAddKernelQtyStorage <> "Update" Then
            AddMultipleEntryDataKernelQtyStorage()

        Else
            UpDateMultipleEntryDataKernelQtyStorage()
        End If
    End Sub

    Private Sub btnOQSAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOQSAdd.Click
        If IsOilQtyStorageValidAdd() Then Exit Sub
        If lbtnAddOilQtyStorage <> "Update" Then
            AddMultipleEntryDataOilQtyStorage()

        Else
            UpDateMultipleEntryDataOilQtyStorage()
        End If
    End Sub

    Private Sub btnMachinelogAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMachinelogAdd.Click
        If IsMachineryOperationValidAdd() Then Exit Sub
        If lbtnAddMachineryOperation <> "Update" Then
            AddMultipleEntryDataMachineryOperation()

        Else
            UpDateMultipleEntryDataMachineryOperation()
        End If
    End Sub

    Private Sub btnBWAAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBWAAdd.Click
        If IsBWAValidAdd() Then Exit Sub
        If lbtnAddBWA <> "Update" Then
            AddMultipleEntryDataBWA()

        Else
            UpDateMultipleEntryDataBWA()
        End If
    End Sub

    Private Sub btnSoftnerAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoftnerAdd.Click
        If IsSoftnerValidAdd() Then Exit Sub
        If lbtnAddSoftner <> "Update" Then
            AddMultipleEntryDataSoftner()

        Else
            UpDateMultipleEntryDataSoftner()
        End If
    End Sub

    Private Sub dgvOilLosses_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOilLosses.CellDoubleClick
        MultipleDateEntryValuesOilLosses()
    End Sub

    Private Sub dgvKernelLossesPCF_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKernelLossesPCF.CellDoubleClick
        MultipleDateEntryValuesKernelLossesPCF()
    End Sub

    Private Sub dgvOilLossesA_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOilLossesA.CellDoubleClick
        MultipleDateEntryValuesOilLossesA()
    End Sub

    Private Sub dgvOilLossesB_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOilLossesB.CellDoubleClick
        MultipleDateEntryValuesOilLossesB()
    End Sub

    Private Sub dgvKernelLossesFFB_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKernelLossesFFB.CellDoubleClick
        MultipleDateEntryValuesKernelLossesFFB()
    End Sub

    Private Sub dgvKernelInTake_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKernelInTake.CellDoubleClick
        MultipleDateEntryValuesKernelIntake()
    End Sub

    Private Sub dgvEffRippleMill_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEffRippleMill.CellDoubleClick
        MultipleDateEntryValuesEffRippleMill()
    End Sub

    Private Sub dgvKernelQtyStorage_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKernelQtyStorage.CellDoubleClick
        MultipleDateEntryValuesKernelQtyStorage()
    End Sub

    Private Sub dgvOilQtyStorage_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOilQtyStorage.CellDoubleClick
        MultipleDateEntryValuesOilQtyStorage()
    End Sub

    Private Sub dgvMachineryOperation_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMachineryOperation.CellDoubleClick
        MultipleDateEntryValuesMachineryOperation()
    End Sub

    Private Sub dgvBoilerWaterAnalysis_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBoilerWaterAnalysis.CellDoubleClick
        MultipleDateEntryValuesBWA()
    End Sub

    Private Sub dgvSoftner_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSoftner.CellDoubleClick
        MultipleDateEntryValuesSoftner()
    End Sub

    Private Sub LaboratoryAnalysisFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim Datagridcheck As Boolean = False

        If (dgvOilLosses.RowCount > 0 Or dgvKernelLosses.RowCount > 0 Or dgvKernelLossesPCF.RowCount > 0 Or dgvOilLossesA.RowCount > 0 Or dgvOilLossesB.RowCount > 0 Or dgvKernelLossesFFB.RowCount > 0 Or dgvSoftner.RowCount > 0 Or dgvKernelInTake.RowCount > 0 Or dgvEffRippleMill.RowCount > 0 Or dgvKernelQtyStorage.RowCount > 0 Or dgvOilQtyStorage.RowCount > 0 Or dgvMachineryOperation.RowCount > 0 Or dgvBoilerWaterAnalysis.RowCount > 0) Then
            Datagridcheck = True
        End If

        If btnSaveAll.Enabled = True And Datagridcheck = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
            Else
                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M92"
                'mdiparent.lblMenuName.Text = "IPR"
            End If
        End If

    End Sub

    'Private Sub LaboratoryAnalysisFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    '    'Dim Datagridcheck As Boolean = False

    '    'If (dgvOilLosses.RowCount > 0 Or dgvKernelLosses.RowCount > 0 Or dgvKernelLossesPCF.RowCount > 0 Or dgvOilLossesA.RowCount > 0 Or dgvOilLossesB.RowCount > 0 Or dgvKernelLossesFFB.RowCount > 0 Or dgvSoftner.RowCount > 0 Or dgvKernelInTake.RowCount > 0 Or dgvEffRippleMill.RowCount > 0 Or dgvKernelQtyStorage.RowCount > 0 Or dgvOilQtyStorage.RowCount > 0 Or dgvMachineryOperation.RowCount > 0 Or dgvBoilerWaterAnalysis.RowCount > 0) Then
    '    '    Datagridcheck = True
    '    'End If

    '    'If btnSaveAll.Enabled = True And Datagridcheck = True And GlobalPPT.IsButtonClose = False Then
    '    '    If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
    '    '        GlobalPPT.IsRetainFocus = False
    '    '        GlobalPPT.IsButtonClose = False
    '    '    Else

    '    '        e.Cancel = True
    '    '        Me.Activate()
    '    '        GlobalPPT.IsRetainFocus = True
    '    '        mdiparent.strMenuID = "M92"

    '    '    End If
    '    'End If
    'End Sub

    Private Sub LaboratoryAnalysisFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        SetUICulture(GlobalPPT.strLang)
        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        dtpLabAnalDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        dtpViewLabAnalDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        LabKeyValuePairSelect("LabNo", "OilLosses")
        LabKeyValuePairSelect("LabNo", "KernelLosses")
        LabKeyValuePairSelect("LabNo", "KernelLossesPCF")
        LabKeyValuePairSelect("LabNo", "OilLossA")
        LabKeyValuePairSelect("LabNo", "OilLossB")
        LabKeyValuePairSelect("LabNo", "EffRippleMill")
        LabKeyValuePairSelect("EfficiencyEquipmentNo", "")
        LabKeyValuePairSelect("EfficiencyEquipment", "")

        LabKeyValuePairSelect("LabLine", "OilLosses")
        LabKeyValuePairSelect("LabLine", "KernelLosses")
        LabKeyValuePairSelect("LabLine", "KernelLossesPCF")
        LabKeyValuePairSelect("LabLine", "KernelLossesFFB")
        LabKeyValuePairSelect("LabLine", "EffRippleMill")

        LabKeyValuePairSelect("LabSoftner", "")

        LabKeyValuePairSelect("LabOLType", "")
        LabKeyValuePairSelect("LabEquipment", "")
        LabKeyValuePairSelect("LabDescp", "")
        LabKeyValuePairSelect("LabStage", "")
        LabKeyValuePairSelect("LabSourceLocation", "")
        LabKeyValuePairSelect("LabProductType", "")
        LabKeyValuePairSelect("LabBWADescp", "")
        LabKeyValuePairSelect("LabBWAType", "")
        LabKeyValuePairSelect("LabKernelLocation", "")
        LabKeyValuePairSelect("LabOLAType", "")

        tbLabAnalysis.SelectedIndex = 1


        MachinNameSelect()
        OilLossesStationSelect()
        OilQtyStorageTankSelect()
        KernelLossesStationSelect()
        KernelPCFStationSelect()
        CPOPKOMonthYearValues()
        ProductionQtyVaules()
        'MOHMonthYearSelect()
        ' CPOPKOFFAPSelect()
        ClearKernelCPOPKOProduction()
        ClearBoilWaterAnalysis()
        ClearEfficiencyripleMill()
        ClearKernelInTake()
        ClearKernelLossesFFB()
        ClearKernelLosses()
        ClearKernelLossesPCF()
        ClearKernelQtyStorage()
        ClearOilLosses()
        ClearOillossesB()
        ClearOillossesA()
        ClearOilQtyStorage()
        ClearSoftner()

        ClearMachineryOperation()
        chkLabAnalDate.Checked = False
        dtpViewLabAnalDate.Enabled = False
        ClearGridView(dgvOilLosses)
        ClearGridView(dgvKernelLosses)
        ClearGridView(dgvKernelLossesPCF)
        ClearGridView(dgvOilLossesA)
        ClearGridView(dgvOilLossesB)
        ClearGridView(dgvKernelLossesFFB)
        ClearGridView(dgvKernelInTake)
        ClearGridView(dgvEffRippleMill)
        ClearGridView(dgvKernelQtyStorage)
        ClearGridView(dgvOilQtyStorage)
        ClearGridView(dgvMachineryOperation)
        ClearGridView(dgvBoilerWaterAnalysis)
        ClearGridView(dgvSoftner)
        If tbLabAnalysis.SelectedIndex <> 0 Then
            BindDataGrid()
        End If


        'MachinNameSelect()
        'OilLossesStationSelect()
        'OilQtyStorageTankSelect()
        'LabKeyValuePairSelect()
        'KernelLossesStationSelect()
        'KernelPCFStationSelect()
        'CPOPKOMonthYearValues()
        'ClearKernelCPOPKOProduction()
        'ClearBoilWaterAnalysis()
        'ClearEfficiencyripleMill()
        'ClearKernelInTake()
        'ClearKernelLossesFFB()
        'ClearKernelLosses()
        'ClearKernelLossesPCF()
        'ClearKernelQtyStorage()
        'ClearOilLosses()
        'ClearOillossesB()
        'ClearOillossesA()
        'ClearOilQtyStorage()
        'ClearSoftner()
        'ClearMachineryOperation()
        'chkLabAnalDate.Checked = False

    End Sub

    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
               Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'tbLabAnalysis.TabPages("tbLaboratoryAnalysis").Text = rm.GetString("tbLabAnalysis.TabPages(tbLaboratoryAnalysis).Text")
            'tbLabAnalysis.TabPages("tbView").Text = rm.GetString("tbLabAnalysis.TabPages(tbView).Text")
            'PnlSearch.CaptionText = rm.GetString("SearchLaboratoryAnalysis")

            'tcLaboratoryAnalysis.TabPages("tpLossestosample").Text = rm.GetString("tcLaboratoryAnalysis.TabPages(tpLossestosample).Text")
            'tcLaboratoryAnalysis.TabPages("tpLossestoFFB").Text = rm.GetString("tcLaboratoryAnalysis.TabPages(tpLossestoFFB).Text")
            'tcLaboratoryAnalysis.TabPages("tpQuality1").Text = rm.GetString("tcLaboratoryAnalysis.TabPages(tpQuality1).Text")
            'tcLaboratoryAnalysis.TabPages("tpQuality2").Text = rm.GetString("tcLaboratoryAnalysis.TabPages(tpQuality2).Text")
            'tcLaboratoryAnalysis.TabPages("tpMachinelog").Text = rm.GetString("tcLaboratoryAnalysis.TabPages(tpMachinelog).Text")
            'tcLaboratoryAnalysis.TabPages("tpOthers").Text = rm.GetString("tcLaboratoryAnalysis.TabPages(tpOthers).Text")

            ' ''lblsearchBy.Text = rm.GetString("searchBy")
            'chkLabAnalDate.Text = rm.GetString("chkLabAnalDate")
            btnSearch.Text = rm.GetString("Search")
            'dgvLaboratoryAnalysis.Columns("dgLabAnalDate").HeaderText = rm.GetString("dgLabAnalDate")

            'gbOilLosses.Text = rm.GetString("OilLosses")
            'gbKernalLosses.Text = rm.GetString("KernalLosses")
            'gbKernallossesPresscakefibre.Text = rm.GetString("KernallossesPresscakefibre")

            ''lblDate.Text = rm.GetString("Date")
            ''lblEquipment.Text = rm.GetString("Equipment")
            ''lblType.Text = rm.GetString("Type")
            ''lblLine.Text = rm.GetString("Line")
            ''lblNo.Text = rm.GetString("No")
            ''lblActualpercent.Text = rm.GetString("Actualpercent")
            ''lblStdPercent.Text = rm.GetString("StdPercent")

            ''lblKLEquipment.Text = rm.GetString("Equipment")
            ''lblKLEfficiency.Text = rm.GetString("Efficiency")
            ''lblKLNo.Text = rm.GetString("No")
            ''lblKLLine.Text = rm.GetString("Line")
            ''lblKLLossesprecent.Text = rm.GetString("Lossesprecent")
            ''lblKLDirtpercent.Text = rm.GetString("Dirtpercent")

            ''lblKLPCLine.Text = rm.GetString("Line")
            ''lblKLPCNo.Text = rm.GetString("No")
            ''lblKLPCTotalNutPercent.Text = rm.GetString("PCTotalNutPercent")
            ''lblKLPCSamplepercent.Text = rm.GetString("Samplepercent")
            ''lblFibrepercent.Text = rm.GetString("Fibrepercent")

            btnOLAdd.Text = rm.GetString("Add")
            btnKLAdd.Text = rm.GetString("Add")
            btnKLPCFAdd.Text = rm.GetString("Add")
            btnOLReset.Text = rm.GetString("Reset")
            btnKLReset.Text = rm.GetString("Reset")
            btnKLPCReset.Text = rm.GetString("Reset")

            'dgvOilLosses.Columns("dgclStationDescp").HeaderText = rm.GetString("gStationDescp")
            'dgvOilLosses.Columns("dgclType").HeaderText = rm.GetString("gType")
            'dgvOilLosses.Columns("dgclNo").HeaderText = rm.GetString("gNo")
            'dgvOilLosses.Columns("dgclActualP").HeaderText = rm.GetString("gActualP")
            'dgvOilLosses.Columns("dgclLine").HeaderText = rm.GetString("gLine")
            'dgvOilLosses.Columns("dgclSTD").HeaderText = rm.GetString("gSTD")

            'dgvKernelLosses.Columns("dgKLStationDescp").HeaderText = rm.GetString("gStationDescp")
            'dgvKernelLosses.Columns("dgKLEfficiencyP").HeaderText = rm.GetString("gEfficiencyP")
            'dgvKernelLosses.Columns("dgKLLine").HeaderText = rm.GetString("gLine")
            'dgvKernelLosses.Columns("dgKLLossesP").HeaderText = rm.GetString("gLossesP")
            'dgvKernelLosses.Columns("dgKLNo").HeaderText = rm.GetString("gNo")
            'dgvKernelLosses.Columns("dgKLDirtP").HeaderText = rm.GetString("gDirtP")

            'dgvKernelLossesPCF.Columns("dgKLPCFLine").HeaderText = rm.GetString("gLine")
            'dgvKernelLossesPCF.Columns("dgKLPCFSample").HeaderText = rm.GetString("gSample")
            'dgvKernelLossesPCF.Columns("dgKLPCFNo").HeaderText = rm.GetString("gNo")
            'dgvKernelLossesPCF.Columns("dgKLPCFFibre").HeaderText = rm.GetString("gFibre")
            'dgvKernelLossesPCF.Columns("dgKLPCFTotalNutPercent").HeaderText = rm.GetString("gTotalNutPercent")

            'gbOillossesA.Text = rm.GetString("gbOillossesA")
            'gbOilLossesB.Text = rm.GetString("gbOilLossesB")
            'gbFFBKL.Text = rm.GetString("gbFFBKL")

            ''lblOLAEquipment.Text = rm.GetString("Equipment")
            ''lblOLANo.Text = rm.GetString("No")
            ''lblOLAType.Text = rm.GetString("Type")
            ''lblOLAActualpercent.Text = rm.GetString("Actualpercent")
            ''lblOLBDescription.Text = rm.GetString("Description")
            ''lblOLBExpellerStageNo.Text = rm.GetString("ExpellerStageNo")
            ''lblOLBExpellerStageType.Text = rm.GetString("ExpellerStageType")
            ''lblOLBAmount.Text = rm.GetString("Amount")
            ''lblFFBKLLine.Text = rm.GetString("Line")
            ''lblFFBKLLTDS2percent.Text = rm.GetString("LTDS2percent")
            ''lblHydroCycpercent.Text = rm.GetString("HydroCycpercent")
            ''lblLTDS1percent.Text = rm.GetString("LTDS1percent")
            ''lblFFBKLFibreCycpercent.Text = rm.GetString("FibreCycpercent")
            ''lblFFBKLFruitinEb.Text = rm.GetString("FruitinEb")


            btnOLAAdd.Text = rm.GetString("Add")
            btnOLAReset.Text = rm.GetString("Reset")
            btnOLBAdd.Text = rm.GetString("Add")
            btnOLBReset.Text = rm.GetString("Reset")
            btnKernelLossFFBAdd.Text = rm.GetString("Add")
            btnKernelLossReset.Text = rm.GetString("Reset")


            'dgvOilLossesA.Columns("dgclOLAEquipment").HeaderText = rm.GetString("gEquipment")
            'dgvOilLossesA.Columns("dgclOLAType").HeaderText = rm.GetString("gType")
            'dgvOilLossesA.Columns("dgclOLANo").HeaderText = rm.GetString("gNo")
            'dgvOilLossesA.Columns("dgclOLAActualpercent").HeaderText = rm.GetString("gActualpercent")


            'dgvOilLossesB.Columns("dgclOLBDescription").HeaderText = rm.GetString("gDescription")
            'dgvOilLossesB.Columns("dgclOLBExpellerStagetype").HeaderText = rm.GetString("gExpellerStagetype")
            'dgvOilLossesB.Columns("dgclOLBExpellerStageNo").HeaderText = rm.GetString("gExpellerStageNo")
            'dgvOilLossesB.Columns("dgclOLBAmount").HeaderText = rm.GetString("gAmount")

            'dgvKernelLossesFFB.Columns("dgclFFBKLLine").HeaderText = rm.GetString("gLine")
            'dgvKernelLossesFFB.Columns("dgclFFBKLLTDS1").HeaderText = rm.GetString("gLTDS1")
            'dgvKernelLossesFFB.Columns("dgclFFBKLLTDS2").HeaderText = rm.GetString("gLTDS2")
            'dgvKernelLossesFFB.Columns("dgclFFBKLFibreCyc").HeaderText = rm.GetString("gFibreCyc")
            'dgvKernelLossesFFB.Columns("dgclFFBKLHydroCyc").HeaderText = rm.GetString("gHydroCyc")
            'dgvKernelLossesFFB.Columns("dgclFFBKLFruitinFB").HeaderText = rm.GetString("gFruitinFB")


            'gbProductionQuantity.Text = rm.GetString("gbProductionQuantity")
            'gbKernelProduction.Text = rm.GetString("gbKernelProduction")
            'gbCPOProduction.Text = rm.GetString("gbCPOProduction")
            'gbPKOProduction.Text = rm.GetString("gbPKOProduction")
            'gbKernelInTake.Text = rm.GetString("gbKernelInTake")
            'gbEfficiencyripleMill.Text = rm.GetString("gbEfficiencyripleMill")



            ''lblTodaymt.Text = rm.GetString("Todaymt")
            ''lblMonthtoDate.Text = rm.GetString("MonthtoDate")
            ''lblyeartodatemt.Text = rm.GetString("yeartodatemt")
            ''lblCPO.Text = rm.GetString("CPO")
            ''lblKernel.Text = rm.GetString("Kernel")
            ''lblPKO.Text = rm.GetString("PKO")
            ''lblToday.Text = rm.GetString("Today")
            ''lblMoisture.Text = rm.GetString("Moisture")
            ''lblDirt.Text = rm.GetString("Dirt")
            ''lblBrokenkernel.Text = rm.GetString("Brokenkernel")

            ''lblCPOTodaypercent.Text = rm.GetString("Todaypercent")
            ''lblCPOMonthtodateper.Text = rm.GetString("Monthtodateper")
            ''lblCPOYeartodate.Text = rm.GetString("Yeartodate")
            ''lblCPOFFA.Text = rm.GetString("FFA")
            ''lblCPOMoisture.Text = rm.GetString("Moisture")
            ''lblCPODirt.Text = rm.GetString("Dirt")

            ''lblPKOTodaypercent.Text = rm.GetString("Todaypercent")
            ''lblPKOMonthtodate.Text = rm.GetString("Monthtodateper")
            ''lblPKOYeartodate.Text = rm.GetString("Yeartodate")
            ''lblPKOFFA.Text = rm.GetString("FFA")
            ''lblPKOMoisture.Text = rm.GetString("Moisture")
            ''lblPKODirt.Text = rm.GetString("Dirt")


            ''lblKernelSourceLocation.Text = rm.GetString("KernelSourceLocation")
            ''lblKernelReceivedTon.Text = rm.GetString("KernelReceivedTon")
            ''lblKernelInTakeBrokenKernel.Text = rm.GetString("KernelInTakeBrokenKernel")
            ''lblKernelMoisture.Text = rm.GetString("Moisture")
            ''lblKernelDirt.Text = rm.GetString("Dirt")

            ''lblERMLine.Text = rm.GetString("Line")
            ''lblERMEfficiencyPercent.Text = rm.GetString("EfficiencyPercent")
            ''lblERMNo.Text = rm.GetString("No")

            btnKernelInTakeAdd.Text = rm.GetString("Add")
            btnKernelInTakeReset.Text = rm.GetString("Reset")
            btnERMAdd.Text = rm.GetString("Add")
            btnERMReset.Text = rm.GetString("Reset")


            'dgvKernelInTake.Columns("dgclSourceLocation").HeaderText = rm.GetString("gSourceLocation")
            'dgvKernelInTake.Columns("dgclMoisture").HeaderText = rm.GetString("gMoisture")
            'dgvKernelInTake.Columns("dgclReceivedTon").HeaderText = rm.GetString("gReceivedTon")
            'dgvKernelInTake.Columns("dgclDirt").HeaderText = rm.GetString("dgclDirt")
            'dgvKernelInTake.Columns("dgclBrokenKernel").HeaderText = rm.GetString("gBrokenKernel")

            'dgvEffRippleMill.Columns("dgclERMLine").HeaderText = rm.GetString("gERMLine")
            'dgvEffRippleMill.Columns("dgclERMNo").HeaderText = rm.GetString("gERMNo")
            'dgvEffRippleMill.Columns("dgclERMEffciencyP").HeaderText = rm.GetString("gERMEffciencyP")

            'gbKernelQualityStorage.Text = rm.GetString("gbKernelQualityStorage")
            'gbOilQualityStorage.Text = rm.GetString("gbOilQualityStorage")

            ''lblKQSLocation.Text = rm.GetString("Location")
            ''lblKQSDirt.Text = rm.GetString("Dirt")
            ''lblKQSMoisture.Text = rm.GetString("Moisture")
            ''lblKQSBrokenKernel.Text = rm.GetString("BrokenKernel")
            ''lblOQSProductType.Text = rm.GetString("ProductType")
            ''lblOQSFFA.Text = rm.GetString("FFA")
            ''lblOQSDirt.Text = rm.GetString("Dirt")
            ''lblOQSTank.Text = rm.GetString("Tank")
            ''lblOQSMoisture.Text = rm.GetString("Moisture")


            btnKQSAdd.Text = rm.GetString("Add")
            btnKQSReset.Text = rm.GetString("Reset")
            btnOQSAdd.Text = rm.GetString("Add")
            gbOQSReset.Text = rm.GetString("Reset")



            'dgvKernelQtyStorage.Columns("dgclKQSLocation").HeaderText = rm.GetString("gLocation")
            'dgvKernelQtyStorage.Columns("dgclKQSMoisture").HeaderText = rm.GetString("gMoisture")
            'dgvKernelQtyStorage.Columns("dgclKQSDirtP").HeaderText = rm.GetString("gDirt")
            'dgvKernelQtyStorage.Columns("dgclKQSBrokenKernel").HeaderText = rm.GetString("gBrokenKernel")

            'dgvOilQtyStorage.Columns("dgclOQSProductType").HeaderText = rm.GetString("gProductType")
            'dgvOilQtyStorage.Columns("dgclOQSTank").HeaderText = rm.GetString("gTank")
            'dgvOilQtyStorage.Columns("dgclOQSFFA").HeaderText = rm.GetString("gFFA")
            'dgvOilQtyStorage.Columns("dgclOQSMoisture").HeaderText = rm.GetString("gMoisture")
            'dgvOilQtyStorage.Columns("dgclOQSDirt").HeaderText = rm.GetString("gDirt")

            'gbMachineryOperationHours.Text = rm.GetString("MachineryOperationHours")

            ''lblMOHMachineName.Text = rm.GetString("MachineName")
            ''lblMOHMeterFrom.Text = rm.GetString("MeterFrom")
            ''lblMOHTotalHours.Text = rm.GetString("TotalHours")
            ''lblMOHMeterTo.Text = rm.GetString("MeterTo")
            ''lblMOHMonthToDate.Text = rm.GetString("MOHMonthToDate")
            ''lblMOHProcessHours.Text = rm.GetString("ProcessHours")
            ''lblMOHYearToDate.Text = rm.GetString("MOHYearToDate")
            ''lblMOHNonProcessHours.Text = rm.GetString("NonProcessHours")
            btnMachinelogAdd.Text = rm.GetString("Add")
            btnResetMachinelog.Text = rm.GetString("Reset")
            btnReset.Text = rm.GetString("ResetAll")
            'dgvMachineryOperation.Columns("dgclMOHMachineName").HeaderText = rm.GetString("MachineName")
            'dgvMachineryOperation.Columns("dgclMOHMeterFrom").HeaderText = rm.GetString("MeterFrom")
            'dgvMachineryOperation.Columns("dgclMeterTo").HeaderText = rm.GetString("MeterTo")
            'dgvMachineryOperation.Columns("dgclProcessHours").HeaderText = rm.GetString("ProcessHours")
            'dgvMachineryOperation.Columns("dgclNonProcessHours").HeaderText = rm.GetString("NonProcessHours")
            'dgvMachineryOperation.Columns("dgclTotalHourstoday").HeaderText = rm.GetString("gTotalHourstoday")
            'dgvMachineryOperation.Columns("dgclMonthTodateHrs").HeaderText = rm.GetString("gMonthTodateHrs")
            'dgvMachineryOperation.Columns("dgclYearTodateHrs").HeaderText = rm.GetString("gYearTodateHrs")


            'gbBoilerWaterAnalysis.Text = rm.GetString("BoilerWaterAnalysis")
            'gbSoftner.Text = rm.GetString("Softner")

            ''lblBWADescription.Text = rm.GetString("Description")
            ''lblBWAAmount.Text = rm.GetString("Amount")
            ''lblBWAValue.Text = rm.GetString("Value")
            ''lblSoftDescription.Text = rm.GetString("Description")
            ''lblSoftDosage.Text = rm.GetString("Dosage")
            ''lblSoftType.Text = rm.GetString("Type")

            btnBWAAdd.Text = rm.GetString("Add")
            btnBWAReset.Text = rm.GetString("Reset")
            btnSoftnerAdd.Text = rm.GetString("Add")
            btnSoftnerReset.Text = rm.GetString("Reset")
            btnOthersClose.Text = rm.GetString("Close")

            'dgvBoilerWaterAnalysis.Columns("dgclBWADescp").HeaderText = rm.GetString("Description")
            'dgvBoilerWaterAnalysis.Columns("dgclBWAAmount").HeaderText = rm.GetString("Type")
            'dgvBoilerWaterAnalysis.Columns("dgclBWAValue").HeaderText = rm.GetString("Value")


            'dgvSoftner.Columns("dgclSoftnerDescp").HeaderText = rm.GetString("Description")
            'dgvSoftner.Columns("dgclSoftnerType").HeaderText = rm.GetString("Type")
            'dgvSoftner.Columns("dgclSoftnerDosage").HeaderText = rm.GetString("Dosage")



        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LaboratoryAnalysisFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
    Private Function IsSaveValid()
        If txtMoistureTodayKer.Text = String.Empty Then
            DisplayInfoMessage("Msg59")
            ''MessageBox.Show("This Field is required ", "Kernel Moisture")
            tcLaboratoryAnalysis.SelectedIndex = 2
            txtMoistureTodayKer.Focus()
            Return False
        End If
        If txtDirtTodayKer.Text = String.Empty Then
            DisplayInfoMessage("Msg60")
            ''MessageBox.Show("This Field is required ", "Kernel Dirt")
            tcLaboratoryAnalysis.SelectedIndex = 2
            txtDirtTodayKer.Focus()
            Return False
        End If

        If txtBKTodayKer.Text = String.Empty Then
            DisplayInfoMessage("Msg61")
            ''MessageBox.Show("This Field is required ", "Broken Kernel")
            tcLaboratoryAnalysis.SelectedIndex = 2
            txtBKTodayKer.Focus()
            Return False
        End If

        If txtFFATodayCPO.Text = String.Empty Then
            DisplayInfoMessage("Msg62")
            ''MessageBox.Show("This Field is required ", "CPO FFA")
            tcLaboratoryAnalysis.SelectedIndex = 2
            txtFFATodayCPO.Focus()
            Return False
        End If

        If txtCPOMoisture.Text = String.Empty Then
            DisplayInfoMessage("Msg63")
            ''MessageBox.Show("This Field is required ", "CPO Moisture")
            tcLaboratoryAnalysis.SelectedIndex = 2
            txtCPOMoisture.Focus()
            Return False
        End If

        If txtCPODirtToday.Text = String.Empty Then
            DisplayInfoMessage("Msg64")
            ''MessageBox.Show("This Field is required ", "CPO Dirt")
            tcLaboratoryAnalysis.SelectedIndex = 2
            txtCPODirtToday.Focus()
            Return False
        End If

        If txtPKOFFAToday.Text = String.Empty Then
            DisplayInfoMessage("Msg65")
            ''MessageBox.Show("This Field is required ", "PKO FFA")
            tcLaboratoryAnalysis.SelectedIndex = 2
            txtPKOFFAToday.Focus()
            Return False
        End If

        If txtPKOMoisture.Text = String.Empty Then
            DisplayInfoMessage("Msg66")
            ''MessageBox.Show("This Field is required ", "PKO Moisture")
            tcLaboratoryAnalysis.SelectedIndex = 2
            txtPKOMoisture.Focus()
            Return False
        End If

        If txtPKODirt.Text = String.Empty Then
            DisplayInfoMessage("Msg67")
            ''MessageBox.Show("This Field is required ", "PKO Dirt")
            tcLaboratoryAnalysis.SelectedIndex = 2
            txtPKODirt.Focus()
            Return False
        End If

        'If dgvOilLosses.Rows.Count = 0 Then
        '    DisplayInfoMessage("Msg68")
        '    ''MsgBox("Oil Losses Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 0
        '    ddlEquitOilLosses.Focus()
        '    Return False
        'End If

        'If dgvKernelLosses.Rows.Count = 0 Then
        '    MsgBox("Kernel Losses Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 0
        '    ddlEqptKernelLosses.Focus()
        '    Return False
        'End If
        ''If dgvKernelLossesPCF.Rows.Count = 0 Then
        ''    MsgBox("Kernel Losses PCF Field is Required")
        ''    tcLaboratoryAnalysis.SelectedIndex = 0
        ''    ddlLineKernelLossesPCF.Focus()
        ''    Return False
        ''End If
        'If dgvOilLossesA.Rows.Count = 0 Then
        '    MsgBox("Oil Losses A Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 1
        '    ddlEqptOilLossesA.Focus()
        '    Return False
        'End If
        'If dgvOilLossesB.Rows.Count = 0 Then
        '    MsgBox("Oil Losses B Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 1
        '    ddlDescpOilLossesB.Focus()
        '    Return False
        'End If
        'If dgvKernelLossesFFB.Rows.Count = 0 Then
        '    MsgBox(" Kernel Losses FFB Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 1
        '    ddlKernelLossesFFBLine.Focus()
        '    Return False
        'End If
        'If dgvKernelInTake.Rows.Count = 0 Then
        '    MsgBox(" Kernel In Take Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 2
        '    ddlKernelIntakeSourceLocation.Focus()
        '    Return False
        'End If

        'If dgvEffRippleMill.Rows.Count = 0 Then
        '    MsgBox("Efficiency Ripple Mill Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 2
        '    ddlLineEffRippleMill.Focus()
        '    Return False
        'End If

        'If dgvKernelQtyStorage.Rows.Count = 0 Then
        '    MsgBox("Kernel Quality Storage Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 3
        '    ddlKernelqtyStorageLocation.Focus()
        '    Return False
        'End If


        'If dgvOilQtyStorage.Rows.Count = 0 Then
        '    MsgBox("Oil Quality Storage Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 3
        '    ddlProductTypeOilQtyStorage.Focus()
        '    Return False
        'End If

        'If dgvMachineryOperation.Rows.Count = 0 Then
        '    MsgBox("Macinery Operation hours Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 4
        '    ddlMachineName.Focus()
        '    Return False
        'End If
        'If txtMOHMonthToDate.Text = String.Empty Then
        '    MessageBox.Show("This Field is required ", "MonthtoDate Hrs")
        '    tcLaboratoryAnalysis.SelectedIndex = 4
        '    txtMOHMonthToDate.Focus()
        '    Return False
        'End If

        'If txtMOHYearToDate.Text = String.Empty Then
        '    MessageBox.Show("This Field is required ", "YearToDate Hrs")
        '    tcLaboratoryAnalysis.SelectedIndex = 4
        '    txtMOHYearToDate.Focus()
        '    Return False
        'End If

        'If dgvBoilerWaterAnalysis.Rows.Count = 0 Then
        '    MsgBox("Boiler Water Analysis  Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 5
        '    ddlBWADescp.Focus()
        '    Return False
        'End If

        'If dgvSoftner.Rows.Count = 0 Then
        '    MsgBox("Softner Field is Required")
        '    tcLaboratoryAnalysis.SelectedIndex = 5
        '    ddlSoftnerDescp.Focus()
        '    Return False
        'End If
        Return True
    End Function


    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        ' If Not IsSaveValid() Then Exit Sub
        If lBtnSaveAll = "Save All" Then
            SaveDatas()
        Else
            UpdateDatas()
        End If

    End Sub

    Public Sub SaveDatas()

        Try

            Dim dsLab As New DataSet
            Dim ObjLaboratoryAnalysisPPTMain As New LaboratoryAnalysisPPT
            With ObjLaboratoryAnalysisPPTMain
                .LabAnalysisDate = dtpLabAnalDate.Value
                .CPOProductionFFAP = Val(txtFFATodayCPO.Text)
                .CPOProductionFFAPMTD = Val(txtCPOFFAToday.Text)
                .CPOProductionFFAPYTD = Val(txtCPOFFAYear.Text)
                .CPOProductionMoistureP = Val(txtCPOMoisture.Text)
                .CPOProductionDirtP = Val(txtCPODirtToday.Text)
                .KERProductionBrokenKernel = Val(txtBKTodayKer.Text)
                .KERProductionDirtP = Val(txtDirtTodayKer.Text)
                .KERProductionMoistureP = Val(txtMoistureTodayKer.Text)
                .PKOProductionDirtP = Val(txtPKODirt.Text)
                .PKOProductionFFAP = Val(txtPKOFFAToday.Text)
                .PKOProductionFFAPMTD = Val(txtPKOFFAMonth.Text)
                .PKOProductionFFAPYTD = Val(txtPKOFFAYear.Text)
                .PKOProductionMoistureP = Val(txtPKOMoisture.Text)
                .PKOProductionMoistureP = Val(txtPKOMoisture.Text)
            End With
            Dim objDateisExists As New Object

            objDateisExists = LaboratoryAnalysisBOL.LaboratoryAnalysisDuplicateCheck(ObjLaboratoryAnalysisPPTMain)
            If objDateisExists = 0 Then
                DisplayInfoMessage("Msg69")
                ''MsgBox("Record already exists for the Date , Please change the Date")
                dtpLabAnalDate.Focus()
                Exit Sub
            End If

            dsLab = LaboratoryAnalysisBOL.LaboratoryAnalysis_Save(ObjLaboratoryAnalysisPPTMain)
            lLabAnalysisID = dsLab.Tables(0).Rows(0).Item("LabAnalysisID")

            Dim dsOilLosses As New DataSet
            For Each DataGridViewRow In dgvOilLosses.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .OLStationID = DataGridViewRow.Cells("dgclStationID").Value.ToString()
                    .OLNo = DataGridViewRow.Cells("dgclNo").Value.ToString()
                    .OLLine = DataGridViewRow.Cells("dgclLine").Value.ToString()
                    .OLType = DataGridViewRow.Cells("dgclType").Value.ToString()
                    .OLActualP = DataGridViewRow.Cells("dgclActualP").Value.ToString()
                    .OLSTD = DataGridViewRow.Cells("dgclSTD").Value.ToString()
                End With
                dsOilLosses = LaboratoryAnalysisBOL.LabOilLosses_Save(ObjLaboratoryAnalysisPPT)
            Next

            Dim dsKernelLosses As New DataSet
            For Each DataGridViewRow In dgvKernelLosses.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .KLStationID = DataGridViewRow.Cells("dgKLStationID").Value.ToString()
                    .KLEfficiencyP = DataGridViewRow.Cells("dgKLEfficiencyP").Value.ToString()
                    .KLLine = DataGridViewRow.Cells("dgKLLine").Value.ToString()
                    .KLLossesP = DataGridViewRow.Cells("dgKLLossesP").Value.ToString()
                    .KLNo = DataGridViewRow.Cells("dgKLNo").Value.ToString()
                    .KLDirtP = DataGridViewRow.Cells("dgKLDirtP").Value.ToString()
                End With
                dsKernelLosses = LaboratoryAnalysisBOL.LabKernelLosses_Save(ObjLaboratoryAnalysisPPT)
            Next

            Dim dsKernelLossesPCF As New DataSet
            For Each DataGridViewRow In dgvKernelLossesPCF.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .KLPCFLine = DataGridViewRow.Cells("dgKLPCFLine").Value.ToString()
                    .KLPCFNo = DataGridViewRow.Cells("dgKLPCFNo").Value.ToString()
                    .KLPCFSampleP = DataGridViewRow.Cells("dgKLPCFSample").Value.ToString()
                    .KLPCFFibreP = DataGridViewRow.Cells("dgKLPCFFibre").Value.ToString()
                    .KLPCFTotalNutP = DataGridViewRow.Cells("dgKLPCFTotalNutPercent").Value.ToString()
                    .KLPCFStationID = lKernelPCFStationID
                End With
                dsKernelLossesPCF = LaboratoryAnalysisBOL.LabKernelLossesPCF_Save(ObjLaboratoryAnalysisPPT)
            Next

            Dim dsOilLossesA As New DataSet
            For Each DataGridViewRow In dgvOilLossesA.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .OLFFBEquipment = DataGridViewRow.Cells("dgclOLAEquipment").Value.ToString()
                    .OLFFBNo = DataGridViewRow.Cells("dgclOLANo").Value.ToString()
                    .OLFFBType = DataGridViewRow.Cells("dgclOLAType").Value.ToString()
                    .OLFFBActualP = DataGridViewRow.Cells("dgclOLAActualpercent").Value.ToString()
                End With
                dsOilLossesA = LaboratoryAnalysisBOL.LabOilLossesFFB_Save(ObjLaboratoryAnalysisPPT)
            Next

            Dim dsOilLossesB As New DataSet
            For Each DataGridViewRow In dgvOilLossesB.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .OLBFFBDescp = DataGridViewRow.Cells("dgclOLBDescription").Value.ToString()
                    .OLBFFBExpellerStageType = DataGridViewRow.Cells("dgclOLBExpellerStagetype").Value.ToString()
                    .OLBFFBExpellerStageNumber = DataGridViewRow.Cells("dgclOLBExpellerStageNo").Value.ToString()
                    .OLBFFBAmount = DataGridViewRow.Cells("dgclOLBAmount").Value.ToString()
                End With
                dsOilLossesB = LaboratoryAnalysisBOL.LabOilLossesBFFB_Save(ObjLaboratoryAnalysisPPT)
            Next

            Dim dsKernelLossesFFB As New DataSet
            For Each DataGridViewRow In dgvKernelLossesFFB.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .KLFFBLine = DataGridViewRow.Cells("dgclFFBKLLine").Value.ToString()
                    .KLFFBLTDS1P = DataGridViewRow.Cells("dgclFFBKLLTDS1").Value.ToString()
                    .KLFFBLTDS2P = DataGridViewRow.Cells("dgclFFBKLLTDS2").Value.ToString()
                    .KLFFBLTDS3P = DataGridViewRow.Cells("dgclFFBKLLTDS3").Value.ToString()
                    .KLFFBLTDS4P = DataGridViewRow.Cells("dgclFFBKLLTDS4").Value.ToString()
                    .KLFFBFibreCycP = DataGridViewRow.Cells("dgclFFBKLFibreCyc").Value.ToString()
                    .KLFFBHydroCycP = DataGridViewRow.Cells("dgclFFBKLHydroCyc").Value.ToString()
                    .KLFFBFruitinEB = DataGridViewRow.Cells("dgclFFBKLFruitinFB").Value.ToString()
                End With
                dsKernelLossesFFB = LaboratoryAnalysisBOL.LabKernelLossesFFB_Save(ObjLaboratoryAnalysisPPT)
            Next

            Dim dsKernelInTake As New DataSet
            For Each DataGridViewRow In dgvKernelInTake.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .KISourceLocation = DataGridViewRow.Cells("dgclSourceLocation").Value.ToString()
                    .KIMoistureP = DataGridViewRow.Cells("dgclMoisture").Value.ToString()
                    .KIDirtP = DataGridViewRow.Cells("dgclDirt").Value.ToString()
                    .KIReceivedTon = DataGridViewRow.Cells("dgclReceivedTon").Value.ToString()
                    .KIBrokenKernel = DataGridViewRow.Cells("dgclBrokenKernel").Value.ToString()
                End With
                dsKernelInTake = LaboratoryAnalysisBOL.LabKernelIntake_Save(ObjLaboratoryAnalysisPPT)
            Next

            Dim dsEffRippMill As New DataSet
            For Each DataGridViewRow In dgvEffRippleMill.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .ERPLine = DataGridViewRow.Cells("dgclERMLine").Value.ToString()
                    .ERPNo = DataGridViewRow.Cells("dgclERMNo").Value.ToString()
                    .ERPEfficiencyP = DataGridViewRow.Cells("dgclERMEffciencyP").Value.ToString()
                    .ERPEquipment = DataGridViewRow.Cells("dgclEquipment").Value.ToString()
                End With
                dsEffRippMill = LaboratoryAnalysisBOL.LabEffRippleMill_Save(ObjLaboratoryAnalysisPPT)
            Next

            Dim dsKernelqtyStorage As New DataSet
            For Each DataGridViewRow In dgvKernelQtyStorage.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .KQSLine = DataGridViewRow.Cells("dgcLine").Value.ToString()
                    .KQSLocation = DataGridViewRow.Cells("dgclKQSLocation").Value.ToString()
                    .KQSMoistureP = DataGridViewRow.Cells("dgclKQSMoisture").Value.ToString()
                    .KQSDirtP = DataGridViewRow.Cells("dgclKQSDirtP").Value.ToString()
                    .KQSBrokenKernel = DataGridViewRow.Cells("dgclKQSBrokenKernel").Value.ToString()

                End With
                dsKernelqtyStorage = LaboratoryAnalysisBOL.LabKernelQualityStorage_Save(ObjLaboratoryAnalysisPPT)
            Next


            Dim dsoilQtyStorage As New DataSet
            For Each DataGridViewRow In dgvOilQtyStorage.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .OQSProductType = DataGridViewRow.Cells("dgclOQSProductType").Value.ToString()
                    .OQSTankID = DataGridViewRow.Cells("dgclOQSTankID").Value.ToString()
                    .OQSMoistureP = DataGridViewRow.Cells("dgclOQSMoisture").Value.ToString()
                    .OQSDirtP = DataGridViewRow.Cells("dgclOQSDirt").Value.ToString()
                    .OQSFFAP = DataGridViewRow.Cells("dgclOQSFFA").Value.ToString()
                End With
                dsoilQtyStorage = LaboratoryAnalysisBOL.LabOilQualityStorage_Save(ObjLaboratoryAnalysisPPT)
            Next

            Dim dsMachineryOperation As New DataSet
            For Each DataGridViewRow In dgvMachineryOperation.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .MOHMachineID = DataGridViewRow.Cells("dgclMOHMachineID").Value.ToString()
                    .MOHMeterFrom = DataGridViewRow.Cells("dgclMOHMeterFrom").Value.ToString()
                    .MOHMeterTo = DataGridViewRow.Cells("dgclMeterTo").Value.ToString()
                    .MOHProcessHours = DataGridViewRow.Cells("dgclProcessHours").Value.ToString()
                    .MOHNonProcessHours = DataGridViewRow.Cells("dgclNonProcessHours").Value.ToString()
                    .MOHTotalHours = DataGridViewRow.Cells("dgclTotalHourstoday").Value.ToString()
                    .MOHMonthToDateHrs = DataGridViewRow.Cells("dgclMonthTodateHrs").Value.ToString()
                    .MOHYeartoDateHrs = DataGridViewRow.Cells("dgclYearTodateHrs").Value.ToString()
                End With
                dsMachineryOperation = LaboratoryAnalysisBOL.MachineryOperation_Save(ObjLaboratoryAnalysisPPT)
            Next

            Dim dsBWA As New DataSet
            For Each DataGridViewRow In dgvBoilerWaterAnalysis.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .BWADescp = DataGridViewRow.Cells("dgclBWADescp").Value.ToString()
                    .BWAType = DataGridViewRow.Cells("dgclBWAAmount").Value.ToString()
                    .BWAValue = DataGridViewRow.Cells("dgclBWAValue").Value.ToString()
                End With
                dsBWA = LaboratoryAnalysisBOL.LabBoilerWater_Save(ObjLaboratoryAnalysisPPT)
            Next


            Dim dsSoftner As New DataSet
            For Each DataGridViewRow In dgvSoftner.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    .SDescp = DataGridViewRow.Cells("dgclSoftnerDescp").Value.ToString()
                    .SType = DataGridViewRow.Cells("dgclSoftnerType").Value.ToString()
                    .SDosage = DataGridViewRow.Cells("dgclSoftnerDosage").Value.ToString()
                    .SAnion = DataGridViewRow.Cells("dgcAnion").Value
                End With
                dsSoftner = LaboratoryAnalysisBOL.LabSoftner_Save(ObjLaboratoryAnalysisPPT)
            Next

            DisplayInfoMessage("Msg70")
            ''MsgBox("Data Successfully Saved")
            ClearKernelCPOPKOProduction()
            ClearBoilWaterAnalysis()
            ClearEfficiencyripleMill()
            ClearKernelInTake()
            ClearKernelLossesFFB()
            ClearKernelLosses()
            ClearKernelLossesPCF()
            ClearKernelQtyStorage()
            ClearOilLosses()
            ClearOillossesB()
            ClearOillossesA()
            ClearOilQtyStorage()
            ClearSoftner()
            ClearMachineryOperation()
            chkLabAnalDate.Checked = False
            ClearGridView(dgvOilLosses)
            ClearGridView(dgvKernelLosses)
            ClearGridView(dgvKernelLossesPCF)
            ClearGridView(dgvOilLossesA)
            ClearGridView(dgvOilLossesB)
            ClearGridView(dgvKernelLossesFFB)
            ClearGridView(dgvKernelInTake)
            ClearGridView(dgvEffRippleMill)
            ClearGridView(dgvKernelQtyStorage)
            ClearGridView(dgvOilQtyStorage)
            ClearGridView(dgvMachineryOperation)
            ClearGridView(dgvBoilerWaterAnalysis)
            ClearGridView(dgvSoftner)
            tcLaboratoryAnalysis.SelectedIndex = 0
            txtMOHMonthToDate.Text = ""
            txtMOHYearToDate.Text = ""
            txtMOHMonthToDate.Text = "00:00"
            txtMOHYearToDate.Text = "00:00"
            ' MOHMonthYearSelect()
            GlobalPPT.IsRetainFocus = False
        Catch ex As Exception
            MsgBox(ex)
        End Try
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub
    Private Sub BindDataGrid()
        Try
            Dim ds As New DataSet
            Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
            If chkLabAnalDate.Checked = True Then
                ObjLaboratoryAnalysisPPT.lLabAnalysisDate = dtpViewLabAnalDate.Value
            Else
                ObjLaboratoryAnalysisPPT.lLabAnalysisDate = "01/01/1900"
            End If

            ds = LaboratoryAnalysisBOL.LaboratoryAnalysis_Select(ObjLaboratoryAnalysisPPT)

            If ds.Tables(0).Rows.Count <> 0 Then
                dgvLaboratoryAnalysis.AutoGenerateColumns = False
                dgvLaboratoryAnalysis.DataSource = ds.Tables(0)
            Else
                ClearGridView(dgvLaboratoryAnalysis) '''''clear the records from grid view
                'lblView.Visible = True
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Public Sub UpdateDatas()

        Try

            Dim dsLab As New DataSet
            Dim ObjLaboratoryAnalysisPPTMain As New LaboratoryAnalysisPPT
            '   Dim ObjLaboratoryAnalysisBOL As New LaboratoryAnalysisBOL
            With ObjLaboratoryAnalysisPPTMain
                .LabAnalysisDate = dtpLabAnalDate.Value
                .CPOProductionFFAP = Val(txtFFATodayCPO.Text)
                .CPOProductionFFAPMTD = Val(txtCPOFFAToday.Text)
                .CPOProductionFFAPYTD = Val(txtCPOFFAYear.Text)
                .CPOProductionMoistureP = Val(txtCPOMoisture.Text)
                .CPOProductionDirtP = Val(txtCPODirtToday.Text)
                .KERProductionBrokenKernel = Val(txtBKTodayKer.Text)
                .KERProductionDirtP = Val(txtDirtTodayKer.Text)
                .KERProductionMoistureP = Val(txtMoistureTodayKer.Text)
                .PKOProductionDirtP = Val(txtPKODirt.Text)
                .PKOProductionFFAP = Val(txtPKOFFAToday.Text)
                .PKOProductionFFAPMTD = Val(txtPKOFFAMonth.Text)
                .PKOProductionFFAPYTD = Val(txtPKOFFAYear.Text)
                .PKOProductionMoistureP = Val(txtPKOMoisture.Text)
                .PKOProductionMoistureP = Val(txtPKOMoisture.Text)
                .LabAnalysisID = lLabAnalysisID
            End With
            dsLab = LaboratoryAnalysisBOL.LaboratoryAnalysis_Update(ObjLaboratoryAnalysisPPTMain)
           
            Dim dsOilLosses As New DataSet
            For Each DataGridViewRow In dgvOilLosses.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    If Not DataGridViewRow.Cells("dgclLabOilLossesID").Value Is DBNull.Value Then
                        .OLLabOilLossesID = DataGridViewRow.Cells("dgclLabOilLossesID").Value.ToString()
                    End If

                    .OLStationID = DataGridViewRow.Cells("dgclStationID").Value.ToString()
                    .OLNo = DataGridViewRow.Cells("dgclNo").Value.ToString()
                    .OLLine = DataGridViewRow.Cells("dgclLine").Value.ToString()
                    .OLType = DataGridViewRow.Cells("dgclType").Value.ToString()
                    .OLActualP = DataGridViewRow.Cells("dgclActualP").Value.ToString()
                    .OLSTD = DataGridViewRow.Cells("dgclSTD").Value.ToString()
                End With
                If ObjLaboratoryAnalysisPPT.OLLabOilLossesID = "" Then
                    dsOilLosses = LaboratoryAnalysisBOL.LabOilLosses_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsOilLosses = LaboratoryAnalysisBOL.LabOilLosses_Update(ObjLaboratoryAnalysisPPT)
                End If

            Next

            Dim dsKernelLosses As New DataSet
            For Each DataGridViewRow In dgvKernelLosses.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    If Not DataGridViewRow.Cells("dgLabKernelLossesID").Value Is DBNull.Value Then
                        .KLLabKernelLossesID = DataGridViewRow.Cells("dgLabKernelLossesID").Value.ToString()
                    End If

                    .KLStationID = DataGridViewRow.Cells("dgKLStationID").Value.ToString()
                    .KLEfficiencyP = DataGridViewRow.Cells("dgKLEfficiencyP").Value.ToString()
                    .KLLine = DataGridViewRow.Cells("dgKLLine").Value.ToString()
                    .KLLossesP = DataGridViewRow.Cells("dgKLLossesP").Value.ToString()
                    .KLNo = DataGridViewRow.Cells("dgKLNo").Value.ToString()
                    .KLDirtP = DataGridViewRow.Cells("dgKLDirtP").Value.ToString()
                End With
                If ObjLaboratoryAnalysisPPT.KLLabKernelLossesID = "" Then
                    dsKernelLosses = LaboratoryAnalysisBOL.LabKernelLosses_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsKernelLosses = LaboratoryAnalysisBOL.LabKernelLosses_Update(ObjLaboratoryAnalysisPPT)
                End If

            Next

            Dim dsKernelLossesPCF As New DataSet
            For Each DataGridViewRow In dgvKernelLossesPCF.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID

                    If Not DataGridViewRow.Cells("dgLabKernelLossesPCFID").Value Is DBNull.Value Then
                        .KLPCFLabKernelLossesPCFID = DataGridViewRow.Cells("dgLabKernelLossesPCFID").Value.ToString()
                    End If

                    .KLPCFLine = DataGridViewRow.Cells("dgKLPCFLine").Value.ToString()
                    .KLPCFNo = DataGridViewRow.Cells("dgKLPCFNo").Value.ToString()
                    .KLPCFSampleP = DataGridViewRow.Cells("dgKLPCFSample").Value.ToString()
                    .KLPCFFibreP = DataGridViewRow.Cells("dgKLPCFFibre").Value.ToString()
                    .KLPCFTotalNutP = DataGridViewRow.Cells("dgKLPCFTotalNutPercent").Value.ToString()
                    .KLPCFStationID = lKernelPCFStationID
                End With
                If ObjLaboratoryAnalysisPPT.KLPCFLabKernelLossesPCFID = "" Then
                    dsKernelLossesPCF = LaboratoryAnalysisBOL.LabKernelLossesPCF_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsKernelLossesPCF = LaboratoryAnalysisBOL.LabKernelLossesPCF_Update(ObjLaboratoryAnalysisPPT)
                End If
            Next

            Dim dsOilLossesA As New DataSet
            For Each DataGridViewRow In dgvOilLossesA.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID

                    If Not DataGridViewRow.Cells("dgclLabOilLossesAID").Value Is DBNull.Value Then
                        .OLFFBLabOilLossesFFBID = DataGridViewRow.Cells("dgclLabOilLossesAID").Value.ToString()
                    End If
                    .OLFFBEquipment = DataGridViewRow.Cells("dgclOLAEquipment").Value.ToString()
                    .OLFFBNo = DataGridViewRow.Cells("dgclOLANo").Value.ToString()
                    .OLFFBType = DataGridViewRow.Cells("dgclOLAType").Value.ToString()
                    .OLFFBActualP = DataGridViewRow.Cells("dgclOLAActualpercent").Value.ToString()
                End With
                If ObjLaboratoryAnalysisPPT.OLFFBLabOilLossesFFBID = "" Then
                    dsOilLossesA = LaboratoryAnalysisBOL.LabOilLossesFFB_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsOilLossesA = LaboratoryAnalysisBOL.LabOilLossesFFB_Update(ObjLaboratoryAnalysisPPT)
                End If

            Next

            Dim dsOilLossesB As New DataSet
            For Each DataGridViewRow In dgvOilLossesB.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID

                    If Not DataGridViewRow.Cells("dgclLabOilLossesBID").Value Is DBNull.Value Then
                        .OLBFFBLabOilLossesBFFBID = DataGridViewRow.Cells("dgclLabOilLossesBID").Value.ToString()
                    End If
                    .OLBFFBDescp = DataGridViewRow.Cells("dgclOLBDescription").Value.ToString()
                    .OLBFFBExpellerStageType = DataGridViewRow.Cells("dgclOLBExpellerStagetype").Value.ToString()
                    .OLBFFBExpellerStageNumber = DataGridViewRow.Cells("dgclOLBExpellerStageNo").Value.ToString()
                    .OLBFFBAmount = DataGridViewRow.Cells("dgclOLBAmount").Value.ToString()
                End With
                If ObjLaboratoryAnalysisPPT.OLBFFBLabOilLossesBFFBID = "" Then
                    dsOilLossesB = LaboratoryAnalysisBOL.LabOilLossesBFFB_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsOilLossesB = LaboratoryAnalysisBOL.LabOilLossesBFFB_Update(ObjLaboratoryAnalysisPPT)
                End If


            Next

            Dim dsKernelLossesFFB As New DataSet
            For Each DataGridViewRow In dgvKernelLossesFFB.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID

                    If Not DataGridViewRow.Cells("dgclLabKernelLossesFFBID").Value Is DBNull.Value Then
                        .KLFFBLabKernelLossesFFBID = DataGridViewRow.Cells("dgclLabKernelLossesFFBID").Value.ToString()
                    End If
                    .KLFFBLine = DataGridViewRow.Cells("dgclFFBKLLine").Value.ToString()
                    .KLFFBLTDS1P = DataGridViewRow.Cells("dgclFFBKLLTDS1").Value.ToString()
                    .KLFFBLTDS2P = DataGridViewRow.Cells("dgclFFBKLLTDS2").Value.ToString()
                    If Not DataGridViewRow.Cells("dgclFFBKLLTDS3").Value Is DBNull.Value Then
                        .KLFFBLTDS3P = DataGridViewRow.Cells("dgclFFBKLLTDS3").Value.ToString()
                    End If
                    If Not DataGridViewRow.Cells("dgclFFBKLLTDS4").Value Is DBNull.Value Then
                        .KLFFBLTDS4P = DataGridViewRow.Cells("dgclFFBKLLTDS4").Value.ToString()
                    End If
                    .KLFFBFibreCycP = DataGridViewRow.Cells("dgclFFBKLFibreCyc").Value.ToString()
                    .KLFFBHydroCycP = DataGridViewRow.Cells("dgclFFBKLHydroCyc").Value.ToString()
                    .KLFFBFruitinEB = DataGridViewRow.Cells("dgclFFBKLFruitinFB").Value.ToString()
                End With
                If ObjLaboratoryAnalysisPPT.KLFFBLabKernelLossesFFBID = "" Then
                    dsKernelLossesFFB = LaboratoryAnalysisBOL.LabKernelLossesFFB_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsKernelLossesFFB = LaboratoryAnalysisBOL.LabKernelLossesFFB_Update(ObjLaboratoryAnalysisPPT)
                End If

            Next

            Dim dsKernelInTake As New DataSet
            For Each DataGridViewRow In dgvKernelInTake.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID

                    If Not DataGridViewRow.Cells("dgclLabKernelInTakeID").Value Is DBNull.Value Then
                        .KILabKernelIntakeID = DataGridViewRow.Cells("dgclLabKernelInTakeID").Value.ToString()
                    End If
                    .KISourceLocation = DataGridViewRow.Cells("dgclSourceLocation").Value.ToString()
                    .KIMoistureP = DataGridViewRow.Cells("dgclMoisture").Value.ToString()
                    .KIDirtP = DataGridViewRow.Cells("dgclDirt").Value.ToString()
                    .KIReceivedTon = DataGridViewRow.Cells("dgclReceivedTon").Value.ToString()
                    .KIBrokenKernel = DataGridViewRow.Cells("dgclBrokenKernel").Value.ToString()
                End With
                If ObjLaboratoryAnalysisPPT.KILabKernelIntakeID = "" Then
                    dsKernelInTake = LaboratoryAnalysisBOL.LabKernelIntake_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsKernelInTake = LaboratoryAnalysisBOL.LabKernelIntake_Update(ObjLaboratoryAnalysisPPT)
                End If


            Next

            Dim dsEffRippMill As New DataSet
            For Each DataGridViewRow In dgvEffRippleMill.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    If Not DataGridViewRow.Cells("dgclLabEffRippleMill").Value Is DBNull.Value Then
                        .ERPLabEffRippleMillID = DataGridViewRow.Cells("dgclLabEffRippleMill").Value
                    End If
                    .ERPLine = DataGridViewRow.Cells("dgclERMLine").Value.ToString()
                    .ERPNo = DataGridViewRow.Cells("dgclERMNo").Value.ToString()
                    .ERPEfficiencyP = DataGridViewRow.Cells("dgclERMEffciencyP").Value.ToString()
                    .ERPEquipment = DataGridViewRow.Cells("dgclEquipment").Value.ToString()
                End With
                If ObjLaboratoryAnalysisPPT.ERPLabEffRippleMillID = "" Then
                    dsEffRippMill = LaboratoryAnalysisBOL.LabEffRippleMill_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsEffRippMill = LaboratoryAnalysisBOL.LabEffRippleMill_Update(ObjLaboratoryAnalysisPPT)
                End If


            Next

            Dim dsKernelqtyStorage As New DataSet
            For Each DataGridViewRow In dgvKernelQtyStorage.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    If Not DataGridViewRow.Cells("dgLabKernelQtyStorageID").Value Is DBNull.Value Then
                        .KQSLabKERQualityID = DataGridViewRow.Cells("dgLabKernelQtyStorageID").Value.ToString()
                    End If
                    .KQSLine = DataGridViewRow.Cells("dgcLine").Value.ToString()
                    .KQSLocation = DataGridViewRow.Cells("dgclKQSLocation").Value.ToString()
                    .KQSMoistureP = DataGridViewRow.Cells("dgclKQSMoisture").Value.ToString()
                    .KQSDirtP = DataGridViewRow.Cells("dgclKQSDirtP").Value.ToString()
                    .KQSBrokenKernel = DataGridViewRow.Cells("dgclKQSBrokenKernel").Value.ToString()

                End With
                If ObjLaboratoryAnalysisPPT.KQSLabKERQualityID = "" Then
                    dsKernelqtyStorage = LaboratoryAnalysisBOL.LabKernelQualityStorage_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsKernelqtyStorage = LaboratoryAnalysisBOL.LabKernelQualityStorage_Update(ObjLaboratoryAnalysisPPT)
                End If


            Next


            Dim dsoilQtyStorage As New DataSet
            For Each DataGridViewRow In dgvOilQtyStorage.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    If Not DataGridViewRow.Cells("dgLabOilQtystorageID").Value Is DBNull.Value Then
                        .OQSLabOilQualityID = DataGridViewRow.Cells("dgLabOilQtystorageID").Value.ToString()
                    End If

                    .OQSProductType = DataGridViewRow.Cells("dgclOQSProductType").Value.ToString()
                    .OQSTankID = DataGridViewRow.Cells("dgclOQSTankID").Value.ToString()
                    .OQSMoistureP = DataGridViewRow.Cells("dgclOQSMoisture").Value.ToString()
                    .OQSDirtP = DataGridViewRow.Cells("dgclOQSDirt").Value.ToString()
                    .OQSFFAP = DataGridViewRow.Cells("dgclOQSFFA").Value.ToString()
                End With
                If ObjLaboratoryAnalysisPPT.OQSLabOilQualityID = "" Then
                    dsoilQtyStorage = LaboratoryAnalysisBOL.LabOilQualityStorage_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsoilQtyStorage = LaboratoryAnalysisBOL.LabOilQualityStorage_Update(ObjLaboratoryAnalysisPPT)
                End If


            Next

            Dim dsMachineryOperation As New DataSet
            For Each DataGridViewRow In dgvMachineryOperation.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    If Not DataGridViewRow.Cells("dgclMachineryOperationID").Value Is DBNull.Value Then
                        .MOHMachinerOperationID = DataGridViewRow.Cells("dgclMachineryOperationID").Value.ToString()
                    End If
                    .MOHMachineID = DataGridViewRow.Cells("dgclMOHMachineID").Value.ToString()
                    .MOHMeterFrom = DataGridViewRow.Cells("dgclMOHMeterFrom").Value.ToString()
                    .MOHMeterTo = DataGridViewRow.Cells("dgclMeterTo").Value.ToString()
                    .MOHProcessHours = DataGridViewRow.Cells("dgclProcessHours").Value.ToString()
                    .MOHNonProcessHours = DataGridViewRow.Cells("dgclNonProcessHours").Value.ToString()
                    .MOHTotalHours = DataGridViewRow.Cells("dgclTotalHourstoday").Value.ToString()
                    .MOHMonthToDateHrs = DataGridViewRow.Cells("dgclMonthTodateHrs").Value.ToString()
                    .MOHYeartoDateHrs = DataGridViewRow.Cells("dgclYearTodateHrs").Value.ToString()
                End With
                If ObjLaboratoryAnalysisPPT.MOHMachinerOperationID = "" Then
                    dsMachineryOperation = LaboratoryAnalysisBOL.MachineryOperation_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsMachineryOperation = LaboratoryAnalysisBOL.MachineryOperation_Update(ObjLaboratoryAnalysisPPT)
                End If



            Next

            Dim dsBWA As New DataSet
            For Each DataGridViewRow In dgvBoilerWaterAnalysis.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    If (Not DataGridViewRow.Cells("dgLabBoilerWaterID").Value Is DBNull.Value) And (Not DataGridViewRow.Cells("dgLabBoilerWaterID").Value Is Nothing) Then
                        .BWALabBoilerWaterID = DataGridViewRow.Cells("dgLabBoilerWaterID").Value
                    End If
                    .BWADescp = DataGridViewRow.Cells("dgclBWADescp").Value.ToString()
                    .BWAType = DataGridViewRow.Cells("dgclBWAAmount").Value.ToString()
                    .BWAValue = DataGridViewRow.Cells("dgclBWAValue").Value.ToString()
                End With
                If ObjLaboratoryAnalysisPPT.BWALabBoilerWaterID = "" Then
                    dsBWA = LaboratoryAnalysisBOL.LabBoilerWater_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsBWA = LaboratoryAnalysisBOL.LabBoilerWater_Update(ObjLaboratoryAnalysisPPT)
                End If


            Next


            Dim dsSoftner As New DataSet
            For Each DataGridViewRow In dgvSoftner.Rows
                Dim ObjLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
                With ObjLaboratoryAnalysisPPT
                    .LabAnalysisID = lLabAnalysisID
                    If (Not DataGridViewRow.Cells("dgLabSoftnerID").Value Is DBNull.Value) And (Not DataGridViewRow.Cells("dgLabSoftnerID").Value Is Nothing) Then
                        .SLabSoftnerID = DataGridViewRow.Cells("dgLabSoftnerID").Value.ToString()
                    End If

                    .SDescp = DataGridViewRow.Cells("dgclSoftnerDescp").Value.ToString()
                    .SType = DataGridViewRow.Cells("dgclSoftnerType").Value.ToString()
                    .SDosage = DataGridViewRow.Cells("dgclSoftnerDosage").Value.ToString()
                End With

                If ObjLaboratoryAnalysisPPT.SLabSoftnerID = "" Then
                    dsSoftner = LaboratoryAnalysisBOL.LabSoftner_Save(ObjLaboratoryAnalysisPPT)
                Else
                    dsSoftner = LaboratoryAnalysisBOL.LabSoftner_Update(ObjLaboratoryAnalysisPPT)
                End If

            Next

            DisplayInfoMessage("Msg71")
            ''MsgBox("Data Successfully Updated")
            ClearKernelCPOPKOProduction()
            ClearBoilWaterAnalysis()
            ClearEfficiencyripleMill()
            ClearKernelInTake()
            ClearKernelLossesFFB()
            ClearKernelLosses()
            ClearKernelLossesPCF()
            ClearKernelQtyStorage()
            ClearOilLosses()
            ClearOillossesB()
            ClearOillossesA()
            ClearOilQtyStorage()
            ClearSoftner()
            ClearMachineryOperation()
            chkLabAnalDate.Checked = False
            ClearGridView(dgvOilLosses)
            ClearGridView(dgvKernelLosses)
            ClearGridView(dgvKernelLossesPCF)
            ClearGridView(dgvOilLossesA)
            ClearGridView(dgvOilLossesB)
            ClearGridView(dgvKernelLossesFFB)
            ClearGridView(dgvKernelInTake)
            ClearGridView(dgvEffRippleMill)
            ClearGridView(dgvKernelQtyStorage)
            ClearGridView(dgvOilQtyStorage)
            ClearGridView(dgvMachineryOperation)
            ClearGridView(dgvBoilerWaterAnalysis)
            ClearGridView(dgvSoftner)
            'ddlEqptKernelLosses.SelectedIndex = 0
            'ddlEquitOilLosses.SelectedIndex = 0
            'ddlMachineName.SelectedIndex = 0
            tcLaboratoryAnalysis.SelectedIndex = 0
            txtMOHMonthToDate.Text = ""
            txtMOHYearToDate.Text = ""
            txtMOHMonthToDate.Text = "00:00"
            txtMOHYearToDate.Text = "00:00"
            ' MOHMonthYearSelect()
            GlobalPPT.IsRetainFocus = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub tbLabAnalysis_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbLabAnalysis.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub


    Private Sub KeyDown2Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Modifiers And (Keys.Alt Or Keys.Insert Or Keys.Control Or Keys.Shift) Then
            isModifierKey = True
            Return
        End If
        isModifierKey = False
        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                Select Case e.KeyCode
                    'Case Keys.OemPeriod
                    '    isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                    Case Keys.[Decimal], Keys.OemPeriod
                        'digit from keypad? --> Keys.[Decimal]
                        'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                        If txtBox.Text.Trim.Contains(".") Then
                            is2Decimal = False
                            Return
                        End If

                        is2Decimal = True
                        Return
                    Case Else

                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            'digit from top of keyboard?
                            'text = txtBox.Text.Trim & CChar(ChrW(e.KeyValue))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                            'digit from keypad?
                            'text = txtBox.Text.Trim & CChar(CChar(CStr(e.KeyValue)))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                        End If

                        is2Decimal = re2DecimalPlaces.IsMatch(text)

                End Select
            Else
                is2Decimal = False
                Return
            End If

        Else
            is2Decimal = True
        End If

    End Sub
    Private Sub KeyPress2Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If isModifierKey Then
            e.Handled = True
            Return
        End If


        If is2Decimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub
    Private Sub KeyDown3Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Modifiers And (Keys.Alt Or Keys.Insert Or Keys.Control Or Keys.Shift) Then
            isModifierKey = True
            Return
        End If
        isModifierKey = False
        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                Select Case e.KeyCode
                    'Case Keys.OemPeriod
                    '    isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                    Case Keys.[Decimal], Keys.OemPeriod
                        'digit from keypad? --> Keys.[Decimal]
                        'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                        If txtBox.Text.Trim.Contains(".") Then
                            is3Decimal = False
                            Return
                        End If

                        is3Decimal = True
                        Return
                    Case Else

                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            'digit from top of keyboard?
                            'text = txtBox.Text.Trim & CChar(ChrW(e.KeyValue))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                            'digit from keypad?
                            'text = txtBox.Text.Trim & CChar(CChar(CStr(e.KeyValue)))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                        End If

                        is3Decimal = re3DecimalPlaces.IsMatch(text)

                End Select
            Else
                is3Decimal = False
                Return
            End If

        Else
            is3Decimal = True
        End If

    End Sub
    Private Sub KeyPress3Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If isModifierKey Then
            e.Handled = True
            Return
        End If


        If is3Decimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub txtActualpercent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtActualpercent.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtActualpercent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtActualpercent.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtStdPercent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStdPercent.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtStdPercent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStdPercent.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKLEfficiency_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKLEfficiency.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKLEfficiency_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKLEfficiency.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKLLossesprecent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKLLossesprecent.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKLLossesprecent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKLLossesprecent.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKLDirtpercent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKLDirtpercent.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtKLDirtpercent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKLDirtpercent.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtKLPCSamplepercent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKLPCSamplepercent.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKLPCSamplepercent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKLPCSamplepercent.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKLPCFibrepercent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKLPCFibrepercent.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKLPCFibrepercent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKLPCFibrepercent.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKLPCTotalNutPercent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKLPCTotalNutPercent.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKLPCTotalNutPercent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKLPCTotalNutPercent.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtOLAActualpercent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOLAActualpercent.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtOLAActualpercent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOLAActualpercent.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtOLBAmount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOLBAmount.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtOLBAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOLBAmount.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

   
    Private Sub txtFFBKLLTDS1P_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBKLLTDS1P.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtFFBKLLTDS1P_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBKLLTDS1P.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtFFBKLLTDS2P_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBKLLTDS2P.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtFFBKLLTDS2P_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBKLLTDS2P.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub


    Private Sub txtFFBKLFibreCycP_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBKLFibreCycP.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtFFBKLFibreCycP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBKLFibreCycP.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

   
    Private Sub txtKLFFBHydroCycP_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKLFFBHydroCycP.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKLFFBHydroCycP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKLFFBHydroCycP.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtFFBKLFruitinEb_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBKLFruitinEb.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtFFBKLFruitinEb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBKLFruitinEb.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMoistureTodayKer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMoistureTodayKer.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtMoistureTodayKer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMoistureTodayKer.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtDirtTodayKer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDirtTodayKer.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtDirtTodayKer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDirtTodayKer.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    
    Private Sub txtBKTodayKer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBKTodayKer.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtBKTodayKer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBKTodayKer.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtFFATodayCPO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFATodayCPO.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtFFATodayCPO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFATodayCPO.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtCPOMoisture_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCPOMoisture.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtCPOMoisture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPOMoisture.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtCPODirtToday_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCPODirtToday.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtCPODirtToday_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPODirtToday.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtPKOFFAToday_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKOFFAToday.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtPKOFFAToday_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKOFFAToday.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtPKOMoisture_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKOMoisture.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtPKOMoisture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKOMoisture.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtPKODirt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKODirt.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtPKODirt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKODirt.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

   
    Private Sub txtKernelInTakeMoisture_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelInTakeMoisture.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKernelInTakeMoisture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelInTakeMoisture.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKernelInTakeReceivedTon_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelInTakeReceivedTon.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtKernelInTakeReceivedTon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelInTakeReceivedTon.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtKernelInTakeDirt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelInTakeDirt.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtKernelInTakeBrokenKernel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelInTakeBrokenKernel.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKernelInTakeBrokenKernel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelInTakeBrokenKernel.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtERMEfficiencyP_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtERMEfficiencyP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKQSMoisture_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKQSMoisture.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKQSMoisture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKQSMoisture.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtKQSDirt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKQSDirt.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtKQSDirt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKQSDirt.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtKQSBrokenKernel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKQSBrokenKernel.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtKQSBrokenKernel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKQSBrokenKernel.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtOQSFFA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOQSFFA.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtOQSFFA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOQSFFA.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtOQSMoisture_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOQSMoisture.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtOQSMoisture_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOQSMoisture.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtOQSDirt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOQSDirt.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtOQSDirt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOQSDirt.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtMOHMeterFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOHMeterFrom.KeyDown
        '  KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtMOHMeterFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOHMeterFrom.KeyPress
        ' KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMOHMeterTo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOHMeterTo.KeyDown
        ' KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtMOHMeterTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOHMeterTo.KeyPress
        ' KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMOHProcessHours_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOHProcessHours.KeyDown
        ' KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtMOHProcessHours_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOHProcessHours.KeyPress
        ' KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMOHNonProcessHours_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOHNonProcessHours.KeyDown
        'KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtMOHNonProcessHours_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOHNonProcessHours.KeyPress
        ' KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtBWAValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBWAValue.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtBWAValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBWAValue.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtSoftDosage_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoftDosage.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtSoftDosage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSoftDosage.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

   

    Private Sub txtKernelInTakeDirt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelInTakeDirt.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub dtpLabAnalDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLabAnalDate.ValueChanged
        CPOPKOMonthYearValues()
        ProductionQtyVaules()
        FFAPCPOCalc()
        FFAPPKOCalc()
    End Sub

    'Private Sub txtMOHProcessHours_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    DecimalIdenCheck(txtMOHProcessHours)
    '    If DecimalCheck = True Then
    '        DisplayInfoMessage("Msg72")
    '        '' MsgBox("User Can enter only HH or HH.mm (Example: 10 (or) 10.50 ;Invalid Values 10.)")
    '        txtMOHProcessHours.Focus()
    '        DecimalCheck = False
    '        Exit Sub
    '    End If



    '    If txtMOHProcessHours.Text <> String.Empty Then
    '        If txtMOHProcessHours.Text > 24 Then
    '            DisplayInfoMessage("Msg73")
    '            ''MsgBox("Process Hours cant be greater than 24 hrs")
    '            txtMOHProcessHours.Focus()
    '        End If
    '        Dim lDecimal As Decimal
    '        lDecimal = txtMOHProcessHours.Text
    '        Dim intMins As Double = 0
    '        Dim intHrs As Double = 0
    '        Dim intDiv As Double = 0
    '        Dim strDiv As String
    '        If lDecimal <> 0 Then

    '            intMins = lDecimal * 100
    '            intHrs = intMins / 100
    '            intHrs = Fix(intHrs)
    '            intDiv = intMins Mod 100
    '            strDiv = intDiv
    '            If intDiv >= 60 Then
    '                intDiv = intDiv - 60
    '                intHrs = intHrs + 1
    '            End If

    '            If intDiv.ToString.Length = 1 Then
    '                txtMOHProcessHours.Text = intHrs.ToString + ".0" + intDiv.ToString
    '            Else
    '                txtMOHProcessHours.Text = intHrs.ToString + "." + intDiv.ToString
    '            End If
    '        End If
    '    End If
    '    TotalHrsCalculation()
    'End Sub

    Private Sub txtMOHProcessHours_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOHProcessHours.TextChanged
        If txtMOHProcessHours.Text <> String.Empty And txtMOHNonProcessHours.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr(), strArr1() As String
            Dim Str, Str1 As String
            Str = txtMOHProcessHours.Text
            strArr = Str.Split(":")
            Str1 = txtMOHNonProcessHours.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            If strArr.Length <= 1 Then
                Return
            End If

            If IsNumeric(strArr(0)) And IsNumeric(strArr1(0)) And IsNumeric(strArr1(1)) And IsNumeric(strArr(1)) Then


                Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                lmin = CInt(strArr1(1)) + CInt(strArr(1))

                If lmin >= 60 Then
                    lmin = lmin - 60
                    Lhrs = Lhrs + 1
                End If



                Dim Strhrs As String = "00"
                Dim StrMin As String = "00"

                If Lhrs > 24 Then
                    DisplayInfoMessage("Msg74")
                    ''MsgBox("Total Process Hrs Cant be greater than 24 hrs ")
                    txtMOHNonProcessHours.Focus()

                Else
                    If Lhrs < 10 Then
                        Strhrs = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin = "0" + Convert.ToString(lmin)
                    Else
                        StrMin = lmin
                    End If

                    'txtMOHTotalHours.Text = Strhrs + ":" + StrMin

                End If
            End If

        End If
    End Sub

    Private Sub txtMOHNonProcessHours_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOHNonProcessHours.Leave
        If txtMOHNonProcessHours.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMOHNonProcessHours.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg75")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtMOHNonProcessHours.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg75")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMOHNonProcessHours.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMOHNonProcessHours.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMOHNonProcessHours.Text = Hrs + ":" + Min
        End If

        If txtMOHProcessHours.Text <> String.Empty And txtMOHNonProcessHours.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr(), strArr1() As String
            Dim Str, Str1 As String
            Str = txtMOHProcessHours.Text
            strArr = Str.Split(":")
            Str1 = txtMOHNonProcessHours.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

            lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

            If lmin >= 60 Then
                lmin = lmin - 60
                Lhrs = Lhrs + 1
            End If
            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs > 24 Then
                DisplayInfoMessage("Msg77")
                ''MsgBox("Total Process Hrs Cant be greater than 24 hrs ")
                txtMOHNonProcessHours.Focus()
            ElseIf Lhrs = 24 And lmin > 0 Then
                DisplayInfoMessage("Msg77")
                '' MsgBox("Total Process Hrs Cant be greater than 24 hrs ")
                txtMOHNonProcessHours.Focus()


            Else
                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                If Strhrs + ":" + StrMin <> txtMOHTotalHours.Text.Trim Then
                    MessageBox.Show("Process hours and non-process hours is incorrect.", "Incorrect Operation Hours", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                'txtMOHTotalHours.Text = Strhrs + ":" + StrMin
            End If
            'Else
            '    'txtMOHTotalHours.Text = ""
        End If

    End Sub
    Private Sub txtMOHProcessHours_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOHProcessHours.Leave
        If txtMOHProcessHours.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMOHProcessHours.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg75")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtMOHProcessHours.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg75")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMOHProcessHours.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMOHProcessHours.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMOHProcessHours.Text = Hrs + ":" + Min
        End If

        If txtMOHProcessHours.Text <> String.Empty And txtMOHNonProcessHours.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr(), strArr1() As String
            Dim Str, Str1 As String
            Str = txtMOHProcessHours.Text
            strArr = Str.Split(":")
            Str1 = txtMOHNonProcessHours.Text
            strArr1 = Str1.Split(":")

            '    Dim Lhrs, lmin As Integer

            '    Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

            '    lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

            '    If lmin >= 60 Then
            '        lmin = lmin - 60
            '        Lhrs = Lhrs + 1
            '    End If
            '    Dim Strhrs As String = "00"
            '    Dim StrMin As String = "00"

            '    If Lhrs > 24 Then
            '        DisplayInfoMessage("Msg77")
            '        ''MsgBox("Total Process Hrs Cant be greater than 24 hrs ")
            '        txtMOHNonProcessHours.Focus()
            '    ElseIf Lhrs = 24 And lmin > 0 Then
            '        DisplayInfoMessage("Msg77")
            '        '' MsgBox("Total Process Hrs Cant be greater than 24 hrs ")
            '        txtMOHNonProcessHours.Focus()


            '    Else
            '        If Lhrs < 10 Then
            '            Strhrs = "0" + Convert.ToString(Lhrs)
            '        Else
            '            Strhrs = Lhrs
            '        End If

            '        If lmin < 10 Then
            '            StrMin = "0" + Convert.ToString(lmin)
            '        Else
            '            StrMin = lmin
            '        End If

            '        If Strhrs + ":" + StrMin <> txtMOHTotalHours.Text.Trim Then
            '            MessageBox.Show("Process hours and non-process hours is incorrect.", "Incorrect Operation Hours", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        End If
            '        'txtMOHTotalHours.Text = Strhrs + ":" + StrMin
            '    End If
            'Else
            '    'txtMOHTotalHours.Text = ""
        End If

    End Sub

    Private Sub txtMOHNonProcessHours_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOHNonProcessHours.TextChanged
        If txtMOHNonProcessHours.Text <> "" Then
            Dim Value As String = txtMOHNonProcessHours.Text
            Dim strlen As Integer
            strlen = Len(txtMOHNonProcessHours.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMOHNonProcessHours.Text = Value.Substring(0, strlen - 1)
                    txtMOHNonProcessHours.Focus()
                End If
            Next
        End If

    End Sub
    Private Sub TotalHrsCalculation()
        If txtMOHProcessHours.Text <> String.Empty And txtMOHNonProcessHours.Text <> String.Empty Then
            '  Dim TProcessHrs, TNonProcessHrs, TtotalHrs As TimeSpan
            Dim lProcessHrs, lNonProcessHrs, ltotalHrs As String

            lProcessHrs = txtMOHProcessHours.Text
            lNonProcessHrs = txtMOHNonProcessHours.Text
            ltotalHrs = lProcessHrs + lNonProcessHrs

            If ltotalHrs < 0 Or ltotalHrs > 24 Then
                DisplayInfoMessage("Msg78")
                ''MsgBox("Non Process hours cant be greater than Process hours")
                txtMOHTotalHours.Text = ""
                Exit Sub
            End If

            Dim intMins As Double = 0
            Dim intHrs As Double = 0
            Dim intDiv As Double = 0
            If ltotalHrs <> 0 Then

                intMins = ltotalHrs * 100
                intMins = intMins - 40
                intHrs = intMins / 100
                intHrs = Fix(intHrs)

                intDiv = intMins Mod 100
                intDiv = Fix(intDiv)
                If intDiv >= 60 Then
                    intDiv = intDiv - 60
                    intHrs = intHrs + 1
                End If
                If intDiv.ToString.Length = 1 Then
                    txtMOHTotalHours.Text = intHrs.ToString + ".0" + intDiv.ToString
                Else
                    txtMOHTotalHours.Text = intHrs.ToString + "." + intDiv.ToString
                End If

            End If
        Else
            txtMOHTotalHours.Text = ""
        End If
    End Sub

    Private Sub DecimalIdenCheck(ByVal ptxtbox As Object)
        Dim i As Integer
        i = ptxtbox.Text.IndexOf("."c)

        If i > 0 Then
            If ptxtbox.Text.Substring(i).Length = 1 Then
                DecimalCheck = True
            End If
        End If


    End Sub


    Private Sub txtActualpercent_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActualpercent.Leave
        DecimalIdenCheck(txtActualpercent)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtActualpercent.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtStdPercent_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStdPercent.Leave
        DecimalIdenCheck(txtStdPercent)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtStdPercent.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKLEfficiency_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKLEfficiency.Leave
        DecimalIdenCheck(txtKLEfficiency)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKLEfficiency.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKLLossesprecent_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKLLossesprecent.Leave
        DecimalIdenCheck(txtKLLossesprecent)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKLLossesprecent.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKLDirtpercent_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKLDirtpercent.Leave
        DecimalIdenCheck(txtKLDirtpercent)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg80")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtKLDirtpercent.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKLPCSamplepercent_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKLPCSamplepercent.Leave
        DecimalIdenCheck(txtKLPCSamplepercent)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKLPCSamplepercent.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKLPCFibrepercent_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKLPCFibrepercent.Leave
        DecimalIdenCheck(txtKLPCFibrepercent)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKLPCFibrepercent.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKLPCTotalNutPercent_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKLPCTotalNutPercent.Leave
        DecimalIdenCheck(txtKLPCTotalNutPercent)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKLPCTotalNutPercent.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtOLAActualpercent_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOLAActualpercent.Leave
        DecimalIdenCheck(txtOLAActualpercent)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtOLAActualpercent.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtOLBAmount_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOLBAmount.Leave
        DecimalIdenCheck(txtOLBAmount)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtOLBAmount.Focus()
        End If
        DecimalCheck = False
    End Sub


    Private Sub txtFFBKLLTDS1P_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBKLLTDS1P.Leave
        DecimalIdenCheck(txtFFBKLLTDS1P)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtFFBKLLTDS1P.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtFFBKLLTDS2P_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBKLLTDS2P.Leave
        DecimalIdenCheck(txtFFBKLLTDS2P)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtFFBKLLTDS2P.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtFFBKLFibreCycP_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBKLFibreCycP.Leave
        DecimalIdenCheck(txtFFBKLFibreCycP)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtFFBKLFibreCycP.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKLFFBHydroCycP_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKLFFBHydroCycP.Leave
        DecimalIdenCheck(txtKLFFBHydroCycP)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKLFFBHydroCycP.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtFFBKLFruitinEb_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFBKLFruitinEb.Leave
        DecimalIdenCheck(txtFFBKLFruitinEb)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtFFBKLFruitinEb.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtMoistureTodayKer_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMoistureTodayKer.Leave
        DecimalIdenCheck(txtMoistureTodayKer)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtMoistureTodayKer.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtDirtTodayKer_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDirtTodayKer.Leave
        DecimalIdenCheck(txtDirtTodayKer)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg80")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtDirtTodayKer.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtBKTodayKer_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBKTodayKer.Leave
        DecimalIdenCheck(txtBKTodayKer)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtBKTodayKer.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtFFATodayCPO_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFFATodayCPO.Leave
        DecimalIdenCheck(txtFFATodayCPO)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtFFATodayCPO.Focus()
        End If
        DecimalCheck = False
        FFAPCPOCalc()

        '  If txtFFATodayCPO.Text <> "" Then
       
        'If txtCPOFFAToday.Enabled = False And CPOLFFAPMTDCalc <> txtFFATodayCPO.Text Then
        '    If Val(txtFFATodayCPO.Text) <> 0 And Val(txtCPOMonthToDate.Text) <> 0 And Val(txtCPOToday.Text) <> 0 Then
        '        Dim lFFAPMTD As Decimal
        '        lFFAPMTD = ((Val(txtFFATodayCPO.Text) * Val(txtCPOToday.Text)) + (CPOLFFAPMTDCalc * Val(txtCPOMonthToDate.Text))) / Val(txtCPOMonthToDate.Text)
        '        txtCPOFFAToday.Text = Math.Round(lFFAPMTD, 2)
        '    End If
        'End If

        'If txtCPOFFAYear.Enabled = False And CPOLFFAPYTDCalc <> txtFFATodayCPO.Text Then
        '    If Val(txtFFATodayCPO.Text) <> 0 And Val(txtCPOYearToDate.Text) <> 0 And Val(txtCPOToday.Text) <> 0 Then
        '        Dim lFFAPYTD As Decimal
        '        lFFAPYTD = ((Val(txtFFATodayCPO.Text) * Val(txtCPOToday.Text)) + (CPOLFFAPYTDCalc * Val(txtCPOYearToDate.Text))) / Val(txtCPOYearToDate.Text)
        '        txtCPOFFAYear.Text = Math.Round(lFFAPYTD, 2)
        '    End If
        'End If

        'Else
        'txtCPOFFAToday.Text = ""
        'txtCPOFFAYear.Text = ""
        'End If


       
        
    End Sub

    Private Sub txtCPOMoisture_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCPOMoisture.Leave
        DecimalIdenCheck(txtCPOMoisture)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtCPOMoisture.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtCPODirtToday_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCPODirtToday.Leave
        DecimalIdenCheck(txtCPODirtToday)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg80")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtCPODirtToday.Focus()
        End If
        DecimalCheck = False
    End Sub


    Private Sub txtPKOFFAToday_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKOFFAToday.Leave
        DecimalIdenCheck(txtPKOFFAToday)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtPKOFFAToday.Focus()
        End If
        DecimalCheck = False
        FFAPPKOCalc()
        'If txtPKOFFAToday.Text <> "" Then
        '    CPOPKOFFAPSelect()

        '    If Val(txtPKOFFAToday.Text) > 0 And PKOLFFAPMTDCalc > 0 And FFAPMonthCount > 1 And lBtnSaveAll = "Save All" Then
        '        txtPKOFFAMonth.Text = PKOLFFAPMTDCalc + Val(txtPKOFFAToday.Text)
        '    ElseIf Val(txtPKOFFAToday.Text) > 0 And PKOLFFAPMTDCalc > 0 And FFAPMonthCount > 1 And lBtnSaveAll <> "Save All" Then
        '        txtPKOFFAMonth.Text = PKOLFFAPMTDCalc + Val(txtPKOFFAToday.Text) - lFFAPKOPrev
        '    ElseIf PKOLFFAPMTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll <> "Save All" Then
        '        'txtPKOFFAMonth.Text = PKOLFFAPMTDCalc
        '        'txtPKOFFAMonth.Enabled = True
        '    ElseIf PKOLFFAPMTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll = "Save All" Then
        '        txtPKOFFAMonth.Text = PKOLFFAPMTDCalc + Val(txtPKOFFAToday.Text)
        '        txtPKOFFAMonth.Enabled = False
        '    ElseIf PKOLFFAPMTDCalc = 0 And FFAPMonthCount >= 1 Then
        '        PKOLFFAPMTDCalc = Val(txtPKOFFAToday.Text)
        '        txtPKOFFAMonth.Text = Val(txtPKOFFAToday.Text)
        '        txtPKOFFAMonth.Enabled = False
        '    ElseIf txtPKOFFAMonth.Enabled = True Then
        '    Else
        '        txtPKOFFAMonth.Text = ""
        '        txtPKOFFAMonth.Enabled = True
        '    End If

        '    If Val(txtPKOFFAToday.Text) > 0 And PKOLFFAPYTDCalc > 0 And FFAPMonthCount > 1 And lBtnSaveAll = "Save All" Then
        '        txtPKOFFAYear.Text = PKOLFFAPYTDCalc + Val(txtPKOFFAToday.Text)
        '    ElseIf Val(txtPKOFFAToday.Text) > 0 And PKOLFFAPYTDCalc > 0 And FFAPMonthCount > 1 And lBtnSaveAll <> "Save All" Then
        '        txtPKOFFAYear.Text = PKOLFFAPYTDCalc + Val(txtPKOFFAToday.Text) - lFFAPKOPrev
        '    ElseIf PKOLFFAPYTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll <> "Save All" Then
        '        'txtPKOFFAYear.Text = PKOLFFAPYTDCalc
        '        'txtPKOFFAYear.Enabled = True
        '    ElseIf PKOLFFAPYTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll = "Save All" Then
        '        txtPKOFFAYear.Text = (PKOLFFAPYTDCalc + Val(txtPKOFFAToday.Text))
        '        txtPKOFFAYear.Enabled = False
        '    ElseIf PKOLFFAPYTDCalc = 0 And FFAPMonthCount >= 1 Then
        '        PKOLFFAPYTDCalc = Val(txtPKOFFAToday.Text)
        '        txtPKOFFAYear.Text = Val(txtPKOFFAToday.Text)
        '        txtPKOFFAYear.Enabled = False
        '    ElseIf txtPKOFFAYear.Enabled = True Then
        '    Else
        '        txtPKOFFAYear.Text = ""
        '        txtPKOFFAYear.Enabled = True
        '    End If

        '    If txtPKOFFAMonth.Enabled = False And PKOLFFAPMTDCalc <> txtPKOFFAToday.Text Then
        '        If Val(txtPKOFFAToday.Text) <> 0 And Val(txtPKOMonthToDate.Text) <> 0 And Val(txtPKOToday.Text) <> 0 Then
        '            Dim lFFAPMTD As Decimal
        '            lFFAPMTD = ((Val(txtPKOFFAToday.Text) * Val(txtPKOToday.Text)) + (PKOLFFAPMTDCalc * Val(txtPKOMonthToDate.Text))) / Val(txtPKOMonthToDate.Text)
        '            txtPKOFFAMonth.Text = Math.Round(lFFAPMTD, 2)
        '        End If
        '    End If
        '    If txtPKOFFAYear.Enabled = False And PKOLFFAPYTDCalc <> txtPKOFFAToday.Text Then
        '        If Val(txtPKOFFAToday.Text) <> 0 And Val(txtPKOYearToDate.Text) <> 0 And Val(txtPKOToday.Text) <> 0 Then
        '            Dim lFFAPYTD As Decimal
        '            lFFAPYTD = ((Val(txtPKOFFAToday.Text) * Val(txtPKOToday.Text)) + (PKOLFFAPYTDCalc * Val(txtPKOYearToDate.Text))) / Val(txtPKOYearToDate.Text)
        '            txtPKOFFAYear.Text = Math.Round(lFFAPYTD, 2)
        '        End If
        '    End If

        'Else
        '    txtPKOFFAToday.Text = ""
        '    txtPKOFFAYear.Text = ""
        'End If
       
    End Sub
    Private Sub FFAPCPOCalc()
        CPOPKOFFAPSelect()

        If Val(txtFFATodayCPO.Text) > 0 And CPOLFFAPMTDCalc > 0 And FFAPMonthCount >= 1 And TotalCPOFFAPCOUNTMonth <> 0 Then
            txtCPOFFAToday.Text = ((CPOLFFAPMTDCalc + Val(txtFFATodayCPO.Text)) / (TotalCPOFFAPCOUNTMonth + 1))
        ElseIf Val(txtFFATodayCPO.Text) = 0 And CPOLFFAPMTDCalc > 0 And FFAPMonthCount >= 1 And TotalCPOFFAPCOUNTMonth <> 0 Then
            txtCPOFFAToday.Text = CPOLFFAPMTDCalc / TotalCPOFFAPCOUNTMonth
        ElseIf CPOLFFAPMTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll <> "Save All" Then
            txtCPOFFAToday.Text = CPOLFFAPMTDCalc
            txtCPOFFAToday.Enabled = True
            'ElseIf CPOLFFAPMTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll = "Save All" Then
            '    txtCPOFFAToday.Text = CPOLFFAPMTDCalc
            '    txtCPOFFAToday.Enabled = False
        ElseIf CPOLFFAPMTDCalc = 0 And FFAPMonthCount >= 1 Then
            txtCPOFFAToday.Text = Val(txtFFATodayCPO.Text)
            '  txtCPOFFAToday.Text = Val(txtFFATodayCPO.Text)
            txtCPOFFAToday.Enabled = False
        ElseIf txtCPOFFAToday.Enabled = True Then
        Else
            txtCPOFFAToday.Text = ""
            txtCPOFFAToday.Enabled = True
        End If

        If Val(txtFFATodayCPO.Text) > 0 And CPOLFFAPYTDCalc > 0 And FFAPMonthCount >= 1 And TotalCPOFFAPCOUNTYear <> 0 Then
            txtCPOFFAYear.Text = ((CPOLFFAPYTDCalc + Val(txtFFATodayCPO.Text))) / (TotalCPOFFAPCOUNTYear + 1)
        ElseIf Val(txtFFATodayCPO.Text) = 0 And CPOLFFAPYTDCalc > 0 And FFAPMonthCount >= 1 And TotalCPOFFAPCOUNTYear <> 0 Then
            txtCPOFFAYear.Text = CPOLFFAPYTDCalc / TotalCPOFFAPCOUNTYear
        ElseIf CPOLFFAPYTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll <> "Save All" Then
            txtCPOFFAYear.Text = CPOLFFAPYTDCalc
            txtCPOFFAYear.Enabled = True
            'ElseIf CPOLFFAPYTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll = "Save All" Then
            '    txtCPOFFAYear.Text = CPOLFFAPYTDCalc + Val(txtFFATodayCPO.Text)
            '    txtCPOFFAYear.Enabled = False
        ElseIf CPOLFFAPYTDCalc = 0 And FFAPMonthCount >= 1 Then
            '  CPOLFFAPYTDCalc = Val(txtFFATodayCPO.Text)
            txtCPOFFAYear.Text = Val(txtFFATodayCPO.Text)
            txtCPOFFAYear.Enabled = False
        ElseIf txtCPOFFAYear.Enabled = True Then
        Else
            txtCPOFFAYear.Text = ""
            txtCPOFFAYear.Enabled = True
        End If

        If txtCPOToday.Text = "" Then
            txtCPOFFAToday.Text = ""
            txtCPOFFAYear.Text = ""
        End If

        If Val(txtCPOFFAToday.Text) > 0 And txtCPOFFAToday.Enabled = False Then
            txtCPOFFAToday.Text = Format(Val(txtCPOFFAToday.Text), "0.00")
        End If
        If Val(txtCPOFFAYear.Text) > 0 And txtCPOFFAYear.Enabled = False Then
            txtCPOFFAYear.Text = Format(Val(txtCPOFFAYear.Text), "0.00")
        End If

    End Sub
    Private Sub FFAPPKOCalc()
        CPOPKOFFAPSelect()

        If Val(txtPKOFFAToday.Text) > 0 And PKOLFFAPMTDCalc > 0 And FFAPMonthCount >= 1 And TotalCPOFFAPCOUNTMonth <> 0 Then

            txtPKOFFAMonth.Text = ((PKOLFFAPMTDCalc + Val(txtPKOFFAToday.Text)) / (TotalCPOFFAPCOUNTMonth + 1))
        ElseIf Val(txtPKOFFAToday.Text) = 0 And PKOLFFAPMTDCalc > 0 And FFAPMonthCount >= 1 And TotalCPOFFAPCOUNTMonth <> 0 Then
            txtPKOFFAMonth.Text = PKOLFFAPMTDCalc / TotalCPOFFAPCOUNTMonth
        ElseIf PKOLFFAPMTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll <> "Save All" Then
            txtPKOFFAMonth.Text = PKOLFFAPMTDCalc
            txtPKOFFAMonth.Enabled = True
            'ElseIf PKOLFFAPMTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll = "Save All" Then
            '    txtPKOFFAToday.Text = PKOLFFAPMTDCalc
            '    txtPKOFFAToday.Enabled = False
        ElseIf PKOLFFAPMTDCalc = 0 And FFAPMonthCount >= 1 Then
            txtPKOFFAMonth.Text = Val(txtPKOFFAToday.Text)
            '  txtPKOFFAToday.Text = Val(txtPKOFFAToday.Text)
            txtPKOFFAMonth.Enabled = False
        ElseIf txtPKOFFAMonth.Enabled = True Then
        Else
            txtPKOFFAMonth.Text = ""
            txtPKOFFAMonth.Enabled = True
        End If

        If Val(txtPKOFFAToday.Text) > 0 And PKOLFFAPYTDCalc > 0 And FFAPMonthCount >= 1 And TotalCPOFFAPCOUNTYear <> 0 Then
            txtPKOFFAYear.Text = ((PKOLFFAPYTDCalc + Val(txtPKOFFAToday.Text))) / (TotalCPOFFAPCOUNTYear + 1)
        ElseIf Val(txtPKOFFAToday.Text) = 0 And PKOLFFAPYTDCalc > 0 And FFAPMonthCount >= 1 And TotalCPOFFAPCOUNTYear <> 0 Then
            txtPKOFFAYear.Text = PKOLFFAPYTDCalc / TotalCPOFFAPCOUNTYear
        ElseIf PKOLFFAPYTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll <> "Save All" Then
            txtPKOFFAYear.Text = PKOLFFAPYTDCalc
            txtPKOFFAYear.Enabled = True
            'ElseIf PKOLFFAPYTDCalc > 0 And FFAPMonthCount = 1 And lBtnSaveAll = "Save All" Then
            '    txtPKOFFAYear.Text = PKOLFFAPYTDCalc + Val(txtPKOFFAToday.Text)
            '    txtPKOFFAYear.Enabled = False
        ElseIf PKOLFFAPYTDCalc = 0 And FFAPMonthCount >= 1 Then
            '  PKOLFFAPYTDCalc = Val(txtPKOFFAToday.Text)
            txtPKOFFAYear.Text = Val(txtPKOFFAToday.Text)
            txtPKOFFAYear.Enabled = False
        ElseIf txtPKOFFAYear.Enabled = True Then
        Else
            txtPKOFFAYear.Text = ""
            txtPKOFFAYear.Enabled = True
        End If

        If txtPKOToday.Text = "" Then
            txtPKOFFAMonth.Text = ""
            txtPKOFFAYear.Text = ""
        End If

        If Val(txtPKOFFAMonth.Text) > 0 And txtPKOFFAMonth.Enabled = False Then
            txtPKOFFAMonth.Text = Format(Val(txtPKOFFAMonth.Text), "0.00")
        End If
        If Val(txtPKOFFAYear.Text) > 0 And txtPKOFFAYear.Enabled = False Then
            txtPKOFFAYear.Text = Format(Val(txtPKOFFAYear.Text), "0.00")
        End If
    End Sub

    Private Sub txtPKOMoisture_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKOMoisture.Leave
        DecimalIdenCheck(txtPKOMoisture)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtPKOMoisture.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtPKODirt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKODirt.Leave
        DecimalIdenCheck(txtPKODirt)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg80")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtPKODirt.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKernelInTakeMoisture_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelInTakeMoisture.Leave
        DecimalIdenCheck(txtKernelInTakeMoisture)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKernelInTakeMoisture.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKernelInTakeReceivedTon_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelInTakeReceivedTon.Leave
        DecimalIdenCheck(txtKernelInTakeReceivedTon)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKernelInTakeReceivedTon.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKernelInTakeDirt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelInTakeDirt.Leave
        DecimalIdenCheck(txtKernelInTakeDirt)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg80")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtKernelInTakeDirt.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtERMEfficiencyP_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DecimalIdenCheck(txtERMEfficiencyP)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtERMEfficiencyP.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKernelInTakeBrokenKernel_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelInTakeBrokenKernel.Leave
        DecimalIdenCheck(txtKernelInTakeBrokenKernel)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKernelInTakeBrokenKernel.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKQSMoisture_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKQSMoisture.Leave
        DecimalIdenCheck(txtKQSMoisture)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKQSMoisture.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKQSDirt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKQSDirt.Leave
        DecimalIdenCheck(txtKQSDirt)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg80")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtKQSDirt.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtKQSBrokenKernel_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKQSBrokenKernel.Leave
        DecimalIdenCheck(txtKQSBrokenKernel)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtKQSBrokenKernel.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtOQSFFA_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOQSFFA.Leave
        DecimalIdenCheck(txtOQSFFA)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtOQSFFA.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtOQSMoisture_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOQSMoisture.Leave
        DecimalIdenCheck(txtOQSMoisture)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtOQSMoisture.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtOQSDirt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOQSDirt.Leave
        DecimalIdenCheck(txtOQSDirt)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg80")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtOQSDirt.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtMOHMeterFrom_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOHMeterFrom.Leave
        If txtMOHMeterFrom.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMOHMeterFrom.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg75")
                '' MessageBox.Show("User Can enter only HH or HH:MM ")
                txtMOHMeterFrom.Focus()
                Exit Sub
            End If

            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg75")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMOHMeterFrom.Focus()
                    Exit Sub
                End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMOHMeterFrom.Focus()
                    Exit Sub
                    'ElseIf strArr(1) >= 1 And strArr(1) < 6 Then
                    '    DisplayInfoMessage("Msg81")
                    '    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    '    txtMOHMeterFrom.Focus()
                    '    Exit Sub
                ElseIf Len(strArr(1)) > 2 Then
                    DisplayInfoMessage("Msg82")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 100 ")
                    txtMOHMeterFrom.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMOHMeterFrom.Text = Hrs + ":" + Min
        End If

        If txtMOHMeterFrom.Text <> String.Empty And txtMOHMeterTo.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr(), strArr1() As String
            Dim Str, Str1 As String
            Str = txtMOHMeterTo.Text
            strArr = Str.Split(":")
            Str1 = txtMOHMeterFrom.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = strArr(0) - strArr1(0)

            If strArr1(1) > strArr(1) Then
                lmin = strArr1(1) - strArr(1)
                Lhrs = Lhrs - 1
            ElseIf strArr1(1) < strArr(1) Then
                lmin = strArr(1) - strArr1(1)
            End If
            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs >= 24 Then
                DisplayInfoMessage("Msg73")
                '' MsgBox("Process Hrs Cant be greater than 24 hrs ")
                txtMOHProcessHours.Text = ""
                txtMOHMeterFrom.Focus()
            ElseIf Lhrs = 24 And lmin > 0 Then
                DisplayInfoMessage("Msg73")
                '' MsgBox("Process Hrs Cant be greater than 24 hrs ")
                txtMOHProcessHours.Text = ""
                txtMOHMeterFrom.Focus()
            ElseIf Lhrs < 0 Then
                'DisplayInfoMessage("Msg83")
                ''MsgBox("Meter To Value should be greater than Meter From")
                'txtMOHProcessHours.Text = ""
                'txtMOHMeterFrom.Focus()

                'time is set to the next date, so add 1 day to current date and get total hours
                Dim currentDate As DateTime = dtpLabAnalDate.Value
                Dim fromDate As DateTime = currentDate.ToString("yyyy-MM-dd") + " " + txtMOHMeterFrom.Text
                Dim toDate As DateTime = DateAdd(DateInterval.Day, 1, Convert.ToDateTime(currentDate.ToString("yyyy-MM-dd") + " " + txtMOHMeterTo.Text))
                Dim minutes As Long = DateDiff(DateInterval.Minute, fromDate, toDate)
                Lhrs = DateDiff(DateInterval.Hour, fromDate, toDate)
                lmin = minutes - (Lhrs * 60)

                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                txtMOHTotalHours.Text = Strhrs + ":" + StrMin

            Else
                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                txtMOHProcessHours.Text = Strhrs + ":" + StrMin
            End If

        End If

    End Sub

    Private Sub txtMOHMeterTo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOHMeterTo.Leave
        If txtMOHMeterTo.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMOHMeterTo.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg75")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtMOHMeterTo.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg75")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMOHMeterTo.Focus()
                    Exit Sub
                End If



                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    '' MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMOHMeterTo.Focus()
                    Exit Sub
                    'ElseIf strArr(1) >= 1 And strArr(1) < 6 Then
                    '    DisplayInfoMessage("Msg81")
                    '    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    '    txtMOHMeterTo.Focus()
                    '    Exit Sub
                ElseIf Len(strArr(1)) > 2 Then
                    DisplayInfoMessage("Msg82")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 100 ")
                    txtMOHMeterTo.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMOHMeterTo.Text = Hrs + ":" + Min
        End If

        If txtMOHMeterFrom.Text <> String.Empty And txtMOHMeterTo.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr(), strArr1() As String
            Dim Str, Str1 As String
            Str = txtMOHMeterTo.Text
            strArr = Str.Split(":")
            Str1 = txtMOHMeterFrom.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

           

            If Val(strArr1(0)) = Val(strArr(0)) And Val(strArr(1)) = 0 And Val(strArr1(1)) = 0 Then
                Lhrs = 24
                lmin = 0
            Else
                Lhrs = Val(strArr(0)) - Val(strArr1(0))
                lmin = Val(strArr(1)) - Val(strArr1(1))
            End If


            If lmin < 0 Then
                Lhrs = Lhrs - 1
                lmin = lmin + 60
            End If



            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs > 24 Then
                DisplayInfoMessage("Msg74")
                ''MsgBox("Process Hrs Cant be greater than 24 hrs ")
                txtMOHProcessHours.Text = ""
                txtMOHMeterTo.Focus()
            ElseIf Lhrs = 24 And lmin > 0 Then
                DisplayInfoMessage("Msg74")
                ''MsgBox("Process Hrs Cant be greater than 24 hrs ")
                txtMOHProcessHours.Text = ""
                txtMOHMeterTo.Focus()
            ElseIf Lhrs < 0 Then
                'DisplayInfoMessage("Msg83")
                ''MsgBox("Meter To Value should be greater than Meter From")
                'txtMOHProcessHours.Text = ""
                'txtMOHMeterTo.Focus()

                'time is set to the next date, so add 1 day to current date and get total hours
                Dim currentDate As DateTime = dtpLabAnalDate.Value
                Dim fromDate As DateTime = currentDate.ToString("yyyy-MM-dd") + " " + txtMOHMeterFrom.Text
                Dim toDate As DateTime = DateAdd(DateInterval.Day, 1, Convert.ToDateTime(currentDate.ToString("yyyy-MM-dd") + " " + txtMOHMeterTo.Text))
                Dim minutes As Long = DateDiff(DateInterval.Minute, fromDate, toDate)
                Lhrs = DateDiff(DateInterval.Hour, fromDate, toDate)
                lmin = minutes - (Lhrs * 60)

                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                txtMOHTotalHours.Text = Strhrs + ":" + StrMin
            Else
                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                'txtMOHProcessHours.Text = Strhrs + ":" + StrMin

                txtMOHTotalHours.Text = Strhrs + ":" + StrMin
            End If

        End If

    End Sub

    Private Sub txtBWAValue_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBWAValue.Leave
        DecimalIdenCheck(txtBWAValue)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtBWAValue.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtSoftDosage_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoftDosage.Leave
        DecimalIdenCheck(txtSoftDosage)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg79")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.50 ;Invalid Values 10.)")
            txtSoftDosage.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtMOHMonthToDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOHMonthToDate.KeyDown
        'KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtMOHMonthToDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOHMonthToDate.KeyPress
        ' KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMOHMonthToDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOHMonthToDate.Leave
        If txtMOHMonthToDate.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMOHMonthToDate.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg75")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtMOHMonthToDate.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg75")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtMOHMonthToDate.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg84")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtMOHMonthToDate.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMOHMonthToDate.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg81")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMOHMonthToDate.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMOHMonthToDate.Text = Hrs + ":" + Min
        End If

        If txtMOHMonthToDate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            str = txtMOHMonthToDate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtMOHTotalHours.Text
            strArrTotal = strTotal.Split(":")

            If strArr(0) < strArrTotal(0) Or (strArr(0) <= strArrTotal(0) And strArr(1) < strArrTotal(1)) Then
                DisplayInfoMessage("Msg85")
                ''MessageBox.Show("Month To Date Hrs cant be lesser than Total Hrs")
                txtMOHMonthToDate.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub txtMOHYearToDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtMOHYearToDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMOHYearToDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOHYearToDate.Leave
        If txtMOHYearToDate.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMOHYearToDate.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg86")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtMOHYearToDate.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg86")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtMOHYearToDate.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg84")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtMOHYearToDate.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMOHYearToDate.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg81")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMOHYearToDate.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMOHYearToDate.Text = Hrs + ":" + Min
        End If

        If txtMOHYearToDate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMOHYearToDate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtMOHTotalHours.Text
            strArrTotal = strTotal.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtMOHMonthToDate.Text
            strArrMonth = strMonth.Split(":")

            If strArr(0) < strArrTotal(0) Or (strArr(0) <= strArrTotal(0) And strArr(1) < strArrTotal(1)) Then
                DisplayInfoMessage("Msg87")
                ''MessageBox.Show("Year To Date Hrs cant be lesser than Total Hrs")
                txtMOHYearToDate.Focus()
                Exit Sub
            End If

            If strArr(0) < strArrMonth(0) Or (strArr(0) <= strArrMonth(0) And strArr(1) < strArrMonth(1)) Then
                DisplayInfoMessage("Msg88")
                ''MessageBox.Show("Year To Date Hrs cant be lesser than Month To Date Hrs")
                txtMOHYearToDate.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtMOHMeterFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOHMeterFrom.TextChanged
        If txtMOHMeterFrom.Text <> "" Then
            Dim Value As String = txtMOHMeterFrom.Text
            Dim strlen As Integer
            strlen = Len(txtMOHMeterFrom.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMOHMeterFrom.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg89")
                    ''MsgBox("Please enter numeric values only")
                    txtMOHMeterFrom.Focus()
                End If
            Next
        End If

    End Sub

    Private Sub txtMOHMeterTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOHMeterTo.TextChanged
        If txtMOHMeterTo.Text <> "" Then
            Dim Value As String = txtMOHMeterTo.Text
            Dim strlen As Integer
            strlen = Len(txtMOHMeterTo.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMOHMeterTo.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg89")
                    ''MsgBox("Please enter numeric values only")
                    txtMOHMeterTo.Focus()
                End If
            Next
        End If

    End Sub

    Private Sub txtMOHMonthToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOHMonthToDate.TextChanged
        If txtMOHMonthToDate.Text <> "" Then
            Dim Value As String = txtMOHNonProcessHours.Text
            Dim strlen As Integer
            strlen = Len(txtMOHMonthToDate.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMOHMonthToDate.Text = Value.Substring(0, strlen - 1)
                    txtMOHMonthToDate.Focus()
                End If
            Next
        End If

        'If txtMOHMonthToDate.Text = "00:00" And ddlMachineName.SelectedIndex <> 0 Then

        '    Dim ds As New DataSet
        '    Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        '    objLaboratoryAnalysisPPT.LabAnalysisDate = dtpLabAnalDate.Value
        '    objLaboratoryAnalysisPPT.MOHMachineID = ddlMachineName.SelectedValue.ToString
        '    ds = LaboratoryAnalysisBOL.LabMOHMonthYearHrsCheck(objLaboratoryAnalysisPPT)

        '    If ds.Tables(3) IsNot Nothing And ds.Tables(3).Rows.Count > 0 Then
        '        txtMOHMonthToDate.Text = ds.Tables(3).Rows(0).Item("MonthToDateHrs").ToString
        '    Else
        '        txtMOHMonthToDate.Text = ""
        '    End If

        'End If
        ''If txtMOHMonthToDate.Text = "00:00" Then
        ''    txtMOHMonthToDate.Enabled = True
        ''    ' lblMOHMonthToDate.ForeColor = Color.Red
        ''Else
        ''    txtMOHMonthToDate.Enabled = False
        ''    'lblMOHMonthToDate.ForeColor = Color.Black
        ''End If
    End Sub

    Private Sub txtMOHYearToDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOHYearToDate.TextChanged
        If txtMOHYearToDate.Text <> "" Then
            Dim Value As String = txtMOHYearToDate.Text
            Dim strlen As Integer
            strlen = Len(txtMOHYearToDate.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMOHYearToDate.Text = Value.Substring(0, strlen - 1)
                    txtMOHYearToDate.Focus()
                End If
            Next
        End If

        'If txtMOHYearToDate.Text = "00:00" And ddlMachineName.SelectedIndex <> 0 Then

        '    Dim ds As New DataSet
        '    Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        '    objLaboratoryAnalysisPPT.LabAnalysisDate = dtpLabAnalDate.Value
        '    objLaboratoryAnalysisPPT.MOHMachineID = ddlMachineName.SelectedValue.ToString
        '    ds = LaboratoryAnalysisBOL.LabMOHMonthYearHrsCheck(objLaboratoryAnalysisPPT)

        '    If ds.Tables(6) IsNot Nothing And ds.Tables(6).Rows.Count > 0 Then
        '        txtMOHYearToDate.Text = ds.Tables(6).Rows(0).Item("YearToDateHrs").ToString
        '    Else
        '        txtMOHYearToDate.Text = ""
        '    End If
        'End If
        'If txtMOHYearToDate.Text = "00:00" Then
        '    txtMOHYearToDate.Enabled = True
        '    'lblMOHYearToDate.ForeColor = Color.Red
        'Else
        '    txtMOHYearToDate.Enabled = False
        '    ' lblMOHYearToDate.ForeColor = Color.Black
        'End If

    End Sub

    Private Sub ddlMachineName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMachineName.SelectedIndexChanged
        Dim lrow As Integer
        lrow = ddlMachineName.SelectedIndex
        If lrow > 0 Then
            lblMacineNameDescp.Text = dsMachineName.Rows(lrow).Item("Descp").ToString
        Else
            lblMacineNameDescp.Text = ""
        End If


        If ddlMachineName.SelectedIndex = 0 Then
            txtMOHMonthToDate.Enabled = False
            txtMOHYearToDate.Enabled = False
            'Else
            '    MOHMonthYearSelect()
        End If





    End Sub

    Private Sub tcLaboratoryAnalysis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcLaboratoryAnalysis.SelectedIndexChanged
        If tcLaboratoryAnalysis.SelectedIndex = 4 Then
            ddlMachineName.SelectedIndex = 0
        End If
    End Sub
    Private Sub GetMonthYearQty()

        Dim objPKOLogPPT As New LaboratoryAnalysisPPT
        Dim dsProdQty As DataSet
        objPKOLogPPT.LabAnalysisDate = dtpLabAnalDate.Value
        objPKOLogPPT.MOHMachineID = ddlMachineName.SelectedValue.ToString
        dsProdQty = LaboratoryAnalysisBOL.LaboratoryMOPGetMonthYearHrs(objPKOLogPPT)


        If dsProdQty.Tables(6).Rows.Count <> 0 Then
            If Not dsProdQty.Tables(6).Rows(0).Item("MonthToDateHrs") Is DBNull.Value Then
                lmonthValuehrs = dsProdQty.Tables(6).Rows(0).Item("MonthToDateHrs")
                lmonthValuehrs = ToModifyTime(lmonthValuehrs)
            End If
        End If
        If dsProdQty.Tables(13).Rows.Count <> 0 Then
            If Not dsProdQty.Tables(13).Rows(0).Item("YearToDateHrs") Is DBNull.Value Then
                lYearValue = dsProdQty.Tables(13).Rows(0).Item("YearToDateHrs")
                lYearValue = ToModifyTime(lYearValue)
            End If
        End If

        MonthCount = dsProdQty.Tables(14).Rows(0).Item("MonthCountHrs")
        YearCount = dsProdQty.Tables(15).Rows(0).Item("YearCountHrs")

        If MonthCount = 0 Or (MonthCount = 1 And lBtnSaveAll <> "Save All") Then
            txtMOHMonthToDate.Enabled = True
        Else
            txtMOHMonthToDate.Enabled = False
        End If

        If YearCount = 0 Or (YearCount = 1 And lBtnSaveAll <> "Save All") Then
            txtMOHYearToDate.Enabled = True
        Else
            txtMOHYearToDate.Enabled = False

        End If

    End Sub
    Private Sub txtMOHTotalHours_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOHTotalHours.TextChanged
        If txtMOHTotalHours.Text <> "" Then
            GetMonthYearQty()

            If txtMOHTotalHours.Text <> "" And lmonthValuehrs <> "00:00" And MonthCount > 1 And lBtnSaveAll = "Save All" Then
                txtMOHMonthToDate.Text = ToaddHours(txtMOHTotalHours.Text, lmonthValuehrs)
            ElseIf txtMOHTotalHours.Text <> "" And lmonthValuehrs <> "00:00" And MonthCount > 1 And lBtnSaveAll <> "Save All" Then
                txtMOHMonthToDate.Text = ToaddHours(txtMOHTotalHours.Text, lmonthValuehrs)
            ElseIf lmonthValuehrs <> "00:00" And MonthCount = 1 And lBtnSaveAll <> "Save All" Then
                txtMOHMonthToDate.Text = lmonthValuehrs
                'disable control if there is a previous month to date value
                txtMOHMonthToDate.Enabled = False
            ElseIf lmonthValuehrs <> "00:00" And MonthCount = 1 And lBtnSaveAll = "Save All" Then
                txtMOHMonthToDate.Text = ToaddHours(txtMOHTotalHours.Text, lmonthValuehrs)
                txtMOHMonthToDate.Enabled = False
            ElseIf lmonthValuehrs = "00:00" And MonthCount >= 1 Then
                txtMOHMonthToDate.Text = txtMOHTotalHours.Text
                txtMOHMonthToDate.Enabled = False
            Else
                txtMOHMonthToDate.Text = ""
                txtMOHMonthToDate.Enabled = True
            End If

            If txtMOHTotalHours.Text <> "" And lYearValue <> "00:00" And YearCount > 1 And lBtnSaveAll = "Save All" Then
                txtMOHYearToDate.Text = ToaddHours(txtMOHTotalHours.Text, lYearValue)
            ElseIf txtMOHTotalHours.Text <> "" And lYearValue <> "00:00" And YearCount > 1 And lBtnSaveAll <> "Save All" Then
                txtMOHYearToDate.Text = ToaddHours(txtMOHTotalHours.Text, lYearValue)
            ElseIf lYearValue <> "00:00" And YearCount = 1 And lBtnSaveAll <> "Save All" Then
                txtMOHYearToDate.Text = lYearValue
                'disable control if there is a previous year to date value
                txtMOHYearToDate.Enabled = False
            ElseIf lYearValue <> "00:00" And YearCount = 1 And lBtnSaveAll = "Save All" Then
                txtMOHYearToDate.Text = ToaddHours(txtMOHTotalHours.Text, lYearValue)
                txtMOHYearToDate.Enabled = False
            ElseIf lYearValue = "00:00" And YearCount >= 1 Then
                txtMOHYearToDate.Text = txtMOHTotalHours.Text
                txtMOHYearToDate.Enabled = False
            Else
                txtMOHYearToDate.Text = ""
                txtMOHYearToDate.Enabled = True
            End If


        End If

    End Sub

    Private Function ToModifyTime(ByVal ModifyTime As String)
        Dim Hrs As String = "00"
        Dim Min As String = "00"
        Dim str As String
        Dim strArr() As String
        str = ModifyTime
        strArr = str.Split(":")
        If strArr(0).Length = 1 Then
            Hrs = "0" + strArr(0)
        Else
            Hrs = strArr(0)
        End If
        Min = strArr(1)
        ModifyTime = Hrs + ":" + Min
        Return ModifyTime
    End Function


    Private Function ToaddHours(ByVal Hours1 As String, ByVal Hours2 As String)
        Dim Calchrs As String
        Dim strArr4(), strArr3() As String
        Dim Str4, Str3 As String
        Str4 = Hours1
        strArr4 = Str4.Split(":")
        Str3 = Hours2
        strArr3 = Str3.Split(":")

        Dim Lhrs2, lmin2 As Integer

        Lhrs2 = CInt(strArr4(0)) + CInt(strArr3(0))
        lmin2 = CInt(strArr4(1)) + CInt(strArr3(1))

        If lmin2 >= 60 Then
            lmin2 = lmin2 - 60
            Lhrs2 = Lhrs2 + 1
        End If
        Dim Strhrs2 As String = "00"
        Dim StrMin2 As String = "00"


        If Lhrs2 < 10 Then
            Strhrs2 = "0" + Convert.ToString(Lhrs2)
        Else
            Strhrs2 = Lhrs2
        End If

        If lmin2 < 10 Then
            StrMin2 = "0" + Convert.ToString(lmin2)
        Else
            StrMin2 = lmin2
        End If
        Calchrs = Strhrs2 + ":" + StrMin2
        Return Calchrs
    End Function


    Private Function ToSubHours(ByVal Hours1 As String, ByVal Hours2 As String)
        Dim Calchrs As String
        Dim strArr4(), strArr3() As String
        Dim Str4, Str3 As String
        Str4 = Hours1
        strArr4 = Str4.Split(":")
        Str3 = Hours2
        strArr3 = Str3.Split(":")

        Dim Lhrs2, lmin2 As Integer

        Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))

        If strArr3(1) > strArr4(1) Then
            lmin2 = 60 - strArr3(1) - strArr4(1)
            Lhrs2 = Lhrs2 - 1
        ElseIf strArr3(1) < strArr4(1) Then
            lmin2 = strArr4(1) - strArr3(1)
        End If
        Dim Strhrs2 As String = "00"
        Dim StrMin2 As String = "00"


        If Lhrs2 < 10 Then
            Strhrs2 = "0" + Convert.ToString(Lhrs2)
        Else
            Strhrs2 = Lhrs2
        End If

        If lmin2 < 10 Then
            StrMin2 = "0" + Convert.ToString(lmin2)
        Else
            StrMin2 = lmin2
        End If

        Calchrs = Strhrs2 + ":" + StrMin2
        Return Calchrs
    End Function

 
   

    Private Sub txtCPOFFAToday_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCPOFFAToday.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtCPOFFAToday_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPOFFAToday.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtCPOFFAYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCPOFFAYear.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtCPOFFAYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPOFFAYear.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtPKOFFAMonth_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKOFFAMonth.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtPKOFFAMonth_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKOFFAMonth.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtPKOFFAYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPKOFFAYear.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtPKOFFAYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKOFFAYear.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub
    Private Sub tbLabAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbLabAnalysis.Click
        Dim Datagridcheck As Boolean = False

        If (dgvOilLosses.RowCount > 0 Or dgvKernelLosses.RowCount > 0 Or dgvKernelLossesPCF.RowCount > 0 Or dgvOilLossesA.RowCount > 0 Or dgvOilLossesB.RowCount > 0 Or dgvKernelLossesFFB.RowCount > 0 Or dgvSoftner.RowCount > 0 Or dgvKernelInTake.RowCount > 0 Or dgvEffRippleMill.RowCount > 0 Or dgvKernelQtyStorage.RowCount > 0 Or dgvOilQtyStorage.RowCount > 0 Or dgvMachineryOperation.RowCount > 0 Or dgvBoilerWaterAnalysis.RowCount > 0) Then
            Datagridcheck = True
        End If

        If btnSaveAll.Enabled = True And Datagridcheck = True And tbLabAnalysis.SelectedIndex = 1 Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                tbLabAnalysis.SelectedIndex = 0

            Else
                ClearKernelCPOPKOProduction()
                ClearBoilWaterAnalysis()
                ClearEfficiencyripleMill()
                ClearKernelInTake()
                ClearKernelLossesFFB()
                ClearKernelLosses()
                ClearKernelLossesPCF()
                ClearKernelQtyStorage()
                ClearOilLosses()
                ClearOillossesB()
                ClearOillossesA()
                ClearOilQtyStorage()
                ClearSoftner()
                ClearMachineryOperation()
                ddlEqptKernelLosses.SelectedIndex = 0
                ddlEquitOilLosses.SelectedIndex = 0
                ddlMachineName.SelectedIndex = 0
                ClearGridView(dgvOilLosses)
                ClearGridView(dgvKernelLosses)
                ClearGridView(dgvKernelLossesPCF)
                ClearGridView(dgvOilLossesA)
                ClearGridView(dgvOilLossesB)
                ClearGridView(dgvKernelLossesFFB)
                ClearGridView(dgvKernelInTake)
                ClearGridView(dgvEffRippleMill)
                ClearGridView(dgvKernelQtyStorage)
                ClearGridView(dgvOilQtyStorage)
                ClearGridView(dgvMachineryOperation)
                ClearGridView(dgvBoilerWaterAnalysis)
                ClearGridView(dgvSoftner)
                BindDataGrid()
                GlobalPPT.IsRetainFocus = False

            End If
        Else
            ClearKernelCPOPKOProduction()
            ClearBoilWaterAnalysis()
            ClearEfficiencyripleMill()
            ClearKernelInTake()
            ClearKernelLossesFFB()
            ClearKernelLosses()
            ClearKernelLossesPCF()
            ClearKernelQtyStorage()
            ClearOilLosses()
            ClearOillossesB()
            ClearOillossesA()
            ClearOilQtyStorage()
            ClearSoftner()
            ClearMachineryOperation()
            ddlEqptKernelLosses.SelectedIndex = 0
            ddlEquitOilLosses.SelectedIndex = 0
            ddlMachineName.SelectedIndex = 0
            ClearGridView(dgvOilLosses)
            ClearGridView(dgvKernelLosses)
            ClearGridView(dgvKernelLossesPCF)
            ClearGridView(dgvOilLossesA)
            ClearGridView(dgvOilLossesB)
            ClearGridView(dgvKernelLossesFFB)
            ClearGridView(dgvKernelInTake)
            ClearGridView(dgvEffRippleMill)
            ClearGridView(dgvKernelQtyStorage)
            ClearGridView(dgvOilQtyStorage)
            ClearGridView(dgvMachineryOperation)
            ClearGridView(dgvBoilerWaterAnalysis)
            ClearGridView(dgvSoftner)
            BindDataGrid()


        End If



    End Sub


    Private Sub ddlProductTypeOilQtyStorage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlProductTypeOilQtyStorage.SelectedIndexChanged
        Dim objLaboratoryAnalysisPPT As New LaboratoryAnalysisPPT
        Dim ds As DataSet

        objLaboratoryAnalysisPPT.OQSProductType = ddlProductTypeOilQtyStorage.SelectedValue.ToString()
        ds = LaboratoryAnalysisBOL.LabOilQualityStorageTankNo_Select(objLaboratoryAnalysisPPT)
        
        ddlTankOilQtyStorage.DataSource = ds.Tables(0)
        ddlTankOilQtyStorage.DisplayMember = "TankNo"
        ddlTankOilQtyStorage.ValueMember = "TankID"

        Dim dr As DataRow = ds.Tables(0).NewRow()
        dr(0) = "--Select--"
        dr(1) = "--Select--"
        ds.Tables(0).Rows.InsertAt(dr, 0)
        ddlTankOilQtyStorage.SelectedIndex = 0


    End Sub

    Private Sub txtFFBKLLTDS3P_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBKLLTDS3P.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtFFBKLLTDS3P_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBKLLTDS3P.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtFFBKLLTDS4P_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFFBKLLTDS4P.KeyDown
        KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtFFBKLLTDS4P_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFFBKLLTDS4P.KeyPress
        KeyPress2Decimal(sender, e)
    End Sub
End Class