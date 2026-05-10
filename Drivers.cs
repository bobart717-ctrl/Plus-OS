using System.Runtime.InteropServices;

namespace PlusOS {
    public static class Drivers {
        // Импортируем наши функции из Ассемблера
        [DllImport("*")] public static extern void outb(ushort port, byte data);
        [DllImport("*")] public static extern byte inb(ushort port);

        public static void CheckKeyboard() {
            // Проверяем, нажата ли клавиша (статус-порт 0x64)
            if ((inb(0x64) & 0x01) != 0) {
                byte scanCode = inb(0x60); // Читаем скан-код клавиши
                
                // Пример: если нажат пробел (скан-код 0x39)
                if (scanCode == 0x39) {
                    Notepad.TypeChar(' ');
                }
                // Если нажат 'N' (скан-код 0x31) - открываем блокнот
                if (scanCode == 0x31) {
                    Notepad.IsOpen = true;
                }
            }
        }
    }
}
