Imports Vehicle_PPT
'Imports Vehicle_DAL
Imports Vehicle_BOL
Imports Common_PPT


Public Class General

    Public Shared Sub ShowMessageFromDataBase(ByVal msg As Integer)
        Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(VehicleDistributionFrm))

        Select Case (msg)

            Case 0
                'MsgBox("We are unable to process your request at this time, Please make sure to enter all the mandatory fields and try again. If the problem still exists contact administrator.", Microsoft.VisualBasic.MsgBoxStyle.Critical + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Failure")
                MsgBox(rm.GetString("Msg0"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)

            Case 1
                'MsgBox("Data successfully saved", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                MsgBox(rm.GetString("Msg1"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)

            Case 2
                'MsgBox("Data successfully updated", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                MsgBox(rm.GetString("Msg2"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)
            Case 3
                'MsgBox("Data successfully deleted", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                MsgBox(rm.GetString("Msg3"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)
            Case 4
                'MsgBox("Record already in use", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Failed")
                MsgBox(rm.GetString("Msg4"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)
            Case 5
                'MsgBox("You are attempting to modify a record that is being used elsewhere", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Concurrency violation")
                MsgBox(rm.GetString("Msg5"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)
            Case 6
                'MsgBox("This record was posted successfully.", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                MsgBox(rm.GetString("Msg6"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)
            Case 7
                'MsgBox("All records were posted successfully.", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                MsgBox(rm.GetString("Msg7"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)
            Case 10
                'MsgBox("Record already exists", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Duplicate Record")
                MsgBox(rm.GetString("Msg10"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)
            Case 11
                'MsgBox("Current data conflicts with existing data in the database.Please modify start kms and/or end kms.", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                MsgBox(rm.GetString("Msg11"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)
            Case 12
                'MsgBox("Current data conflicts with existing data in the database.Please modify start time and/or end time.", Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")
                MsgBox(rm.GetString("Msg12"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)
            Case 13
                'MsgBox("Current data conflicts with existing data in the database.Please modify FFB Delivery Order No.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Duplicate Record")
                MsgBox(rm.GetString("Msg13"), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly)

        End Select
    End Sub

    Public Shared Sub ShowMessageFromDataBase(ByVal liMsg As Integer, ByVal lsErrMsg As String)

        Select Case (liMsg)

            Case 0
                MsgBox(lsErrMsg, Microsoft.VisualBasic.MsgBoxStyle.Critical + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Failure")

            Case 1
                'MsgBox("Success", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")

                'Case 10
                'MsgBox("Record Already Exists", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Duplicate")

        End Select
    End Sub

    Public Shared Function GetTimeFormation(ByVal lsTime As String) As DateTime
        'Dim lsFormatTime As String = lsTime.Replace(".", ":")

        Dim frmt As System.IFormatProvider = New System.Globalization.CultureInfo("en-US", True)
        Dim formats As String() = New String(4) {}
        formats(0) = "HH:mm"
        formats(1) = "H:mm"
        formats(2) = "H"
        formats(3) = "HH"
        formats(4) = "H:m"

        Return DateTime.ParseExact(lsTime, formats, frmt, System.Globalization.DateTimeStyles.None)
    End Function

    Public Shared Function GetInTimeFormat(ByVal lsTime As String) As TimeSpan

        If lsTime <> String.Empty Then
            Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
            Dim ldReturnIn24HrsTimeFormat As DateTime = DateTime.Parse(lsTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
            Return New TimeSpan(ldReturnIn24HrsTimeFormat.Hour, ldReturnIn24HrsTimeFormat.Minute, ldReturnIn24HrsTimeFormat.Second)
        End If

    End Function

    'VehicleRunningBatchfrm
    Public Shared Function IsVHWSCodeExist(ByVal lsFileldName As String, ByVal lsFieldValue As String) As Integer

        Dim _VehicleGeneralPPT As VehicleGeneralPPT = New VehicleGeneralPPT
        Dim _VehicleGeneralBOL As VehicleGeneralBOL = New VehicleGeneralBOL
        _VehicleGeneralPPT.psEstateID = GlobalPPT.strEstateID
        _VehicleGeneralPPT.psFieldName = lsFileldName
        _VehicleGeneralPPT.psFieldValue = lsFieldValue
        Return _VehicleGeneralBOL.IsVHWSCodeExist(_VehicleGeneralPPT)

    End Function

    'VehicleRunningLog
    Public Shared Function ValidateForeignKeyFields(ByVal lsFileldName As String, ByVal lsFieldValue As String) As Integer

        'Dim isValid As Boolean

        'isValid = True

        Dim _VehicleGeneralPPT As VehicleGeneralPPT = New VehicleGeneralPPT
        Dim _VehicleGeneralBOL As VehicleGeneralBOL = New VehicleGeneralBOL
        _VehicleGeneralPPT.psEstateID = GlobalPPT.strEstateID
        _VehicleGeneralPPT.psFieldName = lsFileldName
        _VehicleGeneralPPT.psFieldValue = lsFieldValue

        Return _VehicleGeneralBOL.GetIsValidKey(_VehicleGeneralPPT)

        'Select Case _VehicleGeneralBOL.GetIsValidKey(_VehicleGeneralPPT)
        'Case 0
        'isValid = False
        'End Select

        'Return isValid

    End Function

    'Public Shared Sub SetDateTimePicker(ByVal dtpDatetimepicker As DateTimePicker)
    '    Dim _VehicleGeneralPPT As VehicleGeneralPPT = New VehicleGeneralPPT
    '    Dim _VehicleGeneralBOL As VehicleGeneralBOL = New VehicleGeneralBOL

    '    _VehicleGeneralPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID
    '    _VehicleGeneralPPT.psEstateID = GlobalPPT.strEstateID
    '    GlobalPPT.FiscalYearFromDate()

    '    _VehicleGeneralCollections = _VehicleGeneralBOL.GetActiveMonthYear(_VehicleGeneralPPT)
    '    If _VehicleGeneralCollections IsNot Nothing And _VehicleGeneralCollections.Count > 0 Then
    '        dtpDatetimepicker.MinDate = New DateTime(_VehicleGeneralCollections(0).pdActiveYear, _VehicleGeneralCollections(0).pdActiveMonth, 1) '_VehicleGeneralCollections(0).pdFromDT 'New DateTime(_VehicleGeneralCollections(0).pdActiveYear, _VehicleGeneralCollections(0).pdActiveMonth, 1)
    '        dtpDatetimepicker.MaxDate = dtpDatetimepicker.MinDate.AddMonths(1).AddDays(-1) '_VehicleGeneralCollections(0).pdToDT 'dtpDatetimepicker.MinDate.AddMonths(1).AddDays(-1)
    '    Else
    '        dtpDatetimepicker.MinDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
    '        dtpDatetimepicker.MaxDate = dtpDatetimepicker.MinDate.AddMonths(1).AddDays(-1)
    '    End If

    'End Sub

    'Public Shared Sub SetVehicleDateTimePicker(ByVal dtpDatetimepicker As DateTimePicker, ByVal lsFormName As String)
    Public Shared Sub SetVehicleDateTimePicker(ByVal dtpDatetimepicker As DateTimePicker, ByVal lsSchemaName As String, ByVal lsTableName As String, ByVal lsColumnName As String)

        Dim _VehicleGeneralPPT As VehicleGeneralPPT = New VehicleGeneralPPT
        Dim _VehicleGeneralBOL As VehicleGeneralBOL = New VehicleGeneralBOL

        _VehicleGeneralPPT.psActiveMonthYearID = GlobalPPT.strActMthYearID
        _VehicleGeneralPPT.psEstateID = GlobalPPT.strEstateID
        _VehicleGeneralPPT.PsSchemaName = lsSchemaName
        _VehicleGeneralPPT.PsTableName = lsTableName
        _VehicleGeneralPPT.PsColumnName = lsColumnName

        dtpDatetimepicker.MinDate = GlobalPPT.FiscalYearFromDate
        dtpDatetimepicker.MaxDate = GlobalPPT.FiscalYearToDate

        If lsTableName <> String.Empty Then
            Dim ds As DataSet = _VehicleGeneralBOL.GetActiveMonthYear(_VehicleGeneralPPT)

            'Consider we have a date in our table
            ' then Get the maximum date
            If (ds IsNot Nothing) And (ds.Tables.Count = 1) And (ds.Tables(0).Rows.Count = 1) And Not IsDBNull(ds.Tables(0).Rows(0)(0)) Then

                If CDate(ds.Tables(0).Rows(0)(0)) >= GlobalPPT.FiscalYearFromDate And CDate(ds.Tables(0).Rows(0)(0)) <= GlobalPPT.FiscalYearToDate Then
                    dtpDatetimepicker.Text = CDate(ds.Tables(0).Rows(0)(0))
                ElseIf Now() >= GlobalPPT.FiscalYearFromDate And Now() <= GlobalPPT.FiscalYearToDate Then
                    dtpDatetimepicker.Text = Now
                Else
                    dtpDatetimepicker.Text = GlobalPPT.FiscalYearFromDate
                End If

            ElseIf Now() >= GlobalPPT.FiscalYearFromDate And Now() <= GlobalPPT.FiscalYearToDate Then
                dtpDatetimepicker.Text = Now
            Else
                dtpDatetimepicker.Text = GlobalPPT.FiscalYearFromDate
            End If
        Else
            dtpDatetimepicker.Text = Now
        End If


        'If _VehicleGeneralCollections IsNot Nothing And _VehicleGeneralCollections.Count > 0 Then
        '    dtpDatetimepicker.MinDate = New DateTime(_VehicleGeneralCollections(0).pdActiveYear, _VehicleGeneralCollections(0).pdActiveMonth, 1) '_VehicleGeneralCollections(0).pdFromDT 'New DateTime(_VehicleGeneralCollections(0).pdActiveYear, _VehicleGeneralCollections(0).pdActiveMonth, 1)
        '    dtpDatetimepicker.MaxDate = dtpDatetimepicker.MinDate.AddMonths(1).AddDays(-1) '_VehicleGeneralCollections(0).pdToDT 'dtpDatetimepicker.MinDate.AddMonths(1).AddDays(-1)
        'Else
        '    dtpDatetimepicker.MinDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        '    dtpDatetimepicker.MaxDate = dtpDatetimepicker.MinDate.AddMonths(1).AddDays(-1)
        'End If

    End Sub

    Public Shared Function MonthYear(ByVal number As Integer) As String
        Dim strMonth As String = String.Empty

        Select Case number
            Case 1
                strMonth = "Jan"
            Case 2
                strMonth = "Feb"
            Case 3
                strMonth = "Mar"
            Case 4
                strMonth = "Apr"
            Case 5
                strMonth = "May"
            Case 6
                strMonth = "Jun"
            Case 7
                strMonth = "Jul"
            Case 8
                strMonth = "Aug"
            Case 9
                strMonth = "Sep"
            Case 10
                strMonth = "Oct"
            Case 11
                strMonth = "Nov"
            Case 12
                strMonth = "Dec"
            Case Else
                Exit Select
        End Select
        Return strMonth

    End Function

End Class
