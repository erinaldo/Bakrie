Imports System.IO

Public Class AppSetting

    Dim ConfigPathname As String
    Dim xDS As New DBConfig

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        
        Save()

        ClearAll()
        LoadDBlist()

    End Sub

    Sub Save()
        If btnSave.Text = "Save" Then

            '-----------ALLOW ONLY 1 Database to be entered --- Comment the below line to allow multiple-databases
            'xDS = New DBConfig

            Dim xRow As DBConfig.DBListRow
            xRow = xDS.DBList.NewDBListRow
            xRow.Server = txtServer.Text.Trim()
            xRow.DBName = txtDB.Text.Trim()
            xRow.User = txtUser.Text.Trim()
            xRow.Password = Common_DAL.EncryptionDAL.Encrypt(txtPassword.Text.Trim())
            xRow.DSN = txtDSN.Text.Trim()
            xDS.DBList.AddDBListRow(xRow)
            xDS.WriteXml(ConfigPathname, System.Data.XmlWriteMode.IgnoreSchema)
        Else
            'update selected record
            For Each xRow As DBConfig.DBListRow In xDS.DBList.Rows
                If xRow.ID = txtID.Text Then
                    xRow.Server = txtServer.Text.Trim()
                    xRow.DBName = txtDB.Text.Trim()
                    xRow.User = txtUser.Text.Trim()
                    xRow.Password = Common_DAL.EncryptionDAL.Encrypt(txtPassword.Text.Trim())
                    xRow.DSN = txtDSN.Text.Trim()
                End If
            Next

            Try
                xDS.WriteXml(ConfigPathname, System.Data.XmlWriteMode.IgnoreSchema)
                MessageBox.Show("Settings Saved", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Could not save the settings. Please run the program as Administrator to perform this action", "Settings Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

        End If
    End Sub

    Private Sub AppSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ConfigPathname = Application.StartupPath + "\BSP.exe.DBConfig"

        'MessageBox.Show(ConfigPathname)

        LoadDBlist()

    End Sub

    Sub LoadDBlist()
        If New FileInfo(ConfigPathname).Exists Then
            xDS = New DBConfig
            xDS.ReadXml(ConfigPathname, System.Data.XmlReadMode.IgnoreSchema)

            dgwDatabaseList.DataSource = xDS.DBList

        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearAll()
    End Sub

    Sub ClearAll()
        txtServer.Text = ""
        txtDB.Text = ""
        txtUser.Text = ""
        txtPassword.Text = ""
        txtDSN.Text = ""
        txtID.Text = ""
        btnSave.Text = "Save"
    End Sub

    Private Sub dgwDatabaseList_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwDatabaseList.CellDoubleClick
        LoadSelectedRecord()
    End Sub

    Sub LoadSelectedRecord()
        If dgwDatabaseList.SelectedRows.Count > 0 Then
            txtServer.Text = Me.dgwDatabaseList.SelectedRows(0).Cells("Server").Value.ToString()
            txtDB.Text = Me.dgwDatabaseList.SelectedRows(0).Cells("DBName").Value.ToString()
            txtUser.Text = Me.dgwDatabaseList.SelectedRows(0).Cells("User").Value.ToString()
            Try
                txtPassword.Text = Common_DAL.EncryptionDAL.Decrypt(Me.dgwDatabaseList.SelectedRows(0).Cells("Password").Value.ToString())
            Catch
                txtPassword.Text = ""
            End Try
            txtDSN.Text = Me.dgwDatabaseList.SelectedRows(0).Cells("DSN").Value.ToString()
            txtID.Text = Me.dgwDatabaseList.SelectedRows(0).Cells("ID").Value.ToString()
            btnSave.Text = "Update"
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtID.Text.Trim().Length > 0 Then
            For Each xRow As DBConfig.DBListRow In xDS.DBList.Rows
                If xRow.ID = txtID.Text Then
                    xDS.DBList.RemoveDBListRow(xRow)
                    Exit For
                End If
            Next

            Try
                xDS.WriteXml(ConfigPathname, System.Data.XmlWriteMode.IgnoreSchema)
                MessageBox.Show("Settings Updated", "Settings Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Could not update the settings. Please run the program as Administrator to perform this action", "Settings Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            ClearAll()
            LoadDBlist()
        End If
    End Sub

    Private Sub btnSaveAndExit_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAndExit.Click
        Save()
        Me.DialogResult = DialogResult.OK
    End Sub
End Class