Imports Common_PPT
Imports Common_DAL
Public Class MDIParentBOL
    Public Shared Function GetMenuInfo(ByVal MDIPPT As MDIParentPPT, ByVal MenuAccess As String) As MDIParentPPT
        Return MDIParentDAL.GetMenuInfo(MDIPPT, MenuAccess)
    End Function
End Class
