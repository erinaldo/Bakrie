Imports CrystalDecisions.Shared
Public Class ExportReportToText

    Public Sub TryTextFilePrinting(ByVal ReportName As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal ParamName() As String, ByVal ParamValues() As String)


        Dim MyReportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = ReportName

        Dim Field As CrystalDecisions.Shared.ParameterValues

        Dim Value As CrystalDecisions.Shared.ParameterDiscreteValue

        Try

            If Not ParamName Is Nothing Then

                For i As Integer = 0 To ParamName.Length - 1

                    Field = New CrystalDecisions.Shared.ParameterValues

                    Value = New CrystalDecisions.Shared.ParameterDiscreteValue

                    Value.Value = ParamValues(i)

                    Field.Add(Value)

                    MyReportDocument.DataDefinition.ParameterFields(ParamName(i)).ApplyCurrentValues(Field)

                Next

            End If

            CrystalDecisions.Shared.ExportOptions.CreateTextFormatOptions.CharactersPerInch = 16


            CrystalDecisions.Shared.ExportOptions.CreateTextFormatOptions.LinesPerPage = 50

            MyReportDocument.ExportToDisk(ExportFormatType.Text, "Salary.txt")
            'MyReportDocument.PrintOptions.PrinterName = ""

            'MyReportDocument.PrintToPrinter(1, True, 0, 0)

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Print Report")

        Finally

            MyReportDocument.Close()

            MyReportDocument.Dispose()
            Process.Start(Application.StartupPath + "\Salary.txt")

        End Try

    End Sub


End Class
