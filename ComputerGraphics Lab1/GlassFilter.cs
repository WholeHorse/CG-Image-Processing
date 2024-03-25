using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class GlassFilter : Filters
    {
        Random rnd = new Random(1);
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Random rand = new Random();
            int newX = (int)(x + (rnd.NextDouble() - 0.5) * 10);
            int newY = (int)(y + (rnd.NextDouble() - 0.5) * 10);
            newX = Math.Max(0, Math.Min(sourceImage.Width - 1, newX));
            newY = Math.Max(0, Math.Min(sourceImage.Height - 1, newY));
            return sourceImage.GetPixel(newX, newY);
        }
    }
}
