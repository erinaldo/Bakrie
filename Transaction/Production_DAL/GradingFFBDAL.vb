Imports Production_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class GradingFFBDAL


    Public Shared Function SaveGradingFFB(ByVal ObjGradingFFBPPT As GradingFFBPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(89) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@WeighingID", ObjGradingFFBPPT.WeighingID)
        Parms(3) = New SqlParameter("@GradingDate", ObjGradingFFBPPT.GradingDate)
        Parms(4) = New SqlParameter("@GradingTime", ObjGradingFFBPPT.GradingTime)
        Parms(5) = New SqlParameter("@MinMaturity", ObjGradingFFBPPT.MinMaturity)
        Parms(6) = New SqlParameter("@LosseFruitPerBunche", ObjGradingFFBPPT.LosseFruitPerBunche)
        Parms(7) = New SqlParameter("@UnripeFruitJ", ObjGradingFFBPPT.UnripeFruitJ)
        Parms(8) = New SqlParameter("@UnripeFruitP", ObjGradingFFBPPT.UnripeFruitP)
        Parms(9) = New SqlParameter("@UnripeFruitT", ObjGradingFFBPPT.UnripeFruitT)
        Parms(10) = New SqlParameter("@UnderripeJ", ObjGradingFFBPPT.UnderripeJ)
        Parms(11) = New SqlParameter("@UnderripeP", ObjGradingFFBPPT.UnderripeP)
        Parms(12) = New SqlParameter("@UnderripeT", ObjGradingFFBPPT.UnderripeT)
        Parms(13) = New SqlParameter("@RipeFruitJ", ObjGradingFFBPPT.RipeFruitJ)
        Parms(14) = New SqlParameter("@RipeFruitP", ObjGradingFFBPPT.RipeFruitP)
        Parms(15) = New SqlParameter("@RipeFruitT", ObjGradingFFBPPT.RipeFruitT)
        Parms(16) = New SqlParameter("@OverRipeFruitJ", ObjGradingFFBPPT.OverRipeFruitJ)
        Parms(17) = New SqlParameter("@OverRipeFruitP", ObjGradingFFBPPT.OverRipeFruitP)
        Parms(18) = New SqlParameter("@OverRipeFruitT", ObjGradingFFBPPT.OverRipeFruitT)
        Parms(19) = New SqlParameter("@EmptyBunchFruitJ", ObjGradingFFBPPT.EmptyBunchFruitJ)
        Parms(20) = New SqlParameter("@EmptyBunchFruitP", ObjGradingFFBPPT.EmptyBunchFruitP)
        Parms(21) = New SqlParameter("@EmptyBunchFruitT", ObjGradingFFBPPT.EmptyBunchFruitT)
        Parms(22) = New SqlParameter("@TotalNormalFruitsJ", ObjGradingFFBPPT.TotalNormalFruitsJ)
        Parms(23) = New SqlParameter("@TotalNormalFruitsP", ObjGradingFFBPPT.TotalNormalFruitsP)
        Parms(24) = New SqlParameter("@TotalNormalFruitsT", ObjGradingFFBPPT.TotalNormalFruitsT)
        Parms(25) = New SqlParameter("@PartheJ", ObjGradingFFBPPT.PartheJ)
        Parms(26) = New SqlParameter("@PartheP", ObjGradingFFBPPT.PartheP)
        Parms(27) = New SqlParameter("@PartheT", ObjGradingFFBPPT.PartheT)
        Parms(28) = New SqlParameter("@HardBunchJ", ObjGradingFFBPPT.HardBunchJ)
        Parms(29) = New SqlParameter("@HardBunchP", ObjGradingFFBPPT.HardBunchP)
        Parms(30) = New SqlParameter("@HardBunchT", ObjGradingFFBPPT.HardBunchT)
        Parms(31) = New SqlParameter("@TotalAbnormalFruitsJ", ObjGradingFFBPPT.TotalAbnormalFruitsJ)
        Parms(32) = New SqlParameter("@TotalAbnormalFruitsP", ObjGradingFFBPPT.TotalAbnormalFruitsP)
        Parms(33) = New SqlParameter("@TotalAbnormalFruitsT", ObjGradingFFBPPT.TotalAbnormalFruitsT)
        Parms(34) = New SqlParameter("@GTActualBunchesJ", ObjGradingFFBPPT.GTActualBunchesJ)
        Parms(35) = New SqlParameter("@GTActualBunchesP", ObjGradingFFBPPT.GTActualBunchesP)
        Parms(36) = New SqlParameter("@GTActualBunchesT", ObjGradingFFBPPT.GTActualBunchesT)
        Parms(37) = New SqlParameter("@LooseFruitsP", ObjGradingFFBPPT.LooseFruitsP)
        Parms(38) = New SqlParameter("@KgOfLooseFruit", ObjGradingFFBPPT.KgOfLooseFruit)


        Parms(39) = New SqlParameter("@LightDamageJ", ObjGradingFFBPPT.LightDamageJ)
        Parms(40) = New SqlParameter("@LightDamageP", ObjGradingFFBPPT.LightDamageP)
        Parms(41) = New SqlParameter("@LightDamageT", ObjGradingFFBPPT.LightDamageT)


        Parms(42) = New SqlParameter("@TotalJ", ObjGradingFFBPPT.TotalJ)
        Parms(43) = New SqlParameter("@TotalP", ObjGradingFFBPPT.TotalP)
        Parms(44) = New SqlParameter("@TotalT", ObjGradingFFBPPT.TotalT)
        Parms(45) = New SqlParameter("@Comment", IIf(ObjGradingFFBPPT.Comment <> String.Empty, ObjGradingFFBPPT.Comment, DBNull.Value))

        Parms(46) = New SqlParameter("@LongStalksJ", ObjGradingFFBPPT.LongStalksJ)
        Parms(47) = New SqlParameter("@DirtAndStonesJ", ObjGradingFFBPPT.DirtAndStonesJ)
        Parms(48) = New SqlParameter("@SmallBunchesJ", ObjGradingFFBPPT.SmallBunchesJ)
        Parms(49) = New SqlParameter("@BuahRestanJ", ObjGradingFFBPPT.BuahRestanJ)
        Parms(50) = New SqlParameter("@MediumDamageJ", ObjGradingFFBPPT.MediumDamageJ)
        Parms(51) = New SqlParameter("@UnripeFruitComment", ObjGradingFFBPPT.UnripeFruitComment)
        Parms(52) = New SqlParameter("@UnderRipeComment", ObjGradingFFBPPT.UnderRipeComment)
        Parms(53) = New SqlParameter("@OverRipeFruitComment", ObjGradingFFBPPT.OverRipeFruitComment)
        Parms(54) = New SqlParameter("@EmptyBunchFruitComment", ObjGradingFFBPPT.EmptyBunchFruitComment)
        Parms(55) = New SqlParameter("@LongStalksComment", ObjGradingFFBPPT.LongStalksComment)
        Parms(56) = New SqlParameter("@LooseFruitsComment", ObjGradingFFBPPT.LooseFruitsComment)
        Parms(57) = New SqlParameter("@DirtAndStonesComment", ObjGradingFFBPPT.DirtAndStonesComment)
        Parms(58) = New SqlParameter("@SmallBunchesComment", ObjGradingFFBPPT.SmallBunchesComment)
        Parms(59) = New SqlParameter("@BuahRestanComment", ObjGradingFFBPPT.BuahRestanComment)
        Parms(60) = New SqlParameter("@HardBunchComment", ObjGradingFFBPPT.HardBunchComment)
        Parms(61) = New SqlParameter("@PartheComment", ObjGradingFFBPPT.PartheComment)
        Parms(62) = New SqlParameter("@LightDamageComment", ObjGradingFFBPPT.LightDamageComment)


        Parms(63) = New SqlParameter("@TotalBunches", ObjGradingFFBPPT.TotalBunches)
        Parms(64) = New SqlParameter("@DocumentNumber", ObjGradingFFBPPT.DocumentNumber)
        Parms(65) = New SqlParameter("@TotalGradedBunches", ObjGradingFFBPPT.TotalGradedBunches)

        Parms(66) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(67) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(68) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(69) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(70) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(71) = New SqlParameter("@BatuKerikil", ObjGradingFFBPPT.BatuKerikil)

        Parms(72) = New SqlParameter("@RipeComment", ObjGradingFFBPPT.RipeComment)
        Parms(73) = New SqlParameter("@BunchStalkNotCutJ", ObjGradingFFBPPT.BunchStalkNotCutJ)
        Parms(74) = New SqlParameter("@BunchStalkNotCutComment", ObjGradingFFBPPT.BunchStalkNotCutComment)
        Parms(75) = New SqlParameter("@RottenBunchJ", ObjGradingFFBPPT.RottenBunchJ)
        Parms(76) = New SqlParameter("@RottenBunchComment", ObjGradingFFBPPT.RottenBunchComment)
        Parms(77) = New SqlParameter("@BuahRestan1to2J", ObjGradingFFBPPT.BuahRestan1to2J)
        Parms(78) = New SqlParameter("@BuahRestan1to2Comment", ObjGradingFFBPPT.BuahRestan1to2Comment)
        Parms(79) = New SqlParameter("@BinNumber", ObjGradingFFBPPT.BinNumber)
        Parms(80) = New SqlParameter("@Abnormal", ObjGradingFFBPPT.Abnormal)
        Parms(81) = New SqlParameter("@AbnormalComment", ObjGradingFFBPPT.AbnormalComment)


        Parms(82) = New SqlParameter("@UnDamageJ", DBNull.Value)
        Parms(83) = New SqlParameter("@UnDamageP", DBNull.Value)
        Parms(84) = New SqlParameter("@UnDamageT", DBNull.Value)

        Parms(85) = New SqlParameter("@DamageJ", DBNull.Value)
        Parms(86) = New SqlParameter("@DamageP", DBNull.Value)
        Parms(87) = New SqlParameter("@DamageT", DBNull.Value)

        Parms(88) = New SqlParameter("@MediumDamageComment", DBNull.Value)
        Parms(89) = New SqlParameter("@DamageComment", DBNull.Value)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[GradingFFBInsert]", Parms)
        Return ds

    End Function

    Public Shared Function UpDateGradingFFB(ByVal ObjGradingFFBPPT As GradingFFBPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(87) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@WeighingID", ObjGradingFFBPPT.WeighingID)
        Parms(3) = New SqlParameter("@GradingDate", ObjGradingFFBPPT.GradingDate)
        Parms(4) = New SqlParameter("@GradingTime", ObjGradingFFBPPT.GradingTime)
        Parms(5) = New SqlParameter("@MinMaturity", ObjGradingFFBPPT.MinMaturity)
        Parms(6) = New SqlParameter("@LosseFruitPerBunche", ObjGradingFFBPPT.LosseFruitPerBunche)
        Parms(7) = New SqlParameter("@UnripeFruitJ", ObjGradingFFBPPT.UnripeFruitJ)
        Parms(8) = New SqlParameter("@UnripeFruitP", ObjGradingFFBPPT.UnripeFruitP)
        Parms(9) = New SqlParameter("@UnripeFruitT", ObjGradingFFBPPT.UnripeFruitT)
        Parms(10) = New SqlParameter("@UnderripeJ", ObjGradingFFBPPT.UnderripeJ)
        Parms(11) = New SqlParameter("@UnderripeP", ObjGradingFFBPPT.UnderripeP)
        Parms(12) = New SqlParameter("@UnderripeT", ObjGradingFFBPPT.UnderripeT)
        Parms(13) = New SqlParameter("@RipeFruitJ", ObjGradingFFBPPT.RipeFruitJ)
        Parms(14) = New SqlParameter("@RipeFruitP", ObjGradingFFBPPT.RipeFruitP)
        Parms(15) = New SqlParameter("@RipeFruitT", ObjGradingFFBPPT.RipeFruitT)
        Parms(16) = New SqlParameter("@OverRipeFruitJ", ObjGradingFFBPPT.OverRipeFruitJ)
        Parms(17) = New SqlParameter("@OverRipeFruitP", ObjGradingFFBPPT.OverRipeFruitP)
        Parms(18) = New SqlParameter("@OverRipeFruitT", ObjGradingFFBPPT.OverRipeFruitT)
        Parms(19) = New SqlParameter("@EmptyBunchFruitJ", ObjGradingFFBPPT.EmptyBunchFruitJ)
        Parms(20) = New SqlParameter("@EmptyBunchFruitP", ObjGradingFFBPPT.EmptyBunchFruitP)
        Parms(21) = New SqlParameter("@EmptyBunchFruitT", ObjGradingFFBPPT.EmptyBunchFruitT)
        Parms(22) = New SqlParameter("@TotalNormalFruitsJ", ObjGradingFFBPPT.TotalNormalFruitsJ)
        Parms(23) = New SqlParameter("@TotalNormalFruitsP", ObjGradingFFBPPT.TotalNormalFruitsP)
        Parms(24) = New SqlParameter("@TotalNormalFruitsT", ObjGradingFFBPPT.TotalNormalFruitsT)
        Parms(25) = New SqlParameter("@PartheJ", ObjGradingFFBPPT.PartheJ)
        Parms(26) = New SqlParameter("@PartheP", ObjGradingFFBPPT.PartheP)
        Parms(27) = New SqlParameter("@PartheT", ObjGradingFFBPPT.PartheT)
        Parms(28) = New SqlParameter("@HardBunchJ", ObjGradingFFBPPT.HardBunchJ)
        Parms(29) = New SqlParameter("@HardBunchP", ObjGradingFFBPPT.HardBunchP)
        Parms(30) = New SqlParameter("@HardBunchT", ObjGradingFFBPPT.HardBunchT)
        Parms(31) = New SqlParameter("@TotalAbnormalFruitsJ", ObjGradingFFBPPT.TotalAbnormalFruitsJ)
        Parms(32) = New SqlParameter("@TotalAbnormalFruitsP", ObjGradingFFBPPT.TotalAbnormalFruitsP)
        Parms(33) = New SqlParameter("@TotalAbnormalFruitsT", ObjGradingFFBPPT.TotalAbnormalFruitsT)
        Parms(34) = New SqlParameter("@GTActualBunchesJ", ObjGradingFFBPPT.GTActualBunchesJ)
        Parms(35) = New SqlParameter("@GTActualBunchesP", ObjGradingFFBPPT.GTActualBunchesP)
        Parms(36) = New SqlParameter("@GTActualBunchesT", ObjGradingFFBPPT.GTActualBunchesT)
        Parms(37) = New SqlParameter("@LooseFruitsP", ObjGradingFFBPPT.LooseFruitsP)
        Parms(38) = New SqlParameter("@KgOfLooseFruit", ObjGradingFFBPPT.KgOfLooseFruit)

        Parms(39) = New SqlParameter("@LightDamageJ", ObjGradingFFBPPT.LightDamageJ)
        Parms(40) = New SqlParameter("@LightDamageP", ObjGradingFFBPPT.LightDamageP)
        Parms(41) = New SqlParameter("@LightDamageT", ObjGradingFFBPPT.LightDamageT)

        Parms(42) = New SqlParameter("@TotalJ", ObjGradingFFBPPT.TotalJ)
        Parms(43) = New SqlParameter("@TotalP", ObjGradingFFBPPT.TotalP)
        Parms(44) = New SqlParameter("@TotalT", ObjGradingFFBPPT.TotalT)
        Parms(45) = New SqlParameter("@Comment", IIf(ObjGradingFFBPPT.Comment <> String.Empty, ObjGradingFFBPPT.Comment, DBNull.Value))

        Parms(46) = New SqlParameter("@LongStalksJ", ObjGradingFFBPPT.LongStalksJ)
        Parms(47) = New SqlParameter("@DirtAndStonesJ", ObjGradingFFBPPT.DirtAndStonesJ)
        Parms(48) = New SqlParameter("@SmallBunchesJ", ObjGradingFFBPPT.SmallBunchesJ)
        Parms(49) = New SqlParameter("@BuahRestanJ", ObjGradingFFBPPT.BuahRestanJ)
        Parms(50) = New SqlParameter("@MediumDamageJ", ObjGradingFFBPPT.MediumDamageJ)
        Parms(51) = New SqlParameter("@UnripeFruitComment", ObjGradingFFBPPT.UnripeFruitComment)
        Parms(52) = New SqlParameter("@UnderRipeComment", ObjGradingFFBPPT.UnderRipeComment)
        Parms(53) = New SqlParameter("@OverRipeFruitComment", ObjGradingFFBPPT.OverRipeFruitComment)
        Parms(54) = New SqlParameter("@EmptyBunchFruitComment", ObjGradingFFBPPT.EmptyBunchFruitComment)
        Parms(55) = New SqlParameter("@LongStalksComment", ObjGradingFFBPPT.LongStalksComment)
        Parms(56) = New SqlParameter("@LooseFruitsComment", ObjGradingFFBPPT.LooseFruitsComment)
        Parms(57) = New SqlParameter("@DirtAndStonesComment", ObjGradingFFBPPT.DirtAndStonesComment)
        Parms(58) = New SqlParameter("@SmallBunchesComment", ObjGradingFFBPPT.SmallBunchesComment)
        Parms(59) = New SqlParameter("@BuahRestanComment", ObjGradingFFBPPT.BuahRestanComment)
        Parms(60) = New SqlParameter("@HardBunchComment", ObjGradingFFBPPT.HardBunchComment)
        Parms(61) = New SqlParameter("@PartheComment", ObjGradingFFBPPT.PartheComment)
        Parms(62) = New SqlParameter("@LightDamageComment", ObjGradingFFBPPT.LightDamageComment)

        Parms(63) = New SqlParameter("@TotalBunches", ObjGradingFFBPPT.TotalBunches)
        Parms(64) = New SqlParameter("@DocumentNumber", ObjGradingFFBPPT.DocumentNumber)
        Parms(65) = New SqlParameter("@TotalGradedBunches", ObjGradingFFBPPT.TotalGradedBunches)

        Parms(66) = New SqlParameter("@GradingID", ObjGradingFFBPPT.GradingID)
        Parms(67) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(68) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(69) = New SqlParameter("@BatuKerikil", ObjGradingFFBPPT.BatuKerikil)

        Parms(70) = New SqlParameter("@RipeComment", ObjGradingFFBPPT.RipeComment)
        Parms(71) = New SqlParameter("@BunchStalkNotCutJ", ObjGradingFFBPPT.BunchStalkNotCutJ)
        Parms(72) = New SqlParameter("@BunchStalkNotCutComment", ObjGradingFFBPPT.BunchStalkNotCutComment)
        Parms(73) = New SqlParameter("@RottenBunchJ", ObjGradingFFBPPT.RottenBunchJ)
        Parms(74) = New SqlParameter("@RottenBunchComment", ObjGradingFFBPPT.RottenBunchComment)
        Parms(75) = New SqlParameter("@BuahRestan1to2J", ObjGradingFFBPPT.BuahRestan1to2J)
        Parms(76) = New SqlParameter("@BuahRestan1to2Comment", ObjGradingFFBPPT.BuahRestan1to2Comment)
        Parms(77) = New SqlParameter("@BinNumber", ObjGradingFFBPPT.BinNumber)
        Parms(78) = New SqlParameter("@Abnormal", ObjGradingFFBPPT.Abnormal)
        Parms(79) = New SqlParameter("@AbnormalComment", ObjGradingFFBPPT.AbnormalComment)

        Parms(80) = New SqlParameter("@UnDamageJ", DBNull.Value)
        Parms(81) = New SqlParameter("@UnDamageP", DBNull.Value)
        Parms(82) = New SqlParameter("@UnDamageT", DBNull.Value)

        Parms(83) = New SqlParameter("@DamageJ", DBNull.Value)
        Parms(84) = New SqlParameter("@DamageP", DBNull.Value)
        Parms(85) = New SqlParameter("@DamageT", DBNull.Value)

        Parms(86) = New SqlParameter("@MediumDamageComment", DBNull.Value)
        Parms(87) = New SqlParameter("@DamageComment", DBNull.Value)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[GradingFFBUpdate]", Parms)
        Return ds

    End Function

    Public Function DeleteGradingFFP(ByVal ObjGradingFFBPPT As GradingFFBPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@GradingID", ObjGradingFFBPPT.GradingID)
        rowsAffected = objdb.ExecNonQuery("[Production].[GradingFFBDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function

    Public Function GetGradingFFB(ByVal ObjGradingFFBPPT As GradingFFBPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If ObjGradingFFBPPT.WBTicketNo <> String.Empty Then
            Parms(1) = New SqlParameter("@WBTicketNo", ObjGradingFFBPPT.WBTicketNo)
        Else
            Parms(1) = New SqlParameter("@WBTicketNo", DBNull.Value)
        End If

        Parms(2) = New SqlParameter("@GradingDate", ObjGradingFFBPPT.lGradingDate)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Production].[GradingFFBSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function GetGradingFFBTicket(ByVal ObjGradingFFBPPT As GradingFFBPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@WBTicketNo", ObjGradingFFBPPT.WBTicketNo)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Production].[GradingFFBSelectByTicket]", Parms).Tables(0)
        Return dt
    End Function

    Public Function DuplicateWBTicketCheck(ByVal ObjGradingFFBPPT As GradingFFBPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@WBTicketNo", ObjGradingFFBPPT.WBTicketNo)

        objExists = objdb.ExecuteScalar("[Production].[GradingFFBIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function


    Public Shared Function WBTicketNoLookupSearch(ByVal ObjGradingFFBPPT As GradingFFBPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(3) As SqlParameter
        If ObjGradingFFBPPT.WBTicketNo <> "" Then
            Parms(0) = New SqlParameter("@WBTicketNo", ObjGradingFFBPPT.WBTicketNo)
        Else
            Parms(0) = New SqlParameter("@WBTicketNo", DBNull.Value)
        End If
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@IsDirect", IsDirect)
        Parms(3) = New SqlParameter("@activemonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Production].[GradingFFBWBTicketNoSelect]", Parms)
        Return ds
    End Function

    Public Function GetGradeValues(ByVal ObjGradingFFBPPT As GradingFFBPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Production].[GradingFFBSOPGradeSelect]", Parms)
        Return ds
    End Function

    Public Function GetGradingDocumentNumber() As String
        Dim objdb As New SQLHelp
        Dim dataTable = objdb.ExecQuery("[Production].[GradingFFBDocumentNumberGET]").Tables(0)        
        If dataTable.Rows.Count > 0 Then
            Dim rowDocumentNumber = dataTable.Rows(0)("DocumentNumber")
            Return rowDocumentNumber.ToString()
            'Return objdb.ExecQuery("[Production].[GradingFFBDocumentNumberGET]").Tables(0).Rows(0)("DocumentNumber").ToString()
        End If
        Return Nothing
    End Function

    Public Function GetBlockDetailValues(ByVal ObjGradingFFBPPT As GradingFFBPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@WBTicketNo", ObjGradingFFBPPT.WBTicketNo)
        ds = objdb.ExecQuery("[Production].[GradingFFBBlockDetailSelect]", Parms)
        Return ds
    End Function

    Public Function GradingFFBRecordIsExist(ByVal ObjGradingFFBPPT As GradingFFBPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Production].[GradingFFBRecordIsExist]", Parms)
        Return objExists
    End Function


    Public Function GradingFFBMonthYearGet(ByVal ObjGradingFFBPPT As GradingFFBPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Production].[GradingFFBMonthYearGET]", Parms)
        Return ds
    End Function





End Class
