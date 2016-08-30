Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class DetailPremiProcess

    Dim bw As BackgroundWorker = New BackgroundWorker

    Private Sub DetailPremiProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SQL Server Information
        Dim ConStr As String = Common_PPT.GlobalPPT.ConnectionString
        Dim SQLConn As SqlConnection
        SQLConn = New SqlConnection(ConStr)
        SQLConn.Open()

        Dim query As String = "SELECT FromDT, ToDT FROM General.FiscalYear WHERE FYear = " & Common_PPT.GlobalPPT.intActiveYear.ToString() & " AND Period = " + Common_PPT.GlobalPPT.IntActiveMonth.ToString()
        Dim cmd As New SqlCommand(query, SQLConn)
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        If dr.Read() Then
            dpFrom.Value = Convert.ToDateTime(dr("FromDT"))
            dpTo.Value = Convert.ToDateTime(dr("ToDT"))

        End If

        dr.Close()
        SQLConn.Close()

        ' background worker -----------------------------
        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If bw.WorkerSupportsCancellation = True Then
            bw.CancelAsync()
            Me.Close()
        End If
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        'PremiProcess()
        If Not bw.IsBusy = True Then
            bw.RunWorkerAsync()
        End If
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        ProgressBar1.Value = 0
        PremiProcess(worker, e, dpFrom.Value, dpTo.Value)
    End Sub

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        lblProgress.Text = "Processing " + e.ProgressPercentage.ToString() + "%"
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Cancelled = True Then
            lblProgress.Text = "Canceled!"
        ElseIf e.Error IsNot Nothing Then
            lblProgress.Text = "Error: " & e.Error.Message
        Else
            lblProgress.Text = "Done!"
        End If
    End Sub



    Sub PremiProcess(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs, ByVal fromDT As DateTime, ByVal toDT As DateTime)

        Dim ActiveMonthYearID As String = Common_PPT.GlobalPPT.strActMthYearID
        Dim EstateID As String = Common_PPT.GlobalPPT.strEstateID
        Dim EstateCode As String = Common_PPT.GlobalPPT.strEstateCode
        Dim CreatedBy As String = Common_PPT.GlobalPPT.strUserName

        Dim ConStr As String = Common_PPT.GlobalPPT.ConnectionString

        Dim queryEMP As String = "select Empid from Checkroll.CREmployee where EstateID = '" & EstateID & _
            "' AND  (Status='Active'  or (StatusDate >= '" & fromDT.ToString("yyyy-MM-dd") & "'  and StatusDate <= '" & toDT.ToString("yyyy-MM-dd") & "'))"

        Dim SQLConnEmp As SqlConnection = New SqlConnection(ConStr)
        SQLConnEmp.Open()

        Dim cmdEmp As New SqlCommand(queryEMP, SQLConnEmp)


        Dim dt As New DataTable
        dt.Load(cmdEmp.ExecuteReader)

        Dim drEmp As DataTableReader = New DataTableReader(dt)

        Dim currentDay As DateTime = fromDT
        Dim i As Int32 = 0
        Dim total As Int32 = dt.Rows.Count

        While drEmp.Read()
            If bw.CancellationPending = True Then
                e.Cancel = True
                Exit While
            Else

                'lblProgress.Text = "Employee Number : " + i.ToString()
                bw.ReportProgress((i / total) * 100)

                Do While (toDT > currentDay)
                    CheckRoll_DAL.DailyReceiptionWithTeam_DAL.DailyReceptionBlkHKPremiValueUpdateProcess(drEmp("Empid"), currentDay)
                    currentDay = currentDay.AddDays(1)
                Loop

                'reset for the next employee
                currentDay = fromDT
                i = i + 1
            End If
        End While



    End Sub

    
End Class