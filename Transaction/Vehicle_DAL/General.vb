'Imports BSP.Vehicle.Entity
'Imports BSP.Vehicle.Data


Public Class General


    'Public Shared Sub ShowMessageFromDataBase(ByVal msg As Integer)

    '    Select Case (msg)

    '        Case 0
    '            MsgBox("We are unable to process your request at this time, Please make sure to enter all the Mandatory Fields and try again. If the Problem Still exists contact Administrator.", Microsoft.VisualBasic.MsgBoxStyle.Critical + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Failure")

    '        Case 1
    '            MsgBox("Data Successfully Saved", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")

    '        Case 2
    '            MsgBox("Data Successfully Updated", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")

    '        Case 3
    '            MsgBox("Data Successfully Deleted", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")

    '        Case 4
    '            MsgBox("Record Already In Use", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Failed")

    '        Case 5
    '            MsgBox("Data Changed - ConcurrencyID", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Failed")

    '        Case 6
    '            MsgBox("This record was posted successfully.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Failed")

    '        Case 7
    '            MsgBox("All records were posted successfully.", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Failed")

    '        Case 10
    '            MsgBox("Record Already Exists", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Duplicate")

    '    End Select
    'End Sub

    'Public Shared Sub ShowMessageFromDataBase(ByVal liMsg As Integer, ByVal lsErrMsg As String)

    '    Select Case (liMsg)

    '        Case 0
    '            MsgBox(lsErrMsg, Microsoft.VisualBasic.MsgBoxStyle.Critical + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Failure")

    '        Case 1
    '            'MsgBox("Success", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Success")

    '            'Case 10
    '            'MsgBox("Record Already Exists", Microsoft.VisualBasic.MsgBoxStyle.Exclamation + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "Duplicate")

    '    End Select
    'End Sub

    'Public Shared Function AutoNumberedTable(ByVal SourceTable As DataTable) As DataTable


    '    Dim ResultTable As New DataTable()

    '    Dim AutoNumberColumn As New DataColumn()

    '    AutoNumberColumn.ColumnName = "SNo"

    '    AutoNumberColumn.DataType = GetType(Integer)

    '    AutoNumberColumn.AutoIncrement = True

    '    AutoNumberColumn.AutoIncrementSeed = 1

    '    AutoNumberColumn.AutoIncrementStep = 1

    '    ResultTable.Columns.Add(AutoNumberColumn)

    '    ResultTable.Merge(SourceTable)

    '    Return ResultTable

    'End Function

    'Public Shared Function GetTimeFormation(ByVal lsTime As String) As DateTime
    '    'Dim lsFormatTime As String = lsTime.Replace(".", ":")

    '    Dim frmt As System.IFormatProvider = New System.Globalization.CultureInfo("en-US", True)
    '    Dim formats As String() = New String(4) {}
    '    formats(0) = "HH:mm"
    '    formats(1) = "H:mm"
    '    formats(2) = "H"
    '    formats(3) = "HH"
    '    formats(4) = "H:m"

    '    Return DateTime.ParseExact(lsTime, formats, frmt, System.Globalization.DateTimeStyles.None)
    'End Function

    'Public Shared Function GetInTimeFormat(ByVal lsTime As String) As TimeSpan
    '    Dim culture As IFormatProvider = New System.Globalization.CultureInfo("fr-FR", True)
    '    Dim ldReturnIn24HrsTimeFormat As DateTime = DateTime.Parse(lsTime, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault)
    '    Return New TimeSpan(ldReturnIn24HrsTimeFormat.Hour, ldReturnIn24HrsTimeFormat.Minute, ldReturnIn24HrsTimeFormat.Second)
    'End Function

    'Public Shared Function ValidateForeignKeyFields(ByVal lsFileldName As String, ByVal lsFieldValue As String) As Boolean

    '    Dim isValid As Boolean

    '    isValid = True

    '    Dim objWorkshopLogEntity As WorkshopLogEntity = New WorkshopLogEntity
    '    Dim objWorkshopLogManager As WorkshopLogManager = New WorkshopLogManager
    '    objWorkshopLogEntity.psEstateID = GlobalVar.psEstateID
    '    objWorkshopLogEntity.psFieldName = lsFileldName
    '    objWorkshopLogEntity.psFieldValue = lsFieldValue
    '    Select Case objWorkshopLogManager.GetIsValidKey(objWorkshopLogEntity)
    '        Case 0
    '            isValid = False
    '    End Select

    '    Return isValid

    'End Function

    'Public Shared Sub SetDateTimePicker(ByVal dtpDatetimepicker As DateTimePicker)
    '    Dim objWorkshopLogEntity As WorkshopLogEntity = New WorkshopLogEntity
    '    Dim objWorkshopLogManager As WorkshopLogManager = New WorkshopLogManager


    '    objWorkshopLogEntity.psActiveMonthYearID = GlobalVar.psActiveMonthYearID
    '    objWorkshopLogEntity.psEstateID = GlobalVar.psEstateID
    '    Dim dsActiveMonthYear As DataSet = New DataSet
    '    dsActiveMonthYear = objWorkshopLogManager.GetActiveMonthYear(objWorkshopLogEntity)
    '    If dsActiveMonthYear.Tables(0).Rows.Count > 0 Then
    '        dtpDatetimepicker.MinDate = New DateTime(dsActiveMonthYear.Tables(0).Rows(0)(1).ToString, dsActiveMonthYear.Tables(0).Rows(0)(0).ToString, 1)
    '        dtpDatetimepicker.MaxDate = dtpDatetimepicker.MinDate.AddMonths(1).AddDays(-1)
    '    Else
    '        dtpDatetimepicker.MinDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
    '        dtpDatetimepicker.MaxDate = dtpDatetimepicker.MinDate.AddMonths(1).AddDays(-1)
    '    End If

    'End Sub


    'Public Shared Function CheckIfNumericKey(ByVal K As Keys, ByVal isDecimalPoint As Boolean) As Boolean
    '    If K = Keys.Back Then
    '        'backspace?
    '        Return True
    '    End If

    '    If K = Keys.OemPeriod OrElse K = Keys.[Decimal] Then
    '        'decimal point?
    '        Return isDecimalPoint = False
    '    End If

    '    'or: return !isDecimalPoint
    '    If (K >= Keys.D0) AndAlso (K <= Keys.D9) Then
    '        'digit from top of keyboard?
    '        Return True
    '    End If

    '    If (K >= Keys.NumPad0) AndAlso (K <= Keys.NumPad9) Then
    '        'digit from keypad?
    '        Return True
    '    End If

    '    'no "numeric" key
    '    Return False
    'End Function



End Class
