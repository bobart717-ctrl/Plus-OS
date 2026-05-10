using System.Runtime.InteropServices;

namespace PlusOS {
    public static class Drivers {
        [DllImport("*")] public static extern void outb(ushort port, byte data);
        [DllImport("*")] public static extern byte inb(ushort port);

        public static void CheckKeyboard() {
            if ((inb(0x64) & 0x01) != 0) {
                byte scanCode = inb(0x60);
                
                // Клавиша 'N' открывает блокнот
                if (scanCode == 0x31) {
                    Notepad.IsOpen = true;
                }
                // Клавиша пробел для теста печати
                if (scanCode == 0x39) {
                    Notepad.TypeChar(' ');
                }
            }
        }
    }
}
