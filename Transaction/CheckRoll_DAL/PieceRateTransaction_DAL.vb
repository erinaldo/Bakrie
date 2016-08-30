Imports CheckRoll_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class PieceRateTransaction_DAL

    Public Function PieceRate_Select(ByVal _ReferenceNo As String) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter
        If _ReferenceNo = Nothing Then
            Parms(0) = New SqlParameter("@ReferenceNo", DBNull.Value)
        Else
            Parms(0) = New SqlParameter("@ReferenceNo", _ReferenceNo)
        End If
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        dt = objdb.ExecQuery("[Checkroll].[PieceRateSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function PieceRateActivity_Select(ByVal objPieceRateActivity As PieceRateActivity_PPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        If Not objPieceRateActivity.Id = Nothing Then
            Parms(1) = New SqlParameter("@Id", objPieceRateActivity.Id)
            Parms(2) = New SqlParameter("@ActivityDate", DBNull.Value)
        ElseIf Not objPieceRateActivity.ReferenceNo = Nothing Then
            Parms(1) = New SqlParameter("@ReferenceNo", objPieceRateActivity.ReferenceNo)
            Parms(2) = New SqlParameter("@ActivityDate", DBNull.Value)
        Else
            Parms(1) = New SqlParameter("@Description", objPieceRateActivity.Description)
            Parms(2) = New SqlParameter("@ActivityDate", objPieceRateActivity.StartDate)
        End If

        dt = objdb.ExecQuery("[Checkroll].[PieceRateActivitySelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function PieceRateContractor_Select(ByVal ActivityId As Integer) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Id", ActivityId)

        dt = objdb.ExecQuery("[Checkroll].[PieceRateContractorSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function PieceRateEmployee_Select(ByVal ActivityId As Integer) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Id", ActivityId)

        dt = objdb.ExecQuery("[Checkroll].[PieceRateEmployeeSelect]", Parms).Tables(0)
        Return dt
    End Function


    Public Function PieceRateTransaction_Select(ByVal Id As Integer, ByRef PieceRateActivityId As Integer) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter

        If Not Id = Nothing Then
            Parms(0) = New SqlParameter("@Id", Id)
        Else
            Parms(0) = New SqlParameter("@PieceRateActivityId", PieceRateActivityId)
        End If

        dt = objdb.ExecQuery("[Checkroll].[PieceRateTransactionSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function PieceRateTransaction_Update(ByVal objPRT As PieceRateTransaction_PPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter

        If objPRT.Id = Nothing Then
            Parms(0) = New SqlParameter("@Id", DBNull.Value)
        Else
            Parms(0) = New SqlParameter("@Id", objPRT.Id)
        End If
        Parms(1) = New SqlParameter("@PieceRateActivityId", objPRT.PieceRateActivityId)
        Parms(2) = New SqlParameter("@Date", objPRT.ActivityDate)

        If objPRT.VHID = "0" Then
            Parms(3) = New SqlParameter("@VHID", DBNull.Value)
        Else
            Parms(3) = New SqlParameter("@VHID", objPRT.VHID)
        End If

        Parms(4) = New SqlParameter("@SubStationID", objPRT.SubStationID)
        Parms(5) = New SqlParameter("@UnitCompleted", objPRT.UnitCompleted)
        Parms(6) = New SqlParameter("@Remarks", objPRT.Remarks)
        If objPRT.EmpID = Nothing Then
            Parms(7) = New SqlParameter("@EmpID", DBNull.Value)
        Else
            Parms(7) = New SqlParameter("@EmpID", objPRT.EmpID)
        End If

        If objPRT.ContractID = Nothing Then
            Parms(8) = New SqlParameter("@ContractID", DBNull.Value)
        Else
            Parms(8) = New SqlParameter("@ContractID", objPRT.ContractID)
        End If
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@Production", objPRT.Production)

        Return objdb.ExecNonQuery("[Checkroll].[PieceRateTransactionUpdate]", Parms)
    End Function

    Public Function PieceRateTransaction_Delete(ByVal Id As Integer) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter

        Parms(0) = New SqlParameter("@Id", Id)

        Return objdb.ExecNonQuery("[Checkroll].[PieceRateTransactionDelete]", Parms)
    End Function

End Class
