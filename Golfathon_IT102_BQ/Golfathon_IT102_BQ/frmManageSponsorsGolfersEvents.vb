' ************************************************************************************
' Brad Quinton
' April 20, 2021
' IT 102-001
' Spring 2021
' Final Project (updated Assignment 8 - Golf-a-Thon)
' This form is the "Manage Sponsors Golfers Events" form for this assignment.  The
' user chooses an event year, then a golfer name (from a list of golfers that are
' tied to that chosen event year), then a sponsor name (from a list of available
' sponsors), then a payment type, then a sponsor type, then a pledge amount, then
' whether or not the amount was paid.
' ************************************************************************************

Option Strict On

Public Class frmManageSponsorsGolfersEvents

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



            ' *************************************************************************************
            ' Load Payment Type Combo Box
            ' *************************************************************************************

            Dim drSourceTable3 As OleDb.OleDbDataReader ' This will be where our data is retrieved to.
            Dim dt3 As DataTable = New DataTable ' This is the table we will load from our reader.


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
            strSelect = "SELECT intPaymentTypeID, strPaymentTypeDesc FROM TPaymentTypes"

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable3 = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt3.Load(drSourceTable3)


            ' Add the item to the list box.
            ' We are binding the column name to the combo box display and value members. 
            cboPaymentType.ValueMember = "intPaymentTypeID"
            cboPaymentType.DisplayMember = "strPaymentTypeDesc"
            cboPaymentType.DataSource = dt3

            ' Select the first item in the list box by default.
            If cboPaymentType.Items.Count > 0 Then cboPaymentType.SelectedIndex = 0

            ' Clean up.
            drSourceTable3.Close()

            ' Close the database connection.
            CloseDatabaseConnection()




            ' *************************************************************************************
            ' Load Sponsor Type Combo Box
            ' *************************************************************************************

            Dim drSourceTable4 As OleDb.OleDbDataReader ' This will be where our data is retrieved to.
            Dim dt4 As DataTable = New DataTable ' This is the table we will load from our reader.


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
            strSelect = "SELECT intSponsorTypeID, strSponsorTypeDesc FROM TSponsorTypes"

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable4 = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt4.Load(drSourceTable4)


            ' Add the item to the list box.
            ' We are binding the column name to the combo box display and value members. 
            cboSponsorType.ValueMember = "intSponsorTypeID"
            cboSponsorType.DisplayMember = "strSponsorTypeDesc"
            cboSponsorType.DataSource = dt4

            ' Select the first item in the list box by default.
            If cboSponsorType.Items.Count > 0 Then cboSponsorType.SelectedIndex = 0

            ' Clean up.
            drSourceTable4.Close()

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




    Function Validation(ByRef monPledgeAmount As Double) As Boolean

        ' Ensure the backcolor of the text boxes are white, if they aren't.
        txtAmountPledged.BackColor = Color.White

        ' Validate amount pledged text box.
        If txtAmountPledged.Text <> String.Empty Then
            monPledgeAmount = CDbl(txtAmountPledged.Text)
        Else
            ' If the text box is blank, this pops a message telling the user to enter the amount pledged. It changes the
            ' back color to yellow, and puts the focus in the text box and returns false.
            MessageBox.Show("Please enter a pledge amount.")
            txtAmountPledged.BackColor = Color.Yellow
            txtAmountPledged.Focus()
            Return False
        End If

        Return True

    End Function




    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' Closes the program.
        Close()

    End Sub




    Private Sub AddSponsorToGolfer(ByVal intGolferID As Integer, ByVal intEventYearID As Integer, ByVal intSponsorID As Integer,
                          ByVal monPledgeAmount As Double, ByVal intSponsorTypeID As Integer, ByVal intPaymentTypeID As Integer,
                                   ByVal blnPaid As Integer)



        Dim cmdAddSponsorToGolfer As New OleDb.OleDbCommand() ' Add sponsor command object.
        Dim intRowsAffected As Integer  ' Stores number of rows that were affected when sproc was executed.
        Dim intPKID As Integer ' Declare variable for the sponsor primary key parameter in the AddSponsorToGolfer sproc.


        monPledgeAmount = CDbl(txtAmountPledged.Text)

        If radPaid.Checked = True Then
            blnPaid = 1
        ElseIf radUnpaid.Checked = True Then
            blnPaid = 0
        End If

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
            cmdAddSponsorToGolfer.CommandText = "EXECUTE uspAddSponsorToGolfer " & intPKID & "," & lstGolfer.SelectedValue.ToString & "," &
                cboEventYear.SelectedValue.ToString & "," & lstSponsor.SelectedValue.ToString & "," & monPledgeAmount & "," &
                cboSponsorType.SelectedValue.ToString & "," & cboPaymentType.SelectedValue.ToString & "," & blnPaid
            cmdAddSponsorToGolfer.CommandType = CommandType.StoredProcedure


            ' Execute sproc call command.
            cmdAddSponsorToGolfer = New OleDb.OleDbCommand(cmdAddSponsorToGolfer.CommandText, m_conAdministrator)

            ' This stores the number of rows affected by the execution of the sproc.
            intRowsAffected = cmdAddSponsorToGolfer.ExecuteNonQuery()

            ' Uncomment out the following message box line to use as a tool to check your sql statement.
            ' Remember anything not a numeric value going into SQL Server must have single quotes (')
            ' around it, including dates.
            'MessageBox.Show(cmdAddSponsorToGolfer.CommandText)


            ' Have to let the user know what happened.
            If intRowsAffected < 0 Then
                MessageBox.Show("Sponsor was added")
            Else
                MessageBox.Show("Add failed")
            End If

            ' Close connection to the database is execution of the sproc was unsuccessful.
            CloseDatabaseConnection()




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Sub btnAddSponsorToGolfer_Click(sender As Object, e As EventArgs) Handles btnAddSponsorToGolfer.Click

        ' Declare local variables for all text box fields that will hold sponsor/golfer data from the database.
        Dim intGolferID As Integer
        Dim intEventYearID As Integer
        Dim intSponsorID As Integer
        Dim monPledgeAmount As Double
        Dim intSponsorTypeID As Integer
        Dim intPaymentTypeID As Integer
        Dim blnPaid As Integer

        ' This calls the validation function.
        If Validation(monPledgeAmount) = True Then

            ' This calls the AddSponsor sub, passing all parameters from the uspAddSponsor sproc in the database.
            AddSponsorToGolfer(intGolferID, intEventYearID, intSponsorID, monPledgeAmount, intSponsorTypeID, intPaymentTypeID, blnPaid)

        End If

    End Sub

End Class