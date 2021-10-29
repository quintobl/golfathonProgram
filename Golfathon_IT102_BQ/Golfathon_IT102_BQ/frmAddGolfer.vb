' ************************************************************************************
' Brad Quinton
' April 20, 2021
' IT 102-001
' Spring 2021
' Final Project (updated Assignment 8 - Golf-a-Thon)
' This form is the "Add Golfer" form for this assignment.  It adds golfer information
' to the golf-a-thon database after the user inputs the new golfer data.
' ************************************************************************************

Option Strict On

Public Class frmAddGolfer

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' This button closes the form.
        Close()

    End Sub




    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click

        ' Declare local variables for all text box fields that will hold golfer data from the database.
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        Dim intShirtSizeID As Integer
        Dim intGenderID As Integer

        ' This calls the validation function.
        If Validation(strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail) = True Then

            ' This calls the AddGolfer sub, passing all parameters from the uspAddGolfer sproc in the database.
            AddGolfer(strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail,
                      intShirtSizeID, intGenderID)

        End If

    End Sub




    Private Sub AddGolfer(ByVal FirstName As String, ByVal LastName As String, ByVal StreetAddress As String,
                          ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal PhoneNumber As String, ByVal Email As String,
                          ByVal ShirtSize As Integer, ByVal Gender As Integer)

        Dim cmdAddGolfer As New OleDb.OleDbCommand() ' Add golfer command object.
        Dim intRowsAffected As Integer  ' How many rows were affected when sql executed.
        Dim intPKID As Integer  ' Declare variable for the golfer ID primary key parameter in the uspAddGolfer sproc.

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
            cmdAddGolfer.CommandText = "EXECUTE uspAddGolfer '" & intPKID & "','" & FirstName & "','" & LastName & "','" &
                StreetAddress & "','" & City & "','" & State & "','" & Zip & "','" & PhoneNumber & "','" &
                Email & "','" & cboShirtSize.SelectedValue.ToString & "','" & cboGender.SelectedValue.ToString & "'"
            cmdAddGolfer.CommandType = CommandType.StoredProcedure

            ' Execute sproc call command.
            cmdAddGolfer = New OleDb.OleDbCommand(cmdAddGolfer.CommandText, m_conAdministrator)

            ' This stores the number of rows affected by the execution of the sproc.
            intRowsAffected = cmdAddGolfer.ExecuteNonQuery()

            ' If number of rows affected is not 0, the insert was successful.
            If intRowsAffected > 0 Then
                MessageBox.Show("Golfer has been added.")   ' Let user know the add was successful.
                CloseDatabaseConnection()                   ' Close DB connection.
                Close()                                     ' Close new golfer form.
            Else
                MessageBox.Show("Insert failed")
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
            MessageBox.Show("Please enter golfer's first name.")
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
            MessageBox.Show("Please enter golfer's last name.")
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
            MessageBox.Show("Please enter golfer's address.")
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
            MessageBox.Show("Please enter golfer's city.")
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
            MessageBox.Show("Please enter golfer's state.")
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
            MessageBox.Show("Please enter golfer's zip code.")
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
            MessageBox.Show("Please enter golfer's phone number.")
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
            MessageBox.Show("Please enter golfer's email address.")
            txtEmail.BackColor = Color.Yellow
            txtEmail.Focus()
            Return False
        End If

        Return True

    End Function




    Private Sub Load_ShirtSize()

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' This will be used for our Select statement.
            Dim drSourceTable As OleDb.OleDbDataReader ' This will be where our data is retrieved to.
            Dim dt As DataTable = New DataTable ' This is the table we will load from our reader.

            ' Loop through the textboxes and clear them in case they have data in them after a delete.
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

            ' Open the DB.
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' ... and close the form/application.
                Me.Close()

            End If

            ' Build the Select statement.
            strSelect = "SELECT intShirtSizeID, strShirtSizeDesc FROM TShirtSizes"

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the shirt size ID associated with the shirt size, so 
            ' when we click on the shirt size we can then use the ID to pull the rest of the shirt size data.
            ' We are binding the column name to the combo box display and value members. 
            cboShirtSize.ValueMember = "intShirtSizeID"
            cboShirtSize.DisplayMember = "strShirtSizeDesc"
            cboShirtSize.DataSource = dt

            ' Select the first item in the list by default.
            If cboShirtSize.Items.Count > 0 Then cboShirtSize.SelectedIndex = 0

            ' Clean up.
            drSourceTable.Close()

            ' Close the database connection.
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message.
            MessageBox.Show(ex.Message)

        End Try

    End Sub




    Private Sub Load_Gender()

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' This will be used for our Select statement.
            Dim drSourceTable As OleDb.OleDbDataReader ' This will be where our data is retrieved to.
            Dim dt As DataTable = New DataTable ' This is the table we will load from our reader.

            ' Loop through the textboxes and clear them in case they have data in them after a delete.
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

            ' Open the DB.
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' ... and close the form/application.
                Me.Close()

            End If

            ' Build the Select statement.
            strSelect = "SELECT intGenderID, strGenderDesc FROM TGenders"

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the gender ID associated with the gender, so 
            ' when we click on the gender we can then use the ID to pull the rest of the gender data.
            ' We are binding the column name to the combo box display and value members. 
            cboGender.ValueMember = "intGenderID"
            cboGender.DisplayMember = "strGenderDesc"
            cboGender.DataSource = dt

            ' Select the first item in the list by default.
            If cboGender.Items.Count > 0 Then cboGender.SelectedIndex = 0

            ' Clean up.
            drSourceTable.Close()

            ' Close the database connection.
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message.
            MessageBox.Show(ex.Message)

        End Try

    End Sub




    Private Sub frmAddGolfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            ' Load shirt size combo box.
            Load_ShirtSize()

            ' Load gender combo box.
            Load_Gender()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class