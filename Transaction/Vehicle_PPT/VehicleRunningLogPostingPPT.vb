Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.Collections.Generic


Public Class VehicleRunningLogPostingPPT

    'We are telling the procedure to post all as posted for the text "PostAll"
    'If the text is single we are posting by using the Id

    Private lsCreatedBy As String

    Public Property psCreatedBy() As String
        Get
            Return lsCreatedBy
        End Get
        Set(ByVal value As String)
            lsCreatedBy = value
        End Set
    End Property

    Private lsPostingType As String
    Public Property psPostingType() As String
        Get
            Return lsPostingType
        End Get
        Set(ByVal value As String)
            lsPostingType = value
        End Set
    End Property

    'Related to db table column name: ID
    Private liId As Integer
    Public Property piId() As Integer
        Get
            Return liId
        End Get
        Set(ByVal value As Integer)
            liId = value
        End Set
    End Property

    'Related to db table column name: EstateID
    Dim lsEstateID As String

    Public Property psEstateID() As String
        Get
            Return lsEstateID
        End Get
        Set(ByVal value As String)
            lsEstateID = value
        End Set
    End Property

    'Related to db table column name: ActiveMonthYearID
    Dim lsActiveMonthYearID As String
    Public Property psActiveMonthYearID() As String
        Get
            Return lsActiveMonthYearID
        End Get
        Set(ByVal value As String)
            lsActiveMonthYearID = value
        End Set
    End Property

    Dim lsVHWSCode As String

    Public Property psVHWSCode() As String
        Get
            Return lsVHWSCode
        End Get
        Set(ByVal value As String)
            lsVHWSCode = value
        End Set
    End Property

    'Related to procedure column name: TotalHrsOrKm
    Dim lsTotalHrsOrKm As String
    Public Property psTotalHrsOrKm() As String
        Get
            Return lsTotalHrsOrKm
        End Get
        Set(ByVal value As String)
            lsTotalHrsOrKm = value
        End Set
    End Property

    'Related to TABLE column name: LogDate
    Dim ldLogDateDT As DateTime
    Public Property pdLogDateDT() As DateTime
        Get
            Return ldLogDateDT
        End Get
        Set(ByVal value As DateTime)
            ldLogDateDT = value
        End Set
    End Property

End Class
