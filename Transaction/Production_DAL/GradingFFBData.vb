'Imports BSP.Base.DataAccess
'Imports BSP.Production.Entity
'Imports BSP.Base.Exception
'Imports System.Data.Common
'Imports BSP.Base.Business
'Imports System.Data
'Imports System.Data.SqlClient
Public Class GradingFFBData
    ' Inherits BaseData

#Region "Utility Methods"

    ' Public Overloads Shared Function GetConcurrencyId(ByVal id As String) As Byte()

    'dbCommand = GetStoredProcCommand("[Production].[GradingFFBConcurrencyId]")
    'AddOutParameter(dbCommand, "@GradingID", DbType.String, id)
    'Return ExecuteScalar(dbCommand)

    '  End Function

#End Region


    '#Region "Business Validation"

    '    Public Shared Function ValidateEntity(ByVal GradingFFB As GradingFFBEntity) As GradingFFBEntity

    '        dbCommand = GetStoredProcCommand("[Production].[GradingFFBIsExist]")

    '        If GradingFFB.WBTicketNo = String.Empty Then
    '            AddInParameter(dbCommand, "@WBTicketNo", DbType.String, DBNull.Value)
    '        Else
    '            AddInParameter(dbCommand, "@WBTicketNo", DbType.String, GradingFFB.WBTicketNo)
    '        End If


    '        Dim obj As Object = ExecuteScalar(dbCommand)
    '        If Not obj Is Nothing Then
    '            If obj <> 0 Then
    '                GradingFFB.IsTransactionSuccess = True
    '                GradingFFB.ErrorMessage = ""
    '                'Return GradingFFB
    '            Else
    '                GradingFFB.IsTransactionSuccess = False
    '                GradingFFB.ErrorMessage = "Invalid WBTicket No"
    '            End If

    '        End If

    '        Return GradingFFB


    '    End Function

    '    'Public Shared Function IsTicketNoValid(ByVal GradingFFB As GradingFFBEntity) As GradingFFBEntity
    '    '    Return GradingFFBData.ValidateEntity(GradingFFB)
    '    'End Function
    '#End Region

    '    Public Shared Function Save(ByVal gradingFFBEntity As GradingFFBEntity) As GradingFFBEntity

    '        Dim isInsert As Boolean = False

    '        If gradingFFBEntity.Pkey = String.Empty Then
    '            dbCommand = GetStoredProcCommand("[Production].[GradingFFBINSERT]")
    '            AddOutParameter(dbCommand, "@GradingID", DbType.String, 50)
    '           isInsert = True
    '        End If

    '        With gradingFFBEntity
    '            AddInParameter(dbCommand, "@EstateID", DbType.String, .EstateID)
    '            AddInParameter(dbCommand, "@ActiveMonthYearID", DbType.String, .ActiveMonthYearID)
    '            AddInParameter(dbCommand, "@WeighingID", DbType.String, .WeighingID)
    '            AddInParameter(dbCommand, "@GradingDate", DbType.Date, .GradingDate)
    '            AddInParameter(dbCommand, "@GradingTime", DbType.Time, .GradingTime)
    '            AddInParameter(dbCommand, "@MinMaturity", DbType.Decimal, .MinMaturity)
    '            AddInParameter(dbCommand, "@LosseFruitPerBunche", DbType.Decimal, .LosseFruitPerBunche)
    '            AddInParameter(dbCommand, "@UnripeFruitJ", DbType.Decimal, .UnripeFruitJ)
    '            AddInParameter(dbCommand, "@UnripeFruitP", DbType.Decimal, .UnripeFruitP)
    '            AddInParameter(dbCommand, "@UnripeFruitT", DbType.String, .UnripeFruitT)
    '            AddInParameter(dbCommand, "@UnderripeJ", DbType.Decimal, .UnderripeJ)
    '            AddInParameter(dbCommand, "@UnderripeP", DbType.Decimal, .UnderripeP)
    '            AddInParameter(dbCommand, "@UnderripeT", DbType.String, .UnderripeT)
    '            AddInParameter(dbCommand, "@RipeFruitJ", DbType.Decimal, .RipeFruitJ)
    '            AddInParameter(dbCommand, "@RipeFruitP", DbType.Decimal, .RipeFruitP)
    '            AddInParameter(dbCommand, "@RipeFruitT", DbType.String, .RipeFruitT)
    '            AddInParameter(dbCommand, "@OverRipeFruitJ", DbType.Decimal, .OverRipeFruitJ)
    '            AddInParameter(dbCommand, "@OverRipeFruitP", DbType.Decimal, .OverRipeFruitP)
    '            AddInParameter(dbCommand, "@OverRipeFruitT", DbType.String, .OverRipeFruitT)
    '            AddInParameter(dbCommand, "@EmptyBunchFruitJ", DbType.Decimal, .EmptyBunchFruitJ)
    '            AddInParameter(dbCommand, "@EmptyBunchFruitP", DbType.Decimal, .EmptyBunchFruitP)
    '            AddInParameter(dbCommand, "@EmptyBunchFruitT", DbType.String, .EmptyBunchFruitT)
    '            AddInParameter(dbCommand, "@TotalNormalFruitsJ", DbType.Decimal, .TotalNormalFruitsJ)
    '            AddInParameter(dbCommand, "@TotalNormalFruitsP", DbType.Decimal, .TotalNormalFruitsP)
    '            AddInParameter(dbCommand, "@TotalNormalFruitsT", DbType.String, .TotalNormalFruitsT)
    '            AddInParameter(dbCommand, "@PartheJ", DbType.Decimal, .PartheJ)
    '            AddInParameter(dbCommand, "@PartheP", DbType.Decimal, .PartheP)
    '            AddInParameter(dbCommand, "@PartheT", DbType.String, .PartheT)
    '            AddInParameter(dbCommand, "@HardBunchJ", DbType.Decimal, .HardBunchJ)
    '            AddInParameter(dbCommand, "@HardBunchP", DbType.Decimal, .HardBunchP)
    '            AddInParameter(dbCommand, "@HardBunchT", DbType.String, .HardBunchT)
    '            AddInParameter(dbCommand, "@TotalAbnormalFruitsJ", DbType.Decimal, .TotalAbnormalFruitsJ)
    '            AddInParameter(dbCommand, "@TotalAbnormalFruitsP", DbType.Decimal, .TotalAbnormalFruitsP)
    '            AddInParameter(dbCommand, "@TotalAbnormalFruitsT", DbType.String, .TotalAbnormalFruitsT)
    '            AddInParameter(dbCommand, "@GTActualBunchesJ", DbType.Decimal, .GTActualBunchesJ)
    '            AddInParameter(dbCommand, "@GTActualBunchesP", DbType.Decimal, .GTActualBunchesP)
    '            AddInParameter(dbCommand, "@GTActualBunchesT", DbType.Byte, Convert.ToByte(.GTActualBunchesT))
    '            AddInParameter(dbCommand, "@LooseFruitsP", DbType.Decimal, .LooseFruitsP)
    '            AddInParameter(dbCommand, "@KgOfLooseFruit", DbType.Decimal, .KgOfLooseFruit)
    '            AddInParameter(dbCommand, "@UnDamageJ", DbType.Decimal, .UnDamageJ)
    '            AddInParameter(dbCommand, "@UnDamageP", DbType.Decimal, .UnDamageP)
    '            AddInParameter(dbCommand, "@UnDamageT", DbType.String, .UnDamageT)
    '            AddInParameter(dbCommand, "@LightDamageJ", DbType.Decimal, .LightDamageJ)
    '            AddInParameter(dbCommand, "@LightDamageP", DbType.Decimal, .LightDamageP)
    '            AddInParameter(dbCommand, "@LightDamageT", DbType.String, .LightDamageT)
    '            AddInParameter(dbCommand, "@DamageJ", DbType.Decimal, .DamageJ)
    '            AddInParameter(dbCommand, "@DamageP", DbType.Decimal, .DamageP)
    '            AddInParameter(dbCommand, "@DamageT", DbType.String, .DamageT)
    '            AddInParameter(dbCommand, "@TotalJ", DbType.Decimal, .TotalJ)
    '            AddInParameter(dbCommand, "@TotalP", DbType.Decimal, .TotalP)
    '            AddInParameter(dbCommand, "@TotalT", DbType.String, .TotalT)
    '            AddInParameter(dbCommand, "@Comment", DbType.String, .Comment)
    '            '           AddInParameter(dbCommand, "@@ConcurrencyId", DbType.String, KernelStorage.Code)
    '            'AddInParameter(dbCommand, "@CreatedBy", DbType.String, .CreatedBy)
    '            'AddInParameter(dbCommand, "@CreatedOn", DbType.DateTime, .CreatedOn)
    '            'AddInParameter(dbCommand, "@ModifiedBy", DbType.String, .ModifiedBy)
    '            'AddInParameter(dbCommand, "@ModifiedOn", DbType.DateTime, .ModifiedOn)

    '        End With


    '        SetDefaultSaveParameters(dbCommand, gradingFFBEntity)

    '        Dim rowsAffected As Integer = ExecuteNonQuery(dbCommand)

    '        If isInsert Then
    '            If (rowsAffected <= 0) Then
    '                Throw New SaveOperationFailedException()
    '            End If
    '        Else
    '            If (rowsAffected <= 0) Then
    '                Throw New CustomSqlException(Common.Constants.SqlExceptionMessage.ConcurrencyViolation, New DBConcurrencyException)
    '            End If
    '        End If

    '        gradingFFBEntity.GradingID = GetParameterValue(dbCommand, "@GradingID")
    '        gradingFFBEntity.ConcurrencyId = GetParameterValue(dbCommand, Common.Constants.ConcurrencyParamName)
    '        gradingFFBEntity.IsTransactionSuccess = True

    '        Return gradingFFBEntity

    '    End Function

    '#Region "Public Select Methods"
    '    Public Shared Function GetWBTicketInfo(ByVal WBTicketInfo As GradingFFBEntity) As GradingFFBCollection

    '        dbCommand = GetStoredProcCommand("[Production].[WBTicketNoSearch]")

    '        AddInParameter(dbCommand, "@EstateID", DbType.String, WBTicketInfo.EstateID)
    '        AddInParameter(dbCommand, "@WBTicketNo", DbType.String, WBTicketInfo.WBTicketNo)
    '        Dim tempList As New GradingFFBCollection

    '        Using dataReader As IDataReader = ExecuteReader(dbCommand)
    '            While (dataReader.Read())
    '                tempList.Add(New GradingFFBEntity With { .WBTicketNo = dataReader("WBTicketNo")})

    '            End While
    '        End Using

    '        Return tempList
    '    End Function
    '    Public Shared Function GetSupplierVehicleInfo(ByVal WBTicketInfo As GradingFFBEntity) As GradingFFBEntity
    '        Dim StoreVehicleInfoEntity As GradingFFBEntity = Nothing

    '        dbCommand = GetStoredProcCommand("[Production].[GradingFFBWeighinInoutSelect]")

    '        AddInParameter(dbCommand, "@EstateID", DbType.String, WBTicketInfo.EstateID)
    '        AddInParameter(dbCommand, "@WBTicketNo", DbType.String, WBTicketInfo.WBTicketNo)
    '        Dim countRows As Integer = 0
    '        Using dataReader As IDataReader = ExecuteReader(dbCommand)

    '            While (dataReader.Read())
    '                StoreVehicleInfoEntity = FillStoreVehicleList(dataReader, WBTicketInfo)
    '                countRows = countRows + 1
    '            End While
    '        End Using
    '        WBTicketInfo.CountReaderRows = countRows

    '        Return StoreVehicleInfoEntity
    '    End Function
    '    Public Shared Function GetSupplierVehicleInfoList(ByVal WBTicketInfo As GradingFFBEntity) As GradingFFBCollection
    '        Dim tempList As New GradingFFBCollection()

    '        dbCommand = GetStoredProcCommand("[Production].[GradingFFBWeighinInoutSelect]")

    '        AddInParameter(dbCommand, "@EstateID", DbType.String, WBTicketInfo.EstateID)
    '        AddInParameter(dbCommand, "@WBTicketNo", DbType.String, WBTicketInfo.WBTicketNo)
    '        Dim countRows As Integer = 0
    '        Using dataReader As IDataReader = ExecuteReader(dbCommand)

    '            While (dataReader.Read())
    '                'tempList.Add(FillStoreVehicleList(dataReader, WBTicketInfo))
    '                tempList.Add(New GradingFFBEntity With {.Div = dataReader("Div"), .Yop = dataReader("YOP"), .Block = dataReader("Block"), .TotalBunches = dataReader("Qty")})

    '                countRows = countRows + 1
    '            End While
    '        End Using
    '        WBTicketInfo.CountReaderRows = countRows

    '        Return tempList
    '    End Function

    '    'Public Shared Function GetWBTicketNo(ByVal WBTicketNo As GradingFFBEntity) As GradingFFBCollection

    '    '    'dbCommand = GetStoredProcCommand("[Production].[WBTicketNoSelect]")

    '    '    'AddInParameter(dbCommand, "@EstateID", DbType.String, WBTicketNo.EstateID)
    '    '    'AddInParameter(dbCommand, "@Others", DbType.Int32, WBTicketNo.Others)
    '    '    Dim tempList As New GradingFFBCollection

    '    '    'Using dataReader As IDataReader = ExecuteReader(dbCommand)
    '    '    '    While (dataReader.Read())
    '    '    '        tempList.Add(New WBWeighingInOutEntity With {.WBTicketNo = dataReader("WBTicketNo")})

    '    '    '    End While
    '    '    'End Using

    '    '    Return tempList
    '    'End Function
    '    Public Shared Function GetItem(ByVal id As String) As KernelStorageEntity

    '        Dim KernelStorage As KernelStorageEntity = Nothing
    '        dbCommand = GetStoredProcCommand("[Production].[KernelStorageSelect]")

    '        AddInParameter(dbCommand, "@KernelStorageID", DbType.String, id)
    '        AddInParameter(dbCommand, "@Code", DbType.String, DBNull.Value)
    '        AddInParameter(dbCommand, "@Descp", DbType.String, DBNull.Value)
    '        AddInParameter(dbCommand, "@EstateID", DbType.String, DBNull.Value)


    '        Using dataReader As IDataReader = ExecuteReader(dbCommand)
    '            If dataReader.Read() Then
    '                KernelStorage = FillData(dataReader)
    '            End If
    '        End Using

    '        Return KernelStorage

    '    End Function
    '    Public Shared Function Getlist() As KernelStorageCollection


    '        dbCommand = GetStoredProcCommand("[Production].[KernelStorageSelect]")

    '        AddInParameter(dbCommand, "@KernelStorageID", DbType.String, DBNull.Value)
    '        AddInParameter(dbCommand, "@Code", DbType.String, DBNull.Value)
    '        AddInParameter(dbCommand, "@Descp", DbType.String, DBNull.Value)

    '        AddInParameter(dbCommand, "@EstateID", DbType.String, DBNull.Value)


    '        Return Getlist(dbCommand)

    '    End Function
    '    Public Shared Function GetList(ByVal KernelStorage As KernelStorageEntity) As KernelStorageCollection

    '        dbCommand = GetStoredProcCommand("[Production].[KernelStorageSelect]")

    '        AddInParameter(dbCommand, "@KernelStorageID", DbType.String, DBNull.Value)
    '        AddInParameter(dbCommand, "@Code", DbType.String, KernelStorage.Code)
    '        AddInParameter(dbCommand, "@Descp", DbType.String, KernelStorage.Descp)

    '        AddInParameter(dbCommand, "@EstateID", DbType.String, KernelStorage.EstateID)


    '        Return GetList(dbCommand)

    '    End Function

    '#End Region


    '#Region "Delete Method"

    '    Public Shared Function Delete(ByVal id As String) As Boolean

    '        Dim result As Integer = 0
    '        dbCommand = GetStoredProcCommand("[Production].[KernelStorageDelete]")
    '        AddInParameter(dbCommand, "@KernelStorageID", DbType.String, id)
    '        result = ExecuteNonQuery(dbCommand)
    '        Return result

    '    End Function

    '#End Region


    '#Region "Private Select Methods Helpers"
    '    Private Shared Function GetList(ByVal dbCommand As DbCommand) As KernelStorageCollection

    '        Dim tempList As New KernelStorageCollection

    '        Using dataReader As IDataReader = ExecuteReader(dbCommand)
    '            While (dataReader.Read())
    '                tempList.Add(FillData(dataReader))
    '            End While
    '        End Using

    '        Return tempList

    '    End Function
    '    Private Shared Function FillData(ByVal dataReader As IDataReader) As KernelStorageEntity

    '        Dim KernelStorage As KernelStorageEntity = FillDefaults(dataReader, New KernelStorageEntity)

    '        With KernelStorage

    '            GetReaderValue(.KernelStorageID, dataReader("KernelStorageID"))
    '            GetReaderValue(.Code, dataReader("Code"))
    '            GetReaderValue(.Descp, dataReader("Descp"))
    '            GetReaderValue(.Type, dataReader("Type"))
    '            GetReaderValue(.Capacity, dataReader("Capacity"))
    '            GetReaderValue(.BFQty, dataReader("BFQty"))


    '        End With

    '        Return KernelStorage

    '    End Function

    '    Private Shared Function FillStoreVehicleList(ByVal dataReader As IDataReader, ByVal FFBentity As GradingFFBEntity) As GradingFFBEntity

    '        With FFBentity
    '            GetReaderValue(.SupplierName, dataReader("Name"))
    '            GetReaderValue(.NetWeight, dataReader("NetWeight"))
    '            GetReaderValue(.FFBDeliveryOrderNo, dataReader("FFBDeliveryOrderNo"))
    '            GetReaderValue(.ArrivedDate, dataReader("WeighingDate"))
    '            GetReaderValue(.ArrivedTime, dataReader("WeighingTime").ToString())
    '            GetReaderValue(.Driver, dataReader("DriverName"))
    '            GetReaderValue(.Vehicle, dataReader("VHNo"))
    '            GetReaderValue(.NoOfTrip, dataReader("NoTrip").ToString())
    '            GetReaderValue(.TotalBunches, dataReader("Qty"))
    '            GetReaderValue(.WeighingID, dataReader("WeighingID"))
    '        End With

    '        Return FFBentity

    '    End Function
    '#End Region

End Class
