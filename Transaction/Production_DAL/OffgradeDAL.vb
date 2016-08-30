Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class OffgradeDAL
    Public Shared Function SaveOG(ByVal objOGPPT As OffgradePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objOGPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[OGSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objOGPPT As OffgradePPT) As SqlParameter()
        Dim Parms(13) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objWIORubberPPT.ID Is Nothing OrElse objWIORubberPPT.ID = 0, DBNull.Value, objWIORubberPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objOGPPT.DocDate)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID) 'objWIORubberPPT.EstateID
        Parms(3) = New SqlParameter("@Contract", objOGPPT.OGContract)
        Parms(4) = New SqlParameter("@Cust", objOGPPT.OGCust)
        Parms(5) = New SqlParameter("@Do", objOGPPT.OGDo)
        Parms(6) = New SqlParameter("@TId", objOGPPT.OGTruckId)
        Parms(7) = New SqlParameter("@Storage", objOGPPT.OGStorage)
        Parms(8) = New SqlParameter("@Product", objOGPPT.OGProduct)
        Parms(9) = New SqlParameter("@Wet", objOGPPT.OGWet)
        Parms(10) = New SqlParameter("@Dry", objOGPPT.OGDry)
        Parms(11) = New SqlParameter("@Drc", objOGPPT.OGDrc)
        Parms(12) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objLPOPPT As OffgradePPT) As List(Of OffgradePPT)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@Source", If(objLPOPPT.OGStorage Is Nothing, DBNull.Value, objLPOPPT.OGStorage))
        params(1) = New SqlParameter("@DocDate", If(objLPOPPT.DocDate Is Nothing, DBNull.Value, objLPOPPT.DocDate))
        params(2) = New SqlParameter("@Product", If(objLPOPPT.OGProduct Is Nothing, DBNull.Value, objLPOPPT.OGProduct))
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Try
            dt = objdb.ExecQuery("[Production].[OGGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of OffgradePPT)(dt)
    End Function

    Public Shared Function DeleteLastOG(ByVal objLPOPPT As OffgradePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objLPOPPT.ID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        'Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        'Parms(3).Value = If(objRMSPPT.Tstamp Is Nothing, DBNull.Value, objRMSPPT.Tstamp)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[OGDelete]", Parms, False)
        Return ds

    End Function
End Class
