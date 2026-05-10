namespace PlusOS {
    public class Kernel {
        public static void Main() {
            DrawUI();
            
            while (true) {
                // Вызываем драйвер в каждом цикле
                Drivers.CheckKeyboard();
                
                if (Notepad.IsOpen) {
                    Notepad.Draw();
                }
                
                // Серый квадрат (курсор)
                WriteAt("█", 10, 20, 0x08);
            }
        }
        // ... (остальные методы WriteAt и DrawUI остаются как были)
    }
}
