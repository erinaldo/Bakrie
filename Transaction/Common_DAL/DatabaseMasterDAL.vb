Imports Common_PPT
Imports Common_PPT.DatabaseMasterPPT
Imports System.Windows.Forms

Public Class DatabaseMasterDAL
    Shared ConfigPathname As String = String.Empty

    Public Shared Function GetDataseList() As List(Of DatabaseList)
        ' initially load all Database stored in XML file
        Dim xDS As New DataSet
        ConfigPathname = Application.StartupPath + "\BSP.exe.DBConfig"
        Dim dbList As New List(Of DatabaseList)

        If System.IO.File.Exists(ConfigPathname) Then
            xDS.ReadXml(ConfigPathname)

            If xDS.Tables.Count > 0 Then
                For i As Integer = 0 To xDS.Tables(0).Rows.Count - 1
                    Dim db As New DatabaseList
                    db.ID = xDS.Tables(0).Rows(i)("ID")
                    db.Server = xDS.Tables(0).Rows(i)("Server")
                    db.DBName = xDS.Tables(0).Rows(i)("DBName")
                    db.User = xDS.Tables(0).Rows(i)("User")
                    db.Password = Common_DAL.EncryptionDAL.Decrypt(xDS.Tables(0).Rows(i)("Password"))
                    db.DSN = xDS.Tables(0).Rows(i)("DSN")
                    dbList.Add(db)
                Next
            End If
        Else
            MessageBox.Show("Could not locate the database configuration. Create new configuration.", "Database Configuration not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Return dbList
    End Function


    Public Shared Function GetDatabaseFromID(ByVal ID As Integer) As DatabaseList
        'return a DB info from ID
        Dim dbList As New List(Of DatabaseList)
        dbList = GetDataseList()

        For Each db As DatabaseList In dbList
            If db.ID = ID Then
                Return db
            End If
        Next

        Return New DatabaseList

    End Function
End Class
