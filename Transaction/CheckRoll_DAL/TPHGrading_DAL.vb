Imports Common_DAL
Imports System.Data.SqlClient
Imports CheckRoll_PPT
Imports Common_PPT

Public Class TPHGrading_DAL

    Public Shared Function GetDivisions(ByVal strEstate As String) As DataTable
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@Div", DBNull.Value)
        Parms(1) = New SqlParameter("@DivName", DBNull.Value)
        Parms(2) = New SqlParameter("@EstateID", strEstate)

        Return objSQLHelp.ExecQuery("[General].[DivisionSelect]", Parms).Tables(0)
    End Function

    Public Shared Function GetBlocks(ByVal strEstate As String, ByVal DivisionID As String) As DataTable
        Dim objSQLHelp As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@BlockID", DBNull.Value)
        Parms(1) = New SqlParameter("@EstateID", strEstate)
        Parms(2) = New SqlParameter("@BlockName", DBNull.Value)
        Parms(3) = New SqlParameter("@YOP", DBNull.Value)
        Parms(4) = New SqlParameter("@DivID", DivisionID)

        Return objSQLHelp.ExecQuery("[General].[BlockMasterSelect]", Parms).Tables(0)
    End Function

    Public Shared Function GetTPH(ByVal strEstate As String, ByVal BlockID As String) As DataTable
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", strEstate)
        Parms(1) = New SqlParameter("@BlockID", BlockID)

        Return objSQLHelp.ExecQuery("[General].[TPHMasterSelect]", Parms).Tables(0)
    End Function

    Public Shared Function TPHGradingSelect(ByVal strEstate As String, ByVal TPHGradingID As String) As DataTable
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", strEstate)
        Parms(1) = New SqlParameter("@TPHGradingID", TPHGradingID)

        Return objSQLHelp.ExecQuery("[Checkroll].[TPHGradingSelect]", Parms).Tables(0)
    End Function

    Public Shared Function TPHGradingDetailSelect(ByVal TPHGradingID As String) As DataTable
        Dim objSQLHelp As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@TPHGradingID", TPHGradingID)

        Return objSQLHelp.ExecQuery("[Checkroll].[TPHGradingDetailSelect]", Parms).Tables(0)
    End Function

    Public Shared Function TPHGradingSelect() As DataTable
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objSQLHelp.ExecQuery("[Checkroll].[TPHGradingSelect]", Parms).Tables(0)

    End Function

    Public Shared Function GetEmployeeName(ByVal EmpCode As String) As String
        Dim objSQLHelp As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EmpCode", EmpCode)

        Dim dt As DataTable = objSQLHelp.ExecQuery("[Checkroll].[GetEmployeeName]", Parms).Tables(0)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("EmpName").ToString()
        End If

        Return ""
    End Function

    Public Shared Function TPHGradingCheckExist(ByVal ReceptionDate As Date, ByVal TPH As String) As Boolean
        Dim objSQLHelp As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@TPHID", TPH)
        Parms(3) = New SqlParameter("@DocumentDate", ReceptionDate.ToString("yyyy-MM-dd"))

        If objSQLHelp.ExecQuery("[Checkroll].[TPHGradingCheckExist]", Parms).Tables(0).Rows(0)("Exist") = "1" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function TPHGradingDocumentNoExist(ByVal DocumentNo As String) As Boolean
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@DocumentNo", DocumentNo)

        If objSQLHelp.ExecQuery("[Checkroll].[TPHGradingDocumentNoExist]", Parms).Tables(0).Rows(0)("Exist") = "1" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function TPHGradingDetailSave(ByVal objTPHGrading_PPT As TPHGrading_PPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@TPHID", objTPHGrading_PPT.TPHID)
        Parms(1) = New SqlParameter("@DRC", objTPHGrading_PPT.DRC)
        Return objdb.ExecQuery("[Checkroll].[TPHGradingDetailSave]", Parms)
    End Function

    Public Shared Function TPHGradingSave(ByVal objTPHGrading_PPT As TPHGrading_PPT) As String
        Dim objdb As New SQLHelp
        Dim Parms(21) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@DocumentSerial", objTPHGrading_PPT.DocumentSerial)
        Parms(3) = New SqlParameter("@DocumentDate", objTPHGrading_PPT.DocumentDate.ToString("yyyy-MM-dd"))
        Parms(4) = New SqlParameter("@DivID", objTPHGrading_PPT.DivID)
        Parms(5) = New SqlParameter("@AskepAssistant", objTPHGrading_PPT.AskepAssistant)
        Parms(6) = New SqlParameter("@BlockID", objTPHGrading_PPT.BlockID)
        Parms(7) = New SqlParameter("@TPHID", objTPHGrading_PPT.TPHID)

        Parms(8) = New SqlParameter("@Mentah", objTPHGrading_PPT.Mentah)
        Parms(9) = New SqlParameter("@KurangMatang", objTPHGrading_PPT.KurangMatang)
        Parms(10) = New SqlParameter("@Matang", objTPHGrading_PPT.Matang)
        Parms(11) = New SqlParameter("@TerlaluMatang", objTPHGrading_PPT.TerlaluMatang)
        Parms(12) = New SqlParameter("@BuahBusuk", objTPHGrading_PPT.BuahBusuk)
        Parms(13) = New SqlParameter("@TotalBunches", objTPHGrading_PPT.TotalBunches)
        Parms(14) = New SqlParameter("@Brondolan", objTPHGrading_PPT.Brondolan)
        Parms(15) = New SqlParameter("@LongStalk", objTPHGrading_PPT.LongStalk)
        Parms(16) = New SqlParameter("@NonVCutStalks", objTPHGrading_PPT.NonVCutStalks)
        Parms(17) = New SqlParameter("@CalculatedTotalBunches", objTPHGrading_PPT.CalculatedTotalBunches)

        Parms(18) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        
        Parms(20) = New SqlParameter("@TPHGradingID", objTPHGrading_PPT.TPHGradingID)
        Parms(21) = New SqlParameter("@DRC", objTPHGrading_PPT.DRC)
        Return objdb.ExecQuery("[Checkroll].[TPHGradingSave]", Parms).Tables(0).Rows(0)("TPHGradingID")
    End Function


    Public Shared Function TPHGradingDelete(ByVal TPHGradingID As String) As String
        Dim objSQLHelp As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@TPHGradingID", TPHGradingID)

        Dim dt As DataTable = objSQLHelp.ExecQuery("[Checkroll].[TPHGradingDelete]", Parms).Tables(0)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)("Deleted").ToString()
        End If

        Return ""
    End Function

    Public Shared Function TPHGradingSelectByDate(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@FromDate", FromDate.ToString("yyyy-MM-dd"))
        Parms(2) = New SqlParameter("@ToDate", ToDate.ToString("yyyy-MM-dd"))

        Return objSQLHelp.ExecQuery("[Checkroll].[TPHGradingSelectByDate]", Parms).Tables(0)
    End Function

End Class
