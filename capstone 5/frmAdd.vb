Imports System.IO


Public Class frmAdd

    Public strName As String
    Public strAmt As String
    Public strPercent As String
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        strName = txtName.Text
        strAmt = txtAmount.Text
        strPercent = txtPercent.Text
        frmMain.lstMain.Items.Add(strName)
        frmMain.lstMain.Items.Add(strAmt)
        frmMain.lstMain.Items.Add(strPercent)

        frmMain.lstName.Items.Add(strName)
        frmMain.lblTotal.Text = "Total People in File: " + frmMain.lstName.Items.Count.ToString()
        Me.Close()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class