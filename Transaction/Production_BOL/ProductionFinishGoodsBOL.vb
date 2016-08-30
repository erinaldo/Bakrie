Imports Production_DAL
Imports Production_PPT

Public Class ProductionFinishGoodsBOL
    Public Shared Function Save(ByVal objLPOPPT As ProductionFinishGoodsPPT) As DataSet
        Return ProductionFinishGoodsDAL.SaveProductionFinishGoods(objLPOPPT)
    End Function
    Public Function GetSearchResults(ByVal objLPOPPT As ProductionFinishGoodsPPT) As List(Of ProductionFinishGoodsPPT)
        Dim objDAL As New ProductionFinishGoodsDAL
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastFinishGoods(ByVal objLPOPPT As ProductionFinishGoodsPPT) As DataSet
        Return ProductionFinishGoodsDAL.DeleteLastFinishGoods(objLPOPPT)
    End Function
End Class
