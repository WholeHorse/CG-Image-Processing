using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class WavesFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            //int newX1 = (int)(x + 20 * Math.Sin(2 * Math.PI * y / 60));
            //int newY1 = y;

            int newX2 = (int)(x + 20 * Math.Sin(2 * Math.PI * x / 30));
            int newY2 = y;

            //Color color1 = GetPixelSafe(sourceImage, newX1, newY1);
            Color color2 = GetPixelSafe(sourceImage, newX2, newY2);

            // Среднее значение цветов для волнового эффекта
            int newR = color2.R;
            int newG = color2.G;
            int newB = color2.B;

            return Color.FromArgb(Clamp(newR, 0, 255), Clamp(newG, 0, 255), Clamp(newB, 0, 255));
        }

        private Color GetPixelSafe(Bitmap image, int x, int y)
        {
            x = Clamp(x, 0, image.Width - 1);
            y = Clamp(y, 0, image.Height - 1);
            return image.GetPixel(x, y);
        }
    }
}
