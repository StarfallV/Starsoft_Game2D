Public Class frmMain

    Dim game As frmGame

    Private Sub btnMain_Click(sender As Object, e As EventArgs) Handles btnMain.Click
        game = New frmGame
        game.TopLevel = False
        game.Parent = Me
        game.Show()
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Shift And e.KeyCode = Keys.Up Then
            game.player.Location = New Point(game.player.Location.X - 10, game.player.Location.Y)
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If Not IsNothing(game) Then
            If keyData = (Keys.Shift Or Keys.Left) Then
                game.Arah.Text = "Left"
                game.AnimNext()
                game.player.Location = New Point(game.player.Location.X - 6, game.player.Location.Y)
                If game.IsBlocked() Then
                    game.player.Location = New Point(game.player.Location.X + 6, game.player.Location.Y)
                End If
            ElseIf keyData = (Keys.Shift Or Keys.Right) Then
                game.Arah.Text = "Right"
                game.AnimNext()
                game.player.Location = New Point(game.player.Location.X + 6, game.player.Location.Y)
                If game.IsBlocked() Then
                    game.player.Location = New Point(game.player.Location.X - 6, game.player.Location.Y)
                End If
            ElseIf keyData = (Keys.Shift Or Keys.Up) Then
                game.Arah.Text = "Up"
                game.AnimNext()
                game.player.Location = New Point(game.player.Location.X, game.player.Location.Y - 6)
                If game.IsBlocked() Then
                    game.player.Location = New Point(game.player.Location.X, game.player.Location.Y + 6)
                End If
            ElseIf keyData = (Keys.Shift Or Keys.Down) Then
                game.Arah.Text = "Down"
                game.AnimNext()
                game.player.Location = New Point(game.player.Location.X, game.player.Location.Y + 6)
                If game.IsBlocked() Then
                    game.player.Location = New Point(game.player.Location.X, game.player.Location.Y - 6)
                End If
            End If

            If keyData = Keys.Left Then
                game.Arah.Text = "Left"
                game.AnimNext()
                game.player.Location = New Point(game.player.Location.X - 3, game.player.Location.Y)
                If game.IsBlocked() Then
                    game.player.Location = New Point(game.player.Location.X + 3, game.player.Location.Y)
                End If
            ElseIf keyData = Keys.Right Then
                game.Arah.Text = "Right"
                game.AnimNext()
                game.player.Location = New Point(game.player.Location.X + 3, game.player.Location.Y)
                If game.IsBlocked() Then
                    game.player.Location = New Point(game.player.Location.X - 3, game.player.Location.Y)
                End If
            ElseIf keyData = Keys.Up Then
                game.Arah.Text = "Up"
                game.AnimNext()
                game.player.Location = New Point(game.player.Location.X, game.player.Location.Y - 3)
                If game.IsBlocked() Then
                    game.player.Location = New Point(game.player.Location.X, game.player.Location.Y + 3)
                End If
            ElseIf keyData = Keys.Down Then
                game.Arah.Text = "Down"
                game.AnimNext()
                game.player.Location = New Point(game.player.Location.X, game.player.Location.Y + 3)
                If game.IsBlocked() Then
                    game.player.Location = New Point(game.player.Location.X, game.player.Location.Y - 3)
                End If
            End If

            If keyData = Keys.Space Then
                game.PickTrash()
            End If
        End If

        Return Nothing
    End Function

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        End
    End Sub
End Class
