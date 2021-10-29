' ************************************************************************************
' Brad Quinton
' April 20, 2021
' IT 102-001
' Spring 2021
' Final Project (updated Assignment 8 - Golf-a-Thon)
' This form is the "Aggregate Amounts" form for this assignment.  The user can
' get various sponsor totals.
' ************************************************************************************

Option Strict On

Public Class frmAggregates
    Private Sub frmAggregates_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            lstGolfer.ValueMember = "intGolferID"
            lstGolfer.DisplayMember = "strLastName"
            lstGolfer.DataSource = dt1



            ' Select the first item in the list by default.
            If lstGolfer.Items.Count > 0 Then lstGolfer.SelectedIndex = 0



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
            cboEventYear.ValueMember = "intEventYearID"
            cboEventYear.DisplayMember = "intEventYear"
            cboEventYear.DataSource = dt

            ' Select the first item in the list by default.
            If cboEventYear.Items.Count > 0 Then cboEventYear.SelectedIndex = 0



            ' Clean up.
            drSourceTable.Close()

            ' Close the database connection.
            CloseDatabaseConnection()


        Catch excError As Exception

            ' Log and display error message.
            MessageBox.Show(excError.Message)

        End Try

    End Sub




    Private Sub cboEventYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEventYear.SelectedIndexChanged
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
            strSelect = "SELECT intGolferID, strLastName FROM vGolferEvents WHERE intEventYearID = " & cboEventYear.SelectedValue.ToString

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt.Load(drSourceTable)


            ' Add the item to the combo box.
            ' We are binding the column name to the combo box display and value members. 
            lstGolfer.ValueMember = "intGolferID"
            lstGolfer.DisplayMember = "strLastName"
            lstGolfer.DataSource = dt

            ' Select the first item in the list by default.
            If lstGolfer.Items.Count > 0 Then lstGolfer.SelectedIndex = 0



            ' Clean up.
            drSourceTable.Close()

            ' Close the database connection.
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub




    Private Sub lstGolfer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstGolfer.SelectedIndexChanged
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



            ' Build the select statement for listbox with sponsors in the event year that was selected.
            strSelect = "SELECT intSponsorID, strLastName FROM vAvailableSponsors"

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt.Load(drSourceTable)


            ' Add the item to the combo box.
            ' We are binding the column name to the combo box display and value members. 
            lstSponsor.ValueMember = "intSponsorID"
            lstSponsor.DisplayMember = "strLastName"
            lstSponsor.DataSource = dt

            ' Select the first item in the list by default.
            If lstSponsor.Items.Count > 0 Then lstSponsor.SelectedIndex = 0



            ' Clean up.
            drSourceTable.Close()

            ' Close the database connection.
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try

    End Sub






    Private Sub btnEventTotals_Click(sender As Object, e As EventArgs) Handles btnEventTotals.Click


        Dim strSelect As String = ""
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
            strSelect = "SELECT SUM FROM vTotalEventDonations Where intEventYearID = " & cboEventYear.SelectedValue.ToString

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load the data table from the reader.
            dt.Load(drSourceTable)

            If strSelect <> "" Then
                txtEventTotals.Text = dt.Rows(0).Item(0).ToString
            Else
                txtEventTotals.Text = CDbl(0).ToString
            End If

            ' Close the database connection.
            CloseDatabaseConnection()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub





    Private Sub btnTotalByEvent_Click(sender As Object, e As EventArgs) Handles btnTotalByEvent.Click


        Dim strSelect As String = ""
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
            strSelect = "SELECT SUM FROM vGolferEventTotals Where intEventYearID = " & cboEventYear.SelectedValue.ToString

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load the data table from the reader.
            dt.Load(drSourceTable)

            If strSelect <> "" Then
                txtGolferTotalByEvent.Text = dt.Rows(0).Item(0).ToString
            Else
                txtGolferTotalByEvent.Text = CDbl(0).ToString
            End If

            ' Close the database connection.
            CloseDatabaseConnection()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub




    Private Sub btnSponsorTotal_Click(sender As Object, e As EventArgs) Handles btnSponsorTotal.Click


        Dim strSelect As String = ""
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
            strSelect = "SELECT SUM FROM vSponsorEventTotals Where intEventYearID = " & cboEventYear.SelectedValue.ToString

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load the data table from the reader.
            dt.Load(drSourceTable)

            If strSelect <> "" Then
                txtSponsorTotalByEvent.Text = dt.Rows(0).Item(0).ToString
            Else
                txtSponsorTotalByEvent.Text = CDbl(0).ToString
            End If

            ' Close the database connection.
            CloseDatabaseConnection()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub





    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' Closes the program.
        Close()

    End Sub
End Class