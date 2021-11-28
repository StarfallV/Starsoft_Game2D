Public Class frmGame

    'membuat 2 variabel baru untuk skor serta poin sampah
    Public scorepoints As Integer = 0
    Public trash_points As Integer = 200

    'sub untuk mengatur animasi karakter - trigger ketika teks pada textbox bernama "AnimNum" terganti
    Private Sub AnimNum_TextChanged(sender As Object, e As EventArgs) Handles AnimNum.TextChanged
        If Arah.Text = "Down" Then
            If AnimNum.Text = 0 Then
                Me.player.BackgroundImage = My.Resources.chr_front
            ElseIf AnimNum.Text = 3 Then
                Me.player.BackgroundImage = My.Resources.chr_front_a1
            ElseIf AnimNum.Text = 6 Then
                Me.player.BackgroundImage = My.Resources.chr_front_a2
            End If
        End If
        If Arah.Text = "Up" Then
            If AnimNum.Text = 0 Then
                Me.player.BackgroundImage = My.Resources.chr_back
            ElseIf AnimNum.Text = 3 Then
                Me.player.BackgroundImage = My.Resources.chr_back_a1
            ElseIf AnimNum.Text = 6 Then
                Me.player.BackgroundImage = My.Resources.chr_back_a2
            End If
        End If
        If Arah.Text = "Left" Then
            If AnimNum.Text = 0 Then
                Me.player.BackgroundImage = My.Resources.chr_left
            ElseIf AnimNum.Text = 3 Then
                Me.player.BackgroundImage = My.Resources.chr_left_a1
            ElseIf AnimNum.Text = 6 Then
                Me.player.BackgroundImage = My.Resources.chr_left_a2
            End If
        End If
        If Arah.Text = "Right" Then
            If AnimNum.Text = 0 Then
                Me.player.BackgroundImage = My.Resources.chr_right
            ElseIf AnimNum.Text = 3 Then
                Me.player.BackgroundImage = My.Resources.chr_right_a1
            ElseIf AnimNum.Text = 6 Then
                Me.player.BackgroundImage = My.Resources.chr_right_a2
            End If
        End If
    End Sub

    'fungsi untuk menentukan nomor animasi
    Public Sub AnimNext()
        If AnimNum.Text = 9 Then
            AnimNum.Text = 0
        Else
            AnimNum.Text += 1
        End If
    End Sub

    'fungsi untuk menutup game dan memberikan informasi game over
    Public Sub GameOver()
        MessageBox.Show("Kamu menyentuh lava! Game Over")
        Me.Close()
    End Sub

    'mengecek apakah karakter bersentuhan dengan objek lain
    Public Function IsBlocked() As Boolean
        Dim collision As Boolean

        For Each c As Control In Me.Land.Controls
            If TypeName(c) = "PictureBox" Then
                If Not c.Name = "player" And c.Name.StartsWith("obj_") And Not c.Name.StartsWith("obj_trash") Then
                    If Me.player.Bounds.IntersectsWith(c.Bounds) Then
                        collision = True
                        If c.Name.StartsWith("obj_lava") Then
                            GameOver()
                        End If
                        Exit For
                    Else : collision = False
                    End If
                End If
            End If
        Next

        Return collision
    End Function

    'melakukan drawing untuk map agar lebih smooth
    Private Sub Land_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Land.Paint
        Dim g As Graphics = e.Graphics

        Dim controls = Me.Land.Controls.OfType(Of PictureBox)()

        For Each c In controls
            If Not IsNothing(c.BackgroundImage) Then
                g.DrawImage(c.BackgroundImage, c.Location.X, c.Location.Y, c.Width, c.Height)
            End If
        Next

    End Sub

    'fungsi untuk mengambil sampah dan mendapatkan poin
    Public Function PickTrash() As Boolean

        For Each c As Control In Me.Land.Controls
            If TypeName(c) = "PictureBox" Then
                If Not c.Name = "player" And c.Name.StartsWith("obj_trash") Then
                    If player.Location.X > c.Location.X - 60 And player.Location.X < c.Location.X + 60 And player.Location.Y > c.Location.Y - 100 And player.Location.Y < c.Location.Y + 100 Then
                        Dim pertanyaan As New frmQuestion
                        pertanyaan.Show()
                        c.Dispose()
                        Land.Refresh()
                        End If
                    End If
            End If
        Next

        Return True
    End Function

    'fungsi untuk mengecek apakah skor sudah mencukupi untuk menang
    Private Sub points_TextChanged(sender As Object, e As EventArgs) Handles points.TextChanged
        scorepoints = points.Text
        If scorepoints >= 1200 Then
            MessageBox.Show("Selamat! Anda adalah pahlawan sampah yang hebat!")
        End If
    End Sub

    'fungsi/perintah yang jalan pertama kali ketika form terbuka
    Private Sub frmGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmMain.btnMain.Enabled = False
        frmMain.btnKeluar.Enabled = False
    End Sub

    'mengaktifkan tombol main menu ketika form ditutup
    Private Sub frmGame_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        frmMain.btnMain.Enabled = True
        frmMain.btnKeluar.Enabled = True
    End Sub
End Class