using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            int k = 50;
            int R = Clamp(intensity + 2 * k, 0, 255);
            int G = Clamp((int)(intensity + 0.5 * k), 0, 255);
            int B = Clamp(intensity - 1 * k, 0, 255);

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
