Imports CheckRoll_PPT
Imports CheckRoll_DAL

Public Class PieceRateTransaction_BOL

    Public Function PieceRate_Select(ByVal _ReferenceNo As String) As DataTable
        Dim pieceRateTransaction_DAL As New PieceRateTransaction_DAL
        Return pieceRateTransaction_DAL.PieceRate_Select(_ReferenceNo)
    End Function
    Public Function PieceRateActivity_Select(ByVal objPieceRateActivity As PieceRateActivity_PPT) As DataTable
        Dim pieceRateTransaction_DAL As New PieceRateTransaction_DAL
        Return pieceRateTransaction_DAL.PieceRateActivity_Select(objPieceRateActivity)
    End Function

    Public Function PieceRateContractor_Select(ByVal ActivityId As Integer) As DataTable
        Dim pieceRateTransaction_DAL As New PieceRateTransaction_DAL
        Return pieceRateTransaction_DAL.PieceRateContractor_Select(ActivityId)
    End Function


    Public Function PieceRateEmployee_Select(ByVal ActivityId As Integer) As DataTable
        Dim pieceRateTransaction_DAL As New PieceRateTransaction_DAL
        Return pieceRateTransaction_DAL.PieceRateEmployee_Select(ActivityId)
    End Function

    Public Function PieceRateTransaction_Select(ByVal Id As Integer, ByRef PieceRateActivityId As Integer) As DataTable
        Dim pieceRateTransaction_DAL As New PieceRateTransaction_DAL
        Return pieceRateTransaction_DAL.PieceRateTransaction_Select(Id, PieceRateActivityId)
    End Function

    Public Function PieceRateTransaction_Update(ByVal objPRT As PieceRateTransaction_PPT) As Integer
        Dim pieceRateTransaction_DAL As New PieceRateTransaction_DAL
        Return pieceRateTransaction_DAL.PieceRateTransaction_Update(objPRT)
    End Function

    Public Function PieceRateTransaction_Delete(ByVal Id As Integer) As Integer
        Dim pieceRateTransaction_DAL As New PieceRateTransaction_DAL
        Return pieceRateTransaction_DAL.PieceRateTransaction_Delete(Id)
    End Function
End Class
