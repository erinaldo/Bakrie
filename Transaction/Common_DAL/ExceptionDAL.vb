Imports System.Windows.Forms
Module ExceptionDAL
    Public gstrErrorLoggingFile As String = Application.StartupPath

    ''' <summary>
    ''' To manage the exception that occur at runtime
    ''' </summary>
    ''' <param name="exError"></param>
    ''' <param name="strModuleName"></param>
    ''' <param name="strMethodName"></param>
    ''' <remarks></remarks>
    Public Sub ManageException(ByVal exError As Exception, ByVal strModuleName As String, ByVal strMethodName As String)
        Try

            Dim strErrorMessage As String

            'If gblnShowDetailedError Then
            '    strErrorMessage = "Error Occured in : " + strMethodName + " of " + strModuleName + vbCrLf + _
            '                        "Error Message : " + exError.Message.ToString() + vbCrLf + _
            '                        "Error Source : " + exError.Source.ToString() + vbCrLf + _
            '                        "Error DateTime : " + Now.ToString("dd-MMM-yyyy HH:mm:ss") + vbCrLf + vbCrLf + _
            '                        "Error Stack : " + exError.StackTrace.ToString()
            'Else
            strErrorMessage = "Error Occured in : " + strMethodName + " of " + strModuleName + vbCrLf + _
                                "Error Message : " + exError.Message.ToString() + vbCrLf + _
                                "Error Source : " + exError.Source.ToString() + vbCrLf + _
                                "Error DateTime : " + Now.ToString("dd-MMM-yyyy HH:mm:ss")
            '  End If

            ShowErrorMessage(strErrorMessage, "Error")

            strErrorMessage = "----------------- Start of Exception ----------------" + vbCrLf + _
                            strErrorMessage + vbCrLf + _
                            "----------------- End of Exception ----------------" + vbCrLf + vbCrLf

            'If gblnLogErrorInFile Then
            '    My.Computer.FileSystem.WriteAllText(gstrErrorLoggingFile, strErrorMessage, True)
            'End If

        Catch ex As Exception

            ShowErrorMessage(ex.Message, "Error Writing Log File")

        End Try

    End Sub
    Public Sub ShowErrorMessage(ByVal strMessage As String, ByVal strTitle As String)

        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub
End Module
