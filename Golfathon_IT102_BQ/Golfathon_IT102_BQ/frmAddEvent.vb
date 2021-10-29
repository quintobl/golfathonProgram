' ************************************************************************************
' Brad Quinton
' April 20, 2021
' IT 102-001
' Spring 2021
' Final Project (updated Assignment 8 - Golf-a-Thon)
' This form is the "Add Event" form for this assignment.  It adds the event year
' to the golf-a-thon database after the user inputs the new event year data.
' ************************************************************************************

Option Strict On

Public Class frmAddEvent

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' This button closes the form.
        Close()

    End Sub




    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click

        ' Declare local variable for the text box field that will hold event year data from the database.
        Dim intEventYear As Integer

        ' This calls the validation function.
        If Validation(intEventYear) = True Then

            ' This calls the AddEventYear sub, passing all parameters from the uspAddEvent sproc in the database.
            AddEventYear(intEventYear)
        End If

    End Sub




    Private Sub AddEventYear(ByVal EventYear As Integer)

        Dim cmdAddEvent As New OleDb.OleDbCommand() ' Add event command object.
        Dim intRowsAffected As Integer  ' Stores number of rows that were affected when sproc was executed.
        Dim intPKID As Integer ' Declare variable for the event year primary key parameter in the uspAddEvent sproc.

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' ...and close the form/application.
                Me.Close()

            End If

            ' Call stored procedure.
            cmdAddEvent.CommandText = "EXECUTE uspAddEvent '" & intPKID & "','" & EventYear & "'"
            cmdAddEvent.CommandType = CommandType.StoredProcedure

            ' Execute sproc call command.
            cmdAddEvent = New OleDb.OleDbCommand(cmdAddEvent.CommandText, m_conAdministrator)

            ' This stores the number of rows affected by the execution of the sproc.
            intRowsAffected = cmdAddEvent.ExecuteNonQuery()

            ' If number of rows affected is not 0, the insert was successful.
            If intRowsAffected > 0 Then
                MessageBox.Show("Event has been added.")    ' Let user know the add was successful.
                CloseDatabaseConnection()                   ' Close DB connection.
                Close()                                     ' Close new event form.
            End If

            ' Close connection to the database is execution of the sproc was unsuccessful.
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub




    Function Validation(ByRef EventYear As Integer) As Boolean

        ' Ensure the backcolor of the text box is white, if it isn't.
        txtEventYear.BackColor = Color.White

        ' Validate event year text box.
        If txtEventYear.Text <> String.Empty Then
            EventYear = CInt(txtEventYear.Text)
        Else
            ' If the text box is blank, this pops a message telling the user to enter the event year. It changes the
            ' back color to yellow, and puts the focus in the text box and returns false.
            MessageBox.Show("Please enter event year.")
            txtEventYear.BackColor = Color.Yellow
            txtEventYear.Focus()
            Return False
        End If

        ' Return true.
        Return True

    End Function

End Class