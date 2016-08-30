Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT
Public Class RiceDAL

    Public Shared Function RiceMaritalStatusGet() As DataSet
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Return objdb.ExecQuery("[Budget].[RiceMaritalStatusGet]")
    End Function
    Public Shared Function RiceSelect(ByVal oRicePPT As RicePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oRicePPT.BudgetYear)

        dt = objdb.ExecQuery("[Budget].[RiceSelect]", Parms).Tables(0)

        Return dt
    End Function
    Public Shared Function RiceViewSelect(ByVal oRicePPT As RicePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oRicePPT.BudgetYear)

        dt = objdb.ExecQuery("[Budget].[RiceViewSelect]", Parms).Tables(0)

        Return dt
    End Function

    Public Shared Function RiceMainInsert(ByVal oRicePPT As RicePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim parms(7) As SqlParameter

        parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        parms(1) = New SqlParameter("@BudgetYear", oRicePPT.BudgetYear)
        parms(2) = New SqlParameter("@Rice@", oRicePPT.RiceAt)
        parms(3) = New SqlParameter("@RiceFinal", oRicePPT.RiceFinal)
        parms(4) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        parms(5) = New SqlParameter("@CreatedOn", Date.Today())
        parms(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        parms(7) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[RiceMainInsert]", parms)
        Return ds
    End Function
    Public Shared Function RiceInsert(ByVal oRicePPT As RicePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim parms(10) As SqlParameter

        parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        parms(1) = New SqlParameter("@BudgetYear", oRicePPT.BudgetYear)

        parms(2) = New SqlParameter("@RiceMainID", oRicePPT.RiceMainID)
        parms(3) = New SqlParameter("@MS", oRicePPT.MS)

        parms(4) = New SqlParameter("@Kgs", oRicePPT.Kgs)
        parms(5) = New SqlParameter("@Percentage", oRicePPT.Percentage)
        parms(6) = New SqlParameter("@Total", oRicePPT.Total)

        parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        parms(10) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[RiceInsert]", parms)
        Return ds
    End Function

    Public Shared Function RiceExist(ByVal oRicePPT As RicePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim param(2) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        param(2) = New SqlParameter("@MS", oRicePPT.MS)
        dt = objdb.ExecQuery("[Budget].[RiceIsExist]", param).Tables(0)
        Return dt
    End Function
    Public Shared Function RiceMainUpdate(ByVal oRicePPT As RicePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim parms(6) As SqlParameter

        parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        parms(1) = New SqlParameter("@BudgetYear", oRicePPT.BudgetYear)
        parms(2) = New SqlParameter("@RiceMainID", oRicePPT.RiceMainID)
        parms(3) = New SqlParameter("@Rice@", oRicePPT.RiceAt)
        parms(4) = New SqlParameter("@RiceFinal", oRicePPT.RiceFinal)
        parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        parms(6) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[RiceMainUpdate]", parms)
        Return ds
    End Function

    Public Shared Function RiceUpdate(ByVal oRicePPT As RicePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim parms(9) As SqlParameter
        parms(0) = New SqlParameter("@RiceID", oRicePPT.RiceID)
        parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        parms(2) = New SqlParameter("@BudgetYear", oRicePPT.BudgetYear)

        parms(3) = New SqlParameter("@RiceMainID", oRicePPT.RiceMainID)
        parms(4) = New SqlParameter("@MS", oRicePPT.MS)

        parms(5) = New SqlParameter("@Kgs", oRicePPT.Kgs)
        parms(6) = New SqlParameter("@Percentage", oRicePPT.Percentage)
        parms(7) = New SqlParameter("@Total", oRicePPT.Total)


        parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        parms(9) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[RiceUpdate]", parms)
        Return ds
    End Function

    Public Shared Function RiceMainDelete(ByVal oRicePPT As RicePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oRicePPT.BudgetYear)
        ds = objdb.ExecQuery("[Budget].[RiceMainDelete]", Parms)

        Return ds

    End Function
    Public Shared Function RiceDelete(ByVal oRicePPT As RicePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@BudgetYear", oRicePPT.BudgetYear)
        Parms(1) = New SqlParameter("@RiceMainID", oRicePPT.RiceMainID)
        Parms(2) = New SqlParameter("@MS", oRicePPT.MS)

        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        Parms(4) = New SqlParameter("@RiceID", oRicePPT.RiceID)

        ds = objdb.ExecQuery("[Budget].[RiceDelete]", Parms)

        Return ds

    End Function
End Class
