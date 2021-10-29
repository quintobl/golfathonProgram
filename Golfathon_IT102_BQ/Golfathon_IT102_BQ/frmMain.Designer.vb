<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnManageGolfers = New System.Windows.Forms.Button()
        Me.btnManageEvents = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnManageGolfersAndEvents = New System.Windows.Forms.Button()
        Me.btnManageSponsors = New System.Windows.Forms.Button()
        Me.btnManageGolfersAndSponsors = New System.Windows.Forms.Button()
        Me.btnAggregates = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnManageGolfers
        '
        Me.btnManageGolfers.Location = New System.Drawing.Point(41, 53)
        Me.btnManageGolfers.Name = "btnManageGolfers"
        Me.btnManageGolfers.Size = New System.Drawing.Size(130, 78)
        Me.btnManageGolfers.TabIndex = 0
        Me.btnManageGolfers.Text = "Manage Golfers"
        Me.btnManageGolfers.UseVisualStyleBackColor = True
        '
        'btnManageEvents
        '
        Me.btnManageEvents.Location = New System.Drawing.Point(218, 53)
        Me.btnManageEvents.Name = "btnManageEvents"
        Me.btnManageEvents.Size = New System.Drawing.Size(130, 78)
        Me.btnManageEvents.TabIndex = 1
        Me.btnManageEvents.Text = "Manage Events"
        Me.btnManageEvents.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(218, 283)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(130, 78)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnManageGolfersAndEvents
        '
        Me.btnManageGolfersAndEvents.Location = New System.Drawing.Point(41, 165)
        Me.btnManageGolfersAndEvents.Name = "btnManageGolfersAndEvents"
        Me.btnManageGolfersAndEvents.Size = New System.Drawing.Size(130, 78)
        Me.btnManageGolfersAndEvents.TabIndex = 3
        Me.btnManageGolfersAndEvents.Text = "Manage Golfers/Events"
        Me.btnManageGolfersAndEvents.UseVisualStyleBackColor = True
        '
        'btnManageSponsors
        '
        Me.btnManageSponsors.Location = New System.Drawing.Point(396, 53)
        Me.btnManageSponsors.Name = "btnManageSponsors"
        Me.btnManageSponsors.Size = New System.Drawing.Size(130, 78)
        Me.btnManageSponsors.TabIndex = 4
        Me.btnManageSponsors.Text = "Manage Sponsors"
        Me.btnManageSponsors.UseVisualStyleBackColor = True
        '
        'btnManageGolfersAndSponsors
        '
        Me.btnManageGolfersAndSponsors.Location = New System.Drawing.Point(218, 165)
        Me.btnManageGolfersAndSponsors.Name = "btnManageGolfersAndSponsors"
        Me.btnManageGolfersAndSponsors.Size = New System.Drawing.Size(130, 78)
        Me.btnManageGolfersAndSponsors.TabIndex = 5
        Me.btnManageGolfersAndSponsors.Text = "Manage Golfers/Sponsors"
        Me.btnManageGolfersAndSponsors.UseVisualStyleBackColor = True
        '
        'btnAggregates
        '
        Me.btnAggregates.Location = New System.Drawing.Point(396, 165)
        Me.btnAggregates.Name = "btnAggregates"
        Me.btnAggregates.Size = New System.Drawing.Size(130, 78)
        Me.btnAggregates.TabIndex = 6
        Me.btnAggregates.Text = "Aggregate Amounts"
        Me.btnAggregates.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 416)
        Me.Controls.Add(Me.btnAggregates)
        Me.Controls.Add(Me.btnManageGolfersAndSponsors)
        Me.Controls.Add(Me.btnManageSponsors)
        Me.Controls.Add(Me.btnManageGolfersAndEvents)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnManageEvents)
        Me.Controls.Add(Me.btnManageGolfers)
        Me.Name = "frmMain"
        Me.Text = "Golf-A-Thon"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnManageGolfers As Button
    Friend WithEvents btnManageEvents As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnManageGolfersAndEvents As Button
    Friend WithEvents btnManageSponsors As Button
    Friend WithEvents btnManageGolfersAndSponsors As Button
    Friend WithEvents btnAggregates As Button
End Class
