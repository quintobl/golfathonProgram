' ************************************************************************************
' Brad Quinton
' April 20, 2021
' IT 102-001
' Spring 2021
' Final Project (updated Assignment 8 - Golf-a-Thon)
' This form is the "Manage Golfers" form for this assignment.  It pulls golfers'
' last names from the golf-a-thon database and loads the combo box.  Once the 
' golfer is selected, the rest of the golfer's data is pulled and loaded onto
' this form.
' ************************************************************************************

Option Strict On

Public Class frmManageGolfers

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Load_ShirtSize() ' Load shirt size combo box.

            Load_Gender() ' Load gender combo box.

            Load_Names() ' Load names combo box last so it pulls all info for golfer including shirt size and gender.

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub




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




    Private Sub Load_Names()

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
            strSelect = "SELECT intGolferID, strLastName FROM TGolfers"

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the golfer ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the golfer's data.
            ' We are binding the column name to the combo box display and value members. 
            cboNames.ValueMember = "intGolferID"
            cboNames.DisplayMember = "strLastName"
            cboNames.DataSource = dt

            ' Select the first item in the list by default.
            If cboNames.Items.Count > 0 Then cboNames.SelectedIndex = 0

            ' Clean up.
            drSourceTable.Close()

            ' Close the database connection.
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message.
            MessageBox.Show(ex.Message)

        End Try

    End Sub




    Public Function Validation() As Boolean

        ' Loop through the textboxes and check to make sure there is data in them.
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.BackColor = Color.White
                If cntrl.Text = String.Empty Then
                    cntrl.BackColor = Color.Yellow
                    cntrl.Focus()
                    Return False
                End If
            End If
        Next

        ' If validated then return true.
        Return True

    End Function




    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' Closes the program.
        Close()

    End Sub




    Private Sub btnDeleteGolfers_Click(sender As Object, e As EventArgs) Handles btnDeleteGolfers.Click

        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' This will be used for our Delete statement.
        Dim dt As DataTable = New DataTable ' This is the table we will load from our reader.
        Dim result As DialogResult  ' This is the result of which button the user selects.

        Try
            ' Open the database; this is in module.
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' ...and close the form/application.
                Me.Close()

            End If

            ' Always ask before deleting!!!!
            result = MessageBox.Show("Are you sure you want to Delete Golfer: Last Name-" & cboNames.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' This will figure out which button was selected. Cancel and No does nothing; Yes will allow deletion.
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    ' Build the delete statement using PK from name selected.
                    ' Must delete any child records first.
                    ' This is a deletion of child records from the TGolferEventYearSponsors table,
                    ' which has as a FK the PK of intGolferID from the TGolfers table.
                    strDelete = "Delete FROM TGolferEventYearSponsors Where intGolferID = " & cboNames.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()


                    ' Build the delete statement using PK from name selected.
                    ' Must delete any child records first.
                    ' This is a deletion of child records from the TGolferEventYears table,
                    ' which has as a FK the PK of intGolferID from the TGolfers table.
                    strDelete = "Delete FROM TGolferEventYears Where intGolferID = " & cboNames.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()


                    ' Now we can delete the parent record.
                    strDelete = "Delete FROM TGolfers Where intGolferID = " & cboNames.SelectedValue.ToString

                    ' Delete the record(s) 
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    ' Did it work?
                    If intRowsAffected > 0 Then

                        ' Yes, success!
                        MessageBox.Show("Delete successful")

                    End If

            End Select


            ' Close the database connection.
            CloseDatabaseConnection()

            ' Call the Form Load sub to refresh the combo box data after a delete.
            Form1_Load(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub




    Private Sub btnUpdateGolfers_Click(sender As Object, e As EventArgs) Handles btnUpdateGolfers.Click

        Dim strSelect As String = ""
        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        Dim intRowsAffected As Integer

        Try

            ' This will hold our Update statement.
            Dim cmdUpdate As OleDb.OleDbCommand

            ' Check to make sure all text boxes have data. No data, no update!
            If Validation() = True Then
                ' Open database.
                If OpenDatabaseConnectionSQLServer() = False Then

                    ' No, warn the user ...
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' ... and close the form/application.
                    Me.Close()

                End If

                ' After you validate that there is data, put values into variables.
                If Validation() = True Then

                    strFirstName = txtFirstName.Text
                    strLastName = txtLastName.Text
                    strStreetAddress = txtAddress.Text
                    strCity = txtCity.Text
                    strState = txtState.Text
                    strZip = txtZip.Text
                    strPhoneNumber = txtPhone.Text
                    strEmail = txtEmail.Text


                    ' Build the Select statement using PK from name selected.
                    strSelect = "Update TGolfers Set strFirstName = '" & strFirstName & "', " & "strLastName = '" & strLastName &
                    "', " & "strStreetAddress = '" & strStreetAddress & "', " & "strCity = '" & strCity & "', " &
                     "strState = '" & strState & "', " & "strZip = '" & strZip & "', " & "strPhoneNumber = '" & strPhoneNumber &
                     "', " & "strEmail = '" & strEmail & "', " & "intShirtSizeID = " & cboShirtSize.SelectedValue.ToString & ", " &
                     "intGenderID = " & cboGender.SelectedValue.ToString &
                     "Where intGolferID = " & cboNames.SelectedValue.ToString

                    ' Uncomment out the following message box line to use as a tool to check your sql statement.
                    ' Remember anything not a numeric value going into SQL Server must have single quotes (')
                    ' around it, including dates.
                    ' MessageBox.Show(strSelect)

                    ' Make the connection.
                    cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                    ' Update the row with execute the statement.
                    intRowsAffected = cmdUpdate.ExecuteNonQuery()

                    ' Have to let the user know what happened.
                    If intRowsAffected = 1 Then
                        MessageBox.Show("Update successful")
                    Else
                        MessageBox.Show("Update failed")
                    End If

                    ' Close the database connection.
                    CloseDatabaseConnection()

                    ' Call the Form Load sub to refresh the combo box data after a delete.
                    Form1_Load(sender, e)
                End If
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub




    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click

        ' Create a new instance of the add form.
        Dim AddGolfer As New frmAddGolfer

        ' Show the new form so any past data is not still on the form.
        AddGolfer.ShowDialog()

        ' Call the form load so the combo box refreshes with current data.
        Form1_Load(sender, e)

    End Sub




    Private Sub cboNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNames.SelectedIndexChanged

        Dim strSelect As String = ""
        Dim strName As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' This will be used for our Select statement.
        Dim drSourceTable As OleDb.OleDbDataReader ' This will be where our data is retrieved to.
        Dim dt As DataTable = New DataTable ' This is the table we will load from our reader.
        Dim intShirtSize As Integer
        Dim intGender As Integer

        Try

            ' Open the database.
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' ... and close the form/application.
                Me.Close()

            End If

            ' Build the select statement using PK from name selected.
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID FROM TGolfers Where intGolferID = " & cboNames.SelectedValue.ToString

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load the data table from the reader.
            dt.Load(drSourceTable)

            ' Populate the text boxes with the data.
            txtFirstName.Text = dt.Rows(0).Item(0).ToString
            txtLastName.Text = dt.Rows(0).Item(1).ToString
            txtAddress.Text = dt.Rows(0).Item(2).ToString
            txtCity.Text = dt.Rows(0).Item(3).ToString
            txtState.Text = dt.Rows(0).Item(4).ToString
            txtZip.Text = dt.Rows(0).Item(5).ToString
            txtPhone.Text = dt.Rows(0).Item(6).ToString
            txtEmail.Text = dt.Rows(0).Item(7).ToString

            intShirtSize = CInt(dt.Rows(0).Item(8)) ' Put shirt size ID (in position 8 of the Select statement) into a variable.
            cboShirtSize.SelectedValue = intShirtSize ' Set selected value of shirt size combo box to correct size.

            intGender = CInt(dt.Rows(0).Item(9)) ' Put gender ID (in position 9 of the Select statement) into a variable.
            cboGender.SelectedValue = intGender ' Set selected value of gender combo box to correct gender.

            ' Close the database connection.
            CloseDatabaseConnection()


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

End Class
