' ************************************************************************************
' Brad Quinton
' April 20, 2021
' IT 102-001
' Spring 2021
' Final Project (updated Assignment 8 - Golf-a-Thon)
' This form is the "Manage Sponsors" form for this assignment.  It pulls sponsors'
' last names from the golf-a-thon database and loads the combo box.  Once the 
' sponsor is selected, the rest of the sponsor's data is pulled and loaded onto
' this form.
' ************************************************************************************

Option Strict On

Public Class frmManageSponsors

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Load_Sponsor_Names() ' Load sponsor names combo box so it pulls all info for sponsor.

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub




    Private Sub Load_Sponsor_Names()

        ' This sub will load the sponsor into the combo box.

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
            strSelect = "SELECT intSponsorID, strLastName FROM TSponsors"

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the sponsor ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the sponsor's data.
            ' We are binding the column name to the combo box display and value members. 
            cboSponsorNames.ValueMember = "intSponsorID"
            cboSponsorNames.DisplayMember = "strLastName"
            cboSponsorNames.DataSource = dt

            ' Select the first item in the list by default.
            If cboSponsorNames.Items.Count > 0 Then cboSponsorNames.SelectedIndex = 0

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




    Private Sub btnDeleteSponsor_Click(sender As Object, e As EventArgs) Handles btnDeleteSponsor.Click

        ' This sub will delete a sponsor.

        Try

            Dim cmdDeleteSponsor As New OleDb.OleDbCommand() ' Delete sponsor command object.
            Dim intRowsAffected As Integer  ' Stores number of rows that were affected when sproc was executed.
            Dim intPKID1 As Integer ' Declare variable for the sponsor primary key parameter for child table.
            Dim intPKID2 As Integer ' Declare variable for the sponsor primary key parameter for parent table.
            Dim result As DialogResult  ' This is the result of which button the user selects.

            ' Open the database.
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
            result = MessageBox.Show("Are you sure you want to Delete Sponsor: Last Name-" & cboSponsorNames.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' This will figure out which button was selected. Cancel and No does nothing; Yes will allow deletion.
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    ' Call the stored procedure.
                    cmdDeleteSponsor.CommandText = "EXECUTE uspDeleteGolferEventYearSponsor " & cboSponsorNames.SelectedValue.ToString
                    cmdDeleteSponsor.CommandType = CommandType.StoredProcedure

                    ' Execute sproc call command.
                    cmdDeleteSponsor = New OleDb.OleDbCommand(cmdDeleteSponsor.CommandText, m_conAdministrator)

                    ' This stores the number of rows affected by the execution of the sproc.
                    intRowsAffected = cmdDeleteSponsor.ExecuteNonQuery()



                    ' Call the stored procedure.
                    cmdDeleteSponsor.CommandText = "EXECUTE uspDeleteSponsor " & cboSponsorNames.SelectedValue.ToString
                    cmdDeleteSponsor.CommandType = CommandType.StoredProcedure

                    ' Execute sproc call command.
                    cmdDeleteSponsor = New OleDb.OleDbCommand(cmdDeleteSponsor.CommandText, m_conAdministrator)

                    ' This stores the number of rows affected by the execution of the sproc.
                    intRowsAffected = cmdDeleteSponsor.ExecuteNonQuery()

                    ' Did it work?
                    If intRowsAffected > 0 Then

                        ' Yes, success!
                        MessageBox.Show("Delete successful")

                    End If

            End Select

            ' Close the database connection.
            CloseDatabaseConnection()

            ' reload the form so the changes are shown
            Form1_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub




    Private Sub btnUpdateSponsor_Click(sender As Object, e As EventArgs) Handles btnUpdateSponsor.Click

        Dim strFirstName As String = ""
        Dim strLastName As String = ""
        Dim strStreetAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""


        Try

            Dim cmdUpdateSponsor As New OleDb.OleDbCommand() ' Update sponsor command object.
            Dim intRowsAffected As Integer  ' Stores number of rows that were affected when sproc was executed.

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


                    ' Call the stored procedure.
                    cmdUpdateSponsor.CommandText = "EXECUTE uspUpdateSponsor " & cboSponsorNames.SelectedValue.ToString & "," & "'" &
                        strFirstName & "'," & "'" & strLastName & "'," & "'" & strStreetAddress & "'," & "'" & strCity & "'," &
                        "'" & strState & "'," &
                        "'" & strZip & "'," & "'" & strPhoneNumber & "'," & "'" & strEmail & "'"
                    cmdUpdateSponsor.CommandType = CommandType.StoredProcedure



                    ' Uncomment out the following message box line to use as a tool to check your sql statement.
                    ' Remember anything not a numeric value going into SQL Server must have single quotes (')
                    ' around it, including dates.
                    ' MessageBox.Show(cmdUpdateSponsor.CommandText)



                    ' Execute sproc call command.
                    cmdUpdateSponsor = New OleDb.OleDbCommand(cmdUpdateSponsor.CommandText, m_conAdministrator)

                    ' This stores the number of rows affected by the execution of the sproc.
                    intRowsAffected = cmdUpdateSponsor.ExecuteNonQuery()

                    ' Have to let the user know what happened.
                    If intRowsAffected = 1 Then
                        MessageBox.Show("Update successful")
                    Else
                        MessageBox.Show("Update failed")
                    End If

                    ' Close the database connection.
                    CloseDatabaseConnection()

                    ' Call the Form Load sub to refresh the combo box data after an update.
                    Form1_Load(sender, e)
                End If
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub




    Private Sub btnAddSponsor_Click(sender As Object, e As EventArgs) Handles btnAddSponsor.Click

        ' Create a new instance of the add form.
        Dim AddSponsor As New frmAddSponsor

        ' Show the new form so any past data is not still on the form.
        AddSponsor.ShowDialog()

        ' Call the form load so the combo box refreshes with current data.
        Form1_Load(sender, e)

    End Sub




    Private Sub cboSponsorNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSponsorNames.SelectedIndexChanged

        Dim strSelect As String = ""
        Dim strName As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' This will be used for our Select statement.
        Dim drSourceTable As OleDb.OleDbDataReader ' This will be where our data is retrieved to.
        Dim dt As DataTable = New DataTable ' This is the table we will load from our reader.

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
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail FROM TSponsors Where intSponsorID = " & cboSponsorNames.SelectedValue.ToString

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


            ' Close the database connection.
            CloseDatabaseConnection()


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

End Class
