using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class MaximumFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = 3;
            int maxR = 0;
            int maxG = 0;
            int maxB = 0;

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    Color currentColor = GetPixelSafe(sourceImage, Clamp(x + i, 0, sourceImage.Width - 1), Clamp(y + j, 0, sourceImage.Height - 1));

                    maxR = Math.Max(maxR, currentColor.R);
                    maxG = Math.Max(maxG, currentColor.G);
                    maxB = Math.Max(maxB, currentColor.B);
                }
            }

            return Color.FromArgb(maxR, maxG, maxB);
        }
        private Color GetPixelSafe(Bitmap sourceImage, int x, int y)
        {
            x = Math.Max(0, Math.Min(x, sourceImage.Width - 1));
            y = Math.Max(0, Math.Min(y, sourceImage.Height - 1));
            return sourceImage.GetPixel(x, y);
        }
    }
}
