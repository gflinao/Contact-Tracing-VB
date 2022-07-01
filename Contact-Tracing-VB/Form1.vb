Imports WebCam_Capture
Imports MessagingToolkit.QRCode.Codec

Public Class TRACE
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtbxFN.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TxtbxAdd.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TxtbxAge.TextChanged

    End Sub

    Private Sub LblAdd_Click(sender As Object, e As EventArgs) Handles LblAdd.Click

    End Sub

    Private Sub LblMN_Click(sender As Object, e As EventArgs) Handles LblMN.Click

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CbN1.CheckedChanged

    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnSub_Click(sender As Object, e As EventArgs) Handles BtnSub.Click
        Dim cform As System.IO.StreamWriter
        cform = My.Computer.FileSystem.OpenTextFileWriter("C:\Users\admin\source\repos\Contact-Tracing-VB\TracingForm.txt", True)
        cform.WriteLine("Full Name: " + TxtbxFN.Text)
        cform.WriteLine("Age: " + TxtbxAge.Text)
        cform.WriteLine("Mobile Number: " + TxtbxMN.Text)
        cform.WriteLine("Email Address: " + TxtbxEAdd.Text)
        cform.WriteLine("Address: " + TxtbxAdd.Text)
        cform.WriteLine("")

        If CbY1.CheckState = CheckState.Checked Then
            cform.WriteLine("1.Have you traveled outside the country anytime?: Yes")
        Else
            cform.WriteLine("1.Have you traveled outside the country anytime?: No")
        End If

        If CbY2.CheckState = CheckState.Checked Then
            cform.WriteLine("2.Are you fully vaccinated?: Yes")
        Else
            cform.WriteLine("2.Are you fully vaccinated?: No")
        End If

        If CbCough.CheckState = CheckState.Checked Then
            cform.WriteLine("3.Do you currently have any of the following conditions during this time: Cough")
        Else
            'Do Nothing
        End If

        If CbFever.CheckState = CheckState.Checked Then
            cform.WriteLine("3.Do you currently have any of the following conditions during this time: Fever")
        Else
            'Do Nothing
        End If

        If CbLoss.CheckState = CheckState.Checked Then
            cform.WriteLine("3.Do you currently have any of the following conditions during this time: Loss of Smell or Taste")
        Else
            'Do Nothing
        End If

        If CbNone.CheckState = CheckState.Checked Then
            cform.WriteLine("3.Do you currently have any of the following conditions during this time: None")
        Else
            'Do Nothing
        End If
        cform.WriteLine("")

        TxtbxFN.Clear()
        TxtbxAge.Clear()
        TxtbxMN.Clear()
        TxtbxEAdd.Clear()
        TxtbxAdd.Clear()

        CbY1.Checked = False
        CbY2.Checked = False
        CbN1.Checked = False
        CbN2.Checked = False

        CbFever.Checked = False
        CbCough.Checked = False
        CbLoss.Checked = False
        CbNone.Checked = False

        MessageBox.Show("Trace2.0 Form Submitted!")

        cform.Close()

    End Sub

    WithEvents QRCam As WebCamCapture
    Dim QRreader As QRCodeDecoder

    Private Sub StartQRCam()
        Try
            StopQRCam()
            QRCam = New WebCamCapture
            QRCam.Start(0)
            QRCam.Start(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StopQRCam()
        Try
            QRCam.Stop()
            QRCam.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        StartQRCam()
        TextBoxData.Clear()
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        StopQRCam()
    End Sub

    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles BtnScan.Click
        Try
            StopQRCam()
            QRreader = New QRCodeDecoder
            TextBoxData.Text = QRreader.Decode(New Data.QRCodeBitmapImage(PictureBoxCam.Image))
            MsgBox("Scanned Successfully!")
        Catch ex As Exception
            StartQRCam()
        End Try
    End Sub

    Private Sub PictureBoxCam_Click(sender As Object, e As EventArgs) Handles PictureBoxCam.Click

    End Sub

    Private Sub QRCam_ImageCaptured(source As Object, e As WebcamEventArgs) Handles QRCam.ImageCaptured
        PictureBoxCam.Image = e.WebCamImage
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim SaveDt As New SaveFileDialog
        SaveDt.Filter = "PNG|*.png"
        If SaveDt.ShowDialog() = DialogResult.OK Then
            PictureBoxCam.Image.Save(SaveDt.FileName, Imaging.ImageFormat.Png)
        End If
    End Sub
End Class
