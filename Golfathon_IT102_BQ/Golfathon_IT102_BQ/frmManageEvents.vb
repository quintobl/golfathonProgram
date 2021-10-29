
' ************************************************************************************
' Brad Quinton
' April 20, 2021
' IT 102-001
' Spring 2021
' Final Project (updated Assignment 8 - Golf-a-Thon)
' This form is the "Manage Events" form for this assignment.  It pulls event
' years from the golf-a-thon database and loads the combo box.  Once the 
' event is selected, the event year data is pulled and loaded onto
' this form.
' ************************************************************************************

Option Strict On

Public Class frmManageEvents

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Load_EventYears() ' Load names combo box last so it pulls all info for event (namely, the event year).

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub




    Private Sub Load_EventYears()

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
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load table from data reader.
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the event year ID associated with the event 
            ' year so when we click on the year we can then use the ID to pull the event year data.
            ' We are binding the column name to the combo box display and value members. 
            cboEventYears.ValueMember = "intEventYearID"
            cboEventYears.DisplayMember = "intEventYear"
            cboEventYears.DataSource = dt

            ' Select the first item in the list by default.
            If cboEventYears.Items.Count > 0 Then cboEventYears.SelectedIndex = 0

            ' Clean up.
            drSourceTable.Close()

            ' Close the database connection.
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message.
            MessageBox.Show(ex.Message)

        End Try

    End Sub




    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' Closes the program.
        Close()

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




    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click

        ' Create a new instance of the add form.
        Dim AddEvent As New frmAddEvent

        ' Show the new form so any past data is not still on the form.
        AddEvent.ShowDialog()

        ' Call the form load so the combo box refreshes with current data.
        Form1_Load(sender, e)

    End Sub



    Private Sub cboEventYears_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEventYears.SelectedIndexChanged

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
            strSelect = "SELECT intEventYear FROM TEventYears Where intEventYearID = " & cboEventYears.SelectedValue.ToString

            ' Retrieve all the records.
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' Load the data table from the reader.
            dt.Load(drSourceTable)

            ' Populate the text boxes with the data.
            txtEventYear.Text = dt.Rows(0).Item(0).ToString

            ' Close the database connection.
            CloseDatabaseConnection()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class