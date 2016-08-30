Imports Accounts_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL
Public Class COALookupDAL

    Public Shared Function PsGETExpenditureAGByBlockStatus(ByVal BlockStatus As String) As String

        Select Case BlockStatus
            Case "Immature"
                PsGETExpenditureAGByBlockStatus = "Immature"
            Case "Nursery"
                PsGETExpenditureAGByBlockStatus = "Nursery"
            Case "Matured"
                PsGETExpenditureAGByBlockStatus = "Matured"
            Case "Replanting"
                PsGETExpenditureAGByBlockStatus = "Replanting"
            Case "MILL"
                PsGETExpenditureAGByBlockStatus = "MILL"
            Case "KCP"
                PsGETExpenditureAGByBlockStatus = "KCP"
            Case "CES"
                PsGETExpenditureAGByBlockStatus = "CES"
            Case "Operating"
                PsGETExpenditureAGByBlockStatus = "Operating"
            Case Else
                PsGETExpenditureAGByBlockStatus = String.Empty
        End Select

    End Function

    Public Shared Function LoadCOAGrid(ByVal objCOAPPT As COALookupPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim sExpenditureAG As String = String.Empty

        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter




        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ExpenditureAG", IIf(PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG) <> String.Empty, PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG), DBNull.Value))

        dtCOA = objSQLHelp.ExecQuery("[Accounts].[COALookUpGridFill]", Parms).Tables(0)
        'If dtCOA.Rows.Count <> 0 Then
        'End If
        Return dtCOA
    End Function
    Public Shared Function LoadCOAGridByCOAID(ByVal objCOAPPT As COALookupPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COACode", objCOAPPT.COACode)
        Parms(2) = New SqlParameter("@ExpenditureAG", IIf(PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG) <> String.Empty, PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG), DBNull.Value))
        dtCOA = objSQLHelp.ExecQuery("[Accounts].[COALookUpGridFillByCOAID]", Parms).Tables(0)
        'If dtCOA.Rows.Count <> 0 Then
        'End If
        Return dtCOA
    End Function
    Public Shared Function SelectAllParentCOA(ByVal objCOAPPT As COALookupPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ExpenditureAG", IIf(PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG) <> String.Empty, PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG), DBNull.Value))
        dtCOA = objSQLHelp.ExecQuery("[Accounts].[AccountCOAParentDropDown]", Parms).Tables(0)
        'If dtCOA.Rows.Count <> 0 Then
        'End If
        Return dtCOA
    End Function


    Public Shared Function SelectAllChildCOA(ByVal objCOAPPT As COALookupPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ParentId", objCOAPPT.ParentId)
        Parms(2) = New SqlParameter("@ExpenditureAG", IIf(PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG) <> String.Empty, PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG), DBNull.Value))
        dtCOA = objSQLHelp.ExecQuery("[Accounts].[AccountCOALookUpDropDown]", Parms).Tables(0)
        'If dtCOA.Rows.Count <> 0 Then
        'End If
        Return dtCOA
    End Function

    Public Shared Function ParentIdGet(ByVal objCOAPPT As COALookupPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COADescp", objCOAPPT.COADescp)
        Parms(2) = New SqlParameter("@ExpenditureAG", IIf(PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG) <> String.Empty, PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG), DBNull.Value))
        dtCOA = objSQLHelp.ExecQuery("[Accounts].[COALookUpParentCOAIDGet]", Parms).Tables(0)
        Return dtCOA
    End Function

    Public Shared Function ParentCodeGet(ByVal objCOAPPT As COALookupPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COAID", objCOAPPT.COAID)
        Parms(2) = New SqlParameter("@ExpenditureAG", IIf(PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG) <> String.Empty, PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG), DBNull.Value))
        dtCOA = objSQLHelp.ExecQuery("[Accounts].[COALookUpParentCOACodeGet]", Parms).Tables(0)
        Return dtCOA
    End Function

    Public Shared Function ChildCOAIDGet(ByVal objCOAPPT As COALookupPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COADescp", objCOAPPT.COADescp)
        Parms(2) = New SqlParameter("@ExpenditureAG", IIf(PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG) <> String.Empty, PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG), DBNull.Value))
        dtCOA = objSQLHelp.ExecQuery("[Accounts].[COALookUpCOAIDGet]", Parms).Tables(0)
        Return dtCOA
    End Function

    Public Shared Function ChildCOACodeGet(ByVal objCOAPPT As COALookupPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COAID", objCOAPPT.COAID)
        Parms(2) = New SqlParameter("@ExpenditureAG", IIf(PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG) <> String.Empty, PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG), DBNull.Value))
        dtCOA = objSQLHelp.ExecQuery("[Accounts].[COALookUpCOACodeGet]", Parms).Tables(0)
        Return dtCOA
    End Function

    Public Shared Function COALookUpGridFillByOLDCOACode(ByVal objCOAPPT As COALookupPPT) As DataTable
        Dim dtCOA As New DataTable()
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@OldCOACode", objCOAPPT.OldCOACode)
        Parms(2) = New SqlParameter("@ExpenditureAG", IIf(PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG) <> String.Empty, PsGETExpenditureAGByBlockStatus(objCOAPPT.ExpenditureAG), DBNull.Value))
        dtCOA = objSQLHelp.ExecQuery("[Accounts].[COALookUpGridFillByOLDCOACode]", Parms).Tables(0)
        'If dtCOA.Rows.Count <> 0 Then
        'End If
        Return dtCOA
    End Function

End Class
