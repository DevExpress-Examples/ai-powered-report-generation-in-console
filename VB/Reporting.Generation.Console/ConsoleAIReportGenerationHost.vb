Imports DevExpress.AIIntegration.Reporting

Namespace Reporting.Generation.Console

    Public Class ConsoleAIReportGenerationHost
        Implements IAIReportGenerationHost

        Private currentCursorTop As Integer

        Private isFirstStatusLine As Boolean = True

        Private lastStatus As String = String.Empty

        Private Const MenuInstructionsOffset As Integer = 2

        Public Function ClarifyPromptAsync(ByVal request As PromptClarificationQuestion) As Task(Of PromptClarificationAnswer)
            ClearStatusLines()
            Me.DisplayQuestion(request.Text)
            If request.Choices IsNot Nothing AndAlso request.Choices.Count > 0 Then
                Return HandleChoiceQuestion(request.Choices)
            Else
                Return HandleTextInputQuestion()
            End If
        End Function

        Private Sub ClearStatusLines()
            If Not isFirstStatusLine Then
                Try
                    ClearLine(currentCursorTop - 1)
                    Me.ClearLine(currentCursorTop)
                    System.Console.SetCursorPosition(0, currentCursorTop - 1)
                Catch
                    System.Console.WriteLine()
                End Try
            End If
        End Sub

        Private Sub ClearLine(ByVal lineNumber As Integer)
            System.Console.SetCursorPosition(0, lineNumber)
            System.Console.Write(New String(" "c, System.Console.BufferWidth - 1))
        End Sub

        Private Sub DisplayQuestion(ByVal questionText As String)
            System.Console.ForegroundColor = ConsoleColor.Cyan
            System.Console.WriteLine()
            System.Console.WriteLine(questionText)
            System.Console.ResetColor()
            System.Console.WriteLine()
        End Sub

        Private Function HandleChoiceQuestion(ByVal choices As IReadOnlyList(Of String)) As Task(Of PromptClarificationAnswer)
            Dim selectedIndex = Me.ShowInteractiveMenu(choices)
            isFirstStatusLine = True
            If selectedIndex Is -1 Then
                Return Task.FromResult(PromptClarificationAnswer.Canceled())
            End If

            Return Task.FromResult(PromptClarificationAnswer.FromValue(choices(selectedIndex)))
        End Function

        Private Function HandleTextInputQuestion() As Task(Of PromptClarificationAnswer)
            System.Console.ForegroundColor = ConsoleColor.DarkGray
            System.Console.WriteLine("(Press Enter without text to cancel)")
            System.Console.ResetColor()
            System.Console.Write("Your answer: ")
            Dim answer = System.Console.ReadLine()
            System.Console.WriteLine()
            isFirstStatusLine = True
            If String.IsNullOrWhiteSpace(answer) Then
                Return Task.FromResult(PromptClarificationAnswer.Canceled())
            End If

            Return Task.FromResult(PromptClarificationAnswer.FromValue(answer))
        End Function

        Private Function ShowInteractiveMenu(ByVal choices As IReadOnlyList(Of String)) As Integer
            Dim selectedIndex As Integer = 0
            Dim startTop = System.Console.CursorTop
            System.Console.WriteLine("Use ↑↓ arrows to navigate, Enter to select, Esc to cancel")
            System.Console.WriteLine()
            While True
                RenderMenuItems(choices, selectedIndex, startTop)
                Dim action = ProcessKeyInput(selectedIndex, choices.Count)
                If action.HasValue Then
                    System.Console.SetCursorPosition(0, startTop + MenuInstructionsOffset + choices.Count)
                    System.Console.WriteLine()
                    Return action.Value
                End If
            End While
        End Function

        Private Sub RenderMenuItems(ByVal choices As IReadOnlyList(Of String), ByVal selectedIndex As Integer, ByVal startTop As Integer)
            For i As Integer = 0 To choices.Count - 1
                System.Console.SetCursorPosition(0, startTop + MenuInstructionsOffset + i)
                RenderMenuItem(choices(i), i Is selectedIndex)
            Next
        End Sub

        Private Sub RenderMenuItem(ByVal text As String, ByVal isSelected As Boolean)
            If isSelected Then
                System.Console.BackgroundColor = ConsoleColor.Gray
                System.Console.ForegroundColor = ConsoleColor.Black
                System.Console.Write($"> {text}")
                System.Console.ResetColor()
            Else
                System.Console.Write($"  {text}")
            End If

            Dim padding = Math.Max(0, System.Console.BufferWidth - text.Length - 3)
            System.Console.Write(New String(" "c, padding))
        End Sub

        Private Function ProcessKeyInput(ByRef selectedIndex As Integer, ByVal itemCount As Integer) As Integer?
            Dim key = System.Console.ReadKey(True)
            Select Case key.Key
                Case ConsoleKey.UpArrow
                    selectedIndex = If(selectedIndex > 0, selectedIndex - 1, itemCount - 1)
                    Return Nothing
                Case ConsoleKey.DownArrow
                    selectedIndex = If(selectedIndex < itemCount - 1, selectedIndex + 1, 0)
                    Return Nothing
                Case ConsoleKey.Enter
                    Return selectedIndex
                Case ConsoleKey.Escape
                    Return -1
                Case Else
                    Return Nothing
            End Select
        End Function

        Public Sub NotifyAsync(ByVal status As String, ByVal reasoning As String) Implements IAIReportGenerationHost.NotifyAsync
            Dim statusChanged As Boolean = Not Equals(lastStatus, status)
            lastStatus = status
            If isFirstStatusLine Then
                Me.DisplayInitialStatus(status, reasoning)
            Else
                Me.UpdateStatus(status, reasoning, statusChanged)
            End If
        End Sub

        Private Sub DisplayInitialStatus(ByVal status As String, ByVal reasoning As String)
            System.Console.WriteLine($"Status: {status}")
            If Not String.IsNullOrEmpty(reasoning) Then
                System.Console.Write($"Reasoning: {reasoning}")
            End If

            currentCursorTop = System.Console.CursorTop
            isFirstStatusLine = False
        End Sub

        Private Sub UpdateStatus(ByVal status As String, ByVal reasoning As String, ByVal statusChanged As Boolean)
            Try
                If statusChanged Then
                    Me.UpdateBothLines(status, reasoning)
                Else
                    Me.UpdateReasoningOnly(reasoning)
                End If
            Catch
                Me.FallbackStatusDisplay(status, reasoning)
            End Try
        End Sub

        Private Sub UpdateBothLines(ByVal status As String, ByVal reasoning As String)
            ClearLine(currentCursorTop - 1)
            System.Console.SetCursorPosition(0, currentCursorTop - 1)
            System.Console.WriteLine($"Status: {status}")
            Me.ClearLine(currentCursorTop)
            System.Console.SetCursorPosition(0, currentCursorTop)
            If Not String.IsNullOrEmpty(reasoning) Then
                System.Console.Write($"Reasoning: {reasoning}")
            End If
        End Sub

        Private Sub UpdateReasoningOnly(ByVal reasoning As String)
            Me.ClearLine(currentCursorTop)
            System.Console.SetCursorPosition(0, currentCursorTop)
            If Not String.IsNullOrEmpty(reasoning) Then
                System.Console.Write($"Reasoning: {reasoning}")
            End If
        End Sub

        Private Sub FallbackStatusDisplay(ByVal status As String, ByVal reasoning As String)
            System.Console.WriteLine()
            System.Console.WriteLine($"Status: {status}")
            If Not String.IsNullOrEmpty(reasoning) Then
                System.Console.Write($"Reasoning: {reasoning}")
            End If

            currentCursorTop = System.Console.CursorTop
        End Sub
    End Class
End Namespace
