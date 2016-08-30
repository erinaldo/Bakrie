Imports Vehicle_PPT
Imports Vehicle_DAL

Public Class VehicleDistributionBOL

#Region "Functions"

    Public Function GetVehicleCode(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.GetVehicleCode(_VehicleDistributionPPT)
    End Function

    Public Function GetVehicleDistribution(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.GetVehicleDistribution(_VehicleDistributionPPT)
    End Function

    Public Function GetVehicleDistributionDetails(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.GetVehicleDistributionDetails(_VehicleDistributionPPT)
    End Function

    Function GetDistributionValueForVehicleCode(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.GetDistributionValueForVehicleCode(_VehicleDistributionPPT)
    End Function

    Function IsConcurrentRecordSelect(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Boolean
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.IsConcurrentRecordSelect(_VehicleDistributionPPT)
    End Function

    Function SaveVehicleDistribution(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Integer
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.SaveVehicleDistribution(_VehicleDistributionPPT)
    End Function

    Function UpdateVehicleDistribution(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Integer
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.UpdateVehicleDistribution(_VehicleDistributionPPT)
    End Function

    Function DeleteVehicleDistribution(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Integer
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.DeleteVehicleDistribution(_VehicleDistributionPPT)
    End Function

    Function DeleteVehicleDistributionFrmView(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Integer
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.DeleteVehicleDistributionFrmView(_VehicleDistributionPPT)
    End Function

    Public Function VHDistributionRecordIsExist(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Object
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.VHDistributionRecordIsExist(_VehicleDistributionPPT)
    End Function

#End Region

#Region "Lookup"

    Public Shared Function VHNCategoryGet(ByVal objStoreIssueVoucher As VehicleDistributionPPT) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.VHNCategoryGet(objStoreIssueVoucher)
    End Function

    Public Shared Function GetVHNo(ByVal obVHNo As VehicleDistributionPPT, ByVal IsDirect As String) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.GetVHNo(obVHNo, IsDirect)
    End Function

    Public Shared Function GetYOP(ByVal obYOP As VehicleDistributionPPT) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.GetYOP(obYOP)
    End Function

    Public Shared Function GetDIV(ByVal obDIV As VehicleDistributionPPT, ByVal IsDirect As String) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.GetDIV(obDIV, IsDirect)
    End Function

    Public Shared Function GetSubBlock(ByVal obSubBlock As VehicleDistributionPPT, ByVal IsDirect As String) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.GetSubBlock(obSubBlock, IsDirect)
    End Function

    Public Shared Function TlookupSearch(ByVal objStoreIssueVoucher As VehicleDistributionPPT, ByVal IsDirect As String) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.TlookupSearch(objStoreIssueVoucher, IsDirect)
    End Function
#Region "Account Lookup"

    Public Shared Function AcctlookupSearch(ByVal objStoreIssueVoucher As VehicleDistributionPPT, ByVal IsDirect As String) As DataSet
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.AcctlookupSearch(objStoreIssueVoucher, IsDirect)
    End Function

    Public Shared Function SelectAllParentCOA(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.SelectAllParentCOA(objCOAPPT)
    End Function

    Public Shared Function SelectAllChildCOA(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.SelectAllChildCOA(objCOAPPT)
    End Function

    Public Shared Function LoadCOAGrid(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.LoadCOAGrid(objCOAPPT)
    End Function

    Public Shared Function LoadCOAGridByCOAID(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.LoadCOAGridByCOAID(objCOAPPT)
    End Function

    Public Shared Function ParentIdGet(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.ParentIdGet(objCOAPPT)
    End Function

    Public Shared Function ParentCodeGet(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.ParentCodeGet(objCOAPPT)
    End Function

    Public Shared Function ChildCOAIDGet(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.ChildCOAIDGet(objCOAPPT)
    End Function

    Public Shared Function ChildCOACodeGet(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.ChildCOACodeGet(objCOAPPT)
    End Function
    Public Shared Function COALookUpGridFillByOLDCOACode(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim objVehicleDistributionDAL As New VehicleDistributionDAL
        Return objVehicleDistributionDAL.COALookUpGridFillByOLDCOACode(objCOAPPT)
    End Function

#End Region


#End Region

End Class
