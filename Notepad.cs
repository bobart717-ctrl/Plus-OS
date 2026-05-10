using System.Drawing;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;

namespace PlusOS {
    public static class Notepad {
        public static bool IsOpen = false;
        public static string Text = ""; // Начинаем с пустой строки
        
        // Метод отрисовки окна
        public static void Render(Canvas canvas) {
            if (IsOpen) {
                // Основное окно (белое)
                canvas.DrawFilledRectangle(Color.White, 150, 100, 500, 350);
                
                // Заголовок окна (серая полоска)
                canvas.DrawFilledRectangle(Color.FromArgb(200, 200, 200), 150, 100, 500, 25);
                
                // Кнопка закрытия (красная)
                canvas.DrawFilledRectangle(Color.Red, 630, 105, 15, 15);

                // Отрисовка текста внутри блокнота
                // Используем стандартный шрифт Cosmos
                canvas.DrawString(Text, PCScreenFont.Default, Color.Black, 160, 130);
            }
        }

        // Проверка нажатия на кнопку закрытия
        public static void CheckClick(int x, int y) {
            if (x > 630 && x < 645 && y > 105 && y < 120) {
                IsOpen = false;
            }
        }
    }
}
