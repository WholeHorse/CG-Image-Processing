using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class SubtractFilter : Filters
    {
        private Bitmap originalImage;

        public SubtractFilter(Bitmap originalImage)
        {
            this.originalImage = originalImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color originalColor = originalImage.GetPixel(x, y);
            Color processedColor = sourceImage.GetPixel(x, y);

            int resultR = Clamp(Math.Abs(processedColor.R - originalColor.R), 0, 255);
            int resultG = Clamp(Math.Abs(processedColor.G - originalColor.G), 0, 255);
            int resultB = Clamp(Math.Abs(processedColor.B - originalColor.B), 0, 255);

            return Color.FromArgb(resultR, resultG, resultB);
        }
    }
}
