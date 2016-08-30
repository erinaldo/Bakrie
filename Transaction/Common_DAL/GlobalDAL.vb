Imports Common_PPT
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class GlobalDAL
    Dim objGlobalPPT As GlobalPPT
#Region "Common Functions"
    Public Function getAuthentication(ByVal menuID As String, ByVal type_ As Integer) As Boolean
        'type_ =  1 for add 
        'type_ =  2 for edit
        'type_ =  3 for delete
        'If objGlobalPPT.strDesgLevel = 101 Or objGlobalPPT.strDesgLevel = 102 Then
        '    Return True
        'Else
        '    For i = 0 To objGlobalPPT.commonRoleAll.Length - 1
        '        With objGlobalPPT.commonRoleAll(i)
        '            If .MenuID = menuID And .DesgID = objGlobalPPT.strDesgID Then
        '                If type_ = 1 Then
        '                    Return .PrAdd
        '                ElseIf type_ = 2 Then
        '                    Return .PrUpdate
        '                ElseIf type_ = 3 Then
        '                    Return .PrDelete
        '                End If
        '            End If
        '        End With
        '    Next
        'End If
        Return False
    End Function

    Public Shared Function PMonthName(ByVal IntMonth As Integer, ByVal IntYear As Integer, ByVal asLanguage As String) As String
        Dim sMonthName As String = ""

        Select Case IntMonth
            Case 1
                If asLanguage = "ms" Then
                    sMonthName = "JAN" & "-" & IntYear.ToString
                Else
                    sMonthName = "JAN" & "-" & IntYear.ToString
                End If
            Case 2
                If asLanguage = "ms" Then
                    sMonthName = "FEB" & "-" & IntYear.ToString
                Else
                    sMonthName = "FEB" & "-" & IntYear.ToString
                End If

            Case 3
                If asLanguage = "ms" Then
                    sMonthName = "MAC" & "-" & IntYear.ToString
                Else
                    sMonthName = "MAR" & "-" & IntYear.ToString
                End If
            Case 4
                If asLanguage = "ms" Then
                    sMonthName = "APR" & "-" & IntYear.ToString
                Else
                    sMonthName = "APR" & "-" & IntYear.ToString
                End If
            Case 5
                If asLanguage = "ms" Then
                    sMonthName = "MEI " & "-" & IntYear.ToString
                Else
                    sMonthName = "MAY" & "-" & IntYear.ToString
                End If

            Case 6
                If asLanguage = "ms" Then
                    sMonthName = "JUN" & "-" & IntYear.ToString
                Else
                    sMonthName = "JUN" & "-" & IntYear.ToString
                End If
            Case 7
                If asLanguage = "ms" Then
                    sMonthName = "JUL" & "-" & IntYear.ToString
                Else
                    sMonthName = "JUL" & "-" & IntYear.ToString
                End If
            Case 8
                If asLanguage = "ms" Then
                    sMonthName = "OGS" & "-" & IntYear.ToString
                Else
                    sMonthName = "AUG" & "-" & IntYear.ToString
                End If
            Case 9
                If asLanguage = "ms" Then
                    sMonthName = "SEP" & "-" & IntYear.ToString
                Else
                    sMonthName = "SEP" & "-" & IntYear.ToString
                End If
            Case 10
                If asLanguage = "ms" Then
                    sMonthName = "OKT" & "-" & IntYear.ToString
                Else
                    sMonthName = "OCT" & "-" & IntYear.ToString
                End If
            Case 11
                If asLanguage = "ms" Then
                    sMonthName = "NOV" & "-" & IntYear.ToString
                Else
                    sMonthName = "NOV" & "-" & IntYear.ToString
                End If
            Case 12
                If asLanguage = "ms" Then
                    sMonthName = "DIS" & "-" & IntYear.ToString
                Else
                    sMonthName = "DEC" & "-" & IntYear.ToString
                End If

        End Select

        Return sMonthName
    End Function

    Public Shared Function PFullMonthYearName(ByVal IntMonth As Integer, ByVal IntYear As Integer, ByVal asLanguage As String) As String
        Dim sMonthYearName As String = ""

        Select Case IntMonth
            Case 1
                If asLanguage = "ms" Then
                    sMonthYearName = "Januari '" & -IntYear.ToString
                Else
                    sMonthYearName = "January '" & -IntYear.ToString
                End If
            Case 2
                If asLanguage = "ms" Then
                    sMonthYearName = "Februari '" & -IntYear.ToString
                Else
                    sMonthYearName = "February '" & -IntYear.ToString
                End If

            Case 3
                If asLanguage = "ms" Then
                    sMonthYearName = "Mac '" & -IntYear.ToString
                Else
                    sMonthYearName = "March '" & -IntYear.ToString
                End If
            Case 4
                If asLanguage = "ms" Then
                    sMonthYearName = "April '" & -IntYear.ToString
                Else
                    sMonthYearName = "April '" & -IntYear.ToString
                End If
            Case 5
                If asLanguage = "ms" Then
                    sMonthYearName = "Mei '" & IntYear.ToString
                Else
                    sMonthYearName = "May '" & IntYear.ToString
                End If

            Case 6
                If asLanguage = "ms" Then
                    sMonthYearName = "Jun '" & IntYear.ToString
                Else
                    sMonthYearName = "June '" & IntYear.ToString
                End If
            Case 7
                If asLanguage = "ms" Then
                    sMonthYearName = "Julai '" & IntYear.ToString
                Else
                    sMonthYearName = "July '" & IntYear.ToString
                End If
            Case 8
                If asLanguage = "ms" Then
                    sMonthYearName = "Ogos '" & IntYear.ToString
                Else
                    sMonthYearName = "August '" & IntYear.ToString
                End If
            Case 9
                If asLanguage = "ms" Then
                    sMonthYearName = "September '" & IntYear.ToString
                Else
                    sMonthYearName = "September '" & IntYear.ToString
                End If
            Case 10
                If asLanguage = "ms" Then
                    sMonthYearName = "Oktober '" & IntYear.ToString
                Else
                    sMonthYearName = "October '" & IntYear.ToString
                End If
            Case 11
                If asLanguage = "ms" Then
                    sMonthYearName = "November '" & "-" & IntYear.ToString
                Else
                    sMonthYearName = "November '" & "-" & IntYear.ToString
                End If
            Case 12
                If asLanguage = "ms" Then
                    sMonthYearName = "Disember '" & -IntYear.ToString
                Else
                    sMonthYearName = "December '" & -IntYear.ToString
                End If

        End Select

        Return sMonthYearName
    End Function

    Public Function DatetoStringDDMMYYYY(ByVal Date_ As DateTime) As String
        Dim strDate_ As String
        strDate_ = Date_.Day.ToString + "/" + Date_.Month.ToString + "/" + Date_.Year.ToString
        Return strDate_
    End Function



    Public Shared Sub SetDateTimePickerSTORE(ByVal dtpDatetimepicker As DateTimePicker)
        Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        Dim ToDate As Date = GlobalPPT.FiscalYearToDate.Date
        dtpDatetimepicker.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        dtpDatetimepicker.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)

        If DateDiff("d", DateAdd(DateInterval.Day, -1, Now.Date), Fromdate) < 0 And DateDiff("d", DateAdd(DateInterval.Day, -1, Now.Date), ToDate) > 0 Then

            Dim PickDate As Date
            PickDate = DateAdd(DateInterval.Day, -1, Now.Date)
            dtpDatetimepicker.Text = New DateTime(PickDate.Year, PickDate.Month, PickDate.Day)

        Else
            dtpDatetimepicker.Text = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        End If

    End Sub
    Public Shared Sub SetDateTimePicker(ByVal dtpDatetimepicker As DateTimePicker)
        Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
        Dim ToDate As Date = GlobalPPT.FiscalYearToDate.Date
        dtpDatetimepicker.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        dtpDatetimepicker.MaxDate = New DateTime(ToDate.Year, ToDate.Month, ToDate.Day)
        dtpDatetimepicker.Text = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
    End Sub

    Public Shared Function EstateTypeSelect() As String

        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[STORE].[StoreIssueVoucherEstateType]", Parms)
        Dim strEstateType As String
        strEstateType = ds.Tables(0).Rows(0).Item("TYPE").ToString()
        Return strEstateType
    End Function

    Public Shared Function IsSetMandatoryInCOA(ByVal COAID As String, ByVal SubTypeOrAccountControl As String) As DataSet
        Dim objdb As New SQLHelp

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COAID", COAID)
        Parms(2) = New SqlParameter("@SubTypeOrAccountControl", SubTypeOrAccountControl)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[COASubTypeGET]", Parms)
        Return ds
    End Function

    Public Shared Function AutoBSPBackup(ByVal BeforeOrAfter As String, ByVal ModID As Integer) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@BeforeOrAfter", BeforeOrAfter)
        Parms(1) = New SqlParameter("@Amonth", GlobalPPT.IntActiveMonth)
        Parms(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(3) = New SqlParameter("@ModID", ModID)

        ds = objdb.AutoBSPBackupExecQuery("[General].[AutoBSPBackup]", Parms)

        Return ds

    End Function


#End Region
End Class
