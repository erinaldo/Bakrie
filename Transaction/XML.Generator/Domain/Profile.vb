Namespace Domain
    Public Class Profile
        Public _nameXML As String
        Public _firstTag As String
        Public _secondTag As String
        Public _creator As String()
        Public _descr As String()
        Public _reqStatus As String()

        Public Property NameXML() As String
            Get
                Return _nameXML
            End Get
            Set(value As String)
                _nameXML = value
            End Set
        End Property

        Public Property FirstTag() As String
            Get
                Return _firstTag
            End Get
            Set(value As String)
                _firstTag = value
            End Set
        End Property

        Public Property SecondTag() As String
            Get
                Return _secondTag
            End Get
            Set(value As String)
                _secondTag = value
            End Set
        End Property

        Public Property Creator() As String()
            Get
                Return _creator
            End Get
            Set(value As String())
                _creator = value
            End Set
        End Property

        Public Property Descr() As String()
            Get
                Return _descr
            End Get
            Set(value As String())
                _descr = value
            End Set
        End Property

        Public Property ReqStatus() As String()
            Get
                Return _reqStatus
            End Get
            Set(value As String())
                _reqStatus = value
            End Set
        End Property

    End Class
End Namespace