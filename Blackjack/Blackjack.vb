Imports System
Imports System.IO

Public Class Blackjack
    'File I/O
    Dim oFile As System.IO.File
    Dim oRead As System.IO.StreamReader
    'Cards
    Dim arrImportCards(54) As Card
    Dim arrCards(54) As Card
    Dim CardsLeft As Integer
    Dim ImgPath As String
    'PictureBox
    Dim arrPicDealer(5) As PictureBox
    Dim PlayerCardNum As Integer
    Dim arrPicPlayer(5) As PictureBox
    Dim DealerCardNum As Integer
    'Score
    Dim DealerVisible As Boolean = False
    Dim PlayerScore As Integer
    Dim DealerScore As Integer
    Dim BetValue As Integer
    Dim FCC As Boolean
    Structure Card
        Public CardImage As String
        'Public CardString As String * 2
        Public Suit As Integer
        Public Value As Integer
    End Structure

    Private Sub Blackjack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FCC = False
        ShuffleCards()
        PicBoxArrayMaker()
        DealerProgressBar.Value = 0
        PlayerProgressBar.Value = 0
        DealerScoreLabel.Text = "-"
        PlayerScoreLabel.Text = "-"
        CardsLeft = 5

        HitButton.Enabled = False
        StandButton.Enabled = False
        DoubleDownButton.Enabled = False


    End Sub

    Sub ValueMaker(i As Integer, linein As String)
        With arrImportCards(i)
            Select Case Mid(linein, 1, 1)
                Case "a"
                    .Value = 1
                Case "2"
                    .Value = 2
                Case "3"
                    .Value = 3
                Case "4"
                    .Value = 4
                Case "5"
                    .Value = 5
                Case "6"
                    .Value = 6
                Case "7"
                    .Value = 7
                Case "8"
                    .Value = 8
                Case "9"
                    .Value = 9
                Case "t"
                    .Value = 10
                Case "j"
                    .Value = 10
                Case "q"
                    .Value = 10
                Case "k"
                    .Value = 10
                Case "x"
                    .Value = 0
            End Select
        End With
    End Sub
    Sub SuitMaker(i As Integer, linein As String)
        With arrImportCards(i)
            Select Case Mid(linein, 2, 1)
                Case "c"
                    .Suit = 1
                Case "h"
                    .Suit = 2
                Case "d"
                    .Suit = 3
                Case "s"
                    .Suit = 4
                Case "x"
                    .Suit = 0
            End Select
        End With
    End Sub
    Sub ShuffleCards()
        Dim linein As String
        Dim Path As String
        Dim z As Integer

        'Path = "E:\VBSTUDIOPROGRAMS\2. Blackjack_Proj\Blackjack\cardimages\Cards.txt"'
        'ImgPath = "E:\VBSTUDIOPROGRAMS\2. Blackjack_Proj\Blackjack\cardimages\"'

        Path = Directory.GetCurrentDirectory() + "\cardimages\Cards.txt"
        ImgPath = Directory.GetCurrentDirectory() + "\cardImages\"
        oRead = IO.File.OpenText(Path)
        z = 1
        While oRead.Peek <> -1
            linein = oRead.ReadLine()
            'ListBox1.Items.Add(linein)
            With arrImportCards(z)
                ValueMaker(z, linein)
                SuitMaker(z, linein)
                .CardImage = (ImgPath + linein + ".gif")
            End With
            z = z + 1
        End While


        Dim pos As Integer
        Randomize()
        pos = Int(Rnd() * 53) + 1
        'arrCards(1) = arrImportCards(1)
        For y As Integer = 1 To 54
            If arrCards(pos).Value = vbEmpty Then
                arrCards(pos) = arrImportCards(y)
            Else
                Do While arrCards(pos).Value <> vbEmpty
                    pos = Int(Rnd() * 53) + 1
                Loop

                arrCards(pos) = arrImportCards(y)
            End If
        Next
    End Sub
    Sub PicBoxArrayMaker()
        arrPicDealer(1) = DealerBox1
        arrPicDealer(2) = DealerBox2
        arrPicDealer(3) = DealerBox3
        arrPicDealer(4) = DealerBox4
        arrPicDealer(5) = DealerBox5
        arrPicPlayer(1) = PlayerBox1
        arrPicPlayer(2) = PlayerBox2
        arrPicPlayer(3) = PlayerBox3
        arrPicPlayer(4) = PlayerBox4
        arrPicPlayer(5) = PlayerBox5



    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        My.Computer.Audio.Play(Directory.GetCurrentDirectory() + "\Battle-Song.wav")
        'Bet
        BetValue = InputBox("How much would you like to wager?", "Bet?", 10)
        txtBetPlaced.Text = BetValue
        arrPlayer(Index).BankVal = arrPlayer(Index).BankVal - BetValue
        txtBank.Text = arrPlayer(Index).BankVal


        'Deals out one card each
        Dim CardNumber As Integer
        CardNumber = 1
        For i As Integer = 1 To 2
            With arrPicPlayer(i)
                .Visible = True
                .Image = Image.FromFile(arrCards(CardNumber).CardImage)
                CardNumber = CardNumber + 1
            End With
            With arrPicDealer(i)
                .Visible = True
                .Image = Image.FromFile(arrCards(CardNumber).CardImage)
                CardNumber = CardNumber + 1
            End With
        Next
        'Player hand: card# = 1,3
        'Dealer hand: card# = 2,4

        PlayerScore = (arrCards(1).Value + arrCards(3).Value)
        DealerScore = (arrCards(2).Value + arrCards(4).Value)

        If DealerVisible = True Then
            DealerScoreLabel.Text = DealerScore
        Else
            DealerScoreLabel.Text = "-"
        End If

        PlayerScoreLabel.Text = PlayerScore

        CardsLeft = 5
        PlayerCardNum = 3
        DealerCardNum = 3

        If DealerVisible = True Then
            If DealerScore >= 21 Then
                DealerProgressBar.Value = 21
            Else
                DealerProgressBar.Value = DealerScore
            End If
        Else
            DealerProgressBar.Value = 21
        End If




        If PlayerScore >= 21 Then
            PlayerProgressBar.Value = 21
        Else
            PlayerProgressBar.Value = PlayerScore
        End If

        PlayButton.Enabled = False
        PlayButton.Visible = False
        HitButton.Enabled = True
        StandButton.Enabled = True
        DoubleDownButton.Enabled = True

    End Sub

    Private Sub HitButton_Click(sender As Object, e As EventArgs) Handles HitButton.Click
        'Card Display
        arrPicPlayer(PlayerCardNum).Visible = True
        arrPicPlayer(PlayerCardNum).Image = Image.FromFile(arrCards(CardsLeft).CardImage)
        'ScoreManipulation/Displaygdgsf
        PlayerScore = PlayerScore + arrCards(CardsLeft).Value
        PlayerScoreLabel.Text = PlayerScore
        'Gettin' Ready for next time
        PlayerCardNum = PlayerCardNum + 1
        CardsLeft = CardsLeft + 1

        If PlayerCardNum >= 4 Then
            DoubleDownButton.Enabled = False
        End If


        If PlayerScore >= 21 Then
            PlayerProgressBar.Value = 21
        Else
            PlayerProgressBar.Value = PlayerScore
        End If

        If (PlayerCardNum = 6 And PlayerScore <= 21) Then
            FCC = True
            HitButton.Enabled = False
            DoubleDownButton.Enabled = False
            CheckForBust()
        Else
            CheckForBust()
        End If
        'CheckForBust()
    End Sub
    Private Sub StandButton_Click(sender As Object, e As EventArgs) Handles StandButton.Click
        arrPicDealer(DealerCardNum).Visible = True
        arrPicDealer(DealerCardNum).Image = Image.FromFile(arrCards(CardsLeft).CardImage)
        'ScoreManipulation/Display
        DealerScore = DealerScore + arrCards(CardsLeft).Value

        If DealerVisible = True Then
            DealerScoreLabel.Text = DealerScore
        Else
            DealerScoreLabel.Text = "-"
        End If


        'Gettin' Ready for next time
        DealerCardNum = DealerCardNum + 1
        CardsLeft = CardsLeft + 1

        'DealerBar()
        If DealerVisible = True Then
            If DealerScore >= 21 Then
                DealerProgressBar.Value = 21
            Else
                DealerProgressBar.Value = DealerScore
            End If
        Else
            DealerProgressBar.Value = 21
        End If


        CheckForBust()
    End Sub

    Sub CheckForBust()
        If PlayerScore > 21 Then

            MsgBox("You lost the amount you bet for :(" + vbNewLine + "If you wish to try again, press the PLAY button!")
            PlayButton.Visible = True
            HitButton.Enabled = False
            DoubleDownButton.Enabled = False
            PlayButton.Enabled = True
            SaveScore()
            ResetEverything()
        End If

        If PlayerScore = 21 Then
            BetValue = BetValue * 2
            If FCC = True Then
                MsgBox("It's a 5 Card Charlie!")
            End If
            MsgBox("You won " & BetValue & " points! Twice the amount you bet for!" & vbNewLine & "If you wish to try again, press the PLAY button!")
            arrPlayer(Index).BankVal = arrPlayer(Index).BankVal + BetValue
            txtBank.Text = arrPlayer(Index).BankVal
            PlayButton.Visible = True
            HitButton.Enabled = False
            DoubleDownButton.Enabled = False
            PlayButton.Enabled = True

            SaveScore()
            ResetEverything()
        End If


        If DealerScore > 21 Then

            BetValue = BetValue * 2
            If FCC = True Then
                MsgBox("It's a 5 Card Charlie!")
            End If
            MsgBox("You won " & BetValue & " points! Twice the amount you bet for!" & vbNewLine & "If you wish to try again, press the PLAY button!")
            arrPlayer(Index).BankVal = arrPlayer(Index).BankVal + BetValue
            txtBank.Text = arrPlayer(Index).BankVal
            PlayButton.Visible = True
            HitButton.Enabled = False
            DoubleDownButton.Enabled = False
            PlayButton.Enabled = True
            PlayButton.Visible = True

            SaveScore()
            ResetEverything()
        End If
        If DealerScore = 21 Then
            MsgBox("You lost the amount you bet for :(" + vbNewLine + "If you wish to try again, press the PLAY button!")
            PlayButton.Visible = True
            HitButton.Enabled = False
            DoubleDownButton.Enabled = False
            PlayButton.Enabled = True
            PlayButton.Visible = True
            SaveScore()
            ResetEverything()
        End If
    End Sub
    Sub ResetEverything()
        PlayButton.Enabled = True
        HitButton.Enabled = True
        StandButton.Enabled = True

        DoubleDownButton.Enabled = True
        For x As Integer = 1 To 5
            arrPicDealer(x).Image = Nothing
            arrPicPlayer(x).Image = Nothing
        Next
        DealerScoreLabel.Text = "-"
        PlayerScoreLabel.Text = "-"
        DealerProgressBar.Value = 0
        PlayerProgressBar.Value = 0
        BetValue = vbEmpty
        txtBetPlaced.Text = ""
        REShuffleCards()
        My.Computer.Audio.Stop()



    End Sub
    Sub REShuffleCards()
        Dim pos1 As Integer
        Dim pos2 As Integer
        Dim Temp As Card

        Randomize()

        For x As Integer = 1 To Total
            pos1 = Int(Rnd() * 53) + 1
            pos2 = Int(Rnd() * 53) + 1
            Temp = arrCards(pos1)
            arrCards(pos1) = arrCards(pos2)
            arrCards(pos2) = Temp
        Next


    End Sub
    Sub SaveScore()
        Dim oWrite As System.IO.StreamWriter
        'Dim PlayerPath As String = "E:\VBSTUDIOPROGRAMS\2. Blackjack_Proj\Blackjack\"
        Dim PlayerPath As String = Directory.GetCurrentDirectory()
        oWrite = IO.File.CreateText(PlayerPath + "Players.txt")
        For x As Integer = 1 To Total
            With arrPlayer(x)
                oWrite.WriteLine(.Player)
                oWrite.WriteLine(.BankVal)
            End With
        Next
        oWrite.Close()
    End Sub
    Private Sub DoubleDownButton_Click(sender As Object, e As EventArgs) Handles DoubleDownButton.Click
        'HitButton_Click(sender, e)
        'HitButton_Click(sender, e)


        ' INSTANCE 1
        'Card Display
        arrPicPlayer(PlayerCardNum).Visible = True
        arrPicPlayer(PlayerCardNum).Image = Image.FromFile(arrCards(CardsLeft).CardImage)
        'ScoreManipulation/Displaygdgsf
        PlayerScore = PlayerScore + arrCards(CardsLeft).Value
        PlayerScoreLabel.Text = PlayerScore
        'Gettin' Ready for next time
        PlayerCardNum = PlayerCardNum + 1
        CardsLeft = CardsLeft + 1



        'INSTANCE 2
        'Card Display
        arrPicPlayer(PlayerCardNum).Visible = True
        arrPicPlayer(PlayerCardNum).Image = Image.FromFile(arrCards(CardsLeft).CardImage)
        'ScoreManipulation/Displaygdgsf
        PlayerScore = PlayerScore + arrCards(CardsLeft).Value
        PlayerScoreLabel.Text = PlayerScore
        'Gettin' Ready for next time
        PlayerCardNum = PlayerCardNum + 1
        CardsLeft = CardsLeft + 1

        'Check
        If PlayerCardNum >= 4 Then
            DoubleDownButton.Enabled = False
        End If

        'ProgressBar
        If PlayerScore >= 21 Then
            PlayerProgressBar.Value = 21
        Else
            PlayerProgressBar.Value = PlayerScore
        End If

        If (PlayerCardNum = 6 And PlayerScore <= 21) Then
            FCC = True
            HitButton.Enabled = False
            DoubleDownButton.Enabled = False
            CheckForBust()
        Else
            CheckForBust()
        End If

        'Double up
        BetValue = BetValue * 2
        txtBetPlaced.Text = BetValue
    End Sub

    Private Sub TopScoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopScoresToolStripMenuItem.Click
        frmTopScores.Show()
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click
        frmProfile.Show()
        frmProfile.Focus()
    End Sub



    Private Sub ShowDealerHand_Click(sender As Object, e As EventArgs) Handles ShowDealerHand.Click
        DealerVisible = True
        NOShowDealerHand.Enabled = True
        ShowDealerHand.Enabled = False

        DealerScoreLabel.Text = DealerScore
        If DealerScore >= 21 Then
            DealerProgressBar.Value = 21
        Else
            DealerProgressBar.Value = DealerScore
        End If

        DealerHideCard.Visible = False
    End Sub

    Private Sub NOShowDealerHand_Click(sender As Object, e As EventArgs) Handles NOShowDealerHand.Click
        DealerVisible = False
        NOShowDealerHand.Enabled = False
        ShowDealerHand.Enabled = True
        DealerScoreLabel.Text = "-"

        DealerProgressBar.Value = 21

        DealerHideCard.Visible = True
    End Sub
End Class
