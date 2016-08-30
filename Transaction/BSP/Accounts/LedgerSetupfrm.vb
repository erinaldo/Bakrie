Imports Accounts_BOL
Imports Accounts_PPT
Imports System.Data.SqlClient
Imports Common_BOL
Imports Common_PPT

Public Class LedgerSetupfrm
    Dim strGridCurrentRowVale As String = String.Empty

    Dim strLedgerSetUpID As String
    Dim strLedgerSetUpIDForDelete As String
    Dim objCheckDuplicateRecord As Object = 0
    Dim lbtnSave As String = String.Empty
    Dim lLedgerType As String = String.Empty

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Shadows mdiparent As New MDIParent


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim objLedgerSetpUp As New LedgerSetupPPT

        If (txtLedgerType.Text.Trim  = "") Then
            DisplayInfoMessage("MsgLedgerType")
            'MessageBox.Show("Ledger Type Required", "Ledger Type")
            txtLedgerType.Focus()
            Exit Sub
            'ElseIf (txtLedgerDescription.Text = "") Then
            '    DisplayInfoMessage("MsgLedgerDescription")
            '    'MessageBox.Show("Description Required", "Ledger Description")
            '    txtLedgerDescription.Focus()
            '    Exit Sub
        End If

        If (lbtnSave = "Update") Then

            If lLedgerType <> txtLedgerType.Text Then
                objLedgerSetpUp.Ledgertype = txtLedgerType.Text
                objCheckDuplicateRecord = Accounts_BOL.LedgerSetupBOL.ChechDuplicateLedgerTypeExists(objLedgerSetpUp)
                If (objCheckDuplicateRecord = 0) Then
                    DisplayInfoMessage("MsgLedgerTypeExist")
                    ''MessageBox.Show("LedgerType Already Exists ! Please choose different Ledger Type")
                    Exit Sub
                End If

            End If



            objLedgerSetpUp.Ledgertype = txtLedgerType.Text.Trim
            objLedgerSetpUp.LedgerTypeDescp = txtLedgerDescription.Text.Trim
            objLedgerSetpUp.LedgerSetUpID = strLedgerSetUpID
            Accounts_BOL.LedgerSetupBOL.UpdateLedgerSetup(objLedgerSetpUp)

            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Save"
            Else
                btnSave.Text = "simpan"
            End If

            dgLedgerTypeDetails.AutoGenerateColumns = False
            dgLedgerTypeDetails.DataSource = Accounts_BOL.LedgerSetupBOL.BindDataGridView(objLedgerSetpUp).Tables(0)
            txtLedgerDescription.Text = ""
            txtLedgerType.Text = ""
            DisplayInfoMessage("MsgdtaUpdate")
            '' MessageBox.Show("Data Updated Successfully")
        Else
            objLedgerSetpUp.Ledgertype = txtLedgerType.Text
            objCheckDuplicateRecord = Accounts_BOL.LedgerSetupBOL.ChechDuplicateLedgerTypeExists(objLedgerSetpUp)
            If (objCheckDuplicateRecord = 0) Then
                DisplayInfoMessage("MsgLedgerTypeExist")
                '' MessageBox.Show("LedgerType Already Exists ! Please choose different Ledger Type")
                Exit Sub
            End If
            objLedgerSetpUp.Ledgertype = txtLedgerType.Text
            objLedgerSetpUp.LedgerTypeDescp = txtLedgerDescription.Text.Trim().Replace("'", "")
            Accounts_BOL.LedgerSetupBOL.SaveLedgerSetup(objLedgerSetpUp)

            dgLedgerTypeDetails.AutoGenerateColumns = False
            dgLedgerTypeDetails.DataSource = Accounts_BOL.LedgerSetupBOL.BindDataGridView(objLedgerSetpUp).Tables("Accounts.LedgerSetup")

            dgLedgerTypeDetails.DataSource = Accounts_BOL.LedgerSetupBOL.BindDataGridView(objLedgerSetpUp).Tables(0)
            txtLedgerDescription.Text = ""
            txtLedgerType.Text = ""
            DisplayInfoMessage("MsgdtaSave")
            ''MessageBox.Show("Data Saved Successfully")
        End If

        lbtnSave = "Save"
        GlobalPPT.IsRetainFocus = False
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LedgerSetupfrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

     


        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LedgerSetupfrm))
        If txtLedgerType.Text <> "" Then
            If MsgBox(rm.GetString("Msg28"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = True
                Me.Close()
            Else
                GlobalPPT.IsRetainFocus = True
                GlobalPPT.IsButtonClose = False
            End If
        Else
            Me.Close()
        End If
       

        
    End Sub


    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtLedgerDescription.Text = ""
        txtLedgerType.Text = ""
        If GlobalPPT.strLang = "en" Then
            btnSave.Text = "Save"
        Else
            btnSave.Text = "simpan"
        End If

        lbtnSave = "Save"
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        GlobalPPT.IsRetainFocus = False

    End Sub

    Private Sub dgLedgerTypeDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLedgerTypeDetails.CellDoubleClick
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditUpdateToolStripMenuItem.Enabled = True Then
                strLedgerSetUpID = dgLedgerTypeDetails.CurrentRow.Cells("LedgerSetUpId").Value
                txtLedgerType.Text = dgLedgerTypeDetails.CurrentRow.Cells("LedgerType").Value.ToString()
                txtLedgerDescription.Text = dgLedgerTypeDetails.CurrentRow.Cells("LedgerDescription").Value.ToString()
                lLedgerType = dgLedgerTypeDetails.CurrentRow.Cells("LedgerType").Value.ToString()
                If GlobalPPT.strLang = "en" Then
                    btnSave.Text = "Update"
                Else
                    btnSave.Text = "Memperbarui"
                End If
                lbtnSave = "Update"
                btnSave.Enabled = True
            End If

        End If
       
       

    End Sub

    Private Sub UpdateLegerSetup()
        If objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditUpdateToolStripMenuItem.Enabled = True Then
                btnSave.Enabled = True
            End If
        End If

        strLedgerSetUpID = dgLedgerTypeDetails.SelectedRows.Item(0).Cells("LedgerSetUpId").Value
        txtLedgerType.Text = dgLedgerTypeDetails.SelectedRows.Item(0).Cells("LedgerType").Value.ToString()
        lLedgerType = dgLedgerTypeDetails.SelectedRows.Item(0).Cells("LedgerType").Value.ToString()
        txtLedgerDescription.Text = dgLedgerTypeDetails.SelectedRows.Item(0).Cells("LedgerDescription").Value.ToString()
        If GlobalPPT.strLang = "en" Then
            btnSave.Text = "Update"
        Else
            btnSave.Text = "Memperbarui"
        End If
        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
    End Sub

    Private Sub LedgerSetupfrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (txtLedgerType.Text <> "" And GlobalPPT.IsButtonClose = False) Then
            Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LedgerSetupfrm))
            If MsgBox(rm.GetString("Msg63"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M101"

            End If
        End If
    End Sub

    Private Sub LedgerSetupfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False

        If Not objUserLoginBOl.Privilege(btnSave, AddToolStripMenuItem, EditUpdateToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If
        SetUICulture(GlobalPPT.strLang)
        Dim objLedgerSetpUp As New LedgerSetupPPT
        dgLedgerTypeDetails.AutoGenerateColumns = False
        dgLedgerTypeDetails.DataSource = Accounts_BOL.LedgerSetupBOL.BindDataGridView(objLedgerSetpUp).Tables(0)
    End Sub


    Private Sub dgLedgerTypeDetails_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgLedgerTypeDetails.MouseHover

        '    strLedgerSetUpIDForDelete = dgLedgerTypeDetails.CurrentRow.Cells("LedgerSetUpId").Value.ToString()
    End Sub


    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        txtLedgerType.Focus()
    End Sub

    Private Sub EditUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUpdateToolStripMenuItem.Click
        lbtnSave = "Update"
        UpdateLegerSetup()
    End Sub



    Private Sub dgLedgerTypeDetails_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgLedgerTypeDetails.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = sender.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not dgLedgerTypeDetails.Rows(hti.RowIndex).Selected Then
                    ' User right clicked a row that is not selected, so throw away all other selections and select this row
                    dgLedgerTypeDetails.ClearSelection()
                    dgLedgerTypeDetails.Rows(hti.RowIndex).Selected = True
                    If (dgLedgerTypeDetails.SelectedRows.Item(0).Cells("LedgerSetUpId").Value.ToString() <> Nothing) Then
                        strLedgerSetUpIDForDelete = dgLedgerTypeDetails.SelectedRows.Item(0).Cells("LedgerSetUpId").Value.ToString()
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        txtLedgerDescription.Text = ""
        txtLedgerType.Text = ""
        If GlobalPPT.strLang = "en" Then
            btnSave.Text = "Save"
        Else
            btnSave.Text = "simpan"
        End If

        lbtnSave = "Save"


        Dim objLedgerSetpUp As New LedgerSetupPPT
        objLedgerSetpUp.LedgerSetUpID = dgLedgerTypeDetails.SelectedRows(0).Cells("LedgerSetUpId").Value.ToString()
        If (dgLedgerTypeDetails.SelectedRows(0).Cells("LedgerSetUpId").Value.ToString() = String.Empty) Then
            DisplayInfoMessage("MsgNoRowstodelete")
            Exit Sub
        End If

        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LedgerSetupfrm))
        If MsgBox(rm.GetString("MsgDlte"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then

            Try
                Dim LedgerSetupCheck As Integer
                LedgerSetupCheck = Accounts_BOL.LedgerSetupBOL.DeleteLedgerSetup(objLedgerSetpUp)
                If LedgerSetupCheck = 1 Then
                    DisplayInfoMessage("MsgCantDlte")
                Else
                    dgLedgerTypeDetails.AutoGenerateColumns = False
                    dgLedgerTypeDetails.DataSource = Accounts_BOL.LedgerSetupBOL.BindDataGridView(objLedgerSetpUp).Tables(0)
                    DisplayInfoMessage("MsgDeletedsfly")
                End If
            Catch ex As Exception
                DisplayInfoMessage("Msgexcantdelt")
            End Try

        End If

    End Sub
    Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LedgerSetupfrm))
        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            'Add Tab Controls
            gpAddLedgerType.Text = rm.GetString("gpAddLedgerType.Text")
            gpLedgerTypeToGridDisplay.Text = rm.GetString("gpLedgerTypeToGridDisplay.Text")
            'Add Lables
            lblLedgerType.Text = rm.GetString("lblLedgerType.Text")
            lblLedgerDescription.Text = rm.GetString("lblLedgerDescription.Text")
            cmsLedgerDetail.Items.Item(0).Text = rm.GetString("cmsLedgerDetail.Items.Item(0).Text")
            cmsLedgerDetail.Items.Item(1).Text = rm.GetString("cmsLedgerDetail.Items.Item(1).Text")
            cmsLedgerDetail.Items.Item(2).Text = rm.GetString("cmsLedgerDetail.Items.Item(2).Text")

            'Add Datagrid Fields

            dgLedgerTypeDetails.Columns("LedgerType").HeaderText = rm.GetString("dgLedgerTypeDetails.Columns(LedgerType).HeaderText")
            dgLedgerTypeDetails.Columns("LedgerDescription").HeaderText = rm.GetString("dgLedgerTypeDetails.Columns(LedgerDescription).HeaderText")


            'Add Btn Fields
            btnSave.Text = rm.GetString("btnSave.Text")
            btnReset.Text = rm.GetString("btnReset.Text")
            btnClose.Text = rm.GetString("btnClose.Text")
            TabControl1.TabPages("TabPage1").Text = rm.GetString("TabControl1.TabPages(TabPage1).Text")
            cmsLedgerDetail.Items.Item(0).Text = rm.GetString("cmsLedgerDetail.Items.Item(0).Text")
            cmsLedgerDetail.Items.Item(1).Text = rm.GetString("cmsLedgerDetail.Items.Item(1).Text")
            cmsLedgerDetail.Items.Item(2).Text = rm.GetString("cmsLedgerDetail.Items.Item(2).Text")


        Catch
            'display a message if the culture is not supported
            'try passing bn (Bengali) for testing
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabControl1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dgLedgerTypeDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgLedgerTypeDetails.KeyDown
        If e.KeyCode = 13 Then
            strLedgerSetUpID = dgLedgerTypeDetails.CurrentRow.Cells("LedgerSetUpId").Value
            txtLedgerType.Text = dgLedgerTypeDetails.CurrentRow.Cells("LedgerType").Value.ToString()
            txtLedgerDescription.Text = dgLedgerTypeDetails.CurrentRow.Cells("LedgerDescription").Value.ToString()
            lLedgerType = dgLedgerTypeDetails.CurrentRow.Cells("LedgerType").Value.ToString()
            If GlobalPPT.strLang = "en" Then
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Memperbarui"
            End If

            lbtnSave = "Update"
        End If
    End Sub

    Private Sub LedgerSetupfrm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave


        'If MsgBox(" Data not saved", MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
        '    'MsgBox(rm.GetString("UnSavedAlert"), MsgBoxStyle.OkOnly, "Information")
        '    Me.TabControl1.SelectTab(0)
        '    btnSave.Focus()
        'End If
    End Sub

    Private Sub LedgerSetupfrm_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ParentChanged
        'If MsgBox(" Data not saved", MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
        '    'MsgBox(rm.GetString("UnSavedAlert"), MsgBoxStyle.OkOnly, "Information")
        '    Me.TabControl1.SelectTab(0)
        '    btnSave.Focus()
        ' End If
    End Sub

    Private Sub LedgerSetupfrm_MdiChildActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MdiChildActivate
        If MsgBox(" Data not saved", MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
            'MsgBox(rm.GetString("UnSavedAlert"), MsgBoxStyle.OkOnly, "Information")
            Me.TabControl1.SelectTab(0)
            btnSave.Focus()
        End If
    End Sub

    Private Sub dgLedgerTypeDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgLedgerTypeDetails.CellContentClick

    End Sub
End Class