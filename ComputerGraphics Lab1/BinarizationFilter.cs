using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class BinarizationFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int threshold = 128;
            int grayScale = (int)((sourceColor.R * 0.3) + (sourceColor.G * 0.59) + (sourceColor.B * 0.11));
            int binaryColor = grayScale > threshold ? 255 : 0;

            Color resultColor = Color.FromArgb(binaryColor, binaryColor, binaryColor);
            return resultColor;
        }
    }
}
