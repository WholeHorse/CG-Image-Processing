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
        private int minIntensity = 255;
        private int maxIntensity = 0;

        public HistogramStretchingFilter(Bitmap image)
        {
            // Calculate the minimum and maximum intensity in the image
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    int intensity = (int)((image.GetPixel(i, j).R + image.GetPixel(i, j).G + image.GetPixel(i, j).B) / 3);
                    minIntensity = Math.Min(minIntensity, intensity);
                    maxIntensity = Math.Max(maxIntensity, intensity);
                }
            }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int intensity = (int)((sourceColor.R + sourceColor.G + sourceColor.B) / 3);

            int newIntensity = (int)(((float)(intensity - minIntensity) / (maxIntensity - minIntensity)) * 255);

            Color resultColor = Color.FromArgb(newIntensity, newIntensity, newIntensity);
            return resultColor;
        }
    }
}
