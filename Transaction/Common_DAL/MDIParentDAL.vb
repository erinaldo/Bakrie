Imports System.Data.SqlClient
Imports Common_PPT

Public Class MDIParentDAL
    Dim objSQL As New SQLHelp()
    Public Shared arrMenu(,) As String
    Public Shared arrMenuGroup As New ArrayList()
    Public Shared Function GetMenuInfo(ByVal MDIPPT As MDIParentPPT, ByVal MenuAccess As String) As MDIParentPPT

        arrMenuGroup.Clear()
        MDIPPT.arrMenuGroupList.Clear()
        Dim clsUser As New MDIParentPPT
        ' Dim clsLogin As New UserMasterPPT
        Dim objdb As New SQLHelp
        Dim iFlag As Integer = 0
        Dim ds As New DataSet
        Dim Parm(3) As SqlParameter

        Try
            Parm(0) = New SqlParameter("@ModID", MDIPPT.ModID)

            If GlobalPPT.strLang = "en" Then
                Parm(1) = New SqlParameter("@Lang", 1)
            Else
                Parm(1) = New SqlParameter("@Lang", 0)
            End If
            Parm(2) = New SqlParameter("@MenuAccess", MenuAccess)
            Parm(3) = New SqlParameter("@RoleID", UserMasterPPT.RoleID)

            ds = objdb.ExecQuery("MDIMenuSelect", Parm)

            MDIPPT.RowCount = ds.Tables(0).Rows.Count

            For Each dr As DataRow In ds.Tables(0).Rows
                clsUser.MenuID = IIf(IsDBNull(dr("MenuID")), "", dr("MenuID"))
                clsUser.MenuName = IIf(IsDBNull(dr("MenuName")), "", dr("MenuName"))
                clsUser.MenuGroupID = IIf(IsDBNull(dr("MenuID")), "", dr("MenuID"))
                clsUser.MenuGroup = IIf(IsDBNull(dr("MenuGroup")), "", dr("MenuGroup"))
                clsUser.ModName = IIf(IsDBNull(dr("ModName")), "", dr("ModName"))
                iFlag = 0
                If clsUser.arrMenuGroupList.Count <= 0 Then
                    clsUser.arrMenuGroupList.Add(clsUser.MenuGroup)
                ElseIf clsUser.arrMenuGroupList.Count > 0 Then
                    For i = LBound(clsUser.arrMenuGroupList.ToArray) To UBound(clsUser.arrMenuGroupList.ToArray)
                        If clsUser.MenuGroup.Trim = clsUser.arrMenuGroupList.Item(i).ToString.Trim Then
                            iFlag = 1
                            Exit For
                        End If
                    Next
                    If iFlag = 0 Then
                        clsUser.arrMenuGroupList.Add(clsUser.MenuGroup)
                    End If
                End If


                MDIParentPPT.arrListMenu.SetValue(clsUser.MenuName, clsUser.RowCount, 0)

                MDIParentPPT.arrListMenu.SetValue(clsUser.MenuGroup, clsUser.RowCount, 1)
                MDIParentPPT.arrListMenu.SetValue(clsUser.MenuID, clsUser.RowCount, 2)
                clsUser.RowCount = clsUser.RowCount + 1

            Next

            '  Dim ht As New Hashtable()
            'For Each strItem In arrMenuGroup
            '    ht.Item(strItem) = Nothing
            'Next
            ' clsUser.arrMenuGroupList = New ArrayList(ht.Keys)
        Catch ex As Exception

            ManageException(ex, "MDIParentDAL", "Store_MDI_Click")

        End Try

        Return clsUser
    End Function
End Class
