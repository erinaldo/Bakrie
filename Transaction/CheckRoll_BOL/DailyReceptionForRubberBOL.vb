Imports CheckRoll_DAL
Imports CheckRoll_PPT

Public Class DailyReceptionForRubberBOL
    Public Function Save_Rubber(ByVal objRubberPPT As DailyReceptionForRubberPPT) As Integer
        Dim objIPRData As New DailyReceptionForRubberDAL
        Return objIPRData.Save_Rubber(objRubberPPT)
    End Function

    Public Function DailyRubberSelect(ByVal DailyReceiptionID As String) As DataTable
        Dim objIPRData As New DailyReceptionForRubberDAL
        Return objIPRData.DailyRubberSelect(DailyReceiptionID)
    End Function
End Class