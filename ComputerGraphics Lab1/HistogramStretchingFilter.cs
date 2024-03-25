using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class HistogramStretchingFilter : Filters
    {
        private int minR = 255, maxR = 0, minG = 255, maxG = 0, minB = 255, maxB = 0;

        public HistogramStretchingFilter(Bitmap sourceImage)
        {
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color pixel = sourceImage.GetPixel(i, j);
                    minR = Math.Min(minR, pixel.R);
                    maxR = Math.Max(maxR, pixel.R);
                    minG = Math.Min(minG, pixel.G);
                    maxG = Math.Max(maxG, pixel.G);
                    minB = Math.Min(minB, pixel.B);
                    maxB = Math.Max(maxB, pixel.B);
                }
            }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int newR = Clamp((sourceColor.R - minR) * 255 / (maxR - minR), 0, 255);
            int newG = Clamp((sourceColor.G - minG) * 255 / (maxG - minG), 0, 255);
            int newB = Clamp((sourceColor.B - minB) * 255 / (maxB - minB), 0, 255);
            return Color.FromArgb(newR, newG, newB);
        }
    }
}
