Public Class WBWeighingInOutPPT
#Region "Private Member Declarations"
    Private _SerialNo As String = String.Empty
    Private _OtherSerialNo As String = String.Empty
    Private _EstateID As String = String.Empty
    Private _EstateCode As String = String.Empty
    Private _WeighingID As String = String.Empty
    Private _ActiveMonthYearID As String = String.Empty
    Private _WeighingDate As Date
    Private _WeighingTime As String = String.Empty
    Private _Section As String = String.Empty
    Private _Others As Boolean
    Private _WBTicketNo As String = String.Empty
    Private _FFBDeliveryOrderNo As String = String.Empty
    Private _SupplierCustID As String = String.Empty
    Private _SupplierDetID As String = String.Empty
    Private _FieldBlockSetupID As String = String.Empty
    Private _ProductID As String = String.Empty
    Private _Supplier As String = String.Empty
    Private _VehicleCode As String = String.Empty
    Private _ProductCode As String = String.Empty
    Private _SupplierCodeSearch As String = String.Empty
    Private _VehicleCodeSearch As String = String.Empty
    Private _ProductCodeSearch As String = String.Empty
    Private _SupplierNameSearch As String = String.Empty
    Private _VehicleDescSearch As String = String.Empty
    Private _ProductDescSearch As String = String.Empty
    Private _Company As String = String.Empty
    Private _DriverName As String = String.Empty
    Private _NoTrip As Integer
    Private _FirstWeight As Double = 0.0
    Private _SecondWeight As Double = 0.0
    Private _NetWeight As Double = 0.0
    Private _ManualWeight As Boolean
    Private _Remarks As String = String.Empty
    Private _Division As String = String.Empty
    Private _YOP As String = String.Empty
    Private _Block As String = String.Empty
    Private _TPH As String = String.Empty
    Private _Ketek As String = String.Empty
    Private _WeighingBlockID As String = String.Empty
    Private _QtyFFB As Double = 0.0
    'Private _LooseFruit As Double = 0.0
    Private _FFBDeduction As Double = 0.0
    Private _Usercode As String = String.Empty
    Private _Password As String = String.Empty
    Private _TimeOut As String = String.Empty
    Private _FYear As Integer
    Private _Period As Integer
    Private _Weight As String = String.Empty
    Private _NOTFBDetails As Boolean

    Public Property Loosefruit As Double = 0.0
#End Region

