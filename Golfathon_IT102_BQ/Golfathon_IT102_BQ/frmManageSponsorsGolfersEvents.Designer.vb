<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageSponsorsGolfersEvents
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cboEventYear = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAmountPledged = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPaymentType = New System.Windows.Forms.ComboBox()
        Me.btnAddSponsorToGolfer = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cboSponsorType = New System.Windows.Forms.ComboBox()
        Me.lstGolfer = New System.Windows.Forms.ListBox()
        Me.lstSponsor = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radUnpaid = New System.Windows.Forms.RadioButton()
        Me.radPaid = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboEventYear
        '
        Me.cboEventYear.FormattingEnabled = True
        Me.cboEventYear.Location = New System.Drawing.Point(121, 47)
        Me.cboEventYear.Name = "cboEventYear"
        Me.cboEventYear.Size = New System.Drawing.Size(171, 24)
        Me.cboEventYear.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(132, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Choose an Event Year"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Choose a Golfer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(151, 299)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Choose a Sponsor"
        '
        'txtAmountPledged
        '
        Me.txtAmountPledged.Location = New System.Drawing.Point(438, 129)
        Me.txtAmountPledged.Name = "txtAmountPledged"
        Me.txtAmountPledged.Size = New System.Drawing.Size(171, 22)
        Me.txtAmountPledged.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(444, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Choose a Sponsor Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(418, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(228, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Enter Amount Pledged for Sponsor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(442, 193)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(163, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Choose a Payment Type"
        '
        'cboPaymentType
        '
        Me.cboPaymentType.FormattingEnabled = True
        Me.cboPaymentType.Location = New System.Drawing.Point(438, 213)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(171, 24)
        Me.cboPaymentType.TabIndex = 12
        '
        'btnAddSponsorToGolfer
        '
        Me.btnAddSponsorToGolfer.Location = New System.Drawing.Point(146, 518)
        Me.btnAddSponsorToGolfer.Name = "btnAddSponsorToGolfer"
        Me.btnAddSponsorToGolfer.Size = New System.Drawing.Size(118, 74)
        Me.btnAddSponsorToGolfer.TabIndex = 14
        Me.btnAddSponsorToGolfer.Text = "Click to Add Sponsor to Golfer"
        Me.btnAddSponsorToGolfer.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(438, 518)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(118, 74)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cboSponsorType
        '
        Me.cboSponsorType.FormattingEnabled = True
        Me.cboSponsorType.Location = New System.Drawing.Point(438, 47)
        Me.cboSponsorType.Name = "cboSponsorType"
        Me.cboSponsorType.Size = New System.Drawing.Size(171, 24)
        Me.cboSponsorType.TabIndex = 10
        '
        'lstGolfer
        '
        Me.lstGolfer.FormattingEnabled = True
        Me.lstGolfer.ItemHeight = 16
        Me.lstGolfer.Location = New System.Drawing.Point(82, 129)
        Me.lstGolfer.Name = "lstGolfer"
        Me.lstGolfer.Size = New System.Drawing.Size(259, 132)
        Me.lstGolfer.TabIndex = 21
        '
        'lstSponsor
        '
        Me.lstSponsor.FormattingEnabled = True
        Me.lstSponsor.ItemHeight = 16
        Me.lstSponsor.Location = New System.Drawing.Point(82, 325)
        Me.lstSponsor.Name = "lstSponsor"
        Me.lstSponsor.Size = New System.Drawing.Size(259, 132)
        Me.lstSponsor.TabIndex = 22
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radUnpaid)
        Me.GroupBox1.Controls.Add(Me.radPaid)
        Me.GroupBox1.Location = New System.Drawing.Point(413, 299)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 140)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paid Status"
        '
        'radUnpaid
        '
        Me.radUnpaid.AutoSize = True
        Me.radUnpaid.Location = New System.Drawing.Point(49, 90)
        Me.radUnpaid.Name = "radUnpaid"
        Me.radUnpaid.Size = New System.Drawing.Size(74, 21)
        Me.radUnpaid.TabIndex = 1
        Me.radUnpaid.TabStop = True
        Me.radUnpaid.Text = "Unpaid"
        Me.radUnpaid.UseVisualStyleBackColor = True
        '
        'radPaid
        '
        Me.radPaid.AutoSize = True
        Me.radPaid.Location = New System.Drawing.Point(49, 36)
        Me.radPaid.Name = "radPaid"
        Me.radPaid.Size = New System.Drawing.Size(57, 21)
        Me.radPaid.TabIndex = 0
        Me.radPaid.TabStop = True
        Me.radPaid.Text = "Paid"
        Me.radPaid.UseVisualStyleBackColor = True
        '
        'frmManageSponsorsGolfersEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 641)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lstSponsor)
        Me.Controls.Add(Me.lstGolfer)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAddSponsorToGolfer)
        Me.Controls.Add(Me.cboPaymentType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboSponsorType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAmountPledged)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboEventYear)
        Me.Name = "frmManageSponsorsGolfersEvents"
        Me.Text = "Manage Sponsors Golfers and Events"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboEventYear As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAmountPledged As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cboPaymentType As ComboBox
    Friend WithEvents btnAddSponsorToGolfer As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents cboSponsorType As ComboBox
    Friend WithEvents lstGolfer As ListBox
    Friend WithEvents lstSponsor As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents radUnpaid As RadioButton
    Friend WithEvents radPaid As RadioButton
End Class
