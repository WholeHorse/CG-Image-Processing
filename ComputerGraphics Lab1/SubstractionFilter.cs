using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class SubtractionFilter : Filters
    {
        private Bitmap image1, image2;

        public SubtractionFilter(Bitmap image1, Bitmap image2)
        {
            this.image1 = image1;
            this.image2 = image2;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color1 = image1.GetPixel(x, y);
            Color color2 = image2.GetPixel(x, y);
            int intensityResult = Clamp(color1.R - color2.R, 0, 255);
            return Color.FromArgb(intensityResult, intensityResult, intensityResult);
        }
    }
}
