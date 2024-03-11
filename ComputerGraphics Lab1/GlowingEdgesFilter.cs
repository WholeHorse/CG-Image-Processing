using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_Lab1
{
    internal class GlowingEdgesFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color medianColor = calculateMedianColor(sourceImage, x, y);
            Color edgeColor = calculateEdgeColor(sourceImage, x, y, medianColor);

            int newR = Math.Max(medianColor.R, edgeColor.R);
            int newG = Math.Max(medianColor.G, edgeColor.G);
            int newB = Math.Max(medianColor.B, edgeColor.B);

            return Color.FromArgb(Clamp(newR, 0, 255), Clamp(newG, 0, 255), Clamp(newB, 0, 255));
        }

        private Color calculateMedianColor(Bitmap sourceImage, int x, int y)
        {
            Color color1 = GetPixelSafe(sourceImage, x - 1, y - 1);
            Color color2 = GetPixelSafe(sourceImage, x, y - 1);
            Color color3 = GetPixelSafe(sourceImage, x + 1, y - 1);
            Color color4 = GetPixelSafe(sourceImage, x - 1, y);
            Color color5 = GetPixelSafe(sourceImage, x, y);
            Color color6 = GetPixelSafe(sourceImage, x + 1, y);
            Color color7 = GetPixelSafe(sourceImage, x - 1, y + 1);
            Color color8 = GetPixelSafe(sourceImage, x, y + 1);
            Color color9 = GetPixelSafe(sourceImage, x + 1, y + 1);

            int newR = (color1.R + color2.R + color3.R + color4.R + color5.R + color6.R + color7.R + color8.R + color9.R) / 9;
            int newG = (color1.G + color2.G + color3.G + color4.G + color5.G + color6.G + color7.G + color8.G + color9.G) / 9;
            int newB = (color1.B + color2.B + color3.B + color4.B + color5.B + color6.B + color7.B + color8.B + color9.B) / 9;

            return Color.FromArgb(newR, newG, newB);
        }

        private Color calculateEdgeColor(Bitmap sourceImage, int x, int y, Color medianColor)
        {
            int edgeThreshold = 150;

            int gradientX = GetGradient(sourceImage, x - 1, y, x + 1, y);
            int gradientY = GetGradient(sourceImage, x, y - 1, x, y + 1);

            int gradientMagnitude = (int)Math.Sqrt(gradientX * gradientX + gradientY * gradientY);

            if (gradientMagnitude > edgeThreshold)
            {
                return Color.FromArgb(Math.Min(medianColor.R + gradientMagnitude, 255),
                                       Math.Min(medianColor.G + gradientMagnitude, 255),
                                       Math.Min(medianColor.B + gradientMagnitude, 255));
            }
            else
            {
                return medianColor;
            }
        }

        private int GetGradient(Bitmap image, int x1, int y1, int x2, int y2)
        {
            Color color1 = GetPixelSafe(image, x1, y1);
            Color color2 = GetPixelSafe(image, x2, y2);

            int gradient = Math.Abs(color1.R - color2.R) + Math.Abs(color1.G - color2.G) + Math.Abs(color1.B - color2.B);

            return gradient;
        }

        private Color GetPixelSafe(Bitmap image, int x, int y)
        {
            x = Clamp(x, 0, image.Width - 1);
            y = Clamp(y, 0, image.Height - 1);
            return image.GetPixel(x, y);
        }

        private int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(max, value));
        }
    }
}
