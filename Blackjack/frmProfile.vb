Imports System
Imports System.IO
Public Class frmProfile
    Dim NewUser As String
    Dim PlayerPath As String
    Dim i As Integer
    Dim oFile As System.IO.File
    Dim oRead As System.IO.StreamReader
    Dim oWrite As System.IO.StreamWriter

    Private Sub frmProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ImportPlayers()
    End Sub
    Sub ImportPlayers()

        PlayerSelectorBox.Items.Clear()

        'PlayerPath = "E:\VBSTUDIOPROGRAMS\2. Blackjack_Proj\Blackjack\"
        PlayerPath = Directory.GetCurrentDirectory()
        i = 1
        oRead = IO.File.OpenText(PlayerPath + "Players.txt")
        While oRead.Peek <> -1
            arrPlayer(i).Player = oRead.ReadLine
            arrPlayer(i).BankVal = Int(oRead.ReadLine)
            PlayerSelectorBox.Items.Add(arrPlayer(i).Player)
            i = i + 1
        End While
        Total = i - 1
        oRead.Close()
    End Sub

    Private Sub PlayerSelectorBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PlayerSelectorBox.SelectedIndexChanged
        txtBank.Text = arrPlayer(PlayerSelectorBox.SelectedIndex + 1).BankVal
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        Index = PlayerSelectorBox.SelectedIndex + 1
        Blackjack.lblUser.Text = (arrPlayer(PlayerSelectorBox.SelectedIndex + 1).Player)
        Blackjack.txtBank.Text = (arrPlayer(PlayerSelectorBox.SelectedIndex + 1).BankVal)
        Me.Hide()
    End Sub

    Private Sub CreateProfile_Click(sender As Object, e As EventArgs) Handles CreateProfile.Click
        NewUser = InputBox("What is your name?" + vbNewLine + "Your bank balance will start off with 1000 points", "Name", "NewUser")
        With arrPlayer(i)
            .Player = NewUser
            .BankVal = 1000
            PlayerSelectorBox.Items.Add(.Player)
            txtBank.Text = .BankVal

        End With
        PlayerSelectorBox.SelectedIndex = i - 1

        oWrite = IO.File.CreateText(PlayerPath + "Players.txt")
        For x As Integer = 1 To i
            With arrPlayer(x)
                oWrite.WriteLine(.Player)
                oWrite.WriteLine(.BankVal)
            End With
        Next
        oWrite.Close()

        i = i + 1
        Total = i
    End Sub
End Class