#Region "Public Member Declarations"
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

    Public Property EstateID() As String
        Get
            Return _EstateID
        End Get
        Set(ByVal value As String)
            _EstateID = value
        End Set
    End Property

    Public Property EstateCode() As String
        Get
            Return _EstateCode
        End Get
        Set(ByVal value As String)
            _EstateCode = value
        End Set
    End Property

    Public Property WeighingID() As String
        Get
            Return _WeighingID
        End Get
        Set(ByVal value As String)
            _WeighingID = value
        End Set
    End Property

    Public Property ActiveMonthYearID() As String
        Get
            Return _ActiveMonthYearID
        End Get
        Set(ByVal value As String)
            _ActiveMonthYearID = value
        End Set
    End Property

    Public Property WeighingDate() As Date
        Get
            Return _WeighingDate
        End Get
        Set(ByVal value As Date)
            _WeighingDate = value
        End Set
    End Property

    Public Property WeighingTime() As String
        Get
            Return _WeighingTime
        End Get
        Set(ByVal value As String)
            _WeighingTime = value
        End Set
    End Property

    Public Property Section() As String
        Get
            Return _Section
        End Get
        Set(ByVal value As String)
            _Section = value
        End Set
    End Property

    Public Property Others() As Boolean
        Get
            Return _Others
        End Get
        Set(ByVal value As Boolean)
            _Others = value
        End Set
    End Property

    Public Property WBTicketNo() As String
        Get
            Return _WBTicketNo
        End Get
        Set(ByVal value As String)
            _WBTicketNo = value
        End Set
    End Property

    Public Property FFBDeliveryOrderNo() As String
        Get
            Return _FFBDeliveryOrderNo
        End Get
        Set(ByVal value As String)
            _FFBDeliveryOrderNo = value
        End Set
    End Property

    Public Property SupplierCustID() As String
        Get
            Return _SupplierCustID
        End Get
        Set(ByVal value As String)
            _SupplierCustID = value
        End Set
    End Property

    Public Property SupplierDetID() As String
        Get
            Return _SupplierDetID
        End Get
        Set(ByVal value As String)
            _SupplierDetID = value
        End Set
    End Property

    Public Property FieldBlockSetupID() As String
        Get
            Return _FieldBlockSetupID
        End Get
        Set(ByVal value As String)
            _FieldBlockSetupID = value
        End Set
    End Property

    Public Property ProductID() As String
        Get
            Return _ProductID
        End Get
        Set(ByVal value As String)
            _ProductID = value
        End Set
    End Property

    Public Property Supplier() As String
        Get
            Return _Supplier
        End Get
        Set(ByVal value As String)
            _Supplier = value
        End Set
    End Property

    Public Property SupplierCodeSearch() As String
        Get
            Return _SupplierCodeSearch
        End Get
        Set(ByVal value As String)
            _SupplierCodeSearch = value
        End Set
    End Property

    Public Property SupplierNameSearch() As String
        Get
            Return _SupplierNameSearch
        End Get
        Set(ByVal value As String)
            _SupplierNameSearch = value
        End Set
    End Property

    Public Property VehicleCode() As String
        Get
            Return _VehicleCode
        End Get
        Set(ByVal value As String)
            _VehicleCode = value
        End Set
    End Property

    Public Property VehicleCodeSearch() As String
        Get
            Return _VehicleCodeSearch
        End Get
        Set(ByVal value As String)
            _VehicleCodeSearch = value
        End Set
    End Property

    Public Property VehicleDescSearch() As String
        Get
            Return _VehicleDescSearch
        End Get
        Set(ByVal value As String)
            _VehicleDescSearch = value
        End Set
    End Property

    Public Property ProductCode() As String
        Get
            Return _ProductCode
        End Get
        Set(ByVal value As String)
            _ProductCode = value
        End Set
    End Property

    Public Property ProductCodeSearch() As String
        Get
            Return _ProductCodeSearch
        End Get
        Set(ByVal value As String)
            _ProductCodeSearch = value
        End Set
    End Property

    Public Property ProductDescSearch() As String
        Get
            Return _ProductDescSearch
        End Get
        Set(ByVal value As String)
            _ProductDescSearch = value
        End Set
    End Property

    Public Property Company() As String
        Get
            Return _Company
        End Get
        Set(ByVal value As String)
            _Company = value
        End Set
    End Property

    Public Property DriverName() As String
        Get
            Return _DriverName
        End Get
        Set(ByVal value As String)
            _DriverName = value
        End Set
    End Property

    Public Property NoTrip() As Integer
        Get
            Return _NoTrip
        End Get
        Set(ByVal value As Integer)
            _NoTrip = value
        End Set
    End Property

    Public Property FirstWeight() As Double
        Get
            Return _FirstWeight
        End Get
        Set(ByVal value As Double)
            _FirstWeight = value
        End Set
    End Property

    Public Property SecondWeight() As Double
        Get
            Return _SecondWeight
        End Get
        Set(ByVal value As Double)
            _SecondWeight = value
        End Set
    End Property

    Public Property NetWeight() As Double
        Get
            Return _NetWeight
        End Get
        Set(ByVal value As Double)
            _NetWeight = value
        End Set
    End Property

    Public Property ManualWeight() As Boolean
        Get
            Return _ManualWeight
        End Get
        Set(ByVal value As Boolean)
            _ManualWeight = value
        End Set
    End Property

    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    Public Property Division() As String
        Get
            Return _Division
        End Get
        Set(ByVal value As String)
            _Division = value
        End Set
    End Property

    Public Property YOP() As String
        Get
            Return _YOP
        End Get
        Set(ByVal value As String)
            _YOP = value
        End Set
    End Property

    Public Property Block() As String
        Get
            Return _Block
        End Get
        Set(ByVal value As String)
            _Block = value
        End Set
    End Property

    Public Property TPH() As String
        Get
            Return _TPH
        End Get
        Set(ByVal value As String)
            _TPH = value
        End Set
    End Property

    Public Property Ketek() As String
        Get
            Return _Ketek
        End Get
        Set(ByVal value As String)
            _Ketek = value
        End Set
    End Property

    Public Property WeighingBlockID() As String
        Get
            Return _WeighingBlockID
        End Get
        Set(ByVal value As String)
            _WeighingBlockID = value
        End Set
    End Property

    Public Property QtyFFB() As Double
        Get
            Return _QtyFFB
        End Get
        Set(ByVal value As Double)
            _QtyFFB = value
        End Set
    End Property

    Public Property FFBDeduction() As Double
        Get
            Return _FFBDeduction
        End Get
        Set(ByVal value As Double)
            _FFBDeduction = value
        End Set
    End Property

    Public Property Usercode() As String
        Get
            Return _Usercode
        End Get
        Set(ByVal value As String)
            _Usercode = value
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

    Public Property TimeOut() As String
        Get
            Return _TimeOut
        End Get
        Set(ByVal value As String)
            _TimeOut = value
        End Set
    End Property

    Public Property FYear() As Integer
        Get
            Return _FYear
        End Get
        Set(ByVal value As Integer)
            _FYear = value
        End Set
    End Property

    Public Property Period() As Integer
        Get
            Return _Period
        End Get
        Set(ByVal value As Integer)
            _Period = value
        End Set
    End Property

    Public Property Weight() As String
        Get
            Return _Weight
        End Get
        Set(ByVal value As String)
            _Weight = value
        End Set
    End Property

    Public Property NOTFBDetails() As Boolean
        Get
            Return _NOTFBDetails
        End Get
        Set(ByVal value As Boolean)
            _NOTFBDetails = value
        End Set
    End Property

    'Public Property LooseFruit() As Double
    '    Get
    '        Return _LooseFruit
    '    End Get
    '    Set(ByVal value As Double)
    '        _LooseFruit = value
    '    End Set
    'End Property

#End Region
End Class

