﻿Public Class Form1
    ' Our delegate (which "points" at any method which takes an object and EventArgs)
    ' Look familiar? This is the signature of most control events on a form
    Public Delegate Sub SendMessage(obj As Boolean, e As EventArgs)
    ' Here is the event we trigger to send messages out to listeners
    ' in this case a Boolean which is used to start/stop a Timer.
    Public Event OnSendMessage As SendMessage
    Private Sub ShowChildFormButton_Click(sender As Object, e As EventArgs) _
        Handles ShowChildFormButton.Click

        Dim child As New Form2()

        AddHandler OnSendMessage, AddressOf child.MessageReceived

        child.Show()
        child.Location = New Point(Left + (Width + 10), Top + 5)

    End Sub
    Private Sub StartStopTimerButton_Click(sender As Object, e As EventArgs) _
        Handles StartStopTimerButton.Click

        RaiseEvent OnSendMessage(EnabledCheckBox.Checked, e)

    End Sub
End Class
