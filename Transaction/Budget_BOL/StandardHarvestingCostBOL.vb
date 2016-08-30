Imports Budget_DAL
Imports Budget_PPT
Public Class StandardHarvestingCostBOL

    Public Shared Function StandardHarvestingYOPGet() As DataSet
        Return StandardHarvestingCostDAL.StandardHarvestingYOPGet()
    End Function
    'Public Shared Function StandardHarvestingYOPIDGet(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataSet
    '    Return StandardHarvestingCostDAL.StandardHarvestingYOPIDGet(oStandardHarvestingCostPPT)
    'End Function

    Public Shared Function StandardHarvestingHectFill(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataSet

        Return StandardHarvestingCostDAL.StandardHarvestingHectFill(oStandardHarvestingCostPPT)
    End Function

    Public Shared Function StandardHarvestingInsert(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataSet

        Return StandardHarvestingCostDAL.StandardHarvestingInsert(oStandardHarvestingCostPPT)
    End Function
    Public Shared Function StandardHarvestingYOPSearch(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataSet

        Return StandardHarvestingCostDAL.StandardHarvestingYOPSearch(oStandardHarvestingCostPPT)
    End Function
    Public Shared Function StandardHarvestingCostSelect(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataTable

        Return StandardHarvestingCostDAL.StandardHarvestingCostSelect(oStandardHarvestingCostPPT)
    End Function

    Public Shared Function StandardHarvestingUpdate(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataSet

        Return StandardHarvestingCostDAL.StandardHarvestingUpdate(oStandardHarvestingCostPPT)
    End Function
    Public Shared Function StandardHarvestingDelete(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As Integer

        Return StandardHarvestingCostDAL.StandardHarvestingDelete(oStandardHarvestingCostPPT)
    End Function
    Public Shared Function StandardHarvestingCostSelect_MultipleEntry(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataTable
        Dim oStandardHarvestingCostDAL As New StandardHarvestingCostDAL
        Return oStandardHarvestingCostDAL.StandardHarvestingCostSelect_MultipleEntry(oStandardHarvestingCostPPT)
    End Function
End Class
