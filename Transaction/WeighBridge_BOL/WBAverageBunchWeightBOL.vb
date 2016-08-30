Imports WeighBridge_DAL
Imports WeighBridge_PPT
Imports System.Data.SqlClient

Public Class WBAverageBunchWeightBOL
    Public Function WBAverageBunchWeightCalculate(ByVal NumberOfMonths As Integer) As DataSet
        Dim objWBAverageBunchWeightDAL As New WBAverageBunchWeightDAL
        Return objWBAverageBunchWeightDAL.WBAverageBunchWeightCalculate(NumberOfMonths)
    End Function

    Public Function WBAverageBunchWeightProcess(ByVal NumberOfMonths As Integer) As DataTable
        Dim objWBAverageBunchWeightDAL As New WBAverageBunchWeightDAL
        Return objWBAverageBunchWeightDAL.WBAverageBunchWeightProcess(NumberOfMonths)
    End Function

    Public Function WBAverageBunchWeightSelect(ByVal Year As Integer, ByVal Month As Integer) As DataTable
        Dim objWBAverageBunchWeightDAL As New WBAverageBunchWeightDAL

        Dim dt As DataTable = objWBAverageBunchWeightDAL.GetActiveMonthYearID(Year, Month)
        If dt.Rows.Count > 0 Then
            Return objWBAverageBunchWeightDAL.WBAverageBunchWeightSelect(dt.Rows(0)("ActiveMonthYearID").ToString())
        Else
            Return New DataTable()
        End If
    End Function
End Class
