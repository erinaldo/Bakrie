Namespace Domain
    Public Class ProfileNameValue
        Public _name As String()
        Public _value As String()
        Public _field As String
        Public _id As String

        Public Property Id() As String
            Get
                Return _id
            End Get
            Set(value As String)
                _id = value
            End Set
        End Property

        Public Property Name() As String()
            Get
                Return _name
            End Get
            Set(value As String())
                _name = value
            End Set
        End Property

        Public Property Value() As String()
            Get
                Return _value
            End Get
            Set(value As String())
                _value = value
            End Set
        End Property

        Public Property Field() As String
            Get
                Return _field
            End Get
            Set(value As String)
                _field = value
            End Set
        End Property
    End Class
End Namespace