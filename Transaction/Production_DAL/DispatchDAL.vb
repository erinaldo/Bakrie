Imports Production_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class DispatchDAL

    Public Shared Function SaveDispatch(ByVal ObjDispatchPPT As DispatchPPT, Optional isKernel As Boolean = False) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(33) As SqlParameter
        Dim dsCPO As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@ProductID", ObjDispatchPPT.ProductID)
        Parms(4) = New SqlParameter("@DispatchDate", ObjDispatchPPT.DispatchDate)
        Parms(5) = New SqlParameter("@BAPNo", IIf(ObjDispatchPPT.BAPNo = "", DBNull.Value, ObjDispatchPPT.BAPNo))
        Parms(6) = New SqlParameter("@shipPontoon", IIf(ObjDispatchPPT.ShipPontoon = "", DBNull.Value, ObjDispatchPPT.ShipPontoon))
        Parms(7) = New SqlParameter("@DOA", ObjDispatchPPT.DOA)
        Parms(8) = New SqlParameter("@DOATime", ObjDispatchPPT.DOATime)
        Parms(9) = New SqlParameter("@DOL", ObjDispatchPPT.DOL)
        Parms(10) = New SqlParameter("@DOLTime", ObjDispatchPPT.DOLTime)
        Parms(11) = New SqlParameter("@DCL", ObjDispatchPPT.DCL)
        Parms(12) = New SqlParameter("@DCLTime", ObjDispatchPPT.DCLTime)
        Parms(13) = New SqlParameter("@DepartureDate", ObjDispatchPPT.DepatureDate)
        Parms(14) = New SqlParameter("@DepartureTime", ObjDispatchPPT.Depaturetime)
        Parms(15) = New SqlParameter("@MillWeight", ObjDispatchPPT.MillWeight)
        Parms(16) = New SqlParameter("@LoadingLocationID", IIf(ObjDispatchPPT.LoadingLocationID = "", DBNull.Value, ObjDispatchPPT.LoadingLocationID))
        Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(18) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(20) = New SqlParameter("@ModifiedOn", Date.Today)

        If isKernel Then
            Parms(21) = New SqlParameter("@isKernel", "1")
        Else
            Parms(21) = New SqlParameter("@isKernel", "")
        End If

        Parms(22) = New SqlParameter("@BuyerName", ObjDispatchPPT.BuyerName)
        Parms(23) = New SqlParameter("@KontrakNo", ObjDispatchPPT.KontrakNo)
        Parms(24) = New SqlParameter("@NoPenyerahan", ObjDispatchPPT.NoPenyerahan)
        Parms(25) = New SqlParameter("@NoInstruksi", ObjDispatchPPT.NoInstruksi)
        Parms(26) = New SqlParameter("@JumlahKontrak", ObjDispatchPPT.JumlahKontrak)
        Parms(27) = New SqlParameter("@NoSim", ObjDispatchPPT.NoSim)
        Parms(28) = New SqlParameter("@NoTruk", ObjDispatchPPT.NoTruk)
        Parms(29) = New SqlParameter("@SealNo", ObjDispatchPPT.SealNo)
        Parms(30) = New SqlParameter("@DriverName", ObjDispatchPPT.DriverName)
        Parms(31) = New SqlParameter("@TransporterNo", ObjDispatchPPT.TransporterNo)
        Parms(32) = New SqlParameter("@SPBNo", ObjDispatchPPT.SPBNo)
        Parms(33) = New SqlParameter("@TermofSales", ObjDispatchPPT.TermofSales)

        dsCPO = objdb.ExecQuery("[Production].[CPODispatchInsert]", Parms)
        Return dsCPO
    End Function
    Public Shared Function UpdateDispatch(ByVal ObjDispatchPPT As DispatchPPT, Optional isKernel As Boolean = False) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(31) As SqlParameter
        Dim dsCPO As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@DisPatchID", ObjDispatchPPT.DispatchID)
        Parms(3) = New SqlParameter("@ProductID", ObjDispatchPPT.ProductID)
        Parms(4) = New SqlParameter("@DispatchDate", ObjDispatchPPT.DispatchDate)
        Parms(5) = New SqlParameter("@BAPNo", IIf(ObjDispatchPPT.BAPNo = "", DBNull.Value, ObjDispatchPPT.BAPNo))
        Parms(6) = New SqlParameter("@shipPontoon", IIf(ObjDispatchPPT.ShipPontoon = "", DBNull.Value, ObjDispatchPPT.ShipPontoon))
        Parms(7) = New SqlParameter("@DOA", ObjDispatchPPT.DOA)
        Parms(8) = New SqlParameter("@DOATime", ObjDispatchPPT.DOATime)
        Parms(9) = New SqlParameter("@DOL", ObjDispatchPPT.DOL)
        Parms(10) = New SqlParameter("@DOLTime", ObjDispatchPPT.DOLTime)
        Parms(11) = New SqlParameter("@DCL", ObjDispatchPPT.DCL)
        Parms(12) = New SqlParameter("@DCLTime", ObjDispatchPPT.DCLTime)
        Parms(13) = New SqlParameter("@DepartureDate", ObjDispatchPPT.DepatureDate)
        Parms(14) = New SqlParameter("@DepartureTime", ObjDispatchPPT.Depaturetime)
        Parms(15) = New SqlParameter("@MillWeight", ObjDispatchPPT.MillWeight)
        Parms(16) = New SqlParameter("@LoadingLocationID", IIf(ObjDispatchPPT.LoadingLocationID = "", DBNull.Value, ObjDispatchPPT.LoadingLocationID))
        Parms(17) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(18) = New SqlParameter("@ModifiedOn", Date.Today)
        If isKernel Then
            Parms(19) = New SqlParameter("@isKernel", "1")
        Else
            Parms(19) = New SqlParameter("@isKernel", "")
        End If
        Parms(20) = New SqlParameter("@BuyerName", ObjDispatchPPT.BuyerName)
        Parms(21) = New SqlParameter("@KontrakNo", ObjDispatchPPT.KontrakNo)
        Parms(22) = New SqlParameter("@NoPenyerahan", ObjDispatchPPT.NoPenyerahan)
        Parms(23) = New SqlParameter("@NoInstruksi", ObjDispatchPPT.NoInstruksi)
        Parms(24) = New SqlParameter("@JumlahKontrak", ObjDispatchPPT.JumlahKontrak)
        Parms(25) = New SqlParameter("@NoSim", ObjDispatchPPT.NoSim)
        Parms(26) = New SqlParameter("@NoTruk", ObjDispatchPPT.NoTruk)
        Parms(27) = New SqlParameter("@SealNo", ObjDispatchPPT.SealNo)
        Parms(28) = New SqlParameter("@DriverName", ObjDispatchPPT.DriverName)
        Parms(29) = New SqlParameter("@TransporterNo", ObjDispatchPPT.TransporterNo)
        Parms(30) = New SqlParameter("@SPBNo", ObjDispatchPPT.SPBNo)
        Parms(31) = New SqlParameter("@TermofSales", ObjDispatchPPT.TermofSales)

        dsCPO = objdb.ExecQuery("[Production].[CPODispatchUpdate]", Parms)
        Return dsCPO
    End Function

    Public Shared Function SaveDispatchDetail(ByVal ObjDispatchPPT As DispatchPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@DisPatchID", ObjDispatchPPT.DispatchID)
        Parms(4) = New SqlParameter("@Position", ObjDispatchPPT.Position)
        Parms(5) = New SqlParameter("@FFAP", IIf(ObjDispatchPPT.FFAP = 0, DBNull.Value, ObjDispatchPPT.FFAP))
        Parms(6) = New SqlParameter("@MoistureP", IIf(ObjDispatchPPT.MoistureP = 0, DBNull.Value, ObjDispatchPPT.MoistureP))
        Parms(7) = New SqlParameter("@DirtP", IIf(ObjDispatchPPT.DirtP = 0, DBNull.Value, ObjDispatchPPT.DirtP))
        Parms(8) = New SqlParameter("@BrokenKernel", IIf(ObjDispatchPPT.BrokenKernel = 0, DBNull.Value, ObjDispatchPPT.BrokenKernel))
        Parms(9) = New SqlParameter("@Temp", IIf(ObjDispatchPPT.Temp = 0, DBNull.Value, ObjDispatchPPT.Temp))
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedOn", Date.Today)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[CPODispatchDetailInsert]", Parms)
        Return ds
    End Function

    Public Shared Function UpDateDispatchDetail(ByVal ObjDispatchPPT As DispatchPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@DisPatchID", ObjDispatchPPT.DispatchID)
        Parms(3) = New SqlParameter("@Position", ObjDispatchPPT.Position)
        Parms(4) = New SqlParameter("@FFAP", IIf(ObjDispatchPPT.FFAP = 0, DBNull.Value, ObjDispatchPPT.FFAP))
        Parms(5) = New SqlParameter("@MoistureP", IIf(ObjDispatchPPT.MoistureP = 0, DBNull.Value, ObjDispatchPPT.MoistureP))
        Parms(6) = New SqlParameter("@DirtP", IIf(ObjDispatchPPT.DirtP = 0, DBNull.Value, ObjDispatchPPT.DirtP))
        Parms(7) = New SqlParameter("@BrokenKernel", IIf(ObjDispatchPPT.BrokenKernel = 0, DBNull.Value, ObjDispatchPPT.BrokenKernel))
        Parms(8) = New SqlParameter("@Temp", IIf(ObjDispatchPPT.Temp = 0, DBNull.Value, ObjDispatchPPT.Temp))
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(11) = New SqlParameter("@DispatchDetailID", ObjDispatchPPT.DispatchDetailID)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[DispatchDetailUpdate]", Parms)
        Return ds
    End Function

    Public Function GetTankMaster() As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim parms(2) As SqlParameter
        parms(0) = New SqlParameter("@TankID", DBNull.Value)
        parms(1) = New SqlParameter("@TankNo", DBNull.Value)
        parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Production].[TankMasterSelect]", parms).Tables(0)
        Return dt
    End Function

    Public Function GetKernelStorage() As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim parms(3) As SqlParameter
        parms(0) = New SqlParameter("@KernelStorageID", DBNull.Value)
        parms(1) = New SqlParameter("@Code", DBNull.Value)
        parms(2) = New SqlParameter("@Type", DBNull.Value)
        parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Production].[KernelStorageSelect]", parms).Tables(0)
        Return dt
    End Function

    Public Function GetLocationValues(ByVal ObjDispatchPPT As DispatchPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Production].[CPODispatchLoadingLocationSelect]", Parms).Tables(0)
        Return dt
    End Function
    Public Function GetProductIDValues(ByVal ObjDispatchPPT As DispatchPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Production].[CPODispatchProductIDSelect]", Parms)
        Return ds
    End Function

    Public Function DuplicateDateCheck(ByVal ObjDispatchPPT As DispatchPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductID", ObjDispatchPPT.ProductID)
        Parms(2) = New SqlParameter("@DispatchDate", ObjDispatchPPT.DispatchDate)

        objExists = objdb.ExecuteScalar("[Production].[CPODispatchIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function

    Public Function GetDispatchValues(ByVal ObjDispatchPPT As DispatchPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductID", ObjDispatchPPT.ProductID)
        Parms(2) = New SqlParameter("@DispatchDate", ObjDispatchPPT.lDispatchDate)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Production].[CPODispatchSelect]", Parms)
        Return ds
    End Function

    Public Function GetDispatchDetailValues(ByVal ObjDispatchPPT As DispatchPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim ds As New DataTable
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@DispatchID", ObjDispatchPPT.DispatchID)

        ds = objdb.ExecQuery("[Production].[CPODispatchDetailSelect]", Parms).Tables(0)
        Return ds
    End Function

    Public Function DeleteDispatch(ByVal ObjDispatchPPT As DispatchPPT, Optional isKernel As Boolean = False) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@DispatchID", ObjDispatchPPT.DispatchID)

        If isKernel Then
            Parms(2) = New SqlParameter("@isKernel", "1")
        Else
            Parms(2) = New SqlParameter("@isKernel", "")
        End If
        rowsAffected = objdb.ExecNonQuery("[Production].[CPODispatchDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function

    Public Function DispatchRecordIsExist(ByVal ObjDispatchPPT As DispatchPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Production].[CPODispatchRecordIsExist]", Parms)
        Return objExists
    End Function

    Public Function GetCPOLoading(ByVal ObjDispatchPPT As DispatchPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BAPNo", IIf(ObjDispatchPPT.BAPNo <> "", ObjDispatchPPT.BAPNo, DBNull.Value))
        Parms(2) = New SqlParameter("@DispatchDate", IIf(ObjDispatchPPT.lDispatchDate <> "", ObjDispatchPPT.lDispatchDate, DBNull.Value))
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ds = objdb.ExecQuery("[Production].[CPOLoadingSelect]", Parms)
        Return ds
    End Function

    Public Function CPOLoading_Reporting(ByVal ObjDispatchPPT As DispatchPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@DispatchID", ObjDispatchPPT.DispatchID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ds = objdb.ExecQuery("[Production].[CPOLoadingReport]", Parms)
        Return ds
    End Function

    Public Function GetPKOLoading(ByVal ObjDispatchPPT As DispatchPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BAPNo", IIf(ObjDispatchPPT.BAPNo <> "", ObjDispatchPPT.BAPNo, DBNull.Value))
        Parms(2) = New SqlParameter("@DispatchDate", IIf(ObjDispatchPPT.lDispatchDate <> Nothing, ObjDispatchPPT.lDispatchDate, DBNull.Value))
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ds = objdb.ExecQuery("[Production].[PKOLoadingSelect]", Parms)
        Return ds
    End Function


    Public Function DeleteMultiEntryCPOPKOKernel(ByVal ObjDispatchPPT As DispatchPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@DispatchDetailID", ObjDispatchPPT.DispatchDetailID)

        rowsAffected = objdb.ExecNonQuery("[Production].[DispatchMultiEntryDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function


End Class
