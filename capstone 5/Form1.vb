Option Strict On

Option Infer Off

Option Explicit On



Imports System.ComponentModel
Imports System.IO

Imports System.Runtime.Serialization.Formatters
Public Class frmMain

    Public strFileName As String


    Dim strShortName As String

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        strFileName = String.Empty
        Dim Open As New OpenFileDialog()
        'it is declared as System input and output Streamreader
        'it reads characters from a byte stream in a particular encoding
        Dim myStreamReader As StreamReader

        'in an open dialog box, it will give an opening filter for the current filenames,
        'or the save file types.   
        Open.Filter = "Text [*.txt*]|*.txt|All Files [*.*]|*.*"
        'it checks if the file exists or not
        Open.CheckFileExists = True
        'sets the openfile dialog name as "OpenFile"
        Open.Title = "OpenFile"
        Open.ShowDialog(Me)


        Try
            'it opens the selected file by the user
            Open.OpenFile()
            'opens the existing file
            'it reads the streams from current position to the end of position and display the result to RichTextBox as Text
            strFileName = Open.FileName
        Catch ex As Exception
            'it will catch if any errors occurs
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
        lstMain.Items.Clear()

        lstName.Items.Clear()
        strShortName = Open.SafeFileName

        lblFile.Text = "File Loaded: " + strShortName


        myStreamReader = File.OpenText(Open.FileName)



        Do Until myStreamReader.Peek = -1

            lstMain.Items.Add(myStreamReader.ReadLine())

        Loop


        For x As Integer = 1 To lstMain.Items.Count

            For y As Integer = 1 To 3

                If y = 1 Then

                    lstName.Items.Add(lstMain.Items.Item(x - 1).ToString())

                    x += 2

                End If

            Next

        Next

        lblTotal.Text = "Total People in File: " + (lstMain.Items.Count / 3).ToString()

        myStreamReader.Close()

    End Sub



    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Me.Close()

    End Sub


    Private Sub lstName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstName.SelectedIndexChanged

        Dim file As StreamReader

        file = IO.File.OpenText(strFileName)


        Dim intlinenum As Integer

        intlinenum = (lstName.SelectedIndex + 1) * 3


        For x As Integer = 1 To intlinenum - 2

            file.ReadLine()

        Next

        lblInfoBox.Text = "Amount: " + file.ReadLine() +
        ControlChars.NewLine + "Precent: " + file.ReadLine()

        file.Close()

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        If lblFile.Text = "File Loaded: " + strShortName And
        lstName.SelectedIndex <> -1 Then

            For x As Integer = 0 To 2

                lstMain.Items.RemoveAt(lstName.SelectedIndex * 3)

            Next

            lstName.Items.RemoveAt(lstName.SelectedIndex)

            lblTotal.Text = "Total People in File: " +
            lstName.Items.Count.ToString()

            lblInfoBox.Text = String.Empty
        End If

    End Sub


    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click

        frmAdd.Show()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim x As Integer = lstName.FindString(txtSearch.Text)
        lstName.SelectedIndex = x
    End Sub
End Class
