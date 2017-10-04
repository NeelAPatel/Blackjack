Public Class frmTopScores

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim f As Integer
        Dim b As Integer
        Dim temp As Player

        For f = 1 To Total - 1
            For b = (f + 1) To Total
                If arrPlayer(f).BankVal < arrPlayer(b).BankVal Then
                    temp = arrPlayer(b)
                    arrPlayer(b) = arrPlayer(f)
                    arrPlayer(f) = temp
                End If

            Next
        Next


        For i As Integer = 1 To 10
            TopTenName.Items.Add(i & ". " + arrPlayer(i).Player)
            TopTenScore.Items.Add(arrPlayer(i).BankVal)
        Next

    End Sub

End Class