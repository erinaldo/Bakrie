Imports Common_DAL
Imports Common_PPT
Imports Common_BOL
Imports System.Windows.Forms

Public Class UserLoginBOL
    Dim objUserLoginPPT As New Common_PPT.RolePrivilegePPT
    Dim displaymsg As String = String.Empty

    Public Function AccessUser(ByVal MenuID As String, ByVal RoleID As String) As String

        Dim RoleTable As DataSet
        Dim objLoginBOL As New LoginBOL

        objUserLoginPPT.MID = MenuID
        objUserLoginPPT.RID = RoleID

        RoleTable = objLoginBOL.UserLogin(objUserLoginPPT)

        If RoleTable.Tables(0).Rows.Count > 0 Then

            objUserLoginPPT.View = Convert.ToBoolean(RoleTable.Tables(0).Rows(0)("Visible"))
            objUserLoginPPT.Add = Convert.ToBoolean(RoleTable.Tables(0).Rows(0)("RAdd"))
            objUserLoginPPT.Update = Convert.ToBoolean(RoleTable.Tables(0).Rows(0)("RUpdate"))
            objUserLoginPPT.Delete = Convert.ToBoolean(RoleTable.Tables(0).Rows(0)("RDelete"))

        End If

        If objUserLoginPPT.View = True Then
            If objUserLoginPPT.Add = False And objUserLoginPPT.Update = False And objUserLoginPPT.Delete = False Then
                displaymsg = "You have the following permission in this screen: View only"
            ElseIf objUserLoginPPT.Add = False And objUserLoginPPT.Update = False And objUserLoginPPT.Delete = True Then
                displaymsg = "You have the following permission in this screen: Delete only"
            ElseIf objUserLoginPPT.Add = False And objUserLoginPPT.Update = True And objUserLoginPPT.Delete = False Then
                displaymsg = "You have the following permission in this screen: Update only"
            ElseIf objUserLoginPPT.Add = False And objUserLoginPPT.Update = True And objUserLoginPPT.Delete = True Then
                displaymsg = "You have the following permissions in this screen: Update and Delete only"
            ElseIf objUserLoginPPT.Add = True And objUserLoginPPT.Update = False And objUserLoginPPT.Delete = False Then
                displaymsg = "You have the following permission in this screen: Add only"
            ElseIf objUserLoginPPT.Add = True And objUserLoginPPT.Update = False And objUserLoginPPT.Delete = True Then
                displaymsg = "You have the following permissions in this screen: Add and Delete only"
            ElseIf objUserLoginPPT.Add = True And objUserLoginPPT.Update = True And objUserLoginPPT.Delete = False Then
                displaymsg = "You have the following permissions in this screen: Add and Update only"
            ElseIf objUserLoginPPT.Add = True And objUserLoginPPT.Update = True And objUserLoginPPT.Delete = True Then
                displaymsg = "You have the following permissions in this screen: Add ,Update and Delete only"
            Else

            End If

        End If
        Return displaymsg

        'Create Read Update Delete

    End Function


    Public Function Privilege(ByRef objSaveBtn As Button, ByRef objAddToolStripMenuItem As ToolStripMenuItem, _
     ByRef objUpdateToolStripMenuItem As ToolStripMenuItem, _
   ByRef objDeleteToolStripMenuItem As ToolStripMenuItem, ByRef asError As String) As Boolean
        Try

            If objSaveBtn.Text Like "Save*" Or objSaveBtn.Text Like "Simpan*" Or objSaveBtn.Text Like "Add*" Then
                objSaveBtn.Enabled = objUserLoginPPT.Add

                objAddToolStripMenuItem.Enabled = objUserLoginPPT.Add
                objUpdateToolStripMenuItem.Enabled = objUserLoginPPT.Update

            ElseIf objSaveBtn.Text Like "Update*" Or objSaveBtn.Text Like "Dadangm*" Or objSaveBtn.Text Like "Edit*" Then
                'objUserLoginPPT.Update = True
                objSaveBtn.Enabled = objUserLoginPPT.Update
                objUpdateToolStripMenuItem.Enabled = objUserLoginPPT.Update
                objAddToolStripMenuItem.Enabled = objUserLoginPPT.Add

            End If

            If objUserLoginPPT.Delete = False Then
                objDeleteToolStripMenuItem.Enabled = False
            End If

            Return True

        Catch ex As Exception
            asError = ex.Message
        End Try
    End Function

    Public Function Privilege_weighbridge(ByRef objSaveBtn As Button, ByRef asError As String) As Boolean
        Try

            If objSaveBtn.Text Like "Save*" Or objSaveBtn.Text Like "Simpan*" Or objSaveBtn.Text Like "Add*" Then
                objSaveBtn.Enabled = objUserLoginPPT.Add

                'objAddToolStripMenuItem.Enabled = objUserLoginPPT.Add
                'objUpdateToolStripMenuItem.Enabled = objUserLoginPPT.Update

            ElseIf objSaveBtn.Text Like "Update*" Or objSaveBtn.Text Like "Dadangm*" Or objSaveBtn.Text Like "Edit*" Then
                'objUserLoginPPT.Update = True
                objSaveBtn.Enabled = objUserLoginPPT.Update
                'objUpdateToolStripMenuItem.Enabled = objUserLoginPPT.Update
                'objAddToolStripMenuItem.Enabled = objUserLoginPPT.Add

            End If

            If objUserLoginPPT.Delete = False Then
                'objDeleteToolStripMenuItem.Enabled = False
            End If

            Return True

        Catch ex As Exception
            asError = ex.Message
        End Try
    End Function

End Class
