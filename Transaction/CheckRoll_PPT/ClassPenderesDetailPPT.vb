Public Class ClassPenderesDetailPPT
    Private _GradeMonthId As Integer
    Private _EmpId As String = String.Empty
    Private _Classes As String = String.Empty

    Public Property GradeMonthId() As Integer
        Get
            Return _GradeMonthId
        End Get
        Set(value As Integer)
            _GradeMonthId = value
        End Set
    End Property
    Public Property EmpId() As String
        Get
            Return _EmpId
        End Get
        Set(value As String)
            _EmpId = value
        End Set
    End Property
    Public Property Classes() As String
        Get
            Return _Classes
        End Get
        Set(value As String)
            _Classes = value
        End Set
    End Property
End Class