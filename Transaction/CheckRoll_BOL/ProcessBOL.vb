'////////
'
'
' Programmer: Agung Batricorsila
' Created   : Kamis, 3 Sep 2009, 13:20
' Place     : Kuala Lumpur  
'
'Imports CheckRoll_PPT

Imports System.Data.SqlClient
Imports System.Configuration
'Imports Common_DAL
'Imports Common_PPT
Imports CheckRoll_DAL


Public Class ProcessBOL
    Public Shared Sub UpLoadSalary(ByVal SalaryProcDate As Date)
        ' by Dadang Adi
        ' Sabtu, 13 Mar 2010, 12:54
        'Dim dt As New DataTable
        ProcessDal.UpLoadSalary(SalaryProcDate)

    End Sub
   

    Public Shared Function InsertSalaryOT() As DataTable
        Dim dt As New DataTable
        dt = ProcessDal.InsertSalaryOT()
        Return dt
    End Function

    Public Shared Function ActivityDistributeExists() As DataTable
        Dim dt As New DataTable
        dt = ProcessDal.ActivityDistributeExists()
        Return dt
    End Function

    Public Shared Function AttendanceHarvNoReceiptionExists() As DataTable
        Dim dt As New DataTable
        dt = ProcessDal.AttendanceHarvNoReceiptionExists()
        Return dt
    End Function

    Public Shared Function InsertSalaryPremi() As Integer
        ' by Dadang Adi H
        ' Sabtu, 20 Mar 2010, 14:47
        Dim Hasil As Integer
        Hasil = ProcessDal.InsertSalaryPremi()
        Return Hasil
    End Function

    Public Shared Function UpdateTotalBrutoAndDeduction() As Integer
        ' By Palani
        ' 12 Feb 2010
        ProcessDal.UpdateTotalBrutoAndDeduction()
    End Function


    Public Shared Sub InsertAllDedSalary(ByVal StartDate As Date, ByVal Enddates As Date)
        '  Dim dt As New DataTable
        ProcessDal.InsertAllDedSalary(StartDate, Enddates)
    End Sub

    Public Shared Sub InsertSalaryAdvance()

        ProcessDal.InsertSalaryAdvance()

    End Sub

    Public Shared Function InsertSalaryIncentive() As DataTable
        Dim dt As New DataTable
        dt = ProcessDal.InsertSalaryIncentive()
        Return dt
    End Function
    Public Shared Function InsertSalaryUpdate() As DataTable
        Dim dt As New DataTable
        dt = ProcessDal.InsertSalaryUpdate()
        Return dt
    End Function

    Public Shared Function KTSalary() As DataTable
        Dim dt As DataTable
        dt = ProcessDal.KTSalary()
        Return dt
    End Function

    Public Function GetInterfaceYearPPH21CR(ByVal IntYear As Integer) As DataSet
        Dim objReportDAL As New ProcessDal
        Return objReportDAL.GetInterfaceYearPPH21CR(IntYear)
    End Function
    'stanley@15-12-2011
    Public Function GetInterfaceYearPPH21CR_SPT(ByVal IntYear As Integer) As DataSet
        Dim objReportDAL As New ProcessDal
        Return objReportDAL.GetInterfaceYearPPH21CR_SPT(IntYear)
    End Function

    Public Function GetSPTForYear(ByVal IntYear As Integer) As DataSet
        Dim objReportDAL As New ProcessDal
        Return objReportDAL.GetSPTForYear(IntYear)
    End Function

    Public Function GetActiveMonthYear() As DataSet
        Dim objReportDAL As New ProcessDal
        Return objReportDAL.GetActiveMonthYear()
    End Function

    Public Function GetSPTSeqNo(ByVal IntYear As Integer, ByVal EmpId As String) As DataSet
        Dim objReportDAL As New ProcessDal
        Return objReportDAL.GetSPTSeqNo(IntYear, EmpId)
    End Function

    Public Function GetInterfaceYearDistribusiCR() As DataSet
        Dim objReportDAL As New ProcessDal
        Return objReportDAL.GetInterfaceYearDistribusiCR()
    End Function

    Public Shared Sub ProcessOtherPayment()
        ProcessDal.ProcessOtherPayment()
    End Sub
    Public Shared Sub OnCostProcess()
        ProcessDal.OnCostProcess()
    End Sub
    Public Shared Sub OnCostProcessDet()
        ProcessDal.OnCostProcessDet()
    End Sub
    Public Shared Sub AnalyHarvestingCostInsert()
        ProcessDal.AnalyHarvestingCostInsert()
    End Sub

    Public Shared Sub AnalyRubberCostInsert()
        ProcessDal.AnalyRubberCostInsert()
    End Sub
    Public Shared Sub AttendSummaryWithTeamProcess()
        'by Stanley 24-06-2011
        ProcessDal.AttendSummaryWithTeamProcess()
    End Sub

    Public Shared Sub PremiMonthEndProcess()
        ProcessDal.PremiMonthEndProcess()
    End Sub

    Public Shared Sub CheckrollJournalInsert()
        ProcessDal.CheckrollJournalInsert()
    End Sub

    Public Shared Sub SPT21Insert(ByVal IntYear As Integer, ByVal Empid As String, ByVal SeqNo As Integer)
        ProcessDal.SPT21Insert(IntYear, Empid, SeqNo)
    End Sub

    Public Shared Sub SPT21Delete(ByVal IntYear As Integer)
        ProcessDal.SPT21Delete(IntYear)
    End Sub

    Public Shared Sub WeighbridgeAllocatedWeightUpdate()
        ProcessDal.WeighbridgeAllocatedWeightUpdate()
    End Sub

    Public Shared Sub ProcessRiceValue()
        ProcessDal.ProcessRiceValue()
    End Sub

    Public Shared Sub TransferSalaryToAllowance()
        ProcessDal.TransferSalaryToAllowance()
    End Sub

    Public Shared Sub CalculatePremiGudang()
        ProcessDal.CalculatePremiGudang()
    End Sub

    Public Shared Sub TransferCheckrollToVehicleCharge()
        ProcessDal.TransferCheckrollToVehicleCharge()
    End Sub
End Class
