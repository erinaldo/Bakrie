Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class CPOProductionDAL
    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", CropYieldCode)
        Return objdb.ExecQuery("[Production].[CPOGetStorage]", Parms)
    End Function
 

    Public Function DuplicateDateCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        'Dim objdb As New SQLHelp
        'Dim Parms(2) As SqlParameter
        'Dim objExists As Object
        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@CPODate", objCPOPPT.CPODate)
        'Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

        'objExists = objdb.ExecuteScalar("[Production].[CPODateIsExist]", Parms)
        'If objExists <> Nothing Then
        '    objExists = 0
        '    Return objExists
        'Else
        '    objExists = 1
        '    Return objExists
        'End If
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objCPOPPT.CPOProductionDate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[CPODateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function

    Public Function CalculateCurrentReading(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@Height", objCPOPPT.Measurement)
        Parms(1) = New SqlParameter("@Temprature", objCPOPPT.Temparature)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(4) = New SqlParameter("@CurrentReading", objCPOPPT.CurrentReading)
        objExists = objdb.ExecuteScalar("[Production].[CalculateCurrentReading]", Parms)
        'If objExists <> Nothing Then
        'objExists = 0
        Return objExists
        'Else
        'objExists = 1
        'Return objExists
        'End If
    End Function


    Public Function DuplicateLoadTankCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@TankID", objCPOPPT.TankID)
        objExists = objdb.ExecuteScalar("[Production].[CPOLoadTankIsExist]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function

    Public Function DuplicateTankFirstCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@TankID", objCPOPPT.TankID)
        'Parms(3) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)

        objExists = objdb.ExecuteScalar("[Production].[CPOTankFirstCheck]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function DuplicateLoadLocationFirstCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        'Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        objExists = objdb.ExecuteScalar("[Production].[CPOLoadLocationFirstCheck]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function DuplicateKernelLoadLocationCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@KernalID", objCPOPPT.KernalID)
        'Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        objExists = objdb.ExecuteScalar("[Production].[KernelLoadLocationCheck]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function DuplicateKernelTransLocationCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@KernalID", objCPOPPT.KernalID)
        'Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        objExists = objdb.ExecuteScalar("[Production].[KernelTransLocationCheck]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function DuplicateTransLocationFirstCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        ' Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        objExists = objdb.ExecuteScalar("[Production].[CPOTransLocationFirstCheck]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function

    Public Function DuplicateStockTankCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(3) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)

        objExists = objdb.ExecuteScalar("[Production].[CPOTankIsExist]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function DuplicateKernalCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@KernalID", objCPOPPT.KernalID)
        Parms(3) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        objExists = objdb.ExecuteScalar("[Production].[CPOKernalIsExist]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function DuplicateKernalFirstCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@KernalID", objCPOPPT.KernalID)
        'Parms(3) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        objExists = objdb.ExecuteScalar("[Production].[CPOKernelFirstCheck]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function DuplicateLoadLocationCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        objExists = objdb.ExecuteScalar("[Production].[CPOLoadLocationIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function

    Public Function DuplicateTransTankCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@TankID", objCPOPPT.TankID)
        objExists = objdb.ExecuteScalar("[Production].[CPOTransTankIsExist]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function DuplicateTransLocationCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        objExists = objdb.ExecuteScalar("[Production].[CPOTransLocationIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Shared Function GetProductionID(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Return objdb.ExecQuery("[Production].[CPOGetProductionID]", Parms)
    End Function
    Public Shared Function CPOGetLoadVsLocMonthQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(2) = New SqlParameter("@LoadLocationID", objCPOPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(4) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(6) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)

        Return objdb.ExecQuery("[Production].[CPOGetLoadVsLocMonthQty]", Parms)
    End Function
    Public Shared Function CPOGetTransVsLocMonthQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(2) = New SqlParameter("@LoadLocationID", objCPOPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(4) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(6) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Return objdb.ExecQuery("[Production].[CPOGetTransVsLocMonthQty]", Parms)
    End Function
    Public Shared Function GetTankID(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankNo", objCPOPPT.TankNo)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetTankID]", Parms)
    End Function
    Public Shared Function GetLocationID(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Descp", objCPOPPT.Descp)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetLocationID]", Parms)
    End Function

    Public Shared Function tankDetailSelect(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOTankDetailSelect]", Parms)
    End Function

    Public Shared Function loadCmbLocation() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Type", "Loading")
        Return objdb.ExecQuery("[Production].[CPOGetLoadingLocation]", Parms)
    End Function
    Public Shared Function CPOGetLoadMonthTodate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetLoadMonthTodate]", Parms)
    End Function
    Public Shared Function CPOGetTransMonthTodate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetTransMonthTodate]", Parms)
    End Function
    Public Shared Function CPOGetStockMonthYearQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Parms(4) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetStockMonthYearQty]", Parms)
    End Function
    Public Shared Function CPOGetTransMonthYearQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Parms(4) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetTransMonthYearQty]", Parms)
    End Function
    Public Shared Function CPOGetLoadMonthYearQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Parms(4) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        Return objdb.ExecQuery("[Production].[CPOGetLoadMonthYearQty]", Parms)
    End Function
    Public Shared Function CPOGetLoadTransMonthQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        ' Parms(4) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        Return objdb.ExecQuery("[Production].[CPOGetLoadTransMonthQty]", Parms)
    End Function

    Public Shared Function CPOGetTodayQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(1) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        'Parms(3) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)

        Return objdb.ExecQuery("[Production].[CPOGetProductionTodate]", Parms)
    End Function
    Public Shared Function GetCropYield(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetCropYield]", Parms)
    End Function
    Public Shared Function GetCropYieldID(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@CropYieldCode", objCPOPPT.CropYieldCode)
        Return objdb.ExecQuery("[Production].[CPOGetCropYieldID]", Parms)
    End Function
    Public Shared Function GetCPOAddInfo(ByVal objCPOPPT As CPOProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        'Parms(4) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        'Parms(4) = New SqlParameter("@TankNo", objCPOPPT.TankNo)
        Parms(3) = New SqlParameter("@CPODate", objCPOPPT.CPODate)

        Return objdb.ExecQuery("[Production].[GetCPOAddInfo]", Parms).Tables(0)
    End Function
    Public Shared Function GetCPOAddStockInfo(ByVal objCPOPPT As CPOProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        
        Parms(3) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Return objdb.ExecQuery("[Production].[GetCPOAddStockInfo]", Parms).Tables(0)
    End Function
    Public Shared Function GetCPOAddLoadInfo(ByVal objCPOPPT As CPOProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)

        Return objdb.ExecQuery("[Production].[GetCPOProductionLoad]", Parms).Tables(0)
    End Function
    Public Shared Function GetCPOAddTransInfo(ByVal objCPOPPT As CPOProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        
        Parms(3) = New SqlParameter("@CPODate", objCPOPPT.CPODate)
        Return objdb.ExecQuery("[Production].[GetCPOAddTransInfo]", Parms).Tables(0)
    End Function
    Public Shared Function saveCPOProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPOProductionDate)
        Parms(5) = New SqlParameter("@QtyToday", objCPOPPT.ProductionToday)
        Parms(6) = New SqlParameter("@QtyMonthToDate", objCPOPPT.ProductionMonth)
        Parms(7) = New SqlParameter("@QtyYearTodate", objCPOPPT.ProductionYear)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(12) = New SqlParameter("@CPODate", objCPOPPT.CPODate)

        Return objdb.ExecQuery("[Production].[CPOProductionInsert]", Parms)
    End Function
    Public Shared Function saveCPOTransProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@TransTankID", IIf(objCPOPPT.TransTankID <> String.Empty, objCPOPPT.TransTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(5) = New SqlParameter("@TransQty", objCPOPPT.TransQty)
        Parms(6) = New SqlParameter("@TransMonthToDate", objCPOPPT.TransMonthToDate)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@TransLocationID", IIf(objCPOPPT.TransLocationID <> String.Empty, objCPOPPT.TransLocationID, DBNull.Value))
        Parms(12) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(13) = New SqlParameter("@TransRemarks", objCPOPPT.TransRemarks)
        Return objdb.ExecQuery("[Production].[CPOProductionTransInsert]", Parms)
    End Function
    Public Shared Function saveCPOStockProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(20) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@StockTankID", IIf(objCPOPPT.StockTankID <> String.Empty, objCPOPPT.StockTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@Capacity", objCPOPPT.Capacity)
        Parms(5) = New SqlParameter("@PrevDayReading", objCPOPPT.PrevDayReading)
        Parms(6) = New SqlParameter("@CurrentReading", objCPOPPT.CurrentReading)
        Parms(7) = New SqlParameter("@Writeoff", objCPOPPT.Writeoff)
        Parms(8) = New SqlParameter("@Measurement", objCPOPPT.Measurement)
        Parms(9) = New SqlParameter("@Temp", objCPOPPT.Temparature)
        Parms(10) = New SqlParameter("@FFAP", objCPOPPT.FFA)
        Parms(11) = New SqlParameter("@MoistureP", objCPOPPT.Moisture)
        Parms(12) = New SqlParameter("@DirtP", objCPOPPT.Dirt)
        Parms(13) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(14) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(15) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(16) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(17) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(18) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(19) = New SqlParameter("@Reason", objCPOPPT.Reason)
        Parms(20) = New SqlParameter("@BeritaAcara", objCPOPPT.BeritaAcara)
        Return objdb.ExecQuery("[Production].[CPOProductionStockInsert]", Parms)
    End Function
    Public Shared Function saveCPOLoadProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@StockTankID", IIf(objCPOPPT.StockTankID <> String.Empty, objCPOPPT.StockTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@LoadTankID", IIf(objCPOPPT.LoadTankID <> String.Empty, objCPOPPT.LoadTankID, DBNull.Value))
        Parms(5) = New SqlParameter("@LoadingLocationID", IIf(objCPOPPT.LoadingLocationID <> String.Empty, objCPOPPT.LoadingLocationID, DBNull.Value))
        Parms(6) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(7) = New SqlParameter("@LoadQty", objCPOPPT.LoadQty)
        Parms(8) = New SqlParameter("@LoadMonthToDate", objCPOPPT.LoadMonthToDate)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(13) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(14) = New SqlParameter("@LoadRemarks", objCPOPPT.LoadRemarks)
        'Parms(28) = New SqlParameter("@TransLocationID", IIf(objCPOPPT.TransLocationID <> String.Empty, objCPOPPT.TransLocationID, DBNull.Value))
        Return objdb.ExecQuery("[Production].[CPOProductionLoadInsert]", Parms)
    End Function

    Public Shared Function UpdateTankMasterBFQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objCPOPPT.CPODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Return objdb.ExecQuery("[Production].[TankMasterBFUpdate]", Parms)
    End Function

    Public Shared Function UpdateCPOProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPOProductionDate)
        Parms(5) = New SqlParameter("@QtyToday", objCPOPPT.ProductionToday)
        Parms(6) = New SqlParameter("@QtyMonthToDate", objCPOPPT.ProductionMonth)
        Parms(7) = New SqlParameter("@QtyYearTodate", objCPOPPT.ProductionYear)
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
              Parms(10) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)

        Return objdb.ExecQuery("[Production].[CPOProductionUpdate]", Parms)
    End Function
    Public Shared Function UpdateCPOStockProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(19) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@StockTankID", IIf(objCPOPPT.StockTankID <> String.Empty, objCPOPPT.StockTankID, DBNull.Value))
        'Parms(4) = New SqlParameter("@LoadTankID", IIf(objCPOPPT.LoadTankID <> String.Empty, objCPOPPT.LoadTankID, DBNull.Value))
        'Parms(5) = New SqlParameter("@TransTankID", IIf(objCPOPPT.TransTankID <> String.Empty, objCPOPPT.TransTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@Capacity", objCPOPPT.Capacity)
        Parms(5) = New SqlParameter("@PrevDayReading", objCPOPPT.PrevDayReading)
        Parms(6) = New SqlParameter("@CurrentReading", objCPOPPT.CurrentReading)
        Parms(7) = New SqlParameter("@Writeoff", objCPOPPT.Writeoff)
        Parms(8) = New SqlParameter("@Measurement", objCPOPPT.Measurement)
        Parms(9) = New SqlParameter("@Temp", objCPOPPT.Temparature)
        Parms(10) = New SqlParameter("@FFAP", objCPOPPT.FFA)
        Parms(11) = New SqlParameter("@MoistureP", objCPOPPT.Moisture)
        Parms(12) = New SqlParameter("@DirtP", objCPOPPT.Dirt)
        Parms(13) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(14) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(15) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(16) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(17) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(18) = New SqlParameter("@ProdStockID", objCPOPPT.ProdStockID)
        Parms(19) = New SqlParameter("@Reason", objCPOPPT.Reason)

        Return objdb.ExecQuery("[Production].[CPOProductionStockUpdate]", Parms)
    End Function
    Public Shared Function UpdateCPOLoadProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LoadTankID", IIf(objCPOPPT.LoadTankID <> String.Empty, objCPOPPT.LoadTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@LoadingLocationID", IIf(objCPOPPT.LoadingLocationID <> String.Empty, objCPOPPT.LoadingLocationID, DBNull.Value))
        Parms(5) = New SqlParameter("@LoadQty", objCPOPPT.LoadQty)
        Parms(6) = New SqlParameter("@LoadMonthToDate", objCPOPPT.LoadMonthToDate)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(12) = New SqlParameter("@ProdLoadingID", objCPOPPT.ProdLoadingID)
        Parms(13) = New SqlParameter("@LoadRemarks", objCPOPPT.LoadRemarks)
        Return objdb.ExecQuery("[Production].[CPOProductionLoadUpdate]", Parms)
    End Function
    Public Shared Function UpdateCPOTransProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@TransTankID", IIf(objCPOPPT.TransTankID <> String.Empty, objCPOPPT.TransTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@TransQty", objCPOPPT.TransQty)
        Parms(5) = New SqlParameter("@TransMonthToDate", objCPOPPT.TransMonthToDate)
        Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(10) = New SqlParameter("@TransLocationID", IIf(objCPOPPT.TransLocationID <> String.Empty, objCPOPPT.TransLocationID, DBNull.Value))
        Parms(11) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(12) = New SqlParameter("@ProdTranshipID", objCPOPPT.ProdTranshipID)
        Parms(13) = New SqlParameter("@TransRemarks", objCPOPPT.TransRemarks)
        Return objdb.ExecQuery("[Production].[CPOProductionTransUpdate]", Parms)
    End Function
    Public Function GetCPODetails(ByVal objCPOPPT As CPOProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@CPODate", IIf(objCPOPPT.CPOProductionDate <> Nothing, objCPOPPT.CPOProductionDate, DBNull.Value))
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Production].[CPOProductionSearch]", params).Tables(0)
        Return dt
    End Function
    Public Function Delete_CPODetail(ByVal objCPOPPT As CPOProductionPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

      
        Parms(0) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPOProductionDate)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

        rowsAffected = objdb.ExecNonQuery("[Production].[CPOProductionDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function

    ''Changed by kumar
    Public Shared Function loadCmbStorageBalanceBF(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.CPOProductionDate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Return objdb.ExecQuery("[Production].[CPOGetStorageBalanceBF]", Parms)
    End Function


    Public Shared Function CPOGetLoadingCPOMonthtodate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.CPOProductionDate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
     
        Return objdb.ExecQuery("[Production].[LoadingCPOPrevDayQtyGet]", Parms)
    End Function

    Public Shared Function CPOGetTranshipCPOMonthtodate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.CPODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(4) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[CPOGetTranshipCPOMonthtodate]", Parms)
    End Function

    Public Shared Function CPOProductionMonthYeartodate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.CPOProductionDate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@ActiveYear", GlobalPPT.intActiveYear)

        Return objdb.ExecQuery("[Production].[CPOProductionMonthYeartodate]", Parms)
    End Function

    Public Shared Function ProductionCropYieldIDSelect(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", "CPO")
        ds = objdb.ExecQuery("[Production].[ProductionCropYieldIDSelect]", Parms)
        Return ds
    End Function

    '''Delete Multi entry Datagrid
    ''' 
    Public Function DeleteMultiEntryProdStock(ByVal ObjCPOProductionPPT As CPOProductionPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProdStockID", ObjCPOProductionPPT.ProdStockID)

        rowsAffected = objdb.ExecNonQuery("[Production].[StockCPOMultiEntryDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function


    Public Function DeleteMultiEntryProdLoading(ByVal ObjCPOProductionPPT As CPOProductionPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProdLoadID", ObjCPOProductionPPT.ProdLoadingID)

        rowsAffected = objdb.ExecNonQuery("[Production].[MultiEntryLoadCPODelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function

    Public Function DeleteMultiEntryProdTranship(ByVal ObjCPOProductionPPT As CPOProductionPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProdTranshipID", ObjCPOProductionPPT.ProdTranshipID)

        rowsAffected = objdb.ExecNonQuery("[Production].[TranshipCPOMultiEntryDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function


    Public Function CPOProductionTranshipqtySelect(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@ProductionDate", objCPOPPT.CPOProductionDate)

        ds = objdb.ExecQuery("[Production].[CPOProductionTranshipqtySelect]", Parms)
        Return ds
    End Function


    Public Shared Function CPOProdLoadInsert(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(4) = New SqlParameter("@CurrentQty", objCPOPPT.LoadCurrentReading)
        Parms(5) = New SqlParameter("@PrevDateQty", objCPOPPT.LoadPrevDayReading)
        Parms(6) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(12) = New SqlParameter("@LoadRemarks", objCPOPPT.LoadRemarks)
        Return objdb.ExecQuery("[Production].[CPOProdLoadInsert]", Parms)
    End Function


    Public Shared Function CPOProdLoadUpdate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ProdLoadID", objCPOPPT.ProdLoadingID)
        Parms(3) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(4) = New SqlParameter("@CurrentQty", objCPOPPT.LoadCurrentReading)
        Parms(5) = New SqlParameter("@PrevDateQty", objCPOPPT.LoadPrevDayReading)
        Parms(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(8) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(9) = New SqlParameter("@LoadRemarks", objCPOPPT.LoadRemarks)
        Return objdb.ExecQuery("[Production].[CPOProdLoadUpdate]", Parms)
    End Function



End Class
