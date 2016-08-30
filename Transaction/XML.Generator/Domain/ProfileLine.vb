Namespace Domain
    Public Class ProfileLine
        Public _line As String
        Public _LTName As String()
        Public _fields As String
        Public _id As String
        Public _profileNameValue As IEnumerable(Of ProfileNameValue)

        Public Property Id() As String
            Get
                Return _id
            End Get
            Set(value As String)
                _id = value
            End Set
        End Property

        Public Property ProfileNameValue() As IEnumerable(Of ProfileNameValue)
            Get
                Return _profileNameValue
            End Get
            Set(value As IEnumerable(Of ProfileNameValue))
                _profileNameValue = value
            End Set
        End Property

        Public Property Line() As String
            Get
                Return _line
            End Get
            Set(value As String)
                _line = value
            End Set
        End Property
        Public Property LTName() As String()
            Get
                Return _LTName
            End Get
            Set(value As String())
                _LTName = value
            End Set
        End Property
        Public Property Fields() As String
            Get
                Return _fields
            End Get
            Set(value As String)
                _fields = value
            End Set
        End Property
    End Class
End Namespace