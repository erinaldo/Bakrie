Public Class DailyProductionKCPPPT

    Private _ProductionDate As Date

    Public Property ProductionDate() As Date
        Get
            Return _ProductionDate
        End Get
        Set(ByVal value As Date)
            _ProductionDate = value
        End Set
    End Property
End Class
