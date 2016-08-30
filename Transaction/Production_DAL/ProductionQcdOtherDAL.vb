Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionQcdOtherDAL
    Public Shared Function SaveProductionQcdOther(ByVal objQcdOtherPPT As ProductionQcdOtherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objQcdOtherPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionQCDOtherSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objQcdOtherPPT As ProductionQcdOtherPPT) As SqlParameter()

        Dim Parms(16) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objQcdOtherPPT.ID Is Nothing OrElse objQcdOtherPPT.ID = 0, DBNull.Value, objQcdOtherPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objQcdOtherPPT.DocDate)
        Parms(1) = New SqlParameter("@CRubber3CV", objQcdOtherPPT.CRubber3CV)
        Parms(2) = New SqlParameter("@CRubber10VK", objQcdOtherPPT.CRubber10VK)
        Parms(3) = New SqlParameter("@Storage", objQcdOtherPPT.Storage)
        Parms(4) = New SqlParameter("@CRubberDRC", objQcdOtherPPT.CRubberDRC)
        Parms(5) = New SqlParameter("@CenexDRC", objQcdOtherPPT.CenexDRC)
        Parms(6) = New SqlParameter("@Dirt", objQcdOtherPPT.Dirt)
        Parms(7) = New SqlParameter("@CenexNh3", objQcdOtherPPT.CenexNh3)
        Parms(8) = New SqlParameter("@Ash", objQcdOtherPPT.Ash)
        Parms(9) = New SqlParameter("@MG", objQcdOtherPPT.MG)
        Parms(10) = New SqlParameter("@BsrDRC", objQcdOtherPPT.BsrDRC)
        Parms(11) = New SqlParameter("@RssDRC", objQcdOtherPPT.RssDRC)
        Parms(12) = New SqlParameter("@BcDRC", objQcdOtherPPT.BcDRC)
        Parms(13) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(14) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(15) = New SqlParameter("@EstateID", GlobalPPT.strEstateID) 'objQcdOtherPPT.EstateID
        Parms(16) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objQcdOtherPPT As ProductionQcdOtherPPT) As List(Of ProductionQcdOtherPPT)
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@DocDate", If(objQcdOtherPPT.DocDate Is Nothing, DBNull.Value, objQcdOtherPPT.DocDate))
        params(1) = New SqlParameter("@Storage", If(objQcdOtherPPT.Storage Is Nothing, DBNull.Value, objQcdOtherPPT.Storage))
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Try
            dt = objdb.ExecQuery("[Production].[ProductionQCDOtherGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionQcdOtherPPT)(dt)
    End Function

    Public Shared Function DeleteLastQcdOther(ByVal objQcdOtherPPT As ProductionQcdOtherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@Id", objQcdOtherPPT.Id)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        'Varbinary need to specifically mention
        'Parms(3) = New SqlParameter("@tstamp", SqlDbType.VarBinary, 8)
        'Parms(3).Value = If(objQcdOtherPPT.Tstamp Is Nothing, DBNull.Value, objQcdOtherPPT.Tstamp)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionQCDOtherDelete]", Parms, False)
        Return ds

    End Function
End Class
