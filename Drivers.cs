using Sys = Cosmos.System;

namespace PlusOS {
    public static class Drivers {
        public static void HandleKeyboard() {
            if (Sys.KeyboardManager.TryReadKey(out var key)) {
                if (Notepad.IsOpen) {
                    // Обработка Backspace (стирание)
                    if (key.Key == Sys.ConsoleKeyEx.Backspace) {
                        if (Notepad.Text.Length > 0) {
                            Notepad.Text = Notepad.Text.Remove(Notepad.Text.Length - 1);
                        }
                    }
                    // Обработка Enter (новая строка)
                    else if (key.Key == Sys.ConsoleKeyEx.Enter) {
                        Notepad.Text += "\n";
                    }
                    // Печать обычных символов
                    else {
                        Notepad.Text += key.KeyChar;
                    }
                }
            }
        }
    }
}
