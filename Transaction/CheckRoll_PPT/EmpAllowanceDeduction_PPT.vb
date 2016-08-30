'Jum'at, 28 Aug 2009, 15:35


Imports System

Public Class EmpAllowanceDeduction_PPT

#Region "Private Members Declarations"

    Private _EmpAllowDedID As String = String.Empty
    Private _EstateID As String = String.Empty
    Private _EmpID As String = String.Empty

    Private _AllowDedID As String = String.Empty
    Private _Amount As Double = 0.0
    Private _Type As String = String.Empty
    Private _StartDate As Date = Nothing
    Private _EndDates As Date = Date.Now

    Private _ConcurrencyId As Date = Date.Now
    Private _CreatedBy As String = String.Empty
    Private _CreatedOn As Date = DateTime.Now
    Private _ModifiedBy As String = String.Empty
    Private _ModifiedOn As Date = DateTime.Now

#End Region



#Region "Public Member Declarations"
    Public Property EmpAllowDedID() As String
        Get
            Return _EmpAllowDedID
        End Get
        Set(ByVal value As String)
            _EmpAllowDedID = value
        End Set
    End Property

    Public Property EstateID() As String
        Get
            Return _EstateID
        End Get
        Set(ByVal value As String)
            _EstateID = value
        End Set
    End Property

    Public Property EmpID() As String
        Get
            Return _EmpID
        End Get
        Set(ByVal value As String)
            _EmpID = value
        End Set
    End Property

    Public Property AllowDedID() As String
        Get
            Return _AllowDedID
        End Get
        Set(ByVal value As String)
            _AllowDedID = value
        End Set
    End Property

    Public Property Amount() As Double
        Get
            Return _Amount
        End Get
        Set(ByVal value As Double)
            _Amount = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
        End Set
    End Property

    Public Property StartDate() As Date
        Get
            Return _StartDate
        End Get
        Set(ByVal value As Date)
            _StartDate = value
        End Set
    End Property

    Public Property EndDates() As Date
        Get
            Return _EndDates
        End Get
        Set(ByVal value As Date)
            _EndDates = value
        End Set
    End Property

    Public Property ConcurrencyId() As Date
        Get
            Return _ConcurrencyId
        End Get
        Set(ByVal value As Date)
            _ConcurrencyId = value
        End Set
    End Property

    Public Property CreatedBy() As String
        Get
            Return _CreatedBy
        End Get
        Set(ByVal value As String)
            _CreatedBy = value
        End Set
    End Property

    Public Property CreatedOn() As Date
        Get
            Return _CreatedOn
        End Get
        Set(ByVal value As Date)
            _CreatedOn = value
        End Set
    End Property

    Public Property ModifiedBy() As String
        Get
            Return _ModifiedBy
        End Get
        Set(ByVal value As String)
            _ModifiedBy = value
        End Set
    End Property

    Public Property ModifiedOn() As Date
        Get
            Return _ModifiedOn
        End Get
        Set(ByVal value As Date)
            _ModifiedOn = value
        End Set
    End Property

#End Region

End Class