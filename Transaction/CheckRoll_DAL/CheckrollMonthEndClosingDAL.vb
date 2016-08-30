'///////////////////////////////////////
' 
' By Dadang Adi Hendradi
' Created: Kamis, 31 Dec 2009, 11:35
' Place  : Kuala Lumpur
'
'////////////////////////////////////////

Imports System.Data.SqlClient

Imports Common_DAL
Imports Common_PPT
Imports System.Windows.Forms

Public Class CheckrollMonthEndClosingDAL


    Public Shared Function TaskMonitorUpdateMonthlyProcessing(ByVal Completed As String) As Integer
        Dim retValue As Integer
        Dim adapter As New SQLHelp
        Dim params(7) As SqlParameter
        '
        ' Rabu, 06 Jan 2010, 15:34
        ' ActimonthYearID ganti jadi @AMonth and @AYear

        ' Senin, 11 Jan 2010, 17:32
        ' Dharsini bilang CreatedOn and CreatedBy dihilangkan
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        params(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        params(3) = New SqlParameter("@ModID", 1)
        params(4) = New SqlParameter("@Task", "Checkroll monthly Processing")
        params(5) = New SqlParameter("@Complete", Completed)
        params(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        params(7) = New SqlParameter("@ModifiedOn", Now())

        Try
            retValue = adapter.ExecNonQuery("[General].[TaskMonitorUPDATE]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return retValue
    End Function

    Public Shared Function TaskMonitorUpdateMonthEndClosing(ByVal Completed As String) As Integer
        Dim retValue As Integer
        Dim adapter As New SQLHelp
        Dim params(7) As SqlParameter

        ' Rabu, 06 Jan 2010, 15:34
        ' ActimonthYearID ganti jadi @AMonth and @AYear

        ' Senin, 11 Jan 2010, 17:32
        ' Dharsini bilang CreatedOn and CreatedBy dihilangkan
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        params(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        params(3) = New SqlParameter("@ModID", 1)
        params(4) = New SqlParameter("@Task", "Checkroll month end closing")
        params(5) = New SqlParameter("@Complete", Completed)
        params(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        params(7) = New SqlParameter("@ModifiedOn", Now())

        Try
            retValue = adapter.ExecNonQuery("[General].[TaskMonitorUPDATE]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return retValue
    End Function

    Public Shared Function CRUpdateActiveMonthYear() As Integer
        ' By Dadang Adi
        ' Kamis, 31 Dec 2009, 23:41
        ' This will update General.ActiveMonth table 
        ' with [status] field value current month = 'B', dan next month = 'A'

        Dim retValue As Integer
        Dim adapter As New SQLHelp
        Dim params(3) As SqlParameter


        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@ModID", 1)
        params(3) = New SqlParameter("@User", GlobalPPT.strUserName)

        Try
            retValue = adapter.ExecNonQuery("[Checkroll].[CRUpdateActiveMonthYear]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return retValue
    End Function

    Public Shared Function TaskMonitorInsert() As Integer
        ' Jum'at, 01 Jan 2010, 14:00
        Dim retValue As Integer
        Dim adapter As New SQLHelp
        Dim params(7) As SqlParameter

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        params(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        params(3) = New SqlParameter("@ModID", 1)
        params(4) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        params(5) = New SqlParameter("@CreatedOn", Now())
        params(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        params(7) = New SqlParameter("@ModifiedOn", Now())

        Try
            retValue = adapter.ExecNonQuery("[General].[TaskMonitorINSERT]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return retValue
    End Function

    Public Shared Function CRTaskMonitorGETCompleted() As String
        ' By Dadang Adi H
        ' Jum'at, 01 Jan 2010, 21:50
        ' Rabu, 06 Jan 2010, 16:38
        '   -> Sekarang pake [General].[TaskMonitorGet]
        Dim adapter As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As DataTable = Nothing
        Dim retValue As String = Nothing '-> Complete = Y berarti sudah diproceess

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ModID", 1)

        Try
            dt = adapter.ExecQuery("[General].[TaskMonitorGet]", params).Tables(0)

            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then

                    If dt.Rows(0).Item("TASK").ToString() = "Checkroll monthly Processing" Then
                        If Not dt.Rows(0).IsNull("Complete") Then
                            retValue = dt.Rows(0).Item("Complete").ToString()
                        End If

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Return retValue
        'Return CRTaskMonitorGET("Checkroll monthly Processing")
    End Function

    Public Shared Function CRTaskMonitorGET() As DataTable
        ' By Dadang Adi H
        ' Kamis, 07 Jan 2009, 13:32

        Dim adapter As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As DataTable = Nothing

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ModID", 1)

        Try
            dt = adapter.ExecQuery("[General].[TaskMonitorGet]", params).Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function

    Public Shared Function CRGetActiveMonthYearIDFromLogin() As DataTable
        ' By Dadang Adi H
        ' Senin, 01 Feb 2010, 03:04

        Dim adapter As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As DataTable = Nothing

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@AMonth", GlobalPPT.IntLoginMonth)
        params(2) = New SqlParameter("@AYear", GlobalPPT.intLoginYear)

        Try
            dt = adapter.ExecQuery("[Checkroll].[CRGetActiveMonthYearID]", params).Tables(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function

    Public Shared Function CheckSPTGenerated() As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("Year", GlobalPPT.intLoginYear)
        ds = objdb.ExecQuery("[Checkroll].[CheckSPTGenerated]", Parms)
        Return ds
    End Function
End Class
