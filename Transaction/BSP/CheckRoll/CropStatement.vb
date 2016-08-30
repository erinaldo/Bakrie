Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Imports CheckRoll_DAL
Imports Common_PPT
Imports CheckRoll_BOL
Imports CheckRoll_PPT

Public Class CropStatement

    Dim addflag As Boolean = True
    Dim strblockid As String
    Dim strdivid As String
    Dim stryopid As String
    Dim strCYID As String
    Dim strCropStatementID As String
    Dim reDecimalPlaces0 As New System.Text.RegularExpressions.Regex("^\d{0,18}(\.\d{0,0})?$")
    Dim isDecimal, isModifierKey As Boolean
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CropStatement))

    Private Sub btnblocklookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnblocklookup.Click
        Dim SubBlockLookup_Form As SubBlockLookups
        Dim retValue As Windows.Forms.DialogResult
        SubBlockLookup_Form = New SubBlockLookups("")

        retValue = SubBlockLookup_Form.ShowDialog()

        If retValue = Windows.Forms.DialogResult.OK Then
            txtblock.Text = SubBlockLookup_Form.SubBlockName
            strblockid = SubBlockLookup_Form.SubBlockID
            lblDIVdsp.Text = SubBlockLookup_Form.DIV
            strdivid = SubBlockLookup_Form.DivID
            lblYOPdsp.Text = SubBlockLookup_Form.YOP
            stryopid = SubBlockLookup_Form.YOPID
 
        End If

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Clear()

    End Sub
    Private Sub clear()
        txtblock.Text = String.Empty
        txtblock.Focus()
        txtBunches.Text = String.Empty
        txtMillWeight.Text = String.Empty
        txtsearchblock.Text = String.Empty
        lblDIVdsp.Text = String.Empty
        lblYOPdsp.Text = String.Empty
        dtAD.Value = DateTime.Today
        strblockid = String.Empty
        strdivid = String.Empty
        stryopid = String.Empty
        strCropStatementID = String.Empty
        strCYID = String.Empty

        cmbYieldType.SelectedIndex = 0
        addflag = True
        btnSave.Text = "Save"

    End Sub

    Private Sub txtblock_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtblock.Leave
        If txtblock.Text.Trim() <> String.Empty Then

            Dim DT As DataTable

            DT = DailyAttendanceWithTeam_DAL.CRSubBlockSelect(txtblock.Text)

            If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                lblDIVdsp.Text = String.Empty
                lblYOPdsp.Text = String.Empty
                txtblock.Text = String.Empty

                strblockid = String.Empty
                stryopid = String.Empty
                strdivid = String.Empty

                DisplayInfoMessage("Msg1")
                'MessageBox.Show("Field No not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtblock.Focus()
                Exit Sub

            ElseIf DT.Rows.Count = 1 Then

                txtblock.Text = DT.Rows(0).Item("BlockName").ToString()
                strblockid = DT.Rows(0).Item("BlockID").ToString()

                lblDIVdsp.Text = DT.Rows(0).Item("DIVName").ToString()
                strdivid = DT.Rows(0).Item("DivID").ToString()

                lblYOPdsp.Text = DT.Rows(0).Item("YOP").ToString()
                stryopid = DT.Rows(0).Item("YOPID").ToString()

            End If
        Else
            txtblock.Text = String.Empty
            strblockid = String.Empty

            lblDIVdsp.Text = String.Empty
            strdivid = String.Empty

            lblYOPdsp.Text = String.Empty
            stryopid = String.Empty

        End If
    End Sub

    Private Sub CropStatement_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetUICulture(GlobalPPT.strLang)
        cmbYieldType.SelectedIndex = 0
        cmbSearchYieldType.SelectedIndex = 0
        tcCropStatement.SelectedTab = tbpgView
        Gridbind()
        clear()

    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CropStatement))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)
            tcCropStatement.TabPages("tbpgCropStatement").Text = rm.GetString("tbpgCropStatement")
            tcCropStatement.TabPages("tbpgView").Text = rm.GetString("tbpgView")
 
            lblBlock.Text = rm.GetString("lblBlock")
            lblDiv.Text = rm.GetString("lblDiv")
            lblYOP.Text = rm.GetString("lblYOP")
            lblYieldType.Text = rm.GetString("lblYieldType")
            lblMillWeight.Text = rm.GetString("lblMillWeight")
            lblBunches.Text = rm.GetString("lblBunches")

            lblSearchblock.Text = rm.GetString("lblSearchblock")
            lblSearchYieldType.Text = rm.GetString("lblSearchYieldType")
            lblviewSearchBy.Text = rm.GetString("lblviewSearchBy")
            lblRecordNotFound.Text = rm.GetString("lblRecordNotFound")

            btnSave.Text = rm.GetString("btnSave")
            btnReset.Text = rm.GetString("btnReset")
            btnClose.Text = rm.GetString("btnClose")
            btnviewCropstatementSearch.Text = rm.GetString("btnviewCropstatementSearch")
            btnviewCropstatementReport.Text = rm.GetString("btnviewCropstatementReport")

            pnlCropstatementSearch.CaptionText = rm.GetString("pnlCropstatementSearch")

             
            dgvviewCropstatement.Columns("dgvBlock").HeaderText = rm.GetString("dgvBlock")
            dgvviewCropstatement.Columns("dgvDIV").HeaderText = rm.GetString("dgvDIV")
            dgvviewCropstatement.Columns("dgvYOP").HeaderText = rm.GetString("dgvYOP")
            dgvviewCropstatement.Columns("dgvYieldType").HeaderText = rm.GetString("dgvYieldType")
            dgvviewCropstatement.Columns("dgvMillWeight").HeaderText = rm.GetString("dgvMillWeight")
            dgvviewCropstatement.Columns("dgvBunches").HeaderText = rm.GetString("dgvBunches")

             
            'dgvviewCReceived.Columns("RejectedReason").HeaderText = rm.GetString("dgvviewCReceived.Columns(RejectedReason).HeaderText")

        Catch
            ''display a message if the culture is not supported
            ''try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Gridbind()

        Dim objCropStatementPPT As New CropStatement_PPT
        Dim dt As New DataTable

        lblRecordNotFound.Visible = False

        With objCropStatementPPT
            ._BlockID = strblockid
            If cmbSearchYieldType.SelectedIndex = 0 Then
                ._CropYieldID = ""
            Else
                ._CropYieldID = strCYID
            End If

        End With

        dt = CropStatement_BOL.CropStatementSearch(objCropStatementPPT)

        If dt.Rows.Count = 0 Then
            lblRecordNotFound.Visible = True
        Else
            lblRecordNotFound.Visible = False

        End If

        dgvviewCropstatement.AutoGenerateColumns = False
        dgvviewCropstatement.DataSource = dt
        dgvviewCropstatement.AutoGenerateColumns = False

        strblockid = String.Empty
        strCYID = String.Empty

        Exit Sub

    End Sub

    Private Sub cmbYieldType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYieldType.SelectedIndexChanged
        If cmbYieldType.SelectedIndex = 1 Then
            txtBunches.Enabled = False
            txtBunches.Text = String.Empty
        Else
            txtBunches.Enabled = True
        End If
    End Sub
    Private Function Validation() As Boolean
        Dim CropStatementPPT As New CropStatement_PPT
        Dim dt As DataTable

        If txtblock.Text.Trim = String.Empty Then
            DisplayInfoMessage("Msg2")
            'MessageBox.Show("Block Field is Required")
            txtblock.Focus()
            Return False
        End If

        If Not IsDate(dtAD.Value) Then
            MessageBox.Show("Date is required")
            dtAD.Focus()
        End If


        If txtMillWeight.Text = String.Empty Then
            DisplayInfoMessage("Msg3")
            'MessageBox.Show("Mill Weight Field is Required")
            txtMillWeight.Focus()
            Return False
        End If
        With CropStatementPPT
            ._CropYieldCode = cmbYieldType.Text
        End With

        dt = CropStatement_BOL.GetCropYieldID(CropStatementPPT)

        If dt.Rows.Count > 0 Then
            strCYID = dt.Rows(0).Item("CropYieldID").ToString
        Else
            strCYID = String.Empty
        End If

        If strCYID = String.Empty Then
            DisplayInfoMessage("Msg4")
            'MessageBox.Show("CropYield is not Found")
            Return False
        End If


        Return True
    End Function

    Private Sub txtMillWeight_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMillWeight.KeyDown, txtBunches.KeyDown
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

                        If txtBox.Text.Trim.Contains("") Then
                            isDecimal = False
                            Return
                        End If

                        isDecimal = True
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

                        isDecimal = reDecimalPlaces0.IsMatch(text)

                End Select
            Else
                isDecimal = False
                Return
            End If

        Else
            isDecimal = True
        End If

    End Sub

    Private Sub txtMillWeight_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMillWeight.KeyPress, txtBunches.KeyPress
        If isModifierKey Then
            e.Handled = True
            Return
        End If


        If isDecimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim ObjCropStatementPPT As New CropStatement_PPT
        Dim int As Integer

        If addflag = True Then
            If Validation() = True Then

                With ObjCropStatementPPT
                    ._BlockID = strblockid
                    ._DivID = strdivid
                    ._YOPID = stryopid
                    ._CropYieldID = strCYID
                    ._MilWeight = txtMillWeight.Text.Trim
                    If txtBunches.Text <> String.Empty Then
                        ._Bunches = txtBunches.Text
                    Else
                        ._Bunches = 0
                    End If
                    ._DDate = dtAD.Value
                End With

                int = CropStatement_BOL.CropStatementInsert(ObjCropStatementPPT)
                DisplayInfoMessage("Msg5")
                'MessageBox.Show("Record Inserted Sucessfully")
                clear()

            Else
                Exit Sub
            End If
        Else
            If Validation() = True Then
                With ObjCropStatementPPT
                    ._CropStatementID = strCropStatementID
                    ._BlockID = strblockid
                    ._DivID = strdivid
                    ._YOPID = stryopid
                    ._CropYieldID = strCYID
                    ._MilWeight = txtMillWeight.Text.Trim
                    If txtBunches.Text <> String.Empty Then
                        ._Bunches = txtBunches.Text
                    Else
                        ._Bunches = 0
                    End If
                    ._DDate = dtAD.Value
                End With
                int = CropStatement_BOL.CropStatementUpdate(ObjCropStatementPPT)
                DisplayInfoMessage("Msg6")
                'MessageBox.Show("Record Updated Sucessfully")
                clear()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnviewCropstatementSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewCropstatementSearch.Click


        If searchvalidation() = True Then
            Gridbind()
        Else
            ClearGridView(dgvviewCropstatement)
            lblRecordNotFound.Visible = True
        End If

    End Sub

    Private Function searchvalidation()
       
        Dim CropStatementPPT As New CropStatement_PPT
        Dim DT As DataTable

        If cmbSearchYieldType.SelectedIndex <> 0 Then
            With CropStatementPPT
                ._CropYieldCode = cmbSearchYieldType.Text.Trim
            End With

            DT = CropStatement_BOL.GetCropYieldID(CropStatementPPT)

            If DT.Rows.Count > 0 Then
                strCYID = DT.Rows(0).Item("CropYieldID").ToString
            Else
                strCYID = String.Empty
                DisplayInfoMessage("Msg7")
                'MessageBox.Show("Yield Type Not Found", "BSP")
                ClearGridView(dgvviewCropstatement)
                Return False
            End If
        End If

        If txtsearchblock.Text.Trim() <> String.Empty Then

            DT = DailyAttendanceWithTeam_DAL.CRSubBlockSelect(txtsearchblock.Text)

            If DT.Rows.Count = 0 Or DT.Rows.Count > 1 Then
                strblockid = String.Empty
                txtblock.Focus()
                Return False

            ElseIf DT.Rows.Count = 1 Then

                '' txtsearchblock.Text = DT.Rows(0).Item("BlockName").ToString()
                strblockid = DT.Rows(0).Item("BlockID").ToString()

            End If

        End If









        Return True

    End Function

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

    Private Sub btnsearchblocklookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearchblocklookup.Click
        Dim SubBlockLookup_Form As SubBlockLookups
        Dim retValue As Windows.Forms.DialogResult
        SubBlockLookup_Form = New SubBlockLookups("")

        retValue = SubBlockLookup_Form.ShowDialog()

        If retValue = Windows.Forms.DialogResult.OK Then
            txtsearchblock.Text = SubBlockLookup_Form.SubBlockName
            strblockid = SubBlockLookup_Form.SubBlockID
        End If

    End Sub

    Private Sub dgvviewCropstatement_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvviewCropstatement.CellDoubleClick
        EditViewGridRecord()
    End Sub

    Private Sub EditViewGridRecord()
        Dim ObjCropStatementPPT As New CropStatement_PPT
        Dim dt As New DataTable
 
        If dgvviewCropstatement.Rows.Count > 0 Then
            txtblock.Text = dgvviewCropstatement.SelectedRows(0).Cells("dgvBlock").Value.ToString().Trim
            lblDIVdsp.Text = dgvviewCropstatement.SelectedRows(0).Cells("dgvDIV").Value.ToString().Trim
            lblYOPdsp.Text = dgvviewCropstatement.SelectedRows(0).Cells("dgvYOP").Value.ToString().Trim
            If dgvviewCropstatement.SelectedRows(0).Cells("dgvYieldType").Value.ToString().Trim = "FFB" Then
                cmbYieldType.SelectedIndex = 0
            ElseIf dgvviewCropstatement.SelectedRows(0).Cells("dgvYieldType").Value.ToString().Trim = "Loose Fruits" Then
                cmbYieldType.SelectedIndex = 1
            End If
            txtMillWeight.Text = dgvviewCropstatement.SelectedRows(0).Cells("dgvMillWeight").Value.ToString().Trim
            txtBunches.Text = dgvviewCropstatement.SelectedRows(0).Cells("dgvBunches").Value.ToString().Trim

            strblockid = dgvviewCropstatement.SelectedRows(0).Cells("dgvBlockID").Value.ToString().Trim
            strdivid = dgvviewCropstatement.SelectedRows(0).Cells("dgvDIVID").Value.ToString().Trim
            stryopid = dgvviewCropstatement.SelectedRows(0).Cells("dgvYOPID").Value.ToString().Trim
            strCYID = dgvviewCropstatement.SelectedRows(0).Cells("dgvCropYieldID").Value.ToString().Trim
            strCropStatementID = dgvviewCropstatement.SelectedRows(0).Cells("dgvCropStatementID").Value.ToString().Trim

            addflag = False
            btnSave.Text = "Update"

        End If
        tcCropStatement.SelectedTab = tbpgCropStatement
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        Dim ObjCropStatementPPT As New CropStatement_PPT
        Dim int As New Integer

        If dgvviewCropstatement.Rows.Count > 0 Then

            strCropStatementID = dgvviewCropstatement.SelectedRows(0).Cells("dgvCropStatementID").Value.ToString()
            ObjCropStatementPPT._CropStatementID = strCropStatementID
            CropStatement_BOL.CropStatementDelete(ObjCropStatementPPT)
        Else
            Exit Sub
            DisplayInfoMessage("Msg8")
            'MessageBox.Show(" No Record to Delete", " BSP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Gridbind()
        clear()

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        EditViewGridRecord()
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        tcCropStatement.SelectedTab = tbpgCropStatement
        clear()
    End Sub

    Private Sub tcCropStatement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcCropStatement.Click

        If tcCropStatement.SelectedTab Is tbpgView Then
            If txtblock.Text.Trim <> String.Empty Or txtMillWeight.Text.Trim <> String.Empty Then
                If MsgBox(rm.GetString("Msg9"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                    clear()
                    GlobalPPT.IsRetainFocus = False
                    clear()
                    Gridbind()
                Else
                    tcCropStatement.SelectedTab = tbpgCropStatement
                End If
                
            End If
            clear()
            Gridbind()
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub lblBlock_Click(sender As System.Object, e As System.EventArgs) Handles lblBlock.Click

    End Sub

    Private Sub Label15_Click(sender As System.Object, e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub txtblock_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtblock.TextChanged

    End Sub
End Class