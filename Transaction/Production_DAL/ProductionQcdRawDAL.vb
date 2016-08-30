Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionQcdRawDAL
    Public Shared Function SaveProductionQcdRaw(ByVal objQcdRawPPT As ProductionQcdRawPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objQcdRawPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionQCDRawMaterialSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objQcdRawPPT As ProductionQcdRawPPT) As SqlParameter()

        Dim Parms(25) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objQcdRawPPT.ID Is Nothing OrElse objQcdRawPPT.ID = 0, DBNull.Value, objQcdRawPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objQcdRawPPT.DocDate)
        Parms(1) = New SqlParameter("@TicketNo", objQcdRawPPT.TicketNo)
        Parms(2) = New SqlParameter("@Estate", objQcdRawPPT.Estate)
        Parms(3) = New SqlParameter("@CarNo", objQcdRawPPT.CarNo)
        Parms(4) = New SqlParameter("@Division", objQcdRawPPT.Division)
        Parms(5) = New SqlParameter("@RawMaterial", objQcdRawPPT.RawMaterial)
        Parms(6) = New SqlParameter("@QtyEstate", objQcdRawPPT.QtyEstate)
        Parms(7) = New SqlParameter("@QtyFactory", objQcdRawPPT.QtyFactory)
        Parms(8) = New SqlParameter("@Drc1", objQcdRawPPT.Drc1)
        Parms(9) = New SqlParameter("@Drc2", objQcdRawPPT.Drc2)
        Parms(10) = New SqlParameter("@Drc3", objQcdRawPPT.Drc3)
        Parms(11) = New SqlParameter("@DrcCar", objQcdRawPPT.DrcCar)
        Parms(12) = New SqlParameter("@Nh31", objQcdRawPPT.Nh31)
        Parms(13) = New SqlParameter("@Nh32", objQcdRawPPT.Nh32)
        Parms(14) = New SqlParameter("@Nh33", objQcdRawPPT.Nh33)
        Parms(15) = New SqlParameter("@Nh3Car", objQcdRawPPT.Nh3Car)
        Parms(16) = New SqlParameter("@DrcEstate", objQcdRawPPT.DrcEstate)
        Parms(17) = New SqlParameter("@Nh3Estate", objQcdRawPPT.Nh3Estate)
        Parms(18) = New SqlParameter("@VfaNo", objQcdRawPPT.VfaNo)
        Parms(19) = New SqlParameter("@Dirt", objQcdRawPPT.Dirt)
        Parms(20) = New SqlParameter("@Ash", objQcdRawPPT.Ash)
        Parms(21) = New SqlParameter("@Remarks", objQcdRawPPT.Remarks)
        Parms(22) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(23) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(24) = New SqlParameter("@EstateID", GlobalPPT.strEstateID) 'objQcdRawPPT.EstateID
        Parms(25) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objQcdRawPPT As ProductionQcdRawPPT) As List(Of ProductionQcdRawPPT)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@DocDate", If(objQcdRawPPT.DocDate Is Nothing, DBNull.Value, objQcdRawPPT.DocDate))
        params(1) = New SqlParameter("@TicketNo", If(objQcdRawPPT.TicketNo Is Nothing, DBNull.Value, objQcdRawPPT.TicketNo))
        params(2) = New SqlParameter("@Estate", If(objQcdRawPPT.Estate Is Nothing, DBNull.Value, objQcdRawPPT.Estate))
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Try
            dt = objdb.ExecQuery("[Production].[ProductionQCDRawMaterialGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionQcdRawPPT)(dt)
    End Function

    Public Shared Function DeleteLastQcdRaw(ByVal objQcdRawPPT As ProductionQcdRawPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objQcdRawPPT.Id)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        'Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        'Parms(3).Value = If(objQcdRawPPT.Tstamp Is Nothing, DBNull.Value, objQcdRawPPT.Tstamp)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionQCDRawMaterialDelete]", Parms, False)
        Return ds

    End Function
End Class

