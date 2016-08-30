Module CommonFunctions

    Public Function ConvertToDouble(ByVal strObject As Object) As Double
        If IsNumeric(strObject) = False Then
            Return 0.0
        End If

        Return Convert.ToDouble(strObject)
    End Function

End Module
