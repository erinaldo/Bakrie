Imports Vehicle_PPT
Imports Vehicle_DAL

Public Class SearchCodeBOL

    Function GetSearchWorkshop(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.GetSearchWorkshop(_SearchCodePPT)
    End Function

    Function GetSearchVehicle(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.GetSearchVehicle(_SearchCodePPT)
    End Function

    Function GetSearchWSVehicle(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.GetSearchWSVehicle(_SearchCodePPT)
    End Function

    Function GetSearchAccount(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.GetSearchAccount(_SearchCodePPT)
    End Function

    Function GetSearchOperator(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.GetSearchOperator(_SearchCodePPT)
    End Function

    Function GetSearchDivision(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.GetDivision(_SearchCodePPT)
    End Function

    Function GetSubBlock(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.GetSubBlock(_SearchCodePPT)
    End Function

    Function GetYearOfPlanning(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.GetYearOfPlanning(_SearchCodePPT)
    End Function

    Function GetSearchTAnalysis(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.GetSearchTAnalysis(_SearchCodePPT)
    End Function

    Function GetContractNo(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.GetContractNo(_SearchCodePPT)
    End Function

    Function VHNCategoryGet(ByVal _SearchCodePPT As SearchCodePPT) As DataTable
        Return SearchCodeDAL.VHNCategoryGet(_SearchCodePPT)
    End Function

End Class
