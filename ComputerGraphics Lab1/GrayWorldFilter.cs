using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class GrayWorldFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            float avg = (sourceColor.R + sourceColor.G + sourceColor.B) / 3.0f;
            float kR = avg / sourceColor.R;
            float kG = avg / sourceColor.G;
            float kB = avg / sourceColor.B;

            int R = Clamp((int)(kR * sourceColor.R), 0, 255);
            int G = Clamp((int)(kG * sourceColor.G), 0, 255);
            int B = Clamp((int)(kB * sourceColor.B), 0, 255);

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
