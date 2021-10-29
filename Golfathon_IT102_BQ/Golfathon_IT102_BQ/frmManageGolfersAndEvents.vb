' ************************************************************************************
' Brad Quinton
' April 20, 2021
' IT 102-001
' Spring 2021
' Final Project (updated Assignment 8 - Golf-a-Thon)
' This form is the "Manage Golfers and Events" form for this assignment.  It pulls
' event years from the golf-a-thon database and loads the combo box.  Once the 
' event year is selected, the user can add golfers to that event year.  The user
' is also able to drop golfers from an event year.
' ************************************************************************************

Option Strict On

Public Class frmManageGolfersAndEvents
    Private Sub frmManageGolfersAndEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' This will be used for our Select statement.
            Dim drSourceTable As OleDb.OleDbDataReader ' This will be where our data is retrieved to.
            Dim dt As DataTable = New DataTable ' This is the table we will load from our reader.



            ' *************************************************************************************
            ' Load Available Golfers Listbox
            ' *************************************************************************************

            Dim dt1 As DataTable = New DataTable ' This is the table we will load from our reader.
            Dim drSourceTable1 As OleDb.OleDbDataReader ' This will be where our data is retrieved to.

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



            ' Build the select statement.
            strSelect = "SELECT intGolferID, strLastName FROM vAvailableGolfers"

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable1 = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt1.Load(drSourceTable1)


            ' Add the item to the list box.
            ' We are binding the column name to the list box display and value members. 
            lstAvailableGolfers.ValueMember = "intGolferID"
            lstAvailableGolfers.DisplayMember = "strLastName"
            lstAvailableGolfers.DataSource = dt1



            ' Select the first item in the list by default.
            If lstAvailableGolfers.Items.Count > 0 Then lstAvailableGolfers.SelectedIndex = 0



            ' Clean up.
            drSourceTable1.Close()

            ' Close the database connection.
            CloseDatabaseConnection()

            ' *************************************************************************************
            ' Load EventYears Combo Box
            ' *************************************************************************************




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



            ' Build the select statement for combo box for event years.
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears ORDER BY intEventYearID DESC"

            ' Retrieve all the records .
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt.Load(drSourceTable)


            ' Add the item to the combo box. We need the event year ID associated with the event year, so 
            ' when we click on the event year we can then use the ID to pull the rest of the event year's data.
            ' We are binding the column name to the combo box display and value members. 
            cboYears.ValueMember = "intEventYearID"
            cboYears.DisplayMember = "intEventYear"
            cboYears.DataSource = dt

            ' Select the first item in the list by default.
            If cboYears.Items.Count > 0 Then cboYears.SelectedIndex = 0



            ' Clean up.
            drSourceTable.Close()

            ' Close the database connection.
            CloseDatabaseConnection()




        Catch excError As Exception

            ' Log and display error message.
            MessageBox.Show(excError.Message)

        End Try

    End Sub



    Private Sub cboYears_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYears.SelectedIndexChanged
        ' This will load golfers based on index (DB PK) into the list box for golfers 
        ' when combo box index changes.
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dt As DataTable = New DataTable ' this is the table we will load from our reader


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



            ' Build the select statement for listbox with golfers in the event year that was selected.
            strSelect = "SELECT intGolferID, strLastName FROM vGolferEvents WHERE intEventYearID = " & cboYears.SelectedValue.ToString

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt.Load(drSourceTable)


            ' Add the item to the combo box.
            ' We are binding the column name to the combo box display and value members. 
            lstInEvent.ValueMember = "intGolferID"
            lstInEvent.DisplayMember = "strLastName"
            lstInEvent.DataSource = dt

            ' Select the first item in the list by default.
            If lstInEvent.Items.Count > 0 Then lstInEvent.SelectedIndex = 0



            ' Clean up.
            drSourceTable.Close()

            ' Close the database connection.
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' Closes the form.
        Close()

    End Sub

    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click

        ' This sub will add an available golfer to the event year in the combo box. The 
        ' golfer will then show up in the golfers list box when the event year is selected
        ' in the combo box.

        Try

            Dim cmdAddGolferToEvent As New OleDb.OleDbCommand() ' Add golfer to event command object.
            Dim intRowsAffected As Integer  ' Stores number of rows that were affected when sproc was executed.
            Dim intPKID As Integer ' Declare variable for the golfer primary key parameter in the uspAddGolferEvent sproc.

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


            ' Call the stored procedure.
            cmdAddGolferToEvent.CommandText = "EXECUTE uspAddGolferEvent " & intPKID & "," &
                lstAvailableGolfers.SelectedValue.ToString & "," & cboYears.SelectedValue.ToString
            cmdAddGolferToEvent.CommandType = CommandType.StoredProcedure

            ' Execute sproc call command.
            cmdAddGolferToEvent = New OleDb.OleDbCommand(cmdAddGolferToEvent.CommandText, m_conAdministrator)

            ' This stores the number of rows affected by the execution of the sproc.
            intRowsAffected = cmdAddGolferToEvent.ExecuteNonQuery()

            ' Close the database connection.
            CloseDatabaseConnection()

            ' reload the form so the changes are shown
            frmManageGolfersAndEvents_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub btnDropGolfer_Click(sender As Object, e As EventArgs) Handles btnDropGolfer.Click

        Dim strDelete As String = ""
        Dim strSelect As String = String.Empty
        Dim strName As String = ""
        Dim intRowsAffected As Integer
        Dim cmdDelete As OleDb.OleDbCommand ' This will be used for our Delete statement.
        Dim dt As DataTable = New DataTable ' This is the table we will load from our reader.
        Dim result As DialogResult


        Try

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
            result = MessageBox.Show("Are you sure you want to Delete Golfer: Last Name-" & lstInEvent.Text & " from " & cboYears.Text & " ?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            ' This will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion.
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes


                    ' Build the delete statement using PK from golfer selected.
                    strDelete = "Delete FROM TGolferEventYears Where intGolferID = " & lstInEvent.SelectedValue.ToString & "AND intEventYearID = " & cboYears.SelectedValue.ToString

                    ' Delete the record(s).
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()


            End Select


            ' Close the database connection.
            CloseDatabaseConnection()

            ' Refresh the form so changes can be seen.
            frmManageGolfersAndEvents_Load(sender, e)

        Catch excError As Exception

            ' Log and display error message.
            MessageBox.Show(excError.Message)

        End Try

    End Sub

End Class