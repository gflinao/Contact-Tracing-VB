Public Class Form1
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

        cform.Close()

    End Sub
End Class
