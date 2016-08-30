Imports Production_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Public Class ProductionQcdCrumbDAL
    Public Shared Function SaveQCRM(ByVal objLQCRMPPT As ProductionQcdCrumbPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Dim Params() As SqlParameter
        Params = getSQLParameters(objLQCRMPPT)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[QCRMSave]", Params)
        Return ds

    End Function

    Shared Function getSQLParameters(ByVal objLQCRMPPT As ProductionQcdCrumbPPT) As SqlParameter()
        Dim Parms(24) As SqlParameter
        'Parms(0) = New SqlParameter("@Id", (If(objWIORubberPPT.ID Is Nothing OrElse objWIORubberPPT.ID = 0, DBNull.Value, objWIORubberPPT.ID)))
        Parms(0) = New SqlParameter("@DocDate", objLQCRMPPT.DocDate)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@Category", objLQCRMPPT.QCRMCategory)
        Parms(4) = New SqlParameter("@Product", objLQCRMPPT.QCRMProduct)
        Parms(5) = New SqlParameter("@Storage", objLQCRMPPT.QCRMStorage)
        Parms(6) = New SqlParameter("@Grade", objLQCRMPPT.QCRMGrade)
        Parms(7) = New SqlParameter("@DoNumb", objLQCRMPPT.QCRMDoNum)
        Parms(8) = New SqlParameter("@LoadLoc", objLQCRMPPT.QCRMLLoc)
        Parms(9) = New SqlParameter("@VehNumb", objLQCRMPPT.QCRMVnum)
        Parms(10) = New SqlParameter("@PC", objLQCRMPPT.QCRMNoP)
        Parms(11) = New SqlParameter("@LC", objLQCRMPPT.QCRMNoL)
        Parms(12) = New SqlParameter("@Dest", objLQCRMPPT.QCRMDes)
        Parms(13) = New SqlParameter("@MWt", objLQCRMPPT.QCRMMwt)
        Parms(14) = New SqlParameter("@P30", objLQCRMPPT.QCRMP3)
        Parms(15) = New SqlParameter("@DC", objLQCRMPPT.QCRMDC)
        Parms(16) = New SqlParameter("@PO", objLQCRMPPT.QCRMPO)
        Parms(17) = New SqlParameter("@PRI", objLQCRMPPT.QCRMPri)
        Parms(18) = New SqlParameter("@MV", objLQCRMPPT.QCRMV)
        Parms(19) = New SqlParameter("@VM", objLQCRMPPT.QCRMVM)
        Parms(20) = New SqlParameter("@NC", objLQCRMPPT.QCRMNC)
        Parms(21) = New SqlParameter("@LC1", objLQCRMPPT.QCRMLC)
        Parms(22) = New SqlParameter("@AC", objLQCRMPPT.QCRMAC)
        Parms(23) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(24) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Return Parms
    End Function

    Public Function GetSearchResults(ByVal objLPOPPT As ProductionQcdCrumbPPT) As List(Of ProductionQcdCrumbPPT)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@Storage", If(objLPOPPT.QCRMStorage Is Nothing, DBNull.Value, objLPOPPT.QCRMStorage))
        params(1) = New SqlParameter("@DocDate", If(objLPOPPT.DocDate Is Nothing, DBNull.Value, objLPOPPT.DocDate))
        params(2) = New SqlParameter("@Type", If(objLPOPPT.QCRMProduct Is Nothing, DBNull.Value, objLPOPPT.QCRMProduct))
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Try
            dt = objdb.ExecQuery("[Production].[QCRMGet]", params).Tables(0)
        Catch ex As Exception
        End Try
        Return objdb.ConvertToObjectList(Of ProductionQcdCrumbPPT)(dt)
    End Function

    Public Shared Function DeleteLastQCRM(ByVal objLPOPPT As ProductionQcdCrumbPPT) As DataSet

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
        ds = objdb.ExecQuery("[Production].[QCRMDelete]", Parms, False)
        Return ds

    End Function
End Class
