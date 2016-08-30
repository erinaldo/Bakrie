Imports System

Public Class VehicleGeneralPPT

    'type prop + TAB + TAB for property initialization

    Private lsEstateID As String

    Public Property psEstateID() As String
        Get
            Return lsEstateID
        End Get
        Set(ByVal value As String)
            lsEstateID = value
        End Set
    End Property

    'Private lsFormName As String
    'Public Property psFormName() As String
    '    Get
    '        Return lsFormName
    '    End Get
    '    Set(ByVal value As String)
    '        lsFormName = value
    '    End Set
    'End Property

    Private lsColumnName As String
    Public Property PsColumnName() As String
        Get
            Return lsColumnName
        End Get
        Set(ByVal value As String)
            lsColumnName = value
        End Set
    End Property

    Private lsTableName As String
    Public Property PsTableName() As String
        Get
            Return lsTableName
        End Get
        Set(ByVal value As String)
            lsTableName = value
        End Set
    End Property

    Private lsSchemaName As String
    Public Property PsSchemaName() As String
        Get
            Return lsSchemaName
        End Get
        Set(ByVal value As String)
            lsSchemaName = value
        End Set
    End Property

    Private lsFieldValue As String
    Public Property psFieldValue() As String
        Get
            Return lsFieldValue
        End Get
        Set(ByVal value As String)
            lsFieldValue = value
        End Set
    End Property

    Private lsFieldName As String
    Public Property psFieldName() As String
        Get
            Return lsFieldName
        End Get
        Set(ByVal value As String)
            lsFieldName = value
        End Set
    End Property


    Private ldActiveYear As String
    Public Property pdActiveYear() As String
        Get
            Return ldActiveYear
        End Get
        Set(ByVal value As String)
            ldActiveYear = value
        End Set
    End Property

    Private ldActiveMonth As String
    Public Property pdActiveMonth() As String
        Get
            Return ldActiveMonth
        End Get
        Set(ByVal value As String)
            ldActiveMonth = value
        End Set
    End Property

    Private lsActiveMonthYearID As String
    Public Property psActiveMonthYearID() As String
        Get
            Return lsActiveMonthYearID
        End Get
        Set(ByVal value As String)
            lsActiveMonthYearID = value
        End Set
    End Property

    Private ldFromDT As DateTime
    Public Property pdFromDT() As DateTime
        Get
            Return ldFromDT
        End Get
        Set(ByVal value As DateTime)
            ldFromDT = value
        End Set
    End Property

    Private ldToDT As DateTime
    Public Property pdToDT() As DateTime
        Get
            Return ldToDT
        End Get
        Set(ByVal value As DateTime)
            ldToDT = value
        End Set
    End Property

End Class
