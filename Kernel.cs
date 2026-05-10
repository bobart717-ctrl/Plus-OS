using System;
using System.Drawing;
using Cosmos.System.Graphics;
using Cosmos.System.MouseManager;
using Sys = Cosmos.System;

namespace PlusOS {
    public class Kernel : Sys.Kernel {
        Canvas canvas;

        protected override void BeforeRun() {
            canvas = FullScreenCanvas.GetCanvas(new Mode(800, 600, ColorDepth.ColorDepth32));
            MouseManager.ScreenWidth = 800;
            MouseManager.ScreenHeight = 600;
        }

        protected override void Run() {
            // 1. Фон
            canvas.Clear(Color.Black);

            // 2. Нижняя панель (твой фиолетовый из Canva)
            canvas.DrawFilledRectangle(Color.BlueViolet, 0, 560, 800, 40);

            // 3. Иконка блокнота на панели
            canvas.DrawFilledRectangle(Color.White, 20, 565, 30, 30);

            // 4. Отработка логики ввода (Клавиатура)
            Drivers.HandleKeyboard();

            // 5. Отрисовка Блокнота
            Notepad.Render(canvas);

            // 6. Мышь (серый квадрат)
            int mX = (int)MouseManager.X;
            int mY = (int)MouseManager.Y;
            canvas.DrawFilledRectangle(Color.Gray, mX, mY, 8, 8);

            // Обработка кликов
            if (MouseManager.MouseState == MouseState.Left) {
                // Открытие по иконке
                if (mX > 20 && mX < 50 && mY > 565) {
                    Notepad.IsOpen = true;
                }
                // Закрытие окна
                if (Notepad.IsOpen) {
                    Notepad.CheckClick(mX, mY);
                }
            }

            canvas.Display();
        }
    }
}
