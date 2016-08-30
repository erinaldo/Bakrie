Imports Common_PPT

Public Class Helper
    Public Shared Function T0Default() As String()
        Try
            Dim array(1) As String
            Dim t0Value(1) As String
            t0Value = GlobalPPT.strEstateName.Split("-")
            array(0) = GlobalPPT.strEstateCode
            array(1) = t0Value(1)
            Return array
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
