Public Class ImportAllowancePPT
    Private _empAllowDedID As String = String.Empty
    Private _estateID As String = String.Empty
    Private _estateCode As String = String.Empty
    Private _empID As String = String.Empty
    Private _allowDedID As String = String.Empty
    Private _amount As String = String.Empty
    Private _type As String = String.Empty
    Private _startDate As DateTime
    Private _endDate As DateTime
    Private Shared _fileName As String = String.Empty

    Public Shared Property fileName() As String
        Get
            Return _fileName
        End Get
        Set(value As String)
            _fileName = value
        End Set
    End Property
    Public Property empAllowDedID() As String
        Get
            Return _empAllowDedID
        End Get
        Set(value As String)
            _empAllowDedID = value
        End Set
    End Property
    Public Property estateID As String
        Get
            Return _estateID
        End Get
        Set(value As String)
            _estateID = value
        End Set
    End Property
    Public Property estateCode() As String
        Get
            Return _estateCode
        End Get
        Set(value As String)
            _estateCode = value
        End Set
    End Property
    Public Property empID() As String
        Get
            Return _empID
        End Get
        Set(value As String)
            _empID = value
        End Set
    End Property

    Public Property allowDedID() As String
        Get
            Return _allowDedID
        End Get
        Set(value As String)
            _allowDedID = value
        End Set
    End Property

    Public Property amount() As String
        Get
            Return _amount
        End Get
        Set(value As String)
            _amount = value
        End Set
    End Property

    Public Property type() As String
        Get
            Return _type
        End Get
        Set(value As String)
            _type = value
        End Set
    End Property

    Public Property startDate() As DateTime
        Get
            Return _startDate
        End Get
        Set(value As DateTime)
            _startDate = value
        End Set
    End Property

    Public Property endDate() As DateTime
        Get
            Return _endDate
        End Get
        Set(value As DateTime)
            _endDate = value
        End Set
    End Property

    Public _saveError As String
    Public Property SaveError() As String
        Get
            Return _saveError
        End Get
        Set(value As String)
            _saveError = value
        End Set
    End Property
End Class
