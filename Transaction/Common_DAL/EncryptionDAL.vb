Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class EncryptionDAL
    ''' <summary>
    ''' Decrpting the string value
    ''' </summary>
    ''' <param name="encrypted"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Decrypt(ByVal encrypted As String) As String

        Dim data As Byte() = System.Convert.FromBase64String(encrypted)

        Dim rgbKey As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes("12121212")

        Dim rgbIV As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes("34343434")

        Dim memoryStream As New MemoryStream(data.Length)


        Dim desCryptoServiceProvider As New DESCryptoServiceProvider()



        Dim cryptoStream As New CryptoStream(memoryStream, desCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Read)

        memoryStream.Write(data, 0, data.Length)

        memoryStream.Position = 0

        Dim decrypted As String = New StreamReader(cryptoStream).ReadToEnd()

        cryptoStream.Close()

        Return decrypted

    End Function
    ''' <summary>
    ''' Encrypting the string
    ''' </summary>
    ''' <param name="decrypted"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Encrypt(ByVal decrypted As String) As String

        Dim data As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(decrypted)

        Dim rgbKey As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes("12121212")

        Dim rgbIV As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes("34343434")

        Dim memoryStream As New MemoryStream(1024)


        Dim desCryptoServiceProvider As New DESCryptoServiceProvider()



        Dim cryptoStream As New CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write)

        cryptoStream.Write(data, 0, data.Length)

        cryptoStream.FlushFinalBlock()

        Dim result As Byte() = New Byte(CInt(memoryStream.Position) - 1) {}

        memoryStream.Position = 0

        memoryStream.Read(result, 0, result.Length)

        cryptoStream.Close()

        Return System.Convert.ToBase64String(result)

    End Function
End Class
