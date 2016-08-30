Public Class WBTicketNoConfigurationPPT
#Region "Private Member Declarations"
    Private _WBTicketNoConfigID As String = String.Empty
    Private _estateID As String = String.Empty
    Private _SerialNo As String = String.Empty
    Private _OtherSerialNo As String = String.Empty
    Private _UserName As String = String.Empty
    Private _Password As String = String.Empty
    Private _NewPassword As String = String.Empty
#End Region

#Region "Public Member Declarations"

    Public Property WBTicketNoConfigID() As String
        Get
            Return _WBTicketNoConfigID
        End Get
        Set(ByVal value As String)
            _WBTicketNoConfigID = value
        End Set
    End Property

    Public Property EstateID() As String
        Get
            Return _estateID
        End Get
        Set(ByVal value As String)
            _estateID = value
        End Set

    End Property

    Public Property SerialNo() As String
        Get
            Return _SerialNo
        End Get
        Set(ByVal value As String)
            _SerialNo = value
        End Set
    End Property

    Public Property OtherSerialNo() As String
        Get
            Return _OtherSerialNo
        End Get
        Set(ByVal value As String)
            _OtherSerialNo = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property

    Public Property NewPassword() As String
        Get
            Return _NewPassword
        End Get
        Set(ByVal value As String)
            _NewPassword = value
        End Set
    End Property
#End Region
End Class
