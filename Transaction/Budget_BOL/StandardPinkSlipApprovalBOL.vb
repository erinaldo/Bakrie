Imports Budget_DAL
Imports Budget_PPT
Imports System.Data.SqlClient
Public Class StandardPinkSlipApprovalBOL
    'Public Function PinkSlipApprovalGet(ByVal oStandardPinkSlipApprovalPPT As StandardPinkSlipApprovalPPT) As DataTable
    '    Dim oStandardPinkSlipApprovalDAL As New StandardPinkSlipApprovalDAL
    '    Return oStandardPinkSlipApprovalDAL.PinkSlipApprovalGet(oStandardPinkSlipApprovalPPT)
    'End Function
    Public Shared Function PinkSlipApprovalSelect(ByVal oStandardPinkSlipApprovalPPT As StandardPinkSlipApprovalPPT) As DataTable
        Return StandardPinkSlipApprovalDAL.PinkSlipApprovalSelect(oStandardPinkSlipApprovalPPT)
    End Function
    Public Shared Function PinkSlipSearch(ByVal oStandardPinkSlipApprovalPPT As StandardPinkSlipApprovalPPT, ByVal IsApproval As String) As DataSet
        Return StandardPinkSlipApprovalDAL.PinkSlipSearch(oStandardPinkSlipApprovalPPT, "YES")
    End Function
End Class
