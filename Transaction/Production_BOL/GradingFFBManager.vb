'Imports System
'Imports System.ComponentModel
'Imports BSP.Production.Entity
'Imports BSP.Production.Data
'Imports BSP.Base.Validation
'Imports BSP.Base.Exception
Public Class GradingFFBManager
    '    Public Shared Function GetConcurrencyId(ByVal id As String) As Byte()
    '        Return GradingFFBData.GetConcurrencyId(id)
    '    End Function
    '    <DataObjectMethod(DataObjectMethodType.Select, False)> _
    '    Public Shared Function GetWBTicketInfo(ByVal WBTicketInfo As GradingFFBEntity) As GradingFFBCollection
    '        Return GradingFFBData.GetWBTicketInfo(WBTicketInfo)
    '    End Function
    '    <DataObjectMethod(DataObjectMethodType.Select, False)> _
    '    Public Shared Function GetSupplierVehicleInfo(ByVal WBTicketInfo As GradingFFBEntity) As GradingFFBEntity
    '        Return GradingFFBData.GetSupplierVehicleInfo(WBTicketInfo)
    '    End Function

    '    <DataObjectMethod(DataObjectMethodType.Select, False)> _
    '   Public Shared Function GetSupplierVehicleInfoList(ByVal WBTicketInfo As GradingFFBEntity) As GradingFFBCollection
    '        Return GradingFFBData.GetSupplierVehicleInfoList(WBTicketInfo)
    '    End Function
    '    '    <DataObjectMethod(DataObjectMethodType.Select, True)> _
    '    'Public Overloads Shared Function GetWBTicketNo(ByVal WBTicketNo As GradingFFBEntity) As GradingFFBCollection
    '    '        Return GradingFFBData.GetWBTicketNo(WBTicketNo)
    '    '    End Function
    '    <DataObjectMethod(DataObjectMethodType.Select, True)> _
    '    Public Overloads Shared Function GetList(ByVal KernelStorage As KernelStorageEntity) As KernelStorageCollection
    '        Return KernelStorageData.Getlist(KernelStorage)
    '    End Function
    '    <DataObjectMethod(DataObjectMethodType.Select, False)> _
    '    Public Shared Function GetItem(ByVal id As String) As KernelStorageEntity
    '        Return KernelStorageData.GetItem(id)
    '    End Function

    '    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    '    Public Shared Function Delete(ByVal id As String) As Boolean
    '        Return KernelStorageData.Delete(id)
    '    End Function

    '    <DataObjectMethod(DataObjectMethodType.Insert Or DataObjectMethodType.Update, False)> _
    '    Public Shared Function Save(ByVal gradingFFBEntity As GradingFFBEntity) As GradingFFBEntity

    '        gradingFFBEntity = IsSaveValid(gradingFFBEntity)
    '        If gradingFFBEntity.IsTransactionSuccess Then
    '            gradingFFBEntity = GradingFFBData.Save(gradingFFBEntity)
    '        End If


    '        Return gradingFFBEntity

    '    End Function

    '#Region "Validation"

    '    Public Shared Function IsSaveValid(ByVal gradingFFBEntity As GradingFFBEntity) As GradingFFBEntity
    '        Return GradingFFBData.ValidateEntity(gradingFFBEntity)
    '    End Function

    '#End Region

End Class
