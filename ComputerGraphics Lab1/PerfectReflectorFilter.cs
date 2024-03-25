using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class PerfectReflectorFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            float max = Math.Max(sourceColor.R, Math.Max(sourceColor.G, sourceColor.B));

            float kR = 255.0f / max;
            float kG = 255.0f / max;
            float kB = 255.0f / max;

            int R = Clamp((int)(kR * sourceColor.R), 0, 255);
            int G = Clamp((int)(kG * sourceColor.G), 0, 255);
            int B = Clamp((int)(kB * sourceColor.B), 0, 255);

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
