Imports Store_DAL
Imports Store_PPT
Imports System.Data.SqlClient

Public Class EstateMillDeliverNoteApprovalBOL

    Public Shared Function STMillDeliveryUpdateApproval(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer

        Return EstateMillDeliverNoteApprovalDAL.STMillDeliveryUpdateApproval(objEMDNPPT)

    End Function

    Public Shared Function STIPRDetailUpdateForEMDNApproval_Old(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataSet

        Return EstateMillDeliverNoteApprovalDAL.STIPRDetailUpdateForEMDNApproval_Old(objEMDNPPT)

    End Function

    Public Shared Function STIPRUpdateForEMDNApproval(ByVal objIPRPPT As InternalPurchaseRequisitionApprovalPPT) As Integer

        Return EstateMillDeliverNoteApprovalDAL.STIPRUpdateForEMDNApproval(objIPRPPT)

    End Function

    Public Shared Function STStockDetailAvgPriceApproval(ByVal objEMDN As EstateMillDeliveryNotePPT) As DataSet

        Return EstateMillDeliverNoteApprovalDAL.STStockDetailAvgPriceApproval(objEMDN)

    End Function

    Public Shared Function STIDNLedgerAllModuleInsert(ByVal objEMDNApprovalPPT As EstMillDeliveryNoteApprovalPPT) As DataSet

        Return EstateMillDeliverNoteApprovalDAL.STIDNLedgerAllModuleInsert(objEMDNApprovalPPT)

    End Function

    Public Shared Function STIDNLedgerAllModuleUpdate(ByVal objEMDNApprovalPPT As EstMillDeliveryNoteApprovalPPT) As Integer

        Return EstateMillDeliverNoteApprovalDAL.STIDNLedgerAllModuleUpdate(objEMDNApprovalPPT)

    End Function

    Public Shared Function STIDNJournalDetailInsert(ByVal objEMDNApprovalPPT As EstMillDeliveryNoteApprovalPPT) As Integer

        Return EstateMillDeliverNoteApprovalDAL.STIDNJournalDetailInsert(objEMDNApprovalPPT)

    End Function

    Public Shared Function STIDNStockIDDetailSelect(ByVal objEMDNApprovalPPT As EstMillDeliveryNoteApprovalPPT) As DataSet

        Return EstateMillDeliverNoteApprovalDAL.STIDNStockIDDetailSelect(objEMDNApprovalPPT)

    End Function

    Public Shared Function STLPODetailUpdateForEMDNApproval(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer

        Return EstateMillDeliverNoteApprovalDAL.STLPODetailUpdateForEMDNApproval(objEMDNPPT)

    End Function

    Public Shared Function STIPRDetailUpdateForEMDNApproval(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer

        Return EstateMillDeliverNoteApprovalDAL.STIPRDetailUpdateForEMDNApproval(objEMDNPPT)

    End Function

    Public Shared Function StockDetailConsignmentUpdateforEMDNApproval(ByVal objEMDN As EstateMillDeliveryNotePPT) As DataSet

        Return EstateMillDeliverNoteApprovalDAL.StockDetailConsignmentUpdateforEMDNApproval(objEMDN)

    End Function

    Public Shared Function StockDetailConsignmentAvailCheck(ByVal objEMDN As EstateMillDeliveryNotePPT) As DataSet

        Return EstateMillDeliverNoteApprovalDAL.StockDetailConsignmentAvailCheck(objEMDN)

    End Function

    Public Shared Function StockDetailConsignmentQtyCheck(ByVal objEMDN As EstateMillDeliveryNotePPT) As Integer

        Return EstateMillDeliverNoteApprovalDAL.StockDetailConsignmentQtyCheck(objEMDN)

    End Function

    Public Shared Function LPOSupplierNameGet(ByVal objEMDN As EstateMillDeliveryNotePPT) As DataSet

        Return EstateMillDeliverNoteApprovalDAL.LPOSupplierNameGet(objEMDN)

    End Function

    Public Shared Function IDNLPOT0Select() As DataTable

        Return EstateMillDeliverNoteApprovalDAL.IDNLPOT0Select()

    End Function

End Class
