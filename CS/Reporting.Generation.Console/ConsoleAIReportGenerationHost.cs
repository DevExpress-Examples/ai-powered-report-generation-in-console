using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.AIIntegration.Reporting;

namespace Reporting.Generation.Console {
    public class ConsoleAIReportGenerationHost : IAIReportGenerationHost {
        private int currentCursorTop;
        private bool isFirstStatusLine = true;
        private string lastStatus = string.Empty;

        private const int MenuInstructionsOffset = 2;

        public Task<PromptClarificationAnswer> ClarifyPromptAsync(PromptClarificationQuestion request) {
            ClearStatusLines();
            DisplayQuestion(request.Text);

            if (request.Choices != null && request.Choices.Count > 0) {
                return HandleChoiceQuestion(request.Choices);
            } else {
                return HandleTextInputQuestion();
            }
        }

        void ClearStatusLines() {
            if (!isFirstStatusLine) {
                try {
                    ClearLine(currentCursorTop - 1);
                    ClearLine(currentCursorTop);
                    System.Console.SetCursorPosition(0, currentCursorTop - 1);
                } catch {
                    System.Console.WriteLine();
                }
            }
        }

        void ClearLine(int lineNumber) {
            System.Console.SetCursorPosition(0, lineNumber);
            System.Console.Write(new string(' ', System.Console.BufferWidth - 1));
        }

        void DisplayQuestion(string questionText) {
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine();
            System.Console.WriteLine(questionText);
            System.Console.ResetColor();
            System.Console.WriteLine();
        }

        Task<PromptClarificationAnswer> HandleChoiceQuestion(IReadOnlyList<string> choices) {
            var selectedIndex = ShowInteractiveMenu(choices);
            isFirstStatusLine = true;

            if (selectedIndex == -1) {
                return Task.FromResult(PromptClarificationAnswer.Canceled());
            }

            return Task.FromResult(PromptClarificationAnswer.FromValue(choices[selectedIndex]));
        }

        Task<PromptClarificationAnswer> HandleTextInputQuestion() {
            System.Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.WriteLine("(Press Enter without text to cancel)");
            System.Console.ResetColor();
            System.Console.Write("Your answer: ");

            var answer = System.Console.ReadLine();
            System.Console.WriteLine();
            isFirstStatusLine = true;

            if (string.IsNullOrWhiteSpace(answer)) {
                return Task.FromResult(PromptClarificationAnswer.Canceled());
            }

            return Task.FromResult(PromptClarificationAnswer.FromValue(answer));
        }

        int ShowInteractiveMenu(IReadOnlyList<string> choices) {
            int selectedIndex = 0;
            var startTop = System.Console.CursorTop;

            System.Console.WriteLine("Use ↑↓ arrows to navigate, Enter to select, Esc to cancel");
            System.Console.WriteLine();

            while (true) {
                RenderMenuItems(choices, selectedIndex, startTop);
                var action = ProcessKeyInput(ref selectedIndex, choices.Count);

                if (action.HasValue) {
                    System.Console.SetCursorPosition(0, startTop + MenuInstructionsOffset + choices.Count);
                    System.Console.WriteLine();
                    return action.Value;
                }
            }
        }

        void RenderMenuItems(IReadOnlyList<string> choices, int selectedIndex, int startTop) {
            for (int i = 0; i < choices.Count; i++) {
                System.Console.SetCursorPosition(0, startTop + MenuInstructionsOffset + i);
                RenderMenuItem(choices[i], i == selectedIndex);
            }
        }

        void RenderMenuItem(string text, bool isSelected) {
            if (isSelected) {
                System.Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.ForegroundColor = ConsoleColor.Black;
                System.Console.Write($"> {text}");
                System.Console.ResetColor();
            } else {
                System.Console.Write($"  {text}");
            }

            var padding = Math.Max(0, System.Console.BufferWidth - text.Length - 3);
            System.Console.Write(new string(' ', padding));
        }

        int? ProcessKeyInput(ref int selectedIndex, int itemCount) {
            var key = System.Console.ReadKey(true);

            switch (key.Key) {
                case ConsoleKey.UpArrow:
                    selectedIndex = selectedIndex > 0 ? selectedIndex - 1 : itemCount - 1;
                    return null;
                case ConsoleKey.DownArrow:
                    selectedIndex = selectedIndex < itemCount - 1 ? selectedIndex + 1 : 0;
                    return null;
                case ConsoleKey.Enter:
                    return selectedIndex;
                case ConsoleKey.Escape:
                    return -1;
                default:
                    return null;
            }
        }

        public void NotifyAsync(string status, string reasoning) {
            bool statusChanged = lastStatus != status;
            lastStatus = status;

            if (isFirstStatusLine) {
                DisplayInitialStatus(status, reasoning);
            } else {
                UpdateStatus(status, reasoning, statusChanged);
            }
        }

        void DisplayInitialStatus(string status, string reasoning) {
            System.Console.WriteLine($"Status: {status}");
            if (!string.IsNullOrEmpty(reasoning)) {
                System.Console.Write($"Reasoning: {reasoning}");
            }
            currentCursorTop = System.Console.CursorTop;
            isFirstStatusLine = false;
        }

        void UpdateStatus(string status, string reasoning, bool statusChanged) {
            try {
                if (statusChanged) {
                    UpdateBothLines(status, reasoning);
                } else {
                    UpdateReasoningOnly(reasoning);
                }
            } catch {
                FallbackStatusDisplay(status, reasoning);
            }
        }

        void UpdateBothLines(string status, string reasoning) {
            ClearLine(currentCursorTop - 1);
            System.Console.SetCursorPosition(0, currentCursorTop - 1);
            System.Console.WriteLine($"Status: {status}");

            ClearLine(currentCursorTop);
            System.Console.SetCursorPosition(0, currentCursorTop);
            if (!string.IsNullOrEmpty(reasoning)) {
                System.Console.Write($"Reasoning: {reasoning}");
            }
        }

        void UpdateReasoningOnly(string reasoning) {
            ClearLine(currentCursorTop);
            System.Console.SetCursorPosition(0, currentCursorTop);
            if (!string.IsNullOrEmpty(reasoning)) {
                System.Console.Write($"Reasoning: {reasoning}");
            }
        }

        void FallbackStatusDisplay(string status, string reasoning) {
            System.Console.WriteLine();
            System.Console.WriteLine($"Status: {status}");
            if (!string.IsNullOrEmpty(reasoning)) {
                System.Console.Write($"Reasoning: {reasoning}");
            }
            currentCursorTop = System.Console.CursorTop;
        }
    }
}
