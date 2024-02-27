using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class BrightFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int increase = 50;
            int newR = sourceColor.R + increase > 255 ? 255 : sourceColor.R + increase;
            int newG = sourceColor.G + increase > 255 ? 255 : sourceColor.G + increase;
            int newB = sourceColor.B + increase > 255 ? 255 : sourceColor.B + increase;

            Color resultColor = Color.FromArgb(newR, newG, newB);
            return resultColor;
        }
    }
}
