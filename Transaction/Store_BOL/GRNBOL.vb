Imports Store_DAL
Imports Store_PPT
Public Class GRNBOL
    Public Function GetInterfaceYear(ByVal objGRNPPT As GRNPPT) As DataSet
        Dim objGRNDAL As New GRNDAL
        Return objGRNDAL.GetInterfaceYear(objGRNPPT)
    End Function
    Public Function GetTaskComplete(ByVal objGRNPPT As GRNPPT) As DataSet
        Dim objGRNDAL As New GRNDAL
        Return objGRNDAL.GetTaskComplete(objGRNPPT)
    End Function
    Public Function GetFYearDate(ByVal objGRNPPT As GRNPPT) As DataSet
        Dim objGRNDAL As New GRNDAL
        Return objGRNDAL.GetFYearDate(objGRNPPT)
    End Function
End Class
