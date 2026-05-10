using System;

namespace PlusOS {
    public static class Notepad {
        public static bool IsOpen = false;
        public static string Content = "Welcome!";

        public static void Draw() {
            Kernel.WriteAt("┌──────────────────────────┐", 5, 20, 0x0F);
            Kernel.WriteAt("│ " + Content.PadRight(24) + " │", 6, 20, 0x0F);
            Kernel.WriteAt("└──────────────────────────┘", 7, 20, 0x0F);
        }

        public static void TypeChar(char c) {
            if (Content.Length < 20) {
                Content += c;
            }
        }
    }
}
