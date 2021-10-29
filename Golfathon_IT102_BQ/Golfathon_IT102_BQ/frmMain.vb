' ************************************************************************************
' Brad Quinton
' April 20, 2021
' IT 102-001
' Spring 2021
' Final Project (updated Assignment 8 - Golf-a-Thon)
' This form is the "main" form for this assignment.
' ************************************************************************************
Option Strict On

Public Class frmMain

    Private Sub btnManageGolfers_Click(sender As Object, e As EventArgs) Handles btnManageGolfers.Click

        ' This creates a new instance of frmManageGolfers.
        Dim ManageGolfers As New frmManageGolfers

        ' This shows the new instance of frmManageGolfers form modally (i.e., the new instance stays in
        ' the forefront on the screen until the form is exited).
        ManageGolfers.ShowDialog()

    End Sub




    Private Sub btnManageEvents_Click(sender As Object, e As EventArgs) Handles btnManageEvents.Click

        ' This creates a new instance of frmManageEvents.
        Dim ManageEvents As New frmManageEvents

        ' This shows the new instance of frmManageEvents form modally (i.e., the new instance stays in
        ' the forefront on the screen until the form is exited).
        ManageEvents.ShowDialog()

    End Sub




    Private Sub btnManageSponsors_Click(sender As Object, e As EventArgs) Handles btnManageSponsors.Click

        ' This creates a new instance of frmManageSponsors.
        Dim ManageSponsors As New frmManageSponsors

        ' This shows the new instance of frmManageSponsors form modally (i.e., the new instance stays in
        ' the forefront on the screen until the form is exited).
        ManageSponsors.ShowDialog()

    End Sub




    Private Sub btnManageGolfersAndEvents_Click(sender As Object, e As EventArgs) Handles btnManageGolfersAndEvents.Click

        ' This creates a new instance of frmManageGolfersAndEvents.
        Dim ManageGolfersAndEvents As New frmManageGolfersAndEvents

        ' This shows the new instance of frmManageGolfersAndEvents form modally (i.e., the new instance stays in
        ' the forefront on the screen until the form is exited).
        ManageGolfersAndEvents.ShowDialog()

    End Sub




    Private Sub btnManageGolfersAndSponsors_Click(sender As Object, e As EventArgs) Handles btnManageGolfersAndSponsors.Click

        ' This creates a new instance of frmManageSponsorsGolfersEvents.
        Dim ManageGolfersSponsorsEvents As New frmManageSponsorsGolfersEvents

        ' This shows the new instance of frmManageSponsorsGolfersEvents form modally (i.e., the new instance stays in
        ' the forefront on the screen until the form is exited).
        ManageGolfersSponsorsEvents.ShowDialog()

    End Sub



    Private Sub btnAggregates_Click(sender As Object, e As EventArgs) Handles btnAggregates.Click

        ' This creates a new instance of frmManageSponsorsGolfersEvents.
        Dim AggregateAmounts As New frmAggregates

        ' This shows the new instance of frmManageSponsorsGolfersEvents form modally (i.e., the new instance stays in
        ' the forefront on the screen until the form is exited).
        AggregateAmounts.ShowDialog()

    End Sub




    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' This button closes the main program.
        Close()

    End Sub

End Class
