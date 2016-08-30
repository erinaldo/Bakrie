Imports CheckRoll_DAL
Imports CheckRoll_PPT

Public Class ClassPenderesBOL
    Public Function ClassPenderesInsert(objClassPenderesPPT As ClassPenderesPPT) As DataTable
        Dim objDAl As New ClassPenderesDAL
        Return objDAl.ClassPenderesInsert(objClassPenderesPPT)
    End Function

    Public Function UpdateDailyReceptionForRubber(AttCode As String, DateRubber As DateTime, NIk As String,
                           DRRubberID As String, DailyReceiptionID As String, EstateCode As String,
                           Latex As Double, Drc As Double, CupLamp As Double, DRCCupLump As Double,
                           TreeLace As Double, DRCTreeLace As Double) As Boolean
        Dim objDAl As New ClassPenderesDAL
        Return objDAl.UpdateDailyReceptionForRubber(AttCode, DateRubber, NIk,
                           DRRubberID, DailyReceiptionID, EstateCode,
                           Latex, Drc, CupLamp, DRCCupLump,
                           TreeLace, DRCTreeLace)
    End Function
    Public Function SelectAllDataRubber(periode As DateTime) As DataTable
        Dim objDAl As New ClassPenderesDAL
        Return objDAl.SelectAllDataRubber(periode)
    End Function

    Public Function ClassPenderesDetailInsert(objClassPenderesPPT As ClassPenderesDetailPPT) As Integer
        Dim objDAL As New ClassPenderesDAL
        Return objDAL.ClassPenderesDetailInsert(objClassPenderesPPT)
    End Function

    Public Function ClassPenderesDetailsDelete(id As Integer) As Integer
        Dim obj As New ClassPenderesDAL
        Return obj.ClassPenderesDetailsDelete(id)
    End Function
End Class