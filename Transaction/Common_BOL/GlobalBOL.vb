Imports Common_PPT
Imports Common_DAL
Imports System.Windows.Forms
Public Class GlobalBOL
    Public Shared Sub SetDateTimePicker(ByVal dtpDatetimepicker As DateTimePicker)
        GlobalDAL.SetDateTimePicker(dtpDatetimepicker)
    End Sub

    Public Function PbIsSameMaturityStatus(ByVal COAExpenditureType As String, ByVal BlockStatus As String) As Boolean
        Dim sCOAExpenditureType As String = String.Empty
        Dim sBlockStatus As String = String.Empty

        Select Case COAExpenditureType.ToUpper
            Case "IMMATURE"
                sCOAExpenditureType = "Immature"
            Case "NURSERY"
                sCOAExpenditureType = "Nursery"
            Case "MATURED"
                sCOAExpenditureType = "Matured"
            Case "MILL"
                sCOAExpenditureType = "MILL"
            Case "KCP"
                sCOAExpenditureType = "KCP"
            Case "CES"
                sCOAExpenditureType = "CES"
            Case "OPERATING"
                sCOAExpenditureType = "Operating"
            Case Else
                sCOAExpenditureType = COAExpenditureType.ToUpper
        End Select

        'Sai Comment : Bypassed check for Account code vs field type
        Return True
        'If BlockStatus.Trim.ToUpper = sCOAExpenditureType.Trim.ToUpper Then
        '    Return True
        'Else
        '    Return False
        'End If

    End Function

    Public Shared Sub KeyDownEvent(ByVal GridName As DataGridView, ByVal e As System.Windows.Forms.KeyEventArgs)
        ' If e.KeyValue = 40 Then
        If e.KeyValue = 40 Then
            If GridName.SelectedRows.Count = 0 Then
                GridName.Rows(0).Selected = True
            Else
                If GridName.SelectedRows(0).Index < (GridName.Rows.Count - 1) Then
                    Dim intSelectedIndex As Integer = GridName.SelectedRows(0).Index

                    GridName.ClearSelection()
                    GridName.Rows(intSelectedIndex + 1).Selected = True
                End If
            End If
        End If
        ' End If
    End Sub

    Public Shared Sub KeyUpEvent(ByVal GridName As DataGridView, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = 38 Then
            If GridName.SelectedRows.Count = 0 Then
                GridName.Rows(0).Selected = True
            Else
                If GridName.SelectedRows(0).Index < (GridName.Rows.Count + 1) Then
                    Dim intSelectedIndex As Integer = GridName.SelectedRows(0).Index
                    GridName.ClearSelection()

                    If intSelectedIndex > 0 Then
                        GridName.Rows(intSelectedIndex - 1).Selected = True
                    End If
                End If
            End If
        End If
    End Sub


    Public Shared Sub SetDateTimePickerSTORE(ByVal dtpDatetimepicker As DateTimePicker)
        GlobalDAL.SetDateTimePickerSTORE(dtpDatetimepicker)
    End Sub
    Public Shared Function EstateTypeSelect() As String
        Return GlobalDAL.EstateTypeSelect()
    End Function
    Public Function PMonthName(ByVal IntMonth As Integer, ByVal IntYear As Integer, ByVal asLanguage As String) As String
        Return GlobalDAL.PMonthName(IntMonth, IntYear, asLanguage)
    End Function
    'Public Function PFullMonthYearName(ByVal IntMonth As Integer, ByVal IntYear As Integer, ByVal asLanguage As String) As String
    '    Return GlobalDAL.PFullMonthYearName(IntMonth, IntYear, asLanguage)
    'End Function


    'AN06042010 - To get Account Control and Sub Type condition from COA for the selected/keyed in Account Code, based on the parameter such as 
    ' COAID                   - Selected or keyed in Account code ID from the transaction screen
    ' SubTypeorAccountControl - Send parameter either "SubType" or "AccountControl"
    ' asRequiredField         - Output parameter send empty variable to get the message as output from here
    '                         Note: if requiredField output is empty string, meaning no need to validate the Account code.
    Public Function IsSetMandatoryInCOA(ByVal COAID As String, ByVal SubTypeOrAccountControl As String, ByVal asModule As String, _
     ByRef asRequiredField As String) As Boolean
        Dim sAccountControl As String

        Dim ds As New DataSet
        ds = GlobalDAL.IsSetMandatoryInCOA(COAID, SubTypeOrAccountControl)

        If ds.Tables(0).Rows.Count <> 0 Then

            If SubTypeOrAccountControl = "SubType" Then

                If ds.Tables(0).Rows(0).Item("SubType") = "A" Then  'Accounts Payable (AP)
                    asRequiredField = "Accounts Payable Code"
                ElseIf ds.Tables(0).Rows(0).Item("SubType") = "V" Then ' Vehicle (V)
                    asRequiredField = "Vehicle Code"
                ElseIf ds.Tables(0).Rows(0).Item("SubType") = "F" Then ' Field & Block (F)
                    asRequiredField = "Sub Block Code"
                Else
                    asRequiredField = String.Empty
                End If

            ElseIf SubTypeOrAccountControl = "AccountControl" Then
                sAccountControl = ds.Tables(0).Rows(0).Item("AccountControl")

                If ds.Tables(0).Rows(0).Item("AccountControl") = "000" Then  'No Account Control
                    asRequiredField = String.Empty
                ElseIf ds.Tables(0).Rows(0).Item("AccountControl") = "001" Then ' only for Material(Store)
                    asRequiredField = "STORE MODULE"
                ElseIf ds.Tables(0).Rows(0).Item("AccountControl") = "010" Then ' only for Labour(checkroll) 
                    asRequiredField = "CHECKROLL MODULE"
                ElseIf ds.Tables(0).Rows(0).Item("AccountControl") = "100" Then ' only for vehicle
                    asRequiredField = "VEHICLE MODULE"
                ElseIf ds.Tables(0).Rows(0).Item("AccountControl") = "110" Then ' only for vehicle & Labour
                    asRequiredField = "VEHICLE AND CHECKROLL MODULES"
                ElseIf ds.Tables(0).Rows(0).Item("AccountControl") = "011" Then ' only for Labour & Material
                    asRequiredField = "CHECKROLL & STORE MODULES"
                ElseIf ds.Tables(0).Rows(0).Item("AccountControl") = "101" Then ' only for Vehicle & Material
                    asRequiredField = "VEHICLE & STORE MODULES"
                ElseIf ds.Tables(0).Rows(0).Item("AccountControl") = "111" Then ' for Vehicle & Material & Labour
                    asRequiredField = "VEHICLE & STORE & CHECKROLL MODULES"
                End If

                If asModule = "STORE" Then
                    If sAccountControl.Trim.Substring(2, 1) = "1" Then
                        asRequiredField = String.Empty
                    End If
                End If

                If asModule = "VEHICLE" Then
                    If sAccountControl.Trim.Substring(0, 1) = "1" Then
                        asRequiredField = String.Empty
                    End If
                End If

                If asModule = "CHECKROLL" Then
                    If sAccountControl.Trim.Substring(1, 1) = "1" Then
                        asRequiredField = String.Empty
                    End If
                End If


            End If
        Else
            asRequiredField = String.Empty
        End If


        Return True
    End Function

    'Commented by sangar D on 28-Aug-2012 - Advised by ran team to imporove the application performance
    'Public Shared Function AutoBSPBackup(ByVal BeforeOrAfter As String, ByVal ModID As Integer) As DataSet

    '    Return GlobalDAL.AutoBSPBackup(BeforeOrAfter, ModID)

    'End Function


End Class
