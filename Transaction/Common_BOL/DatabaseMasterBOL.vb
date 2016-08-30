Imports System.Windows.Forms
Imports Common_PPT.DatabaseMasterPPT

Public Class DatabaseMasterBOL

    Shared ConfigPathname As String = String.Empty

    Public Shared Function GetDataseList() As List(Of DatabaseList)
        Return Common_DAL.DatabaseMasterDAL.GetDataseList()
    End Function


    Public Shared Function GetDatabaseFromID(ByVal ID As Integer) As DatabaseList
        Return Common_DAL.DatabaseMasterDAL.GetDatabaseFromID(ID)
    End Function


End Class
