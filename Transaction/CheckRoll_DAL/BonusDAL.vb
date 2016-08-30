
' By Dadang Adi H
' Created : Senin, 28 Dec 2009, 13:06
'
'
Imports System.Data
Imports System.Data.SqlClient

Imports Common_DAL
Imports Common_PPT
Imports System.Windows.Forms

Public Class BonusDAL
    Public Shared Sub CRBonusInsert(ByVal ProcDate As Date, ByVal noofmonths As Double, ByVal DSPSI As Double, ByVal DSPSB As Double, ByVal TunjanganBeras As Double, _
                                    ByVal OverwriteSalaryMonth As Integer, ByVal OverwriteSalaryYear As Integer)
        Dim params(9) As SqlClient.SqlParameter
        Dim adapter As New SQLHelp()

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ProcDate", ProcDate)
        params(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
        params(4) = New SqlParameter("@NoofMonths", noofmonths)
        params(5) = New SqlParameter("@DedSPSI", DSPSI)
        params(6) = New SqlParameter("@DedSBSP", DSPSB)
        params(7) = New SqlParameter("@BerasNaturaPrice", TunjanganBeras)
        params(8) = New SqlParameter("@OverwriteSalaryMonth", OverwriteSalaryMonth)
        params(9) = New SqlParameter("@OverwriteSalaryYear", OverwriteSalaryYear)
        Try
            adapter.ExecNonQuery("[Checkroll].[CRBonusInsert]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Shared Function BonusGet(ByVal YearPeriod As Integer, ByRef processingDate As Date) As Boolean
        ' Selasa, 09 Mar 2010, 19:01
        ' Rabu, 10 Mar 2010, 11:17 -> add Processing Date
        Dim params(3) As SqlClient.SqlParameter
        Dim adapter As New SQLHelp()
        Dim result As Boolean = False

        'Dim a As Nullable(Of Date)

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@YearPeriod", YearPeriod)
        params(2) = New SqlParameter("@ProcessingDate", SqlDbType.Date)
        params(2).Direction = ParameterDirection.Output

        params(3) = New SqlParameter("@Hasil", SqlDbType.Bit)
        params(3).Direction = ParameterDirection.Output

        Try
            adapter.ExecNonQuery("[Checkroll].[CRTHRGet]", params)
            If Not params(2).Value Is System.DBNull.Value Then
                processingDate = params(2).Value
            End If

            result = params(3).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return result
    End Function

    'Saves bonus based on a previous month already generated bonus entry
    Public Shared Sub CRBonusInsertOtherMonth(ByVal ProcDate As Date, ByVal Zmonth As Integer, ByVal ZYear As Integer)
        Dim params(5) As SqlClient.SqlParameter
        Dim adapter As New SQLHelp()

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@ProcDate", ProcDate)
        params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
        params(4) = New SqlParameter("@ZMonth", Zmonth)
        params(5) = New SqlParameter("@ZYear", ZYear)

        Try
            adapter.ExecNonQuery("[Checkroll].[CRBonusInsertOther]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
