Public Class ProgressingFrm

    Private Sub ProgressingFrm_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        'Timer1.Stop()
    End Sub

    Private Sub LoginFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Refresh()
        lblMessage.Text = String.Empty
        pbWait.Minimum = 0
        pbWait.Maximum = 100
        pbWait.Value = 0
    End Sub


    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    pbWait.Value += 2
    '    If pbWait.Value >= 100 Then
    '        pbWait.Value = 0
    '    End If
    '    MsgBox(pbWait.Value)
    'End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    'PictLogin.Refresh()
    'End Sub
End Class