namespace PlusOS {
    public static class Notepad {
        public static bool IsOpen = true; // Сделаем открытым для теста
        public static string Content = "Plus OS Notepad v1.0";

        public static void Draw() {
            // Рисуем рамку блокнота
            Kernel.WriteAt("┌──────────────────────────┐", 5, 20, 0x0F);
            Kernel.WriteAt("│ " + Content.PadRight(24) + " │", 6, 20, 0x0F);
            Kernel.WriteAt("└──────────────────────────┘", 7, 20, 0x0F);
        }
    }
}
