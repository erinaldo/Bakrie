Imports WeighBridge_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class WBTicketNoConfigurationDAL

    Public Function WBTicketNoConfiguration_Select(ByVal objWBTNCPPT As WBTicketNoConfigurationPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Weighbridge].[WBTicketNoConfigurationSelect]", Parms).Tables(0)
        Return dt
    End Function


    Public Function WBTicketNoConfigurationID_isExist(ByVal objWBTNCPPT As WBTicketNoConfigurationPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@WBTicketNoConfigID", objWBTNCPPT.WBTicketNoConfigID)
        Parms(1) = New SqlParameter("@SerialNo", objWBTNCPPT.SerialNo)
        Parms(2) = New SqlParameter("@OtherSerialNo", objWBTNCPPT.OtherSerialNo)
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Weighbridge].[WBTicketNoConfigurationIsExist]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Save_WBTicketNoConfiguration(ByVal objWBTNCPPT As WBTicketNoConfigurationPPT) As DataTable
        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(7) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@SerialNo", objWBTNCPPT.SerialNo)
        Parms(3) = New SqlParameter("@OtherSerialNo", objWBTNCPPT.OtherSerialNo)
        Parms(4) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(5) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@ModifiedOn", Date.Today)

        dt = objdb.ExecQuery("[Weighbridge].[WBTicketNoConfigurationInsert]", Parms).Tables(0)
        Return dt
    End Function

    Public Function UpdateWBTicketNo_Password(ByVal objWBTNCPPT As WBTicketNoConfigurationPPT) As Integer
        Dim rowsaffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@Username", GlobalPPT.strUserName)
            Parms(1) = New SqlParameter("@Password", objWBTNCPPT.Password)
            rowsaffected = objdb.ExecNonQuery("[Weighbridge].[WBTicketNoConfigurationUpdate]", Parms)
            rowsaffected = 1
        Catch ex As Exception
            rowsaffected = 0
        End Try
        Return rowsaffected
    End Function
End Class
