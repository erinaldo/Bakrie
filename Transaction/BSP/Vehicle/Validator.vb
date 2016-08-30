Public Class Validator

    Dim message As String

    Public Function Required(ByVal lsControlValue As String, ByVal lsControlType As String, ByVal lsErrorMessage As String) As String
        message = String.Empty
        If (lsControlType = "TextBox") Then
            If (Not RequiredFieldValidator(lsControlValue)) Then
                message = lsErrorMessage
            End If
        Else
            If (lsControlType = "ComboBox") Then
                If (lsControlValue = -1) Then
                    message = lsErrorMessage
                End If
            End If
        End If
        Return message
    End Function


    Public Function Required(ByVal lsStartTimeHrs As ComboBox, ByVal lsStartTimeMin As ComboBox, ByVal lsStartTimeMeridiem As ComboBox, ByVal lsEndTimeHrs As ComboBox, ByVal lsEndTimeMin As ComboBox, ByVal lsEndTimeMeridiem As ComboBox) As String
        message = String.Empty
        Dim lbIsStartTime As Boolean
        Dim lbIsEndTime As Boolean

        If lsStartTimeHrs.SelectedIndex > -1 Or lsStartTimeMin.SelectedIndex > -1 Or lsStartTimeMeridiem.SelectedIndex > -1 Then
            message += startTime(lsStartTimeHrs, lsStartTimeMin, lsStartTimeMeridiem)

            lbIsStartTime = message <> String.Empty

            'If message <> String.Empty Then
            '    lbIsStartTime = True

            'Else
            '    lbIsStartTime = False
            'End If
        End If

        If lsEndTimeHrs.SelectedIndex > -1 Or lsEndTimeMin.SelectedIndex > -1 Or lsEndTimeMeridiem.SelectedIndex > -1 Then


            message += EndTime(lsEndTimeHrs, lsEndTimeMin, lsEndTimeMeridiem)

            lbIsEndTime = message <> String.Empty

            'If message <> String.Empty Then
            '    lbIsEndTime = True

            'Else
            '    lbIsEndTime = False
            'End If

        End If

        If (lbIsStartTime And Not lbIsEndTime) Then
            message = message + EndTime(lsEndTimeHrs, lsEndTimeMin, lsEndTimeMeridiem)
        End If

        If (Not lbIsEndTime And Not lbIsStartTime) Then
            message = message + startTime(lsStartTimeHrs, lsStartTimeMin, lsStartTimeMeridiem)
        End If


        Return message
    End Function

    Public Function startTime(ByVal lsStartTimeHrs As ComboBox, ByVal lsStartTimeMin As ComboBox, ByVal lsStartTimeMeridiem As ComboBox) As String
        message = String.Empty
        If lsStartTimeHrs.SelectedIndex = -1 And lsStartTimeMin.SelectedIndex = -1 And lsStartTimeMeridiem.SelectedIndex = -1 Then
            message += "Please Select Start Hours, Minutes, Meridiem" & vbCrLf & ""
        ElseIf lsStartTimeHrs.SelectedIndex = -1 And lsStartTimeMin.SelectedIndex = -1 Then
            message += "Please Select Start Hours, Minutes" & vbCrLf & ""
        ElseIf lsStartTimeHrs.SelectedIndex = -1 And lsStartTimeMeridiem.SelectedIndex = -1 Then
            message += "Please Select Start Hours, Meridiem" & vbCrLf & ""
        ElseIf lsStartTimeMin.SelectedIndex = -1 And lsStartTimeMeridiem.SelectedIndex = -1 Then
            message += "Please Select Start Minutes, Meridiem" & vbCrLf & ""
        ElseIf lsStartTimeHrs.SelectedIndex = -1 Then
            message += "Please Select Start Hours" & vbCrLf & ""
        ElseIf lsStartTimeMin.SelectedIndex = -1 Then
            message += "Please Select Start Minutes" & vbCrLf & ""
        ElseIf lsStartTimeMeridiem.SelectedIndex = -1 Then
            message += "Please Select Start Meridiem" & vbCrLf & ""
        End If

        Return message
    End Function

    Public Function EndTime(ByVal lsEndTimeHrs As ComboBox, ByVal lsEndTimeMin As ComboBox, ByVal lsEndTimeMeridiem As ComboBox) As String
        message = String.Empty
        If lsEndTimeHrs.SelectedIndex = -1 And lsEndTimeMin.SelectedIndex = -1 And lsEndTimeMeridiem.SelectedIndex = -1 Then
            message += "Please Select End Hours, Minutes, Meridiem" & vbCrLf & ""
        ElseIf lsEndTimeHrs.SelectedIndex = -1 And lsEndTimeMin.SelectedIndex = -1 Then
            message += "Please Select End Hours, Minutes" & vbCrLf & ""
        ElseIf lsEndTimeHrs.SelectedIndex = -1 And lsEndTimeMeridiem.SelectedIndex = -1 Then
            message += "Please Select End Hours, Meridiem" & vbCrLf & ""
        ElseIf lsEndTimeMin.SelectedIndex = -1 And lsEndTimeMeridiem.SelectedIndex = -1 Then
            message += "Please Select End Minutes, Meridiem" & vbCrLf & ""
        ElseIf lsEndTimeHrs.SelectedIndex = -1 Then
            message += "Please Select Hours" & vbCrLf & ""
        ElseIf lsEndTimeMin.SelectedIndex = -1 Then
            message += "Please Select End Minutes" & vbCrLf & ""
        ElseIf lsEndTimeMeridiem.SelectedIndex = -1 Then
            message += "Please Select End Meridiem" & vbCrLf & ""
        End If
        Return message
    End Function

    Public Function RequiredFieldValidator(ByVal lsControlValue As String) As Boolean
        Return lsControlValue <> String.Empty
    End Function

    Public Function RequiredFieldValidator(ByVal lsStartTimeHrs As Integer, ByVal lsStartTimeMin As Integer, ByVal lsStartTimeMeridiem As Integer, ByVal lsEndTimeHrs As Integer, ByVal lsEndTimeMin As Integer, ByVal lsEndTimeMeridiem As Integer) As Boolean
        Return (Not (lsStartTimeHrs > -1 Or lsStartTimeMin > -1 Or lsStartTimeMeridiem > -1 Or lsEndTimeHrs > -1 Or lsEndTimeMin > -1 Or lsEndTimeMeridiem > -1))
    End Function

    Public Function RequiredFieldValidator(ByVal lbOperational As Boolean, ByVal lbStandBy As Boolean, ByVal lbBreakDown As Boolean, ByVal lbFFBdeliverytoMill As Boolean) As Boolean
        Return Not (lbOperational = False And lbStandBy = False And lbBreakDown = False And lbFFBdeliverytoMill = False)
    End Function

    Public Function RequiredFieldValidator(ByVal cmbHrs As ComboBox) As Boolean
        Return Not (cmbHrs.SelectedIndex = 0)
    End Function

    Public Function RequiredFieldValidator(ByVal lsStartHrsOrKms As String, ByVal lsEndHrsOrKms As String) As Boolean
        If (lsStartHrsOrKms = String.Empty And lsEndHrsOrKms <> String.Empty) Or _
            (lsStartHrsOrKms <> String.Empty And lsEndHrsOrKms = String.Empty) Then

            Return False

        End If

        Return True
    End Function

    'Function RequiredFieldValidator(ByVal lsStartTimeHrs As Integer, ByVal lsStartTimeMin As Integer, ByVal lsStartTimeMeridiem As Integer, ByVal lsEndTimeHrs As Integer, ByVal lsEndTimeMin As Integer, ByVal lsEndTimeMeridiem As Integer) As Boolean
    '    If (lsStartTimeHrs > -1 Or lsStartTimeMin > -1 Or lsStartTimeMeridiem > -1 Or lsEndTimeHrs > -1 Or lsEndTimeMin > -1 Or lsEndTimeMeridiem > -1) Then
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function

End Class