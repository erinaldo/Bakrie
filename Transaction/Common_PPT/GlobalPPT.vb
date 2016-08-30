Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings

Public Class GlobalPPT


#Region "Application Global Variables"

    'Public gblnShowDetailedError As Boolean = True

    Public Shared strLang As String '= "en"
    Public Shared strCategoryField As String = String.Empty
    Public Shared strUID As String = String.Empty
    Public Shared strDesgID As String = String.Empty
    Public Shared strDesgLevel As Integer
    Public Shared strDisplayName As String = String.Empty
    Public commonRoleAll As UserMasterPPT()
    Public Shared strActMthYearID As String = String.Empty
    Public Shared strEstateCode As String
    Public Shared strEstateID As String
    Public Shared strUserName As String = String.Empty
    Public Shared strPassword As String = String.Empty
    Public Shared intActiveYear As Integer
    Public Shared IntActiveMonth As Integer
    Public Shared FiscalYearFromDate As Date
    Public Shared FiscalYearToDate As Date
    Public Shared strEstateIDCode As String = String.Empty
    Public Shared straIdAndCode() As String
    Public Shared strEstateName As String = String.Empty
    Public Shared strEstateAbbrev As String = String.Empty
    Public Shared strLoginMonth As String = String.Empty
    Public Shared IntLoginMonth As Integer
    Public Shared intLoginYear As Integer
    Public Shared BSPVhVer As String = "1.0.1"
    Public Shared BSPAccVer As String = "1.0.1"
    Public Shared BSPWBVer As String = "1.0.1"
    Public Shared BSPBdgVer As String = "1.0.1"
    Public Shared BSPProVer As String = "1.0.1"
    Public Shared BSPStrVer As String = "1.0.1"
    Public Shared BSPChrVer As String = "1.0.1"
    Public Shared BSPVer As String = "1.0.1"
    Public Shared psAcctExpenditureType As String = String.Empty
    Public Shared psEstateType As String = String.Empty
    Public strMenuType As String
    Public Shared IsStockCategory As Boolean = True
    Public Shared Empid As String
    Public Shared EmpCode As String
    Public Shared WorkerType As String
    Public Shared Mandore As String
    Public Shared IsRetainFocus As Boolean = False
    Public Shared IsButtonClose As Boolean = False

    Public Shared SelectedDatabaseID As Integer = 0
    Public Shared SelectedDB As DatabaseMasterPPT.DatabaseList
    Public Shared ConnectionString As String = String.Empty

#End Region

#Region "MsgBox Variables"
    Public strExistMessage As String = "The record already exist in database."
    Public strAddMessage As String = "Details added successfully."
    Public strErrorAddMessage As String = "Error occured during add processing. Contact system administrator"
    Public strUpdateMessage As String = "Details updated successfully."
    Public strErrorUpdateMessage As String = "Error occured during update processing. Contact system administrator"
    Public strDeleteMessage As String = "Details Deleted successfully."
    Public strErrorDeleteMessage As String = "Error occured during delete processing. Contact system administrator"
    Public strErrorAutheticationMessage As String = "Sorry you have no permission to do this process. Contact system administrator"
#End Region


End Class
