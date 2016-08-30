Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionQcdCenexDAL
    Public Shared Function SaveQCNX(ByVal objLQCNXPPT As ProductionQcdCenexPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objLQCNXPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[QCNXSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objLQCNXPPT As ProductionQcdCenexPPT) As SqlParameter()
        Dim Parms(18) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objWIORubberPPT.ID Is Nothing OrElse objWIORubberPPT.ID = 0, DBNull.Value, objWIORubberPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objLQCNXPPT.DocDate)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@Category", objLQCNXPPT.QCNXCategory)
        Parms(4) = New SqlParameter("@Train", objLQCNXPPT.QCNXTrain)
        Parms(5) = New SqlParameter("@LoadLoc", objLQCNXPPT.QCNXLLoc)
        Parms(6) = New SqlParameter("@Dest", objLQCNXPPT.QCNXDes)
        Parms(7) = New SqlParameter("@Sedo", objLQCNXPPT.QCNXSe)
        Parms(8) = New SqlParameter("@Qty", objLQCNXPPT.QCNXQty)
        Parms(9) = New SqlParameter("@Drc", objLQCNXPPT.QCNXDrc)
        Parms(10) = New SqlParameter("@Tsc", objLQCNXPPT.QCNXTsc)
        Parms(11) = New SqlParameter("@Nrc", objLQCNXPPT.QCNXNrc)
        Parms(12) = New SqlParameter("@Nh3", objLQCNXPPT.QCNXNh3)
        Parms(13) = New SqlParameter("@Vfa", objLQCNXPPT.QCNXVfa)
        Parms(14) = New SqlParameter("@Mst", objLQCNXPPT.QCNXMst)
        Parms(15) = New SqlParameter("@Koh", objLQCNXPPT.QCNXKoh)
        Parms(16) = New SqlParameter("@Mg", objLQCNXPPT.QCNXMg)
        Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(18) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objLPOPPT As ProductionQcdCenexPPT) As List(Of ProductionQcdCenexPPT)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@Train", If(objLPOPPT.QCNXTrain Is Nothing, DBNull.Value, objLPOPPT.QCNXTrain))
        params(1) = New SqlParameter("@DocDate", If(objLPOPPT.DocDate Is Nothing, DBNull.Value, objLPOPPT.DocDate))
        params(2) = New SqlParameter("@Cat", If(objLPOPPT.QCNXCategory Is Nothing, DBNull.Value, objLPOPPT.QCNXCategory))
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Try
            dt = objdb.ExecQuery("[Production].[QCNXGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionQcdCenexPPT)(dt)
    End Function

    Public Shared Function DeleteLastQCNX(ByVal objLPOPPT As ProductionQcdCenexPPT) As DataSet

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
        ds = objdb.ExecQuery("[Production].[QCNXDelete]", Parms, False)
        Return ds

    End Function
End Class
