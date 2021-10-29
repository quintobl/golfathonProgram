' ************************************************************************************
' Brad Quinton
' April 20, 2021
' IT 102-001
' Spring 2021
' Final Project (updated Assignment 8 - Golf-a-Thon)
' This form is the "Add Sponsors" form for this assignment.  It adds a sponsor
' to the golf-a-thon database after the user inputs the new sponsor data.
' ************************************************************************************

Option Strict On

Public Class frmAddSponsor
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' This button closes the form.
        Close()

    End Sub




    Private Sub btnAddSponsor_Click(sender As Object, e As EventArgs) Handles btnAddSponsor.Click

        ' Declare local variables for all text box fields that will hold sponsor data from the database.
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""

        ' This calls the validation function.
        If Validation(strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail) = True Then

            ' This calls the AddSponsor sub, passing all parameters from the uspAddSponsor sproc in the database.
            AddSponsor(strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail)

        End If

    End Sub




    Private Sub AddSponsor(ByVal FirstName As String, ByVal LastName As String, ByVal StreetAddress As String,
                          ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal PhoneNumber As String, ByVal Email As String)

        Dim cmdAddSponsor As New OleDb.OleDbCommand() ' Add sponsor command object.
        Dim intRowsAffected As Integer  ' Stores number of rows that were affected when sproc was executed.
        Dim intPKID As Integer ' Declare variable for the sponsor primary key parameter in the uspAddSponsor sproc.

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
            cmdAddSponsor.CommandText = "EXECUTE uspAddSponsor '" & intPKID & "','" & FirstName & "','" & LastName & "','" &
                StreetAddress & "','" & City & "','" & State & "','" & Zip & "','" & PhoneNumber & "','" & Email & "'"
            cmdAddSponsor.CommandType = CommandType.StoredProcedure

            ' Execute sproc call command.
            cmdAddSponsor = New OleDb.OleDbCommand(cmdAddSponsor.CommandText, m_conAdministrator)

            ' This stores the number of rows affected by the execution of the sproc.
            intRowsAffected = cmdAddSponsor.ExecuteNonQuery()

            ' If number of rows affected is not 0, the insert was successful.
            If intRowsAffected > 0 Then
                MessageBox.Show("Sponsor has been added.")    ' Let user know the add was successful.
                CloseDatabaseConnection()                     ' Close DB connection.
                Close()                                       ' Close new event form.
            End If

            ' Close connection to the database is execution of the sproc was unsuccessful.
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub




    Function Validation(ByRef FirstName As String, ByRef LastName As String, ByRef Address As String, ByRef City As String,
                        ByRef State As String, ByRef Zip As String, ByRef Phone As String, ByRef Email As String) As Boolean

        ' Ensure the backcolor of the text boxes are white, if they aren't.
        txtFirstName.BackColor = Color.White
        txtLastName.BackColor = Color.White
        txtAddress.BackColor = Color.White
        txtCity.BackColor = Color.White
        txtState.BackColor = Color.White
        txtZip.BackColor = Color.White
        txtPhone.BackColor = Color.White
        txtEmail.BackColor = Color.White

        ' Validate first name text box.
        If txtFirstName.Text <> String.Empty Then
            FirstName = txtFirstName.Text
        Else
            ' If the text box is blank, this pops a message telling the user to enter the first name. It changes the
            ' back color to yellow, and puts the focus in the text box and returns false.
            MessageBox.Show("Please enter sponsor's first name.")
            txtFirstName.BackColor = Color.Yellow
            txtFirstName.Focus()
            Return False
        End If

        ' Validate last name text box.
        If txtLastName.Text <> String.Empty Then
            LastName = txtLastName.Text
        Else
            ' If the text box is blank, this pops a message telling the user to enter the last name. It changes the
            ' back color to yellow, and puts the focus in the text box and returns false.
            MessageBox.Show("Please enter sponsor's last name.")
            txtLastName.BackColor = Color.Yellow
            txtLastName.Focus()
            Return False
        End If

        ' Validate address text box.
        If txtAddress.Text <> String.Empty Then
            Address = txtAddress.Text
        Else
            ' If the text box is blank, this pops a message telling the user to enter the address. It changes the
            ' back color to yellow, and puts the focus in the text box and returns false.
            MessageBox.Show("Please enter sponsor's address.")
            txtAddress.BackColor = Color.Yellow
            txtAddress.Focus()
            Return False
        End If

        ' Validate city text box.
        If txtCity.Text <> String.Empty Then
            City = txtCity.Text
        Else
            ' If the text box is blank, this pops a message telling the user to enter the city. It changes the
            ' back color to yellow, and puts the focus in the text box and returns false.
            MessageBox.Show("Please enter sponsor's city.")
            txtCity.BackColor = Color.Yellow
            txtCity.Focus()
            Return False
        End If

        ' Validate state text box.
        If txtState.Text <> String.Empty Then
            State = txtState.Text
        Else
            ' If the text box is blank, this pops a message telling the user to enter the state. It changes the
            ' back color to yellow, and puts the focus in the text box and returns false.
            MessageBox.Show("Please enter sponsor's state.")
            txtState.BackColor = Color.Yellow
            txtState.Focus()
            Return False
        End If

        ' Validate zip code text box.
        If txtZip.Text <> String.Empty Then
            Zip = txtZip.Text
        Else
            ' If the text box is blank, this pops a message telling the user to enter the zip. It changes the
            ' back color to yellow, and puts the focus in the text box and returns false.
            MessageBox.Show("Please enter sponsor's zip code.")
            txtZip.BackColor = Color.Yellow
            txtZip.Focus()
            Return False
        End If

        ' Validate phone number text box.
        If txtPhone.Text <> String.Empty Then
            Phone = txtPhone.Text
        Else
            ' If the text box is blank, this pops a message telling the user to enter the phone number. It changes the
            ' back color to yellow, and puts the focus in the text box and returns false.
            MessageBox.Show("Please enter sponsor's phone number.")
            txtPhone.BackColor = Color.Yellow
            txtPhone.Focus()
            Return False
        End If

        ' Validate email text box.
        If txtEmail.Text <> String.Empty Then
            Email = txtEmail.Text
        Else
            ' If the text box is blank, this pops a message telling the user to enter the email address. It changes the
            ' back color to yellow, and puts the focus in the text box and returns false.
            MessageBox.Show("Please enter sponsor's email address.")
            txtEmail.BackColor = Color.Yellow
            txtEmail.Focus()
            Return False
        End If

        Return True

    End Function

End Class