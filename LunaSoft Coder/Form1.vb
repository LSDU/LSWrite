Imports System
Imports System.IO
Imports System.Security.AccessControl
Public Class Form1
    Dim speed As Integer = 160
    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AnimationTimer.Interval = speed
        Panel1.Hide()
        Dim myTabPage As New TabPage()
        Dim rtb As New RichTextBox
        myTabPage.Text = "Untitled"
        TabControl1.TabPages.Add(myTabPage)
        TabControl1.SelectedTab = myTabPage
        rtb.Dock = DockStyle.Fill
        rtb.Font = New Font(My.Settings.DefaultFont, False)
        TabControl1.SelectedTab.Controls.Add(rtb)
        If My.Settings.Idfk = "Yes" Then
            WordToolStripMenuItem.Checked = True
            CType(TabControl1.SelectedTab.Controls.Item(0), RichTextBox).WordWrap = True
        ElseIf My.Settings.Idfk = "No" Then
            WordToolStripMenuItem.Checked = False
            CType(TabControl1.SelectedTab.Controls.Item(0), RichTextBox).WordWrap = False
        End If
        Me.Size = My.Settings.WindowSize
    End Sub

    Private Sub AddTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddTabToolStripMenuItem.Click
        Dim myTabPage As New TabPage()
        Dim rtb As New RichTextBox
        myTabPage.Text = "Untitled"
        TabControl1.TabPages.Add(myTabPage)
        TabControl1.SelectedTab = myTabPage
        rtb.Dock = DockStyle.Fill
        rtb.Font = New Font(My.Settings.DefaultFont, False)
        TabControl1.SelectedTab.Controls.Add(rtb)
    End Sub
    Private Sub RemoveTabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveTabToolStripMenuItem.Click
        If CType(TabControl1.SelectedTab.Controls.Item(0), RichTextBox).Modified() = True Then
            Dim Ask As MsgBoxResult
            Ask = MsgBox("This tab has been modified, do you want to save?", MsgBoxStyle.YesNo)
            If Ask = MsgBoxResult.Yes Then
                SaveFile()
            Else

            End If
        End If
        If TabControl1.TabCount = 1 Then
            MsgBox("This is the last tab, it cannot be removed.")
        Else
            TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFile()
    End Sub
    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SavAs()
    End Sub
    Private Sub ClearAllTabsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllTabsToolStripMenuItem.Click
        TabControl1.TabPages.Clear()
        Dim myTabPage As New TabPage()
        Dim rtb As New RichTextBox
        myTabPage.Text = "Untitled"
        TabControl1.TabPages.Add(myTabPage)
        TabControl1.SelectedTab = myTabPage
        rtb.Dock = DockStyle.Fill
        rtb.Font = New Font(My.Settings.DefaultFont, False)
        TabControl1.SelectedTab.Controls.Add(rtb)
    End Sub
    Sub SaveFile()
        SaveFileDialog1.ShowDialog()
        Text = CType(TabControl1.SelectedTab.Controls.Item(0), RichTextBox).Text
        TabControl1.SelectedTab.Text = SaveFileDialog1.FileName
        If My.Computer.FileSystem.FileExists(SaveFileDialog1.FileName) Then
            Dim ask As MsgBoxResult
            ask = MsgBox("File already exists, would you like to replace it?", MsgBoxStyle.YesNo, "File Exists")
            If ask = MsgBoxResult.No Then
                SaveFileDialog1.ShowDialog()
            ElseIf ask = MsgBoxResult.Yes Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, Text, False)
                Dim filename As String
                filename = SaveFileDialog1.FileName
                TabControl1.SelectedTab.Text = filename
                Text = filename + " - " + My.Settings.Titlebar
            End If
        Else
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, Text, False)
                Dim filename As String
                filename = SaveFileDialog1.FileName
                TabControl1.SelectedTab.Text = filename
                Text = filename + " - " + My.Settings.Titlebar
            Catch ex As Exception
            End Try
        End If
        If SaveFileDialog1.FileName = String.Empty Then
            TabControl1.SelectedTab.Text = "Untitled"
            Me.Text = "Untitled - LunaSoft Write 2017 Tech Preview 1"
        End If
    End Sub
    Sub SavAs()
        SaveFileDialog1.ShowDialog()
        Text = CType(TabControl1.SelectedTab.Controls.Item(0), RichTextBox).Text
        TabControl1.SelectedTab.Text = SaveFileDialog1.FileName
        If My.Computer.FileSystem.FileExists(SaveFileDialog1.FileName) Then
            Dim ask As MsgBoxResult
            ask = MsgBox("File already exists, would you like to replace it?", MsgBoxStyle.YesNo, "File Exists")
            If ask = MsgBoxResult.No Then
                SaveFileDialog1.ShowDialog()
            ElseIf ask = MsgBoxResult.Yes Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, Text, False)
                Dim filename As String
                filename = SaveFileDialog1.FileName
                TabControl1.SelectedTab.Text = filename
                Text = filename + " - " + My.Settings.Titlebar
            End If
        Else
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, Text, False)
                Dim filename As String
                filename = SaveFileDialog1.FileName
                TabControl1.SelectedTab.Text = filename
                Text = filename + " - " + My.Settings.Titlebar
            Catch ex As Exception
            End Try
        End If
        If SaveFileDialog1.FileName = String.Empty Then
            TabControl1.SelectedTab.Text = "Untitled"
            Me.Text = "Untitled - LunaSoft Write 2017 Tech Preview 2"
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.Feedbackonclose = "No" Then

        Else
            Me.Hide()
            Dim Ask As MsgBoxResult
            Ask = MsgBox("Would you like to send feedback to us?", MsgBoxStyle.YesNo, "Feedback")
        End If
        My.Settings.WindowSize = Me.Size
    End Sub

    Private Sub NEWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NEWToolStripMenuItem.Click
        Dim myTabPage As New TabPage()
        Dim rtb As New RichTextBox
        myTabPage.Text = "Untitled"
        TabControl1.TabPages.Add(myTabPage)
        TabControl1.SelectedTab = myTabPage
        rtb.Dock = DockStyle.Fill
        rtb.Font = New Font(My.Settings.DefaultFont, False)
        TabControl1.SelectedTab.Controls.Add(rtb)
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
        If My.Settings.OpenFileDialogOpensnewtab = "True" Then
            Try
                Dim myTabPage As New TabPage()
                Dim rtb As New RichTextBox
                myTabPage.Text = OpenFileDialog1.FileName
                TabControl1.TabPages.Add(myTabPage)
                TabControl1.SelectedTab = myTabPage
                rtb.Dock = DockStyle.Fill
                rtb.Font = New Font(My.Settings.DefaultFont, False)
                TabControl1.SelectedTab.Controls.Add(rtb)
                rtb.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            Catch ex As Exception
            End Try
        Else
            Try
                Dim myTabPage As New TabPage()
                Dim rtb As New RichTextBox
                TabControl1.SelectedTab.Text = OpenFileDialog1.FileName
                CType(TabControl1.SelectedTab.Controls.Item(0), RichTextBox).Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
                Text = OpenFileDialog1.FileName + " - " + My.Settings.Titlebar
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        CType(TabControl1.SelectedTab.Controls.Item(0), RichTextBox).Font = FontDialog1.Font
        My.Settings.DefaultFont = FontDialog1.Font
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If ClearAllTabsToolStripMenuItem.Pressed = True Then
            Text = "Untitled - " & My.Settings.Titlebar
        ElseIf ClearAllTabsToolStripMenuItem.Pressed = False Then
            Text = TabControl1.SelectedTab.Text + " - " + My.Settings.Titlebar
        End If
    End Sub

    Private Sub ResetLunaSoftWriteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim Ask As MsgBoxResult
        Dim Buttons As MessageBoxButtons
        Dim Exclamation As MessageBoxIcon
        Exclamation = MessageBoxIcon.Exclamation
        Buttons = MessageBoxButtons.YesNo
        If MessageBox.Show("Are you sure you want to reset LunaSoft Write?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.Yes Then
            My.Settings.FirstBoot = "True"
            MsgBox("We will now restart.")
            My.Settings.Username = ""
            Application.Restart()
        End If
    End Sub
    Private Sub ThemeToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DarkToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub WordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordToolStripMenuItem.Click
        If WordToolStripMenuItem.Checked = True Then
            My.Settings.Idfk = "Yes"
            CType(TabControl1.SelectedTab.Controls.Item(0), RichTextBox).WordWrap = True
        Else
            My.Settings.Idfk = "No"
            CType(TabControl1.SelectedTab.Controls.Item(0), RichTextBox).WordWrap = False
        End If
    End Sub

    Private Sub USERNAMEToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ShowMoreAdvancedOtionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowMoreAdvancedOtionsToolStripMenuItem.Click

        If ShowMoreAdvancedOtionsToolStripMenuItem.Text = "Close Advanced Options" Then
            ShowMoreAdvancedOtionsToolStripMenuItem.Text = "Open Advanced Options"
            Panel1.Hide()
        ElseIf ShowMoreAdvancedOtionsToolStripMenuItem.Text = "Open Advanced Options" Then
            ShowMoreAdvancedOtionsToolStripMenuItem.Text = "Close Advanced Options"
            Panel1.Show()
        End If
    End Sub

    Private Sub Panel2_Click(sender As Object, e As PaintEventArgs) Handles Panel2.Click
        Settings.Show()
    End Sub
End Class
