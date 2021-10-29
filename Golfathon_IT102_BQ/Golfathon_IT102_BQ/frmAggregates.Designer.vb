<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAggregates
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
        Me.txtGolferTotalByEvent = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEventTotals = New System.Windows.Forms.TextBox()
        Me.txtSponsorTotalByEvent = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnTotalByEvent = New System.Windows.Forms.Button()
        Me.btnEventTotals = New System.Windows.Forms.Button()
        Me.btnSponsorTotal = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lstSponsor = New System.Windows.Forms.ListBox()
        Me.lstGolfer = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'cboEventYear
        '
        Me.cboEventYear.FormattingEnabled = True
        Me.cboEventYear.Location = New System.Drawing.Point(32, 59)
        Me.cboEventYear.Name = "cboEventYear"
        Me.cboEventYear.Size = New System.Drawing.Size(171, 24)
        Me.cboEventYear.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Event Year"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(337, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Golfer Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(580, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Sponsor Name"
        '
        'txtGolferTotalByEvent
        '
        Me.txtGolferTotalByEvent.Location = New System.Drawing.Point(296, 411)
        Me.txtGolferTotalByEvent.Name = "txtGolferTotalByEvent"
        Me.txtGolferTotalByEvent.Size = New System.Drawing.Size(171, 22)
        Me.txtGolferTotalByEvent.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(309, 386)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Golfer Total By Event"
        '
        'txtEventTotals
        '
        Me.txtEventTotals.Location = New System.Drawing.Point(32, 411)
        Me.txtEventTotals.Name = "txtEventTotals"
        Me.txtEventTotals.Size = New System.Drawing.Size(171, 22)
        Me.txtEventTotals.TabIndex = 8
        '
        'txtSponsorTotalByEvent
        '
        Me.txtSponsorTotalByEvent.Location = New System.Drawing.Point(551, 411)
        Me.txtSponsorTotalByEvent.Name = "txtSponsorTotalByEvent"
        Me.txtSponsorTotalByEvent.Size = New System.Drawing.Size(171, 22)
        Me.txtSponsorTotalByEvent.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(73, 387)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Event Totals"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(560, 389)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(157, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Sponsor Total By Event"
        '
        'btnTotalByEvent
        '
        Me.btnTotalByEvent.Location = New System.Drawing.Point(321, 262)
        Me.btnTotalByEvent.Name = "btnTotalByEvent"
        Me.btnTotalByEvent.Size = New System.Drawing.Size(118, 74)
        Me.btnTotalByEvent.TabIndex = 12
        Me.btnTotalByEvent.Text = "Golfer Total By Event"
        Me.btnTotalByEvent.UseVisualStyleBackColor = True
        '
        'btnEventTotals
        '
        Me.btnEventTotals.Location = New System.Drawing.Point(58, 262)
        Me.btnEventTotals.Name = "btnEventTotals"
        Me.btnEventTotals.Size = New System.Drawing.Size(118, 74)
        Me.btnEventTotals.TabIndex = 13
        Me.btnEventTotals.Text = "Event Totals"
        Me.btnEventTotals.UseVisualStyleBackColor = True
        '
        'btnSponsorTotal
        '
        Me.btnSponsorTotal.Location = New System.Drawing.Point(574, 262)
        Me.btnSponsorTotal.Name = "btnSponsorTotal"
        Me.btnSponsorTotal.Size = New System.Drawing.Size(118, 74)
        Me.btnSponsorTotal.TabIndex = 14
        Me.btnSponsorTotal.Text = "Sponsor Total By Event"
        Me.btnSponsorTotal.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(321, 493)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(118, 74)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lstSponsor
        '
        Me.lstSponsor.FormattingEnabled = True
        Me.lstSponsor.ItemHeight = 16
        Me.lstSponsor.Location = New System.Drawing.Point(538, 59)
        Me.lstSponsor.Name = "lstSponsor"
        Me.lstSponsor.Size = New System.Drawing.Size(199, 148)
        Me.lstSponsor.TabIndex = 17
        '
        'lstGolfer
        '
        Me.lstGolfer.FormattingEnabled = True
        Me.lstGolfer.ItemHeight = 16
        Me.lstGolfer.Location = New System.Drawing.Point(283, 59)
        Me.lstGolfer.Name = "lstGolfer"
        Me.lstGolfer.Size = New System.Drawing.Size(199, 148)
        Me.lstGolfer.TabIndex = 16
        '
        'frmAggregates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 611)
        Me.Controls.Add(Me.lstSponsor)
        Me.Controls.Add(Me.lstGolfer)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSponsorTotal)
        Me.Controls.Add(Me.btnEventTotals)
        Me.Controls.Add(Me.btnTotalByEvent)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSponsorTotalByEvent)
        Me.Controls.Add(Me.txtEventTotals)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtGolferTotalByEvent)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboEventYear)
        Me.Name = "frmAggregates"
        Me.Text = "Aggregate Amounts"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboEventYear As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtGolferTotalByEvent As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEventTotals As TextBox
    Friend WithEvents txtSponsorTotalByEvent As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnTotalByEvent As Button
    Friend WithEvents btnEventTotals As Button
    Friend WithEvents btnSponsorTotal As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents lstSponsor As ListBox
    Friend WithEvents lstGolfer As ListBox
End Class
