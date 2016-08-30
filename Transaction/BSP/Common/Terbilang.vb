Imports VB = Microsoft.VisualBasic
Public Class Terbilang
    Dim temp, angka As String

    Function GetFigures(ByRef x As String) As String

        Try

            Dim satu(10) As String

            Dim dua(10) As String

            Dim tiga(10) As String

            Dim ratus As String

            Dim ribu As String

            Dim juta As String

            Dim miliar As String

            Dim triliun As String

            satu(0) = "" : satu(1) = "Satu" : satu(2) = "Dua" : satu(3) = "Tiga" : satu(4) = "Empat" : satu(5) = "Lima" : satu(6) = "Enam" : satu(7) = "Tujuh" : satu(8) = "Delapan" : satu(9) = "Sembilan"

            dua(0) = "Sepuluh" : dua(1) = "Sebelas" : dua(2) = "Dua belas" : dua(3) = "Tiga belas" : dua(4) = "Empat belas" : dua(5) = "Lima belas" : dua(6) = "Enam belas" : dua(7) = "Tujuh belas" : dua(8) = "Delapan belas" : dua(9) = "Sembilan belas"

            tiga(2) = "Dua puluh " : tiga(3) = "Tiga puluh " : tiga(4) = "Empat puluh " : tiga(5) = "Lima puluh " : tiga(6) = "Enam puluh " : tiga(7) = "Tujuh puluh " : tiga(8) = "Delapan puluh " : tiga(9) = "Sembilan puluh "

            ratus = " Ratus " : ribu = " Ribu " : juta = " Juta "

            miliar = " Miliar " : triliun = " Triliun "



            temp = CStr(Val(x))

            Dim nilai As String

            nilai = Len(temp)

            Select Case nilai

                Case 1

                    angka = satu(CInt(x))

                Case 2

                    If CDbl(VB.Left(temp, 1)) > 1 Then  ' dari 20-99

                        angka = tiga(CInt(VB.Left(temp, 1))) & satu(CInt(VB.Right(temp, 1)))

                    ElseIf CDbl(VB.Left(temp, 1)) = 1 Then ' dari 11-19

                        angka = dua(CInt(VB.Right(temp, 1)))

                    Else ' dari 20 to 90 selisih 10

                        angka = GetFigures(CStr(Int(CDbl(VB.Right(temp, 1)))))

                    End If

                Case 3

                    If (VB.Left(temp, 1)) > 1 Then

                        angka = satu(CInt(VB.Left(temp, 1))) & ratus ' dari 200-999

                        angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 2)))))

                    ElseIf Int(CDbl(VB.Left(temp, 1))) = 1 Then

                        angka = satu(CInt(VB.Left(temp, 1))) & ratus ' dari 100-199

                        angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 2)))))

                    Else

                        angka = satu(CInt(VB.Left(temp, 1))) & ratus ' dari 200-900

                    End If

                Case 4

                    If (VB.Left(temp, 1)) > 1 Then

                        angka = satu(CInt(VB.Left(temp, 1))) & ribu ' dari 200-999

                        angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 3)))))

                    ElseIf Int(CDbl(VB.Left(temp, 1))) = 1 Then

                        angka = satu(CInt(VB.Left(temp, 1))) & ribu ' dari 100-199

                        angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 3)))))

                    Else

                        angka = satu(CInt(VB.Left(temp, 1))) & ribu ' dari 200-900

                    End If

                Case 5

                    If (VB.Left(temp, 1)) > 1 Then

                        If (VB.Mid(temp, 2, 1)) = 0 Then

                            angka = tiga(CInt(VB.Left(temp, 1))) & ribu

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 3, 3)))))

                        Else

                            angka = tiga(CInt(VB.Left(temp, 1)))

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 4)))))

                        End If

                    ElseIf Int(CDbl(VB.Left(temp, 1))) = 1 Then

                        If (VB.Mid(temp, 2, 1)) = 0 Then

                            angka = dua(CInt(VB.Mid(temp, 2, 1))) & ribu

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 4)))))

                        Else

                            angka = dua(CInt(VB.Mid(temp, 2, 1))) & ribu

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 3, 3)))))

                        End If

                    Else

                        angka = tiga(CInt(VB.Left(temp, 1))) & ribu

                    End If

                Case 6

                    angka = satu(CInt(VB.Left(temp, 1))) & ratus

                    angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 5)))))

                Case 7

                    angka = satu(CInt(VB.Left(temp, 1))) & juta

                    angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 6)))))



                Case 8

                    If (VB.Left(temp, 1)) > 1 Then

                        If (VB.Mid(temp, 2, 1)) = 0 Then

                            angka = tiga(CInt(VB.Left(temp, 1))) & juta

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 3, 6)))))

                        Else

                            angka = tiga(CInt(VB.Left(temp, 1)))

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 7)))))

                        End If

                    ElseIf Int(CDbl(VB.Left(temp, 1))) = 1 Then

                        If (VB.Mid(temp, 2, 1)) = 0 Then

                            angka = dua(CInt(VB.Mid(temp, 2, 1))) & juta

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 7)))))

                        Else

                            angka = dua(CInt(VB.Mid(temp, 2, 1))) & juta

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 3, 6)))))

                        End If

                    Else

                        angka = tiga(CInt(VB.Left(temp, 1))) & ribu

                    End If

                Case 9

                    angka = satu(CInt(VB.Left(temp, 1))) & ratus & juta

                    angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 8)))))

                Case 10

                    angka = satu(CInt(VB.Left(temp, 1))) & miliar

                    angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 9)))))

                Case 11

                    If (VB.Left(temp, 1)) > 1 Then

                        If (VB.Mid(temp, 2, 1)) = 0 Then

                            angka = tiga(CInt(VB.Left(temp, 1))) & miliar

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 3, 9)))))

                        Else

                            angka = tiga(CInt(VB.Left(temp, 1)))

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 10)))))

                        End If

                    ElseIf Int(CDbl(VB.Left(temp, 1))) = 1 Then

                        If (VB.Mid(temp, 2, 1)) = 0 Then

                            angka = dua(CInt(VB.Mid(temp, 2, 1))) & miliar

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 10)))))

                        Else

                            angka = dua(CInt(VB.Mid(temp, 2, 1))) & miliar

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 3, 9)))))

                        End If

                    Else

                        angka = tiga(CInt(VB.Left(temp, 1))) & ribu

                    End If

                Case 12

                    If (VB.Mid(temp, 2, 1)) = 0 Then

                        angka = satu(CInt(VB.Left(temp, 1))) & ratus & miliar

                    Else

                        angka = satu(CInt(VB.Left(temp, 1))) & ratus

                        angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 11)))))

                    End If

                Case 13

                    angka = satu(CInt(VB.Left(temp, 1))) & triliun

                    angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 12)))))

                Case 14

                    If (VB.Left(temp, 1)) > 1 Then

                        If (VB.Mid(temp, 2, 1)) = 0 Then

                            angka = tiga(CInt(VB.Left(temp, 1))) & triliun

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 3, 13)))))

                        Else

                            angka = tiga(CInt(VB.Left(temp, 1)))

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 14)))))

                        End If

                    ElseIf Int(CDbl(VB.Left(temp, 1))) = 1 Then

                        If (VB.Mid(temp, 2, 1)) = 0 Then

                            angka = dua(CInt(VB.Mid(temp, 2, 1))) & triliun

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 13)))))

                        Else

                            angka = dua(CInt(VB.Mid(temp, 2, 1))) & triliun

                            angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 3, 12)))))

                        End If

                    End If

                Case 15

                    If (VB.Mid(temp, 2, 1)) = 0 Then

                        angka = satu(CInt(VB.Left(temp, 1))) & ratus & triliun

                    Else

                        angka = satu(CInt(VB.Left(temp, 1))) & ratus

                        angka = angka & GetFigures(CStr(Int(CDbl(VB.Mid(temp, 2, 14)))))

                    End If

            End Select

        Catch

            MessageBox.Show("Terdapat kesalahan cek lagi angka yang anda inputkan", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

        GetFigures = Replace(angka, "Satu Ratus", "Seratus")

        GetFigures = Replace(GetFigures, "Satu Ribu", "Seribu")

    End Function
End Class
