Imports CheckRoll_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT
Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class ImportAllowanceDAL
    Dim connection As New OleDbConnection
    Dim ds As New DataSet
    Dim adapter As New OleDbDataAdapter
    Dim command As New OleDbCommand

    Public excelConnection = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & ImportAllowancePPT.fileName & "';Extended Properties=Excel 8.0;"

    Public Function Save(ppt As ImportAllowancePPT) As Boolean
        Dim adap As New SQLHelp
        Dim param(12) As SqlParameter
        Try
            param(0) = New SqlParameter("@EmpAllowDedID", ppt.empAllowDedID)
            param(1) = New SqlParameter("@EstateID", ppt.estateID)
            param(2) = New SqlParameter("@EstateCode", ppt.estateCode)
            Dim empid As String
            empid = GetEmpIDFromEmpCode(ppt.empID)
            param(3) = New SqlParameter("@EmpID", empid)
            Dim allowDedID As String
            allowDedID = GetAllowDedID(ppt.allowDedID)
            param(4) = New SqlParameter("@AllowDedID", allowDedID)
            param(5) = New SqlParameter("@Amount", ppt.amount)
            param(6) = New SqlParameter("@Type", ppt.type)
            param(7) = New SqlParameter("@StartDate", ppt.startDate)
            param(8) = New SqlParameter("@EndDates", ppt.endDate)
            param(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            param(10) = New SqlParameter("@CreatedOn", DateTime.Now)
            param(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            param(12) = New SqlParameter("@ModifiedOn", DateTime.Now)            
            adap.ExecQuery("[Checkroll].[EmpAllowanceDeductionInsert]", param)
            Return True
        Catch ex As Exception
            ppt.SaveError = ex.Message
            Return False
        End Try
    End Function

    Private Function GetAllowDedID(allowedCode As String) As String
        Dim adap As New SQLHelp
        Dim param(0) As SqlParameter
        Try
            param(0) = New SqlParameter("@AllowDedCode", allowedCode)
            Dim ds As DataSet = adap.ExecQuery("[Checkroll].[GetAllowDedID]", param)
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("AllowDedID")) Then
                Return ds.Tables(0).Rows(0).Item("AllowDedID").ToString()
            End If
            Throw New Exception("AllowDedID isn't Exist !")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Private Function GetEmpIDFromEmpCode(EmpCode As String) As String
        Dim adap As New SQLHelp
        Dim param(0) As SqlParameter
        GetEmpIDFromEmpCode = ""
        Try
            param(0) = New SqlParameter("@EmpCode", EmpCode)
            Dim ds As DataSet = adap.ExecQuery("[Checkroll].[GetEmpIdFromEmpCode]", param)
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("Empid")) Then
                    Return ds.Tables(0).Rows(0).Item("Empid").ToString()
                End If
            Else
                Return ""
            End If
            Throw New Exception("Emp Id Doesnt Exist !")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Public Function GetExcel() As DataSet
        Try
            connection = New OleDbConnection(excelConnection)
            connection.Open()
            adapter = New OleDbDataAdapter("select * from [Sheet1$]", connection)
            adapter.TableMappings.Add("T", "T")
            ds = New DataSet
            adapter.Fill(ds)
            Return ds
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        Finally
            connection.Close()
        End Try
    End Function

    Public Sub UpdateExcel(errorstring As String, empID As String, allowDedID As String)
        Try
            connection = New OleDbConnection(excelConnection)
            connection.Open()
            command = New OleDbCommand("Update [Sheet1$] set [System Error Message] = '" & errorstring & "' where [Emp ID] = '" & empID & "' And [AllowDeductionCode] = '" & allowDedID & "';", connection)
            command.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            connection.Close()
        End Try
    End Sub

    Public Sub UpdateExcels(objectVariable As IEnumerable(Of String))
        Try
            connection = New OleDbConnection(excelConnection)
            connection.Open()
            For Each getErrorString As String In objectVariable
                Dim getError = getErrorString.Split("|")
                command = New OleDbCommand("Update [Sheet1$] set [System Error Message] = '" & getError(0) & "' where [Emp ID] = '" & getError(1) & "' And [AllowDeductionCode] = '" & getError(2) & "';", connection)
                command.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")            
        Finally
            connection.Close()
        End Try
    End Sub


End Class
