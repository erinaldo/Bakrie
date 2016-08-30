Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class EncryptDAL


    Public Shared Function Decrypt(ByVal cipherText As String) As String

        Dim passPhrase As String = "R$ANNPas5pr@se"
        Dim saltValue As String = "R$ANNs@1tValue"
        Dim hashAlgorithm As String = "SHA1"
        Dim passwordIterations As Integer = 3
        Dim initVector As String = "R$AN&N123RK$PMS~"
        Dim keySize As Integer = 256

        ' Convert strings defining encryption key characteristics into byte
        ' arrays. Let us assume that strings only contain ASCII codes.
        ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
        ' encoding.
        Dim initVectorBytes As Byte()
        initVectorBytes = Encoding.ASCII.GetBytes(initVector)

        Dim saltValueBytes As Byte()
        saltValueBytes = Encoding.ASCII.GetBytes(saltValue)

        ' Convert our ciphertext into a byte array.
        Dim cipherTextBytes As Byte()
        cipherTextBytes = Convert.FromBase64String(cipherText)

        ' First, we must create a password, from which the key will be 
        ' derived. This password will be generated from the specified 
        ' passphrase and salt value. The password will be created using
        ' the specified hash algorithm. Password creation can be done in
        ' several iterations.
        Dim password As PasswordDeriveBytes
        password = New PasswordDeriveBytes(passPhrase, _
                                           saltValueBytes, _
                                           hashAlgorithm, _
                                           passwordIterations)

        ' Use the password to generate pseudo-random bytes for the encryption
        ' key. Specify the size of the key in bytes (instead of bits).
        Dim keyBytes As Byte()
        keyBytes = password.GetBytes(keySize / 8)

        ' Create uninitialized Rijndael encryption object.
        Dim symmetricKey As RijndaelManaged
        symmetricKey = New RijndaelManaged()

        ' It is reasonable to set encryption mode to Cipher Block Chaining
        ' (CBC). Use default options for other symmetric key parameters.
        symmetricKey.Mode = CipherMode.CBC

        ' Generate decryptor from the existing key bytes and initialization 
        ' vector. Key size will be defined based on the number of the key 
        ' bytes.
        Dim decryptor As ICryptoTransform
        decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

        ' Define memory stream which will be used to hold encrypted data.
        Dim memoryStream As MemoryStream
        memoryStream = New MemoryStream(cipherTextBytes)

        ' Define memory stream which will be used to hold encrypted data.
        Dim cryptoStream As CryptoStream
        cryptoStream = New CryptoStream(memoryStream, _
                                        decryptor, _
                                        CryptoStreamMode.Read)

        ' Since at this point we don't know what the size of decrypted data
        ' will be, allocate the buffer long enough to hold ciphertext;
        ' plaintext is never longer than ciphertext.
        Dim plainTextBytes As Byte()
        ReDim plainTextBytes(cipherTextBytes.Length)

        ' Start decrypting.
        Dim decryptedByteCount As Integer
        decryptedByteCount = cryptoStream.Read(plainTextBytes, _
                                               0, _
                                               plainTextBytes.Length)

        ' Close both streams.
        memoryStream.Close()
        cryptoStream.Close()

        ' Convert decrypted data into a string. 
        ' Let us assume that the original plaintext string was UTF8-encoded.
        Dim plainText As String
        plainText = Encoding.UTF8.GetString(plainTextBytes, _
                                            0, _
                                            decryptedByteCount)

        ' Return decrypted string.
        Decrypt = plainText
    End Function
    'Private key() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24}
    'Private iv() As Byte = {65, 110, 68, 26, 69, 178, 200, 219}

    'Public Function Encrypt(ByVal plainText As String) As Byte()
    '    ' Declare a UTF8Encoding object so we may use the GetByte 
    '    ' method to transform the plainText into a Byte array. 
    '    Dim utf8encoder As UTF8Encoding = New UTF8Encoding()
    '    Dim inputInBytes() As Byte = utf8encoder.GetBytes(plainText)

    '    ' Create a new TripleDES service provider 
    '    Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

    '    ' The ICryptTransform interface uses the TripleDES 
    '    ' crypt provider along with encryption key and init vector 
    '    ' information 
    '    Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateEncryptor(Me.key, Me.iv)

    '    ' All cryptographic functions need a stream to output the 
    '    ' encrypted information. Here we declare a memory stream 
    '    ' for this purpose. 
    '    Dim encryptedStream As MemoryStream = New MemoryStream()
    '    Dim cryptStream As CryptoStream = New CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write)

    '    ' Write the encrypted information to the stream. Flush the information 
    '    ' when done to ensure everything is out of the buffer. 
    '    cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
    '    cryptStream.FlushFinalBlock()
    '    encryptedStream.Position = 0

    '    ' Read the stream back into a Byte array and return it to the calling 
    '    ' method. 
    '    Dim result(encryptedStream.Length - 1) As Byte
    '    encryptedStream.Read(result, 0, encryptedStream.Length)
    '    cryptStream.Close()
    '    Return result
    'End Function

    'Public Function Decrypt(ByVal inputInBytes() As Byte) As String
    '    ' UTFEncoding is used to transform the decrypted Byte Array 
    '    ' information back into a string. 
    '    Dim utf8encoder As UTF8Encoding = New UTF8Encoding()
    '    Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

    '    ' As before we must provide the encryption/decryption key along with 
    '    ' the init vector. 
    '    Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateDecryptor(Me.key, Me.iv)

    '    ' Provide a memory stream to decrypt information into 
    '    Dim decryptedStream As MemoryStream = New MemoryStream()
    '    Dim cryptStream As CryptoStream = New CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write)
    '    cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
    '    cryptStream.FlushFinalBlock()
    '    decryptedStream.Position = 0

    '    ' Read the memory stream and convert it back into a string 
    '    Dim result(decryptedStream.Length - 1) As Byte
    '    decryptedStream.Read(result, 0, decryptedStream.Length)
    '    cryptStream.Close()
    '    Dim myutf As UTF8Encoding = New UTF8Encoding()
    '    Return myutf.GetString(result)
    'End Function

End Class
