Imports System.Data.SqlClient
Imports System.Configuration
Imports CheckRoll_DAL
Imports CheckRoll_PPT

Public Class CropStatement_BOL
    Public Shared Function GetCropYieldID(ByVal objCropStatementPPT As CropStatement_PPT) As DataTable
        Return CropStatement_DAL.GetCropYieldID(objCropStatementPPT)
    End Function
    Public Shared Function CropStatementInsert(ByVal objCropStatementPPT As CropStatement_PPT) As Integer
        Return CropStatement_DAL.CropStatementInsert(objCropStatementPPT)
    End Function
    Public Shared Function CropStatementSearch(ByVal objCropStatementPPT As CropStatement_PPT) As DataTable
        Return CropStatement_DAL.CropStatementSearch(objCropStatementPPT)
    End Function
    Public Shared Function CropStatementUpdate(ByVal objCropStatementPPT As CropStatement_PPT) As Integer
        Return CropStatement_DAL.CropStatementUpdate(objCropStatementPPT)
    End Function
    Public Shared Function CropStatementDelete(ByVal objCropStatementPPT As CropStatement_PPT) As Integer
        Return CropStatement_DAL.CropStatementDelete(objCropStatementPPT)
    End Function
End Class
