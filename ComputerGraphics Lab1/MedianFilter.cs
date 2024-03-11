using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class MedianFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = 1;
            int size = 2 * radius + 1;
            int[] r = new int[size * size];
            int[] g = new int[size * size];
            int[] b = new int[size * size];
            int k = 0;

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    Color currentColor = GetPixelSafe(sourceImage, Clamp(x + i, 0, sourceImage.Width - 1), Clamp(y + j, 0, sourceImage.Height - 1));
                    r[k] = currentColor.R;
                    g[k] = currentColor.G;
                    b[k] = currentColor.B;
                    k++;
                }
            }

            Array.Sort(r);
            Array.Sort(g);
            Array.Sort(b);

            return Color.FromArgb(r[size / 2], g[size / 2], b[size / 2]);
        }
        private Color GetPixelSafe(Bitmap sourceImage, int x, int y)
        {
            x = Math.Max(0, Math.Min(x, sourceImage.Width - 1));
            y = Math.Max(0, Math.Min(y, sourceImage.Height - 1));
            return sourceImage.GetPixel(x, y);
        }
    }
}
