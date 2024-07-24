<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbRotation = New System.Windows.Forms.ComboBox()
        Me.numRevolution = New System.Windows.Forms.NumericUpDown()
        Me.numDistance = New System.Windows.Forms.NumericUpDown()
        Me.numLower = New System.Windows.Forms.NumericUpDown()
        Me.numUpper = New System.Windows.Forms.NumericUpDown()
        Me.numHeight = New System.Windows.Forms.NumericUpDown()
        Me.Height = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbPort = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.UpperTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.HeightTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.UpTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.LowerTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.RevolutionTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.DistanceTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.numRevolution, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLower, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUpper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbRotation)
        Me.GroupBox1.Controls.Add(Me.numRevolution)
        Me.GroupBox1.Controls.Add(Me.numDistance)
        Me.GroupBox1.Controls.Add(Me.numLower)
        Me.GroupBox1.Controls.Add(Me.numUpper)
        Me.GroupBox1.Controls.Add(Me.numHeight)
        Me.GroupBox1.Controls.Add(Me.Height)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 209)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameters"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.Label5.Location = New System.Drawing.Point(17, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 23)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Rotation"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.Label4.Location = New System.Drawing.Point(17, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 23)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Distance"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.Label3.Location = New System.Drawing.Point(17, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 23)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Revolution"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.Label2.Location = New System.Drawing.Point(17, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 23)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Lower Limit"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.Label1.Location = New System.Drawing.Point(17, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 23)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Upper Limit"
        '
        'cbRotation
        '
        Me.cbRotation.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbRotation.FormattingEnabled = True
        Me.cbRotation.Location = New System.Drawing.Point(124, 165)
        Me.cbRotation.Name = "cbRotation"
        Me.cbRotation.Size = New System.Drawing.Size(82, 27)
        Me.cbRotation.TabIndex = 11
        '
        'numRevolution
        '
        Me.numRevolution.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numRevolution.Location = New System.Drawing.Point(124, 108)
        Me.numRevolution.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numRevolution.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numRevolution.Name = "numRevolution"
        Me.numRevolution.Size = New System.Drawing.Size(82, 26)
        Me.numRevolution.TabIndex = 10
        Me.numRevolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numRevolution.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numDistance
        '
        Me.numDistance.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDistance.Location = New System.Drawing.Point(124, 136)
        Me.numDistance.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numDistance.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numDistance.Name = "numDistance"
        Me.numDistance.Size = New System.Drawing.Size(82, 26)
        Me.numDistance.TabIndex = 9
        Me.numDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numDistance.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numLower
        '
        Me.numLower.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numLower.Location = New System.Drawing.Point(124, 79)
        Me.numLower.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numLower.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLower.Name = "numLower"
        Me.numLower.Size = New System.Drawing.Size(82, 26)
        Me.numLower.TabIndex = 8
        Me.numLower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numLower.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numUpper
        '
        Me.numUpper.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.numUpper.Location = New System.Drawing.Point(124, 50)
        Me.numUpper.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numUpper.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numUpper.Name = "numUpper"
        Me.numUpper.Size = New System.Drawing.Size(82, 26)
        Me.numUpper.TabIndex = 7
        Me.numUpper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numUpper.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numHeight
        '
        Me.numHeight.DecimalPlaces = 2
        Me.numHeight.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numHeight.Location = New System.Drawing.Point(124, 22)
        Me.numHeight.Maximum = New Decimal(New Integer() {99999, 0, 0, 131072})
        Me.numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numHeight.Name = "numHeight"
        Me.numHeight.Size = New System.Drawing.Size(82, 26)
        Me.numHeight.TabIndex = 6
        Me.numHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numHeight.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'Height
        '
        Me.Height.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.Height.Location = New System.Drawing.Point(17, 25)
        Me.Height.Name = "Height"
        Me.Height.Size = New System.Drawing.Size(101, 23)
        Me.Height.TabIndex = 0
        Me.Height.Text = "Current Height"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cbPort)
        Me.GroupBox2.Location = New System.Drawing.Point(252, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 66)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Connection"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.2!)
        Me.Label6.Location = New System.Drawing.Point(17, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 23)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Port"
        '
        'cbPort
        '
        Me.cbPort.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPort.FormattingEnabled = True
        Me.cbPort.Location = New System.Drawing.Point(91, 19)
        Me.cbPort.Name = "cbPort"
        Me.cbPort.Size = New System.Drawing.Size(87, 27)
        Me.cbPort.TabIndex = 12
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblStatus)
        Me.GroupBox3.Controls.Add(Me.btnSend)
        Me.GroupBox3.Location = New System.Drawing.Point(252, 84)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 137)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Send"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(18, 87)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(160, 26)
        Me.lblStatus.TabIndex = 1
        '
        'btnSend
        '
        Me.btnSend.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.Location = New System.Drawing.Point(18, 17)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(160, 67)
        Me.btnSend.TabIndex = 0
        Me.btnSend.Text = "SEND"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 247)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "DHC Setter Companion Software"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.numRevolution, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLower, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUpper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents numRevolution As NumericUpDown
    Friend WithEvents numDistance As NumericUpDown
    Friend WithEvents numLower As NumericUpDown
    Friend WithEvents numUpper As NumericUpDown
    Friend WithEvents numHeight As NumericUpDown
    Friend WithEvents Height As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbRotation As ComboBox
    Friend WithEvents cbPort As ComboBox
    Friend WithEvents btnSend As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents UpperTip As ToolTip
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents HeightTip As ToolTip
    Friend WithEvents UpTip As ToolTip
    Friend WithEvents LowerTip As ToolTip
    Friend WithEvents RevolutionTip As ToolTip
    Friend WithEvents DistanceTip As ToolTip
End Class
