<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddSalesperson
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtASPfName = New System.Windows.Forms.TextBox()
        Me.txtASPlName = New System.Windows.Forms.TextBox()
        Me.mtbASPHPhone = New System.Windows.Forms.MaskedTextBox()
        Me.mtbASPCPhone = New System.Windows.Forms.MaskedTextBox()
        Me.cbManager = New System.Windows.Forms.CheckBox()
        Me.mtbASPZipCode = New System.Windows.Forms.MaskedTextBox()
        Me.cbASPState = New System.Windows.Forms.ComboBox()
        Me.txtASPStreet = New System.Windows.Forms.TextBox()
        Me.txtASPCity = New System.Windows.Forms.TextBox()
        Me.txtASPNumSold = New System.Windows.Forms.TextBox()
        Me.btnAddSalesperson = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(226, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vehicles Sold:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Last Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Home Phone:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cell Phone:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(226, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "City:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(445, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "State:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(226, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Address:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(226, 102)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "ZipCode:"
        '
        'txtASPfName
        '
        Me.txtASPfName.Location = New System.Drawing.Point(90, 8)
        Me.txtASPfName.Name = "txtASPfName"
        Me.txtASPfName.Size = New System.Drawing.Size(100, 20)
        Me.txtASPfName.TabIndex = 10
        '
        'txtASPlName
        '
        Me.txtASPlName.Location = New System.Drawing.Point(90, 53)
        Me.txtASPlName.Name = "txtASPlName"
        Me.txtASPlName.Size = New System.Drawing.Size(100, 20)
        Me.txtASPlName.TabIndex = 11
        '
        'mtbASPHPhone
        '
        Me.mtbASPHPhone.Location = New System.Drawing.Point(90, 99)
        Me.mtbASPHPhone.Mask = "(999) 000-0000"
        Me.mtbASPHPhone.Name = "mtbASPHPhone"
        Me.mtbASPHPhone.Size = New System.Drawing.Size(100, 20)
        Me.mtbASPHPhone.TabIndex = 12
        '
        'mtbASPCPhone
        '
        Me.mtbASPCPhone.Location = New System.Drawing.Point(90, 144)
        Me.mtbASPCPhone.Mask = "(999) 000-0000"
        Me.mtbASPCPhone.Name = "mtbASPCPhone"
        Me.mtbASPCPhone.Size = New System.Drawing.Size(100, 20)
        Me.mtbASPCPhone.TabIndex = 13
        '
        'cbManager
        '
        Me.cbManager.AutoSize = True
        Me.cbManager.Location = New System.Drawing.Point(448, 101)
        Me.cbManager.Name = "cbManager"
        Me.cbManager.Size = New System.Drawing.Size(74, 17)
        Me.cbManager.TabIndex = 14
        Me.cbManager.Text = "Manager?"
        Me.cbManager.UseVisualStyleBackColor = True
        '
        'mtbASPZipCode
        '
        Me.mtbASPZipCode.Location = New System.Drawing.Point(280, 99)
        Me.mtbASPZipCode.Mask = "00000-9999"
        Me.mtbASPZipCode.Name = "mtbASPZipCode"
        Me.mtbASPZipCode.Size = New System.Drawing.Size(95, 20)
        Me.mtbASPZipCode.TabIndex = 18
        '
        'cbASPState
        '
        Me.cbASPState.FormattingEnabled = True
        Me.cbASPState.Items.AddRange(New Object() {"Alabama", "Alaska", "Arizona", "Arkansas", "California" & Global.Microsoft.VisualBasic.ChrW(9), "Colorado" & Global.Microsoft.VisualBasic.ChrW(9), "Connecticut" & Global.Microsoft.VisualBasic.ChrW(9), "Delaware", "Florida" & Global.Microsoft.VisualBasic.ChrW(9), "Georgia" & Global.Microsoft.VisualBasic.ChrW(9), "Hawaii" & Global.Microsoft.VisualBasic.ChrW(9), "Idaho", "Illinois" & Global.Microsoft.VisualBasic.ChrW(9), "Indiana" & Global.Microsoft.VisualBasic.ChrW(9), "Iowa" & Global.Microsoft.VisualBasic.ChrW(9), "Kansas", "Kentucky" & Global.Microsoft.VisualBasic.ChrW(9), "Louisiana" & Global.Microsoft.VisualBasic.ChrW(9), "Maine" & Global.Microsoft.VisualBasic.ChrW(9), "Maryland", "Massachusetts" & Global.Microsoft.VisualBasic.ChrW(9), "Michigan" & Global.Microsoft.VisualBasic.ChrW(9), "Minnesota" & Global.Microsoft.VisualBasic.ChrW(9), "Mississippi", "Missouri" & Global.Microsoft.VisualBasic.ChrW(9), "Montana" & Global.Microsoft.VisualBasic.ChrW(9), "Nebraska" & Global.Microsoft.VisualBasic.ChrW(9), "Nevada", "New Hampshire" & Global.Microsoft.VisualBasic.ChrW(9), "New Jersey" & Global.Microsoft.VisualBasic.ChrW(9), "New Mexico" & Global.Microsoft.VisualBasic.ChrW(9), "New York", "North Carolina" & Global.Microsoft.VisualBasic.ChrW(9), "North Dakota" & Global.Microsoft.VisualBasic.ChrW(9), "Ohio" & Global.Microsoft.VisualBasic.ChrW(9), "Oklahoma", "Oregon" & Global.Microsoft.VisualBasic.ChrW(9), "Pennsylvania" & Global.Microsoft.VisualBasic.ChrW(9), "Rhode Island" & Global.Microsoft.VisualBasic.ChrW(9), "South Carolina", "South Dakota" & Global.Microsoft.VisualBasic.ChrW(9), "Tennessee" & Global.Microsoft.VisualBasic.ChrW(9), "Texas" & Global.Microsoft.VisualBasic.ChrW(9), "Utah", "Vermont" & Global.Microsoft.VisualBasic.ChrW(9), "Virginia" & Global.Microsoft.VisualBasic.ChrW(9), "Washington" & Global.Microsoft.VisualBasic.ChrW(9), "West Virginia", "Wisconsin" & Global.Microsoft.VisualBasic.ChrW(9), "Wyoming"})
        Me.cbASPState.Location = New System.Drawing.Point(486, 53)
        Me.cbASPState.Name = "cbASPState"
        Me.cbASPState.Size = New System.Drawing.Size(116, 21)
        Me.cbASPState.TabIndex = 17
        '
        'txtASPStreet
        '
        Me.txtASPStreet.Location = New System.Drawing.Point(280, 8)
        Me.txtASPStreet.Name = "txtASPStreet"
        Me.txtASPStreet.Size = New System.Drawing.Size(323, 20)
        Me.txtASPStreet.TabIndex = 15
        '
        'txtASPCity
        '
        Me.txtASPCity.Location = New System.Drawing.Point(259, 53)
        Me.txtASPCity.Name = "txtASPCity"
        Me.txtASPCity.Size = New System.Drawing.Size(116, 20)
        Me.txtASPCity.TabIndex = 16
        '
        'txtASPNumSold
        '
        Me.txtASPNumSold.Location = New System.Drawing.Point(306, 144)
        Me.txtASPNumSold.Name = "txtASPNumSold"
        Me.txtASPNumSold.Size = New System.Drawing.Size(69, 20)
        Me.txtASPNumSold.TabIndex = 19
        '
        'btnAddSalesperson
        '
        Me.btnAddSalesperson.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSalesperson.Location = New System.Drawing.Point(446, 138)
        Me.btnAddSalesperson.Name = "btnAddSalesperson"
        Me.btnAddSalesperson.Size = New System.Drawing.Size(157, 30)
        Me.btnAddSalesperson.TabIndex = 20
        Me.btnAddSalesperson.Text = "Add Salesperson"
        Me.btnAddSalesperson.UseVisualStyleBackColor = True
        '
        'frmAddSalesperson
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 174)
        Me.Controls.Add(Me.btnAddSalesperson)
        Me.Controls.Add(Me.txtASPNumSold)
        Me.Controls.Add(Me.mtbASPZipCode)
        Me.Controls.Add(Me.cbASPState)
        Me.Controls.Add(Me.txtASPStreet)
        Me.Controls.Add(Me.txtASPCity)
        Me.Controls.Add(Me.cbManager)
        Me.Controls.Add(Me.mtbASPCPhone)
        Me.Controls.Add(Me.mtbASPHPhone)
        Me.Controls.Add(Me.txtASPlName)
        Me.Controls.Add(Me.txtASPfName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAddSalesperson"
        Me.Text = "Add Salesperson"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtASPfName As System.Windows.Forms.TextBox
    Friend WithEvents txtASPlName As System.Windows.Forms.TextBox
    Friend WithEvents mtbASPHPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtbASPCPhone As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbManager As System.Windows.Forms.CheckBox
    Friend WithEvents mtbASPZipCode As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbASPState As System.Windows.Forms.ComboBox
    Friend WithEvents txtASPStreet As System.Windows.Forms.TextBox
    Friend WithEvents txtASPCity As System.Windows.Forms.TextBox
    Friend WithEvents txtASPNumSold As System.Windows.Forms.TextBox
    Friend WithEvents btnAddSalesperson As System.Windows.Forms.Button
End Class
