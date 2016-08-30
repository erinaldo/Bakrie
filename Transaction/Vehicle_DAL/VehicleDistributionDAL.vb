
Imports Common_PPT
Imports Common_DAL
Imports Vehicle_PPT
Imports System.Data.SqlClient
Public Class VehicleDistributionDAL

    Public Function GetVehicleCode(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As DataSet
        Dim ds As DataSet
        
        Dim Parms(6) As SqlParameter
        Dim objdb As New SQLHelp



        Parms(0) = New SqlParameter("@DistributionDT", GetDataValue(_VehicleDistributionPPT.pdDistributionDT))
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@VHWSCode", GetDataValue(_VehicleDistributionPPT.psVHID))
        Parms(4) = New SqlParameter("@SearchByDate", GetDataValue(_VehicleDistributionPPT.psSearchBy))
        Parms(5) = New SqlParameter("@VehicleName", GetDataValue(_VehicleDistributionPPT.psVehicleName))
        Parms(6) = New SqlParameter("@VehicleModel", GetDataValue(_VehicleDistributionPPT.psVHModel))
        ds = objdb.ExecQuery("[Vehicle].VehicleDistributionVehicleCodeGET", Parms)
        Return ds
        '' Return objdb.ExecQuery("[Vehicle].VehicleDistributionVehicleCodeGET", Parms)

    End Function

    Public Function GetVehicleDistribution(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As DataSet
        Dim ds As DataSet

        Dim Parms(3) As SqlParameter
        Dim objdb As New SQLHelp
        Parms(0) = New SqlParameter("@VHID", GetDataValue(_VehicleDistributionPPT.psVHID))
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@DistributionDT", GetDataValue(_VehicleDistributionPPT.pdDistributionDT))
        ds = objdb.ExecQuery("[Vehicle].[VehicleDistributionGET]", Parms)
        Return ds


    End Function

    Public Function GetVehicleDistributionDetails(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As DataSet
        Dim Parms(0) As SqlParameter
        Dim objdb As New SQLHelp
        Parms(0) = New SqlParameter("@Id", GetDataValue(_VehicleDistributionPPT.piId))
        Return objdb.ExecQuery("[Vehicle].[VehicleDistributionEditDetailsGET]", Parms)


    End Function

    Public Function GetDistributionValueForVehicleCode(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As DataSet
        Dim Parms(3) As SqlParameter
        Dim objdb As New SQLHelp
        Parms(0) = New SqlParameter("@VHID", GetDataValue(_VehicleDistributionPPT.psVHID))
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@DistributionDT", GetDataValue(_VehicleDistributionPPT.pdDistributionDT))
        Return objdb.ExecQuery("[Vehicle].[VehicleDistributionInitialValuesForVehicleCodeGET]", Parms)

    End Function

    Public Function IsConcurrentRecordSelect(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Boolean
        Dim Parms(1) As SqlParameter
        Dim objdb As New SQLHelp
        Parms(0) = New SqlParameter("@Id", GetDataValue(_VehicleDistributionPPT.piId))
        Parms(1) = New SqlParameter("@ConcurrencyId", GetDataValue(_VehicleDistributionPPT.pbConcurrencyId))
        Return objdb.ExecuteScalar("[Vehicle].[IsConcurrentRecordSelect]", Parms)
    End Function

    Public Function VHDistributionRecordIsExist(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Vehicle].[VHDistributionRecordIsExist]", Parms)
        Return objExists
    End Function

#Region "Lookup"

    Public Function GetDIV(ByVal _VehicleDistributionPPT As VehicleDistributionPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim ds As New DataSet
        Parms(0) = New SqlParameter("@Div", GetDataValue(_VehicleDistributionPPT.Div))
        Parms(1) = New SqlParameter("@DivName", GetDataValue(_VehicleDistributionPPT.DivName))
        Parms(2) = New SqlParameter("@IsDirect", IsDirect)
        Parms(3) = New SqlParameter("@BlockID", GetDataValue(_VehicleDistributionPPT.BlockID))
        Parms(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("Vehicle.VDDivisionGet", Parms)
        Return ds
    End Function

    Public Function GetYOP(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        If _VehicleDistributionPPT.YOP <> "" And _VehicleDistributionPPT.YOPName <> "" Then
            Parms(0) = New SqlParameter("@YOP", _VehicleDistributionPPT.YOP)
            Parms(1) = New SqlParameter("@YOPName", _VehicleDistributionPPT.YOPName)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf _VehicleDistributionPPT.YOP <> "" And _VehicleDistributionPPT.YOPName = "" Then
            Parms(0) = New SqlParameter("@YOP", _VehicleDistributionPPT.YOP)
            Parms(1) = New SqlParameter("@YOPName", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf _VehicleDistributionPPT.YOP = "" And _VehicleDistributionPPT.YOPName <> "" Then
            Parms(0) = New SqlParameter("@YOP", DBNull.Value)
            Parms(1) = New SqlParameter("@YOPName", _VehicleDistributionPPT.YOPName)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@YOP", DBNull.Value)
            Parms(1) = New SqlParameter("@YOPName", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Return objdb.ExecQuery("Vehicle.VDGetYOP", Parms)
    End Function

    Public Function GetSubBlock(ByVal _VehicleDistributionPPT As VehicleDistributionPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter

        Parms(0) = New SqlParameter("@Div", GetDataValue(_VehicleDistributionPPT.Div))
        Parms(1) = New SqlParameter("@YOP", GetDataValue(_VehicleDistributionPPT.YOP))
        Parms(2) = New SqlParameter("@BlockName", GetDataValue(_VehicleDistributionPPT.BlockName))
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(4) = New SqlParameter("@IsDirect", IsDirect)
        If PsGETBlockStatusByExpenditureAG(_VehicleDistributionPPT.BlockStatus) <> String.Empty Then
            Parms(5) = New SqlParameter("@BlockStatus", PsGETBlockStatusByExpenditureAG(_VehicleDistributionPPT.BlockStatus))
        Else
            Parms(5) = New SqlParameter("@BlockStatus", DBNull.Value)
        End If


        'Parms(5) = New SqlParameter("@BlockStatus", GetDataValue(_VehicleDistributionPPT.BlockStatus))

        Dim ds As New DataSet
        ds = objdb.ExecQuery("Vehicle.VDBlockMasterGet", Parms)
        Return ds

    End Function

    Public Shared Function PsGETBlockStatusByExpenditureAG(ByVal ExpenditureAG As String) As String

        Select Case ExpenditureAG
            Case "Newplanting"
                PsGETBlockStatusByExpenditureAG = "Immature"
            Case "Nursery"
                PsGETBlockStatusByExpenditureAG = "Nursery"
            Case "Matured"
                PsGETBlockStatusByExpenditureAG = "Matured"
            Case "Immature"
                PsGETBlockStatusByExpenditureAG = "Replanting"
            Case "MILL"
                PsGETBlockStatusByExpenditureAG = "MILL"
            Case "KCP"
                PsGETBlockStatusByExpenditureAG = "KCP"
            Case "CES"
                PsGETBlockStatusByExpenditureAG = "CES"
            Case "Operating"
                PsGETBlockStatusByExpenditureAG = "Operating"
            Case Else
                PsGETBlockStatusByExpenditureAG = String.Empty
        End Select

    End Function

    Public Function TlookupSearch(ByVal _VehicleDistributionPPT As VehicleDistributionPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(4) = New SqlParameter("@IsDirect", IsDirect)
        If _VehicleDistributionPPT.TDecide = "T0" Then
            If _VehicleDistributionPPT.T0Value <> "" And _VehicleDistributionPPT.T0Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", _VehicleDistributionPPT.T0Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", _VehicleDistributionPPT.T0Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf _VehicleDistributionPPT.T0Value <> "" And _VehicleDistributionPPT.T0Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", _VehicleDistributionPPT.T0Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf _VehicleDistributionPPT.T0Value = "" And _VehicleDistributionPPT.T0Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", _VehicleDistributionPPT.T0Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If _VehicleDistributionPPT.TDecide = "T1" Then
            If _VehicleDistributionPPT.T1Value <> "" And _VehicleDistributionPPT.T1Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", _VehicleDistributionPPT.T1Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", _VehicleDistributionPPT.T1Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf _VehicleDistributionPPT.T1Value <> "" And _VehicleDistributionPPT.T1Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", _VehicleDistributionPPT.T1Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf _VehicleDistributionPPT.T1Value = "" And _VehicleDistributionPPT.T1Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", _VehicleDistributionPPT.T1Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If _VehicleDistributionPPT.TDecide = "T2" Then
            If _VehicleDistributionPPT.T2Value <> "" And _VehicleDistributionPPT.T2Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", _VehicleDistributionPPT.T2Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", _VehicleDistributionPPT.T2Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf _VehicleDistributionPPT.T2Value <> "" And _VehicleDistributionPPT.T2Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", _VehicleDistributionPPT.T2Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf _VehicleDistributionPPT.T2Value = "" And _VehicleDistributionPPT.T2Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", _VehicleDistributionPPT.T2Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If _VehicleDistributionPPT.TDecide = "T3" Then
            If _VehicleDistributionPPT.T3Value <> "" And _VehicleDistributionPPT.T3Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", _VehicleDistributionPPT.T3Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", _VehicleDistributionPPT.T3Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf _VehicleDistributionPPT.T3Value <> "" And _VehicleDistributionPPT.T3Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", _VehicleDistributionPPT.T3Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf _VehicleDistributionPPT.T3Value = "" And _VehicleDistributionPPT.T3Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", _VehicleDistributionPPT.T3Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If _VehicleDistributionPPT.TDecide = "T4" Then
            If _VehicleDistributionPPT.T4Value <> "" And _VehicleDistributionPPT.T4Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", _VehicleDistributionPPT.T4Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", _VehicleDistributionPPT.T4Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf _VehicleDistributionPPT.T4Value <> "" And _VehicleDistributionPPT.T4Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", _VehicleDistributionPPT.T4Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf _VehicleDistributionPPT.T4Value = "" And _VehicleDistributionPPT.T4Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", _VehicleDistributionPPT.T4Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", _VehicleDistributionPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        Return objdb.ExecQuery("[Vehicle].[VDTAnalysisSelect]", Parms)
    End Function

    Public Function VHNCategoryGet(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("Vehicle.[VDVHNCategoryGet]", Parms)
        Return ds
    End Function

    Public Function GetVHNo(ByVal _VehicleDistributionPPT As VehicleDistributionPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Parms(0) = New SqlParameter("@VHWSCode", GetDataValue(_VehicleDistributionPPT.VHWSCode))
        Parms(1) = New SqlParameter("@VHDescp", GetDataValue(_VehicleDistributionPPT.VHDesc))
        Parms(2) = New SqlParameter("@VHCategoryID", GetDataValue(_VehicleDistributionPPT.VHCategoryID))
        Parms(3) = New SqlParameter("@Type", GetDataValue(_VehicleDistributionPPT.Type))
        Parms(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(5) = New SqlParameter("@IsDirect", IsDirect)
        Parms(6) = New SqlParameter("@LogDate", _VehicleDistributionPPT.pdDistributionDT)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("Vehicle.[VDVehicleLookupGet]", Parms)
        Return ds
    End Function

#Region "Account Lookup"

    Public Function AcctlookupSearch(ByVal _VehicleDistributionPPT As VehicleDistributionPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        If _VehicleDistributionPPT.COACode <> "" And _VehicleDistributionPPT.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", _VehicleDistributionPPT.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", _VehicleDistributionPPT.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf _VehicleDistributionPPT.COACode <> "" And _VehicleDistributionPPT.COADescp = "" Then
            Parms(0) = New SqlParameter("@Accountcode", _VehicleDistributionPPT.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf _VehicleDistributionPPT.COACode = "" And _VehicleDistributionPPT.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", _VehicleDistributionPPT.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("Vehicle.[VDAcctCodeSelect]", Parms)
    End Function

    Public Function LoadCOAGrid(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dtCOA = objSQLHelp.ExecQuery("Vehicle.[VDCOALookUpGridFill]", Parms).Tables(0)
        'If dtCOA.Rows.Count <> 0 Then
        'End If
        Return dtCOA
    End Function

    Public Function LoadCOAGridByCOAID(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COACode", objCOAPPT.COACode)
        dtCOA = objSQLHelp.ExecQuery("Vehicle.[VDCOALookUpGridFillByCOAID]", Parms).Tables(0)
        'If dtCOA.Rows.Count <> 0 Then
        'End If
        Return dtCOA
    End Function

    Public Function SelectAllParentCOA(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dtCOA = objSQLHelp.ExecQuery("Vehicle.[VDAccountCOAParentDropDown]", Parms).Tables(0)
        'If dtCOA.Rows.Count <> 0 Then
        'End If
        Return dtCOA
    End Function

    Public Function SelectAllChildCOA(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ParentId", objCOAPPT.ParentId)
        dtCOA = objSQLHelp.ExecQuery("Vehicle.[VDAccountCOALookUpDropDown]", Parms).Tables(0)
        'If dtCOA.Rows.Count <> 0 Then
        'End If
        Return dtCOA
    End Function

    Public Function ParentIdGet(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COADescp", objCOAPPT.COADescp)
        dtCOA = objSQLHelp.ExecQuery("Vehicle.[COALookUpParentCOAIDGet]", Parms).Tables(0)
        Return dtCOA
    End Function

    Public Function ParentCodeGet(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COAID", objCOAPPT.COAID)
        dtCOA = objSQLHelp.ExecQuery("Vehicle.[VDCOALookUpParentCOACodeGet]", Parms).Tables(0)
        Return dtCOA
    End Function

    Public Function ChildCOAIDGet(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COADescp", objCOAPPT.COADescp)
        dtCOA = objSQLHelp.ExecQuery("Vehicle.[VDCOALookUpCOAIDGet]", Parms).Tables(0)
        Return dtCOA
    End Function

    Public Function ChildCOACodeGet(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COAID", objCOAPPT.COAID)
        dtCOA = objSQLHelp.ExecQuery("Vehicle.[VDCOALookUpCOACodeGet]", Parms).Tables(0)
        Return dtCOA
    End Function

    Public Function COALookUpGridFillByOLDCOACode(ByVal objCOAPPT As VehicleDistributionPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@OldCOACode", objCOAPPT.OldCOACode)
        dtCOA = objSQLHelp.ExecQuery("Vehicle.[VDCOALookUpGridFillByOLDCOACode]", Parms).Tables(0)
        'If dtCOA.Rows.Count <> 0 Then
        'End If
        Return dtCOA
    End Function

#End Region

#End Region

#Region "Save Method"

    Public Function SaveVehicleDistribution(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Integer
        'Dim ds As DataSet
        Dim Parms(19) As SqlParameter
        Dim objdb As New SQLHelp

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@DistributionDT", GetDataValue(_VehicleDistributionPPT.pdDistributionDT))
        Parms(3) = New SqlParameter("@VHID", GetDataValue(_VehicleDistributionPPT.psVHID))
        Parms(4) = New SqlParameter("@TotalRunningKmHours", GetDataValue(_VehicleDistributionPPT.pdTotalRunningKmHours))
        Parms(5) = New SqlParameter("@TotalKmHoursDistributed", GetDataValue(_VehicleDistributionPPT.pdTotalKmHoursDistributed))
        Parms(6) = New SqlParameter("@COAID", GetDataValue(_VehicleDistributionPPT.psCOAID))
        Parms(7) = New SqlParameter("@KmHours", GetDataValue(_VehicleDistributionPPT.pdKmHours))
        Parms(8) = New SqlParameter("@BalanceToDistribute", GetDataValue(_VehicleDistributionPPT.pdBalanceToDistribute))
        Parms(9) = New SqlParameter("@PrestasiTonBunchesKm", GetDataValue(_VehicleDistributionPPT.pdPrestasiTonBunchesKm))
        Parms(10) = New SqlParameter("@T0", GetDataValue(_VehicleDistributionPPT.psT0))
        Parms(11) = New SqlParameter("@T1", GetDataValue(_VehicleDistributionPPT.psT1))
        Parms(12) = New SqlParameter("@T2", GetDataValue(_VehicleDistributionPPT.psT2))
        Parms(13) = New SqlParameter("@T3", GetDataValue(_VehicleDistributionPPT.psT3))
        Parms(14) = New SqlParameter("@T4", GetDataValue(_VehicleDistributionPPT.psT4))
        Parms(15) = New SqlParameter("@DivID", GetDataValue(_VehicleDistributionPPT.psDivID))
        Parms(16) = New SqlParameter("@YOPID", GetDataValue(_VehicleDistributionPPT.psYOPID))
        Parms(17) = New SqlParameter("@BlockID", GetDataValue(_VehicleDistributionPPT.psBlockID))
        Parms(18) = New SqlParameter("@Remarks", GetDataValue(_VehicleDistributionPPT.psRemarks))
        Parms(19) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)

        Return objdb.ExecuteScalar("[Vehicle].[VehicleDistributionINSERT]", Parms)

    End Function

    Public Function UpdateVehicleDistribution(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Integer
        ''dbCommand = GetStoredProcCommand("[Vehicle].[VehicleDistributionUPDATE]")
        Dim Parms(20) As SqlParameter
        Dim objdb As New SQLHelp

        Parms(0) = New SqlParameter("@Id", GetDataValue(_VehicleDistributionPPT.piId))
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@DistributionDT", GetDataValue(_VehicleDistributionPPT.pdDistributionDT))
        Parms(4) = New SqlParameter("@VHID", GetDataValue(_VehicleDistributionPPT.psVHID))
        Parms(5) = New SqlParameter("@TotalRunningKmHours", GetDataValue(_VehicleDistributionPPT.pdTotalRunningKmHours))
        Parms(6) = New SqlParameter("@TotalKmHoursDistributed", GetDataValue(_VehicleDistributionPPT.pdTotalKmHoursDistributed))
        Parms(7) = New SqlParameter("@COAID", GetDataValue(_VehicleDistributionPPT.psCOAID))
        Parms(8) = New SqlParameter("@KmHours", GetDataValue(_VehicleDistributionPPT.pdKmHours))
        Parms(9) = New SqlParameter("@BalanceToDistribute", GetDataValue(_VehicleDistributionPPT.pdBalanceToDistribute))
        Parms(10) = New SqlParameter("@PrestasiTonBunchesKm", GetDataValue(_VehicleDistributionPPT.pdPrestasiTonBunchesKm))
        Parms(11) = New SqlParameter("@T0", GetDataValue(_VehicleDistributionPPT.psT0))
        Parms(12) = New SqlParameter("@T1", GetDataValue(_VehicleDistributionPPT.psT1))
        Parms(13) = New SqlParameter("@T2", GetDataValue(_VehicleDistributionPPT.psT2))
        Parms(14) = New SqlParameter("@T3", GetDataValue(_VehicleDistributionPPT.psT3))
        Parms(15) = New SqlParameter("@T4", GetDataValue(_VehicleDistributionPPT.psT4))
        Parms(16) = New SqlParameter("@DivID", GetDataValue(_VehicleDistributionPPT.psDivID))
        Parms(17) = New SqlParameter("@YOPID", GetDataValue(_VehicleDistributionPPT.psYOPID))
        Parms(18) = New SqlParameter("@BlockID", GetDataValue(_VehicleDistributionPPT.psBlockID))
        Parms(19) = New SqlParameter("@Remarks", GetDataValue(_VehicleDistributionPPT.psRemarks))
        Parms(20) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        'Parms(21) = New SqlParameter("@ConcurrencyId", GetDataValue(_VehicleDistributionPPT.pbConcurrencyId))

        Return objdb.ExecuteScalar("[Vehicle].[VehicleDistributionUPDATE]", Parms)

    End Function

#End Region

#Region "Delete Method"

    Public Function DeleteVehicleDistribution(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Integer
        Dim Parms(4) As SqlParameter
        Dim objdb As New SQLHelp

        ''dbCommand = GetStoredProcCommand("[Vehicle].[VehicleDistributionDELETE]")

        'Parms(0) = New SqlParameter("@Id", DbType.Int32, GetDataValue(_VehicleDistributionPPT.piId))
        Parms(0) = New SqlParameter("@VHDistributionID", GetDataValue(_VehicleDistributionPPT.psVHDistributionID))
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@DistributionDT", GetDataValue(_VehicleDistributionPPT.pdDistributionDT))
        Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Return objdb.ExecuteScalar("[Vehicle].[VehicleDistributionDELETE]", Parms)

    End Function

    Public Function DeleteVehicleDistributionFrmView(ByVal _VehicleDistributionPPT As VehicleDistributionPPT) As Integer
        Dim Parms(4) As SqlParameter
        Dim objdb As New SQLHelp

        ''dbCommand = GetStoredProcCommand("[Vehicle].[VehicleDistributionDELETE]")

        'Parms(0) = New SqlParameter("@Id", DbType.Int32, GetDataValue(_VehicleDistributionPPT.piId))
        Parms(0) = New SqlParameter("@VHID", GetDataValue(_VehicleDistributionPPT.psVHID))
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@DistributionDT", GetDataValue(_VehicleDistributionPPT.pdDistributionDT))
        Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Return objdb.ExecuteScalar("[Vehicle].[VehicleDistributionFrmViewDELETE]", Parms)

    End Function

#End Region

    Public Function GetDataValue(ByVal o As Object) As Object

        If o Is Nothing OrElse String.Empty.Equals(o) Then
            Return DBNull.Value
        Else
            Return o
        End If

    End Function

End Class
