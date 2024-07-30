Imports System.Globalization
Imports System.IO.Ports
Imports System.Management
Public Class Form1
    Private acknowledgmentReceived As Boolean = False
    Private receiveString As String = ""
    Private watcher As ManagementEventWatcher
    Private portIsOpen As Boolean = False
    Private noPortsMessageShown As Boolean = False
    Private Sub ValidateLimits()

        If numUpper.Value < numLower.Value Then
            ' Display an error message or take appropriate action
            ShowToolTip(UpTip, numUpper, "Upper Limit cannot be lower than Lower Limit.")
            ' You can also disable the send button
            btnSend.Enabled = False
        Else
            ' Clear any error message or perform desired action
            ' For example, enable the send button

            UpTip.Hide(numUpper)
            btnSend.Enabled = True
        End If

    End Sub
    Public Function getChecksumAsciiBytes(ByVal value As Integer) As Integer
        Dim ascii() As Byte
        Dim retval As Integer = 0
        ascii = System.Text.ASCIIEncoding.ASCII.GetBytes(value)
        For i As Integer = 0 To ascii.Length - 1
            retval = retval + ascii(i)
        Next
        Return retval
    End Function

    Public Function getChecksumAsciiBytesDouble(ByVal value As Double) As Integer
        Dim ascii() As Byte
        Dim retval As Integer = 0
        ascii = System.Text.ASCIIEncoding.ASCII.GetBytes(value)
        For i As Integer = 0 To ascii.Length - 1
            retval = retval + ascii(i)
        Next
        Return retval
    End Function

    Public Function getChecksumAsciiBytesString(ByVal value As String) As Integer
        Dim ascii() As Byte
        Dim retval As Integer = 0
        ascii = System.Text.ASCIIEncoding.ASCII.GetBytes(value)
        For i As Integer = 0 To ascii.Length - 1
            retval = retval + ascii(i)
        Next
        Return retval
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the COM ports when the form loads
        InitializeCOMPorts()

        cbPort.DropDownStyle = ComboBoxStyle.DropDownList
        cbRotation.DropDownStyle = ComboBoxStyle.DropDownList


        SetEnableInputs(True)
        numHeight.Value = 888.88
        numUpper.Value = 888
        numLower.Value = 888
        numRevolution.Value = 10
        numDistance.Value = 1
        'Initialize the cbRotation
        cbRotation.Items.Add("Left")
        cbRotation.Items.Add("Right")
        cbRotation.SelectedIndex = 1

        ' Set up the USB device arrival and removal event watcher
        Dim query As New WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3")
        watcher = New ManagementEventWatcher(query)
        AddHandler watcher.EventArrived, AddressOf USBDeviceChangeEvent
        watcher.Start()


    End Sub
    Private Sub USBDeviceChangeEvent(sender As Object, e As EventArrivedEventArgs)
        ' Handle USB device arrival or removal event
        Dim eventType As Integer = CInt(e.NewEvent.Properties("EventType").Value)

        If eventType = 2 Then
            ' Device plugged in
            Me.Invoke(Sub()
                          lblStatus.Text = "USB Device Plugged In"
                          Timer1.Interval = 2000
                          Timer1.Start()
                          noPortsMessageShown = False ' Reset the flag
                          InitializeCOMPorts()
                      End Sub)
        ElseIf eventType = 3 Then
            ' Device unplugged
            Me.Invoke(Sub()
                          lblStatus.Text = "USB Device Unplugged"
                          Timer1.Interval = 2000
                          Timer1.Start()
                          InitializeCOMPorts()
                      End Sub)
        End If
    End Sub




    Private Sub InitializeCOMPorts()
        ' Clear the existing items in the ComboBox
        cbPort.Items.Clear()

        ' Get the list of available COM ports
        Dim availablePorts As String() = SerialPort.GetPortNames()

        ' Sort the ports in descending order
        Array.Sort(availablePorts)
        Array.Reverse(availablePorts)

        ' Add each port to the ComboBox
        For Each port As String In availablePorts
            If Not cbPort.Items.Contains(port) Then
                cbPort.Items.Add(port)
            End If
        Next


        ' Preselect the first port if available
        If cbPort.Items.Count > 0 Then
            cbPort.SelectedIndex = 0
            noPortsMessageShown = False
        Else
            If Not noPortsMessageShown Then
                MessageBox.Show("No ports are available. Please connect a device", "Error")
                noPortsMessageShown = True
            End If
            cbPort.Text = ""
        End If
    End Sub



    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Stop the USB device event watcher when the form is closing
        RemoveHandler SerialPort1.DataReceived, AddressOf SerialPortDataReceivedHandler
        watcher.Stop()
        watcher.Dispose()
    End Sub

    Private Sub SerialPortDataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        Dim serialPort As SerialPort = DirectCast(sender, SerialPort)

        ' Read the received data and process it as needed
        Dim receivedData As String = serialPort.ReadLine() ' Read a line of data
        ' Process the receivedData, update UI, etc.
    End Sub
    Private Function CheckInputValidity() As Boolean
        ' Check the validity of all input fields
        Dim validInput As Boolean = True

        ' Check if numHeight is valid
        If numHeight.Value < 0.01 Or numHeight.Value > 999.99 Then
            validInput = False
        End If

        ' Check if numUpper is valid
        If numUpper.Value < 1 Or numUpper.Value > 999 Then
            validInput = False
        End If

        ' Check if numUpper is not less than numLower
        If numUpper.Value < numLower.Value Then
            ShowToolTip(UpTip, numUpper, "Upper Limit cannot be lower than Lower Limit")
            validInput = False
        Else
            UpTip.Hide(numUpper)
        End If

        ' Check if numLower is valid
        If numLower.Value < 1 Or numLower.Value > 999 Then
            validInput = False
        End If

        ' Check if numRevolution is valid
        If numRevolution.Value < 1 Or numRevolution.Value > 99999 Then
            validInput = False
        End If

        ' Check if numDistance is valid
        If numDistance.Value < 1 Or numDistance.Value > 999 Then
            validInput = False
        End If

        ' Check if any input field is empty or null
        If String.IsNullOrWhiteSpace(numHeight.Text) OrElse
       String.IsNullOrWhiteSpace(numUpper.Text) OrElse
       String.IsNullOrWhiteSpace(numLower.Text) OrElse
       String.IsNullOrWhiteSpace(numRevolution.Text) OrElse
       String.IsNullOrWhiteSpace(numDistance.Text) Then
            validInput = False
        End If

        ' Enable or disable the Send button based on input validity
        btnSend.Enabled = validInput

        ' Return the validity status
        Return validInput
    End Function


    Private Sub ShowToolTip(toolTip As ToolTip, control As Control, message As String)
        ' Calculate the new X-coordinate by adding an offset (e.g., 10 pixels)
        Dim newX As Integer = control.Location.X + control.Width + 15

        ' Calculate the new Y-coordinate by adding an offset (e.g., 20 pixels)
        Dim newY As Integer = control.Location.Y + control.Height + 20

        ' Show the ToolTip at the new position
        toolTip.Show(message, control.FindForm(), newX, newY)
    End Sub

    Private Sub SetEnableInputs(enabled As Boolean)
        numHeight.Enabled = enabled
        numUpper.Enabled = enabled
        numLower.Enabled = enabled
        numRevolution.Enabled = enabled
        numDistance.Enabled = enabled
        cbPort.Enabled = enabled
        cbRotation.Enabled = enabled
        btnSend.Enabled = enabled

    End Sub
    Private Sub WaitForAcknowledgment(timeoutMilliseconds As Integer)
        Dim acknowledgmentReceived As Boolean = False
        Dim startTime As DateTime = DateTime.Now

        While Not acknowledgmentReceived
            Application.DoEvents() ' Allow the UI to remain responsive

            ' Check if acknowledgment is received
            If SerialPort1.BytesToRead > 0 Then

                Dim receivedData As String = SerialPort1.ReadExisting()

                If receivedData = "<ACK>" Then
                    acknowledgmentReceived = True

                    Exit While
                End If
            End If

            ' Check if the timeout has been reached
            If (DateTime.Now - startTime).TotalMilliseconds > timeoutMilliseconds Then
                Exit While
            End If
        End While
    End Sub
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        ' Dandan 07/30/2024 - Add validation in Send Button
        If CheckInputValidity() Then
            Try
                If cbPort.SelectedItem IsNot Nothing Then
                    SerialPort1.PortName = cbPort.SelectedItem.ToString()
                    SerialPort1.Open() ' Open the serial port
                    SerialPort1.DiscardInBuffer()
                    SerialPort1.DiscardOutBuffer()
                    portIsOpen = True
                Else

                    portIsOpen = False
                End If
            Catch ex As Exception
                portIsOpen = False
            End Try

            Dim transmitString As String
            Dim numCurrentHeightForSending As Integer = numHeight.Value * 100
            Dim cbRotationForSending As String
            Dim checksumForSending As Integer

            If cbRotation.SelectedItem = "Right" Then
                cbRotationForSending = "R"
            Else
                cbRotationForSending = "L"
            End If
            checksumForSending = getChecksumAsciiBytes(numCurrentHeightForSending) +
                getChecksumAsciiBytes(numUpper.Value) +
                getChecksumAsciiBytes(numLower.Value) +
                getChecksumAsciiBytes(numRevolution.Value) +
                getChecksumAsciiBytes(numDistance.Value) +
                getChecksumAsciiBytesString(cbRotationForSending)

            transmitString =
                "<" &
                numCurrentHeightForSending & "," &
                numUpper.Value & "," &
                numLower.Value & "," &
                numRevolution.Value & "," &
                numDistance.Value & "," &
                cbRotationForSending & "," &
                "0x" & Convert.ToString(checksumForSending, 16) &
                ">"

            Try
                ' Replace with actual data
                SerialPort1.Write(transmitString)
                lblStatus.Text = "Sending.."
                SetEnableInputs(False)
                ' Wait for acknowledgment with a timeout of 5000 milliseconds (5 seconds)
                WaitForAcknowledgment(1000)
                ' Handle acknowledgment (e.g., update status label)
                If acknowledgmentReceived Then
                    lblStatus.Text = "Send successful."

                Else
                    lblStatus.Text = "Device Error. Timeout."

                End If
            Catch ex As Exception
                ' Handle write error
                MessageBox.Show("Error while sending data: " & "Device is not available. Please connect-disconnect your device", "Send Error")

            End Try
            Timer1.Interval = 3000
            Timer1.Start()


            If SerialPort1.IsOpen Then
                SerialPort1.DiscardInBuffer()
                SerialPort1.DiscardOutBuffer()
                SerialPort1.Close()
            End If
        Else
            MessageBox.Show("One or more inputs are invalid. Please review the fields and correct any errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        ' ... (existing code)
        Dim serialPort As SerialPort = DirectCast(sender, SerialPort)
        receiveString &= serialPort.ReadExisting()
        If Not String.IsNullOrEmpty(receiveString) Then
            ' Handle the received data, e.g., check for acknowledgment
            If receiveString.IndexOf("<ACK>", StringComparison.OrdinalIgnoreCase) >= 0 Then
                acknowledgmentReceived = True
            End If

        Else
            acknowledgmentReceived = False

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        acknowledgmentReceived = False
        SetEnableInputs(True)
        lblStatus.Text = ""
        Timer1.Stop()


    End Sub

    'Validtions


    Private Sub numHeight_TextChanged(sender As Object, e As EventArgs) Handles numHeight.TextChanged
        Dim numControl As NumericUpDown = CType(sender, NumericUpDown)
        ' Check if the input is empty or null
        If String.IsNullOrWhiteSpace(numControl.Text) Then
            ShowToolTip(HeightTip, numHeight, "Please enter a value.")
            btnSend.Enabled = False
        Else
            HeightTip.Hide(numControl)
            btnSend.Enabled = True
        End If

    End Sub


    Private Sub numCurrentHeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles numHeight.KeyPress
        Dim numControl As NumericUpDown = CType(sender, NumericUpDown)
        Dim decimalSeparator As Char = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.Chars(0)

        If e.KeyChar = "-" Then
            e.Handled = True ' Suppress the '-' key
        ElseIf e.KeyChar = decimalSeparator AndAlso Not numControl.Text.Contains(decimalSeparator) Then
            ' Allow the decimal separator only if it's not already present
            e.Handled = False
        ElseIf e.KeyChar = "." AndAlso Not numControl.Text.Contains(".") Then
            ' Allow the period as the decimal separator only if it's not already present
            e.Handled = False
        ElseIf Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True ' Suppress non-digit characters (except Backspace)
        End If
    End Sub

    Private Sub numCurrentHeight_KeyDown(sender As Object, e As KeyEventArgs) Handles numHeight.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.A Then
            ' Ctrl+A was pressed, select all text in the NumericUpDown control
            numHeight.Select(0, numHeight.Text.Length)

        End If
    End Sub

    Private Sub numInput_KeyUp(sender As Object, e As KeyEventArgs) Handles numHeight.KeyUp, numUpper.KeyUp, numLower.KeyUp, numRevolution.KeyUp, numDistance.KeyUp
        If e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down Then
            ' Arrow up or arrow down keys were released, update the Send button accordingly
            ValidateLimits()
        End If

    End Sub

    Private Sub numUpperLimit_TextChanged(sender As Object, e As EventArgs) Handles numUpper.TextChanged
        Dim numControl As NumericUpDown = CType(sender, NumericUpDown)

        ' Check if the input is empty or null
        If String.IsNullOrWhiteSpace(numControl.Text) Then
            ShowToolTip(UpTip, numUpper, "Please enter a value.")
            btnSend.Enabled = False
        Else
            UpTip.Hide(numControl)
            btnSend.Enabled = True
            ValidateLimits()
        End If

    End Sub

    Private Sub numLowerLimit_TextChanged(sender As Object, e As EventArgs) Handles numLower.TextChanged
        Dim numControl As NumericUpDown = CType(sender, NumericUpDown)
        ' Check if the input is empty or null
        If String.IsNullOrWhiteSpace(numControl.Text) Then
            ShowToolTip(LowerTip, numControl, "Please enter a value.")
            btnSend.Enabled = False
        Else
            LowerTip.Hide(numControl)
            btnSend.Enabled = True
            ValidateLimits()
        End If

    End Sub

    Private Sub numRevolution_TextChanged(sender As Object, e As EventArgs) Handles numRevolution.TextChanged
        Dim numControl As NumericUpDown = CType(sender, NumericUpDown)
        ' Check if the input is empty or null
        If String.IsNullOrWhiteSpace(numControl.Text) Then
            ShowToolTip(RevolutionTip, numRevolution, "Please enter a value.")
            btnSend.Enabled = False
        Else
            RevolutionTip.Hide(numControl)
            btnSend.Enabled = True
        End If

    End Sub
    Private Sub numDistance_TextChanged(sender As Object, e As EventArgs) Handles numDistance.TextChanged
        Dim numControl As NumericUpDown = CType(sender, NumericUpDown)
        ' Check if the input is empty or null
        If String.IsNullOrWhiteSpace(numControl.Text) Then
            ShowToolTip(DistanceTip, numDistance, "Please enter a value.")
            btnSend.Enabled = False
        Else
            DistanceTip.Hide(numControl)
            btnSend.Enabled = True
        End If

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class
