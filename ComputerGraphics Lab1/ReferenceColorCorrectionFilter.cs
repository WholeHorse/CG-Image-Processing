using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class ReferenceColorCorrectionFilter : Filters
    {
        private Color referenceColor;

        public ReferenceColorCorrectionFilter(Color referenceColor)
        {
            this.referenceColor = referenceColor;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            float kR = (float)referenceColor.R / 255;
            float kG = (float)referenceColor.G / 255;
            float kB = (float)referenceColor.B / 255;

            int R = Clamp((int)(sourceColor.R * kR), 0, 255);
            int G = Clamp((int)(sourceColor.G * kG), 0, 255);
            int B = Clamp((int)(sourceColor.B * kB), 0, 255);

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
