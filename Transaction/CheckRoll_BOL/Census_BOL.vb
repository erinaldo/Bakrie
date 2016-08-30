'
'
' Programmer: Dadang Adi H
' Created   : 15 Oct 2009

Imports CheckRoll_DAL

Public Class Census_BOL

    Public Shared Function CRCensusByDateSelect( _
        ByVal CensusStartDate As System.Nullable(Of Date), _
        ByVal CensusEndDate As System.Nullable(Of Date)) As DataTable

        Dim dt As DataTable
        dt = Census_DAL.CRCensusByDateSelect(CensusStartDate, CensusEndDate)

        Return dt
    End Function

    Public Shared Function UpdateCensus(ByVal objCensus As Census_DAL, ByRef DT As System.Data.DataTable) As Integer
        ' Jum'at, 16 Oct 2009, 15:15
        Return Census_DAL.UpdateCensus(objCensus, DT)
    End Function

End Class
