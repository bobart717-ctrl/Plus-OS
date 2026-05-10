using System;

namespace PlusOS {
    public class Kernel {
        private static unsafe byte* VidMem = (byte*)0xB8000;

        public static void Main() {
            DrawUI();
            
            while (true) {
                if (Notepad.IsOpen) {
                    Notepad.Draw();
                }
                // Твой курсор - серый квадрат (символ 219 - полный блок)
                WriteAt("█", 10, 20, 0x08); 
            }
        }

        public static unsafe void DrawUI() {
            // Заливка черным (как в Canva)
            for (int i = 0; i < 80 * 25 * 2; i += 2) {
                VidMem[i] = 0; VidMem[i+1] = 0x00;
            }
            // Фиолетовая панель внизу (строка 24)
            for (int i = 0; i < 80; i++) {
                WriteAt(" ", 24, i, 0x55); // 0x5 - пурпурный фон
            }
            // Иконка блокнота (белый квадрат на панели)
            WriteAt("■", 24, 2, 0x5F);
        }

        public static unsafe void WriteAt(string s, int r, int c, byte col) {
            int off = (r * 80 + c) * 2;
            foreach (char ch in s) {
                VidMem[off] = (byte)ch;
                VidMem[off + 1] = col;
                off += 2;
            }
        }
    }
}
