Imports System.Xml
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports XML.Generator.Domain

Public Class BSPXMLGenerator

    Public Shared Sub Generate(profile As Profile, listLine As IEnumerable(Of ProfileLine), listNameValue As IEnumerable(Of ProfileNameValue))
        Try
            Dim dialog As New FolderBrowserDialog
            Dim path As String
            If dialog.ShowDialog() = DialogResult.OK Then
                path = dialog.SelectedPath
                Dim pathFile As String
                pathFile = path & "\" & profile.NameXML & ".xml"
                Dim xmlWriter As New XmlTextWriter(pathFile, Encoding.UTF8)
                With xmlWriter
                    .WriteStartDocument(True)
                    .Formatting = Formatting.Indented
                    .Indentation = 2
                    .WriteStartElement(profile.FirstTag)
                    .WriteStartElement(profile.SecondTag)
                    .WriteElementString(profile.Creator(0), profile.Creator(1))
                    .WriteElementString(profile.Descr(0), profile.Descr(1))
                    .WriteElementString(profile.ReqStatus(0), profile.ReqStatus(1))

                    For Each profileLine As ProfileLine In listLine
                        .WriteStartElement(profileLine.Line)
                        .WriteElementString(profileLine.LTName(0), profileLine.LTName(1))
                        .WriteStartElement(profileLine.Fields)

                        For Each profileName As ProfileNameValue In profileLine.ProfileNameValue.Where(Function(n) n.Id = profileLine.Id)
                            .WriteStartElement(profileName.Field)
                            .WriteElementString(profileName.Name(0), profileName.Name(1))
                            .WriteElementString(profileName.Value(0), profileName.Value(1))
                            .WriteEndElement()
                        Next

                        .WriteEndElement()
                        .WriteEndElement()
                    Next
                    .WriteEndElement()
                    .WriteEndElement()
                    .WriteEndDocument()
                    .Close()
                End With
                MsgBox("Record has successfull Generated!", MsgBoxStyle.OkOnly, "Succesfull")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Public Shared Function GenerateWitFileName(profile As Profile, listLine As IEnumerable(Of ProfileLine), listNameValue As IEnumerable(Of ProfileNameValue), fileName As String) As String
        Try
            ' Dim dialog As New FolderBrowserDialog
            Dim path As String
            'If dialog.ShowDialog() = DialogResult.OK Then
            path = fileName
            Dim pathFile As String
            pathFile = path & "\" & profile.NameXML & ".xml"
            Dim xmlWriter As New XmlTextWriter(pathFile, Encoding.UTF8)
            With xmlWriter
                .WriteStartDocument(True)
                .Formatting = Formatting.Indented
                .Indentation = 2
                .WriteStartElement(profile.FirstTag)
                .WriteStartElement(profile.SecondTag)
                .WriteElementString(profile.Creator(0), profile.Creator(1))
                .WriteElementString(profile.Descr(0), profile.Descr(1))
                .WriteElementString(profile.ReqStatus(0), profile.ReqStatus(1))

                For Each profileLine As ProfileLine In listLine
                    .WriteStartElement(profileLine.Line)
                    .WriteElementString(profileLine.LTName(0), profileLine.LTName(1))
                    .WriteStartElement(profileLine.Fields)

                    For Each profileName As ProfileNameValue In profileLine.ProfileNameValue.Where(Function(n) n.Id = profileLine.Id)
                        .WriteStartElement(profileName.Field)
                        .WriteElementString(profileName.Name(0), profileName.Name(1))
                        .WriteElementString(profileName.Value(0), profileName.Value(1))
                        .WriteEndElement()
                    Next

                    .WriteEndElement()
                    .WriteEndElement()
                Next
                .WriteEndElement()
                .WriteEndElement()
                .WriteEndDocument()
                .Close()
            End With

            Return "Record has successfull Generated!"
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error")
            Return ex.ToString()
        End Try
    End Function


    Public Shared Function WriteXML(dt As DataTable, oDetail As DataRow, item As String) As ProfileNameValue
        Try
            Dim profileNameValuequantity As New ProfileNameValue
            With profileNameValuequantity
                .Id = oDetail.Item("Id").ToString()
                .Field = "field"
                .Name = New String() {"name", dt.Columns.Item(item).ColumnName}
                .Value = New String() {"value", oDetail.Item(item).ToString()}
            End With
            Return profileNameValuequantity
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error")
            Return New ProfileNameValue
        End Try
    End Function

End Class
